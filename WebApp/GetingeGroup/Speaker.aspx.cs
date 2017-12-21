using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.GetingeGroup
{
    public partial class Speaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
                {
                    string id = Request.QueryString["Id"].ToString();
                    speakerImg.Src = "img/" + id + ".jpg";
                }
            }
        }
    }
}