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
    public partial class CustomerMaster2 : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();
        String RacePrefix = String.Empty, AgeGrpPrefix = String.Empty, CorporatePrefix = string.Empty, SkinTypePrefix = string.Empty, LangPrefix = string.Empty, LocationPrefix = string.Empty, Source_Prefix = string.Empty, OccupationType_Prefix = string.Empty;
        String Race_ControlNo = String.Empty, AgeGrp_ControlNo = String.Empty, Corporate_ControlNo = String.Empty, Lang_ControlNo = String.Empty, SkinType_ControlNo = String.Empty, Location_ControlNo = String.Empty, Source_ControlNo = String.Empty, OccupationType_ControlNo = String.Empty;

        private void Get_ControlNo_Prefixs()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Race\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    RacePrefix = controlNos[0].controlPrefix;
                    Race_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Age Group\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    AgeGrpPrefix = controlNos[0].controlPrefix;
                    AgeGrp_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Skin Type Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    SkinTypePrefix = controlNos[0].controlPrefix;
                    SkinType_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Language Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    LangPrefix = controlNos[0].controlPrefix;
                    Lang_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Location Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    LocationPrefix = controlNos[0].controlPrefix;
                    Location_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


                api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Corporate Cust Code\"}}";
                response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    CorporatePrefix = controlNos[0].controlPrefix;
                    Corporate_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                 api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Source\"}}";
                 response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Source_Prefix = controlNos[0].controlPrefix;
                    Source_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                 api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Occupation CODE\"}}";
                 response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    OccupationType_Prefix = controlNos[0].controlPrefix;
                    OccupationType_ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


            }

        }

        protected void Get_AgeGroup()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Agegroups"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Agegroups"));
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

            List<AgeGroupUpdate> items = new List<AgeGroupUpdate>();
            items = JsonConvert.DeserializeObject<List<AgeGroupUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].ageCode;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 40 %");
                Col.InnerText = items[i].itmDesc;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerAgeGroupMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerAgeGroupMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerAgeGroupMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].itmId.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = AgeGrpPrefix ;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = AgeGrp_ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                tblAgeGroup.Rows.Add(_Row);

            }
        }

        protected void Get_Race()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Races"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Races"));
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

            List<RacesUpdate> items = new List<RacesUpdate>();
            items = JsonConvert.DeserializeObject<List<RacesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 30 %");
                Col.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerText = items[i].itmName;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerRaceMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerRaceMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerRaceMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].itmId.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = RacePrefix;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText =  Race_ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                tblRace.Rows.Add(_Row);

            }
        }

        protected void Get_CorporateCustomer()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Corporatecustomers"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Corporatecustomers"));

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


            List<CorporateCustomersUpdate> items = new List<CorporateCustomersUpdate>();
            items = JsonConvert.DeserializeObject<List<CorporateCustomersUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.InnerHtml = "<a href='CorporateCustomer.aspx?PKey=" + items[i].id + "&Code=" + items[i].code + "'><font color='#6a6000'><b>" + items[i].code + "</b></font></a>";
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.InnerText = items[i].name;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive)
                {
                    Col_3.InnerText = "Yes";  //"<input type='checkbox' checked class='chk_CustomerClass editor - active'>";
                }
                else
                {
                    Col_3.InnerText = "No";  //"<input type='checkbox' class='chk_CustomerClass editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblCorporateCustomer.Rows.Add(_Row);

            }

            //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        }

        protected void Get_SkinType()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/SkinTypes"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/SkinTypes"));
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

            List<SkinTypesUpdate> items = new List<SkinTypesUpdate>();
            items = JsonConvert.DeserializeObject<List<SkinTypesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 30 %");
                Col.InnerText = items[i].code;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerText = items[i].description;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isActive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerSkinTypeMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerSkinTypeMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerSkinTypeMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].id.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = SkinTypePrefix;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = SkinType_ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                tblSkinType.Rows.Add(_Row);

            }
        }

        protected void Get_Language()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Languages"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Languages"));
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

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 30 %");
                Col.InnerText = items[i].itmCode;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerText = items[i].itmDesc;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerLanguageMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerLanguageMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerLanguageMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].itmId.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = LangPrefix;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = Lang_ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                tblLanguage.Rows.Add(_Row);

            }
        }

        protected void Get_Locations()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Locations"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Locations"));
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

            List<LocationsUpdate> items = new List<LocationsUpdate>();
            items = JsonConvert.DeserializeObject<List<LocationsUpdate>>(jsonString);

            bool xNoRecords = false;
            if (items.Count == 0)
            {
                LocationsUpdate x = new LocationsUpdate();
                x.itmId = 0;
                x.locName = "";
                x.locIsactive = true;
                x.locCode = Location_ControlNo;
                items.Add(x);
                xNoRecords = true;
            }

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 30 %");
                Col.InnerText = items[i].locCode;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerText = items[i].locName;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].locIsactive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerLocationMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerLocationMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerLocationMaster glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].itmId.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText =  LocationPrefix ;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = Location_ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
                if (xNoRecords) _Row.Attributes.Add("style", "display:none");
                tblLocation.Rows.Add(_Row);

            }
        }

        protected void Get_Gender()
        {

            
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Genders"));
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

            List<GenderUpdate> items = new List<GenderUpdate>();
            items = JsonConvert.DeserializeObject<List<GenderUpdate>>(jsonString);

            //bool xNoRecords = false;
            //if (items.Count == 0)
            //{
            //    LocationsUpdate x = new LocationsUpdate();
            //    x.itmId = 0;
            //    x.locName = "";
            //    x.locIsactive = true;
            //    x.locCode = Location_ControlNo;
            //    items.Add(x);
            //    xNoRecords = true;
            //}

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].itmCode;  //1
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 40 %");
                Col.InnerText = items[i].itmName;   //2 
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 30 %; text-align:center");
                if (items[i].itmIsactive)      //3
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_CustomerGenderMaster editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_CustomerGenderMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_CustomerGenderMaster glyphicon glyphicon-pencil'></i></div>";  //4
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.InnerText = items[i].itmId.ToString();  //5
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);
               
                tblGender.Rows.Add(_Row);

            }
        }

        protected void Get_Sources()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Sources"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Sources"));
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

            List<SourcesUpdate> items = new List<SourcesUpdate>();
            items = JsonConvert.DeserializeObject<List<SourcesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %;");
                Col_1.InnerText = items[i].sourceCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %;");
                Col_2.InnerText = items[i].sourceDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].sourceIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_Source editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_Source editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_Source glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Source_Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = Source_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblSource.Rows.Add(_Row);

            }
        }

        protected void Get_OccupationTypes()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Occupationtypes"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Occupationtypes"));
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

            List<OccupationTypesUpdate> items = new List<OccupationTypesUpdate>();
            items = JsonConvert.DeserializeObject<List<OccupationTypesUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %;");
                Col_1.InnerText = items[i].occupationCode;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %;");
                Col_2.InnerText = items[i].occupationDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].occupationIsactive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_OccupationType editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_OccupationType editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_OccupationType glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].occupationId.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = OccupationType_Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                Col_4 = new HtmlTableCell();
                Col_4.InnerText = OccupationType_ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                //Col_4.Visible = false;
                tblOccupationType.Rows.Add(_Row);

            }

            //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["AlertMessage"] != null)
                {
                    oCommonEngine.SetAlert(this.Page, Session["AlertMessage"].ToString(), Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                    Session["AlertMessage"] = null;
                }

                Get_ControlNo_Prefixs();
                Get_AgeGroup();
                Get_Race();
                Get_SkinType();
                Get_CorporateCustomer();
                Get_Sources();
                Get_OccupationTypes();

                if (Request.QueryString["PKey"] != null)
                {
                    CollapsiblePanelCorporateCustomer.Collapsed = false;
                    CollapsiblePanelRace.Collapsed = false;
                    CollapsiblePanelAgeGroup.Collapsed = false;
                    CollapsiblePanelCorporateCustomer.Collapsed = false;
                    CollapsiblePanelSkinType.Collapsed = false;
                    CollapsiblePanelLanguage.Collapsed = false;
                }

                Get_Language();
                Get_Locations();
                Get_Gender();


            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }



        }
    }
}