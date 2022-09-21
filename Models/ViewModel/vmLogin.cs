using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class vmLogin
{
	[Display(Name = "Username")] // 設定欄位標題
	[Required(ErrorMessage = "登入帳號不可空白!!!")] // 驗證
	public string UserNo { get; set; } // 帳號
	[Display(Name = "Password")]
	[Required(ErrorMessage = "登入密碼不可空白!!!")]
	[DataType(DataType.Password)] // 格式
	public string Password { get; set; } // 密碼
}
