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
    public partial class ConfigInterface_ItemStatus : System.Web.UI.Page
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
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Item Status Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    Session["Prefix"] = _Prefix;
                    _ControlNo = controlNos[0].controlNo;
                    Session["ControlNo"] = _ControlNo;
                    txtCode_ItemStatus.Value = _Prefix + _ControlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            //Bind Site Code
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ItemStatusGroups?filter={\"where\":{\"isactive\":\"true\"}}";
                var response = client1.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ItemStatusGroups> itemSiteLists = JsonConvert.DeserializeObject<List<ItemStatusGroups>>(a);
                    ddlGroup_ItemStatus.DataSource = itemSiteLists;
                    ddlGroup_ItemStatus.DataValueField = "statusGroupCode";
                    ddlGroup_ItemStatus.DataTextField = "statusGroupDesc";
                    ddlGroup_ItemStatus.DataBind();
                }
            }


        }

        protected void Get_ItemStatus()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemStatuses"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemStatuses"));
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

            List<ItemStatusUpdate> items = new List<ItemStatusUpdate>();
            items = JsonConvert.DeserializeObject<List<ItemStatusUpdate>>(jsonString);

            while (tblItemStatusList.Rows.Count > 1) tblItemStatusList.Rows.RemoveAt(1);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerHtml = "<a href='ConfigInterface_ItemStatus.aspx?PKey=" + items[i].itmId + "'><font color='#6a6000'><b>" + items[i].statusCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 25 %");
                Col.InnerText = items[i].statusDesc;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 25 %");
                Col.InnerText = items[i].statusShortDesc;
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].statusGroupCode;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].itmIsactive == false)
                {
                    Col.InnerHtml = "<label> No </label>";
                }
                else
                {

                    Col.InnerHtml = "<label> Yes </label>";
                }
                _Row.Controls.Add(Col);


                //Col = new HtmlTableCell();
                //Col.Attributes.Add("style", "width: 10 %; text-align:center");
                //if (items[i].itmIsactive)
                //{
                //    Col.InnerHtml = "<input type='checkbox' checked class='chk_ItemStatus editor - active'>";
                //}
                //else
                //{
                //    Col.InnerHtml = "<input type='checkbox' class='chk_ItemStatus editor - active'>";
                //}
                //_Row.Controls.Add(Col);

                tblItemStatusList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txtCode_ItemStatus.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txteDesc_ItemStatus.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (txtShortDesc_ItemStatus.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Short Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
            btn_AddItemStatus.InnerText = "Add";
            txteDesc_ItemStatus.Value = string.Empty;
            txtShortDesc_ItemStatus.Value = string.Empty;
            chkStatusActive_ItemStatus.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/ItemStatuses/" + _PKey;
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    ItemStatusUpdate itemStatusUpdates = JsonConvert.DeserializeObject<ItemStatusUpdate>(a);

                        txtCode_ItemStatus.Value = itemStatusUpdates.statusCode;
                        ddlGroup_ItemStatus.Value = itemStatusUpdates.statusGroupCode;
                        txteDesc_ItemStatus.Value = itemStatusUpdates.statusDesc;
                        txtShortDesc_ItemStatus.Value = itemStatusUpdates.statusShortDesc;
                        chkStatusActive_ItemStatus.Checked = itemStatusUpdates.itmIsactive;

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

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                if (!IsPostBack)
                {

                    Get_ControlPrefixs();

                    DataClear();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddItemStatus.InnerText = "Update";
                         CollapsiblePanelItemStatusCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddItemStatus.InnerText = "Add";
                        _PKey = string.Empty;

                    }

                    Get_ItemStatus();

                };


                

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

                    if (btn_AddItemStatus.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            ItemStatus p = new ItemStatus
                            {

                                statusCode = txtCode_ItemStatus.Value.ToString().Trim(),
                                statusDesc = txteDesc_ItemStatus.Value.ToString().Trim(),
                                statusShortDesc = txtShortDesc_ItemStatus.Value.ToString().Trim(),
                                statusGroupCode = ddlGroup_ItemStatus.Value.ToString().Trim(),
                                itmIsactive = chkStatusActive_ItemStatus.Checked

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<ItemStatus>("api/ItemStatuses", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Item Status Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(Session["ControlNo"].ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txtCode_ItemStatus.Value = Session["Prefix"].ToString() + Convert.ToString((Int64.Parse(Session["ControlNo"].ToString()) + 1));
                                }
                                oCommonEngine.SetAlert(this.Page, "Item Status Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                            oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            ItemStatusUpdate p = new ItemStatusUpdate
                            {
                                itmId =  Int32.Parse(_PKey),
                                statusCode = txtCode_ItemStatus.Value.ToString().Trim(),
                                statusDesc = txteDesc_ItemStatus.Value.ToString().Trim(),
                                statusShortDesc = txtShortDesc_ItemStatus.Value.ToString().Trim(),
                                statusGroupCode = ddlGroup_ItemStatus.Value.ToString().Trim(),
                                itmIsactive = chkStatusActive_ItemStatus.Checked
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<ItemStatusUpdate>("api/ItemStatuses", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Item Status Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);

                            CollapsiblePanelItemStatusList.Collapsed = false;
                            Get_ControlPrefixs();

                        }

                        Get_ControlPrefixs();
                    }

                    DataClear();
                    Get_ItemStatus();

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