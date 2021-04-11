using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sequoia_BE.Utilities;

namespace Sequoia_BE
{
    public partial class ConfigInterface_PaymentGroup : System.Web.UI.Page
    {
        private DataTable oDT_City = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        string _Prefix = string.Empty, _ControlNo = string.Empty, _PKey = string.Empty;

        #region Methods

        private void Get_ControlPrefixs()
        {

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                ////GET Method  
                //string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"Room Code\"}}";
                //var response = client.GetAsync(api).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    var a = response.Content.ReadAsStringAsync().Result;
                //    List<ControlNos> controlNos = JsonConvert.DeserializeObject<List<ControlNos>>(a);
                //    _Prefix = controlNos[0].controlPrefix;
                //    _ControlNo = controlNos[0].controlNo;
                //    txtCode_Room.Value = _Prefix + _ControlNo;

                //}
                //else
                //{
                //    Console.WriteLine("Internal server Error");
                //}
            }

        }

        protected void Get_PayGroups()
        {

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/PayGroups"));
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/PayGroups"));
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

            List<PayGroupUpdate> items = new List<PayGroupUpdate>();
            items = JsonConvert.DeserializeObject<List<PayGroupUpdate>>(jsonString);

            for (int i = 0; i < items.Count; i++)
            {

                HtmlTableRow _Row = new HtmlTableRow();
                HtmlTableCell Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerHtml = "<a href='ConfigInterface_PaymentGroup.aspx?PKey=" + items[i].id + "'><font color='#6a6000'><b>" + items[i].payGroupCode.ToString() + "</b></font></a>";
                _Row.Controls.Add(Col);
                Col = new HtmlTableCell();
                Col.Attributes.Add("style", "width: 50 %");
                Col.InnerText = Convert.ToString(items[i].seq);
                _Row.Controls.Add(Col);
                tblSiteList.Rows.Add(_Row);

            }
        }

        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                if (txtCode_PayGroup.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Payment Group...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
                    return _RetVal;
                }
                if (txtSqe_PayGroup.Value.ToString().Trim().Replace("'", "") == "")
                {
                    oCommonEngine.SetAlert(this.Page, "Please enter Sequence...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
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
            btn_AddPayGroup.InnerText = "Add";
            txtCode_PayGroup.Value = string.Empty;
            txtSqe_PayGroup.Value = string.Empty;

        }

        private void FetchRecords()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string api = "api/PayGroups/" + _PKey;
                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsStringAsync().Result;
                    PayGroupUpdate payGroupUpdate = JsonConvert.DeserializeObject<PayGroupUpdate>(a);

                    txtCode_PayGroup.Value = payGroupUpdate.payGroupCode;
                    txtSqe_PayGroup.Value = Convert.ToString(payGroupUpdate.seq);
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
                Get_ControlPrefixs();

                if (Request.QueryString["PKey"] != null)
                {
                    _PKey = Request.QueryString["PKey"].ToString();
                }


                if (!IsPostBack)
                {
                    DataClear();
                   

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btn_AddPayGroup.InnerText = "Update";
                        CollapsiblePanelPayGroupCreation.Collapsed = false;
                        FetchRecords();
                    }
                    else
                    {
                        btn_AddPayGroup.InnerText = "Add";
                        _PKey = string.Empty;

                    }

                    Get_PayGroups();
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

                    if (btn_AddPayGroup.InnerText.Trim() == "Add")
                    {

                        using (var client = new HttpClient())
                        {
                            PayGroup p = new PayGroup
                            {

                                payGroupCode = txtCode_PayGroup.Value.ToString().Trim(),
                                seq = Int32.Parse(txtSqe_PayGroup.Value),
                                iscreditcard = false,
                                pictureLocation = " "
                               // imgUpload = img_Upload.Value.ToString()

                            };
                          

                             //FileUpload img = (FileUpload)img_Upload;
                             //Byte[] imgByte = null;
                             //if (img.HasFile && img.PostedFile != null)
                             //{
                             //    img_Upload imgByte = new Byte[File.ContentLength];
                             //    File.InputStream.Read(imgByte, 0, File.ContentLength);
                             //}
                             //string conn = ConfigurationManager.ConnectionStrings["EmployeeConnString"].ConnectionString;
                             //connection = new SqlConnection(conn);

                             //connection.Open();
                             //string sql = "INSERT INTO EmpDetails(empname,empimg) VALUES(@enm, @eimg) SELECT @@IDENTITY";
                             //SqlCommand cmd = new SqlCommand(sql, connection);
                             //cmd.Parameters.AddWithValue("@enm", txtEName.Text.Trim());
                             //cmd.Parameters.AddWithValue("@eimg", imgByte);
                             //int id = Convert.ToInt32(cmd.ExecuteScalar());
                             //lblImageName.Text = String.Format("Employee ID is {0}", id);

                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PostAsJsonAsync<PayGroup>("api/PayGroups", p);
                            post.Wait();
                            var response = post.Result;


                            if (response.IsSuccessStatusCode)
                            {

                                //ControlNosUpdate c = new ControlNosUpdate { controldescription = "Room Code", controlnumber = Convert.ToString((Int64.Parse(txtCode_Room.Value.ToString()) + 1)) };
                                //string api = "api/ControlNos/updatecontrol";
                                //post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                                //post.Wait();
                                //response = post.Result;
                                //if (response.IsSuccessStatusCode)
                                //{
                                //    txtCode_Room.Value = Convert.ToString((Int64.Parse(txtCode_Room.Value.ToString()) + 1));
                                //}
                                oCommonEngine.SetAlert(this.Page, "Payment Group Saved Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }

                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            PayGroupUpdate p = new PayGroupUpdate
                            {
                                id = Int32.Parse(_PKey),
                                payGroupCode = txtCode_PayGroup.Value.ToString().Trim(),
                                seq = Int32.Parse(txtSqe_PayGroup.Value),
                                iscreditcard = false,
                                pictureLocation = " "

                            };
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var post = client.PutAsJsonAsync<PayGroupUpdate>("api/PayGroups", p);
                            post.Wait();
                            var response = post.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                oCommonEngine.SetAlert(this.Page, "Payment Group Updated Successfully..!", Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                            }
                            else
                                oCommonEngine.SetAlert(this.Page, response.StatusCode + "...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);


                        }
                    }

                    DataClear();
                    Get_PayGroups();

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