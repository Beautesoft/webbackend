using Newtonsoft.Json;
using System;
using System.Text;
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
    public partial class RoomMaster : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private DataTable oDT_General = new DataTable();
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
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Room Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    _Prefix = controlNos[0].controlPrefix;
                    _ControlNo = controlNos[0].controlNo;
                    txtCode_Room.Value = _Prefix + _ControlNo;

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
                string api = "api/ItemSiteLists?filter={\"where\":{\"itemsiteIsactive\":\"true\"}}";
                var response = client1.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ItemSiteLists> itemSiteLists = JsonConvert.DeserializeObject<List<ItemSiteLists>>(a);
                    ddlSiteCode_Room.DataSource = itemSiteLists;
                    ddlSiteCode_Room.DataValueField = "itemsiteCode";
                    ddlSiteCode_Room.DataTextField = "itemsiteCode";
                    ddlSiteCode_Room.DataBind();
                }
            }


        }

        protected void Get_Rooms()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Rooms"));
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

            List<RoomsList> items = new List<RoomsList>();
            items = JsonConvert.DeserializeObject<List<RoomsList>>(jsonString);

            while (tblSiteList.Rows.Count > 1) tblSiteList.Rows.RemoveAt(1);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 15 %");
                Col.InnerHtml = "<a href='ConfigInterface_RoomMaster.aspx?PKey=" + items[i].roomCode + "'><font color='#6a6000'><b>" + items[i].roomCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %");
                Col.InnerText = items[i].siteCode;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].displayname;
                _Row.Controls.Add(Col);


                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 20 %");
                Col.InnerText = items[i].description;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 15 %");
                Col.InnerText = items[i].equipment;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %");
                Col.InnerText = items[i].roomtype;
                _Row.Controls.Add(Col);

                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 10 %; text-align:center");
                if (items[i].isactive)
                {
                    Col.InnerText = "Yes"; //"<input type='checkbox' checked class='chk_RoomMaster editor - active'>";
                }
                else
                {
                    Col.InnerText = "No"; // "<input type='checkbox' class='chk_RoomMaster editor - active'>";
                }
                _Row.Controls.Add(Col);
                tblSiteList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txtCode_Room.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txteDesc_Room.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Room Description...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                //if (ddlEquipment.Value.ToString().Trim().Replace("'", "") == "")
                //{
                //    oCommonEngine.SetAlert(this.Page, "Please enter Room Equipment...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
            btn_AddRoom.InnerText = "Add";
            txteDesc_Room.Value = string.Empty;
            ddlEquipment.Value = string.Empty;
            txt_RoomNo.Value = string.Empty;
            chkRoomActive_Room.Checked = true;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/Rooms?filter={\"where\":{\"roomCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<RoomsList> roomsLists = JsonConvert.DeserializeObject<List<RoomsList>>(a);

                    if (roomsLists.Count > 0)
                    {

                        txtCode_Room.Value = roomsLists[0].roomCode;
                        ddlSiteCode_Room.Value = roomsLists[0].siteCode;
                        txt_RoomNo.Value = roomsLists[0].displayname;
                        txteDesc_Room.Value = roomsLists[0].description;
                        //ddlEquipment.Value = roomsLists[0].equipment;

                        if (roomsLists[0].equipment.ToString().Length > 0)
                        {
                            IList<string> _SiteList = roomsLists[0].equipment.Split('/').ToList<string>();
                            for (int i = 0; i < _SiteList.Count; i++)
                            {
                                if (_SiteList[i].ToString().Trim() != "")
                                {

                                    ListItem x = new ListItem(_SiteList[i].ToString().Trim());

                                    if(ddlEquipment.Items.Contains(x))
                                        ddlEquipment.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
                                       
                                }
                            }
                        }

                        if (roomsLists[0].roomtype == "Single")
                        {
                            rbtn_SingleRoom.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Double")
                        {
                            rbtn_Double.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Triple")
                        {
                            rbtn_TripleRoom.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Quad")
                        {
                            rbtn_QuadRoom.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Twin")
                        {
                            rbtn_Twin.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Family")
                        {
                            rbtn_Family.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "King")
                        {
                            rbtn_King.Checked = true;
                        }
                        else if (roomsLists[0].roomtype == "Queen")
                        {
                            rbtn_Queen.Checked = true;
                        }


                        chkRoomActive_Room.Checked = roomsLists[0].isactive;
                    }

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

        }

        private void LoadValue()
        {

            try
            {
                //Load City
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/Myequipments"), (typeof(DataTable)));
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Myequipments"), (typeof(DataTable)));
                DataView oDV = new DataView(oDT_General);
                // oDV.RowFilter = "itmIsactive = True";
                oDT_General = oDV.ToTable();
                //DataTable oDT_General = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
                ddlEquipment.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlEquipment.Items.Add(new ListItem(oDr["equipmentName"].ToString().Trim(), oDr["equipmentName"].ToString().Trim()));
                    //ddlCity.Items.Add(new ListItem(oDr.itmDesc, oDr.itmCode));
                }
            }
            catch (Exception Ex)
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
                    LoadValue();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddRoom.InnerText = "Update";
                        CollapsiblePanelRoomCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddRoom.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

                Get_Rooms();

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

                    if (btn_AddRoom.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            RoomsList p = new RoomsList
                            {

                                roomCode = txtCode_Room.Value.ToString().Trim(),
                                siteCode = ddlSiteCode_Room.Value.ToString().Trim(),
                                description = txteDesc_Room.Value.ToString().Trim(),
                                displayname = txt_RoomNo.Value.ToString().Trim(),
                                // equipment = ddlEquipment.Value.ToString().Trim(),
                                isactive = chkRoomActive_Room.Checked,



                            };
                            System.Collections.Generic.List<string> sc = new System.Collections.Generic.List<string>();
                            foreach (ListItem item in ddlEquipment.Items)
                            {
                                if (item.Selected)
                                    sc.Add(item.Text);
                            }


                            string csv = String.Join("/", sc.ToArray());

                            //  csv = ddlEquipment.Value.ToString().Trim();

                            p.equipment = csv;


                            if (rbtn_SingleRoom.Checked)
                            {
                                p.roomtype = rbtn_SingleRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_Double.Checked)
                            {
                                p.roomtype = rbtn_Double.Value.ToString().Trim();
                            }
                            else if (rbtn_TripleRoom.Checked)
                            {
                                p.roomtype = rbtn_TripleRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_QuadRoom.Checked)
                            {
                                p.roomtype = rbtn_QuadRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_Twin.Checked)
                            {
                                p.roomtype = rbtn_Twin.Value.ToString().Trim();
                            }
                            else if (rbtn_Family.Checked)
                            {
                                p.roomtype = rbtn_Family.Value.ToString().Trim();
                            }
                            else if (rbtn_King.Checked)
                            {
                                p.roomtype = rbtn_King.Value.ToString().Trim();
                            }
                            else if (rbtn_Queen.Checked)
                            {
                                p.roomtype = rbtn_Queen.Value.ToString().Trim();
                            }


                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<RoomsList>("api/Rooms", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                var a = response.Content.ReadAsStringAsync().Result;
                                CustomerClassUpdate customerClassesUpdates = JsonConvert.DeserializeObject<CustomerClassUpdate>(a);
                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Room Code", sitecode = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(txtCode_Room.Value.ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    txtCode_Room.Value = Convert.ToString((Int64.Parse(txtCode_Room.Value.ToString()) + 1));
                                }
                                oCommonEngine.SetAlert(this.Page, "Room Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            RoomsList p = new RoomsList
                            {
                                roomCode = txtCode_Room.Value.ToString().Trim(),
                                siteCode = ddlSiteCode_Room.Value.ToString().Trim(),
                                description = txteDesc_Room.Value.ToString().Trim(),
                                displayname = txt_RoomNo.Value.ToString().Trim(),
                                equipment = ddlEquipment.Value.ToString().Trim(),
                                isactive = chkRoomActive_Room.Checked
                            };

                            System.Collections.Generic.List<string> sc = new System.Collections.Generic.List<string>();
                            foreach (ListItem item in ddlEquipment.Items)
                            {
                                if (item.Selected)
                                    sc.Add(item.Text);
                            }


                            string csv = String.Join("/", sc.ToArray());

                            //  csv = ddlEquipment.Value.ToString().Trim();

                            p.equipment = csv;


                            if (rbtn_SingleRoom.Checked)
                            {
                                p.roomtype = rbtn_SingleRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_Double.Checked)
                            {
                                p.roomtype = rbtn_Double.Value.ToString().Trim();
                            }
                            else if (rbtn_TripleRoom.Checked)
                            {
                                p.roomtype = rbtn_TripleRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_QuadRoom.Checked)
                            {
                                p.roomtype = rbtn_QuadRoom.Value.ToString().Trim();
                            }
                            else if (rbtn_Twin.Checked)
                            {
                                p.roomtype = rbtn_Twin.Value.ToString().Trim();
                            }
                            else if (rbtn_Family.Checked)
                            {
                                p.roomtype = rbtn_Family.Value.ToString().Trim();
                            }
                            else if (rbtn_King.Checked)
                            {
                                p.roomtype = rbtn_King.Value.ToString().Trim();
                            }
                            else if (rbtn_Queen.Checked)
                            {
                                p.roomtype = rbtn_Queen.Value.ToString().Trim();
                            }
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<RoomsList>("api/Rooms", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Room Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                        Get_ControlPrefixs();

                    }

                    DataClear();
                    Get_Rooms();  

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