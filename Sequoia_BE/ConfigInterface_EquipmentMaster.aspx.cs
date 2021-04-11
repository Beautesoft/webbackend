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
    public partial class EquipmentMaster : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string Prefix = string.Empty, ControlNo = string.Empty, _PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Equipment Code\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                    Prefix = "EQU";
                    ControlNo = controlNos[0].controlNo;
                    Session["ControlNo"] = ControlNo;
                    txtEquipmentID_ConfigInterface.Value = Prefix + ControlNo;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }


        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txtEquipmentID_ConfigInterface.Value.ToString().Trim().Replace("'", "") == "")
                {
                    //txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
                }
                if (txtEquipmentName_ConfigInterface.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Equipment Name...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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

            _PKey = String.Empty;
            btnSubmit_AddEquipmentMaster.InnerText = "Add";
            txtEquipmentName_ConfigInterface.Value = string.Empty;
            txtEquipmentDescription_ConfigInterface.Value = string.Empty;
            chk_ActiveEquipment.Checked = false;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                //string api = "api/ItemRanges?filter={\"where\":{\"itmCode\":\"" + _PKey + "\"}}";
                //string api = "api/Myequipments/" + _PKey;
                string api = "api/Myequipments/findOne?filter={\"where\":{\"equipmentCode\":\"" + _PKey + "\"}}";
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    //EquipmentList equipmentList = JsonConvert.DeserializeObject<EquipmentList>(a);
                    EquipmentFetchList equipmentList = JsonConvert.DeserializeObject<EquipmentFetchList>(a);

                    Session["id"] = equipmentList.id;
                    txtEquipmentID_ConfigInterface.Value = equipmentList.equipmentCode;
                    txtEquipmentName_ConfigInterface.Value = equipmentList.equipmentName;
                    txtEquipmentDescription_ConfigInterface.Value = equipmentList.equipmentDescription;
                    chk_ActiveEquipment.Checked = equipmentList.equipmentIsactive;
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
                    Get_ControlPrefixs();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btnSubmit_AddEquipmentMaster.InnerText = "Update";
                        FetchRecords();
                    }
                    else
                    {
                        btnSubmit_AddEquipmentMaster.InnerText = "Add";
                        _PKey = string.Empty;

                    }
                };

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }

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

                    if (btnSubmit_AddEquipmentMaster.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            EquipmentList p = new EquipmentList
                            {
                                //id = int.Parse(txtEquipmentTableID.Value.ToString().Trim()),
                                equipmentCode = txtEquipmentID_ConfigInterface.Value.ToString().Trim(),
                                equipmentName = txtEquipmentName_ConfigInterface.Value.ToString().Trim(),
                                equipmentDescription = txtEquipmentDescription_ConfigInterface.Value.ToString().Trim(),
                                equipmentIsactive = chk_ActiveEquipment.Checked

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<EquipmentList>("api/Myequipments", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Equipment Code", sitecode= System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(), controlnumber = Convert.ToString((Int64.Parse(Session["ControlNo"].ToString()) + 1)) };
                                string api = "api/ControlNos/updatecontrol";
                                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                post.Wait();
                                response = post.Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    Response.Redirect("ConfigInterface_EquipmentsList.aspx");
                                }

                                oCommonEngine.SetAlert(this.Page, "Equipment Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            EquipmentListUpdate p = new EquipmentListUpdate
                            {
                                //id = Int32.Parse(_PKey),
                                id= int.Parse(Session["id"].ToString()),
                                equipmentName = txtEquipmentName_ConfigInterface.Value.ToString().Trim(),
                                equipmentDescription = txtEquipmentDescription_ConfigInterface.Value.ToString().Trim(),
                                equipmentIsactive = chk_ActiveEquipment.Checked,
                                equipmentCode =  txtEquipmentID_ConfigInterface.Value.ToString().Trim()
                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            //var post = client.PutAsJsonAsync<EquipmentListUpdate>("api/Myequipments/replaceOrCreate", p);
                            var post = client.PostAsJsonAsync<EquipmentListUpdate>("api/Myequipments/replaceOrCreate", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                Response.Redirect("ConfigInterface_EquipmentsList.aspx");
                                oCommonEngine.SetAlert(this.Page, "Equipment Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                                Server.Execute("ConfigInterface.aspx");
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);



                        }
                    }

                    DataClear();

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