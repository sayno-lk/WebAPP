using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml;
using System.Net;



public class JsonHelper
{
    ///// <summary>
    ///// 生成Json格式
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="obj"></param>
    ///// <returns></returns>
    public static string GetJson<T>(T obj)
    {
        DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream stream = new MemoryStream())
        {
            json.WriteObject(stream, obj);
            string szJson = Encoding.UTF8.GetString(stream.ToArray());
            return szJson;
        }
    }
    /// <summary>
    /// 生成Json格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToJson<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
    }


    /// <summary>
    ///  过滤特殊字符
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string String2Json(String s)
    {

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {

            char c = s.ToCharArray()[i];

            switch (c)
            {

                case '\"':

                    sb.Append("\\\""); break;

                case '\\':

                    sb.Append("\\\\"); break;

                case '/':

                    sb.Append("\\/"); break;

                case '\b':

                    sb.Append("\\b"); break;

                case '\f':

                    sb.Append("\\f"); break;

                case '\n':

                    sb.Append("\\n"); break;

                case '\r':

                    sb.Append("\\r"); break;

                case '\t':

                    sb.Append("\\t"); break;

                default:

                    sb.Append(c); break;

            }

        }

        return sb.ToString();

    }
    /// <summary>
    /// 获取Json的Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="szJson"></param>
    /// <returns></returns>
    public static T ParseFromJson<T>(String json)
    {
        if (String.IsNullOrEmpty(json))
        {
            return default(T);
        }
        T obj = new JavaScriptSerializer().Deserialize<T>(json);
        return obj;
    }
    //public static T ParseFromJson<T>(string szJson)
    //{
    //    T obj = Activator.CreateInstance<T>();
    //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
    //    {
    //        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
    //        return (T)serializer.ReadObject(ms);
    //    }
    //}  
    //Json返序列化
    public static T ResolveJson<T>(String json)
    {
        if (String.IsNullOrEmpty(json))
        {
            return default(T);
        }
        T obj = new JavaScriptSerializer().Deserialize<T>(json);
        return obj;
    }

    /// <summary>
    /// 转换Json字符串到具体的对象
    /// </summary>
    /// <param name="url">返回Json数据的链接地址</param>
    /// <param name="postData">POST提交的数据</param>
    /// <returns></returns>
    //public static string ConvertJson(string url, string postData)
    //{
    //    string content = HttpHelper.GetHtml(url,postData);
    //    return content;
    //}
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
        #region
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
        //Response.Write(returnText);
        #endregion
    }

    public static string ip = "211.144.107.201";
    public static string port = "9090";
    public static string data = "http://203.156.200.68:9090/maritime/";
}