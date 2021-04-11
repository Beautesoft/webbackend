using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class BusinessHours : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string _Prefix = string.Empty, _ControlNo = string.Empty, _PKey = string.Empty;

        #region Methods


        protected void Get_BusinessHours()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Businesshrs"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Businesshrs"));
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

            List<BusinessHoursMaster> items = new List<BusinessHoursMaster>();
            items = JsonConvert.DeserializeObject<List<BusinessHoursMaster>>(jsonString);

            for (int i = 1; i < tbl_BusinessHoursList.Rows.Count; i++)
            {
                tbl_BusinessHoursList.Rows.RemoveAt(1);
            }

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerHtml = "<a href='BusinessHours.aspx?PKey=" + items[i].businessday + "'><font color='#6a6000'><b>" + items[i].businessday.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = items[i].status;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = Convert.ToDateTime(items[i].starttime.Substring(11, 5)).ToString("hh:mm tt");
                //DateString = L.Date.Date.ToString("dd-MMM-yyyy"),
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 35 %");
                Col.InnerText = Convert.ToDateTime(items[i].endtime.Substring(11, 5)).ToString("hh:mm tt"); 
                _Row.Controls.Add(Col);


                tbl_BusinessHoursList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txt_BusinessDay.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txt_Status.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Business Hours ...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
              

                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                return _RetVal;
            }
        }

        private void DataClear()
        {
            btn_AddBusinessHours.InnerText = "Add";
            txt_BusinessDay.Value = string.Empty;
            txt_Status.Value = string.Empty;
            txt_StartTime.Value = string.Empty;
            txt_EndTime.Value = string.Empty;
            txt_SiteCode.Value = string.Empty;
            //chkBusinessHoursActive_BusinessHours.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/Businesshrs?filter={\"where\":{\"businessday\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<BusinessHoursMasterUpdate> BusinessHoursMasters = JsonConvert.DeserializeObject<List<BusinessHoursMasterUpdate>>(a);

                    if (BusinessHoursMasters.Count > 0)
                    {
                        Session["id"] = BusinessHoursMasters[0].id;
                        txt_BusinessDay.Value = BusinessHoursMasters[0].businessday;
                        txt_Status.Value = BusinessHoursMasters[0].status;
                        txt_StartTime.Value = Convert.ToDateTime(BusinessHoursMasters[0].starttime.ToString().Substring(11, 5)).ToString("hh:mm tt");
                        txt_EndTime.Value = Convert.ToDateTime(BusinessHoursMasters[0].endtime.ToString().Substring(11, 5)).ToString("hh:mm tt");  
                        txt_SiteCode.Value = BusinessHoursMasters[0].sitecode;
                       // chkBusiness HoursActive_Business Hours.Checked = BusinessHoursMasters[0].isactive;
                    }

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

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
                    DataClear();
                 //   Get_ControlPrefixs();
                    

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddBusinessHours.InnerText = "Update";
                        CollapsiblePanelBusinessHoursCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddBusinessHours.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                Get_BusinessHours();

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }


        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {

                    if (btn_AddBusinessHours.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            BusinessHoursMaster p = new BusinessHoursMaster
                            {

                                businessday = txt_BusinessDay.Value.ToString().Trim(),
                                status = txt_Status.Value.ToString().Trim(),
                                //starttime = txt_StartTime.Value.ToString().Trim(),
                                starttime = Convert.ToDateTime(txt_StartTime.Value.ToString().Trim()).ToString("yyyy-MM-ddTHH:mm:00.000Z"),
                               // endtime = txt_EndTime.Value.ToString().Trim(),
                                endtime = Convert.ToDateTime(txt_EndTime.Value.ToString().Trim()).ToString("yyyy-MM-ddTHH:mm:00.000Z"),
                                sitecode = txt_SiteCode.Value.ToString().Trim(),
                                //isactive = chkBusiness HoursActive_Business Hours.Checked,
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<BusinessHoursMaster>("api/Businesshrs", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Business hours Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                //  Response.Redirect("ConfigInterface_PaymentType.aspx");
                             //   Get_BusinessHours();
                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            BusinessHoursMasterUpdate p = new BusinessHoursMasterUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                businessday = txt_BusinessDay.Value.ToString().Trim(),
                                status = txt_Status.Value.ToString().Trim(),
                                starttime = Convert.ToDateTime(txt_StartTime.Value.ToString().Trim()).ToString("yyyy-MM-ddTHH:mm:00.000Z"),
                                endtime = Convert.ToDateTime(txt_EndTime.Value.ToString().Trim()).ToString("yyyy-MM-ddTHH:mm:00.000Z"),
                                sitecode = txt_SiteCode.Value.ToString().Trim(),
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<BusinessHoursMasterUpdate>("api/Businesshrs", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                oCommonEngine.SetAlert(this.Page, "Business hours Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }

                        }
                    }

                    DataClear();
                    Get_BusinessHours();

                }


            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }



        }

        #endregion
    }
}