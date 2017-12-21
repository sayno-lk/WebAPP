using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DB;

namespace WebApp.GetingeGroup.admin
{
    public partial class msgList : System.Web.UI.Page
    {
        private VoteAndQuestionDBEntities db = new VoteAndQuestionDBEntities();
        private List<xm_Msg> list = new List<xm_Msg>();
        public int index = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie loginCookies = Request.Cookies["LoginCookies"];

            if (!IsPostBack)
            {
                LoadPrizeData();
            }
        }
        public void LoadPrizeData()
        {
            //PageIndex = 1;
            list = (from a in db.xm_Msg
                    orderby a.mTime descending
                    where a.mState == 1
                    select a).ToList();  //getCases(PageIndex, PageCount);
            repVoteInfo.DataSource = list;
            repVoteInfo.DataBind();
        }
        public string GetClass(Object obj)
        {
            string temp = obj.ToString();
            string color = "";
            switch (temp)
            {
                case "0":
                    color = "class1";
                    break;
                case "1":
                    color = "class2";
                    break;
                case "2":
                    color = "class3";
                    break;
            }
            return color;
        }
        /// <summary>
        /// 返回留言状态
        /// </summary>
        /// <param name="voteState"></param>
        /// <returns></returns>
        public string GetMsgState(string voteState)
        {
            return voteState == "0" ? "未审批" : "已审批";
            //int state = Convert.ToInt32(voteState);
            //return Enum.GetName(typeof(VoteState), state);

        }
    }
}