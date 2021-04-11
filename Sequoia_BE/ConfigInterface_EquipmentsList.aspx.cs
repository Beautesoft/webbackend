using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sequoia_BE
{
    public partial class ConfigInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User_UserCode"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

        }
    }
}