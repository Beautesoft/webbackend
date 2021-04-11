using Newtonsoft.Json;
using System;
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
    public partial class RangeMasterVoucher : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private string _PKey = "";
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_Lead = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        private DataTable oDT_atStudent = new DataTable();

        public class RangeMasterProductInput
        {
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public string itmBrand { get; set; }
            public string itmDept { get; set; }
            public bool itmStatus { get; set; }
            public bool isproduct { get; set; }
            public bool prepaidForProduct { get; set; }
            public bool prepaidForService { get; set; }
            public bool prepaidForAll { get; set; }
            public bool isservice { get; set; }
            public bool isvoucher { get; set; }
            public bool isprepaid { get; set; }
            public bool iscompound { get; set; }
        }

        public class itemBrandlist
        {
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
        }


        public class ControlNos
        {
            public string controlNo { get; set; }
        }




        #endregion
        #region Functions
        #region LoadValue
        private void LoadValue()
        {

            try
            {

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemVendorlists"), (typeof(DataTable)));
                //ddl_supplier.Items.Add(new ListItem("", "Select your option"));
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddl_supplier.Items.Add(new ListItem(oDr["ivlVendordesc"].ToString().Trim(), oDr["itemCode"].ToString().Trim()));
                //}

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemSitelists"), (typeof(DataTable)));
                //if (oDT_General.Rows.Count > 0 && stockListingMaster.Rows.Count == 1)
                //{
                //    for (int i = 0; i < oDT_General.Rows.Count; i++)
                //    {
                //        HtmlTableRow _Row = new HtmlTableRow();
                //        HtmlTableCell Col_1 = new HtmlTableCell();
                //        Col_1.InnerText = oDT_General.Rows[i]["itemsiteCode"].ToString();

                //        _Row.Controls.Add(Col_1);
                //        HtmlTableCell Col_2 = new HtmlTableCell();
                //        Col_2.InnerText = oDT_General.Rows[i]["itemsiteDesc"].ToString();
                //        _Row.Controls.Add(Col_2);
                //        HtmlTableCell Col_3 = new HtmlTableCell();
                //        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                //        Col_3.InnerHtml = "<input type='checkbox' class='case'>";
                //        _Row.Controls.Add(Col_3);
                //        stockListingMaster.Rows.Add(_Row);
                //    }
                //}

            }
            catch (Exception Ex)
            {
                throw;
            }
        }


        private string apiCalling( string apiName)
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
        /// <summary>
        /// 
        /// </summary>
        private void LoadPageInformations()
        {
            //try
            //{

            //    oDT_General = oCommonEngine.ExecuteDataTable("Select * from StudentMaster Where StudentCode='" + _PKey + "'");
            //    oDT_atStudent = oCommonEngine.ExecuteDataTable("Select *,'Y' [Existing] from Attachments Where  Document='Student' and PrimaryKey='" + _PKey + "'");
            //    Session["oDT_atStudent"] = oDT_atStudent;
            //    if (oDT_General.Rows.Count == 1)
            //    {
            //        lblLastUpdateInfo_Student.InnerText = "[Last Updated:" + Convert.ToDateTime(oDT_General.Rows[0]["UpdateDate"]).ToString("dd/MM/yyyy hh:mm tt") + "]";

            //        txtCode_Student.Value = oDT_General.Rows[0]["StudentCode"].ToString();
            //        txtName_Student.Value = oDT_General.Rows[0]["StudentName"].ToString();
            //        ddlStudentType.Items.FindByValue(oDT_General.Rows[0]["StudentType"].ToString().Trim()).Selected = true;
            //        ddlIDType.Items.FindByValue(oDT_General.Rows[0]["IDType"].ToString().Trim()).Selected = true;
            //        ddlNationality.Items.FindByValue(oDT_General.Rows[0]["Nationality"].ToString().Trim()).Selected = true;
            //        txtID_Student.Value = oDT_General.Rows[0]["IDNumber"].ToString();
            //        if (oDT_General.Rows[0]["DOB"].ToString().Trim() != "")
            //        { dtDateOfBirth_Student.Value = Convert.ToDateTime(oDT_General.Rows[0]["DOB"].ToString().Trim()).ToString("dd/MM/yyyy"); }
            //        if (oDT_General.Rows[0]["RegDate"].ToString().Trim() != "")
            //        { dtRegistration_Student.Value = Convert.ToDateTime(oDT_General.Rows[0]["RegDate"].ToString().Trim()).ToString("dd/MM/yyyy"); }
            //        txtEmail_Student.Value = oDT_General.Rows[0]["Email"].ToString().Trim();
            //        txtContact1_Student.Value = oDT_General.Rows[0]["Contact"].ToString().Trim();
            //        txtContact2_Student.Value = oDT_General.Rows[0]["Contact2"].ToString().Trim();
            //        txtEmergencyContact_Student.Value = oDT_General.Rows[0]["EmergencyContact"].ToString().Trim();
            //        ddlGender.Items.FindByValue(oDT_General.Rows[0]["Gender"].ToString().Trim()).Selected = true;
            //        ddlStatus.Items.FindByValue(oDT_General.Rows[0]["MStatus"].ToString().Trim()).Selected = true;
            //        ddlRace.Items.FindByValue(oDT_General.Rows[0]["Race"].ToString().Trim()).Selected = true;
            //        txtBilltoAddress_Student.Value = oDT_General.Rows[0]["Address"].ToString();
            //        txtPinCode_Student.Value = oDT_General.Rows[0]["PinCode"].ToString();
            //        if (oDT_General.Rows[0]["LeadCode"].ToString().Trim() != "")
            //        {
            //            lblLead_Student.Text = oDT_General.Rows[0]["LeadCode"].ToString().Trim() + " Converted At:" + Convert.ToDateTime(oDT_General.Rows[0]["ConvertedOn"].ToString().Trim()).ToString("dd/MM/yyyy");
            //            lblLead_Student.NavigateUrl = "LeadMaster.aspx?PKey=" + oDT_General.Rows[0]["LeadCode"].ToString() + "";
            //        }
            //        txtBalance_Student.NavigateUrl = "StudentAccount.aspx?PKey=" + oDT_General.Rows[0]["StudentCode"].ToString() + "";
            //        txtBalance_Student.Text= oDT_General.Rows[0]["Balance"].ToString();
            //        if (oDT_General.Rows[0]["OtherSiteAccess"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["OtherSiteAccess"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlOtherSiteAccess.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
                    
            //        if (oDT_General.Rows[0]["PreferredLanguage1"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredLanguage1"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPrefferedLanguage.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        if (oDT_General.Rows[0]["PreferredType"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredType"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPrefferedType.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }

            //        ddlNextProgression.Items.FindByValue(oDT_General.Rows[0]["NextProgression"].ToString().Trim()).Selected = true;
            //        ddlEmployerName_student.Items.FindByValue(oDT_General.Rows[0]["EmpName"].ToString().Trim()).Selected = true;
            //        txtEmployerNameNone_student.Value = oDT_General.Rows[0]["EmpNameNone"].ToString();
            //        ddlAcademic.Items.FindByValue(oDT_General.Rows[0]["Academic"].ToString()).Selected = true;
            //        if (oDT_General.Rows[0]["PreferredCourseCategory"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredCourseCategory"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPreferCoursecategory.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        if (oDT_General.Rows[0]["PreferredCourseMode"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredCourseMode"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPreferCourseMode.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        txtDesignation_student.Value = oDT_General.Rows[0]["EmpDesignation"].ToString();
            //        txtBasicSalary_student.Value = oDT_General.Rows[0]["EmpSalary"].ToString();
            //        ddlEmploymentStatus.Items.FindByValue(oDT_General.Rows[0]["EmpStatus"].ToString()).Selected = true;
            //        txtRemarks_Student.Value = oDT_General.Rows[0]["Remarks"].ToString();
            //        if (oDT_General.Rows[0]["InActive"].ToString() == "Y")
            //        {
            //            chkInActive_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkInActive_Student.Checked = false;
            //        }
            //        if (oDT_General.Rows[0]["ActiveSMS"].ToString() == "Y")
            //        {
            //            chkSendSMS_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkSendSMS_Student.Checked = false;
            //        }
            //        if (oDT_General.Rows[0]["ActiveEMail"].ToString() == "Y")
            //        {
            //            chkSendEmail_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkSendEmail_Student.Checked = false;
            //        }

            //        btnOperation.InnerText = "Update";
            //        txtCode_Student.Disabled = true;
            //        LoadHTMLTable();
            //    }
            //    else
            //    {
            //        ddlNationality.Items.FindByValue("SG").Selected = true;
            //        ddlIDType.Items.FindByValue("SINGAPOREAN").Selected = true;
            //        try { ddlOtherSiteAccess.Items.FindByValue(strSiteCode.Trim()).Selected = true; }
            //        catch (Exception Ex1) { }
            //        if (Session["LeadToStudent"] != null)
            //        {
            //            oDT_Lead = oCommonEngine.ExecuteDataTable("Select * from LeadMaster T0 Where T0.LeadCode='" + Session["LeadToStudent"].ToString() + "'");
            //            if (oDT_Lead.Rows.Count > 0)
            //            {
            //                lblLead_Student.Text = oDT_Lead.Rows[0]["LeadCode"].ToString();
            //                lblLead_Student.NavigateUrl = "LeadMaster.aspx?PKey=" + oDT_Lead.Rows[0]["LeadCode"].ToString() + "";
            //                txtName_Student.Value = oDT_Lead.Rows[0]["LeadName"].ToString();
            //                ddlNationality.Items.FindByValue(oDT_Lead.Rows[0]["Nationality"].ToString().Trim()).Selected = true;
            //                txtContact1_Student.Value = oDT_Lead.Rows[0]["Contact"].ToString().Trim();
            //                txtContact2_Student.Value = oDT_Lead.Rows[0]["Contact2"].ToString().Trim();
            //                txtEmail_Student.Value = oDT_Lead.Rows[0]["Email"].ToString().Trim();                                                    
            //                if (oDT_Lead.Rows[0]["PreferredLanguage1"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredLanguage1"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPrefferedLanguage.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredType"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredType"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPrefferedType.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredCourseCategory"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredCourseCategory"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPreferCoursecategory.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredCourseMode"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredCourseMode"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPreferCourseMode.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["ActiveSMS"].ToString() == "Y")
            //                {
            //                    chkSendSMS_Student.Checked = true;
            //                }
            //                else
            //                {
            //                    chkSendSMS_Student.Checked = false;
            //                }
            //                if (oDT_Lead.Rows[0]["ActiveEMail"].ToString() == "Y")
            //                {
            //                    chkSendEmail_Student.Checked = true;
            //                }
            //                else
            //                {
            //                    chkSendEmail_Student.Checked = false;
            //                }
            //                txtRemarks_Student.Value = oDT_Lead.Rows[0]["Remarks"].ToString();
            //            }
            //            Session["LeadToStudent"] = null;
            //        }
            //        btnOperation.InnerText = "Add";
            //        lblLastUpdateInfo_Student.InnerText = "";
            //        ddlEmployerName_student.Items.FindByValue("-").Selected = true;
            //        txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
            //        dtRegistration_Student.Value = DateTime.Now.ToString("dd/MM/yyyy");
            //        txtCode_Student.Disabled = false;
            //    }
            //    if (strSiteCode != "HQ01")
            //    {
            //        ddlOtherSiteAccess.Disabled = true;
            //    }
            //    else
            //    {
            //        ddlOtherSiteAccess.Disabled = false;
            //    }

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Bind Data
        private void BindData()
        {
            //try
            //{
            //    oDT_General = oCommonEngine.ExecuteDataTable("Select * from StudentMaster Where StudentCode='" + _PKey + "'");
            //    oDT_atStudent = (DataTable)Session["oDT_atStudent"];
            //    oDT_General.TableName = "Student";
            //    oDT_atStudent.TableName = "Attachment";
            //    if (oDT_General.Rows.Count == 0)
            //    {
            //        DataRow oDr = oDT_General.NewRow();
            //        oDr["StudentCode"] = txtCode_Student.Value.ToString().Trim().Replace("'", ""); 
            //        oDr["StudentName"] = txtName_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentType"] = ddlStudentType.Items[ddlStudentType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDType"] = ddlIDType.Items[ddlIDType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Nationality"] = ddlNationality.Items[ddlNationality.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDNumber"] = txtID_Student.Value.ToString().Trim().Replace("'", "");
            //        if (dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["DOB"] = DateTime.ParseExact(dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["RegDate"] = DateTime.ParseExact(dtRegistration_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }

            //        oDr["Email"] = txtEmail_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact"] = txtContact1_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact2"] = txtContact2_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmergencyContact"] = txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "");

            //        oDr["Gender"] = ddlGender.Items[ddlGender.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["MStatus"] = ddlStatus.Items[ddlStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Race"] = ddlRace.Items[ddlRace.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Address"] = txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["PinCode"] = txtPinCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["LeadCode"] = lblLead_Student.Text.Trim().Replace("'", "");
            //        oDr["OtherSiteAccess"] = "";
            //        for (int i = 0; i < ddlOtherSiteAccess.Items.Count; i++)
            //        {
            //            if (ddlOtherSiteAccess.Items[i].Selected == true)
            //            { oDr["OtherSiteAccess"] = oDr["OtherSiteAccess"].ToString() + ddlOtherSiteAccess.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredLanguage1"] = "";
            //        for (int i = 0; i < ddlPrefferedLanguage.Items.Count; i++)
            //        {
            //            if (ddlPrefferedLanguage.Items[i].Selected == true)
            //            { oDr["PreferredLanguage1"] = oDr["PreferredLanguage1"].ToString() + ddlPrefferedLanguage.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredType"] = "";
            //        for (int i = 0; i < ddlPrefferedType.Items.Count; i++)
            //        {
            //            if (ddlPrefferedType.Items[i].Selected == true)
            //            { oDr["PreferredType"] = oDr["PreferredType"].ToString() + ddlPrefferedType.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }


            //        oDr["NextProgression"] = ddlNextProgression.Items[ddlNextProgression.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpName"] = ddlEmployerName_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpNameNone"] = txtEmployerNameNone_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Academic"] = ddlAcademic.Items[ddlAcademic.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["PreferredCourseCategory"] = "";
            //        for (int i = 0; i < ddlPreferCoursecategory.Items.Count; i++)
            //        {
            //            if (ddlPreferCoursecategory.Items[i].Selected == true)
            //            { oDr["PreferredCourseCategory"] = oDr["PreferredCourseCategory"].ToString() + ddlPreferCoursecategory.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredCourseMode"] = "";
            //        for (int i = 0; i < ddlPreferCourseMode.Items.Count; i++)
            //        {
            //            if (ddlPreferCourseMode.Items[i].Selected == true)
            //            { oDr["PreferredCourseMode"] = oDr["PreferredCourseMode"].ToString() + ddlPreferCourseMode.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }


            //        oDr["EmpDesignation"] = txtDesignation_student.Value.ToString().Trim().Replace("'", "");
            //        if (txtBasicSalary_student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["EmpSalary"] = Convert.ToInt32(txtBasicSalary_student.Value.ToString().Trim().Replace("'", "")); }
            //        else
            //        { oDr["EmpSalary"] = 0; }
            //        oDr["EmpStatus"] = ddlEmploymentStatus.Items[ddlEmploymentStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Remarks"] = txtRemarks_Student.Value.ToString().Trim().Replace("'", "");
            //        if (chkInActive_Student.Checked == true)
            //        {
            //            oDr["InActive"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["InActive"] = "N";
            //        }
            //        if (chkSendSMS_Student.Checked == true)
            //        {
            //            oDr["ActiveSMS"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveSMS"] = "N";
            //        }
            //        if (chkSendEmail_Student.Checked == true)
            //        {
            //            oDr["ActiveEMail"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveEMail"] = "N";
            //        }
            //        oDT_General.Rows.Add(oDr);
            //    }
            //    else
            //    {
            //        DataRow oDr = oDT_General.Rows[0];
            //        oDr["StudentCode"] = txtCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentName"] = txtName_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentType"] = ddlStudentType.Items[ddlStudentType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDType"] = ddlIDType.Items[ddlIDType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Nationality"] = ddlNationality.Items[ddlNationality.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDNumber"] = txtID_Student.Value.ToString().Trim().Replace("'", "");
            //        if (dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["DOB"] = DateTime.ParseExact(dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["RegDate"] = DateTime.ParseExact(dtRegistration_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        oDr["Email"] = txtEmail_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact"] = txtContact1_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact2"] = txtContact2_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmergencyContact"] = txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Gender"] = ddlGender.Items[ddlGender.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["MStatus"] = ddlStatus.Items[ddlStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Race"] = ddlRace.Items[ddlRace.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Address"] = txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["PinCode"] = txtPinCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["LeadCode"] = lblLead_Student.Text.Trim().Replace("'", "");
            //        oDr["OtherSiteAccess"] = "";
            //        for (int i = 0; i < ddlOtherSiteAccess.Items.Count; i++)
            //        {
            //            if (ddlOtherSiteAccess.Items[i].Selected == true)
            //            { oDr["OtherSiteAccess"] = oDr["OtherSiteAccess"].ToString() + ddlOtherSiteAccess.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredLanguage1"] = "";
            //        for (int i = 0; i < ddlPrefferedLanguage.Items.Count; i++)
            //        {
            //            if (ddlPrefferedLanguage.Items[i].Selected == true)
            //            { oDr["PreferredLanguage1"] = oDr["PreferredLanguage1"].ToString() + ddlPrefferedLanguage.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredType"] = "";
            //        for (int i = 0; i < ddlPrefferedType.Items.Count; i++)
            //        {
            //            if (ddlPrefferedType.Items[i].Selected == true)
            //            { oDr["PreferredType"] = oDr["PreferredType"].ToString() + ddlPrefferedType.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["NextProgression"] = ddlNextProgression.Items[ddlNextProgression.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpName"] = ddlEmployerName_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpNameNone"] = txtEmployerNameNone_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Academic"] = ddlAcademic.Items[ddlAcademic.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["PreferredCourseCategory"] = "";
            //        for (int i = 0; i < ddlPreferCoursecategory.Items.Count; i++)
            //        {
            //            if (ddlPreferCoursecategory.Items[i].Selected == true)
            //            { oDr["PreferredCourseCategory"] = oDr["PreferredCourseCategory"].ToString() + ddlPreferCoursecategory.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredCourseMode"] = "";
            //        for (int i = 0; i < ddlPreferCourseMode.Items.Count; i++)
            //        {
            //            if (ddlPreferCourseMode.Items[i].Selected == true)
            //            { oDr["PreferredCourseMode"] = oDr["PreferredCourseMode"].ToString() + ddlPreferCourseMode.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["EmpDesignation"] = txtDesignation_student.Value.ToString().Trim().Replace("'", "");
            //        if (txtBasicSalary_student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["EmpSalary"] = Convert.ToInt32(txtBasicSalary_student.Value.ToString().Trim().Replace("'", "")); }
            //        else
            //        { oDr["EmpSalary"] = 0; }
            //        oDr["EmpStatus"] = ddlEmploymentStatus.Items[ddlEmploymentStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Remarks"] = txtRemarks_Student.Value.ToString().Trim().Replace("'", "");
            //        if (chkInActive_Student.Checked == true)
            //        {
            //            oDr["InActive"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["InActive"] = "N";
            //        }
            //        if (chkSendSMS_Student.Checked == true)
            //        {
            //            oDr["ActiveSMS"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveSMS"] = "N";
            //        }
            //        if (chkSendEmail_Student.Checked == true)
            //        {
            //            oDr["ActiveEMail"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveEMail"] = "N";
            //        }
            //        oDr.AcceptChanges();
            //        oDT_General.AcceptChanges();
            //    }

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            bool _RetVal = false;
            return _RetVal;
            //try
            //{
            //    if (txtCode_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
            //    }
            //    if (txtName_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Name...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Registration Date...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlIDType.Items[ddlIDType.SelectedIndex].Value.Trim().Replace("'", "") == "-" && btnOperation.InnerText=="Add")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Valid ID Type...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtID_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter ID Number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtContact1_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Hand phone number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Emergency Contact number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtEmail_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter EMail...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Address...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtPinCode_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter PinCode...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }

            //    if (ddlPrefferedType.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Type...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPrefferedLanguage.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Language...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPreferCourseMode.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Course Mode...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPreferCoursecategory.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Course Category...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (oCommonEngine.IsValidEmail(txtEmail_Student.Value.ToString().Trim().Replace("'", "")) && oCommonEngine.ExecuteQueryHasRows("Select StudentCode from StudentMaster Where StudentCode<>'" + txtCode_Student.Value.ToString().Trim() + "' And EMail='" + txtEmail_Student.Value.ToString().Trim().Replace("'", "") + "'") == true)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "EMail Already Exist in Student Data...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtContact1_Student.Value != "123" && oCommonEngine.ExecuteQueryHasRows("Select StudentCode from StudentMaster Where StudentCode<>'" + txtCode_Student.Value.ToString().Trim() + "' And Contact='" + txtContact1_Student.Value.ToString().Trim().Replace("'", "") + "'") == true)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Mobile 1 Already Exist in Student Data...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    _RetVal = true;
            //    return _RetVal;
            //}
            //catch (Exception Ex)
            //{
            //    oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //    return _RetVal;
            //}
        }
        #endregion

        #region Update Table

        [WebMethod]
        public static void RemoveAttachment(string Index)
        {
            DataTable oDT_Static_StudentMaster = new DataTable();
            oDT_Static_StudentMaster = null;
            oDT_Static_StudentMaster = (DataTable)HttpContext.Current.Session["oDT_atStudent"];
            oDT_Static_StudentMaster.Rows.RemoveAt(Convert.ToInt32(Index) - 1);
            HttpContext.Current.Session["oDT_atStudent"] = oDT_Static_StudentMaster;
            oDT_Static_StudentMaster = null;

        }
        [WebMethod]
        public static void AddAttachment(string SourcePath)
        {
            DataTable oDT_Static_StudentMaster = new DataTable();
            oDT_Static_StudentMaster = null;
            oDT_Static_StudentMaster = (DataTable)HttpContext.Current.Session["oDT_atStudent"];
            DataRow oDr = oDT_Static_StudentMaster.NewRow();
            oDr["Document"] = "Student";
            oDr["ServerPath"] = (string)HttpContext.Current.Session["AttachmentPath"];
            oDr["FileInfo"] = SourcePath;
            oDr["Existing"] = "N";

            oDT_Static_StudentMaster.Rows.Add(oDr);
            HttpContext.Current.Session["oDT_atStudent"] = oDT_Static_StudentMaster;
            oDT_Static_StudentMaster = null;
        }
        #endregion

        #region Load HTML Table
        private void LoadHTMLTable()
        {
            //try
            //{

            //    oDT_atStudent = (DataTable)Session["oDT_atStudent"];
            //    if (oDT_atStudent.Rows.Count > 0 && atStudent.Rows.Count == 1)
            //    {

            //        for (int i = 0; i < oDT_atStudent.Rows.Count; i++)
            //        {
            //            HtmlTableRow _Row = new HtmlTableRow();
            //            HtmlTableCell Col_1 = new HtmlTableCell();
            //            Col_1.InnerText = oDT_atStudent.Rows[i]["FileInfo"].ToString();
            //            _Row.Controls.Add(Col_1);
            //            HtmlTableCell Col_2 = new HtmlTableCell();
            //            Col_2.Attributes.Add("style", "width: 20%; text-align:center");
            //            Col_2.InnerHtml = "<div class='tools'><i class='Download_Attachments_Student glyphicon glyphicon-download-alt'></i><i class='Remove_Attachments_Student glyphicon glyphicon-trash'></i></div>";
            //            _Row.Controls.Add(Col_2);
            //            atStudent.Rows.Add(_Row);
            //        }
            //    }


            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Upload File
        private void UploadFile()
        {
            //try
            //{
            //    string strDirectory = (string)HttpContext.Current.Session["AttachmentPath"].ToString().Trim() + "/" + txtCode_Student.Value;
            //    if (System.IO.Directory.Exists(strDirectory) ==false)
            //    {
            //        System.IO.Directory.CreateDirectory(strDirectory);
            //    }
            //    HttpFileCollection flImages = Request.Files;
            //    foreach (string _key in flImages.Keys)
            //    {
            //        HttpPostedFile flFile = flImages[_key];
            //        if (flFile.FileName != "")
            //        {
            //            string _Path =Path.Combine(strDirectory,  flFile.FileName);
            //            flFile.SaveAs(_Path);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion
        #endregion
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AlertMessage"] != null)
                {
                    oCommonEngine.SetAlert(this.Page, Session["AlertMessage"].ToString(), Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                    Session["AlertMessage"] = null;
                }
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
                if (Request.QueryString["PKey"] != null)
                {
                    using (var client1 = new HttpClient())
                    {
                        client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client1.DefaultRequestHeaders.Accept.Clear();
                        client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        bool val = true;
                        string api = "api/itemBrands?filter={\"where\":{\"voucherBrand\":\"" + val + "\"}}";
                        var response = client1.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<itemBrandlist> Brandlist = JsonConvert.DeserializeObject<List<itemBrandlist>>(a);
                            ddl_BrandRangeVoucher.DataSource = Brandlist;
                            ddl_BrandRangeVoucher.DataValueField = "itmCode";
                            ddl_BrandRangeVoucher.DataTextField = "itmDesc";
                            ddl_BrandRangeVoucher.DataBind();
                        }
                    }

                    _PKey = Request.QueryString["PKey"].ToString();
                    btnSubmit_AddRangeVoucherMaster.InnerText = "Update";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string api = "api/ItemRanges?filter={\"where\":{\"itmCode\":\"" + _PKey + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<RangeMasterProductInput> depts = JsonConvert.DeserializeObject<List<RangeMasterProductInput>>(a);
                            txtCode_RangeVoucher.Value = depts[0].itmCode;
                            txtName_RangeVoucher.Value = depts[0].itmDesc;
                            ddl_BrandRangeVoucher.Value = depts[0].itmBrand;
                            if (depts[0].itmStatus==true)
                            {
                                chk_ActiveRangeVoucher.Checked = true;
                            }
                            else
                            {
                                chk_ActiveRangeVoucher.Checked = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                }
                else
                {
                    btnSubmit_AddRangeVoucherMaster.InnerText = "Add";
                    _PKey = "";
                    //FetchRecordAsync();

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string codeDesc = "Range";
                        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<ControlNos> depts = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                            txtCode_RangeVoucher.Value = depts[0].controlNo;
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                    using (var client1 = new HttpClient())
                    {
                        client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client1.DefaultRequestHeaders.Accept.Clear();
                        client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        bool val = true;
                        string api = "api/itemBrands?filter={\"where\":{\"voucherBrand\":\"" + val + "\"}}";
                        var response = client1.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<itemBrandlist> Brandlist = JsonConvert.DeserializeObject<List<itemBrandlist>>(a);
                            ddl_BrandRangeVoucher.DataSource = Brandlist;
                            ddl_BrandRangeVoucher.DataValueField = "itmCode";
                            ddl_BrandRangeVoucher.DataTextField = "itmDesc";
                            ddl_BrandRangeVoucher.DataBind();
                        }
                    }
                    

                }
                if (!IsPostBack)
                {
                    LoadValue();
                    LoadPageInformations();
                }
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }




        [WebMethod]
        public static void AddRangeMasterVoucherData(string itmCode, string itmDesc, bool itmStatus, string itmBrand, string siteCode)
        {
            using (var client = new HttpClient())
            {
                if (string.IsNullOrEmpty(siteCode))
                    siteCode = "HQ";

                // isvoucher = false -- changed to True & isproduct = true to false for Range-->Voucher Save part On 10 Jul 2019 Imran
                RangeMasterProductInput p = new RangeMasterProductInput { itmCode = itmCode, itmDesc = itmDesc, itmStatus = itmStatus, itmBrand = itmBrand, isproduct = false, prepaidForProduct = false, prepaidForService = false, prepaidForAll = false, isservice = false, isvoucher = true, isprepaid = false, iscompound = false };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<RangeMasterProductInput>("api/ItemRanges", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.Write("Success");

                    using (var client1 = new HttpClient())
                    {
                        //client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        //client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //string desc = "Range";
                        int controlNo = int.Parse(itmCode);
                        int NewcontrolNo = controlNo + 1;
                        //string jsonData = "{'controlNo':'" + NewcontrolNo + "'}";
                        //var post1 = client.PostAsJsonAsync("api/controlno/update?[where][controlDescription]=" + desc + "", jsonData).Result;

                        var a = response.Content.ReadAsStringAsync().Result;
                        CustomerClassUpdate customerClassesUpdates = JsonConvert.DeserializeObject<CustomerClassUpdate>(a);
                        ControlNosUpdate c = new ControlNosUpdate { controldescription = "Range", sitecode= siteCode, controlnumber = Convert.ToString(NewcontrolNo) };
                        string api = "api/ControlNos/updatecontrol";
                        post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                        post.Wait();
                        response = post.Result;
                    }
                    

                }
                else
                {
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.Write("Error");
                }

            }
        }

        [WebMethod]
        public static void EditAddRangeMasterVoucherData(string itmCode, string itmDesc, bool itmStatus, string itmBrand)
        {
            using (var client = new HttpClient())
            {
                RangeMasterProductInput p = new RangeMasterProductInput { itmCode = itmCode, itmDesc = itmDesc, itmStatus = itmStatus, itmBrand = itmBrand, isproduct = true, prepaidForProduct = false, prepaidForService = false, prepaidForAll = false, isservice = false, isvoucher = true, isprepaid = false, iscompound = false };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<RangeMasterProductInput>("api/ItemRanges/update?[where][itmCode]=" + itmCode + "", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.Write("Success");
                }
                else
                {
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.Write("Error");
                }

            }
        }


        protected void aPrint_Disclaimer_Student_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/DisclaimerForm.aspx?PKey=" + txtCode_Student.Value.Trim() + "&SKey=");
        }
        protected void aPrint_AdvisoryNote_Student_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/AdvisoryNoteForm.aspx?PKey=" + txtCode_Student.Value.Trim() + "&SKey=");
        }
        protected void aPrint_PDPA_Student_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/StudentPDPA.aspx?PKey=" + txtCode_Student.Value.Trim() + "&SKey=");
        }
        protected void aPrint_Enrolment_Student_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/EnrolmentPagePrint.aspx?PKey=" + txtCode_Student.Value.Trim() + "&SKey=");
        }
        #endregion
    }
}