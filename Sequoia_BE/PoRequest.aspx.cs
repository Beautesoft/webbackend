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
    public partial class PoRequest : System.Web.UI.Page
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

        public class Delreqdetails
        {
            public string reqId { get; set; }
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
                ddl_supplierPOReq.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_supplierPOReq.Items.Add(new ListItem(oDr["supplydesc"].ToString().Trim(), oDr["splyCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                ddlStoreCode_POReq.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlStoreCode_POReq.Items.Add(new ListItem(oDr["itemsiteDesc"].ToString().Trim(), oDr["itemsiteCode"].ToString().Trim()));
                }
                ddlStoreCode_POReq.Value= System.Configuration.ConfigurationManager.AppSettings["SiteCode"];

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
        public static void DelreqdetailsData(List<Delreqdetails> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Delreqdetails c = new Delreqdetails { reqId = Details[0].reqId };
                string api = "api/reqdetails/" + Details[0].reqId;
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
        public static void AddreqsData(List<reqsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "PO REQUISITE";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> POReq = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].reqNo = POReq[0].controlPrefix + POReq[0].siteCode + POReq[0].controlNo;
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
                var post = client.PostAsJsonAsync<List<reqsInput>>("api/reqs", Details);
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
        public static void EditreqsData(List<reqsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<reqsInput>("api/reqs/update?[where][reqNo]=" + Details[0].reqNo + "", Details[0]);
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
        public static void AddreqDtlsData(List<reqDtls> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string codeDesc = "PO REQUISITE";
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> POReq = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Details[0].reqNo = POReq[0].controlPrefix+ POReq[0].siteCode + POReq[0].controlNo;
                    Details[0].RunningNo =  POReq[0].controlNo;
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
                    mc.reqNo = Details[0].reqNo;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<reqDtls>>("api/reqdetails", Details);
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
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "PO REQUISITE", controlnumber = Convert.ToString(NewcontrolNo) };
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
        public static void EditreqDtlsData(List<reqDtls> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].reqId != "" && Details[i].reqId != null)
                {
                    using (var client = new HttpClient())
                    {
                        reqDtls p = new reqDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,reqdItemcode = Details[i].reqdItemcode,
                            reqdItemdesc = Details[i].reqdItemdesc,reqdItemprice = Details[i].reqdItemprice,reqdQty = Details[i].reqdQty,
                            reqAppqty = Details[i].reqAppqty,reqdFocqty = Details[i].reqdFocqty,reqdTtlqty = Details[i].reqdTtlqty,
                            reqdPrice = Details[i].reqdPrice,reqdDiscper = Details[i].reqdDiscper,reqdDiscamt = Details[i].reqdDiscamt,
                            reqdAmt = Details[i].reqdAmt,reqdRecqty = Details[i].reqdRecqty,reqdCancelqty = Details[i].reqdCancelqty,
                            reqdOutqty = Details[i].reqdOutqty,reqdDate = Details[i].reqdDate,reqdTime = Details[i].reqdTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,syncClientindexstring = Details[i].syncClientindexstring,
                            brandcode = Details[i].brandcode,brandname = Details[i].brandname,linenumber = Details[i].linenumber,reqNo = Details[i].reqNo,
                            poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<reqDtls>("api/reqdetails/update?[where][reqId]=" + Details[i].reqId + "", p);
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
                        reqDtls p = new reqDtls
                        {
                            itemsiteCode = Details[i].itemsiteCode,status = Details[i].status,reqdItemcode = Details[i].reqdItemcode,
                            reqdItemdesc = Details[i].reqdItemdesc,reqdItemprice = Details[i].reqdItemprice,reqdQty = Details[i].reqdQty,
                            reqAppqty = Details[i].reqAppqty,reqdFocqty = Details[i].reqdFocqty,reqdTtlqty = Details[i].reqdTtlqty,
                            reqdPrice = Details[i].reqdPrice,reqdDiscper = Details[i].reqdDiscper,reqdDiscamt = Details[i].reqdDiscamt,
                            reqdAmt = Details[i].reqdAmt,reqdRecqty = Details[i].reqdRecqty,reqdCancelqty = Details[i].reqdCancelqty,
                            reqdOutqty = Details[i].reqdOutqty,reqdDate = Details[i].reqdDate,reqdTime = Details[i].reqdTime,syncGuid = Details[i].syncGuid,
                            syncClientindex = Details[i].syncClientindex,syncLstupd = Details[i].syncLstupd,
                            syncClientindexstring = Details[i].syncClientindexstring,brandcode = Details[i].brandcode,brandname = Details[i].brandname,
                            linenumber = Details[i].linenumber,reqNo = Details[i].reqNo,poststatus = Details[i].poststatus
                        };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<reqDtls>("api/reqdetails", p);
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
                    btnSubmit_AddPOReq.InnerText = "Edit";

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
                            txtDocNo_POReq.Value = StkMovdocHdrsVal[0].reqNo;
                            
                            dt_DocDatePOReq.Value =Convert.ToDateTime(StkMovdocHdrsVal[0].reqDate).ToString("dd/MM/yyyy");
                            txtStatus_POReq.Value = StkMovdocHdrsVal[0].reqStatus;
                            //if (StkMovdocHdrsVal[0].reqStatus == "0")
                            //{
                            //    txtStatus_POReq.Value = "Open";
                            //}
                            //else
                            //{
                            //    txtStatus_POReq.Value = "Posted";
                            //}
                            ddl_supplierPOReq.Value = StkMovdocHdrsVal[0].suppCode;
                            ddlStoreCode_POReq.Value = StkMovdocHdrsVal[0].itemsiteCode;
                            txtRemark_POReq.Value = StkMovdocHdrsVal[0].reqRemk1;
                            txt_TotAmntPOReq.Value = StkMovdocHdrsVal[0].reqTtqty;
                            txtTotQty_POReq.Value = StkMovdocHdrsVal[0].reqTtqty;
                            recStatus = StkMovdocHdrsVal[0].reqStatus;
                            if (StkMovdocHdrsVal[0].reqStatus == "Open")
                            {
                                btnSubmit_AddPOReq.Disabled = false;
                                btnSubmit_PostPOReq.Disabled = false;
                            }
                            else
                            {
                                btnSubmit_AddPOReq.Disabled = true;
                                btnSubmit_PostPOReq.Disabled = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }

                    List<reqDtls> StkMovdocDtlsVal = JsonConvert.DeserializeObject<List<reqDtls>>(GetapiCalling("api/reqdetails?filter={\"where\":{\"reqNo\":\"" + _PKey + "\"}}"));
                    if (StkMovdocDtlsVal.Count > 0 && POReqEntryModule.Rows.Count == 1)
                    {
                        for (int i = 0; i < StkMovdocDtlsVal.Count; i++)
                        {
                            HtmlTableRow _Row = new HtmlTableRow();

                            HtmlTableCell Col_0 = new HtmlTableCell();
                            Col_0.Attributes.Add("style", "width: 0 % ;visibility:hidden;");
                            Col_0.InnerHtml = StkMovdocDtlsVal[i].reqId;
                            //Col_15.InnerHtml = "<input type='hidden' class=form-control' value=" + StkMovdocDtlsVal[i].docId + " id='txthiddenId_POReqDtl' runat='server'>";
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
                            Col_6.InnerText = StkMovdocDtlsVal[i].reqdItemprice;
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
                            Col_9.InnerText = StkMovdocDtlsVal[i].reqdQty;
                            _Row.Controls.Add(Col_9);

                            if (recStatus == "Open")
                            {
                                HtmlTableCell Col_12 = new HtmlTableCell();
                                Col_12.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_12.InnerHtml = "<div class='tools'><i class='Remove_AddItemToPOReqAfterSave glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_12);
                            }
                            POReqEntryModule.Rows.Add(_Row);
                        }
                    }



                }
                else
                {
                    btnSubmit_AddPOReq.InnerText = "Add";
                    txtStatus_POReq.Value = "Open";
                    _PKey = "";
                    //FetchRecordAsync();
                    dt_DocDatePOReq.Value = DateTime.Now.ToString("dd/MM/yyyy");
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
                    //        txtDocNo_POReq.Value = PoReq[0].controlPrefix + PoReq[0].siteCode + PoReq[0].controlNo;
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