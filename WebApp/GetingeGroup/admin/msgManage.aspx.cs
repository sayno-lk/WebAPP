using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DB;
using WebApp.GetingeGroup.admin.model;

namespace WebApp.GetingeGroup.admin
{
    public partial class msgManage : System.Web.UI.Page
    {
        private VoteAndQuestionDBEntities db= new VoteAndQuestionDBEntities();
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
                    orderby a.mTime descending, a.mId descending
                    where a.mState == 0
                    select a).ToList();  //getCases(PageIndex, PageCount);
            repVoteInfo.DataSource = list;
            repVoteInfo.DataBind();
        }
        protected void repVoteInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName) //修改投票状态操作
            {
                case "update":
                    UpdateVoteState(e);
                    break;
                case "del":
                    DelVoteById(e);
                    break;
            }
        }

        public void DelVoteById(RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            xm_Msg vote = (from a in db.xm_Msg
                                   where a.mId == id
                                   select a
               ).FirstOrDefault();
            if (vote != null)
            {
                db.DeleteObject(vote);
                db.SaveChanges();
                LoadPrizeData();
            }
        }
        /// <summary>
        /// 留言审批
        /// </summary>
        /// <param name="e"></param>
        public void UpdateVoteState(RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            SqlParameter[] para =
                {
                    new SqlParameter("@mId", SqlDbType.Int),
                    new SqlParameter("@mState", SqlDbType.Int),
                };
            para[0].Value = id;
            para[1].Value = 1;
            int res = GetingeGroupDBHerlper.RunProcedure("spMsg", para);
            if (res > 0)
            {
                LoadPrizeData();
            }
        }
        /// <summary>
        /// 根据投票状态返回修改按钮的文字
        /// </summary>
        /// <param name="voteState"></param>
        /// <returns></returns>
        public string GetUpdateText(string voteState)
        {
            int state = Convert.ToInt32(voteState);
            if (state == 1)
            {
                return "已审批";
            }
            else if (state == 2)
            {
                return "已拉取";
            }
            else
            {
                return "审批";
            }
        }
        //退出
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        //搜索
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //cityFlag = Convert.ToInt32(ddlVoteType.SelectedValue);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + cityFlag + "');</script>");
            //LoadPrizeData();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            List<xm_Msg> msgList = (from a in db.xm_Msg
                                            select a).ToList();
            for (int i = 0; i < msgList.Count; i++)
            {
                db.DeleteObject(msgList[i]);
                db.SaveChanges();
            }
            LoadPrizeData();
        }
        protected void btnNoDel_Click(object sender, EventArgs e)
        {
            List<xm_Msg> msgList = (from a in db.xm_Msg
                                            where a.mState == 0
                                            select a).ToList();
            for (int i = 0; i < msgList.Count; i++)
            {
                db.DeleteObject(msgList[i]);
                db.SaveChanges();
            }
            LoadPrizeData();
        }
        protected void btnYesDel_Click(object sender, EventArgs e)
        {
            List<xm_Msg> msgList = (from a in db.xm_Msg
                                            where a.mState == 1
                                            select a).ToList();
            for (int i = 0; i < msgList.Count; i++)
            {
                db.DeleteObject(msgList[i]);
                db.SaveChanges();
            }
            LoadPrizeData();
        }
        protected void ddlVoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cityFlag = Convert.ToInt32(ddlVoteType.SelectedValue);
            //LoadPrizeData();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //string tip = CreateExcel();
            //Response.Redirect(tip);
        }
        public string GetColor(Object obj)
        {
            string temp = obj.ToString();
            string color = "";
            switch (temp)
            {
                case "0":
                    color = "color:#000000";
                    break;
                case "1":
                    color = "color:#0000ff";
                    break;
                case "2":
                    color = "color:#ff0000";
                    break;
            }
            return color;
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