using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// 應用程式專用類別
/// </summary>
public static class AppService
{
	/// <summary>
	/// 應用程式名稱
	/// </summary>
	public static string AppName
	{
		get
		{
			object obj_value = WebConfigurationManager.AppSettings["AppName"];
			return (obj_value == null) ? "" : obj_value.ToString();
		}
	}
	/// <summary>
	/// 應用程式版本
	/// </summary>
	public static string AppVersion { get { return GetAppSettingValue("AppVersion", ""); } }
	/// <summary>
	/// 應用程式名稱及版本
	/// </summary>
	public static string AppInfo { get { return $"{AppName} {AppVersion}"; } }
	/// <summary>
	/// 除錯模式
	/// </summary>
	public static bool DebugMode { get { return (GetAppSettingValue("DebugMode", "0") == "1"); } }
	/// <summary>
	/// 公司名稱
	/// </summary>
	public static string CompanyName { get { return GetAppSettingValue("CompanyName", "我的公司"); } }
	/// <summary>
	/// 登入 Log
	/// </summary>
	public static bool LoginLog { get { return (GetAppSettingValue("LoginLog", "0") == "1"); } }
	/// <summary>
	/// 執行程式 Log
	/// </summary>
	public static bool FormLog { get { return (GetAppSettingValue("FormLog", "0") == "1"); } }
	/// <summary>
	/// 網站網址
	/// </summary>
	public static string WebSiteUrl { get { return GetAppSettingValue("WebSiteUrl", ""); } }
	/// <summary>
	/// 資料庫連線字串
	/// </summary>
	public static string ConnectingString { get { return WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString; } }
	/// <summary>
	/// 取得 Web.config 中的 AppSettings 的值
	/// </summary>
	/// <param name="keyName">Key 名稱</param>
	/// <param name="defaultValue">預設值</param>
	/// <returns></returns>
	private static string GetAppSettingValue(string keyName, string defaultValue)
	{
		object obj_value = WebConfigurationManager.AppSettings[keyName];
		return (obj_value == null) ? defaultValue : obj_value.ToString();
	}
}
