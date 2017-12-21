using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.admin.MaryKay.ajax
{
    /// <summary>
    /// marykayUploadImg 的摘要说明
    /// </summary>
    public class marykayUploadImg : IHttpHandler
    {

        string imgSavePath = "MaryKayUploadImg";
        //private string webUrl =   "http://localhost:1867/";
        //private string webUrl = "http://wechatweb.77hudong.com/";
        private string webUrl = System.Configuration.ConfigurationManager.AppSettings["webUrl"].ToString();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = Request1.GetF("action");
            switch (action)
            {
                case "uploadZs":
                    context.Response.Write(ZsUploadImg());
                    break;
                case "uploadPhoto":
                    context.Response.Write(PhotoUploadImg());
                    break;
            }
        }

        /// <summary>
        /// 上传证书
        /// </summary>
        /// <returns></returns>
        public string ZsUploadImg()
        {
            string json = "";
            //2.上传图片
            string bgImgUrl = Request1.GetF("imgBase64");
            string imgName = "zs";
            if (bgImgUrl.Contains("data:image/jpg;base64,") || bgImgUrl.Contains("data:image/jpeg;base64,"))
            {
                imgName += ".jpg";
            }
            else
            {
                imgName += ".png";
            }
            string path = HttpRuntime.AppDomainAppPath + imgSavePath + "/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (SavePhoto(bgImgUrl, imgName, path))
            {
                string imgUrl = webUrl + imgSavePath + "/" + imgName;
                json = "{\"data_result\":\"1\",\"data_msg\":" + "\"添加成功！\",\"data_Img\":\"" + imgUrl + "\"}";
            }
            else
            {
                json = "{\"data_result\":\"0\",\"data_msg\":" + "\"图片上传失败\"" + "}";
            }
            return json;
        }
        /// <summary>
        /// 上传集体照
        /// </summary>
        /// <returns></returns>
        public string PhotoUploadImg()
        {
            string json = "";
            //2.上传图片
            string bgImgUrl = Request1.GetF("imgBase64");
            string imgName = "photo";
            if (bgImgUrl.Contains("data:image/jpg;base64,") || bgImgUrl.Contains("data:image/jpeg;base64,"))
            {
                imgName += ".jpg";
            }
            else
            {
                imgName += ".png";
            }
            string path = HttpRuntime.AppDomainAppPath + imgSavePath+"/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (SavePhoto(bgImgUrl, imgName, path))
            {
                string imgUrl = webUrl + imgSavePath + "/" + imgName ;
                json = "{\"data_result\":\"1\",\"data_msg\":" + "\"添加成功！\",\"data_Img\":\"" + imgUrl + "\"}";
            }
            else
            {
                json = "{\"data_result\":\"0\",\"data_msg\":" + "\"图片上传失败\"" + "}";
            }
            return json;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="url">图片二进制</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="proName">文件夹名称（项目名称：autoQuotationSys）</param>
        /// <returns></returns>
        public bool SavePhoto(string url, string imgName, string filePath)
        {
            WebClient client = new WebClient();
            MemoryStream stream = null;
            Image img = null;
            try
            {
                byte[] bs = null;
                //if (url.Contains("data:image/jpg;base64,"))
                //{
                //    url = url.Replace("data:image/jpg;base64,", "");
                //    bs = Convert.FromBase64String(url);
                //}

                int index = url.IndexOf(',');
                if (index > 0)
                {
                    url = url.Substring(index + 1);
                    //Log.WriteLog("base64_2:" + url);
                    bs = Convert.FromBase64String(url);
                }
                else
                {
                    bs = client.DownloadData(url);
                }

                string slink = url.Trim();
                DateTime dt = DateTime.Now;
                //创建保存裁剪图片的文件夹
                //string path = HttpRuntime.AppDomainAppPath + imgSavePath;

                // writeLog.WriteLogToStr("美图效果(path):" + path);
                //创建保存图片文件夹

                string filename = filePath + imgName;
                stream = new MemoryStream(bs, 0, bs.Length);
                img = new Bitmap(stream);
                img.Save(filename, ImageFormat.Jpeg);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                img.Dispose();
                stream.Dispose();
                client.Dispose();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}