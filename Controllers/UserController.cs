using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Dynamic;
using bageldemo.Models;

namespace bageldemo.Controllers
{
	public class UserController : Controller
    {
		[HttpGet]
		public ActionResult Login()
        {
			vmLoginModel model = new vmLoginModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult Login(vmLoginModel model)
		{

			if (!ModelState.IsValid) return View(model);

			if (!UserService.Login(model.LoginModel.UserNo, model.LoginModel.Password))
			{
				ModelState.AddModelError("LoginModel.UserNo", "帳號或密碼輸入錯誤!!!");
				return View(model);
			}
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Logout()
		{
			UserService.Logout();
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// 使用者註冊
		/// </summary>
		//[HttpGet]
		//public ActionResult Register()
		//{
		//	vmRegister model = new vmRegister();
		//	return View(model);
		//}
		/// <summary>
		/// 使用者註冊確認
		/// </summary>
		[HttpPost]
		public ActionResult Register(vmLoginModel model)
		{
			if (!ModelState.IsValid) return View(model.RegisterModel);
			using (repoUsers users = new repoUsers())
			{
				// 1. 檢查自定義驗證條件
				string str_col_name = "";
				string str_message = "";
				if(!users.CheckRegister(model.RegisterModel, ref str_col_name, ref str_message))
				{
					ModelState.AddModelError(str_col_name, str_message);
					return RedirectToAction("Register", "User", model.RegisterModel);
					//return View(model.RegisterModel);
				}
				// 2. 新增一個不合法的使用者紀錄
				string str_valid_code = users.AddRegisterUser(model.RegisterModel);
				// 3. 寄出一封電子信箱驗證信件
				str_message = users.SendRegisterMail(str_valid_code);
				if (string.IsNullOrEmpty(str_message))
					TempData["str_message"] = "系統已寄出一封電子信箱驗證信件，請到信箱中接收，並按下[信箱驗證]連結，完成註冊程序！";
				TempData["MessageText"] = users.SendRegisterMail(str_valid_code);
				return RedirectToAction("Register", "User");
			}

		}
		/// <summary>
		/// 訊息視窗
		/// </summary>
		/// <returns></returns>
		//[HttpGet]
		//public ActionResult Message()
		//{
		//	return View();
		//}
		
	}
}