using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class CountrySettings : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string SiteGrp_Prefix = string.Empty, SiteGrp_ControlNo = string.Empty, _PKey = string.Empty;
        String CountryPrefix = String.Empty, Country_ControlNo = String.Empty, StatePrefix = String.Empty, State_ControlNo = String.Empty;
        String CityPrefix = String.Empty, City_ControlNo = String.Empty;

        #region Methods

        private void Get_ControlNo_Prefixs()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Country Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    CountryPrefix = controlNos[0].controlPrefix;
                    Country_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"State Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    StatePrefix = controlNos[0].controlPrefix;
                    State_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"CITY CODE\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    CityPrefix = controlNos[0].controlPrefix;
                    City_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


            }

        }

        protected void Get_Cities()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Cities"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Cities"));
            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203/main/api/race?siteCode=SL02"));

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

            List<MasterCitiesUpdate> items = new List<MasterCitiesUpdate>();
            items = JsonConvert.DeserializeObject<List<MasterCitiesUpdate>>(jsonString);

            oDT_City = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

            for (int i = 0; i < items.Count; i++)
            {

                //ddlCity.Items.Add(new ListItem(items[i].itmDesc, items[i].itmCode));

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %;");
                Col_1.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %;");
                Col_2.InnerText = items[i].itmDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CityMaster editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CityMaster editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CityMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].itmId.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = CityPrefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = City_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblSiteAddress_City.Rows.Add(_Row);

            }

            //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        }

        protected void Get_States()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/States"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/States"));
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

            List<MasterCitiesUpdate> items = new List<MasterCitiesUpdate>();
            items = JsonConvert.DeserializeObject<List<MasterCitiesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

               // ddlState.Items.Add(new ListItem(items[i].itmDesc, items[i].itmCode));

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %");
                Col_1.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %");
                Col_2.InnerText = items[i].itmDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_StateMaster editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_StateMaster editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_StateMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].itmId.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = StatePrefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = State_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblSiteAddress_State.Rows.Add(_Row);

            }
        }

        protected void Get_Countries()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Countries"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Countries"));
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

            List<MasterCountriesUpdate> items = new List<MasterCountriesUpdate>();
            items = JsonConvert.DeserializeObject<List<MasterCountriesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                //ddlCountry.Items.Add(new ListItem(items[i].itmDesc, items[i].itmCode));

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %");
                Col_1.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %");
                Col_2.InnerText = items[i].itmDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_CountryMaster editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_CountryMaster editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_CountryMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].itmId.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = CountryPrefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Country_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);

                tblSiteAddress_Country.Rows.Add(_Row);

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


                };
                Get_ControlNo_Prefixs();
                Get_Cities();
                Get_States();
                Get_Countries();               

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }      

        #endregion

    }
}