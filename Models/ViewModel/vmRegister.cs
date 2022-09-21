using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// 使用者註冊的 ViewModel
/// </summary>
public class vmRegister
{
	[Display(Name = "Username")]
	[Required(ErrorMessage = "登入帳號不可空白!!!")]
	public string UserNo { set; get; }
	[Display(Name = "Name")]
	[Required(ErrorMessage = "登入名稱不可空白!!!")]
	public string UserName { set; get; }
	[Display(Name = "Email")]
	[Required(ErrorMessage = "電子信箱不可空白!!!")]
	[EmailAddress(ErrorMessage = "電子信箱格式輸入錯誤!!!")]
	public string Email { set; get; }
	[Display(Name = "Password")]
	[Required(ErrorMessage = "登入密碼不可空白!!!")]
	[DataType(DataType.Password)]
	public string Password { set; get; }
}
