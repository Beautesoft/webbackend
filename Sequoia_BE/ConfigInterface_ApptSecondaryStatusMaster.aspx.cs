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
    public partial class ConfigInterface_ApptSecondaryStatusMaster : System.Web.UI.Page
    {

        private string _PKey = "";
        private CommonEngine oCommonEngine = new CommonEngine();

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"APPOINTMENT SECONDARY STATUS\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    //_Prefix = controlNos[0].controlPrefix;
                    //_ControlNo = controlNos[0].controlNo;
                    txtCode_ApptBookingStatus.Value = controlNos[0].controlPrefix + controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {

                if (txtDesc_ApptBookingStatus.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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

            btnSubmit_AddApptSecondaryMaster.InnerText = "Add";
            txtDesc_ApptBookingStatus.Value = string.Empty;
            txtColor.Text = string.Empty;
            chk_ApptBookingStatus.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/ApptSecondaryStatuses?filter={\"where\":{\"ssCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ApptSecondaryStatusUpdate> roomsLists = JsonConvert.DeserializeObject<List<ApptSecondaryStatusUpdate>>(a);

                    if (roomsLists.Count > 0)
                    {

                        txtCode_ApptBookingStatus.Value = roomsLists[0].ssCode;
                        txtDesc_ApptBookingStatus.Value = roomsLists[0].ssDesc;
                        txtColor.Text = roomsLists[0].ssColorCode;

                        chk_ApptBookingStatus.Checked = roomsLists[0].active;
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
                        btnSubmit_AddApptSecondaryMaster.InnerText = "Update";
                        FetchRecords();
                    }
                    else
                    {
                        btnSubmit_AddApptSecondaryMaster.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

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

        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {

                    if (btnSubmit_AddApptSecondaryMaster.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            ApptSecondaryStatus p = new ApptSecondaryStatus
                            {

                                ssCode = txtCode_ApptBookingStatus.Value.ToString().Trim(),
                                ssDesc = txtDesc_ApptBookingStatus.Value.ToString().Trim(),
                                ssColorCode = txtColor.Text.ToString().Trim(),
                                active = chk_ApptBookingStatus.Checked

                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<ApptSecondaryStatus>("api/ApptSecondaryStatuses", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                var a = response.Content.ReadAsStringAsync().Result;
                                CustomerClassUpdate customerClassesUpdates = JsonConvert.DeserializeObject<CustomerClassUpdate>(a);
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "APPOINTMENT SECONDARY STATUS", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(txtCode_ApptBookingStatus.Value.ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txtCode_ApptBookingStatus.Value = Convert.ToString((Int64.Parse(txtCode_ApptBookingStatus.Value.ToString()) + 1));
                                }
                                oCommonEngine.SetAlert(this.Page, "Appointment Secondary Status Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            ApptSecondaryStatusUpdate p = new ApptSecondaryStatusUpdate
                            {
                                ssCode = txtCode_ApptBookingStatus.Value.ToString().Trim(),
                                ssDesc = txtDesc_ApptBookingStatus.Value.ToString().Trim(),
                                ssColorCode = txtColor.Text.ToString().Trim(),
                                active = chk_ApptBookingStatus.Checked
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<ApptSecondaryStatusUpdate>("api/ApptSecondaryStatuses/update?[where][ssCode]=" + txtCode_ApptBookingStatus.Value.ToString() + "", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Appointment Secondary Status Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                Response.Redirect("ConfigInterface_ApptSecondaryStatus.aspx");
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }
                    }

                    DataClear();

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
