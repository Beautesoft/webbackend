using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;
using System.Net;
using System.IO;

namespace Sequoia_BE
{
    public partial class CorporateCustomer : System.Web.UI.Page
    {

        private DataTable oDT_Depts = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        private string _PKey = "", _ClassCode = "";
        private string _ControlNo = "";
        
        private void GetControlNo()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Corporate Cust Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _ControlNo = controlNos[0].controlNo;
                    txtCode_CorporateCustomer.Value = controlNos[0].controlPrefix + controlNos[0].controlNo;
                    txtName_CorporateCustomer.Focus();

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/CorporateCustomers/" + _PKey;
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    CorporateCustomers corporateCustomers = JsonConvert.DeserializeObject<CorporateCustomers>(a);

                    txtCode_CorporateCustomer.Value = corporateCustomers.code;
                    txtName_CorporateCustomer.Value = corporateCustomers.name;
                    txtAddress1_CorporateCustomer.Value = corporateCustomers.add1;
                    txtAddress2_CorporateCustomer.Value = corporateCustomers.add2;
                    txtAddress3_CorporateCustomer.Value = corporateCustomers.add3;
                    txtAddress4_CorporateCustomer.Value = corporateCustomers.add4;
                    txtAddress5_CorporateCustomer.Value = corporateCustomers.add5;
                    chkInActive_CorporateCustomer.Checked = (corporateCustomers.isactive);

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            { 

                if (!IsPostBack)
                {
                    GetControlNo();

                    if (Request.QueryString["PKey"] != null)
                    {

                        _PKey = Request.QueryString["PKey"].ToString();
                        _ClassCode = Request.QueryString["Code"].ToString();
                        txtCode_CorporateCustomer.Value = _ClassCode;
                        txtCode_CorporateCustomer.Disabled = true;
                        FetchRecords();
                        btnCorporateOperation.InnerText = "Update";
                    }
                    else
                    {
                        _PKey = "";
                        btnCorporateOperation.InnerText = "Add";

                    }

                }

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }




            }
            catch(Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }



        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {

            
                if (txtName_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                if (txtAddress1_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter address1...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }


                if (txtAddress2_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter address2...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                if (txtAddress3_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter address3...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                if (txtAddress4_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter address4...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                if (txtAddress5_CorporateCustomer.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter address5...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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

        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {

                //LoadHTMLTable();
                bool xSuccess = false;
                if (Validation())
                {


                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        //Save
                        if (btnCorporateOperation.InnerText.Trim() == "Add")
                        {
                            CorporateCustomers p = new CorporateCustomers
                            {
                                code = txtCode_CorporateCustomer.Value.ToString().Trim(),
                                name = txtName_CorporateCustomer.Value.ToString().Trim(),
                                add1 = txtAddress1_CorporateCustomer.Value.ToString().Trim(),
                                add2 = txtAddress2_CorporateCustomer.Value.ToString().Trim(),
                                add3 = txtAddress3_CorporateCustomer.Value.ToString().Trim(),
                                add4 = txtAddress4_CorporateCustomer.Value.ToString().Trim(),
                                add5 = txtAddress5_CorporateCustomer.Value.ToString().Trim(),
                                isactive = (chkInActive_CorporateCustomer.Checked),
                            };

                            var post = client.PostAsJsonAsync<CorporateCustomers>("api/CorporateCustomers", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                ControlNosUpdate c = new ControlNosUpdate {controldescription = "Corporate Cust Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(_ControlNo) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    xSuccess = true;
                                    txtCode_CorporateCustomer.Value = Convert.ToString((Int64.Parse(_ControlNo) + 1));
                                }

                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }
                        else  //Update
                        {
                            CorporateCustomersUpdate p = new CorporateCustomersUpdate
                            {
                                id = Int32.Parse(_PKey),
                                code = txtCode_CorporateCustomer.Value.ToString().Trim(),
                                name = txtName_CorporateCustomer.Value.ToString().Trim(),
                                add1 = txtAddress1_CorporateCustomer.Value.ToString().Trim(),
                                add2 = txtAddress2_CorporateCustomer.Value.ToString().Trim(),
                                add3 = txtAddress3_CorporateCustomer.Value.ToString().Trim(),
                                add4 = txtAddress4_CorporateCustomer.Value.ToString().Trim(),
                                add5 = txtAddress5_CorporateCustomer.Value.ToString().Trim(),
                                isactive = (chkInActive_CorporateCustomer.Checked),
                            };

                            var post = client.PutAsJsonAsync<CorporateCustomersUpdate>("api/CorporateCustomers", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                xSuccess = true;

                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                        if (xSuccess)
                        {
                            if (btnCorporateOperation.InnerText.Trim() == "Add")
                            {
                                oCommonEngine.SetAlert(this.Page, "Customer Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                Session["AlertMessage"] = "Customer Class Created Sucessfully...!";
                                Response.Redirect("CustomerMaster2.aspx?PKey=CUSTOMER");
                            }
                            else
                            {
                                Session["AlertMessage"] = "Customer " + " Updated Sucessfully...!";
                                Response.Redirect("CustomerMaster2.aspx?PKey=CUSTOMER");
                            }
                         }
                       
                       
                    }
    
                }

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }
        }

      

    }
}