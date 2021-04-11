using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class ConfigInterface_PaymentType : System.Web.UI.Page
    {

        private CommonEngine oCommonEngine = new CommonEngine();
        private DataTable oDT_General = new DataTable();
        string _Prefix = string.Empty, _ControlNo = string.Empty, _PKey = string.Empty;
        //private string _PKey = "";

        #region Methods

        //private void Get_ControlPrefixs()
        //{

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        //GET Method  
        //        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"REMARKS\"}}";
        //        var response = client.GetAsync(api).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var a = response.Content.ReadAsStringAsync().Result;
        //            List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
        //            _Prefix = controlNos[0].controlPrefix;
        //            _ControlNo = controlNos[0].controlNo;

        //        }
        //        else
        //        {
        //            Console.WriteLine("Internal server Error");
        //        }
        //    }


        //}

        protected void Get_PaymentType()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Paytables"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Paytables"));
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
            List<PaymentTypeListUpdate> items = new List<PaymentTypeListUpdate>();
            items = JsonConvert.DeserializeObject<List<PaymentTypeListUpdate>>(jsonString);
            for (int i = 0; i < items.Count; i++)
            {
                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 10 %;");
                Col_1.InnerHtml = "<a href='ConfigInterface_PaymentType.aspx?PKey=" + items[i].payCode + "'><font color='#6a6000'><b>" + items[i].payCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col_1);

                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 20 %;");
                Col_2.InnerText = items[i].payDescription;
                _Row.Controls.Add(Col_2);

                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 20 %;");
                Col_3.InnerText = items[i].payGroup;
                _Row.Controls.Add(Col_3);

                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.Attributes.Add("style", "width: 10 %;");
                Col_4.InnerText = items[i].sequence;
                _Row.Controls.Add(Col_4);

                HtmlTableCell Col_5 = new HtmlTableCell();
                Col_5.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].payIsactive == false)
                {
                    Col_5.InnerHtml = "<label> No </label>";
                }
                else
                {

                    Col_5.InnerHtml = "<label> Yes </label>";
                }
                _Row.Controls.Add(Col_5);

                tblPaymentTypeList.Rows.Add(_Row);

            }
        }

        private void LoadValue()
        {

            try
            {
                //Load Pay Group
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/PayGroups"), (typeof(DataTable)));
                DataView oDV = new DataView(oDT_General);
                oDT_General = oDV.ToTable();
                ddlPayGroup.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlPayGroup.Items.Add(new ListItem(oDr["payGroupCode"].ToString().Trim(), oDr["payGroupCode"].ToString().Trim()));
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
                if (txt_PayCode.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Pay Code...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (txt_PayDesc.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Pay Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (ddlPayGroup.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Site Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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

            _PKey = String.Empty;
            btn_AddPaymentType.InnerText = "Add";
            txt_PayCode.Value = string.Empty;
            txt_PayDesc.Value = string.Empty;
            ddlPayGroup.Value = string.Empty;
            txt_AccountCode.Value = string.Empty;
            txt_Sequence.Value = string.Empty;
            txt_CreditCharges.Value = string.Empty;
            txt_OnlinePayCharges.Value = string.Empty;
            chkCreditCardActive.Checked = false;
            chkOnlinePaymentActive.Checked = false;
            chkGstActive.Checked = false;
            chkActive.Checked = false;


        }

        private void FetchRecords()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/Paytables?filter={\"where\":{\"payCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<PaymentTypeListUpdate> PaymentTypeList = JsonConvert.DeserializeObject<List<PaymentTypeListUpdate>>(a);

                    if (PaymentTypeList.Count > 0)
                    {
                        Session["id"] = PaymentTypeList[0].payId;
                        txt_PayCode.Value = PaymentTypeList[0].payCode;
                        txt_PayDesc.Value = PaymentTypeList[0].payDescription;
                        ddlPayGroup.Value = PaymentTypeList[0].payGroup;
                        ddlGtGroup.Value = PaymentTypeList[0].gtGroup;
                        txt_AccountCode.Value = PaymentTypeList[0].accountCode;
                        txt_Sequence.Value = PaymentTypeList[0].sequence;
                        txt_CreditCharges.Value = PaymentTypeList[0].creditcardcharges;
                        txt_OnlinePayCharges.Value = PaymentTypeList[0].onlinepaymentcharges;
                        txt_BankCharges.Value = PaymentTypeList[0].bankCharges;
                        if (PaymentTypeList[0].iscreditcard == true)
                        {
                            chkCreditCardActive.Checked = true;
                        }
                        else
                        {
                            chkCreditCardActive.Checked = false;
                        }

                        if (PaymentTypeList[0].isonlinepayment == true)
                        {
                            chkOnlinePaymentActive.Checked = true;
                        }
                        else
                        {
                            chkOnlinePaymentActive.Checked = false;
                        }

                        if (PaymentTypeList[0].payIsGst == true)
                        {
                            chkGstActive.Checked = true;
                        }
                        else
                        {
                            chkGstActive.Checked = false;
                        }

                        if (PaymentTypeList[0].payIsactive == true)
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get_ControlPrefixs();
                LoadValue();
                if (!IsPostBack)
                {
                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddPaymentType.InnerText = "Update";
                        CollapsiblePanelPaymentType.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                         btn_AddPaymentType.InnerText = "Add";
                        _PKey = string.Empty;
                    }                 
                };
                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }
               Get_PaymentType();
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

                    if (btn_AddPaymentType.InnerText.Trim() == "Add")
                    {

                        if (tblPaymentTypeList.Rows.Count > 0)
                        {
                            //for (int i = 0; i < tblPaymentTypeList.Rows.Count; i++)
                            //{
                            //    if (Convert.ToString(tblPaymentTypeList.Rows[i][]) == txt_PayCode.Value.ToString().Trim())
                            //    {

                            //    }
                            //}

                            //var customers = from customer in tblPaymentTypeList.AsEnumerable()
                            //                where customer.Field<string>("Country") == country
                            //                select new
                            //                {
                            //                    CustomerId = customer.Field<int>("CustomerId"),
                            //                    Name = customer.Field<string>("Name"),
                            //                    Country = customer.Field<string>("Country")
                            //                };
                           
                        }

                        using (var client = new HttpClient())
                        {
                            PaymentTypeList p = new PaymentTypeList
                            {
                                payCode = txt_PayCode.Value.ToString().Trim(),
                                payDescription = txt_PayDesc.Value.ToString().Trim(),
                                sequence = txt_Sequence.Value.ToString().Trim(),
                                payGroup = ddlPayGroup.Value.ToString().Trim(),
                                payIsactive = chkActive.Checked,
                                payIsGst = chkGstActive.Checked,
                                iscreditcard = chkCreditCardActive.Checked,
                                isonlinepayment = chkOnlinePaymentActive.Checked,
                                gtGroup = ddlGtGroup.Value.ToString().Trim(),  //"GT1",
                                rwUsebp = true,
                                iscomm = false,
                                bankCharges = txt_BankCharges.Value.ToString().Trim(),
                                eps = "0",
                                voucherPaymentControl = false,
                                showInReport = false,
                                creditcardcharges = txt_CreditCharges.Value.ToString().Trim(),
                                onlinepaymentcharges = txt_OnlinePayCharges.Value.ToString().Trim(),
                                accountCode = txt_AccountCode.Value.ToString().Trim(),
                                accountMapping = false,
                                openCashdrawer = false,
                                iscustapptpromo = false,
                                isvoucherExtvoucher = false,

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<PaymentTypeList>("api/Paytables", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Payment Type  Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                //  Response.Redirect("ConfigInterface_PaymentType.aspx");
                                Get_PaymentType();
                            }
                            else
                            {
                                //oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something Wrong.. Please Check Payment Type or Descripton for Duplicate!');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);
                                return;
                            }


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            PaymentTypeListUpdate p = new PaymentTypeListUpdate
                            {
                                //payId = Int32.Parse(_PKey),
                                payId = int.Parse(Session["id"].ToString()),
                                payCode = txt_PayCode.Value.ToString().Trim(),
                                payDescription = txt_PayDesc.Value.ToString().Trim(),
                                sequence = txt_Sequence.Value.ToString().Trim(),
                                payGroup = ddlPayGroup.Value.ToString().Trim(),
                                payIsactive = chkActive.Checked,
                                payIsGst = chkGstActive.Checked,
                                iscreditcard = chkCreditCardActive.Checked,
                                isonlinepayment = chkOnlinePaymentActive.Checked,
                                gtGroup = ddlGtGroup.Value.ToString().Trim(), //  "GT1",
                                rwUsebp = true,
                                iscomm = false,
                                bankCharges = txt_BankCharges.Value.ToString().Trim(),
                                eps = "0",
                                voucherPaymentControl = false,
                                showInReport = false,
                                creditcardcharges = txt_CreditCharges.Value.ToString().Trim(),
                                onlinepaymentcharges = txt_OnlinePayCharges.Value.ToString().Trim(),
                                accountCode = txt_AccountCode.Value.ToString().Trim(),
                                accountMapping = false,
                                openCashdrawer = false,
                                iscustapptpromo = false,
                                isvoucherExtvoucher = false,

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<PaymentTypeListUpdate>("api/Paytables", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                oCommonEngine.SetAlert(this.Page, "Payment Type Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);

                                Get_PaymentType();

                            }
                            else
                            {
                                //oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something Wrong.. Please Check Payment Type or Descripton for Duplicate!');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);
                                return;
                            }
                        }
                        //  Response.Redirect("ConfigInterface_PaymentType.aspx");
                    }

                    DataClear();

                }

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }

        }

    }
}