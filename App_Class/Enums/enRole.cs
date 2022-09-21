using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 角色枚舉類型
/// </summary>
public enum enRole
{
	/// <summary>
	/// 訪客
	/// </summary>
	Guest = 0,
	/// <summary>
	/// 使用者
	/// </summary>
	User = 1,
	/// <summary>
	/// 管理者
	/// </summary>
	Mis = 2,
	/// <summary>
	/// 廠商
	/// </summary>
	Vendor = 3 
}

/// <summary>
/// 枚舉類型的類別
/// </summary>
public partial class enumClass
{
	/// <summary>
	/// 取得角色名稱
	/// </summary>
	/// <param name="role">角色</param>
	/// <returns></returns>
	public string GetRoleName(enRole role)
	{
		string str_value = "未定義";
		if (role == enRole.Guest) str_value = "訪客";
		if (role == enRole.User) str_value = "使用者";
		if (role == enRole.Mis) str_value = "管理者";
		if (role == enRole.Vendor) str_value = "廠商";
		return str_value;
	}
	/// <summary>
	/// 取得角色
	/// </summary>
	/// <param name="role">角色</param>
	/// <returns></returns>
	public enRole GetRole(string role)
	{
		enRole en_value = enRole.Guest;
		if (role == "Guest") en_value = enRole.Guest;
		if (role == "User") en_value = enRole.User;
		if (role == "Mis") en_value = enRole.Mis;
		if (role == "Vendor") en_value = enRole.Vendor;
		return en_value;
	}
}
