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
using System.Web.Script.Serialization;

namespace Sequoia_BE
{
    public partial class Po : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private string ControlNo = "";
        private string _PKey = "";
        private string recStatus = "";
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_Lead = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        private DataTable oDT_atStudent = new DataTable();

        public class itemDivInput
        {
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public bool itmIsactive { get; set; }
            public string itmSeq { get; set; }
        }

        public class itemDivUpdateInput
        {
            public string itmDesc { get; set; }
            public bool itmIsactive { get; set; }
        }

        public class posInput
        {
            public string poNo { get; set; }
            public string itemsiteCode { get; set; }
            public string suppCode { get; set; }
            public string poRef { get; set; }
            public string poUser { get; set; }
            public string poDate { get; set; }
            public string poStatus { get; set; }
            public string poTtqty { get; set; }
            public string poTtfoc { get; set; }
            public string poTtdisc { get; set; }
            public string poTtamt { get; set; }
            public string poAttn { get; set; }
            public string poRemk1 { get; set; }
            public string poRemk2 { get; set; }
            public string poBname { get; set; }
            public string poBaddr1 { get; set; }
            public string poBaddr2 { get; set; }
            public string poBaddr3 { get; set; }
            public string poBpostcode { get; set; }
            public string poBstate { get; set; }
            public string poBcity { get; set; }
            public string poBcountry { get; set; }
            public string poDaddr1 { get; set; }
            public string poDaddr2 { get; set; }
            public string poDaddr3 { get; set; }
            public string poDpostcode { get; set; }
            public string poDstate { get; set; }
            public string poDcity { get; set; }
            public string poDcountry { get; set; }
            public string poCancelqty { get; set; }
            public string poRecstatus { get; set; }
            public string poRecexpect { get; set; }
            public string poRecttl { get; set; }
            public string syncGuid { get; set; }
            public string syncClientindex { get; set; }
            public string syncLstupd { get; set; }
            public string syncClientindexstring { get; set; }
            public string poTime { get; set; }
            public string reqNo { get; set; }
        }


        public class poDtls
        {
            public string itemsiteCode { get; set; }
            public string status { get; set; }
            public string podItemcode { get; set; }
            public string podItemdesc { get; set; }
            public string podItemprice { get; set; }
            public string podQty { get; set; }
            public string poAppqty { get; set; }
            public string podFocqty { get; set; }
            public string podTtlqty { get; set; }
            public string podPrice { get; set; }
            public string podDiscper { get; set; }
            public string podDiscamt { get; set; }
            public string podAmt { get; set; }
            public string podRecqty { get; set; }
            public string podCancelqty { get; set; }
            public string podOutqty { get; set; }
            public string podDate { get; set; }
            public string podTime { get; set; }
            public string syncGuid { get; set; }
            public string syncClientindex { get; set; }
            public string syncLstupd { get; set; }
            public string syncClientindexstring { get; set; }
            public string brandcode { get; set; }
            public string brandname { get; set; }
            public string linenumber { get; set; }
            public string poNo { get; set; }
            public string poststatus { get; set; }
            
                public string poId { get; set; }
            public string RunningNo { get; set; }
        }

        public class Delpodetails
        {
            public string poId { get; set; }
        }

        public class StktrnsInput
        {
            public string trnPost { get; set; }
            public string trnNo { get; set; }
            public string trnDate { get; set; }
            public string postTime { get; set; }
            public string aperiod { get; set; }
            public string itemcode { get; set; }
            public string storeNo { get; set; }
            public string tstoreNo { get; set; }
            public string fstoreNo { get; set; }
            public string trnDocno { get; set; }
            public string trnType { get; set; }
            public string trnDbQty { get; set; }
            public string trnCrQty { get; set; }
            public string trnQty { get; set; }
            public string trnBalqty { get; set; }
            public string trnBalcst { get; set; }
            public string trnAmt { get; set; }
            public string trnCost { get; set; }
            public string trnRef { get; set; }
            public string hqUpdate { get; set; }
            public string lineNo { get; set; }
            public string itemUom { get; set; }
            public string itemBatch { get; set; }
            public string movType { get; set; }
            public string itemBatchCost { get; set; }
            public string stockIn { get; set; }
            public string transPackageLineNo { get; set; }
        }


        public class ControlNos
        {
            
            public string controlPrefix { get; set; }
            public string siteCode { get; set; }
            public string controlNo { get; set; }
        }




        #endregion
        #region Functions
        #region LoadValue
        private void LoadValue()
        {

            try
            {

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSupplies"), (typeof(DataTable)));
                ddl_supplierPo.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_supplierPo.Items.Add(new ListItem(oDr["supplydesc"].ToString().Trim(), oDr["splyCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                ddlStoreCode_Po.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlStoreCode_Po.Items.Add(new ListItem(oDr["itemsiteDesc"].ToString().Trim(), oDr["itemsiteCode"].ToString().Trim()));
                }
                ddlStoreCode_Po.Value= System.Configuration.ConfigurationManager.AppSettings["SiteCode"];

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

        private string GetapiCalling(string apiName)
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = apiName;
                var response = client.GetAsync(api).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        #endregion

        #region Load Page Informations
        /// <summary>
        /// 
        /// </summary>
        private void LoadPageInformations()
        {
        }
        #endregion

        [WebMethod]
        public static void DelpodetailsData(List<Delpodetails> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Delpodetails c = new Delpodetails { poId = Details[0].poId };
                string api = "api/podetails/" + Details[0].poId;
                var post = client.DeleteAsync(api);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }

            }
        }

        [WebMethod]
        public static void AddposData(List<posInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "PO";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> Po = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].poNo = Po[0].controlPrefix + Po[0].siteCode + Po[0].controlNo;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<posInput>>("api/pos", Details);
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

        [WebMethod]
        public static void EditposData(List<posInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<posInput>("api/pos/update?[where][poNo]=" + Details[0].poNo + "", Details[0]);
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


        [WebMethod]
        public static void AddpoDtlsData(List<poDtls> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "PO";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> Po = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].poNo = Po[0].controlPrefix+ Po[0].siteCode + Po[0].controlNo;
                    Details[0].RunningNo =  Po[0].controlNo;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            if (Details.Count > 0)
            {
                //List <StkMovdocDtls> datelist = new List<StkMovdocDtls>();

                foreach (var mc in Details)
                    mc.poNo = Details[0].poNo;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<poDtls>>("api/podetails", Details);
                    post.Wait();
                    var response = post.Result;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string control = Details[0].RunningNo;
                            string controlNo = control;
                            int Newcontrol = int.Parse(controlNo);
                            int NewcontrolNo = Newcontrol + 1;
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "PO", controlnumber = Convert.ToString(NewcontrolNo) };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                        {

                        }
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
        }

        [WebMethod]
        public static void EditpoDtlsData(List<poDtls> Details)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"] + "api/Delpodetail?reqNumber=" + Details[0].poNo + "");
            req.ContentType = "application/json;";
            req.Method = "GET";
            WebResponse response1 = req.GetResponse();
            Stream responseStream = response1.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());


            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].poId != "" && Details[i].poId != null)
                {
                    using (var client = new HttpClient())
                    {
                        poDtls p = new poDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,podItemcode = Details[i].podItemcode,
                            podItemdesc = Details[i].podItemdesc,podItemprice = Details[i].podItemprice,podQty = Details[i].podQty,
                            poAppqty = Details[i].poAppqty,podFocqty = Details[i].podFocqty,podTtlqty = Details[i].podTtlqty,
                            podPrice = Details[i].podPrice,podDiscper = Details[i].podDiscper,podDiscamt = Details[i].podDiscamt,
                            podAmt = Details[i].podAmt,podRecqty = Details[i].podRecqty,podCancelqty = Details[i].podCancelqty,
                            podOutqty = Details[i].podOutqty,podDate = Details[i].podDate,podTime = Details[i].podTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,syncClientindexstring = Details[i].syncClientindexstring,
                            brandcode = Details[i].brandcode,brandname = Details[i].brandname,linenumber = Details[i].linenumber,poNo = Details[i].poNo,
                            poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<poDtls>("api/podetails/update?[where][poId]=" + Details[i].poId + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        poDtls p = new poDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,podItemcode = Details[i].podItemcode,
                            podItemdesc = Details[i].podItemdesc,podItemprice = Details[i].podItemprice,podQty = Details[i].podQty,
                            poAppqty = Details[i].poAppqty,podFocqty = Details[i].podFocqty,podTtlqty = Details[i].podTtlqty,
                            podPrice = Details[i].podPrice,podDiscper = Details[i].podDiscper,podDiscamt = Details[i].podDiscamt,
                            podAmt = Details[i].podAmt,podRecqty = Details[i].podRecqty,podCancelqty = Details[i].podCancelqty,
                            podOutqty = Details[i].podOutqty,podDate = Details[i].podDate,podTime = Details[i].podTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,
                            syncClientindexstring = Details[i].syncClientindexstring,brandcode = Details[i].brandcode,brandname = Details[i].brandname,
                            linenumber = Details[i].linenumber,poNo = Details[i].poNo,poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<poDtls>("api/podetails", p);
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
            }
        }

        //[WebMethod]
        //public static void AddStktrnsData(List<StktrnsInput> Details)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        var post = client.PostAsJsonAsync<List<StktrnsInput>>("api/Stktrns", Details);
        //        post.Wait();
        //        var response = post.Result;
        //        System.Net.ServicePointManager.Expect100Continue = false;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var errorMessage = response.Content.ReadAsStringAsync().Result;
        //            Console.Write("Success");
        //        }
        //        else
        //        {
        //            var errorMessage = response.Content.ReadAsStringAsync().Result;
        //            Console.Write("Error");
        //        }

        //    }
        //}

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
                if (!IsPostBack)
                {
                    LoadValue();
                    LoadPageInformations();
                }

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                    btnSubmit_AddPo.InnerText = "Edit";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string api = "api/pos?filter={\"where\":{\"poNo\":\"" + _PKey + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<posInput> StkMovdocHdrsVal = JsonConvert.DeserializeObject<List<posInput>>(a);
                            txtDocNo_Po.Value = StkMovdocHdrsVal[0].poNo;
                            
                            dt_DocDatePo.Value =Convert.ToDateTime(StkMovdocHdrsVal[0].poDate).ToString("dd/MM/yyyy");
                            txtStatus_Po.Value = StkMovdocHdrsVal[0].poStatus;
                            //if (StkMovdocHdrsVal[0].poStatus == "0")
                            //{
                            //    txtStatus_Po.Value = "Open";
                            //}
                            //else
                            //{
                            //    txtStatus_Po.Value = "Posted";
                            //}
                            ddl_supplierPo.Value = StkMovdocHdrsVal[0].suppCode;
                            ddlStoreCode_Po.Value = StkMovdocHdrsVal[0].itemsiteCode;
                            txtRemark_Po.Value = StkMovdocHdrsVal[0].poRemk1;
                            txt_TotAmntPo.Value = StkMovdocHdrsVal[0].poTtqty;
                            txtTotQty_Po.Value = StkMovdocHdrsVal[0].poTtqty;
                            recStatus = StkMovdocHdrsVal[0].poStatus;
                            if (StkMovdocHdrsVal[0].poStatus == "Open")
                            {
                                btnSubmit_AddPo.Disabled = false;
                                btnSubmit_PostPo.Disabled = false;
                            }
                            else
                            {
                                btnSubmit_AddPo.Disabled = true;
                                btnSubmit_PostPo.Disabled = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                    List<poDtls> StkMovdocDtlsVal = JsonConvert.DeserializeObject<List<poDtls>>(GetapiCalling("api/podetails?filter={\"where\":{\"poNo\":\"" + _PKey + "\"}}"));
                    if (StkMovdocDtlsVal.Count > 0 && PoEntryModule.Rows.Count == 1)
                    {
                        for (int i = 0; i < StkMovdocDtlsVal.Count; i++)
                        {
                            HtmlTableRow _Row = new HtmlTableRow();

                            HtmlTableCell Col_0 = new HtmlTableCell();
                            Col_0.Attributes.Add("style", "width: 0 % ;visibility:hidden;");
                            Col_0.InnerHtml = StkMovdocDtlsVal[i].poId;
                            //Col_15.InnerHtml = "<input type='hidden' class=form-control' value=" + StkMovdocDtlsVal[i].docId + " id='txthiddenId_PoDtl' runat='server'>";
                            _Row.Controls.Add(Col_0);


                            HtmlTableCell Col_2 = new HtmlTableCell();
                            Col_2.Attributes.Add("style", "width: 5 %");
                            Col_2.InnerText = StkMovdocDtlsVal[i].linenumber;
                            _Row.Controls.Add(Col_2);

                            HtmlTableCell Col_3 = new HtmlTableCell();
                            Col_3.Attributes.Add("style", "width: 10 %");
                            Col_3.InnerText = StkMovdocDtlsVal[i].podItemcode;
                            _Row.Controls.Add(Col_3);

                            HtmlTableCell Col_4 = new HtmlTableCell();
                            Col_4.Attributes.Add("style", "width: 20 %");
                            Col_4.InnerText = StkMovdocDtlsVal[i].podItemdesc;
                            _Row.Controls.Add(Col_4);

                            HtmlTableCell Col_5 = new HtmlTableCell();
                            Col_5.Attributes.Add("style", "width: 10 %");
                            Col_5.InnerText = StkMovdocDtlsVal[i].brandname;
                            _Row.Controls.Add(Col_5);

                            HtmlTableCell Col_6 = new HtmlTableCell();
                            Col_6.Attributes.Add("style", "width: 10 %");
                            Col_6.InnerText = StkMovdocDtlsVal[i].podItemprice;
                            _Row.Controls.Add(Col_6);

                            HtmlTableCell Col_7 = new HtmlTableCell();
                            Col_7.Attributes.Add("style", "width: 10 %");
                            Col_7.InnerText = StkMovdocDtlsVal[i].podDiscper;
                            _Row.Controls.Add(Col_7);

                            HtmlTableCell Col_8 = new HtmlTableCell();
                            Col_8.Attributes.Add("style", "width: 10 %");
                            Col_8.InnerText = StkMovdocDtlsVal[i].podDiscamt;
                            _Row.Controls.Add(Col_8);

                            HtmlTableCell Col_9 = new HtmlTableCell();
                            Col_9.Attributes.Add("style", "width: 10 %");
                            Col_9.InnerText = StkMovdocDtlsVal[i].podQty;
                            _Row.Controls.Add(Col_9);

                            if (recStatus == "Open")
                            {
                                HtmlTableCell Col_12 = new HtmlTableCell();
                                Col_12.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_12.InnerHtml = "<div class='tools'><i class='Remove_AddItemToPoAfterSave glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_12);
                            }
                            PoEntryModule.Rows.Add(_Row);
                        }
                    }



                }
                else
                {
                    btnSubmit_AddPo.InnerText = "Add";
                    txtStatus_Po.Value = "Open";
                    _PKey = "";
                    //FetchRecordAsync();
                    dt_DocDatePo.Value = DateTime.Now.ToString("dd/MM/yyyy");
                    //using (var client = new HttpClient())
                    //{
                    //    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    //    client.DefaultRequestHeaders.Accept.Clear();
                    //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //    //GET Method  
                    //    string codeDesc = "PO REQUISITE";
                    //    string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                    //    var response = client.GetAsync(api).Result;
                    //    if (response.IsSuccessStatusCode)
                    //    {
                    //        var a = response.Content.ReadAsStringAsync().Result;
                    //        List<ControlNos> PoReq = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    //        txtDocNo_Po.Value = PoReq[0].controlPrefix + PoReq[0].siteCode + PoReq[0].controlNo;
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Internal server Error");
                    //    }
                    //}
                }
                
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }

        #endregion
    }
}