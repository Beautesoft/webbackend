using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sequoia_BE
{
    public partial class SiteMaster : System.Web.UI.Page
    {

        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                //BindData();
                //if (Validation())
                //{
                //    oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Operation_Masters] '" + strUserCode.ToString() + "','" + strSiteCode.ToString() + "','Corporate','" + btnOperation.InnerText.Trim() + "','" + oCommonEngine.GetXMLfromDataTable(oDT_General).ToString() + "'");
                //    if (btnOperation.InnerText.Trim() == "Add")
                //    {
                //        Session["AlertMessage"] = "Corporate: " + oDT_General.Rows[0][0].ToString() + " Created Sucessfully...!";
                //        Response.Redirect("CorporateMaster.aspx?PKey=" + txtCode_Corporate.Value.ToString().Trim() + "");
                //    }
                //    else
                //    {
                //        Session["AlertMessage"] = "Corporate: " + txtCode_Corporate.Value.ToString().Trim() + " Updated Sucessfully...!";
                //        Response.Redirect("CorporateMaster.aspx?PKey=" + txtCode_Corporate.Value.ToString().Trim() + "");
                //    }
                //}

            }
            catch (Exception Ex)
            {
                //oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }



        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}