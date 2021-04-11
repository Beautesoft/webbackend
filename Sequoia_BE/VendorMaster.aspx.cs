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
    public partial class VendorMaster : System.Web.UI.Page
    {

        private CommonEngine oCommonEngine = new CommonEngine();
        private string _PKey = "";
        private string _ControlNo = "";

        private void GetControlNo()
        {

            using (var client = new HttpClient())
            {
                //string baseUrl = "http://103.253.14.203:3000/";                
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Supplier Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> depts = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _ControlNo = depts[0].controlNo;
                    txtCode_VendorMaster.Value = depts[0].controlPrefix + depts[0].controlNo;
                    txtCode_VendorMaster.Disabled = true;
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
                string api = "api/itemSupplies?filter={\"where\":{\"splyCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ItemSupply> itemSupply = JsonConvert.DeserializeObject<List<ItemSupply>>(a);

                    txtCode_VendorMaster.Value = itemSupply[0].splyCode;
                    txtSupplierName_VendorMaster.Value = itemSupply[0].supplydesc;
                    txtDate_VendorMaster.Value = Convert.ToDateTime(itemSupply[0].splyDate.ToString()).ToString("dd/MM/yyyy");
                    txtAccountNo_VendorMaster.Value = itemSupply[0].accountNumber;
                    txtSupplierAtn_VendorMaster.Value = itemSupply[0].splyAttn;
                    txtAddress1_VendorMaster.Value = itemSupply[0].splyAddr1;
                    txtAddress2_VendorMaster.Value = itemSupply[0].splyAddr2;
                    txtAddress3_VendorMaster.Value = itemSupply[0].splyAddr3;
                    txtPostCode_VendorMaster.Value = itemSupply[0].splyPoscd;
                    txtState_VendorMaster.Value = itemSupply[0].splyState;
                    txtCity_VendorMaster.Value = itemSupply[0].splyCity;
                    txtCountry_VendorMaster.Value = itemSupply[0].splyCntry;
                    txtMailAddress1_VendorMaster.Value = itemSupply[0].splymaddr1;
                    txtMailAddress2_VendorMaster.Value = itemSupply[0].splymaddr2;
                    txtMailAddress3_VendorMaster.Value = itemSupply[0].splymaddr3;
                    txtMailPostCode_VendorMaster.Value = itemSupply[0].splymposcd;
                    txtMailState_VendorMaster.Value = itemSupply[0].splymstate;
                    txtMailCity_VendorMaster.Value = itemSupply[0].splymcity;
                    txtMailCountry_VendorMaster.Value = itemSupply[0].splymcntry;
                    txtPhoneNo_VendorMaster.Value = itemSupply[0].splyTelno;
                    txtFaxNo_VendorMaster.Value = itemSupply[0].splyFaxno;
                    txtTerms_VendorMaster.Value = Convert.ToString( itemSupply[0].splyTerm);
                    txtCommission_VendorMaster.Value = Convert.ToString(itemSupply[0].splyComm);
                    if(Convert.ToString(itemSupply[0].splyactive) == "1")
                        chkActive_VendorMaster.Checked = true;
                    else
                        chkActive_VendorMaster.Checked = false;

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


                if (txtCode_VendorMaster.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Supply Code...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }

                if (txtSupplierName_VendorMaster.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Supplier Name...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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

        protected void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                txtMailAddress1_VendorMaster.Value = txtAddress1_VendorMaster.Value;
                txtMailAddress2_VendorMaster.Value = txtAddress2_VendorMaster.Value;
                txtMailAddress3_VendorMaster.Value = txtAddress3_VendorMaster.Value;
                txtMailPostCode_VendorMaster.Value = txtPostCode_VendorMaster.Value;
                txtMailCity_VendorMaster.Value = txtCity_VendorMaster.Value;
                txtMailState_VendorMaster.Value = txtState_VendorMaster.Value;
                txtMailCountry_VendorMaster.Value = txtCountry_VendorMaster.Value;
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

                //LoadHTMLTable();
                bool xSuccess = false;
                if (Validation())
                {

                    byte isActive = 0;
                    if (chkActive_VendorMaster.Checked)
                        isActive = 1;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        //Save
                        if (btnVendorOperation.InnerText.Trim() == "Add")
                        {
                            ItemSupply p = new ItemSupply
                            {
                                splyCode = txtCode_VendorMaster.Value.ToString().Trim(),
                                supplydesc = txtSupplierName_VendorMaster.Value.ToString().Trim(),
                                splyDate = (txtDate_VendorMaster.Value.ToString().Substring(6, 4) + "-" + txtDate_VendorMaster.Value.ToString().Substring(3, 2) + "-" + txtDate_VendorMaster.Value.ToString().Substring(0, 2)),
                                accountNumber = txtAccountNo_VendorMaster.Value.ToString().Trim(),
                                splyAttn = txtSupplierAtn_VendorMaster .Value.ToString().Trim(),
                                splyIc = "",
                                splyType = "",
                                splyAddr1 = txtAddress1_VendorMaster.Value.ToString().Trim(),
                                splyAddr2 = txtAddress2_VendorMaster.Value.ToString().Trim(),
                                splyAddr3 = txtAddress3_VendorMaster.Value.ToString().Trim(),
                                splyPoscd = txtPostCode_VendorMaster.Value.ToString().Trim(),
                                splyState = txtState_VendorMaster.Value.ToString().Trim(),
                                splyCity = txtCity_VendorMaster.Value.ToString().Trim(),
                                splyCntry = txtCountry_VendorMaster.Value.ToString().Trim(),
                                splymaddr1 = txtMailAddress1_VendorMaster.Value.ToString().Trim(),
                                splymaddr2 = txtMailAddress2_VendorMaster.Value.ToString().Trim(),
                                splymaddr3 = txtMailAddress3_VendorMaster.Value.ToString().Trim(),
                                splymposcd = txtMailPostCode_VendorMaster.Value.ToString().Trim(),
                                splymstate = txtMailState_VendorMaster.Value.ToString().Trim(),
                                splymcity = txtMailCity_VendorMaster.Value.ToString().Trim(),
                                splymcntry = txtMailCountry_VendorMaster.Value.ToString().Trim(),
                                splyTelno =  txtPhoneNo_VendorMaster.Value.ToString().Trim(),
                                splyFaxno = txtFaxNo_VendorMaster.Value.ToString().Trim(),
                                splyRemk1="",
                                splyRemk2 = "",
                                splyRemk3="",
                                splyTerm = txtTerms_VendorMaster.Value.ToString().Trim(),
                                splyLimit = "0",
                                splyBal ="0",
                                splyComm = txtCommission_VendorMaster.Value.ToString().Trim(),
                                firstName ="",
                                netseq="0",
                                splyactive = isActive,
                                createUser ="",
                                createDate= (txtDate_VendorMaster.Value.ToString().Substring(6, 4) + "-" + txtDate_VendorMaster.Value.ToString().Substring(3, 2) + "-" + txtDate_VendorMaster.Value.ToString().Substring(0, 2))

                            };

                            var post = client.PostAsJsonAsync<ItemSupply>("api/ItemSupplies", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                Console.Write("Success");
                                //int NewcontrolNo = int.Parse(_ControlNo) + 1;
                                int NewcontrolNo = 0;
                                if (String.IsNullOrEmpty(_ControlNo))
                                {
                                    NewcontrolNo = 0;
                                }
                                else
                                { NewcontrolNo = int.Parse(_ControlNo); }
                                NewcontrolNo = NewcontrolNo + 1;
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Supplier Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString(NewcontrolNo) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    Console.Write("Success");
                                }
                                Response.Redirect("VendorList.aspx");

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }

                        }
                        else  //Update
                        {
                            ItemSupplyUpdate p = new ItemSupplyUpdate
                            {
                                //splyId = Int32.Parse(_PKey),
                                splyCode = txtCode_VendorMaster.Value.ToString().Trim(),
                                supplydesc = txtSupplierName_VendorMaster.Value.ToString().Trim(),
                                splyDate = (txtDate_VendorMaster.Value.ToString().Substring(6, 4) + "-" + txtDate_VendorMaster.Value.ToString().Substring(3, 2) + "-" + txtDate_VendorMaster.Value.ToString().Substring(0, 2)),
                                accountNumber = txtAccountNo_VendorMaster.Value.ToString().Trim(),
                                splyAttn = txtSupplierAtn_VendorMaster.Value.ToString().Trim(),
                                splyIc = "",
                                splyType = "",
                                splyAddr1 = txtAddress1_VendorMaster.Value.ToString().Trim(),
                                splyAddr2 = txtAddress2_VendorMaster.Value.ToString().Trim(),
                                splyAddr3 = txtAddress3_VendorMaster.Value.ToString().Trim(),
                                splyPoscd = txtPostCode_VendorMaster.Value.ToString().Trim(),
                                splyState = txtState_VendorMaster.Value.ToString().Trim(),
                                splyCity = txtCity_VendorMaster.Value.ToString().Trim(),
                                splyCntry = txtCountry_VendorMaster.Value.ToString().Trim(),
                                splymaddr1 = txtMailAddress1_VendorMaster.Value.ToString().Trim(),
                                splymaddr2 = txtMailAddress2_VendorMaster.Value.ToString().Trim(),
                                splymaddr3 = txtMailAddress3_VendorMaster.Value.ToString().Trim(),
                                splymposcd = txtMailPostCode_VendorMaster.Value.ToString().Trim(),
                                splymstate = txtMailState_VendorMaster.Value.ToString().Trim(),
                                splymcity = txtMailCity_VendorMaster.Value.ToString().Trim(),
                                splymcntry = txtMailCountry_VendorMaster.Value.ToString().Trim(),
                                splyTelno = txtPhoneNo_VendorMaster.Value.ToString().Trim(),
                                splyFaxno = txtFaxNo_VendorMaster.Value.ToString().Trim(),
                                splyRemk1 = "",
                                splyRemk2 = "",
                                splyRemk3 = "",
                                splyTerm = Convert.ToInt32(txtTerms_VendorMaster.Value.ToString()),
                                splyLimit = 0,
                                splyBal = 0,
                                splyComm = Convert.ToInt32(txtCommission_VendorMaster.Value),
                                firstName = "",
                                netseq = "",
                                splyactive = isActive,
                                createUser = "",
                                createDate = (txtDate_VendorMaster.Value.ToString().Substring(6, 4) + "-" + txtDate_VendorMaster.Value.ToString().Substring(3, 2) + "-" + txtDate_VendorMaster.Value.ToString().Substring(0, 2)),
                            };

                            //var post = client.PutAsJsonAsync<ItemSupplyUpdate>("api/ItemSupplies", p);
                            var post = client.PostAsJsonAsync<ItemSupplyUpdate>("api/ItemSupplies/update?[where][splyCode]=" + txtCode_VendorMaster.Value.ToString() + "", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                xSuccess = true;

                            }
                            else
                            {
                                var errorMessage = response.Content.ReadAsStringAsync().Result;
                                Console.Write("Error");
                            }
                        }

                        if (xSuccess)
                        {
                            if (btnVendorOperation.InnerText.Trim() == "Add")
                            {
                                oCommonEngine.SetAlert(this.Page, "Item Vendor Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                Session["AlertMessage"] = "Customer Class Created Sucessfully...!";
                                Response.Redirect("VendorList.aspx");
                            }
                            else
                            {
                                Session["AlertMessage"] = "Item Vendor " + " Updated Sucessfully...!";
                                Response.Redirect("VendorList.aspx");
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
                        txtCode_VendorMaster.Disabled = true;
                        FetchRecords();
                        btnVendorOperation.InnerText = "Update";
                    }
                    else
                    {
                        _PKey = "";
                        btnVendorOperation.InnerText = "Add";
                        txtDate_VendorMaster.Value = DateTime.Now.ToString("dd/MM/yyyy");
                    }

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
    }
}