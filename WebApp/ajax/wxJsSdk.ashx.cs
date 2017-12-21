using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
namespace WebApp.ajax
{

    /// <summary>
    /// wxJsSdk 的摘要说明
    /// </summary>
    public class wxJsSdk : IHttpHandler
    {
        public static string nonceStr = "";
        public static string signature = "";
        public static string timestamp = "";
        public static string appId = "wx88ac3e6ab868f62f";
        public static string openid = "";
        public static string ceshi = "";
        public static string _url = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = Request1.GetF("action");
            if (action == "error")
            {
                Log.WriteLog("ticketResult1:" + "删除成功");
                //删除文件
                string path = HttpContext.Current.Server.MapPath(@"/weixin/");
                path = path + "jsapi_ticket.json";
                File.Delete(path);
                context.Response.Write("删除成功");
            }
            else
            {
                _url = Request1.GetF("url");
                Hashtable b = getSignPackage();
                nonceStr = b["nonceStr"].ToString();
                appId = b["appId"].ToString();
                timestamp = b["timestamp"].ToString();
                signature = b["signature"].ToString();
                string json = @"wx.config({
            debug: false,
            appId: '" + appId + @"',
            timestamp: " + timestamp + @",
            nonceStr: '" + nonceStr + @"',
            signature: '" + signature + @"',
            jsApiList: [
                        'checkJsApi',
                        'onMenuShareTimeline',
                        'onMenuShareAppMessage',
                        'onMenuShareQQ',
                        'onMenuShareWeibo',
                        'hideMenuItems',
                        'showMenuItems',
                        'hideAllNonBaseMenuItem',
                        'showAllNonBaseMenuItem',
                        'translateVoice',
                        'startRecord',
                        'stopRecord',
                        'onRecordEnd',
                        'playVoice',
                        'pauseVoice',
                        'stopVoice',
                        'uploadVoice',
                        'downloadVoice',
                        'chooseImage',
                        'previewImage',
                        'uploadImage',
                        'downloadImage',
                        'getNetworkType',
                        'openLocation',
                        'getLocation',
                        'hideOptionMenu',
                        'showOptionMenu',
                        'closeWindow',
                        'scanQRCode',
                        'chooseWXPay',
                        'openProductSpecificView',
                        'addCard',
                        'chooseCard',
                        'openCard'
                      ]
        });";
                context.Response.Write(json);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //下载数据
        protected static string GetJson(string url)
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
        }
        /// <summary>
        /// 获取凭证
        /// </summary>
        /// <returns></returns>
        //protected static string Get_token()
        //{
        //    string appid = "wx88ac3e6ab868f62f";
        //    string secret = "bfbf498ac439cf67b39d13f600fe378d";
        //    string Str = "";
        //    Access_token access_token = new Access_token();
        //    Str = GetJson("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret).ToString();
        //    access_token = JsonHelper.ParseFromJson<Access_token>(Str);
        //    return access_token.access_token;
        //}
        /// <summary>
        /// 得到accesstoken 如果文件里时间 超时则重新获取  
        /// </summary>
        /// <returns></returns>
        private string Get_token()
        {
            // access_token 应该全局存储与更新，以下代码以写入到文件中做示例
            string appid = "wx88ac3e6ab868f62f";
            string secret = "bfbf498ac439cf67b39d13f600fe378d";
            string access_token = "";
            string path = HttpContext.Current.Server.MapPath(@"/weixin/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = path + "access_token.json";

            if (!File.Exists(path))
            {
                string Str = "";
                Access_token token = new Access_token();
                Str = GetJson("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret).ToString();
                token = JsonHelper.ParseFromJson<Access_token>(Str);
                access_token = token.access_token;
                //Log.WriteDebugLog("\t" + "access_token_1:" + access_token);
                if (access_token != "")
                {
                    token.expires_in = (ConvertDateTimeInt(DateTime.Now) + 7000).ToString();
                    token.access_token = access_token;

                    string json = JsonHelper.GetJson<Access_token>(token);
                    StreamWriterMetod(json, path);
                }
            }
            else
            {
                FileStream file = new FileStream(path, FileMode.Open);
                try
                {
                    var serializer = new DataContractJsonSerializer(typeof(AccToken));
                    //Log.WriteLog("access_token_2:" + access_token);
                    AccToken readJSTicket = (AccToken)serializer.ReadObject(file);
                    //Log.WriteLog("access_token_3:" + access_token);
                    file.Close();
                    if (readJSTicket.expires_in < ConvertDateTimeInt(DateTime.Now))
                    {
                        string Str = "";
                        Access_token token = new Access_token();
                        Str = GetJson("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret).ToString();
                        token = JsonHelper.ParseFromJson<Access_token>(Str);
                        access_token = token.access_token;

                        if (access_token != "")
                        {
                            token.expires_in = (ConvertDateTimeInt(DateTime.Now) + 7000).ToString();
                            token.access_token = access_token;

                            string json = JsonHelper.GetJson<Access_token>(token);
                            StreamWriterMetod(json, path);
                        }
                    }
                    else
                    {
                        access_token = readJSTicket.access_token;
                        //Log.WriteLog("\t" + "token_3:" + access_token);
                    }
                }
                catch (Exception ex)
                {
                    file.Dispose();
                    file.Close();
                    Log.WriteLog("error:" + ex.Message);

                    try
                    {
                        File.Delete(path);
                        Log.WriteLog("result:" + "删除成功！");
                    }
                    catch (Exception exc)
                    {
                        Log.WriteLog("error...:" + exc.Message);
                    }

                }
            }
            return access_token;
        }


        //得到数据包，返回使用页面  
        public Hashtable getSignPackage()
        {
            string jsapiTicket = getJsApiTicket(Get_token());
            string url = _url; //"http://msd.binland.com.cn/msd_ggl/msdIndex.htm";//HttpContext.Current.Request.Url.ToString();

            string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
            string nonceStr = createNonceStr();

            //这里参数的顺序要按照 key 值 ASCII 码升序排序  
            string rawstring = "jsapi_ticket=" + jsapiTicket + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + url + "";
            string signature = SHA1_Hash(rawstring);
            System.Collections.Hashtable signPackage = new System.Collections.Hashtable();
            signPackage.Add("appId", appId);
            signPackage.Add("nonceStr", nonceStr);
            signPackage.Add("timestamp", timestamp);
            signPackage.Add("url", url);
            signPackage.Add("signature", signature);
            signPackage.Add("rawString", rawstring);


            return signPackage;
        }


        //创建随机字符串  
        private string createNonceStr()
        {
            int length = 16;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string str = "";
            Random rad = new Random();
            for (int i = 0; i < length; i++)
            {
                str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
            }
            return str;
        }


        //得到ticket 如果文件里时间 超时则重新获取  
        private string getJsApiTicket(string accessToken)
        {
            string ticket = "";
            string path = HttpContext.Current.Server.MapPath(@"/weixin/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = path + "jsapi_ticket.json";

            if (!File.Exists(path))
            {
                string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
                Jsapi api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));
                ticket = api.ticket;
               
                if (ticket != null && ticket != "")
                {
                    api.expires_in = (ConvertDateTimeInt(DateTime.Now) + 7000).ToString();
                    api.ticket = ticket;
                    string json = JsonHelper.GetJson<Jsapi>(api);
                    StreamWriterMetod(json, path);
                }
                else
                {
                    Log.WriteLog("拉取ticket时的accessToken:" + accessToken);
                }
            }
            else
            {
                FileStream file = new FileStream(path, FileMode.Open);
                try
                {
                    var serializer = new DataContractJsonSerializer(typeof(JSTicket));
                    JSTicket readJSTicket = (JSTicket)serializer.ReadObject(file);
                    file.Close();
                    if (readJSTicket.expires_in < ConvertDateTimeInt(DateTime.Now))
                    {
                        string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
                        Jsapi api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));
                        ticket = api.ticket;
                        //Log.WriteLog("\t" + "ticket_2:" + ticket);
                        if (ticket != "")
                        {
                            api.expires_in = (ConvertDateTimeInt(DateTime.Now) + 7000).ToString();
                            api.ticket = ticket;
                            string json = JsonHelper.GetJson<Jsapi>(api);
                            StreamWriterMetod(json, path);
                        }
                    }
                    else
                    {
                        ticket = readJSTicket.ticket;
                        //Log.WriteLog("\t" + "ticket_3:" + ticket);
                    }
                }
                catch (Exception ex)
                {
                    file.Dispose();
                    file.Close();
                    Log.WriteLog("ticketError:" + ex.Message);

                    try
                    {
                        File.Delete(path);
                        Log.WriteLog("ticketResult:" + "删除成功！");
                    }
                    catch (Exception exc)
                    {
                        Log.WriteLog("ticketError...:" + exc.Message);
                    }

                }
            }
            return ticket;
        }

        //发起一个http请球，返回值  
        private string httpGet(string url)
        {
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
                string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              

                return pageHtml;
            }


            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message.ToString());
                return null;
            }
        }


        //SHA1哈希加密算法  
        public string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }


        /// <summary>  
        /// StreamWriter写入文件方法  
        /// </summary>  
        private void StreamWriterMetod(string str, string patch)
        {
            try
            {
                FileStream fsFile = new FileStream(patch, FileMode.OpenOrCreate);
                StreamWriter swWriter = new StreamWriter(fsFile);
                swWriter.WriteLine(str);
                swWriter.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>double</returns>  
        public int ConvertDateTimeInt(System.DateTime time)
        {
            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = Convert.ToInt32((time - startTime).TotalSeconds);
            return intResult;
        }
    }
    #region
    //创建JSon类 保存文件 jsapi_ticket.json  
    public class JSTicket
    {

        public string ticket { get; set; }

        public double expires_in { get; set; }
    }
    //创建 JSon类 保存文件 access_token.json  

    public class AccToken
    {

        public string access_token { get; set; }

        public double expires_in { get; set; }
    }


    //创建从微信返回结果的一个类 用于获取ticket  

    public class Jsapi
    {

        public int errcode { get; set; }

        public string errmsg { get; set; }

        public string ticket { get; set; }

        public string expires_in { get; set; }
    }
    #endregion

}