using bageldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// 使用者專用類別
/// </summary>
public static class UserService
{
	public static string UserNo { get; set; }
	public static string UserName { get; set; }
	public static enRole Role { get; set; }
	public static string Userinfo
	{
		get
		{
			enumClass enclass = new enumClass();
			string str_role_name = enclass.GetRoleName(Role);
			return $"{UserNo} {UserName} {str_role_name}";
		}
	}
	public static bool IsLogin { get; set; }

	/// <summary>
	/// 登入系統
	/// </summary>
	/// <param name="userNo">使用者帳號</param>
	/// <param name="userPassword">使用者密碼</param>
	/// <returns></returns>
	public static bool Login(string userNo, string userPassword)
	{
		using (repoUsers users = new repoUsers())
		{
			Logout();
			var data = users.repo
				.ReadSingle(m => m.mno == userNo && m.pass_user == userPassword);
				
			if (data == null) return false;
			enumClass enclass = new enumClass();
			IsLogin = true;
			UserNo = data.mno;
			UserName = data.mname;
			Role = enclass.GetRole(data.role_no);
			return true;
		}
	}

	/// <summary>
	/// 登出系統
	/// </summary>
	public static void Logout()
	{
		IsLogin = false;
		UserNo = "";
		UserName = "";
		Role = enRole.Guest;
		
	}
}


