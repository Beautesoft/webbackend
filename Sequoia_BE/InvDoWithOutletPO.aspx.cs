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
    public partial class InvDoWithOutletPO : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private string ControlNo = "";
        private string _PKey = "";
        private string _PKey1 = "";
        private string _PKey2 = "";
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

        public class reqsInput
        {
            public string reqNo { get; set; }
            public string itemsiteCode { get; set; }
            public string suppCode { get; set; }
            public string reqRef { get; set; }
            public string reqUser { get; set; }
            public string reqDate { get; set; }
            public string reqStatus { get; set; }
            public string reqTtqty { get; set; }
            public string reqTtfoc { get; set; }
            public string reqTtdisc { get; set; }
            public string reqTtamt { get; set; }
            public string reqAttn { get; set; }
            public string reqRemk1 { get; set; }
            public string reqRemk2 { get; set; }
            public string reqBname { get; set; }
            public string reqBaddr1 { get; set; }
            public string reqBaddr2 { get; set; }
            public string reqBaddr3 { get; set; }
            public string reqBpostcode { get; set; }
            public string reqBstate { get; set; }
            public string reqBcity { get; set; }
            public string reqBcountry { get; set; }
            public string reqDaddr1 { get; set; }
            public string reqDaddr2 { get; set; }
            public string reqDaddr3 { get; set; }
            public string reqDpostcode { get; set; }
            public string reqDstate { get; set; }
            public string reqDcity { get; set; }
            public string reqDcountry { get; set; }
            public string reqCancelqty { get; set; }
            public string reqRecstatus { get; set; }
            public string supplierName { get; set; }
            public string reqRecexpect { get; set; }
            public string reqRecttl { get; set; }
            public string reqTime { get; set; }
        }


        public class reqDtls
        {
            public string itemsiteCode { get; set; }
            public string status { get; set; }
            public string reqdItemcode { get; set; }
            public string reqdItemdesc { get; set; }
            public string reqdItemprice { get; set; }
            public string reqdQty { get; set; }
            public string reqAppqty { get; set; }
            public string reqdFocqty { get; set; }
            public string reqdTtlqty { get; set; }
            public string reqdPrice { get; set; }
            public string reqdDiscper { get; set; }
            public string reqdDiscamt { get; set; }
            public string reqdAmt { get; set; }
            public string reqdRecqty { get; set; }
            public string reqdCancelqty { get; set; }
            public string reqdOutqty { get; set; }
            public string reqdDate { get; set; }
            public string reqdTime { get; set; }
            public string syncGuid { get; set; }
            public string syncClientindex { get; set; }
            public string syncLstupd { get; set; }
            public string syncClientindexstring { get; set; }
            public string brandcode { get; set; }
            public string brandname { get; set; }
            public string linenumber { get; set; }
            public string reqNo { get; set; }
            public string poststatus { get; set; }
            
                public string reqId { get; set; }
            public string RunningNo { get; set; }
        }

        public class dosInput
        {
            public string doNo { get; set; }
            public string itemsiteCode { get; set; }
            public string suppCode { get; set; }
            public string doRef { get; set; }
            public string doUser { get; set; }
            public string doDate { get; set; }
            public string doStatus { get; set; }
            public string doTtqty { get; set; }
            public string doTtfoc { get; set; }
            public string doTtdisc { get; set; }
            public string doTtamt { get; set; }
            public string doAttn { get; set; }
            public string doRemk1 { get; set; }
            public string doRemk2 { get; set; }
            public string doBname { get; set; }
            public string doBaddr1 { get; set; }
            public string doBaddr2 { get; set; }
            public string doBaddr3 { get; set; }
            public string doBdostcode { get; set; }
            public string doBstate { get; set; }
            public string doBcity { get; set; }
            public string doBcountry { get; set; }
            public string doDaddr1 { get; set; }
            public string doDaddr2 { get; set; }
            public string doDaddr3 { get; set; }
            public string doDdostcode { get; set; }
            public string doDstate { get; set; }
            public string doDcity { get; set; }
            public string doDcountry { get; set; }
            public string doCancelqty { get; set; }
            public string doRecstatus { get; set; }
            public string doRecexpect { get; set; }
            public string doRecttl { get; set; }
            public string syncGuid { get; set; }
            public string syncClientindex { get; set; }
            public string syncLstupd { get; set; }
            public string syncClientindexstring { get; set; }
            public string doTime { get; set; }
            public string poNo { get; set; }

        }

        public class doDtls
        {
            public string itemsiteCode { get; set; }
            public string status { get; set; }
            public string dodItemcode { get; set; }
            public string dodItemdesc { get; set; }
            public string dodItemprice { get; set; }
            public string dodQty { get; set; }
            public string dodFocqty { get; set; }
            public string dodTtlqty { get; set; }
            public string dodPrice { get; set; }
            public string dodDiscper { get; set; }
            public string dodDiscamt { get; set; }
            public string dodAmt { get; set; }
            public string dodRecqty { get; set; }
            public string dodCancelqty { get; set; }
            public string dodOutqty { get; set; }
            public string dodDate { get; set; }
            public string dodTime { get; set; }
            public string brandcode { get; set; }
            public string brandname { get; set; }
            public string linenumber { get; set; }
            public string doNo { get; set; }
            public string doststatus { get; set; }

            public string doId { get; set; }
            public string RunningNo { get; set; }

            public string syncGuid { get; set; }
            public string syncClientindex { get; set; }
            public string syncLstupd { get; set; }
            public string syncClientindexstring { get; set; }
            public string poststatus { get; set; }
        }
        public class Deldodetails
        {
            public string doId { get; set; }
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
                ddl_supplierInvDoWithOutletPO.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_supplierInvDoWithOutletPO.Items.Add(new ListItem(oDr["supplydesc"].ToString().Trim(), oDr["splyCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                ddlStoreCode_InvDoWithOutletPO.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlStoreCode_InvDoWithOutletPO.Items.Add(new ListItem(oDr["itemsiteDesc"].ToString().Trim(), oDr["itemsiteCode"].ToString().Trim()));
                }
                ddlStoreCode_InvDoWithOutletPO.Value= System.Configuration.ConfigurationManager.AppSettings["SiteCode"];

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
        public static void DeldodetailsData(List<Deldodetails> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Deldodetails c = new Deldodetails { doId = Details[0].doId };
                string api = "api/dodetails/" + Details[0].doId;
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
        public static void AdddosData(List<dosInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "Outlet PO Invoice";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> InvDoWithOutletPO = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].doNo = InvDoWithOutletPO[0].controlPrefix + InvDoWithOutletPO[0].siteCode + InvDoWithOutletPO[0].controlNo;
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
                var post = client.PostAsJsonAsync<List<dosInput>>("api/dos", Details);
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
        public static void EditdosData(List<dosInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<dosInput>("api/dos/update?[where][doNo]=" + Details[0].doNo + "", Details[0]);
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
        public static void AdddoDtlsData(List<doDtls> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "Outlet PO Invoice";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> InvDoWithOutletPO = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].doNo = InvDoWithOutletPO[0].controlPrefix+ InvDoWithOutletPO[0].siteCode + InvDoWithOutletPO[0].controlNo;
                    Details[0].RunningNo =  InvDoWithOutletPO[0].controlNo;
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
                    mc.doNo = Details[0].doNo;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<doDtls>>("api/dodetails", Details);
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
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Outlet PO Invoice", controlnumber = Convert.ToString(NewcontrolNo) };
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
        public static void EditdoDtlsData(List<doDtls> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].doId != "" && Details[i].doId != null)
                {
                    using (var client = new HttpClient())
                    {
                        doDtls p = new doDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,dodItemcode = Details[i].dodItemcode,
                            dodItemdesc = Details[i].dodItemdesc,dodItemprice = Details[i].dodItemprice,dodQty = Details[i].dodQty,
                            dodFocqty = Details[i].dodFocqty,dodTtlqty = Details[i].dodTtlqty,
                            dodPrice = Details[i].dodPrice,dodDiscper = Details[i].dodDiscper,dodDiscamt = Details[i].dodDiscamt,
                            dodAmt = Details[i].dodAmt,dodRecqty = Details[i].dodRecqty,dodCancelqty = Details[i].dodCancelqty,
                            dodOutqty = Details[i].dodOutqty,dodDate = Details[i].dodDate,dodTime = Details[i].dodTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,syncClientindexstring = Details[i].syncClientindexstring,
                            brandcode = Details[i].brandcode,brandname = Details[i].brandname,linenumber = Details[i].linenumber,doNo = Details[i].doNo,
                            poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<doDtls>("api/dodetails/update?[where][doId]=" + Details[i].doId + "", p);
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
                        doDtls p = new doDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,dodItemcode = Details[i].dodItemcode,
                            dodItemdesc = Details[i].dodItemdesc,dodItemprice = Details[i].dodItemprice,dodQty = Details[i].dodQty,
                            dodFocqty = Details[i].dodFocqty,dodTtlqty = Details[i].dodTtlqty,
                            dodPrice = Details[i].dodPrice,dodDiscper = Details[i].dodDiscper,dodDiscamt = Details[i].dodDiscamt,
                            dodAmt = Details[i].dodAmt,dodRecqty = Details[i].dodRecqty,dodCancelqty = Details[i].dodCancelqty,
                            dodOutqty = Details[i].dodOutqty,dodDate = Details[i].dodDate,dodTime = Details[i].dodTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,
                            syncClientindexstring = Details[i].syncClientindexstring,brandcode = Details[i].brandcode,brandname = Details[i].brandname,
                            linenumber = Details[i].linenumber,doNo = Details[i].doNo,poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<doDtls>("api/dodetails", p);
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

        [WebMethod]
        public static void AddStktrnsData(List<StktrnsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<StktrnsInput>>("api/Stktrns", Details);
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

                _PKey = Request.QueryString["PKey"].ToString();
                _PKey1 = Request.QueryString["PKey1"].ToString();
                _PKey2 = Request.QueryString["PKey2"].ToString();
                if (Request.QueryString["PKey2"] != "null")
                {
                    
                    btnSubmit_AddInvDoWithOutletPO.InnerText = "Edit";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string api = "api/dos?filter={\"where\":{\"doNo\":\"" + _PKey2 + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<dosInput> StkMovdocHdrsVal = JsonConvert.DeserializeObject<List<dosInput>>(a);
                            txtInvNo_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].doNo;
                            txtDocNo_InvDoWithOutletPO.Value = _PKey;
                            dt_DocDateInvDoWithOutletPO.Value = Convert.ToDateTime(StkMovdocHdrsVal[0].doDate).ToString("dd/MM/yyyy");
                            
                            ddl_supplierInvDoWithOutletPO.Value = StkMovdocHdrsVal[0].suppCode;
                            ddlStoreCode_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].itemsiteCode;
                            txtRemark_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].doRemk1;
                            txt_TotAmntInvDoWithOutletPO.Value = StkMovdocHdrsVal[0].doTtqty;
                            txtTotQty_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].doTtqty;
                            recStatus = StkMovdocHdrsVal[0].doStatus;
                            if (StkMovdocHdrsVal[0].doStatus == "Posted")
                            {
                                txtStatus_InvDoWithOutletPO.Value = "Open";
                                btnSubmit_AddInvDoWithOutletPO.Disabled = false;
                                btnSubmit_PostInvDoWithOutletPO.Disabled = false;
                            }
                            else
                            {
                                txtStatus_InvDoWithOutletPO.Value = "Approved";
                                btnSubmit_AddInvDoWithOutletPO.Disabled = true;
                                btnSubmit_PostInvDoWithOutletPO.Disabled = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                    List<doDtls> StkMovdocDtlsVal = JsonConvert.DeserializeObject<List<doDtls>>(GetapiCalling("api/dodetails?filter={\"where\":{\"doNo\":\"" + _PKey2 + "\"}}"));
                    if (StkMovdocDtlsVal.Count > 0 && InvDoWithOutletPOEntryModule.Rows.Count == 1)
                    {
                        for (int i = 0; i < StkMovdocDtlsVal.Count; i++)
                        {
                            HtmlTableRow _Row = new HtmlTableRow();

                            HtmlTableCell Col_0 = new HtmlTableCell();
                            Col_0.Attributes.Add("style", "width: 0 % ;visibility:hidden;");
                            Col_0.InnerHtml = StkMovdocDtlsVal[i].doId;
                            //Col_15.InnerHtml = "<input type='hidden' class=form-control' value=" + StkMovdocDtlsVal[i].docId + " id='txthiddenId_InvDoWithOutletPODtl' runat='server'>";
                            _Row.Controls.Add(Col_0);


                            HtmlTableCell Col_2 = new HtmlTableCell();
                            Col_2.Attributes.Add("style", "width: 5 %");
                            Col_2.InnerText = StkMovdocDtlsVal[i].linenumber;
                            _Row.Controls.Add(Col_2);

                            HtmlTableCell Col_3 = new HtmlTableCell();
                            Col_3.Attributes.Add("style", "width: 10 %");
                            Col_3.InnerText = StkMovdocDtlsVal[i].dodItemcode;
                            _Row.Controls.Add(Col_3);

                            HtmlTableCell Col_4 = new HtmlTableCell();
                            Col_4.Attributes.Add("style", "width: 20 %");
                            Col_4.InnerText = StkMovdocDtlsVal[i].dodItemdesc;
                            _Row.Controls.Add(Col_4);

                            HtmlTableCell Col_5 = new HtmlTableCell();
                            Col_5.Attributes.Add("style", "width: 10 %");
                            Col_5.InnerText = StkMovdocDtlsVal[i].brandname;
                            _Row.Controls.Add(Col_5);

                            HtmlTableCell Col_6 = new HtmlTableCell();
                            Col_6.Attributes.Add("style", "width: 10 %");
                            //Col_6.InnerText = StkMovdocDtlsVal[i].dodItemprice;
                            Col_6.InnerHtml = "<input type='number' class='quantity form-control' value=" + StkMovdocDtlsVal[i].dodItemprice + " id='txtPrice_InvDoWithOutletPO' runat='server'>";
                            _Row.Controls.Add(Col_6);

                            HtmlTableCell Col_7 = new HtmlTableCell();
                            Col_7.Attributes.Add("style", "width: 10 %");
                            Col_7.InnerText = StkMovdocDtlsVal[i].dodDiscper;
                            _Row.Controls.Add(Col_7);

                            HtmlTableCell Col_8 = new HtmlTableCell();
                            Col_8.Attributes.Add("style", "width: 10 %");
                            Col_8.InnerText = StkMovdocDtlsVal[i].dodDiscamt;
                            _Row.Controls.Add(Col_8);

                            HtmlTableCell Col_9 = new HtmlTableCell();
                            Col_9.Attributes.Add("style", "width: 10 %");
                            //Col_9.InnerText = StkMovdocDtlsVal[i].dodQty;
                            Col_9.InnerHtml = "<input type='number' class='InvDoWithOutletPOquantity form-control' value=" + StkMovdocDtlsVal[i].dodQty + " id='txtAppQty_InvDoWithOutletPO' runat='server'>";
                            _Row.Controls.Add(Col_9);

                            if (recStatus == "Posted")
                            {
                                HtmlTableCell Col_12 = new HtmlTableCell();
                                Col_12.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_12.InnerHtml = "<div class='tools'><i class='Remove_AddItemToInvDoWithOutletPOAfterSave glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_12);
                            }
                            InvDoWithOutletPOEntryModule.Rows.Add(_Row);
                        }
                    }

                    


                }
                else
                {
                    btnSubmit_AddInvDoWithOutletPO.InnerText = "Add";
                    txtStatus_InvDoWithOutletPO.Value = "Open";
                    //_PKey = "";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string api = "api/reqs?filter={\"where\":{\"reqNo\":\"" + _PKey + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<reqsInput> StkMovdocHdrsVal = JsonConvert.DeserializeObject<List<reqsInput>>(a);
                            txtDocNo_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].reqNo;

                            dt_DocDateInvDoWithOutletPO.Value = Convert.ToDateTime(StkMovdocHdrsVal[0].reqDate).ToString("dd/MM/yyyy");
                            StkMovdocHdrsVal[0].reqStatus = "Open";
                            txtStatus_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].reqStatus;
                            //if (StkMovdocHdrsVal[0].reqStatus == "0")
                            //{
                            //    txtStatus_InvDoWithOutletPO.Value = "Open";
                            //}
                            //else
                            //{
                            //    txtStatus_InvDoWithOutletPO.Value = "Posted";
                            //}
                            ddl_supplierInvDoWithOutletPO.Value = StkMovdocHdrsVal[0].suppCode;
                            ddlStoreCode_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].itemsiteCode;
                            txtRemark_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].reqRemk1;
                            txt_TotAmntInvDoWithOutletPO.Value = StkMovdocHdrsVal[0].reqTtqty;
                            txtTotQty_InvDoWithOutletPO.Value = StkMovdocHdrsVal[0].reqTtqty;
                            recStatus = StkMovdocHdrsVal[0].reqStatus;
                            if (StkMovdocHdrsVal[0].reqStatus == "Open")
                            {
                                btnSubmit_AddInvDoWithOutletPO.Disabled = false;
                                btnSubmit_PostInvDoWithOutletPO.Disabled = true;
                            }
                            else
                            {
                                btnSubmit_AddInvDoWithOutletPO.Disabled = true;
                                btnSubmit_PostInvDoWithOutletPO.Disabled = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                    List<reqDtls> StkMovdocDtlsVal = JsonConvert.DeserializeObject<List<reqDtls>>(GetapiCalling("api/reqdetails?filter={\"where\":{\"reqNo\":\"" + _PKey + "\"}}"));
                    if (StkMovdocDtlsVal.Count > 0 && InvDoWithOutletPOEntryModule.Rows.Count == 1)
                    {
                        for (int i = 0; i < StkMovdocDtlsVal.Count; i++)
                        {
                            HtmlTableRow _Row = new HtmlTableRow();

                            HtmlTableCell Col_0 = new HtmlTableCell();
                            Col_0.Attributes.Add("style", "width: 0 % ;visibility:hidden;");
                            Col_0.InnerHtml = StkMovdocDtlsVal[i].reqId;
                            //Col_15.InnerHtml = "<input type='hidden' class=form-control' value=" + StkMovdocDtlsVal[i].docId + " id='txthiddenId_InvDoWithOutletPODtl' runat='server'>";
                            _Row.Controls.Add(Col_0);


                            HtmlTableCell Col_2 = new HtmlTableCell();
                            Col_2.Attributes.Add("style", "width: 5 %");
                            Col_2.InnerText = StkMovdocDtlsVal[i].linenumber;
                            _Row.Controls.Add(Col_2);

                            HtmlTableCell Col_3 = new HtmlTableCell();
                            Col_3.Attributes.Add("style", "width: 10 %");
                            Col_3.InnerText = StkMovdocDtlsVal[i].reqdItemcode;
                            _Row.Controls.Add(Col_3);

                            HtmlTableCell Col_4 = new HtmlTableCell();
                            Col_4.Attributes.Add("style", "width: 20 %");
                            Col_4.InnerText = StkMovdocDtlsVal[i].reqdItemdesc;
                            _Row.Controls.Add(Col_4);

                            HtmlTableCell Col_5 = new HtmlTableCell();
                            Col_5.Attributes.Add("style", "width: 10 %");
                            Col_5.InnerText = StkMovdocDtlsVal[i].brandname;
                            _Row.Controls.Add(Col_5);

                            HtmlTableCell Col_6 = new HtmlTableCell();
                            Col_6.Attributes.Add("style", "width: 10 %");
                            //Col_6.InnerText = StkMovdocDtlsVal[i].reqdItemprice;
                            Col_6.InnerHtml = "<input type='number' class='quantity form-control' value=" + StkMovdocDtlsVal[i].reqdItemprice + " id='txtPrice_InvDoWithOutletPO' runat='server'>";
                            _Row.Controls.Add(Col_6);

                            HtmlTableCell Col_7 = new HtmlTableCell();
                            Col_7.Attributes.Add("style", "width: 10 %");
                            Col_7.InnerText = StkMovdocDtlsVal[i].reqdDiscper;
                            _Row.Controls.Add(Col_7);

                            HtmlTableCell Col_8 = new HtmlTableCell();
                            Col_8.Attributes.Add("style", "width: 10 %");
                            Col_8.InnerText = StkMovdocDtlsVal[i].reqdDiscamt;
                            _Row.Controls.Add(Col_8);

                            HtmlTableCell Col_9 = new HtmlTableCell();
                            Col_9.Attributes.Add("style", "width: 10 %");
                            //Col_9.InnerText = StkMovdocDtlsVal[i].reqdQty;
                            Col_9.InnerHtml = "<input type='number' class='InvDoWithOutletPOquantity form-control' value=" + StkMovdocDtlsVal[i].reqdQty + " id='txtAppQty_InvDoWithOutletPO' runat='server'>";
                            _Row.Controls.Add(Col_9);

                            if (recStatus == "Open")
                            {
                                HtmlTableCell Col_12 = new HtmlTableCell();
                                Col_12.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_12.InnerHtml = "<div class='tools'><i class='Remove_AddItemToInvDoWithOutletPO glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_12);
                            }
                            else
                            {
                                HtmlTableCell Col_12 = new HtmlTableCell();
                                Col_12.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_12.InnerHtml = "<div class='tools'><i class='Remove_AddItemToInvDoWithOutletPOAfterSave glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_12);
                            }
                            InvDoWithOutletPOEntryModule.Rows.Add(_Row);
                        }
                    }
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