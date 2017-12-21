using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

/// <summary>
///OAuth 的摘要说明
/// </summary>
public class OAuth
{
    public OAuth()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //用户同意授权，获取code
    public static string Get_code(string RedirectUri)
    {
        //snsapi_userinfo 

        string MyAppid = "wx88ac3e6ab868f62f";//微信应用Id  
        //string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + MyAppid + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
        string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + MyAppid + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
        //Log.WriteDebugLog(URL);
        return URL;
    }

    /// <summary>
    /// 获得Token
    /// </summary>
    /// <param name="Code"></param>
    /// <returns></returns>
    public static OAuth_Token Get_token(string Code)
    {
        string Appid = "wx88ac3e6ab868f62f";
        string appsecret = "bfbf498ac439cf67b39d13f600fe378d";
        string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + Appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
        OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
        return Oauth_Token_Model;
    }
    //下载数据
    public static string GetJson(string url)
    {
        string res = "";
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
        req.Method = "GET";
        using (WebResponse wr = req.GetResponse())
        {
            HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            res = reader.ReadToEnd();
        }
        return res;
        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        //WebClient wc = new WebClient();
        //wc.Credentials = CredentialCache.DefaultCredentials;
        //wc.Encoding = Encoding.UTF8;
        //string returnText = wc.DownloadString(url);

        //if (returnText.Contains("errcode"))
        //{
        //    //Response.Redirect("http://weixin.quantumfilm.com.cn/Weixin/indexShow.aspx");
        //    //可能发生错误
        //}
        ////Response.Write(returnText);
        //return returnText;
    }
}