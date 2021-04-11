using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class VendorList : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AlertMessage"] != null)
            {
                oCommonEngine.SetAlert(this.Page, Session["AlertMessage"].ToString(), Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                Session["AlertMessage"] = null;
            }
        }
    }
}