using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.IO;
using System.Net;
using System.Net.Http;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class Home : System.Web.UI.MasterPage
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private string strUserName= "";
        private string strUserType = "";   
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
       

        #endregion

        #region Functions

        #region LoadValue

        private void LoadValue()
        {
            try
            {
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemUOMs"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV = new DataView(oDT_General);
                    oDV.RowFilter = "uomIsactive = True";
                    oDT_General = oDV.ToTable();
                }
                //DataTable oDT_General = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
                ddlUomCDesc_mdladdUom.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlUomCDesc_mdladdUom.Items.Add(new ListItem(oDr["uomDesc"].ToString().Trim(), oDr["uomCode"].ToString().Trim()));
                }
                ddlUomDesc_mdladdUom.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlUomDesc_mdladdUom.Items.Add(new ListItem(oDr["uomDesc"].ToString().Trim(), oDr["uomCode"].ToString().Trim()));
                }


                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Module'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlModule_mdlAddModule.Items.Add(new ListItem(oDr["ModuleCode"].ToString() + "-" + oDr["ModuleName"].ToString(), oDr["ModuleCode"].ToString()));
                //    ddlModule_mdlAddSyllabusTopic.Items.Add(new ListItem(oDr["ModuleCode"].ToString() + "-" + oDr["ModuleName"].ToString(), oDr["ModuleCode"].ToString()));
                //}
                //oDT_General = oCommonEngine.ExecuteDataTable("Select TopicName,TopicName from ModuleTopics");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlTopic_mdlAddSyllabusTopic.Items.Add(new ListItem(oDr["TopicName"].ToString(), oDr["TopicName"].ToString()));
                //}
                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Course'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    if (oDr["Status"].ToString()!= "Yes")
                //    {
                //        ddlCourse_mdlAddCourse.Items.Add(new ListItem(oDr["CourseCode"].ToString() + "-" + oDr["CourseName"].ToString(), oDr["CourseCode"].ToString()));
                //        ddlCourse_mdlAddInvoiceLine.Items.Add(new ListItem(oDr["CourseCode"].ToString() + "-" + oDr["CourseName"].ToString(), oDr["CourseCode"].ToString()));
                //        ddlCourse_mdlAddQuotationLine.Items.Add(new ListItem(oDr["CourseCode"].ToString() + "-" + oDr["CourseName"].ToString(), oDr["CourseCode"].ToString()));
                //    }                  
                //}
                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Product'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    if (oDr["Status"].ToString() != "Yes")
                //    {
                //        ddlProduct_mdlAddProduct.Items.Add(new ListItem(oDr["ProductCode"].ToString() + "-" + oDr["ProductName"].ToString(), oDr["ProductCode"].ToString()));
                //        ddlProduct_mdlAddInvoiceLine.Items.Add(new ListItem(oDr["ProductCode"].ToString() + "-" + oDr["ProductName"].ToString(), oDr["ProductCode"].ToString()));
                //        ddlProduct_mdlAddQuotationLine.Items.Add(new ListItem(oDr["ProductCode"].ToString() + "-" + oDr["ProductName"].ToString(), oDr["ProductCode"].ToString()));
                //    }
                //}
                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Employee'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlEmployee_mdlCourseSyallabus_editAdd.Items.Add(new ListItem(oDr["EmployeeName"].ToString(), oDr["EmployeeCode"].ToString()));
                //    ddlEmployee_mdlCourseAssessment.Items.Add(new ListItem(oDr["EmployeeName"].ToString(), oDr["EmployeeCode"].ToString()));
                //    ddlEmployee_mdlAddSyllabusTopic.Items.Add(new ListItem(oDr["EmployeeName"].ToString(), oDr["EmployeeCode"].ToString()));
                //}

                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Student'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    if (oDr["Status"].ToString() != "Yes")
                //    {
                //        ddlstudent_mdlCourseEnrollment.Items.Add(new ListItem(oDr["StudentName"].ToString(), oDr["StudentCode"].ToString()));
                //    }
                //}
                //oDT_General =oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Cashless'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlCashlessType_mdlAddPaymentMean.Items.Add(new ListItem(oDr["Name"].ToString(), oDr["Code"].ToString()));
                //}
                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','Bank'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlCardBank_mdlAddPaymentMean.Items.Add(new ListItem(oDr["Name"].ToString(), oDr["Code"].ToString()));
                //    ddlCheckBank_mdlAddPaymentMean.Items.Add(new ListItem(oDr["Name"].ToString(), oDr["Code"].ToString()));
                //}
                //ddlCardMethod_mdlAddPaymentMean.Items.Add(new ListItem("Debit", "Debit"));
                //ddlCardMethod_mdlAddPaymentMean.Items.Add(new ListItem("Credit", "Credit"));              
                //ddlCardType_mdlAddPaymentMean.Items.Add(new ListItem("Visa", "Visa"));
                //ddlCardType_mdlAddPaymentMean.Items.Add(new ListItem("Master", "Master"));
                //ddlCardType_mdlAddPaymentMean.Items.Add(new ListItem("American Express", "American Express"));
                //ddlCardType_mdlAddPaymentMean.Items.Add(new ListItem("Discover", "Discover"));
                //ddlCardType_mdlAddPaymentMean.Items.Add(new ListItem("Others", "Others"));
                //oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + strUserCode.Trim() + "','" + strSiteCode.Trim() + "','LeadGroup'");
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlLeadGroup_mdlCampaignLeadGroup.Items.Add(new ListItem(oDr["Name"].ToString(), oDr["Code"].ToString()));
                //}

            }
            catch (Exception)
            {
                throw;
            }

        }

        private string apiCalling(string apiName)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(apiName));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);
            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            return jsonString;
        }

        #endregion

        #region Load Page Informations

        private void LoadPageInformations()
        {
            try
            {
                //oDT_General = oCommonEngine.ExecuteDataTable("Select Name from InstitutionProfile");
                //if(oDT_General.Rows.Count>0)
                //{
                //    Page.Title = ""+ oDT_General.Rows[0][0].ToString() + " | Home";
                //    lblInstitutionName.InnerText = oDT_General.Rows[0][0].ToString();
                //    lblInstitutionNameShort.InnerText = oDT_General.Rows[0][0].ToString().Substring(0,1);
                //    lblInstitutionName.InnerText = "SEQUOIA";
                //    lblInstitutionNameShort.InnerText = "SEQUOIA";
                //}

                Page.Title = "SEQUOIA | BE";
                //lblInstitutionName.InnerText = "SEQUOIA | BE";
                //lblInstitutionNameShort.InnerText = "SEQUOIA | BE";
                //lblInstitutionName.InnerText = "SEQUOIA | BE";
                //lblInstitutionNameShort.InnerText = "SEQUOIA | BE";

                //if (Session["User_UserLastLogin"] != null)
                //{ lblLastLogin_Home.InnerText = Session["User_UserLastLogin"].ToString(); }
                //else
                //{ lblLastLogin_Home.InnerText = "No Log Info...!"; }
                //lbl_VersionInfo_Home.InnerText = System.Configuration.ConfigurationManager.AppSettings["VersionInfo"];

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Bind Data
        private void BindData()
        {
            try
            {
               
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_UserName"] == null)
            {
                strUserName = "";
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                strUserName = (string)Session["User_UserName"];
            }


            if (!IsPostBack)
            {
                lbl_GlobalUserName.InnerText = "Welcome, " + strUserName.Trim();
                lbl_GlobalSignoutUserName.InnerText = strUserName.Trim();

                LoadValue();
                LoadPageInformations();
            }

        }

        protected void GlobalSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGlobalSearch_Home.Value.Trim()!="")
                {
                    Response.Redirect("~/SearchInfo.aspx?PKey="+ txtGlobalSearch_Home.Value.Trim() + "");
                }
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }
        }

    }
}