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
    public partial class SecurityMaster : System.Web.UI.Page
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
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"SECURITY_LEVEL\"}}";
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

        protected void Get_SecurityLevels()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Securities"));
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

            List<SecurityUpdate> items = new List<SecurityUpdate>();
            items = JsonConvert.DeserializeObject<List<SecurityUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 15 %;");
                Col.InnerText = items[i].levelCode;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 25 %;");
                Col.InnerText = items[i].levelName;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 40 %;");
                Col.InnerText = items[i].levelDescription;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].levelIsActive)
                {
                    Col.InnerHtml = "<input type='checkbox' checked class='chk_SecurityLevel editor - active'>";
                }
                else
                {
                    Col.InnerHtml = "<input type='checkbox' class='chk_SecurityLevel editor - active'>";
                }
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                Col.InnerHtml = "<div class='tools'><i class='edit_SecurityLevel glyphicon glyphicon-pencil'></i></div>";
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.InnerText = items[i].levelItemId.ToString();
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.InnerText = _Prefix;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.InnerText = _ControlNo;
                Col.Attributes.Add("style", "width: 0px; display:none");
                _Row.Controls.Add(Col);

                tblSecurityLevel.Rows.Add(_Row);

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

                Get_SecurityLevels();

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }

    }
}