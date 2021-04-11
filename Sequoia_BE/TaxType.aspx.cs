using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class TaxType : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string Gst_Prefix = string.Empty, Gst_ControlNo = string.Empty;
        string Tax1_Prefix = string.Empty, Tax1_ControlNo = string.Empty, Tax1_PKey = string.Empty;
        string Tax2_Prefix = string.Empty, Tax2_ControlNo = string.Empty, Tax2_PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"1st Tax Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Tax1_Prefix = controlNos[0].controlPrefix;
                    Tax1_ControlNo = controlNos[0].controlNo;
                    txt_itemCode.Value = Tax1_Prefix + Tax1_ControlNo;
                    Session["ControlNo_Tax1"] = Tax1_ControlNo;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"2nd Tax Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Tax2_Prefix = controlNos[0].controlPrefix;
                    Tax2_ControlNo = controlNos[0].controlNo;
                    txt_itemCode2.Value = Tax2_Prefix + Tax2_ControlNo;
                    Session["ControlNo_Tax2"] = Tax2_ControlNo;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"GST Tax Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Gst_Prefix = controlNos[0].controlPrefix;
                    Gst_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        protected void Get_GstTaxSettings()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/GstSettings"));
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

            // DataTable dt = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;

            List<GstSettingUpdate> items = new List<GstSettingUpdate>();
            items = JsonConvert.DeserializeObject<List<GstSettingUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 20 %;");
                Col_1.InnerText = items[i].itemCode;
                _Row.Controls.Add(Col_1);

                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 30 %;");
                Col_2.InnerText = items[i].itemDesc;
                _Row.Controls.Add(Col_2);

                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 15 %;");
                Col_2.InnerText = items[i].itemValue.ToString();
                _Row.Controls.Add(Col_2);

                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 15 %;");
                Col_2.InnerText = items[i].itemSeq.ToString();
                _Row.Controls.Add(Col_2);

                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_GstTaxSetting'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_GstTaxSetting editor - active'>";
                }
                _Row.Controls.Add(Col_3);

                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_GstTaxSetting glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);

                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Gst_Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Gst_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                tblGstTaxSetting.Rows.Add(_Row);

            }
        }

        protected void Get_1stTaxType()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/TaxType1TaxCodes"));
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

            List<TaxTypeMaster> items = new List<TaxTypeMaster>();
            items = JsonConvert.DeserializeObject<List<TaxTypeMaster>>(jsonString);

            for (int i = 1; i < tbl_TaxTypeList.Rows.Count; i++)
            {
                tbl_TaxTypeList.Rows.RemoveAt(i);
            }

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerHtml = "<a href='TaxType.aspx?PKey1=" + items[i].itemCode + "'><font color='#6a6000'><b>" + items[i].itemCode.ToString() + "</b></font></a>";                
                _Row.Controls.Add(Col);

                 Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].taxCode;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = items[i].taxDesc;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = items[i].taxRatePercent;
                _Row.Controls.Add(Col);


                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive)
                {
                    Col.InnerHtml = "Yes";  // "<input type='checkbox' checked class='chk_ActiveTaxType editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "No";  // "<input type='checkbox' class='chk_ActiveTaxType editor - active'>";
                }
                _Row.Controls.Add(Col);

                tbl_TaxTypeList.Rows.Add(_Row);

            }
        }

        protected void Get_2ndTaxType()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/TaxType2TaxCodes"));
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

            List<TaxTypeMaster> items = new List<TaxTypeMaster>();
            items = JsonConvert.DeserializeObject<List<TaxTypeMaster>>(jsonString);

            for (int i = 1; i < tbl_TaxTypeList2.Rows.Count; i++)
            {
                tbl_TaxTypeList2.Rows.RemoveAt(i);
            }

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerHtml = "<a href='TaxType.aspx?PKey2=" + items[i].itemCode + "'><font color='#6a6000'><b>" + items[i].itemCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].taxCode;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = items[i].taxDesc;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = items[i].taxRatePercent;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive)
                {
                    Col.InnerText = "Yes";  // "<input type='checkbox' checked class='chk_ActiveTaxType editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "No";  // "<input type='checkbox' class='chk_ActiveTaxType editor - active'>";
                }
                _Row.Controls.Add(Col);

                tbl_TaxTypeList2.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txt_TaxCode.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txt_TaxDesc.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Tax Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }


                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                return _RetVal;
            }
        }

        private bool Validation2()
        {
            bool _RetVal = false;
            try
            {
                if (txt_TaxCode2.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txt_TaxDesc2.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Tax Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }


                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                return _RetVal;
            }
        }

        private void DataClear()
        {
            btn_AddTaxType.InnerText = "Add";
            txt_itemCode.Value = string.Empty;
            txt_TaxCode.Value = string.Empty;
            txt_TaxDesc.Value = string.Empty;
            txt_TaxPercent.Value = string.Empty;
            chk_ActiveTaxType.Checked = true;
            for (int i = 1; i <= tbl_TaxTypeList.Rows.Count - 1; i++)
            {
                tbl_TaxTypeList.Rows.RemoveAt(i);
            }
        }

        private void DataClear2()
        {
            btn_AddTaxType2.InnerText = "Add";
            txt_itemCode2.Value = string.Empty;
            txt_TaxCode2.Value = string.Empty;
            txt_TaxDesc2.Value = string.Empty;
            txt_TaxPercent2.Value = string.Empty;
            chk_ActiveTaxType2.Checked = true;
            for (int i = 1; i <= tbl_TaxTypeList2.Rows.Count - 1; i++)
            {
                tbl_TaxTypeList2.Rows.RemoveAt(i);
            }
        }

        private void FetchTax1Records()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/TaxType1TaxCodes?filter={\"where\":{\"itemCode\":\"" + Tax1_PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<TaxTypeMasterUpdate> TaxTypeMasters = JsonConvert.DeserializeObject<List<TaxTypeMasterUpdate>>(a);

                    if (TaxTypeMasters.Count > 0)
                    {
                        Session["id"] = TaxTypeMasters[0].id;
                        txt_TaxCode.Value = TaxTypeMasters[0].taxCode;
                        txt_TaxDesc.Value = TaxTypeMasters[0].taxDesc;
                        txt_TaxPercent.Value = TaxTypeMasters[0].taxRatePercent;
                        txt_itemCode.Value = TaxTypeMasters[0].itemCode;
                        chk_ActiveTaxType.Checked = TaxTypeMasters[0].isactive;
                    }

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

        }

        private void FetchTax2Records()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/TaxType2TaxCodes?filter={\"where\":{\"itemCode\":\"" + Tax2_PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<TaxTypeMasterUpdate> TaxTypeMasters = JsonConvert.DeserializeObject<List<TaxTypeMasterUpdate>>(a);

                    if (TaxTypeMasters.Count > 0)
                    {
                        Session["id"] = TaxTypeMasters[0].id;
                        txt_TaxCode2.Value = TaxTypeMasters[0].taxCode;
                        txt_TaxDesc2.Value = TaxTypeMasters[0].taxDesc;
                        txt_TaxPercent2.Value = TaxTypeMasters[0].taxRatePercent;
                        txt_itemCode2.Value = TaxTypeMasters[0].itemCode;
                        chk_ActiveTaxType2.Checked = TaxTypeMasters[0].isactive;
                    }

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
                    DataClear();
                    DataClear2();
                    Get_ControlPrefixs();


                    if (Request.QueryString["PKey1"] != null)
                    {
                        Tax1_PKey = Request.QueryString["PKey1"].ToString();
                        btn_AddTaxType.InnerText = "Update";
                        CollapsiblePanelTaxTypeCreation.Collapsed = false;
                        FetchTax1Records();
                    }
                    else
                    {
                        btn_AddTaxType.InnerText = "Add";
                        Tax1_PKey = string.Empty;

                    }
                    Get_1stTaxType();


                    if (Request.QueryString["PKey2"] != null)
                    {
                        Tax2_PKey = Request.QueryString["PKey2"].ToString();
                        btn_AddTaxType2.InnerText = "Update";
                        CollapsiblePanelTaxType2Creation.Collapsed = false;
                        FetchTax2Records();
                    }
                    else
                    {
                        btn_AddTaxType2.InnerText = "Add";
                        Tax2_PKey = string.Empty;

                    }
                    Get_2ndTaxType();

                };

                if (Request.QueryString["PKey1"] != null)
                {
                    Tax1_PKey = Request.QueryString["PKey1"].ToString();
                }

                if (Request.QueryString["PKey2"] != null)
                {
                    Tax2_PKey = Request.QueryString["PKey2"].ToString();
                }

                Get_GstTaxSettings();



            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }


        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {

                    if (btn_AddTaxType.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            TaxTypeMaster p = new TaxTypeMaster
                            {

                                itemCode = txt_itemCode.Value.ToString().Trim(),
                                taxCode = txt_TaxCode.Value.ToString().Trim(),
                                taxDesc = txt_TaxDesc.Value.ToString().Trim(),
                                taxRatePercent = txt_TaxPercent.Value.ToString().Trim(),
                                isactive = chk_ActiveTaxType.Checked,
                                //  siteCode = txt_SiteCode.Value.ToString().Trim(),
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<TaxTypeMaster>("api/TaxType1TaxCodes", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "1st Tax Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(Session["ControlNo_Tax1"].ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    oCommonEngine.SetAlert(this.Page, "Tax Type Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                }

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            TaxTypeMasterUpdate p = new TaxTypeMasterUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                itemCode = txt_itemCode.Value.ToString().Trim(),
                                taxCode = txt_TaxCode.Value.ToString().Trim(),
                                taxDesc = txt_TaxDesc.Value.ToString().Trim(),
                                taxRatePercent = txt_TaxPercent.Value.ToString().Trim(),
                                isactive = chk_ActiveTaxType.Checked,
                                //  siteCode = txt_SiteCode.Value.ToString().Trim(),
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<TaxTypeMasterUpdate>("api/TaxType1TaxCodes", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Tax Type Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }
                    }

                    DataClear();
                    Get_1stTaxType();
                    Get_2ndTaxType();
                    Get_ControlPrefixs();

                }


            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }

        }

        protected void Operation_Click2(object sender, EventArgs e)
        {
            try
            {
                if (Validation2())
                {

                    if (btn_AddTaxType2.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            TaxTypeMaster p = new TaxTypeMaster
                            {

                                itemCode = txt_itemCode2.Value.ToString().Trim(),
                                taxCode = txt_TaxCode2.Value.ToString().Trim(),
                                taxDesc = txt_TaxDesc2.Value.ToString().Trim(),
                                taxRatePercent = txt_TaxPercent2.Value.ToString().Trim(),
                                isactive = chk_ActiveTaxType2.Checked
                                //  siteCode = txt_SiteCode.Value.ToString().Trim(),
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<TaxTypeMaster>("api/TaxType2TaxCodes", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "2nd Tax Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(Session["ControlNo_Tax2"].ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    oCommonEngine.SetAlert(this.Page, "2nd Tax Code Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                }

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            TaxTypeMasterUpdate p = new TaxTypeMasterUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                itemCode = txt_itemCode2.Value.ToString().Trim(),
                                taxCode = txt_TaxCode2.Value.ToString().Trim(),
                                taxDesc = txt_TaxDesc2.Value.ToString().Trim(),
                                taxRatePercent = txt_TaxPercent2.Value.ToString().Trim(),
                                isactive = chk_ActiveTaxType2.Checked
                                //  siteCode = txt_SiteCode.Value.ToString().Trim(),
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<TaxTypeMasterUpdate>("api/TaxType2TaxCodes", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "2nd Tax Code Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }
                    }

                    DataClear2();
                    Get_ControlPrefixs();
                    Get_1stTaxType();
                    Get_2ndTaxType();

                }


            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }



        }

        #endregion

    }
}