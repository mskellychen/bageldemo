using bageldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;


public class repoUsers : BaseClass
{
	public IRepository<Users> repo;

	public repoUsers()
	{
		repo = new EFGenericRepository<Users>(new dbEntities());
	}

	/// <summary>
	/// 使用者註冊驗證
	/// </summary>
	/// <param name="model">使用者註冊資料</param>
	/// <param name="colName">錯誤欄位</param>
	/// <param name="messageText">錯誤訊息</param>
	/// <returns></returns>
	public bool CheckRegister(vmRegister model, ref string colName, ref string messageText)
	{

		// 自定義註冊驗證
		colName = "";
		messageText = "";
		var data = repo.ReadSingle(m => m.mno == model.UserNo);
		if (data != null)
		{
			colName = "UserNo";
			messageText = "此帳號已存在!!";
			return false;
			//ModelState.AddModelError("UserNo", "此帳號已存在!!");
			//return View(model);
		}
		data = repo.ReadSingle(m => m.email_contact == model.Email);
		if (data != null)
		{
			colName = "Email";
			messageText = "此信箱已註冊!!";
			return false;
			//ModelState.AddModelError("Email", "此信箱已註冊!!");
			//return View(model);
		}
		return true;
	}

	/// <summary>
	/// 新增註冊的使用者
	/// </summary>
	/// <param name="model"></param>
	public string AddRegisterUser(vmRegister model)
	{
		string str_valid_code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
		using (Cryptographys cryp = new Cryptographys())
		{
			Users users = new Users();
			users.is_valid = false;
			users.mno = model.UserNo;
			users.mname = model.UserName;
			users.pass_user = cryp.SHA256Encode(model.Password);
			users.code_gender = "";
			users.tel_contact = "";
			users.email_contact = model.Email;
			users.addr_contact = "";
			users.title_no = "";
			users.department_no = "";
			users.date_leave = null;
			users.date_onboard = null;
			users.code_valid = str_valid_code;
			users.remark = "";
			repo.Create(users);
			repo.SaveChanges();
			users.remark = "";
			users.email_contact = model.Email;
			return str_valid_code;
		}
	}
	/// <summary>
	/// 寄出一封電子信箱驗證信件
	/// </summary>
	/// <param name="validCode">驗證碼</param>
	public string SendRegisterMail(string validCode)
	{
		using (AppMail appMail = new AppMail())
		{
			return appMail.UserRegister(validCode);
		}
	}

}
