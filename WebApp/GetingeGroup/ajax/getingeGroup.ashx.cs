using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DB;

namespace WebApp.GetingeGroup.ajax
{
    /// <summary>
    /// getingeGroup 的摘要说明
    /// </summary>
    public class getingeGroup : IHttpHandler
    {
        private VoteAndQuestionDBEntities db = new VoteAndQuestionDBEntities();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = Request1.GetF("action");
            switch (action)
            {
                case "login":
                    context.Response.Write(Login());
                    break;
                case "addMsg":
                    context.Response.Write(AddMsg());
                    break;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public string Login()
        {
            string json = "";
            string email = Request1.GetF("email");
            xm_Employee e = (from a in db.xm_Employee
                             where a.eEmail == email
                             select a
                ).FirstOrDefault();
            if (e != null)
            {
                if (e.eSign == true)
                {
                    json = "{\"data_relult\":\"2\",\"data_msg\":\"" + e.eId + "\"}";
                }
                else
                {
                    e.eSign = true;
                    e.eSignTime = DateTime.Now;
                    db.SaveChanges();
                    json = "{\"data_relult\":\"1\",\"data_msg\":\"" + e.eId + "\"}";
                }
            }
            else
            {
                json = "{\"data_relult\":\"0\",\"data_msg\":\"不存在!\"}";
            }
            return json;
        }
        /// <summary>
        /// 留言
        /// </summary>
        /// <returns></returns>
        public string AddMsg()
        {
            string json = "";

            string mCode = Request1.GetF("mCode");
            string content = Request1.GetF("content");
            if (mCode != "" && content != "")
            {
                xm_Msg msg = new xm_Msg();
                msg.mCode = mCode;
                msg.mContent = content;
                msg.mState = 0;
                msg.mTime = DateTime.Now;

                db.AddToxm_Msg(msg);
                db.SaveChanges();
                json = "{\"data_relult\":\"1\",\"data_msg\":\"添加成功!\"}";
            }
            else
            {
                json = "{\"data_relult\":\"0\",\"data_msg\":\"留言内容不能为空!\"}";
            }
            return json;
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