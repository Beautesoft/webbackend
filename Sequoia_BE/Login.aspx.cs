using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace Sequoia_BE
{
    public partial class Login : System.Web.UI.Page
    {

        private CommonEngine oCommonEngine = new CommonEngine();
        public static string strAPIURL = "";
        private DataTable oDT_General = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            strAPIURL = System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"].ToString();
            if (!IsPostBack)
            {
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                //DataView oDV = new DataView(oDT_General);
                //oDV.RowFilter = "itemsiteIsactive='True'";
                //oDT_General = oDV.ToTable();
                //ddlSite_Login.Items.Add(new ListItem("Select your Outlet", ""));
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddlSite_Login.Items.Add(new ListItem(oDr["itemsiteDesc"].ToString().Trim(), oDr["itemsiteCode"].ToString().Trim()));
                //}


            }
        }

        //protected void Login_Click(object sender, EventArgs e)
        //{

        //    Session["User_UserCode"] = "U1";
        //    Session["User_SiteCode"] = "S1";

        //    //Response.Redirect("~/SiteAddressMaster.aspx");
        //    Response.Redirect("~/Dashboard.aspx");

        //    //using (var client = new HttpClient())
        //    //{
        //    //    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    //    var post = client.PostAsJsonAsync<LoginData>("api/Users/login", new LoginData { email =  txtUserName.Value.ToString().Trim() , password= txtPassword.Text.ToString()});
        //    //    post.Wait();
        //    //    var response = post.Result;
        //    //    System.Net.ServicePointManager.Expect100Continue = false;
        //    //    if (response.IsSuccessStatusCode)
        //    //    {

        //    //        //Session["User_UserCode"] = oDT_General.Rows[0]["UserCode"].ToString();
        //    //        //Session["User_UserName"] = oDT_General.Rows[0]["UserName"].ToString();
        //    //        //Session["User_UserType"] = oDT_General.Rows[0]["UserType"].ToString();
        //    //        //Session["User_SiteCode"] = oDT_General.Rows[0]["SiteCode"].ToString();
        //    //        //Session["User_Portal"] = "User";
        //    //        //Session["User_FilePathForPush"] = oDT_General.Rows[0]["PushPath"].ToString();
        //    //        //Session["User_ServerUserName"] = oDT_General.Rows[0]["ServerUserName"].ToString();
        //    //        //Session["User_ServerUserPassword"] = oDT_General.Rows[0]["ServerUserPassword"].ToString();
        //    //        //Session["AttachmentPath"] = oDT_General.Rows[0]["AttachmentPath"].ToString();
        //    //        //strUserCode = (string)Session["User_UserCode"];
        //    //        //strSiteCode = (string)Session["User_SiteCode"];
        //    //        //oDT_General = oCommonEngine.ExecuteDataTable("Select TOP 1 Convert(Varchar(50),AccessDate,100) from AccessLog Where IDType='User' And ID='" + strUserCode.Trim() + "' Order By AccessDate DESC");
        //    //        //if (oDT_General.Rows.Count == 1)
        //    //        //{
        //    //        //    Session["User_UserLastLogin"] = oDT_General.Rows[0][0].ToString();
        //    //        //}
        //    //        //else
        //    //        //{
        //    //        //    Session["User_UserLastLogin"] = "No Log Info...!";
        //    //        //}
        //    //        //oCommonEngine.AccessLog(strUserCode, "User", "LogIn");
        //    //        Response.Redirect("~/SiteAddressMaster.aspx");

        //    //    }
        //    //    else
        //    //    {
        //    //        Session["User_UserCode"] = "U1";
        //    //        Session["User_SiteCode"] = "S1";
        //    //        Response.Redirect("~/SiteAddressMaster.aspx");
        //    //        //lblFailed.Visible = true;
        //    //        //lblFailed.InnerText = "Login Failed...email and password mismatch.";

        //    //    }

        //    //}


        //}


        //protected void Login_Click(object sender, EventArgs e)
        //{
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strAPIURL + "/api/webBI_Login");
        //    req.ContentType = "application/json;";
        //    req.Method = "POST";
        //    string postData = "{\"userName\":\"" + txtUserName.Value.Trim() + "\"," +
        //          "\"password\":\"" + txtPassword.Text.Trim() + "\"}";
        //    var data = Encoding.ASCII.GetBytes(postData);
        //    req.Method = "POST";
        //    req.ContentType = "application/json";
        //    req.ContentLength = data.Length;
        //    using (var stream = req.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    WebResponse response = req.GetResponse();
        //    Stream responseStream = response.GetResponseStream();
        //    StreamReader sr = new StreamReader(responseStream);
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
        //    if (MyDynamic["success"] == "1")
        //    {
        //        if (chkRememberMe.Checked == true)
        //        {
        //            Response.Cookies["bck_webBIUser"].Value = txtUserName.Value.ToString().Trim();
        //            Response.Cookies["bck_webBIPwd"].Value = txtPassword.Text.ToString().Trim();
        //            Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddYears(20);
        //            Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddYears(20);
        //        }
        //        else
        //        {
        //            Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddDays(-1);
        //            Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddDays(-1);
        //        }
        //        Session["User_UserCode"] = txtUserName.Value.Trim();
        //        Session["User_SiteCode"] = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString();

        //        Response.Redirect("~/DashBoard.aspx");
        //    }

        //}

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

        protected void Login_Click(object sender, EventArgs e)
        {
            //if (ddlSite_Login.Value != "")
            //{
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strAPIURL + "/api/webBI_Login");
                req.ContentType = "application/json;";
                req.Method = "POST";
                string postData = "{\"userName\":\"" + txtUserName.Value.Trim() + "\"," +
                      "\"password\":\"" + txtPassword.Text.Trim() + "\"}";
                var data = Encoding.ASCII.GetBytes(postData);
                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = data.Length;
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = req.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
                if (MyDynamic["success"] == "1")
                {
                    if (chkRememberMe.Checked == true)
                    {
                        Response.Cookies["bck_webBIUser"].Value = txtUserName.Value.ToString().Trim();
                        Response.Cookies["bck_webBIPwd"].Value = txtPassword.Text.ToString().Trim();
                        Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddYears(20);
                        Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddYears(20);
                    }
                    else
                    {
                        Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["User_UserName"] = txtUserName.Value.Trim();
                    Session["strUserName"] = txtUserName.Value.Trim();
                    Session["isSettingEnabled"] = MyDynamic["isSettingEnabled"];
                    Session["User_UserCode"] = txtUserName.Value.Trim();
                    Session["User_SiteCode"] = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(); //ddlSite_Login.Value.Trim();
                    Session["User_UserType"] = "";

                    dynamic MyDynamic_Result = MyDynamic["reportAuthInfo"];
                    JavaScriptSerializer js_result = new JavaScriptSerializer();
                    js_result.MaxJsonLength = Int32.MaxValue;
                    js_result.RecursionLimit = 100;
                    var json = js_result.Serialize(MyDynamic_Result);
                    //DashBoard._oDT_InventoryAuth = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                    Session["User_UserName"] = txtUserName.Value.Trim();
                    Response.Redirect("~/DashBoard.aspx");
                }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Name and Password does not match')", true);
            }
            //else if (MyDynamic["success"] == "2")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Name and Password does not match')", true);
            //    //ddlSite_Login.Value = ddlSite_Login.Value;
            //}
            //else if (MyDynamic["success"] == "3")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Outlet Aecess Denied')", true);
            //    txtPassword.Text = txtPassword.Text;
            //}
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the Outlet')", true);
            //}

        }

    }
}