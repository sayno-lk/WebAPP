using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DB;

namespace WebApp.ajax
{
    /// <summary>
    /// AddReceipt 的摘要说明
    /// </summary>
    public class AddReceipt : IHttpHandler
    {
        private VoteAndQuestionDBEntities db = new VoteAndQuestionDBEntities();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = Request1.GetF("action");
            switch (action)
            {
                case "addReceipt":
                    context.Response.Write(GetAddReceipt());
                    break;
            }
        }

        public string GetAddReceipt()
        {
            string rName = Request1.GetF("rName");
            string rDept = Request1.GetF("rDept");
            string rPhone = Request1.GetF("rPhone");
            string rCode = Request1.GetF("rCode");
            string rBeginTime = Request1.GetF("rBeginTime");
            string rEndTime = Request1.GetF("rEndTime");
            string rBeginAddress = Request1.GetF("rBeginAddress");
            string rEndAddress = Request1.GetF("rEndAddress");
            string rPeople = Request1.GetF("rPeople");
            string rPeopleTell = Request1.GetF("rPeopleTell");
            string rStay = Request1.GetF("rStay");
            string rTravel = Request1.GetF("rTravel");

            string json = "";
            tbl_Receipt rModel = (from a in db.tbl_Receipt
                                  where a.rCode == rCode
                                  select a
                              ).FirstOrDefault();
            if (rModel != null)
            {
                json = "{\"data_result\":\"0\",\"data_msg\":\"" + "该身份证已经添加。" + "\"}";
            }
            else
            {
                rModel = new tbl_Receipt();
                rModel.rName = rName;
                rModel.rDept = rDept;
                rModel.rPhone = rPhone;
                rModel.rCode = rCode;
                rModel.rBeginTime = rBeginTime;
                rModel.rEndTime = rEndTime;
                rModel.rBeginAddress = rBeginAddress;
                rModel.rEndAddress = rEndAddress;
                rModel.rPeople = rPeople;
                rModel.rPeopleTell = rPeopleTell;
                rModel.rStay = rStay;
                rModel.rTravel = rTravel;
                rModel.rCreateTime = DateTime.Now;

                db.AddTotbl_Receipt(rModel);
                db.SaveChanges();
                json = "{\"data_result\":\"1\",\"data_msg\":\"" + rModel.rId + "\"}";
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