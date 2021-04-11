using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.UI.HtmlControls;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class CustomerMaster : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();
        String Grp1Prefix = String.Empty, Grp2Prefix = String.Empty, Grp3Prefix = string.Empty, ProdGrpPrefix= string.Empty, CustomerPrefix=string.Empty;
        String Grp1_ControlNo = String.Empty, Grp2_ControlNo = String.Empty, Grp3_ControlNo = String.Empty, ProdGrp_ControlNo = String.Empty, Customer_ControlNo = string.Empty;

        //protected void Get_CustomerClass()
        //{

        //    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerClasses"));


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

        //    // DataTable dt = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;

        //    List<CustomerClassUpdate> items = new List<CustomerClassUpdate>();
        //    items = JsonConvert.DeserializeObject<List<CustomerClassUpdate>>(jsonString);

        //    for (int i = 0; i < items.Count; i++)
        //    {

        //        HtmlTableRow _Row = new HtmlTableRow();
        //        HtmlTableCell Col_1 = new HtmlTableCell();
        //        Col_1.InnerText = items[i].classCode;
        //        _Row.Controls.Add(Col_1);
        //        HtmlTableCell Col_2 = new HtmlTableCell();
        //        Col_2.InnerText = items[i].classDesc;
        //        _Row.Controls.Add(Col_2);
        //        HtmlTableCell Col_3 = new HtmlTableCell();
        //        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
        //        if (items[i].classIsactive == false)
        //        {
        //            Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerClass editor - active'>";
        //        }
        //        else
        //        {
        //            Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerClass editor - active'>";
        //        }
        //        _Row.Controls.Add(Col_3);
        //        HtmlTableCell Col_Action = new HtmlTableCell();
        //        Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
        //        Col_Action.InnerHtml = "<div class='tools'><i class='edit_CustomerClass glyphicon glyphicon-pencil'></i></div>";
        //        _Row.Controls.Add(Col_Action);
        //        HtmlTableCell Col_4 = new HtmlTableCell();
        //        Col_4.InnerText = items[i].id.ToString();
        //        Col_4.Attributes.Add("style", "width: 0px; display:none");
        //        _Row.Controls.Add(Col_4);
        //        tblCustomerClass.Rows.Add(_Row);

        //    }

        //    //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        //}

        protected void Get_CustomerClass()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerClasses"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CustomerClasses"));

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

            List<CustomerClassUpdate> items = new List<CustomerClassUpdate>();
            items = JsonConvert.DeserializeObject<List<CustomerClassUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.InnerHtml = "<a href='CustomerClass.aspx?PKey=" + items[i].id + "&ClassCode=" + items[i].classCode + "'><font color='#6a6000'><b>" + items[i].classCode + "</b></font></a>";
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.InnerText = items[i].classDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].classIsactive)
                {
                    //Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerClass editor - active'>";
                    Col_3.InnerText = "Yes";
                }
                else
                {
                    //Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerClass editor - active'>";
                    Col_3.InnerText = "No";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblCustomerClass.Rows.Add(_Row);

            }

            //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        }

        protected void Get_CustomerTypes()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerTypes"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CustomerTypes"));
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

            List<CustomerTypesUpdate> items = new List<CustomerTypesUpdate>();
            items = JsonConvert.DeserializeObject<List<CustomerTypesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 40 %");
                Col_1.InnerText = items[i].typeCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 40 %");
                Col_2.InnerText = items[i].typeDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].typeIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerTypeMaster editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerTypeMaster editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CustomerTypeMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                Col_4 = new HtmlTableCell();
                Col_4.InnerText = CustomerPrefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Customer_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                tblCustomerType.Rows.Add(_Row);

            }
        }

        protected void Get_CustomerGroup1s()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerGroups"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CustomerGroups"));
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

            List<CustomerGroup1sUpdate> items = new List<CustomerGroup1sUpdate>();
            items = JsonConvert.DeserializeObject<List<CustomerGroup1sUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 40 %");
                Col_1.InnerText = items[i].groupCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 40 %");
                Col_2.InnerText = items[i].groupDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].groupIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerGrp1Master editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerGrp1Master editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CustomerGrp1Master glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp1Prefix; 
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp1_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblCustomerGrp1.Rows.Add(_Row);

            }
        }

        protected void Get_CustomerGroup2s()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerGroup2s"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CustomerGroup2s"));
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

            List<CustomerGroup1sUpdate> items = new List<CustomerGroup1sUpdate>();
            items = JsonConvert.DeserializeObject<List<CustomerGroup1sUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 40 %");
                Col_1.InnerText = items[i].groupCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 40 %");
                Col_2.InnerText = items[i].groupDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].groupIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerGrp2Master editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerGrp2Master editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CustomerGrp2Master glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp2Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp2_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblCustomerGrp2.Rows.Add(_Row);

            }
        }

        protected void Get_CustomerGroup3s()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/CustomerGroup3s"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CustomerGroup3s"));
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

            List<CustomerGroup1sUpdate> items = new List<CustomerGroup1sUpdate>();
            items = JsonConvert.DeserializeObject<List<CustomerGroup1sUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 40 %");
                Col_1.InnerText = items[i].groupCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 40 %");
                Col_2.InnerText = items[i].groupDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].groupIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CustomerGrp3Master editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CustomerGrp3Master editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CustomerGrp3Master glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp3Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Grp3_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblCustomerGrp3.Rows.Add(_Row);

            }
        }

        protected void Get_ProductGroups()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ProductGroups"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ProductGroups"));
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

            List<ProductGroupsUpdate> items = new List<ProductGroupsUpdate>();
            items = JsonConvert.DeserializeObject<List<ProductGroupsUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 40 %");
                Col_1.InnerText = items[i].code;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 40 %");
                Col_2.InnerText = items[i].description;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isActive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_ProductGrpMaster editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_ProductGrpMaster editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_ProductGrpMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = ProdGrpPrefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = ProdGrp_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblProductGrp.Rows.Add(_Row);

            }
        }

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"CUSTOMER GROUP CODE\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Grp1Prefix = controlNos[0].controlPrefix;
                    Grp1_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Customer Group Code2\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Grp2Prefix = controlNos[0].controlPrefix;
                    Grp2_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Customer Group Code3\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Grp3Prefix = controlNos[0].controlPrefix;
                    Grp3_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Product Group Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    ProdGrpPrefix = controlNos[0].controlPrefix;
                    ProdGrp_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Customer Type Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    CustomerPrefix = controlNos[0].controlPrefix;
                    Customer_ControlNo = controlNos[0].controlNo;

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

                Get_ControlPrefixs();
                Get_CustomerClass();
                Get_CustomerTypes();
                Get_CustomerGroup1s();
                Get_CustomerGroup2s();
                Get_CustomerGroup3s();
                Get_ProductGroups();

                if (Request.QueryString["PKey"] != null)
                {
                    CollapsiblePanelCustomerClass.Collapsed = false;
                }
                

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

         

        }

    }
}