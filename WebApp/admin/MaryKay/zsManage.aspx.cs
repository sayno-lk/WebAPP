using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin.MaryKay
{
    public partial class zsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            //ClearUser();
            Response.Redirect("Login.aspx");
        }
        protected void BtnDown_Click(object sender, EventArgs e)
        {

            string url = string.Empty;//"http://localhost:1867/grabGoUpImg/qr/qr_20150918153024469.png";
            url = txtQrUrl.Value;
            //DownImgAndSave(url);

            string saveFileName = url.Substring(url.LastIndexOf("/") + 1);
            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            this.EnableViewState = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.AppendHeader("Content-Disposition", "attachment;filename=" + saveFileName);
            WebClient client = new WebClient();
            byte[] bytes = client.DownloadData(new Uri(url));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}