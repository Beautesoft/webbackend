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
    public partial class StockCount : System.Web.UI.Page
    {
      

        #region Declaration
        private string strUserCode = "";
      
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_GeneralTitle = new DataTable();
        private DataSet oDS_General = new DataSet();
        private CommonEngine oCommonEngine = new CommonEngine();
        #endregion
        #region Functions

        #region LoadValue
        private void LoadValue()
        {
            try
            {


                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemBrands"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemBrands"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV2 = new DataView(oDT_General);
                    oDV2.RowFilter = "itmStatus = True";
                    oDT_General = oDV2.ToTable();
                }
                ddlBrand_StockCount.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlBrand_StockCount.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemRanges"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemRanges"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV4 = new DataView(oDT_General);
                    oDV4.RowFilter = "itmStatus = True";
                    oDT_General = oDV4.ToTable();
                }
                ddlRange_StockCount.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlRange_StockCount.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Stocks"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemRanges"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV4 = new DataView(oDT_General);
                    oDV4.RowFilter = "itemIsactive = True";
                    oDT_General = oDV4.ToTable();
                }
                ddlItem_StockCount.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlItem_StockCount.Items.Add(new ListItem(oDr["itemDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDivs"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemDivs"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV = new DataView(oDT_General);
                    oDV.RowFilter = "itmIsactive = True";
                    oDT_General = oDV.ToTable();
                }
                ddlDiv_StockCount.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlDiv_StockCount.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }
                ddlDiv_StockCount.Value = "1";

                DateTime _ToDate = DateTime.Now;
                dtDate_StockCount.Value = _ToDate.ToString("dd/MM/yyyy");
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
        #endregion

        #region Load Page Informations
        private void LoadPageInformations()
        {
            try
            {
                string strDiv = "";
                string stritemCode = "";               
                string strRange = "";
                string strBrand = "";
                string strDate = "";
                strDiv = ddlDiv_StockCount.Items[ddlDiv_StockCount.SelectedIndex].Value.ToString().Trim();
                stritemCode = ddlItem_StockCount.Items[ddlItem_StockCount.SelectedIndex].Value.ToString().Trim();
                strBrand = ddlBrand_StockCount.Items[ddlBrand_StockCount.SelectedIndex].Value.ToString().Trim();
                strRange = ddlRange_StockCount.Items[ddlRange_StockCount.SelectedIndex].Value.ToString().Trim();
                strDate = dtDate_StockCount.Value.ToString();
                
                if(stritemCode == "")
                {
                    stritemCode = "%";
                }
                if (strRange == "")
                {
                    strRange = "%";
                }
                if (strBrand == "")
                {
                    strBrand = "%";
                }
                string postData = "{\"div\":\"" + strDiv.Trim() + "\"," +
                     "\"itemCode\":\"" + stritemCode.Trim() + "\"," +
                     "\"itemBrand\":\"" + strBrand.Trim() + "\"," +
                     "\"itemRange\":\"" + strRange.Trim() + "\"," +
                     "\"date\":\"" + strDate.Trim() + "\"}";
                oDT_General = oCommonEngine.GetDataTableFromAPI(System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"] + "api/stockCount", postData);
                if (oDT_General.Rows.Count > 0 && tblStockCount.Rows.Count == 1)
                {
                    for (int i = 0; i < oDT_General.Rows.Count; i++)
                    {
                        HtmlTableRow _Row = new HtmlTableRow();
                        HtmlTableCell Col_1 = new HtmlTableCell();
                        Col_1.InnerText = oDT_General.Rows[i]["ItemCode"].ToString();
                        Col_1.Attributes.Add("style", "width: 5 %; text-align:center");
                        _Row.Controls.Add(Col_1);

                        HtmlTableCell Col_2 = new HtmlTableCell();
                        Col_2.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_2.InnerText = oDT_General.Rows[i]["ItemName"].ToString();
                        _Row.Controls.Add(Col_2);

                        HtmlTableCell Col_3 = new HtmlTableCell();
                        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_3.InnerText = oDT_General.Rows[i]["ItemBrand"].ToString();
                        _Row.Controls.Add(Col_3);

                        HtmlTableCell Col_4 = new HtmlTableCell();
                        Col_4.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_4.InnerText = oDT_General.Rows[i]["ItemRange"].ToString();
                        _Row.Controls.Add(Col_4);

                        HtmlTableCell Col_5 = new HtmlTableCell();
                        Col_5.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_5.InnerText = oDT_General.Rows[i]["ItemUOM"].ToString();
                        _Row.Controls.Add(Col_5);

                        HtmlTableCell Col_6 = new HtmlTableCell();
                        Col_6.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_6.InnerText = oDT_General.Rows[i]["AWHQ"].ToString();
                        _Row.Controls.Add(Col_6);

                        HtmlTableCell Col_7 = new HtmlTableCell();
                        Col_7.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_7.InnerText = oDT_General.Rows[i]["AW01"].ToString();
                        _Row.Controls.Add(Col_7);

                        HtmlTableCell Col_8 = new HtmlTableCell();
                        Col_8.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_8.InnerText = oDT_General.Rows[i]["AW02"].ToString();
                        _Row.Controls.Add(Col_8);

                        HtmlTableCell Col_9 = new HtmlTableCell();
                        Col_9.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_9.InnerText = oDT_General.Rows[i]["AW03"].ToString();
                        _Row.Controls.Add(Col_9);

                        HtmlTableCell Col_10 = new HtmlTableCell();
                        Col_10.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_10.InnerText = oDT_General.Rows[i]["AW04"].ToString();
                        _Row.Controls.Add(Col_10);

                        HtmlTableCell Col_11 = new HtmlTableCell();
                        Col_11.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_11.InnerText = oDT_General.Rows[i]["AW05"].ToString();
                        _Row.Controls.Add(Col_11);

                        HtmlTableCell Col_12 = new HtmlTableCell();
                        Col_12.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_12.InnerText = oDT_General.Rows[i]["AW06"].ToString();
                        _Row.Controls.Add(Col_12);

                        HtmlTableCell Col_13 = new HtmlTableCell();
                        Col_13.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_13.InnerText = oDT_General.Rows[i]["AW07"].ToString();
                        _Row.Controls.Add(Col_13);

                        HtmlTableCell Col_14 = new HtmlTableCell();
                        Col_14.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_14.InnerText = oDT_General.Rows[i]["AW08"].ToString();
                        _Row.Controls.Add(Col_14);

                        HtmlTableCell Col_15 = new HtmlTableCell();
                        Col_15.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_15.InnerText = oDT_General.Rows[i]["AW09"].ToString();
                        _Row.Controls.Add(Col_15);

                        HtmlTableCell Col_16 = new HtmlTableCell();
                        Col_16.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_16.InnerText = oDT_General.Rows[i]["AW10"].ToString();
                        _Row.Controls.Add(Col_16);

                        HtmlTableCell Col_17 = new HtmlTableCell();
                        Col_17.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_17.InnerText = oDT_General.Rows[i]["AW11"].ToString();
                        _Row.Controls.Add(Col_17);

                        HtmlTableCell Col_18 = new HtmlTableCell();
                        Col_18.Attributes.Add("style", "width: 5 %; text-align:center");
                        Col_18.InnerText = oDT_General.Rows[i]["balance"].ToString();
                        _Row.Controls.Add(Col_18);

                        tblStockCount.Rows.Add(_Row);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            bool _RetVal = false;
            try
            {
                _RetVal = true;
                return _RetVal;
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, CommonEngine.MessageType.Error, CommonEngine.MessageDuration.Short);
                return _RetVal;
            }
        }
        #endregion
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadValue();
                    LoadPageInformations();
                }
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, CommonEngine.MessageType.Error, CommonEngine.MessageDuration.Medium);
            }
        }
        protected void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    LoadPageInformations();
                }
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, CommonEngine.MessageType.Error, CommonEngine.MessageDuration.Short);
            }
        }




        #endregion

    }
}