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
    public partial class ItemCommissionMaster : System.Web.UI.Page
    {
        #region Declaration
        private string _PKey = "";
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_Lead = new DataTable();
        private DataTable oDT_atStudent = new DataTable();

        private Dictionary<string, string> empLevelList;


        public class commissionGroupHrInput
        {
            public string code { get; set; }
            public string description { get; set; }
            public bool isactive { get; set; }
            public bool isservice { get; set; }
            public string type { get; set; }
            public string type2 { get; set; }
        }

        public class commissionGroupHrFetch
        {
            public Int64 id { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public bool isactive { get; set; }
            public bool isservice { get; set; }
            public string type { get; set; }
            public string type2 { get; set; }
        }


        public class commDetailListingData
        {
                public string code { get; set; }
                public string commLevel { get; set; }
                public int commValue { get; set; }
                public bool ispercent { get; set; }
                public bool isactive { get; set; }
                public bool isdiscaffect { get; set; }
                public int fscale { get; set; }
                public int tscale { get; set; }
                public int level { get; set; }
                public string commDtlCode { get; set; }
                public int commBalValue { get; set; }
                public bool commBalIspercent { get; set; }
                public int calmethod { get; set; }
        }

        public class commDetailListingDataFetch
        {
            public int id { get; set; }
            public string code { get; set; }
            public string commLevel { get; set; }
            public int commValue { get; set; }
            public bool ispercent { get; set; }
            public bool isactive { get; set; }
            public bool isdiscaffect { get; set; }
            public int fscale { get; set; }
            public int tscale { get; set; }
            public int level { get; set; }
            public string commDtlCode { get; set; }
            public int commBalValue { get; set; }
            public bool commBalIspercent { get; set; }
            public int calmethod { get; set; }
        }

        public class commSiteGroupListingData
        {
            //public int id { get; set; }
            public string commCode { get; set; }
            public string siteGroup { get; set; }
            public bool isactive { get; set; }
        }

        public class commSiteGroupListingDataFetch
        {
            public int id { get; set; }
            public string commCode { get; set; }
            public string siteGroup { get; set; }
            public bool isactive { get; set; }
        }

        #endregion

        #region Functions

        #region LoadValue

        private void LoadValue()
        {
            try
            {

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemPrepaidConditions"), (typeof(DataTable)));

                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV8 = new DataView(oDT_General);
                    oDV8.RowFilter = "isactive = True";
                    oDT_General = oDV8.ToTable();
                }

                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlCommPrepaidType.Items.Add(new ListItem(oDr["condDesc"].ToString().Trim(), oDr["condCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/SiteGroups"), (typeof(DataTable)));
                
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV8 = new DataView(oDT_General);
                    oDV8.RowFilter = "isActive = True";
                    oDT_General = oDV8.ToTable();
                }

               

                if (oDT_General.Rows.Count > 0 && tblCommissionSiteGroup.Rows.Count == 1)
                {
                    for (int i = 0; i < oDT_General.Rows.Count; i++)
                    {
                        

                        HtmlTableRow _Row = new HtmlTableRow();
                        HtmlTableCell Col_1 = new HtmlTableCell();
                        Col_1.InnerText = oDT_General.Rows[i]["code"].ToString();

                        _Row.Controls.Add(Col_1);
                        HtmlTableCell Col_2 = new HtmlTableCell();
                        Col_2.InnerText = oDT_General.Rows[i]["description"].ToString();
                        _Row.Controls.Add(Col_2);
                        HtmlTableCell Col_3 = new HtmlTableCell();
                        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_3.InnerHtml = "<input type='checkbox' checked class='case'>";
                        _Row.Controls.Add(Col_3);

                        //Id
                        HtmlTableCell Col_4 = new HtmlTableCell();
                        Col_4.InnerHtml = "0";   // "<input type='hidden' class=form-control' value=" + commDetail[i].id + " id='txthiddenId_tblCommissionDetail' runat='server'>";
                        Col_4.Attributes.Add("style", "display: none;");
                        _Row.Controls.Add(Col_4);

                        tblCommissionSiteGroup.Rows.Add(_Row);
                    }
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/EmpLevels"), (typeof(DataTable)));

                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV8 = new DataView(oDT_General);
                    oDV8.RowFilter = "levelIsActive = True";
                    oDT_General = oDV8.ToTable();
                }

                empLevelList = new Dictionary<string, string>();

                if (oDT_General.Rows.Count > 0)
                {
                    for (int i = 0; i < oDT_General.Rows.Count; i++)
                    {
                        empLevelList.Add(oDT_General.Rows[i]["levelCode"].ToString(), oDT_General.Rows[i]["levelDesc"].ToString());

                    }
                }
                


            }
            catch (Exception)
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

        private string GetapiCalling(string apiName)
        {
            using (var client = new HttpClient())
            {
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
            try
            {


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Bind Data
        private void BindData()
        {
            try
            {
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Validation

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                return _RetVal;
            }
        }

        #endregion



        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

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

                if (!Page.IsPostBack) { 

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                     btnSubmit_AddCommissionMaster.InnerText = "Update";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string api = "api/CommGroupHdrs?filter={\"where\":{\"code\":\"" + _PKey + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                                var a = response.Content.ReadAsStringAsync().Result;
                                List<commissionGroupHrFetch> comms = JsonConvert.DeserializeObject<List<commissionGroupHrFetch>>(a);
                                txtCode_CommissionGroup.Value = comms[0].code;
                                txtCode_CommissionGroup.Disabled = true;
                                txtDescription_CommissionGroup.Value = comms[0].description;
                                ddlCommissionGroup.Value = comms[0].type;
                                if (comms[0].isactive == true)
                                {
                                    chk_CommissionGroupActive.Checked = true;
                                }
                                else
                                {
                                    chk_CommissionGroupActive.Checked = false;
                                }

                                //if (comms[0].type == "Prepaid")
                                //    rowPrepaidType.Visible = true;

                            }
                            else
                            {
                                Console.WriteLine("Internal server Error");
                            }

                            List<commDetailListingDataFetch> commDetail = JsonConvert.DeserializeObject<List<commDetailListingDataFetch>>(GetapiCalling("api/CommGroupDtls?filter={\"where\":{\"code\":\"" + _PKey + "\"}}"));
                            if (commDetail.Count > 0 && tblCommissionDetail.Rows.Count == 1)
                            {
                                for (int i = 0; i < commDetail.Count; i++)
                                {
                                    HtmlTableRow _Row = new HtmlTableRow();
                                    HtmlTableCell Col_1 = new HtmlTableCell();

                                    string output = "";
                                    Col_1.InnerText = commDetail[i].commLevel;
                                    Col_1.Attributes.Add("style", "display: none;");
                                    _Row.Controls.Add(Col_1);

                                    HtmlTableCell Col_2 = new HtmlTableCell();
                                    if (empLevelList.TryGetValue(commDetail[i].commLevel, out output))
                                    {
                                        Col_2.InnerText = empLevelList[commDetail[i].commLevel];
                                    }
                                    else
                                    {
                                        Col_2.InnerText = commDetail[i].commLevel;
                                    }
                                    _Row.Controls.Add(Col_2);

                                    HtmlTableCell Col_3 = new HtmlTableCell();
                                    Col_3.InnerText = Convert.ToString(commDetail[i].fscale);
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    Col_3.InnerText = Convert.ToString(commDetail[i].tscale);
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    Col_3.InnerText = Convert.ToString(commDetail[i].commValue);
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    if(commDetail[i].ispercent == true)
                                        Col_3.InnerText = "Yes";
                                    else
                                        Col_3.InnerText = "No";
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    if (commDetail[i].calmethod == 1)
                                        Col_3.InnerText = "Normal";
                                    else
                                        Col_3.InnerText = "Floor Price";
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    if (commDetail[i].level == 1)
                                        Col_3.InnerText = "Single Transaction";
                                    else
                                        Col_3.InnerText = "Period Transaction";
                                    _Row.Controls.Add(Col_3);

                                    Col_3 = new HtmlTableCell();
                                    if (commDetail[i].isactive == true)
                                        Col_3.InnerText = "Yes";
                                    else
                                        Col_3.InnerText = "No";
                                    _Row.Controls.Add(Col_3);

                                    HtmlTableCell Col_4 = new HtmlTableCell();
                                    Col_4.Attributes.Add("style", "width: 10%; text-align:center");
                                    Col_4.InnerHtml = "<div class='tools'><i class='edit_mdlCommissonGrpDetail glyphicon glyphicon-pencil'></i></div>";
                                    _Row.Controls.Add(Col_4);

                                    //Id
                                    HtmlTableCell Col_5 = new HtmlTableCell();
                                    Col_5.InnerHtml = Convert.ToString(commDetail[i].id);   // "<input type='hidden' class=form-control' value=" + commDetail[i].id + " id='txthiddenId_tblCommissionDetail' runat='server'>";
                                    Col_5.Attributes.Add("style", "display: none;");
                                    _Row.Controls.Add(Col_5);

                                    //Comm detail code
                                    Col_5 = new HtmlTableCell();
                                    Col_5.InnerHtml = Convert.ToString(commDetail[i].commDtlCode);   //
                                    Col_5.Attributes.Add("style", "display: none;");
                                    _Row.Controls.Add(Col_5);

                                    tblCommissionDetail.Rows.Add(_Row);

                                }
                            }

                        }

                    List<commSiteGroupListingDataFetch> commSiteGroupListingDatas = JsonConvert.DeserializeObject<List<commSiteGroupListingDataFetch>>(GetapiCalling("api/CommissionSiteGroups?filter={\"where\":{\"commCode\":\"" + _PKey + "\"}}"));
                        if (commSiteGroupListingDatas.Count > 0)
                        {
                            for (int i = 0; i < tblCommissionSiteGroup.Rows.Count; i++)
                            {
                                string col2 = tblCommissionSiteGroup.Rows[i].Cells[0].InnerHtml;
                                var _lst = commSiteGroupListingDatas.Where(x => x.siteGroup == col2 && x.isactive == true).ToList();
                                if (_lst.Count > 0)
                                {
                                    tblCommissionSiteGroup.Rows[i].Cells[2].InnerHtml = "<input type='checkbox' checked class='case'>";
                                    tblCommissionSiteGroup.Rows[i].Cells[3].InnerHtml = Convert.ToString(_lst[0].id);
                                }
                                else
                                {
                                    tblCommissionSiteGroup.Rows[i].Cells[2].InnerHtml = "<input type='checkbox' class='case'>";
                                }

                                
                            }
                        }

                    }
                else
                {
                    _PKey = "";
                    btnSubmit_AddCommissionMaster.InnerText = "Add";
                    txtDescription_CommissionGroup.Focus();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method  
                        string codeDesc = "Comm No";
                        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                        var response = client.GetAsync(api).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadAsStringAsync().Result;
                            List<ControlNos> depts = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                            if(depts.Count>0)
                             txtCode_CommissionGroup.Value = depts[0].controlNo;
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                    }
                }

             }

             
            }
            catch (Exception Ex)
            {
            }

        }

        [WebMethod]
        public static void AddCommissionGroupHrData(string code, string description, bool isactive, bool isservice,  
            string type, string type2, string siteCode)
        {
            if (string.IsNullOrEmpty(siteCode))
                siteCode = "HQ";

            if (type == "Work")
            {
                isservice = true;
                type2 = "";
            }
            else if(type == "Prepaid")
            {
                isservice = false;
            }
            else
            {
                isservice = false;
                type2 = "";
            }
                

            using (var client = new HttpClient())
            {
                commissionGroupHrInput p = new commissionGroupHrInput{ code = code, description = description, isactive = isactive, isservice = isservice, 
                    type = type, type2 = type2};
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<commissionGroupHrInput>("api/CommGroupHdrs", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    int Newcontrol = int.Parse(code);
                    int NewcontrolNo = Newcontrol + 1;
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "Comm No", sitecode = siteCode , controlnumber = Convert.ToString(NewcontrolNo) };
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
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.Write("Error");
                }


            }
        }

        [WebMethod]
        public static void EditCommissionGroupHrData(string code, string description, bool isactive, bool isservice,
            string type, string type2, string siteCode)
        {

            if (type == "Work")
            {
                isservice = true;
                type2 = "";
            }
            else if (type == "Prepaid")
            {
                isservice = false;
            }
            else
            {
                isservice = false;
                type2 = "";
            }

            using (var client = new HttpClient())
            {
                commissionGroupHrInput p = new commissionGroupHrInput
                {
                    code = code,
                    description = description,
                    isactive = isactive,
                    isservice = isservice,
                    type = type,
                    type2 = type2
                };

                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<commissionGroupHrInput>("api/CommGroupHdrs/update?[where][code]=" + code + "", p);
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
        public static void AddCommissionDetailListing(List<commDetailListingData> Details)
        {
            if (Details.Count > 0)
            {

                // to get commission detail control no.
                Int64 controlNo = 0;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    string codeDesc = "Comm Detail Code";
                    string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                    var response = client.GetAsync(api).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var a = response.Content.ReadAsStringAsync().Result;
                        List<ControlNos> depts = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                        if (depts.Count > 0)
                            controlNo = Int64.Parse(depts[0].controlNo);
                    }
                }

                for(int i=0; i < Details.Count; i++)
                {
                    Details[i].commDtlCode = Convert.ToString(controlNo);
                    controlNo += 1;
                }

               using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<commDetailListingData>>("api/CommGroupDtls", Details);
                    post.Wait();
                    var response = post.Result;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    if (response.IsSuccessStatusCode)
                    {
                        ControlNosUpdate c = new ControlNosUpdate { controldescription = "Comm Detail Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString(controlNo) };
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
                        var errorMessage = response.Content.ReadAsStringAsync().Result;
                        Console.Write("Error");
                    }
                }
            }
        }

        [WebMethod]
        public static void EditCommissionDetailListing(List<commDetailListingDataFetch> Details)
        {
            List<commDetailListingData> insertCommDetailList = new List<commDetailListingData>();
            List<commDetailListingDataFetch> updateCommDetailList = new List<commDetailListingDataFetch>();

            if (Details.Count > 0)
            {

                // to get commission detail control no.
                Int64 controlNo = 0;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    string codeDesc = "Comm Detail Code";
                    string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
                    var response = client.GetAsync(api).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var a = response.Content.ReadAsStringAsync().Result;
                        List<ControlNos> depts = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                        if (depts.Count > 0)
                            controlNo = Int64.Parse(depts[0].controlNo);
                    }
                }

                for (int i = 0; i < Details.Count; i++)
                {

                    if (string.IsNullOrEmpty(Details[i].commDtlCode))
                    {
                        Details[i].commDtlCode = Convert.ToString(controlNo);
                        controlNo += 1;
                        commDetailListingData insertCommDetailData = new commDetailListingData();
                        insertCommDetailData.code = Details[i].code;
                        insertCommDetailData.commLevel = Details[i].commLevel;
                        insertCommDetailData.commValue = Details[i].commValue;
                        insertCommDetailData.ispercent = Details[i].ispercent;
                        insertCommDetailData.isactive = Details[i].isactive;
                        insertCommDetailData.isdiscaffect = Details[i].isdiscaffect;
                        insertCommDetailData.fscale = Details[i].fscale;
                        insertCommDetailData.tscale = Details[i].tscale;
                        insertCommDetailData.level = Details[i].level;
                        insertCommDetailData.commDtlCode = Details[i].commDtlCode;
                        insertCommDetailData.commBalValue = Details[i].commBalValue;
                        insertCommDetailData.commBalIspercent = Details[i].commBalIspercent;
                        insertCommDetailData.calmethod = Details[i].calmethod;
                        insertCommDetailList.Add(insertCommDetailData);
                    }
                    else
                    {
                        updateCommDetailList.Add(Details[i]);
                    }
                }

                //Update Commisson details
                if(updateCommDetailList.Count > 0)
                {
                    for(int i=0; i<updateCommDetailList.Count; i++)
                    {

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<commDetailListingDataFetch>("api/CommGroupDtls", updateCommDetailList[i]);
                            post.Wait();
                            var response = post.Result;
                            System.Net.ServicePointManager.Expect100Continue = false;
                            if (response.IsSuccessStatusCode)
                            {
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


                //New commission details
                if (insertCommDetailList.Count > 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<List<commDetailListingData>>("api/CommGroupDtls", insertCommDetailList);
                        post.Wait();
                        var response = post.Result;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        if (response.IsSuccessStatusCode)
                        {
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Comm Detail Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString(controlNo) };
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
                            var errorMessage = response.Content.ReadAsStringAsync().Result;
                            Console.Write("Error");
                        }
                    }
                }
               
            }
        }

        [WebMethod]
        public static void AddCommissionSiteGroupListing(List<commSiteGroupListingData> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<commSiteGroupListingData>>("api/CommissionSiteGroups", Details);
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

        [WebMethod]
        public static void EditCommissionSiteGroupListing(List<commSiteGroupListingDataFetch> Details)
        {
            if (Details.Count > 0)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/CommissionSiteGroups?filter={\"where\":{\"commCode\":\"" + Details[0].commCode + "\"}}";
                var response = client.GetAsync(api).Result;
                List<commSiteGroupListingDataFetch> commSiteGroupListings;
                var a = response.Content.ReadAsStringAsync().Result;
                commSiteGroupListings = JsonConvert.DeserializeObject<List<commSiteGroupListingDataFetch>>(a);

                if (commSiteGroupListings.Count > 0)
                {
                    for (var i = 0; i < commSiteGroupListings.Count; i++)
                    {
                        using (var client1 = new HttpClient())
                        {
                            client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var deleteTask = client1.DeleteAsync("api/CommissionSiteGroups/" + commSiteGroupListings[i].id);
                            deleteTask.Wait();
                            var response1 = deleteTask.Result;
                            if (response1.IsSuccessStatusCode)
                            {
                                var errorMessage = response1.Content.ReadAsStringAsync().Result;
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

                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    List<commSiteGroupListingData> newCommissionSiteGroupListing = new List<commSiteGroupListingData>();
                    for (int i = 0; i < Details.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(Details[i].commCode))
                        {
                            commSiteGroupListingData siteGroupListingData = new commSiteGroupListingData();
                            siteGroupListingData.commCode = Details[i].commCode;
                            siteGroupListingData.siteGroup = Details[i].siteGroup;
                            siteGroupListingData.isactive = Details[i].isactive;
                            newCommissionSiteGroupListing.Add(siteGroupListingData);
                        }
                    }

                    var post2 = client2.PostAsJsonAsync<List<commSiteGroupListingData>>("api/CommissionSiteGroups", newCommissionSiteGroupListing);
                    post2.Wait();
                    var response2 = post2.Result;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    if (response2.IsSuccessStatusCode)
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

      

        #endregion

    }
}