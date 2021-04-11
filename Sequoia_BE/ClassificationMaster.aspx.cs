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
    public partial class ClassificationMaster : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";      
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_CommonMaster = new DataTable();

        public class itemClassInput
        {
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public bool itmIsactive { get; set; }
            public string itmSeq { get; set; }
        }

        public class itemClassUpdateInput
        {
            public string itmDesc { get; set; }
            public bool itmIsactive { get; set; }
        }


        #endregion

        #region Functions

        #region LoadValue
        #endregion
        #region Load Page Informations
        private void LoadPageInformations()
        {
            try
            {

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemClasses"), (typeof(DataTable)));
                //if (oDT_General.Rows.Count > 0 && ClassificationMasterPage.Rows.Count == 1)
                //{
                //    for (int i = 0; i < oDT_General.Rows.Count; i++)
                //    {
                //        HtmlTableRow _Row = new HtmlTableRow();
                //        HtmlTableCell Col_1 = new HtmlTableCell();
                //        Col_1.InnerText = oDT_General.Rows[i]["itmCode"].ToString();

                //        _Row.Controls.Add(Col_1);
                //        HtmlTableCell Col_2 = new HtmlTableCell();
                //        Col_2.InnerText = oDT_General.Rows[i]["itmDesc"].ToString();
                //        _Row.Controls.Add(Col_2);
                //        HtmlTableCell Col_3 = new HtmlTableCell();
                //        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                //        if (oDT_General.Rows[i]["itmIsactive"].ToString() == "True")
                //        {
                //            Col_3.InnerHtml = "<input type='checkbox' checked class='chk_mdlClassificationMaster editor - active' >";
                //        }
                //        else
                //        {
                //            Col_3.InnerHtml = "<input  type='checkbox' class='chk_mdlClassificationMaster editor - active' >";
                //        }
                //        _Row.Controls.Add(Col_3);
                //        HtmlTableCell Col_Action = new HtmlTableCell();
                //        Col_Action.Attributes.Add("style", "width: 10 %; text-align:center");
                //        Col_Action.InnerHtml = "<div class='tools'><i class='edit_mdlClassificationMaster glyphicon glyphicon-pencil'></i></div>";
                //        _Row.Controls.Add(Col_Action);
                //        ClassificationMasterPage.Rows.Add(_Row);
                //    }
                //}

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

        [WebMethod]
        public static void ClassMasterCall( string Code, string Name, bool InActive, string siteCode)
        {
            using (var client = new HttpClient())
            {
                itemClassInput p = new itemClassInput { itmCode = Code, itmDesc = Name, itmIsactive = InActive, itmSeq = Code};
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<itemClassInput>("api/ItemClasses", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    int Newcontrol = int.Parse(Code);
                    int NewcontrolNo = Newcontrol + 1;
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "CLASS CODE", sitecode = siteCode, controlnumber = Convert.ToString(NewcontrolNo) };
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
        public static void UpdateClassMasterCall(string Code, string Name, bool InActive)
        {
            using (var client = new HttpClient())
            {
                itemClassUpdateInput p = new itemClassUpdateInput { itmDesc = Name, itmIsactive = InActive};
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<itemClassUpdateInput>("api/ItemClasses/update?[where][itmCode]=" + Code + "", p);
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
                    
                }
                //LoadPageInformations();

            }
            catch (Exception Ex)
            {
            }
        }

        #endregion
    }
}