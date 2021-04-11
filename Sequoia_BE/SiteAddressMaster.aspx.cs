using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class SiteAddressMaster : System.Web.UI.Page
    {

        private DataTable oDT_City = new DataTable();
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string SiteGrp_Prefix = string.Empty, SiteGrp_ControlNo = string.Empty, _PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Site Group\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    SiteGrp_Prefix = controlNos[0].controlPrefix;
                    SiteGrp_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        protected void Get_SiteGroups()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/SiteGroups"));
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

            List<MasterSiteGroupsUpdate> items = new List<MasterSiteGroupsUpdate>();
            items = JsonConvert.DeserializeObject<List<MasterSiteGroupsUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isActive == true) { 

                    ddlSiteGroup.Items.Add(new ListItem(items[i].description, items[i].code + "-" + items[i].id));

                    HtmlTableRow _Row = new HtmlTableRow();
                    HtmlTableCell Col_1 = new HtmlTableCell();
                    Col_1.Attributes.Add("style", "width: 30 %");
                    Col_1.InnerText = items[i].code;
                    _Row.Controls.Add(Col_1);
                    HtmlTableCell Col_2 = new HtmlTableCell();
                    Col_2.Attributes.Add("style", "width: 50 %");
                    Col_2.InnerText = items[i].description;
                    _Row.Controls.Add(Col_2);
                    HtmlTableCell Col_3 = new HtmlTableCell();
                    Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                    if (items[i].isActive)
                    {
                        Col_3.InnerHtml = "<input type='checkbox' checked class='chk_SiteGroupMaster editor - active'>";
                    }
                    else
                    {
                        Col_3.InnerHtml = "<input type='checkbox' class='chk_SiteGroupMaster editor - active'>";
                    }
                    _Row.Controls.Add(Col_3);
                    HtmlTableCell Col_Action = new HtmlTableCell();
                    Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                    Col_Action.InnerHtml = "<div class='tools'><i class='edit_SiteGroupMaster glyphicon glyphicon-pencil'></i></div>";
                    _Row.Controls.Add(Col_Action);
                    HtmlTableCell Col_4 = new HtmlTableCell();
                    Col_4.InnerText = items[i].id.ToString();
                    Col_4.Attributes.Add("style", "width: 0px; display:none");
                    _Row.Controls.Add(Col_4);
                    Col_4 = new HtmlTableCell();
                    Col_4.InnerText = SiteGrp_Prefix;
                    Col_4.Attributes.Add("style", "width: 0px; display:none");
                    _Row.Controls.Add(Col_4);
                    Col_4 = new HtmlTableCell();
                    Col_4.InnerText = SiteGrp_ControlNo;
                    Col_4.Attributes.Add("style", "width: 0px; display:none");
                    _Row.Controls.Add(Col_4);
                    tblSite_Group.Rows.Add(_Row);

                }

            }
        }

        protected void Get_Sites()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSiteLists"));
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

            List<MasterItemSiteListsUpdate> items = new List<MasterItemSiteListsUpdate>();
            items = JsonConvert.DeserializeObject<List<MasterItemSiteListsUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 25 %");
                Col_1.InnerHtml = "<a href='SiteAddressMaster.aspx?PKey=" + items[i].itemsiteId.ToString() + "'><font color='#6a6000'><b>" + items[i].itemsiteCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 75 %");
                Col_2.InnerText = items[i].itemsiteDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_SiteMaster glyphicon glyphicon-pencil'></i></div>";
                Col_Action.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].itemsiteId.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblSiteList.Rows.Add(_Row);

            }
        }

        private void LoadValue()
        {

            try
            {
                //Load City
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Cities"), (typeof(DataTable)));
                DataView oDV = new DataView(oDT_General);
                oDT_General = oDV.ToTable();
                ddlCity.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlCity.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmId"].ToString().Trim()));
                }

                //Load State
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/States"), (typeof(DataTable)));
                DataView oDV1 = new DataView(oDT_General);
                oDT_General = oDV1.ToTable();
                ddlState.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlState.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmId"].ToString().Trim()));
                }
                //Load Country
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Countries"), (typeof(DataTable)));
                DataView oDV2 = new DataView(oDT_General);
                oDT_General = oDV2.ToTable();
                ddlCountry.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlCountry.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmId"].ToString().Trim()));
                }
            }
            catch (Exception Ex)
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

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txtSiteCode_Site.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txtSiteCode_Site.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Site Code...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (txtSiteDesc_Site.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Site Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (string.IsNullOrEmpty(ddlCity.Value))
                {
                    oCommonEngine.SetAlert(this.Page, "Please select City...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (string.IsNullOrEmpty(ddlState.Value))
                {
                    oCommonEngine.SetAlert(this.Page, "Please select State...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (string.IsNullOrEmpty(ddlState.Value))
                {
                    oCommonEngine.SetAlert(this.Page, "Please select Country...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                //if (txtPostCode_Site.Value.ToString().Trim().Replace("'", "") == "")
                //{
                //    oCommonEngine.SetAlert(this.Page, "Please enter PostCode...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                //    return _RetVal;
                //}

                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                return _RetVal;
            }
        }

        [WebMethod]
        public static void EditSite(Int32 _siteID)
        {

            //CollapsiblePanelSiteCreation.Collapsed = false;
            //CollapsiblePanelSiteCreation.ClientState = "false";


        }

        private void DataClear()
        {

            _PKey = String.Empty;
            btn_AddSite.InnerText = "Add";
            txtSiteCode_Site.Disabled = false;
            txtSiteCode_Site.Value = string.Empty;
            txtAddress_Site.Value = string.Empty;
            txtSiteDesc_Site.Value = string.Empty;
            txtPostCode_Site.Value = string.Empty;
            ddlCity.Value = string.Empty;
            ddlState.Value = string.Empty;
            ddlCountry.Value = string.Empty;
            txtContact1_Site.Value = string.Empty;
            txtContact2_Site.Value = string.Empty;
            txtFax_Site.Value = string.Empty;
            txtEMail_Site.Value = String.Empty;
            chkSalesActive_Site.Checked = false;
            chkGstActive_Site.Checked = false;
            txtSiteAcCode_Site.Value = string.Empty; 

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                //string api = "api/ItemRanges?filter={\"where\":{\"itmCode\":\"" + _PKey + "\"}}";
                string api = "api/ItemSiteLists/" + _PKey;
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    MasterItemSiteLists masterItemSite = JsonConvert.DeserializeObject<MasterItemSiteLists>(a);

                    txtSiteCode_Site.Disabled = true;
                    txtSiteCode_Site.Value = masterItemSite.itemsiteCode;
                    txtAddress_Site.Value = masterItemSite.itemsiteAddress;
                    txtSiteDesc_Site.Value = masterItemSite.itemsiteDesc;
                    txtPostCode_Site.Value = masterItemSite.itemsitePostcode;
                    ddlSiteGroup.Value = masterItemSite.siteGroup + "-" + masterItemSite.siteGroupIdId;
                    ddlCity.Value = masterItemSite.itemSiteCityIdId;
                    ddlState.Value = masterItemSite.itemSiteStateIdId;
                    ddlCountry.Value = masterItemSite.itemSiteCountryIdId;
                    txtContact1_Site.Value = masterItemSite.itemsitePhone1;
                    txtContact2_Site.Value = masterItemSite.itemsitePhone2;
                    txtFax_Site.Value = masterItemSite.itemsiteFax;
                    txtEMail_Site.Value = masterItemSite.itemsiteEmail;
                    chkSalesActive_Site.Checked = masterItemSite.itemsiteIsactive; 
                    chkGstActive_Site.Checked = masterItemSite.siteIsGst;
                    txtSiteAcCode_Site.Value = masterItemSite.accountCode;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    Get_ControlPrefixs();
                    LoadValue();
                    Get_SiteGroups();
                    Get_Sites();
                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddSite.InnerText = "Update";
                        CollapsiblePanelSiteCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddSite.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                }
                else
                {
                    Get_SiteGroups();
                    Get_Sites();
                }

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }


             
             

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }

        protected void DdlSiteHeader_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
               // LoadPageInformations();
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }


        }

        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    string[] stringSeparators = new string[] { "-" };
                    string[] siteCodeandId = ddlSiteGroup.Value.ToString().Trim().Split(stringSeparators, StringSplitOptions.None);

                    if (btn_AddSite.InnerText.Trim() == "Add")
                    {
                       
                        using (var client = new HttpClient())
                        {
                          
                            MasterItemSiteLists p = new MasterItemSiteLists
                            {
                                itemSiteCityIdId = ddlCity.Value.ToString().Trim(),
                                itemSiteStateIdId = ddlState.Value.ToString().Trim(),
                                itemSiteCountryIdId = ddlCountry.Value.ToString().Trim(),
                                itemSiteUserIdId = null,
                                itemsiteCode = txtSiteCode_Site.Value.ToString().Trim(),
                                itemsiteDesc = txtSiteDesc_Site.Value.ToString().Trim(),
                                itemsiteType = "",
                                itemPurchasedept = "",
                                itemsiteAddress = txtAddress_Site.Value.ToString().Trim(),
                                itemsitePostcode = txtPostCode_Site.Value.ToString().Trim(),
                                itemsiteCity = ddlCity.Items[ddlCity.SelectedIndex].Text,
                                itemsiteState = ddlState.Items[ddlState.SelectedIndex].Text,
                                itemsiteCountry = ddlCountry.Items[ddlCountry.SelectedIndex].Text,
                                itemsitePhone1 = txtContact1_Site.Value.ToString().Trim(),
                                itemsitePhone2 = txtContact2_Site.Value.ToString().Trim(),
                                itemsiteFax = txtFax_Site.Value.ToString().Trim(),
                                itemsiteEmail = txtEMail_Site.Value.ToString().Trim(),
                                itemsiteUser = "",
                                itemsiteDate = (DateTime.Now.Date),
                                itemsiteTime = (DateTime.Now.Date),
                                itemsiteIsactive = chkSalesActive_Site.Checked,
                                itemsiteRefcode = "",
                                siteGroup = siteCodeandId[0],
                                siteGroupIdId = siteCodeandId[1],
                                siteIsGst = chkGstActive_Site.Checked,
                                accountCode = txtSiteAcCode_Site.Value.ToString().Trim(),
                                ratings = "",
                                picPath = "",
                                qrcode = "",
                                systemlogMdplUpdate = true,
                                sitedbconnectionurl = ""

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<MasterItemSiteLists>("api/ItemSiteLists", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Item Site List Save Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            MasterItemSiteListsUpdate p = new MasterItemSiteListsUpdate
                            {
                                itemsiteId = Int32.Parse(_PKey),
                                itemSiteCityIdId = ddlCity.Value.ToString().Trim(),
                                itemSiteStateIdId = ddlState.Value.ToString().Trim(),
                                itemSiteCountryIdId = ddlCountry.Value.ToString().Trim(),
                                itemSiteUserIdId = null,
                                itemsiteCode = txtSiteCode_Site.Value.ToString().Trim(),
                                itemsiteDesc = txtSiteDesc_Site.Value.ToString().Trim(),
                                itemsiteType = "",
                                itemPurchasedept = "",
                                itemsiteAddress = txtAddress_Site.Value.ToString().Trim(),
                                itemsitePostcode = txtPostCode_Site.Value.ToString().Trim(),
                                itemsiteCity = ddlCity.Items[ddlCity.SelectedIndex].Text,
                                itemsiteState = ddlState.Items[ddlState.SelectedIndex].Text,
                                itemsiteCountry = ddlCountry.Items[ddlCountry.SelectedIndex].Text,
                                itemsitePhone1 = txtContact1_Site.Value.ToString().Trim(),
                                itemsitePhone2 = txtContact2_Site.Value.ToString().Trim(),
                                itemsiteFax = txtFax_Site.Value.ToString().Trim(),
                                itemsiteEmail = txtEMail_Site.Value.ToString().Trim(),
                                itemsiteUser = "",
                                itemsiteDate = (DateTime.Now.Date),
                                itemsiteTime = (DateTime.Now.Date),
                                itemsiteIsactive = chkSalesActive_Site.Checked,
                                itemsiteRefcode = "",
                                siteGroup = siteCodeandId[0],
                                siteGroupIdId = siteCodeandId[1],
                                siteIsGst = chkGstActive_Site.Checked,
                                accountCode = txtSiteAcCode_Site.Value.ToString().Trim(),
                                ratings = "",
                                picPath = "",
                                qrcode = "",
                                systemlogMdplUpdate = true,
                                sitedbconnectionurl = ""

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<MasterItemSiteListsUpdate>("api/ItemSiteLists", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Item Site List Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);

                        }
                    }

                    DataClear();

                }

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
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }


        }

        #endregion

    }
}