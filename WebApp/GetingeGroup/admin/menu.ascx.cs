using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.GetingeGroup.admin
{
    public partial class menu : System.Web.UI.UserControl
    {
        private int _ClassID = 0;
        public int ClassID
        {
            get { return _ClassID; }
            set { _ClassID = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}