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
    public partial class CustomerClass : System.Web.UI.Page
    {

        private DataTable oDT_Depts = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        public string _PKey = "", _ClassCode = "";
        private string _ControlNo = "";
        
        protected void LoadDepartments()
        {

            try
            {

                //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDepts"));
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDepts"));
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
;

                oDT_Depts = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

                if (oDT_Depts.Rows.Count > 0)
                {

                    for (int i = 0; i < oDT_Depts.Rows.Count; i++)
                    {

                        HtmlTableRow _Row = new HtmlTableRow();
                        HtmlTableCell Col = new HtmlTableCell();
                        Col.InnerText = oDT_Depts.Rows[i]["itmCode"].ToString();
                        _Row.Controls.Add(Col);

                        Col = new HtmlTableCell();
                        Col.InnerText = oDT_Depts.Rows[i]["itmDesc"].ToString();
                        _Row.Controls.Add(Col);

                        Col = new HtmlTableCell();
                        _Row.Controls.Add(Col);
                        _Row.Controls.Add(Col);
                        var _ctrl = new HtmlInputText("Integer");
                        Col.Controls.Add(_ctrl);
                        //Col.InnerHtml = "<input type='text' value='0'>";
                        //Col.Attributes.Add("id", "dis" + i);
                        _Row.Controls.Add(Col);

                        Col = new HtmlTableCell();
                        Col.InnerText = oDT_Depts.Rows[i]["itmId"].ToString();
                        Col.Attributes.Add("style", "width: 0px; display:none");
                        _Row.Controls.Add(Col);

                        //dor discount id
                        Col = new HtmlTableCell();
                        Col.InnerText = "";
                        Col.Attributes.Add("style", "width: 0px; display:none");
                        _Row.Controls.Add(Col);

                        tblDiscount.Rows.Add(_Row);

                        var cell = tblDiscount.Rows[i + 1].Cells[2];
                        var txtDynamic = cell.Controls.OfType<HtmlInputText>().FirstOrDefault();
                        txtDynamic.Value = "0";

                    }

                }
            }

            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }


        }

        private void GetControlNo()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Customer Class Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _ControlNo = controlNos[0].controlNo;
                    txtCode_CustomerClass.Value = controlNos[0].controlPrefix + controlNos[0].controlNo;
                    txtName_CustomerClass.Focus();

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        //[WebMethod]
        //public static void AddDepartmentDiscountsData(List<ItemDeptDiscountUpdate> Details)
        //{

        //    for (int i = 0; i < Details.Count; i++)
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //            //GET Method  
        //            string api = "api/Departmentaldiscounts?filter={\"where\":{\"classid\": " + Details[i].classid + "}}";
        //            var response = client.GetAsync(api).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var a = response.Content.ReadAsStringAsync().Result;
        //                List<ItemDeptDiscount> itemDeptDiscounts = JsonConvert.DeserializeObject<List<ItemDeptDiscount>>(a);

        //                if (itemDeptDiscounts.Count > 0)
        //                {

        //                    //Update Existing Discount
        //                    var post = client.PutAsJsonAsync<ItemDeptDiscountUpdate>("api/Departmentaldiscounts", new ItemDeptDiscountUpdate { classid = Details[i].classid, departmentid = Details[i].departmentid, discount = Details[i].discount, isactive = Details[i].isactive, id = Details[i].id});
        //                    post.Wait();
        //                    response = post.Result;
        //                    System.Net.ServicePointManager.Expect100Continue = false;
        //                    if (response.IsSuccessStatusCode)
        //                    {
        //                        var errorMessage = response.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Success");
        //                    }
        //                    else
        //                    {
        //                        var errorMessage = response.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Error");
        //                    }


        //                }
        //                else
        //                {

        //                    //Save New Discount
        //                    var post = client.PostAsJsonAsync<ItemDeptDiscount>("api/Departmentaldiscounts", new ItemDeptDiscount { classid = Details[i].classid, departmentid = Details[i].departmentid, discount = Details[i].discount, isactive = Details[i].isactive });
        //                    post.Wait();
        //                    response = post.Result;
        //                    System.Net.ServicePointManager.Expect100Continue = false;
        //                    if (response.IsSuccessStatusCode)
        //                    {
        //                        var errorMessage = response.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Success");
        //                    }
        //                    else
        //                    {
        //                        var errorMessage = response.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Error");
        //                    }



        //                }



        //            }
        //            else
        //            {
        //                Console.WriteLine("Internal server Error");
        //            }

        //        }


        //    }


        //}

        [WebMethod]
        public static void AddDepartmentDiscountsData(List<ItemDeptDiscountUpdate> Details)
        {

            for (int i = 0; i < Details.Count; i++)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    string api = "api/Departmentaldiscounts?filter={\"where\":{\"classid\": " + Details[i].classid + ",\"departmentid\": " + Details[i].departmentid + "}}";
                    var response = client.GetAsync(api).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var a = response.Content.ReadAsStringAsync().Result;
                        List<ItemDeptDiscountFetch> itemDeptDiscounts = JsonConvert.DeserializeObject<List<ItemDeptDiscountFetch>>(a);

                        if (itemDeptDiscounts.Count > 0)
                        {

                            //Update Existing Discount
                            var post = client.PutAsJsonAsync<ItemDeptDiscountUpdate>("api/Departmentaldiscounts", new ItemDeptDiscountUpdate { classid = Details[i].classid, departmentid = Details[i].departmentid, discount = Details[i].discount, isactive = Details[i].isactive, id = itemDeptDiscounts[0].id });
                            post.Wait();
                            response = post.Result;
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
                        else
                        {

                            //Save New Discount
                            var post = client.PostAsJsonAsync<ItemDeptDiscount>("api/Departmentaldiscounts", new ItemDeptDiscount { classid = Details[i].classid, departmentid = Details[i].departmentid, discount = Details[i].discount, isactive = Details[i].isactive });
                            post.Wait();
                            response = post.Result;
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
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }

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
                string api = "api/CustomerClasses/" + _PKey;
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    CustomerClasses customerClasses = JsonConvert.DeserializeObject<CustomerClasses>(a);

                    txtName_CustomerClass.Value = customerClasses.classDesc;
                    chkInActive_CustomerClass.Checked = (customerClasses.classIsactive == false);
                  

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
                string api = "api/Departmentaldiscounts?filter={\"where\":{\"classid\":" + _PKey + "}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ItemDeptDiscountUpdate> depts = JsonConvert.DeserializeObject<List<ItemDeptDiscountUpdate>>(a);

                    for (int i = 0; i < depts.Count; i++)
                    {

                        for(int j = 1; j < tblDiscount.Rows.Count; j++)
                        {

                            if (Int32.Parse(tblDiscount.Rows[j].Cells[3].InnerText) == depts[i].departmentid)
                            {
                                // var txtDiscount = (HtmlInputText)tblDiscount.Rows[j].Cells[2].Controls[0];

                                var cell = tblDiscount.Rows[j].Cells[2];
                                var txtDynamic = cell.Controls.OfType<HtmlInputText>().FirstOrDefault();
                                txtDynamic.Value = depts[i].discount.ToString();

                                tblDiscount.Rows[j].Cells[4].InnerText = depts[i].id.ToString();


                                //string tInputBox0 = tblDiscount.Rows[j].Cells[2].Controls[0].ClientID;
                                //var tContent = (HtmlInputText)tblDiscount.Rows[j].Cells[2].FindControl(tInputBox0);
                                //var txtdis = (HtmlInputText)tblDiscount.Rows[j].Cells[2].Controls[0];
                                //string x = txtdis.Value;

                            }


                        }


                    }


                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

        }

        //private async System.Threading.Tasks.Task FetchRecordAsync()
        //{

        //    try
        //    {

        //    //Fetching Customer Class
        //    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerClasses/" + _PKey));
        //    WebReq.Method = "GET";
        //    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

        //    Console.WriteLine(WebResp.StatusCode);
        //    Console.WriteLine(WebResp.Server);

        //    string jsonString;
        //    using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //        jsonString = reader.ReadToEnd();
        //    }

        //    CustomerClasses items = new CustomerClasses();
        //    items = JsonConvert.DeserializeObject<CustomerClasses>(jsonString);

        //    //Fetching Department Discounts for that classes
        //    txtName_CustomerClass.Value = items.classDesc;
        //    chkInActive_CustomerClass.Checked = items.classIsactive;

        //    using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //            //GET Method  
        //            string api = "api/Departmentaldiscounts?filter={\"where\":{\"classid\":" + _PKey + "}}";
        //            HttpResponseMessage response = await client.GetAsync(api);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                List<ItemDeptDiscount> depts = await response.Content.ReadAsAsync<List<ItemDeptDiscount>>();

        //                for (int i = 0; i < depts.Count; i++)
        //                {

        //                    oDT_Depts.Rows[i][2] = depts[i].discount;
        //                    //oDT_Depts.Rows[i][]

        //                    //if (tblDiscount.ID.Equals(depts[i].departmentid))
        //                    //{
        //                    //    string id = "test";
        //                    //}



        //                }


        //            }
        //            else
        //            {
        //                Console.WriteLine("Internal server Error");
        //            }
        //        }

               

        //    //WebReq = (HttpWebRequest)WebRequest.Create(api);
        //    //WebResp = (HttpWebResponse)WebReq.GetResponse();

        //    //using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
        //    //{
        //    //    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //    //    jsonString = reader.ReadToEnd();
        //    //}

        //    txtName_CustomerClass.Focus();

        //    } catch(Exception Ex)
        //    {
        //        oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
        //    }

        //}

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    LoadDepartments();

                    if (Request.QueryString["PKey"] != null)
                    {

                        _PKey = Request.QueryString["PKey"].ToString();
                        FetchRecords();
                    }
                    else
                    {
                        txtName_CustomerClass.Value = string.Empty;
                    }

                }

                if (Request.QueryString["PKey"] != null)
                {

                    _PKey = Request.QueryString["PKey"].ToString();
                    txtClassID.Value = _PKey;
                    _ClassCode = Request.QueryString["ClassCode"].ToString();
                    txtCode_CustomerClass.Value = _ClassCode;
                    txtCode_CustomerClass.Disabled = true;
                    btnOperation.InnerText = "Update";
                }
                else
                {
                    _PKey = "";
                    GetControlNo();
                    btnOperation.InnerText = "Add";
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

            
                if (txtName_CustomerClass.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
                int xClassid = 0;

                if (Validation())
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        //Save
                        if (btnOperation.InnerText.Trim() == "Add")
                        {
                            CustomerClasses p = new CustomerClasses
                            {
                                classCode = txtCode_CustomerClass.Value.ToString().Trim(),
                                classDesc = txtName_CustomerClass.Value.ToString().Trim(),
                                classIsactive = (!chkInActive_CustomerClass.Checked),
                                classProduct = 0,
                                classService = 0

                            };
                            var post = client.PostAsJsonAsync<CustomerClasses>("api/CustomerClasses", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                var a = response.Content.ReadAsStringAsync().Result;
                                CustomerClassUpdate customerClassesUpdates = JsonConvert.DeserializeObject<CustomerClassUpdate>(a);
                                xClassid = customerClassesUpdates.id;

                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Customer Class Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(_ControlNo) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    xSuccess = true;
                                    Response.Redirect("CustomerMaster.aspx");
                                }

                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }
                        else  //Update
                        {

                            CustomerClassUpdate p = new CustomerClassUpdate
                            {
                                classCode = txtCode_CustomerClass.Value.ToString().Trim(),
                                classDesc = txtName_CustomerClass.Value.ToString().Trim(),
                                classIsactive = (!chkInActive_CustomerClass.Checked),
                                classProduct = 0,
                                classService = 0,
                                id = Int32.Parse(_PKey)
                            };
                            xClassid = Int32.Parse(_PKey);
                            var post = client.PutAsJsonAsync<CustomerClassUpdate>("api/CustomerClasses", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                xSuccess = true;

                                //string api = "api/Departmentaldiscounts/10";
                                //post = client.DeleteAsync(api);
                                //post.Wait();
                                //response = post.Result;
                                //if (response.IsSuccessStatusCode)
                                //{
                                //    xSuccess = true;
                                //}

                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }


                        if (xSuccess)
                        {
                            if (btnOperation.InnerText.Trim() == "Add")
                            {
                                oCommonEngine.SetAlert(this.Page, "Customer Class Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                Session["AlertMessage"] = "Customer Class Created Sucessfully...!";
                                txtCode_CustomerClass.Value = Convert.ToString((Int64.Parse(_ControlNo) + 1));
                                txtName_CustomerClass.Value = string.Empty;
                                LoadDepartments();
                            }
                            else
                            {
                                Session["AlertMessage"] = "Customer Class " + " Updated Sucessfully...!";
                                Response.Redirect("CustomerMaster.aspx?PKey=CLASS");
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