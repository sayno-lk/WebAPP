using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin.MaryKay
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int classID = 0;
        public int ClassID
        {
            get { return classID; }
            set { classID = value; }
        }
    }
}