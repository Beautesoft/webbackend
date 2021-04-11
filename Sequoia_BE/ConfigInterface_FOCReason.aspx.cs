using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;


namespace Sequoia_BE
{
    public partial class ConfigInterface_FOCReason : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();
        private string _Prefix = string.Empty;
        private string _ControlNo = string.Empty;
        private string _PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"FOC Reason Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    _ControlNo = controlNos[0].controlNo;
                    txtPrefix.Text = controlNos[0].controlPrefix;
                    txtControlNo.Text = controlNos[0].controlNo;

                    txtCode_FOCReason.Value = _Prefix + _ControlNo;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        protected void Get_FOCReasons()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/FocReasons"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/FocReasons"));
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

            List<FocReasonUpdate> items = new List<FocReasonUpdate>();
            items = JsonConvert.DeserializeObject<List<FocReasonUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 20 %;");
                // Col_1.InnerText = items[i].focReasonCode;
                Col_1.InnerHtml = "<a href='ConfigInterface_FOCReason.aspx?PKey=" + items[i].focReasonCode + "'><font color='#6a6000'><b>" + items[i].focReasonCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 30 %;");
                Col_2.InnerText = items[i].focReasonLdesc;
                _Row.Controls.Add(Col_2);
                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 30 %;");
                Col_2.InnerText = items[i].focReasonSdesc;
                _Row.Controls.Add(Col_2);

                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].focReasonIsactive == false)
                {
                    Col_2.InnerHtml = "<label> No </label>";
                }
                else
                {

                    Col_2.InnerHtml = "<label> Yes </label>";
                }
                _Row.Controls.Add(Col_2);

                //HtmlTableCell Col_3 = new HtmlTableCell();
                //Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                //if (items[i].focReasonIsactive)
                //{
                //    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_FocReason editor - active'>";
                //}
                //else
                //{
                //    Col_3.InnerHtml = "<input type='checkbox' class='chk_FocReason editor - active'>";
                //}
                //_Row.Controls.Add(Col_3);

                tblFOCReasonList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
               
                if (txtDesc_FOCReason.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Description ...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
            btn_AddFOCReason.InnerText = "Add";
            txtDesc_FOCReason.Value = string.Empty;
            txtShortDesc_FOCReason.Value = string.Empty;
            chkStatusActive_FOCReason.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/FocReasons?filter={\"where\":{\"focReasonCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<FocReasonUpdate> FocReasons = JsonConvert.DeserializeObject<List<FocReasonUpdate>>(a);

                    if (FocReasons.Count > 0)
                    {
                        Session["id"] = FocReasons[0].id;
                        txtCode_FOCReason.Value = FocReasons[0].focReasonCode;
                        txtDesc_FOCReason.Value = FocReasons[0].focReasonLdesc;
                        txtShortDesc_FOCReason.Value = FocReasons[0].focReasonSdesc.ToString();
                        chkStatusActive_FOCReason.Checked = FocReasons[0].focReasonIsactive;
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
                    Get_ControlPrefixs();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddFOCReason.InnerText = "Update";
                        CollapsiblePanelFOCReasonCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddFOCReason.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                Get_FOCReasons();

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

                    if (btn_AddFOCReason.InnerText.Trim() == "Add")
                    {
                        
                        using (var client = new HttpClient())
                        {
                            FocReason p = new FocReason
                            {

                                focReasonCode = txtCode_FOCReason.Value.ToString().Trim(),
                                focReasonLdesc = txtDesc_FOCReason.Value.ToString().Trim(),
                                focReasonSdesc = txtShortDesc_FOCReason.Value.ToString().Trim(),
                                focReasonIsactive = chkStatusActive_FOCReason.Checked,
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<FocReason>("api/FocReasons", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                //Console.Write("Success");
                                int NewcontrolNo = int.Parse(txtControlNo.Text) + 1;
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "FOC Reason Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString(NewcontrolNo) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txtCode_FOCReason.Value = txtPrefix.Text + NewcontrolNo;
                                    oCommonEngine.SetAlert(this.Page, "FOC Reasons Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
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
                            FocReasonUpdate p = new FocReasonUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                focReasonCode = txtCode_FOCReason.Value.ToString().Trim(),
                                focReasonLdesc = txtDesc_FOCReason.Value.ToString().Trim(),
                                focReasonSdesc = txtShortDesc_FOCReason.Value.ToString().Trim(),
                                focReasonIsactive = chkStatusActive_FOCReason.Checked,
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<FocReasonUpdate>("api/FocReasons", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                oCommonEngine.SetAlert(this.Page, "FOC Reasons Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);

                             //   Get_FOCReasons();

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }

                        }

                        Get_ControlPrefixs();
                    }

                    DataClear();
                    Get_FOCReasons();

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