using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Request1
{

    #region Get/GetInt/GetFloat
    /// <summary>
    /// 接收传值
    /// </summary>
    /// <param name="VarName">参数名称</param>
    /// <returns>参数对应的值</returns>
    static public String Get(String VarName)
    {
        string varValue = "";
        if (HttpContext.Current.Request[VarName] != null)
            varValue = HttpContext.Current.Request[VarName].ToString();
        return varValue;
    }



    #endregion

    #region GetQ/GetQInt/GetQFloat
    /// <summary>
    /// 取URL上的参数
    /// </summary>
    /// <param name="VarName">参数名</param>
    /// <returns>返回参数</returns>
    static public String GetQ(String VarName)
    {
        string varValue = "";
        if (HttpContext.Current.Request.QueryString[VarName] != null)
            varValue = HttpContext.Current.Request.QueryString[VarName].ToString();
        return varValue;
    }


    #endregion

    #region GetF/GetFInt/GetFFloat
    /// <summary>
    /// 取POST提交的数据
    /// </summary>
    /// <param name="VarName">名称</param>
    /// <returns>返回值</returns>
    static public String GetF(String VarName)
    {
        string varValue = "";
        if (HttpContext.Current.Request.Form[VarName] != null)
            varValue = HttpContext.Current.Request.Form[VarName].ToString();
        return varValue;
    }
    #endregion

    #region IsPost/IsGet
    /// <summary>
    /// 判断当前页面是否接收到了Post请求
    /// </summary>
    /// <returns>是否接收到了Post请求</returns>
    public static bool IsPost()
    {
        return HttpContext.Current.Request.HttpMethod.Equals("POST");
    }
    /// <summary>
    /// 判断当前页面是否接收到了Get请求
    /// </summary>
    /// <returns>是否接收到了Get请求</returns>
    public static bool IsGet()
    {
        return HttpContext.Current.Request.HttpMethod.Equals("GET");
    }
    #endregion

    #region 服务器变量名
    /// <summary>
    /// 返回指定的服务器变量信息
    /// 
    /// </summary>
    /// <param name="strName">服务器变量名</param>
    /// <returns>服务器变量信息</returns>
    public static string GetServerString(string strName)
    {
        if (HttpContext.Current.Request.ServerVariables[strName] == null)
            return "";
        return HttpContext.Current.Request.ServerVariables[strName].ToString();
    }
    #endregion

    #region GetRawUrl/IsBrowserGet/IsSearchEnginesGet/GetPageName/GetQParamCount/GetFParamCount/GetParamCount/
    /// <summary>
    /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
    /// </summary>
    /// <returns>原始 URL</returns>
    public static string GetRawUrl()
    {
        return HttpContext.Current.Request.RawUrl;
    }
    /// <summary>
    /// 判断当前访问是否来自浏览器软件
    /// </summary>
    /// <returns>当前访问是否来自浏览器软件</returns>
    public static bool IsBrowserGet()
    {
        string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
        string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
        for (int i = 0; i < BrowserName.Length; i++)
        {
            if (curBrowser.IndexOf(BrowserName[i]) >= 0) return true;
        }
        return false;
    }
    /// <summary>
    /// 判断是否来自搜索引擎链接
    /// </summary>
    /// <returns>是否来自搜索引擎链接</returns>
    public static bool IsSearchEnginesGet()
    {
        if (HttpContext.Current.Request.UrlReferrer != null)
        {
            string[] strArray = new string[] { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string str = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str.IndexOf(strArray[i]) >= 0) return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 获得当前页面的名称
    /// </summary>
    /// <returns>当前页面的名称</returns>
    public static string GetPageName()
    {
        string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
        return urlArr[urlArr.Length - 1].ToLower();
    }
    /// <summary>
    /// 返回表单或Url参数的总个数
    /// </summary>
    /// <returns></returns>
    public static int GetParamCount()
    {
        return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
    }
    /// <summary>
    /// GET ParamCount
    /// </summary>
    /// <returns></returns>
    public static int GetQParamCount() { return (HttpContext.Current.Request.QueryString.Count); }
    /// <summary>
    /// POST ParamCount
    /// </summary>
    /// <returns></returns>
    public static int GetFParamCount() { return (HttpContext.Current.Request.Form.Count); }
    #endregion

    #region GetCurrentFullHost/GetHost/GetIP/GetUrl/GetReferrer/SaveRequestFile/GetOS/GetBrowser
    /// <summary>
    /// 取全IP包括端口
    /// </summary>
    /// <returns>IP和端口</returns>
    public static string GetCurrentFullHost()
    {
        HttpRequest request = HttpContext.Current.Request;
        if (!request.Url.IsDefaultPort)
            return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
        return request.Url.Host;
    }
    /// <summary>
    /// 取主机名
    /// </summary>
    /// <returns></returns>
    public static string GetHost() { return HttpContext.Current.Request.Url.Host; }
    /// <summary>
    /// 前台URL
    /// </summary>
    /// <returns></returns>
    public static string GetUrl() { return HttpContext.Current.Request.Url.ToString(); }
    /// <summary>
    /// 来源URL
    /// </summary>
    /// <returns></returns>
    public static string GetReferrer()
    {
        string str = null;
        try
        {
            str = GetServerString("HTTP_REFERER").Trim();
            if (str.Length == 0) str = HttpContext.Current.Request.UrlReferrer.ToString();
        }
        catch { }

        if (str == null) return "";
        return str;
    }
    /// <summary>
    /// 保存Request文件
    /// </summary>
    /// <param name="path">保存到文件名</param>
    public static void SaveRequestFile(string path)
    {
        if (HttpContext.Current.Request.Files.Count > 0) HttpContext.Current.Request.Files[0].SaveAs(path);
    }
    #region GetOS
    /// <summary>
    /// 取操作系统
    /// </summary>
    /// <returns>返回操作系统</returns>
    public static string GetOS()
    {
        HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
        bc = System.Web.HttpContext.Current.Request.Browser;
        return bc.Platform;
    }
    #endregion
    #region GetBrowser
    /// <summary>
    /// 取游览器
    /// </summary>
    /// <returns>返回游览器</returns>
    public static string GetBrowser()
    {
        HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
        bc = System.Web.HttpContext.Current.Request.Browser;
        return bc.Type;
    }
    #endregion
    #endregion
}

