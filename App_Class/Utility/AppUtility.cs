using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// 應用程式工具類別
/// </summary>
public class AppUtility : BaseClass
{
    /// <summary>
    /// 取得完整的 Request URL
    /// 參考:https://blog.miniasp.com/post/2008/02/10/How-Do-I-Get-Paths-and-URL-fragments-from-the-HttpRequest-object
    /// 範例:http://localhost:1897/News/Press/Content.aspx/123?id=1#toc
    /// </summary>
    /// <returns>
    ///     返回:http://localhost:1897/News/Press/Content.aspx/123?id=1
    /// </returns>
    public string GetRequestUrl()
    {
        return HttpContext.Current.Request.Url.AbsoluteUri;
    }
    /// <summary>
    /// 取得 Request URL 中的路徑，不包含 Domain 部份 (http://localhost:1897)
    /// 參考:https://blog.miniasp.com/post/2008/02/10/How-Do-I-Get-Paths-and-URL-fragments-from-the-HttpRequest-object
    /// 範例:http://localhost:1897/News/Press/Content.aspx/123?id=1#toc
    /// </summary>
    /// <returns>
    ///     返回: /News/Press/Content.aspx/123?id=1
    /// </returns>
    public string GetRequestUrlPathAndQuery()
    {
        return HttpContext.Current.Request.Url.PathAndQuery;
    }
    /// <summary>
    /// 取得 Request URL 中的 Domain 部份
    /// 參考:https://blog.miniasp.com/post/2008/02/10/How-Do-I-Get-Paths-and-URL-fragments-from-the-HttpRequest-object
    /// 範例:http://localhost:1897/News/Press/Content.aspx/123?id=1#toc
    ///      Url.Scheme = http
    ///      Url.Authority = localhost:1897
    /// </summary>
    /// <returns>
    ///     返回:http://localhost:1897
    /// </returns>
    public string GetRequestDomain()
    {
        string str_seheme = HttpContext.Current.Request.Url.Scheme;
        string str_authority = HttpContext.Current.Request.Url.Authority;
        return string.Format("{0}://{1}", str_seheme ,str_authority);
    }

    /// <summary>
    /// 取得 Request URL 中的 Domain 部份加上指定的網址
    /// 參考:https://blog.miniasp.com/post/2008/02/10/How-Do-I-Get-Paths-and-URL-fragments-from-the-HttpRequest-object
    /// 範例:http://localhost:1897/News/Press/Content.aspx/123?id=1#toc
    /// </summary>
    /// <param name="url">Home/Index</param>
    /// <returns>
    ///     返回:http://localhost:1897/Home/Index
    /// </returns>
    public string GetRequestUrl(string url)
    {
        string str_domain = GetRequestDomain();
        if (url.Substring(0 , 1) != "/") url = "/" + url;
        return string.Format("{0}{1}", str_domain, url);
    }

    /// <summary>
    /// 檔案上傳時另存到指定位置
    /// </summary>
    /// <param name="file">上傳的檔案物件</param>
    /// <param name="filePath">另存的路徑,如 ~/Images/User</param>
    /// <param name="fileName">另存的檔名,如 001.jpg</param>
    /// <returns></returns>
    public string FileUpload(HttpPostedFileBase file , string filePath , string fileName)
    {
        string str_message = string.Empty;
        if (file != null)
        {
            if (file.ContentLength > 0)
            {
                try
                { 
                var path = Path.Combine(HttpContext.Current.Server.MapPath(filePath), fileName);
                if (File.Exists(path)) File.Delete(path);
                file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    str_message = ex.Message;
                }
            }
        }
        return str_message;
    }
}