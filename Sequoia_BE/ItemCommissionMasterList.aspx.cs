using Sequoia_BE.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sequoia_BE
{
    public partial class ItemCommissionMasterList : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["User_UserCode"] == null)
            //{
            //    strUserCode = "";
            //    strSiteCode = "";
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    strUserCode = (string)Session["User_UserCode"];
            //    strSiteCode = (string)Session["User_SiteCode"];
            //}
            
        }


        #endregion
    }
}