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
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        private CommonEngine oCommonEngine = new CommonEngine();
        string _Prefix = string.Empty, _ControlNo = string.Empty, _PKey = string.Empty;

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"EmpLevel Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    _ControlNo = controlNos[0].controlNo;
                    txt_EmpLevelCode.Value = _Prefix + _ControlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }



        }

        protected void Get_EmpLevels()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/EmpLevels"));
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
            List<EmployeeLevelUpdate> items = new List<EmployeeLevelUpdate>();
            items = JsonConvert.DeserializeObject<List<EmployeeLevelUpdate>>(jsonString);
            for (int i = 0; i < items.Count; i++)
            {
                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1 = new HtmlTableCell();
                Col_1.Attributes.Add("style", "width: 10 %;");
                Col_1.InnerHtml = "<a href='EmployeeMaster.aspx?PKey=" + items[i].levelCode + "'><font color='#6a6000'><b>" + items[i].levelCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col_1);

                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 20 %;");
                Col_2.InnerText = items[i].levelDesc;
                _Row.Controls.Add(Col_2);

                HtmlTableCell Col_4 = new HtmlTableCell();
                Col_4.Attributes.Add("style", "width: 10 %;");
                Col_4.InnerText = items[i].levelSequence;
                _Row.Controls.Add(Col_4);

                HtmlTableCell Col_5 = new HtmlTableCell();
                Col_5.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].levelIsActive == false)
                {
                    Col_5.InnerHtml = "<label> No </label>";
                }
                else
                {

                    Col_5.InnerHtml = "<label> Yes </label>";
                }
                _Row.Controls.Add(Col_5);

                tblEmployeeLevel.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txt_EmpLevelCode.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txt_EmpLevelDesc.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Employee Level Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                //if (txt_EmpLevelSequence.Value.ToString().Trim().Replace("'", "") == "")
                //{
                //    oCommonEngine.SetAlert(this.Page, "Please enter Sequence...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                //    return _RetVal;
                //}

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

            _PKey = String.Empty;
            btn_AddEmployeeLevel.InnerText = "Add";
            txt_EmpLevelDesc.Value = string.Empty;
            txt_EmpLevelSequence.Value = string.Empty;
            chkActive.Checked = true;
            chkAllowAllSpa.Checked = true;

        }

        private void FetchRecords()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/EmpLevels?filter={\"where\":{\"levelCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<EmployeeLevelUpdate> employeeLevelList = JsonConvert.DeserializeObject<List<EmployeeLevelUpdate>>(a);

                    if (employeeLevelList.Count > 0)
                    {
                        Session["id"] = employeeLevelList[0].id;
                        txt_EmpLevelCode.Value = employeeLevelList[0].levelCode;
                        txt_EmpLevelDesc.Value = employeeLevelList[0].levelDesc;
                        txt_EmpLevelSequence.Value = employeeLevelList[0].levelSequence;
                        if (employeeLevelList[0].levelSpa == true)
                        {
                            chkAllowAllSpa.Checked = true;
                        }
                        else
                        {
                            chkAllowAllSpa.Checked = false;
                        }

                        if (employeeLevelList[0].levelIsActive == true)
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
                        }

                    }

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

                if (!IsPostBack)
                {
                    DataClear();
                    Get_ControlPrefixs();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddEmployeeLevel.InnerText = "Update";
                        CollapsiblepanelEmpLevelCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddEmployeeLevel.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                Get_EmpLevels();


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

                    if (btn_AddEmployeeLevel.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            EmployeeLevelInsert p = new EmployeeLevelInsert
                            {

                                levelCode = txt_EmpLevelCode.Value.ToString().Trim(),
                                levelDesc = txt_EmpLevelDesc.Value.ToString().Trim(),
                                levelSequence = txt_EmpLevelSequence.Value.ToString().Trim(),
                                levelSpa = chkAllowAllSpa.Checked,
                                levelIsActive = chkActive.Checked,
                                getGroupComm = false,
                                minTarget = "0",
                                fromSalary= "0",
                                toSalary = "0"
                                
                            };
                            
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<EmployeeLevelInsert>("api/EmpLevels", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                var a = response.Content.ReadAsStringAsync().Result;
                                CustomerClassUpdate customerClassesUpdates = JsonConvert.DeserializeObject<CustomerClassUpdate>(a);
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "EmpLevel Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(txt_EmpLevelCode.Value.ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txt_EmpLevelCode.Value = Convert.ToString((Int64.Parse(txt_EmpLevelCode.Value.ToString()) + 1));
                                }
                                oCommonEngine.SetAlert(this.Page, "Employee Level Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            EmployeeLevelUpdate p = new EmployeeLevelUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                levelCode = txt_EmpLevelCode.Value.ToString().Trim(),
                                levelDesc = txt_EmpLevelDesc.Value.ToString().Trim(),
                                levelSequence = txt_EmpLevelSequence.Value.ToString().Trim(),
                                levelSpa = chkAllowAllSpa.Checked,
                                levelIsActive = chkActive.Checked,
                                getGroupComm = false,
                                minTarget = "0",
                                fromSalary = "0",
                                toSalary = "0"
                            };

                           
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<EmployeeLevelUpdate>("api/EmpLevels", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Employee Level Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);

                            Get_ControlPrefixs();

                        }
                    }

                    DataClear();
                    Get_EmpLevels();

                }


            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }



        }

    }
}