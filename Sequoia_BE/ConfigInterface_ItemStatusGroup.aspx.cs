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
    public partial class ConfigInterface_ItemStatusGroup : System.Web.UI.Page
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
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Item Status Group\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    Session["Prefix"] = _Prefix;
                    _ControlNo = controlNos[0].controlNo;
                    Session["ControlNo"] = _ControlNo;
                    txt_StausCode.Value = _Prefix + _ControlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        protected void Get_ItemStatusGroups()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemStatusGroups"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemStatusGroups"));
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

            List<ItemStatusGroupsUpdate> items = new List<ItemStatusGroupsUpdate>();
            items = JsonConvert.DeserializeObject<List<ItemStatusGroupsUpdate>>(jsonString);

            while (tbl_ItemStatusGroupsList.Rows.Count > 1) tbl_ItemStatusGroupsList.Rows.RemoveAt(1);

            for (int i = 0; i < items.Count; i++)
            {


                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col_1a = new HtmlTableCell();
                Col_1a.Attributes.Add("style", "width: 20 %;");
               // Col_1a.InnerText = items[i].statusGroupCode;
                Col_1a.InnerHtml = "<a href='ConfigInterface_ItemStatusGroup.aspx?PKey=" + items[i].statusGroupCode + "'><font color='#6a6000'><b>" + items[i].statusGroupCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col_1a);
                HtmlTableCell Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 25 %;");
                Col_2.InnerText = items[i].statusGroupDesc;
                _Row.Controls.Add(Col_2);
                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 25 %;");
                Col_2.InnerText = items[i].statusGroupShortDesc;
                _Row.Controls.Add(Col_2);

                Col_2 = new HtmlTableCell();
                Col_2.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive == false)
                {
                    Col_2.InnerHtml = "<label> No </label>";
                }
                else
                {

                    Col_2.InnerHtml = "<label> Yes </label>";
                }
                _Row.Controls.Add(Col_2);

                //HtmlTableCell Col_3 = new HtmlTableCell();
                //Col_3.Attributes.Add("style", "width: 20 %; text-align:center");
                //if (items[i].isactive)
                //{
                //    Col_3.InnerHtml = "<input type='checkbox' checked class='chk_ItemStatusGroup editor - active'>";
                //}
                //else
                //{
                //    Col_3.InnerHtml = "<input type='checkbox' class='chk_ItemStatusGroup editor - active'>";
                //}
                //_Row.Controls.Add(Col_3);

                tbl_ItemStatusGroupsList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txt_Desc.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Description ...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
            btn_AddItemStatusGroups.InnerText = "Add";
            txt_Desc.Value = string.Empty;
            txt_ShortDesc.Value = string.Empty;
            chkActive.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/ItemStatusGroups?filter={\"where\":{\"statusGroupCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ItemStatusGroupsUpdate> ItemStatusGroups = JsonConvert.DeserializeObject<List<ItemStatusGroupsUpdate>>(a);

                    if (ItemStatusGroups.Count > 0)
                    {
                        Session["id"] = ItemStatusGroups[0].id;
                        txt_StausCode.Value = ItemStatusGroups[0].statusGroupCode;
                        txt_Desc.Value = ItemStatusGroups[0].statusGroupDesc;
                        txt_ShortDesc.Value = ItemStatusGroups[0].statusGroupShortDesc;                        
                        chkActive.Checked = ItemStatusGroups[0].isactive;
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

                    Get_ControlPrefixs();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddItemStatusGroups.InnerText = "Update";
                        CollapsiblePanelItemStatusGroupsCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddItemStatusGroups.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                Get_ItemStatusGroups();

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

                    if (btn_AddItemStatusGroups.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            ItemStatusGroups p = new ItemStatusGroups
                            {

                                statusGroupCode = txt_StausCode.Value.ToString().Trim(),
                                statusGroupDesc = txt_Desc.Value.ToString().Trim(),
                                statusGroupShortDesc = txt_ShortDesc.Value.ToString().Trim(),
                                isactive = chkActive.Checked,
                            };


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<ItemStatusGroups>("api/ItemStatusGroups", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Item Status Group", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(Session["ControlNo"].ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txt_StausCode.Value = Session["Prefix"].ToString() + Convert.ToString((Int64.Parse(Session["ControlNo"].ToString()) + 1));
                                }

                                oCommonEngine.SetAlert(this.Page, "Item Status Groups Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);

                                CollapsiblePanelItemStatusGroupsList.Collapsed = false;
                                Get_ControlPrefixs();

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
                            ItemStatusGroupsUpdate p = new ItemStatusGroupsUpdate
                            {
                                id = int.Parse(Session["id"].ToString()),
                                statusGroupCode = txt_StausCode.Value.ToString().Trim(),
                                statusGroupDesc = txt_Desc.Value.ToString().Trim(),
                                statusGroupShortDesc = txt_ShortDesc.Value.ToString().Trim(),
                                isactive = chkActive.Checked,
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<ItemStatusGroupsUpdate>("api/ItemStatusGroups", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {

                                oCommonEngine.SetAlert(this.Page, "Item Status Groups Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);

                            }
                            else
                            {
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                            }

                        }

                        Get_ControlPrefixs();
                    }

                    DataClear();
                    Get_ItemStatusGroups();

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