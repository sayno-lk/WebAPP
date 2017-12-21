using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        public static string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (s == "")
                {                
                    s = DateTime.Now.AddMinutes(2).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime st = Convert.ToDateTime(s);
                    if (ConvertDateTimeInt(st) < ConvertDateTimeInt(DateTime.Now))
                    {
                        s = DateTime.Now.AddMinutes(2).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                //http://a.app.qq.com/o/simple.jsp?pkgname=com.ejt.mobile.wallet
                string url = "http://fir.im/pzc5";
                //Response.Redirect(url);
                Response.Write(s);
            }
            else
            {
                Response.Write(s);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();
            Response.Write("aaa");
        }
    }
}