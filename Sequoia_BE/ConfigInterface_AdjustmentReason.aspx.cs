using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class ConfigInterface_AdjustmentReason : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();
        string _Prefix = string.Empty, _ControlNo = string.Empty, _PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Reverse Reason\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    _ControlNo = controlNos[0].controlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        protected void Get_AdjstmentReasons()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ReverseTrmtReasons"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ReverseTrmtReasons"));
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

            List<AdjustmentReasonUpdate> items = new List<AdjustmentReasonUpdate>();
            items = JsonConvert.DeserializeObject<List<AdjustmentReasonUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 30 %;");
                Col_1.InnerText = items[i].revNo;
                _Row.Controls.Add(Col_1);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 50 %;");
                Col_2.InnerText = items[i].revDesc;
                _Row.Controls.Add(Col_2);
                HtmlTableCell Col_3 = new HtmlTableCell();
                Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isActive)
                {
                    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_AdjustmentReason editor - active'>";
                }
                else
                {
                    Col_3.InnerHtml = "<input type='checkbox' class='chk_AdjustmentReason editor - active'>";
                }
                _Row.Controls.Add(Col_3);
                HtmlTableCell Col_Action = new HtmlTableCell();
                Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                Col_Action.InnerHtml = "<div class='tools'><i class='edit_AdjustmentReason glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col_Action);
                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.InnerText = items[i].id.ToString();
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                 Col_4 = new HtmlTableCell();
                Col_4.InnerText = _Prefix;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                 Col_4 = new HtmlTableCell();
                Col_4.InnerText = _ControlNo;
                Col_4.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col_4);
                tblAdjustmentReasons.Rows.Add(_Row);

            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Get_ControlPrefixs();
                if (!IsPostBack)
                {

                };

                Get_AdjstmentReasons();

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }
    }
}