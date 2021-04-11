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
    public partial class ItemMaster : System.Web.UI.Page
    {
        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";
        private string _PKey = "";
        private DataTable oDT_General = new DataTable();
        private DataTable oDT_Lead = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        private DataTable oDT_atStudent = new DataTable();

        public class divMasInput
        {
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public bool itmIsactive { get; set; }
            public string itmSeq { get; set; }
        }
        public class stockdetailsInput
        {
            public string stockcode { get; set; }
            public string stockname { get; set; }
            public string type { get; set; }
            public bool isactive { get; set; }
            public string division { get; set; }
            public string rangecode { get; set; }
            public string range { get; set; }
            public string deptcode { get; set; }
            public string department { get; set; }
            public string classcode { get; set; }
            public string Class { get; set; }
            public string brandcode { get; set; }
            public string brand { get; set; }
        }
        
        public class itemMasInput
        {
            public string siteCode { get; set; }
            public string itemCode { get; set; }
            public string itemDiv { get; set; }
            public string itemDept { get; set; }
            public string itemClass { get; set; }
            public string itemBrand { get; set; }
            public string itemRange { get; set; }
            public string itemName { get; set; }
            public string itemDesc { get; set; }
            
            public bool isOpenPrepaid { get; set; }
            public string itemType { get; set; }
            public string srvDuration { get; set; }
            public string itemSupp { get; set; }
            public string itemPrice { get; set; }
            public string itemPriceFloor { get; set; }
            public string costPrice { get; set; }
            public string disclimit { get; set; }
            public bool disctypeamount { get; set; }
            public bool autocustdisc { get; set; }
            public bool itemIsactive { get; set; }
            public bool commissionable { get; set; }
            public bool itemFoc { get; set; }
            public bool isGst { get; set; }
            public bool isAllowFoc { get; set; }
            public bool itemHavechild { get; set; }
            public bool valueApplytochild { get; set; }
            public bool havePackageDisc { get; set; }
            public bool mixbrand { get; set; }

            public string serviceCost { get; set; }
            public bool serviceCostPercent { get; set; }
            
            public bool isHaveTax { get; set; }
            public string accountCode { get; set; }

            public bool voucherIsvalidUntilDate { get; set; }
            public string voucherValidUntilDate { get; set; }
            public string voucherValue { get; set; }
            public bool voucherValueIsAmount { get; set; }
            public string voucherValidPeriod { get; set; }

            public string prepaidValidPeriod { get; set; }
            public bool membercardnoaccess { get; set; }
            public string prepaidValue { get; set; }
            public string prepaidSellAmt { get; set; }

            public bool reorderActive { get; set; }
            public string reorderMinqty { get; set; }
            public string custReplenishDays { get; set; }
            public string custAdvanceDays { get; set; }
            public bool trading { get; set; }

            public string workcomm { get; set; }
            public string salescomm { get; set; }
            
            public string salescommpoints { get; set; }
            public string workcommpoints { get; set; }
            

            public bool serviceExpireActive { get; set; }
            public string serviceExpireMonth { get; set; }
            public bool treatmentLimitActive { get; set; }
            public string treatmentLimitCount { get; set; }
            public bool limitserviceFlexionly { get; set; }


            public string t1TaxCode { get; set; }
            public string t2TaxCode { get; set; }

            public string itemClassIdId { get; set; }
            public string itemDeptIdId { get; set; }
            public string itemDivIdId { get; set; }
            public string itemRangeIdId { get; set; }
            public string itemTypeIdId { get; set; }
        }

        public class matrixInput
        {
            public string matrixX { get; set; }
            public string matrixY { get; set; }
            public string matrixCode { get; set; }
            public string itemCode { get; set; }
            public string itemBarcode { get; set; }
            public string itemName { get; set; }
            public string itemPrice { get; set; }
            public string onhandQty { get; set; }
            public string onhandCst { get; set; }
            public string itemOnhandcost { get; set; }
            public string matrixUser { get; set; }
            public string matrixDate { get; set; }
            public string matrixTime { get; set; }
        }

        public class itemBatchInput
        {
            public string itemCode { get; set; }
            public string siteCode { get; set; }
            public string batchNo { get; set; }
            public string uom { get; set; }
            public string qty { get; set; }
            public string expDate { get; set; }
            public string batchCost { get; set; }
        }

        public class itemRangesFetch
        {
            public string itmId { get; set; }
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public bool itmStatus { get; set; }
            public string itmSeq { get; set; }
            public string itmBrand { get; set; }
            public string itmDept { get; set; }
            public string picPath { get; set; }
            public bool prepaidForProduct { get; set; }
            public bool prepaidForService { get; set; }
            public bool prepaidForAll { get; set; }
            public bool isservice { get; set; }
            public bool isvoucher { get; set; }
            public bool isprepaid { get; set; }
            public bool iscompound { get; set; }

        }

        public class itemBrandsFetch
        {
            public string itmId { get; set; }
            public string itmCode { get; set; }
            public string itmDesc { get; set; }
            public bool itmStatus { get; set; }
            public string itmSeq { get; set; }
            public string picPath { get; set; }
            public bool voucherForSales { get; set; }
            public bool voucherBrand { get; set; }
            public bool retailProductBrand { get; set; }
            public bool prepaidBrand { get; set; }

        }

        public class itemTypesFetch
        {
            public string itmId { get; set; }
            public string itmName { get; set; }

        }

            public class Data
        {
            public string id { get; set; }
            public string itemCode { get; set; }
            public string itemUom { get; set; }
            public string uomDesc { get; set; }
            public string uomUnit { get; set; }
            public string itemUom2 { get; set; }
            public string uom2Desc { get; set; }
            public string itemPrice { get; set; }
            public string itemCost { get; set; }
            public string minMargin { get; set; }

            public bool isactive { get; set; }
            public string itemUompriceSeq { get; set; }

        }

        public class linkData
        {
            public string itmId { get; set; }
            public string itemCode { get; set; }
            public string linkCode { get; set; }
            public string linkDesc { get; set; }
            public string linkType { get; set; }
            public bool itmIsactive { get; set; }
        }

        public class ServiceData
        {
            
            public string itmId { get; set; }
            public string itemCode { get; set; }
            public string itemSrvcode { get; set; }
            public string itemSrvdesc { get; set; }
            public string itmIsactive { get; set; }
        }


        public class stockListingData
        {
            public string itemstocklistId { get; set; }
            public string itemCode { get; set; }
            public string itemBarcode { get; set; }
            public string itemsiteCode { get; set; }
            public string onhandQty { get; set; }
            public bool itemstocklistStatus { get; set; }

            //public string itemstocklistMinqty { get; set; }
            //public string itemstocklistMaxqty { get; set; }
            //public string onhandCst { get; set; }
            //public string itemstocklistOnhandcost { get; set; }
            //public string itemstocklistUnit { get; set; }
            //public string itemstocklistUser { get; set; }
            //public string itemstocklistDatetime { get; set; }
            //public string itemstocklistRemark { get; set; }
            //public bool itemstocklistPosted { get; set; }
            //public bool itemstocklistStatus { get; set; }
            //public string lstpoUcst { get; set; }
            //public string lstpoNo { get; set; }
            //public string lstpoDate { get; set; }
            //public string costPrice { get; set; }
            //public string itmSeq { get; set; }
        }

        public class itemUsageLevel
        {
            public string id { get; set; }
            public string serviceCode { get; set; }
            public string itemCode { get; set; }
            public string qty { get; set; }
            public string uom { get; set; }
            public string sequence { get; set; }
            public string serviceDesc { get; set; }
            public string itemDesc { get; set; }
            public bool isactive { get; set; }
        }

        public class prepaidConditionsInput
        {
            public string itemid { get; set; }
            public string pItemtype { get; set; }
            public string itemCode { get; set; }
            public string conditiontype1 { get; set; }
            public string conditiontype2 { get; set; }
            public string amount { get; set; }
            public string rate { get; set; }
            public bool membercardnoaccess { get; set; }
        }

        public class PackageHdrsInput
        {
            public string code { get; set; }
            public string description { get; set; }
            public string price { get; set; }
            public string discount { get; set; }
            public string dateCreated { get; set; }
            public string timeCreated { get; set; }
            public string userName { get; set; }
            public string packageBarcode { get; set; }
            public string unitPrice { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string fromTime { get; set; }
            public string toTime { get; set; }
            public string siteCode { get; set; }
            public string manualDisc { get; set; }
            public string istdt { get; set; }
            public string apptlimit { get; set; }
        }

        public class PackageDtlsInput
        {
            public string ID { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public string cost { get; set; }
            public string price { get; set; }
            public string discount { get; set; }
            public string packageCode { get; set; }
            public string qty { get; set; }
            public string uom { get; set; }
            public string itemDiv { get; set; }
            public string packageBarcode { get; set; }
            public string discPercent { get; set; }
            public string unitPrice { get; set; }
            public string ttlUprice { get; set; }
            public string siteCode { get; set; }
            public string lineNo { get; set; }
            public bool serviceExpireActive { get; set; }
            public string serviceExpireMonth { get; set; }
            public string treatmentLimitActive { get; set; }
            public string treatmentLimitCount { get; set; }
            public bool limitserviceFlexionly { get; set; }
            public bool isactive { get; set; }
        }

        #endregion
        #region Functions
        #region LoadValue
        private void LoadValue()
        {

            try
            {
                //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDivs"));
                //WebReq.Method = "GET";
                //HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                //Console.WriteLine(WebResp.StatusCode);
                //Console.WriteLine(WebResp.Server);
                //string jsonString;
                //using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
                //{
                //    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                //    jsonString = reader.ReadToEnd();
                //}
                //DataTable oDT_General = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDivs"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemDivs"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV = new DataView(oDT_General);
                    oDV.RowFilter = "itmIsactive = True";
                    oDT_General = oDV.ToTable();
                }
                //DataTable oDT_General = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
                ddl_Div.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Div.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim() + "-" + oDr["itmId"].ToString().Trim()));
                }
                //on 09 Jul 2019 Imran - uncomment before release
                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDepts"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemDepts"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV1 = new DataView(oDT_General);
                    oDV1.RowFilter = "itmStatus = True";
                    oDT_General = oDV1.ToTable();
                }
                //DataTable oDT_General = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
                ddl_Dept.Items.Add(new ListItem("Select your option", ""));
                ddlDept_mdlPackageItem.Items.Add(new ListItem("", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Dept.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim() + "-" + oDr["itmId"].ToString().Trim()));
                    ddlDept_mdlPackageItem.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemBrands"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV2 = new DataView(oDT_General);
                    oDV2.RowFilter = "itmStatus = True";
                    oDT_General = oDV2.ToTable();
                }
                ddl_Brand.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Brand.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemClasses"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV3 = new DataView(oDT_General);
                    oDV3.RowFilter = "itmIsactive = True";
                    oDT_General = oDV3.ToTable();
                }
                ddl_Class.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Class.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim() + "-" + oDr["itmId"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemRanges"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV4 = new DataView(oDT_General);
                    oDV4.RowFilter = "itmStatus = True";
                    oDT_General = oDV4.ToTable();
                }
                ddl_Range.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Range.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim() + "-" + oDr["itmId"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemUoms"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV5 = new DataView(oDT_General);
                    oDV5.RowFilter = "uomIsactive = True";
                    oDT_General = oDV5.ToTable();
                }
                ddl_Uom.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_Uom.Items.Add(new ListItem(oDr["uomDesc"].ToString().Trim(), oDr["uomCode"].ToString().Trim()));
                }

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemVendorlists"), (typeof(DataTable)));
                ////oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemVendorlists"), (typeof(DataTable)));
                //if (oDT_General.Rows.Count > 0)
                //{
                //    DataView oDV6 = new DataView(oDT_General);
                //    oDV6.RowFilter = "ivlSupplystatus = True";
                //    oDT_General = oDV6.ToTable();
                //}
                //ddl_supplier.Items.Add(new ListItem("Select your option", ""));
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddl_supplier.Items.Add(new ListItem(oDr["ivlVendordesc"].ToString().Trim(), oDr["itemCode"].ToString().Trim()));
                //}

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSupplies"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV5 = new DataView(oDT_General);
                    oDV5.RowFilter = "splyactive = True";
                    oDT_General = oDV5.ToTable();
                }
                ddl_supplier.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_supplier.Items.Add(new ListItem(oDr["supplydesc"].ToString().Trim(), oDr["splyCode"].ToString().Trim()));
                }


                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemSitelists"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV7 = new DataView(oDT_General);
                    oDV7.RowFilter = "itemsiteIsactive = True";
                    oDT_General = oDV7.ToTable();
                }
                ddl_siteCode.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_siteCode.Items.Add(new ListItem(oDr["itemsiteDesc"].ToString().Trim(), oDr["itemsiteCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/TaxType1TaxCodes"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/TaxType1TaxCodes"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV9 = new DataView(oDT_General);
                    oDV9.RowFilter = "isactive = True";
                    oDT_General = oDV9.ToTable();
                }
                ddl_siteCode.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl1stTax_ItemMaster.Items.Add(new ListItem(oDr["taxDesc"].ToString().Trim(), oDr["taxCode"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CommGroupHdrs"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/CommGroupHdrs"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV10 = new DataView(oDT_General);
                    oDV10.RowFilter = "isactive =True and type = 'Sales' ";
                    oDT_General = oDV10.ToTable();
                }
                ddlSalesCommGroup_itemMaster.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlSalesCommGroup_itemMaster.Items.Add(new ListItem(oDr["description"].ToString().Trim(), oDr["code"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CommGroupHdrs"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/CommGroupHdrs"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV11 = new DataView(oDT_General);
                    oDV11.RowFilter = "isactive =True and type = 'Work' ";
                    oDT_General = oDV11.ToTable();
                }
                ddlWorkCommGroup_itemMaster.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddlWorkCommGroup_itemMaster.Items.Add(new ListItem(oDr["description"].ToString().Trim(), oDr["code"].ToString().Trim()));
                }

                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Vouchervalidperiods"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV11 = new DataView(oDT_General);
                    oDV11.RowFilter = "VoucherValidIsActive =True ";
                    oDT_General = oDV11.ToTable();
                }
                ddl_ValidityPeriodItemMaster.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_ValidityPeriodItemMaster.Items.Add(new ListItem(oDr["VoucherValidDesc"].ToString().Trim(), oDr["VoucherValidDays"].ToString().Trim()));
                }

                ddl_ValidPeriodItemMaster.Items.Add(new ListItem("Select your option", ""));
                foreach (DataRow oDr in oDT_General.Rows)
                {
                    ddl_ValidPeriodItemMaster.Items.Add(new ListItem(oDr["VoucherValidDesc"].ToString().Trim(), oDr["VoucherValidDays"].ToString().Trim()));
                }

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Prepaidvalidperiods"), (typeof(DataTable)));
                //if (oDT_General.Rows.Count > 0)
                //{
                //    DataView oDV11 = new DataView(oDT_General);
                //    oDV11.RowFilter = "PrepaidValidIsActive =True ";
                //    oDT_General = oDV11.ToTable();
                //}
                //ddl_ValidPeriodItemMaster.Items.Add(new ListItem("Select your option", ""));
                //foreach (DataRow oDr in oDT_General.Rows)
                //{
                //    ddl_ValidPeriodItemMaster.Items.Add(new ListItem(oDr["PrepaidValidDesc"].ToString().Trim(), oDr["PrepaidValidDays"].ToString().Trim()));
                //}


                oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSitelists"), (typeof(DataTable)));
                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/ItemSitelists"), (typeof(DataTable)));
                if (oDT_General.Rows.Count > 0)
                {
                    DataView oDV8 = new DataView(oDT_General);
                    oDV8.RowFilter = "itemsiteIsactive = True";
                    oDT_General = oDV8.ToTable();
                }
                if (oDT_General.Rows.Count > 0 && stockListingMaster.Rows.Count == 1)
                {
                    for (int i = 0; i < oDT_General.Rows.Count; i++)
                    {
                        HtmlTableRow _Row = new HtmlTableRow();
                        HtmlTableCell Col_1 = new HtmlTableCell();
                        Col_1.InnerText = oDT_General.Rows[i]["itemsiteCode"].ToString();

                        _Row.Controls.Add(Col_1);
                        HtmlTableCell Col_2 = new HtmlTableCell();
                        Col_2.InnerText = oDT_General.Rows[i]["itemsiteDesc"].ToString();
                        _Row.Controls.Add(Col_2);
                        HtmlTableCell Col_3 = new HtmlTableCell();
                        Col_3.Attributes.Add("style", "width: 10 %; text-align:center");
                        Col_3.InnerHtml = "<input type='checkbox' checked class='case'>";
                        _Row.Controls.Add(Col_3);
                        stockListingMaster.Rows.Add(_Row);
                    }
                }

                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling("http://103.253.14.203:3000/api/Stocks"), (typeof(DataTable)));
                //if (oDT_General.Rows.Count > 0 && ItemUsageMaster.Rows.Count == 1)
                //{
                //    for (int i = 0; i < oDT_General.Rows.Count; i++)
                //    {
                //        HtmlTableRow _Row = new HtmlTableRow();
                //        HtmlTableCell Col_1 = new HtmlTableCell();
                //        Col_1.InnerText = oDT_General.Rows[i]["itemName"].ToString();

                //        _Row.Controls.Add(Col_1);
                //        HtmlTableCell Col_2 = new HtmlTableCell();
                //        Col_2.InnerText = oDT_General.Rows[i]["itemCode"].ToString();
                //        _Row.Controls.Add(Col_2);
                //        HtmlTableCell Col_3 = new HtmlTableCell();
                //        Col_3.InnerText = oDT_General.Rows[i]["itemBarcode"].ToString();
                //        _Row.Controls.Add(Col_3);

                //        HtmlTableCell Col_4 = new HtmlTableCell();
                //        Col_4.Attributes.Add("style", "width: 10 %; text-align:center");
                //        Col_4.InnerHtml = "<input type='checkbox' class='case'>";
                //        _Row.Controls.Add(Col_4);
                //        ItemUsageMaster.Rows.Add(_Row);
                //    }
                //}


            }
            catch (Exception Ex)
            {
                throw;
            }
        }
        private string apiCalling( string apiName)
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

        private string GetapiCalling(string apiName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = apiName;
                var response = client.GetAsync(api).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        #endregion

        #region Load Page Informations
        /// <summary>
        /// 
        /// </summary>
        private void LoadPageInformations()
        {
            //try
            //{

            //    oDT_General = oCommonEngine.ExecuteDataTable("Select * from StudentMaster Where StudentCode='" + _PKey + "'");
            //    oDT_atStudent = oCommonEngine.ExecuteDataTable("Select *,'Y' [Existing] from Attachments Where  Document='Student' and PrimaryKey='" + _PKey + "'");
            //    Session["oDT_atStudent"] = oDT_atStudent;
            //    if (oDT_General.Rows.Count == 1)
            //    {
            //        lblLastUpdateInfo_Student.InnerText = "[Last Updated:" + Convert.ToDateTime(oDT_General.Rows[0]["UpdateDate"]).ToString("dd/MM/yyyy hh:mm tt") + "]";

            //        txtCode_Student.Value = oDT_General.Rows[0]["StudentCode"].ToString();
            //        txtName_Student.Value = oDT_General.Rows[0]["StudentName"].ToString();
            //        ddlStudentType.Items.FindByValue(oDT_General.Rows[0]["StudentType"].ToString().Trim()).Selected = true;
            //        ddlIDType.Items.FindByValue(oDT_General.Rows[0]["IDType"].ToString().Trim()).Selected = true;
            //        ddlNationality.Items.FindByValue(oDT_General.Rows[0]["Nationality"].ToString().Trim()).Selected = true;
            //        txtID_Student.Value = oDT_General.Rows[0]["IDNumber"].ToString();
            //        if (oDT_General.Rows[0]["DOB"].ToString().Trim() != "")
            //        { dtDateOfBirth_Student.Value = Convert.ToDateTime(oDT_General.Rows[0]["DOB"].ToString().Trim()).ToString("dd/MM/yyyy"); }
            //        if (oDT_General.Rows[0]["RegDate"].ToString().Trim() != "")
            //        { dtRegistration_Student.Value = Convert.ToDateTime(oDT_General.Rows[0]["RegDate"].ToString().Trim()).ToString("dd/MM/yyyy"); }
            //        txtEmail_Student.Value = oDT_General.Rows[0]["Email"].ToString().Trim();
            //        txtContact1_Student.Value = oDT_General.Rows[0]["Contact"].ToString().Trim();
            //        txtContact2_Student.Value = oDT_General.Rows[0]["Contact2"].ToString().Trim();
            //        txtEmergencyContact_Student.Value = oDT_General.Rows[0]["EmergencyContact"].ToString().Trim();
            //        ddlGender.Items.FindByValue(oDT_General.Rows[0]["Gender"].ToString().Trim()).Selected = true;
            //        ddlStatus.Items.FindByValue(oDT_General.Rows[0]["MStatus"].ToString().Trim()).Selected = true;
            //        ddlRace.Items.FindByValue(oDT_General.Rows[0]["Race"].ToString().Trim()).Selected = true;
            //        txtBilltoAddress_Student.Value = oDT_General.Rows[0]["Address"].ToString();
            //        txtPinCode_Student.Value = oDT_General.Rows[0]["PinCode"].ToString();
            //        if (oDT_General.Rows[0]["LeadCode"].ToString().Trim() != "")
            //        {
            //            lblLead_Student.Text = oDT_General.Rows[0]["LeadCode"].ToString().Trim() + " Converted At:" + Convert.ToDateTime(oDT_General.Rows[0]["ConvertedOn"].ToString().Trim()).ToString("dd/MM/yyyy");
            //            lblLead_Student.NavigateUrl = "LeadMaster.aspx?PKey=" + oDT_General.Rows[0]["LeadCode"].ToString() + "";
            //        }
            //        txtBalance_Student.NavigateUrl = "StudentAccount.aspx?PKey=" + oDT_General.Rows[0]["StudentCode"].ToString() + "";
            //        txtBalance_Student.Text= oDT_General.Rows[0]["Balance"].ToString();
            //        if (oDT_General.Rows[0]["OtherSiteAccess"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["OtherSiteAccess"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlOtherSiteAccess.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
                    
            //        if (oDT_General.Rows[0]["PreferredLanguage1"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredLanguage1"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPrefferedLanguage.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        if (oDT_General.Rows[0]["PreferredType"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredType"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPrefferedType.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }

            //        ddlNextProgression.Items.FindByValue(oDT_General.Rows[0]["NextProgression"].ToString().Trim()).Selected = true;
            //        ddlEmployerName_student.Items.FindByValue(oDT_General.Rows[0]["EmpName"].ToString().Trim()).Selected = true;
            //        txtEmployerNameNone_student.Value = oDT_General.Rows[0]["EmpNameNone"].ToString();
            //        ddlAcademic.Items.FindByValue(oDT_General.Rows[0]["Academic"].ToString()).Selected = true;
            //        if (oDT_General.Rows[0]["PreferredCourseCategory"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredCourseCategory"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPreferCoursecategory.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        if (oDT_General.Rows[0]["PreferredCourseMode"].ToString().Length > 0)
            //        {
            //            IList<string> _SiteList = oDT_General.Rows[0]["PreferredCourseMode"].ToString().Split(',').ToList<string>();
            //            for (int i = 0; i < _SiteList.Count; i++)
            //            {
            //                if (_SiteList[i].ToString().Trim() != "")
            //                {
            //                    ddlPreferCourseMode.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                }
            //            }
            //        }
            //        txtDesignation_student.Value = oDT_General.Rows[0]["EmpDesignation"].ToString();
            //        txtBasicSalary_student.Value = oDT_General.Rows[0]["EmpSalary"].ToString();
            //        ddlEmploymentStatus.Items.FindByValue(oDT_General.Rows[0]["EmpStatus"].ToString()).Selected = true;
            //        txtRemarks_Student.Value = oDT_General.Rows[0]["Remarks"].ToString();
            //        if (oDT_General.Rows[0]["InActive"].ToString() == "Y")
            //        {
            //            chkInActive_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkInActive_Student.Checked = false;
            //        }
            //        if (oDT_General.Rows[0]["ActiveSMS"].ToString() == "Y")
            //        {
            //            chkSendSMS_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkSendSMS_Student.Checked = false;
            //        }
            //        if (oDT_General.Rows[0]["ActiveEMail"].ToString() == "Y")
            //        {
            //            chkSendEmail_Student.Checked = true;
            //        }
            //        else
            //        {
            //            chkSendEmail_Student.Checked = false;
            //        }

            //        btnOperation.InnerText = "Update";
            //        txtCode_Student.Disabled = true;
            //        LoadHTMLTable();
            //    }
            //    else
            //    {
            //        ddlNationality.Items.FindByValue("SG").Selected = true;
            //        ddlIDType.Items.FindByValue("SINGAPOREAN").Selected = true;
            //        try { ddlOtherSiteAccess.Items.FindByValue(strSiteCode.Trim()).Selected = true; }
            //        catch (Exception Ex1) { }
            //        if (Session["LeadToStudent"] != null)
            //        {
            //            oDT_Lead = oCommonEngine.ExecuteDataTable("Select * from LeadMaster T0 Where T0.LeadCode='" + Session["LeadToStudent"].ToString() + "'");
            //            if (oDT_Lead.Rows.Count > 0)
            //            {
            //                lblLead_Student.Text = oDT_Lead.Rows[0]["LeadCode"].ToString();
            //                lblLead_Student.NavigateUrl = "LeadMaster.aspx?PKey=" + oDT_Lead.Rows[0]["LeadCode"].ToString() + "";
            //                txtName_Student.Value = oDT_Lead.Rows[0]["LeadName"].ToString();
            //                ddlNationality.Items.FindByValue(oDT_Lead.Rows[0]["Nationality"].ToString().Trim()).Selected = true;
            //                txtContact1_Student.Value = oDT_Lead.Rows[0]["Contact"].ToString().Trim();
            //                txtContact2_Student.Value = oDT_Lead.Rows[0]["Contact2"].ToString().Trim();
            //                txtEmail_Student.Value = oDT_Lead.Rows[0]["Email"].ToString().Trim();                                                    
            //                if (oDT_Lead.Rows[0]["PreferredLanguage1"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredLanguage1"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPrefferedLanguage.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredType"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredType"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPrefferedType.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredCourseCategory"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredCourseCategory"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPreferCoursecategory.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["PreferredCourseMode"].ToString().Length > 0)
            //                {
            //                    IList<string> _SiteList = oDT_Lead.Rows[0]["PreferredCourseMode"].ToString().Split(',').ToList<string>();
            //                    for (int i = 0; i < _SiteList.Count; i++)
            //                    {
            //                        if (_SiteList[i].ToString().Trim() != "")
            //                        {
            //                            ddlPreferCourseMode.Items.FindByValue(_SiteList[i].ToString()).Selected = true;
            //                        }
            //                    }
            //                }
            //                if (oDT_Lead.Rows[0]["ActiveSMS"].ToString() == "Y")
            //                {
            //                    chkSendSMS_Student.Checked = true;
            //                }
            //                else
            //                {
            //                    chkSendSMS_Student.Checked = false;
            //                }
            //                if (oDT_Lead.Rows[0]["ActiveEMail"].ToString() == "Y")
            //                {
            //                    chkSendEmail_Student.Checked = true;
            //                }
            //                else
            //                {
            //                    chkSendEmail_Student.Checked = false;
            //                }
            //                txtRemarks_Student.Value = oDT_Lead.Rows[0]["Remarks"].ToString();
            //            }
            //            Session["LeadToStudent"] = null;
            //        }
            //        btnOperation.InnerText = "Add";
            //        lblLastUpdateInfo_Student.InnerText = "";
            //        ddlEmployerName_student.Items.FindByValue("-").Selected = true;
            //        txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
            //        dtRegistration_Student.Value = DateTime.Now.ToString("dd/MM/yyyy");
            //        txtCode_Student.Disabled = false;
            //    }
            //    if (strSiteCode != "HQ01")
            //    {
            //        ddlOtherSiteAccess.Disabled = true;
            //    }
            //    else
            //    {
            //        ddlOtherSiteAccess.Disabled = false;
            //    }

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Bind Data
        private void BindData()
        {
            //try
            //{
            //    oDT_General = oCommonEngine.ExecuteDataTable("Select * from StudentMaster Where StudentCode='" + _PKey + "'");
            //    oDT_atStudent = (DataTable)Session["oDT_atStudent"];
            //    oDT_General.TableName = "Student";
            //    oDT_atStudent.TableName = "Attachment";
            //    if (oDT_General.Rows.Count == 0)
            //    {
            //        DataRow oDr = oDT_General.NewRow();
            //        oDr["StudentCode"] = txtCode_Student.Value.ToString().Trim().Replace("'", ""); 
            //        oDr["StudentName"] = txtName_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentType"] = ddlStudentType.Items[ddlStudentType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDType"] = ddlIDType.Items[ddlIDType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Nationality"] = ddlNationality.Items[ddlNationality.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDNumber"] = txtID_Student.Value.ToString().Trim().Replace("'", "");
            //        if (dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["DOB"] = DateTime.ParseExact(dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["RegDate"] = DateTime.ParseExact(dtRegistration_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }

            //        oDr["Email"] = txtEmail_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact"] = txtContact1_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact2"] = txtContact2_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmergencyContact"] = txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "");

            //        oDr["Gender"] = ddlGender.Items[ddlGender.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["MStatus"] = ddlStatus.Items[ddlStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Race"] = ddlRace.Items[ddlRace.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Address"] = txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["PinCode"] = txtPinCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["LeadCode"] = lblLead_Student.Text.Trim().Replace("'", "");
            //        oDr["OtherSiteAccess"] = "";
            //        for (int i = 0; i < ddlOtherSiteAccess.Items.Count; i++)
            //        {
            //            if (ddlOtherSiteAccess.Items[i].Selected == true)
            //            { oDr["OtherSiteAccess"] = oDr["OtherSiteAccess"].ToString() + ddlOtherSiteAccess.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredLanguage1"] = "";
            //        for (int i = 0; i < ddlPrefferedLanguage.Items.Count; i++)
            //        {
            //            if (ddlPrefferedLanguage.Items[i].Selected == true)
            //            { oDr["PreferredLanguage1"] = oDr["PreferredLanguage1"].ToString() + ddlPrefferedLanguage.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredType"] = "";
            //        for (int i = 0; i < ddlPrefferedType.Items.Count; i++)
            //        {
            //            if (ddlPrefferedType.Items[i].Selected == true)
            //            { oDr["PreferredType"] = oDr["PreferredType"].ToString() + ddlPrefferedType.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }


            //        oDr["NextProgression"] = ddlNextProgression.Items[ddlNextProgression.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpName"] = ddlEmployerName_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpNameNone"] = txtEmployerNameNone_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Academic"] = ddlAcademic.Items[ddlAcademic.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["PreferredCourseCategory"] = "";
            //        for (int i = 0; i < ddlPreferCoursecategory.Items.Count; i++)
            //        {
            //            if (ddlPreferCoursecategory.Items[i].Selected == true)
            //            { oDr["PreferredCourseCategory"] = oDr["PreferredCourseCategory"].ToString() + ddlPreferCoursecategory.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredCourseMode"] = "";
            //        for (int i = 0; i < ddlPreferCourseMode.Items.Count; i++)
            //        {
            //            if (ddlPreferCourseMode.Items[i].Selected == true)
            //            { oDr["PreferredCourseMode"] = oDr["PreferredCourseMode"].ToString() + ddlPreferCourseMode.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }


            //        oDr["EmpDesignation"] = txtDesignation_student.Value.ToString().Trim().Replace("'", "");
            //        if (txtBasicSalary_student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["EmpSalary"] = Convert.ToInt32(txtBasicSalary_student.Value.ToString().Trim().Replace("'", "")); }
            //        else
            //        { oDr["EmpSalary"] = 0; }
            //        oDr["EmpStatus"] = ddlEmploymentStatus.Items[ddlEmploymentStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Remarks"] = txtRemarks_Student.Value.ToString().Trim().Replace("'", "");
            //        if (chkInActive_Student.Checked == true)
            //        {
            //            oDr["InActive"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["InActive"] = "N";
            //        }
            //        if (chkSendSMS_Student.Checked == true)
            //        {
            //            oDr["ActiveSMS"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveSMS"] = "N";
            //        }
            //        if (chkSendEmail_Student.Checked == true)
            //        {
            //            oDr["ActiveEMail"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveEMail"] = "N";
            //        }
            //        oDT_General.Rows.Add(oDr);
            //    }
            //    else
            //    {
            //        DataRow oDr = oDT_General.Rows[0];
            //        oDr["StudentCode"] = txtCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentName"] = txtName_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["StudentType"] = ddlStudentType.Items[ddlStudentType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDType"] = ddlIDType.Items[ddlIDType.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Nationality"] = ddlNationality.Items[ddlNationality.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["IDNumber"] = txtID_Student.Value.ToString().Trim().Replace("'", "");
            //        if (dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["DOB"] = DateTime.ParseExact(dtDateOfBirth_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["RegDate"] = DateTime.ParseExact(dtRegistration_Student.Value.ToString().Trim().Replace("'", ""), "dd/MM/yyyy", null); }
            //        oDr["Email"] = txtEmail_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact"] = txtContact1_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Contact2"] = txtContact2_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmergencyContact"] = txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Gender"] = ddlGender.Items[ddlGender.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["MStatus"] = ddlStatus.Items[ddlStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Race"] = ddlRace.Items[ddlRace.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Address"] = txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["PinCode"] = txtPinCode_Student.Value.ToString().Trim().Replace("'", "");
            //        oDr["LeadCode"] = lblLead_Student.Text.Trim().Replace("'", "");
            //        oDr["OtherSiteAccess"] = "";
            //        for (int i = 0; i < ddlOtherSiteAccess.Items.Count; i++)
            //        {
            //            if (ddlOtherSiteAccess.Items[i].Selected == true)
            //            { oDr["OtherSiteAccess"] = oDr["OtherSiteAccess"].ToString() + ddlOtherSiteAccess.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredLanguage1"] = "";
            //        for (int i = 0; i < ddlPrefferedLanguage.Items.Count; i++)
            //        {
            //            if (ddlPrefferedLanguage.Items[i].Selected == true)
            //            { oDr["PreferredLanguage1"] = oDr["PreferredLanguage1"].ToString() + ddlPrefferedLanguage.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredType"] = "";
            //        for (int i = 0; i < ddlPrefferedType.Items.Count; i++)
            //        {
            //            if (ddlPrefferedType.Items[i].Selected == true)
            //            { oDr["PreferredType"] = oDr["PreferredType"].ToString() + ddlPrefferedType.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["NextProgression"] = ddlNextProgression.Items[ddlNextProgression.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpName"] = ddlEmployerName_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["EmpNameNone"] = txtEmployerNameNone_student.Value.ToString().Trim().Replace("'", "");
            //        oDr["Academic"] = ddlAcademic.Items[ddlAcademic.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["PreferredCourseCategory"] = "";
            //        for (int i = 0; i < ddlPreferCoursecategory.Items.Count; i++)
            //        {
            //            if (ddlPreferCoursecategory.Items[i].Selected == true)
            //            { oDr["PreferredCourseCategory"] = oDr["PreferredCourseCategory"].ToString() + ddlPreferCoursecategory.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["PreferredCourseMode"] = "";
            //        for (int i = 0; i < ddlPreferCourseMode.Items.Count; i++)
            //        {
            //            if (ddlPreferCourseMode.Items[i].Selected == true)
            //            { oDr["PreferredCourseMode"] = oDr["PreferredCourseMode"].ToString() + ddlPreferCourseMode.Items[i].Value.ToString().Trim().Replace("'", "") + ","; }
            //        }
            //        oDr["EmpDesignation"] = txtDesignation_student.Value.ToString().Trim().Replace("'", "");
            //        if (txtBasicSalary_student.Value.ToString().Trim().Replace("'", "") != "")
            //        { oDr["EmpSalary"] = Convert.ToInt32(txtBasicSalary_student.Value.ToString().Trim().Replace("'", "")); }
            //        else
            //        { oDr["EmpSalary"] = 0; }
            //        oDr["EmpStatus"] = ddlEmploymentStatus.Items[ddlEmploymentStatus.SelectedIndex].Value.ToString().Trim().Replace("'", "");
            //        oDr["Remarks"] = txtRemarks_Student.Value.ToString().Trim().Replace("'", "");
            //        if (chkInActive_Student.Checked == true)
            //        {
            //            oDr["InActive"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["InActive"] = "N";
            //        }
            //        if (chkSendSMS_Student.Checked == true)
            //        {
            //            oDr["ActiveSMS"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveSMS"] = "N";
            //        }
            //        if (chkSendEmail_Student.Checked == true)
            //        {
            //            oDr["ActiveEMail"] = "Y";
            //        }
            //        else
            //        {
            //            oDr["ActiveEMail"] = "N";
            //        }
            //        oDr.AcceptChanges();
            //        oDT_General.AcceptChanges();
            //    }

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            bool _RetVal = false;
            return _RetVal;
            //try
            //{
            //    if (txtCode_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        txtCode_Student.Value = oCommonEngine.GetAutoGenerateCode(strUserCode, strSiteCode, "Student");
            //    }
            //    if (txtName_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Name...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (dtRegistration_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Registration Date...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlIDType.Items[ddlIDType.SelectedIndex].Value.Trim().Replace("'", "") == "-" && btnOperation.InnerText=="Add")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Valid ID Type...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtID_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter ID Number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtContact1_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Hand phone number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtEmergencyContact_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Emergency Contact number...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtEmail_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter EMail...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtBilltoAddress_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter Address...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtPinCode_Student.Value.ToString().Trim().Replace("'", "") == "")
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please enter PinCode...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }

            //    if (ddlPrefferedType.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Type...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPrefferedLanguage.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Language...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPreferCourseMode.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Course Mode...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (ddlPreferCoursecategory.SelectedIndex == -1)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Please Select Preffered Course Category...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (oCommonEngine.IsValidEmail(txtEmail_Student.Value.ToString().Trim().Replace("'", "")) && oCommonEngine.ExecuteQueryHasRows("Select StudentCode from StudentMaster Where StudentCode<>'" + txtCode_Student.Value.ToString().Trim() + "' And EMail='" + txtEmail_Student.Value.ToString().Trim().Replace("'", "") + "'") == true)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "EMail Already Exist in Student Data...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    if (txtContact1_Student.Value != "123" && oCommonEngine.ExecuteQueryHasRows("Select StudentCode from StudentMaster Where StudentCode<>'" + txtCode_Student.Value.ToString().Trim() + "' And Contact='" + txtContact1_Student.Value.ToString().Trim().Replace("'", "") + "'") == true)
            //    {
            //        oCommonEngine.SetAlert(this.Page, "Mobile 1 Already Exist in Student Data...!", Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //        return _RetVal;
            //    }
            //    _RetVal = true;
            //    return _RetVal;
            //}
            //catch (Exception Ex)
            //{
            //    oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            //    return _RetVal;
            //}
        }
        #endregion

        #region Update Table

        [WebMethod]
        public static void RemoveAttachment(string Index)
        {
            DataTable oDT_Static_StudentMaster = new DataTable();
            oDT_Static_StudentMaster = null;
            oDT_Static_StudentMaster = (DataTable)HttpContext.Current.Session["oDT_atStudent"];
            oDT_Static_StudentMaster.Rows.RemoveAt(Convert.ToInt32(Index) - 1);
            HttpContext.Current.Session["oDT_atStudent"] = oDT_Static_StudentMaster;
            oDT_Static_StudentMaster = null;

        }
        [WebMethod]
        public static void AddAttachment(string SourcePath)
        {
            DataTable oDT_Static_StudentMaster = new DataTable();
            oDT_Static_StudentMaster = null;
            oDT_Static_StudentMaster = (DataTable)HttpContext.Current.Session["oDT_atStudent"];
            DataRow oDr = oDT_Static_StudentMaster.NewRow();
            oDr["Document"] = "Student";
            oDr["ServerPath"] = (string)HttpContext.Current.Session["AttachmentPath"];
            oDr["FileInfo"] = SourcePath;
            oDr["Existing"] = "N";

            oDT_Static_StudentMaster.Rows.Add(oDr);
            HttpContext.Current.Session["oDT_atStudent"] = oDT_Static_StudentMaster;
            oDT_Static_StudentMaster = null;
        }
        #endregion

        #region Load HTML Table
        private void LoadHTMLTable()
        {
            //try
            //{

            //    oDT_atStudent = (DataTable)Session["oDT_atStudent"];
            //    if (oDT_atStudent.Rows.Count > 0 && atStudent.Rows.Count == 1)
            //    {

            //        for (int i = 0; i < oDT_atStudent.Rows.Count; i++)
            //        {
            //            HtmlTableRow _Row = new HtmlTableRow();
            //            HtmlTableCell Col_1 = new HtmlTableCell();
            //            Col_1.InnerText = oDT_atStudent.Rows[i]["FileInfo"].ToString();
            //            _Row.Controls.Add(Col_1);
            //            HtmlTableCell Col_2 = new HtmlTableCell();
            //            Col_2.Attributes.Add("style", "width: 20%; text-align:center");
            //            Col_2.InnerHtml = "<div class='tools'><i class='Download_Attachments_Student glyphicon glyphicon-download-alt'></i><i class='Remove_Attachments_Student glyphicon glyphicon-trash'></i></div>";
            //            _Row.Controls.Add(Col_2);
            //            atStudent.Rows.Add(_Row);
            //        }
            //    }


            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #region Upload File
        private void UploadFile()
        {
            //try
            //{
            //    string strDirectory = (string)HttpContext.Current.Session["AttachmentPath"].ToString().Trim() + "/" + txtCode_Student.Value;
            //    if (System.IO.Directory.Exists(strDirectory) ==false)
            //    {
            //        System.IO.Directory.CreateDirectory(strDirectory);
            //    }
            //    HttpFileCollection flImages = Request.Files;
            //    foreach (string _key in flImages.Keys)
            //    {
            //        HttpPostedFile flFile = flImages[_key];
            //        if (flFile.FileName != "")
            //        {
            //            string _Path =Path.Combine(strDirectory,  flFile.FileName);
            //            flFile.SaveAs(_Path);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Server.ScriptTimeout = 300;
            try
            {
                //if (Session["AlertMessage"] != null)
                //{
                //    oCommonEngine.SetAlert(this.Page, Session["AlertMessage"].ToString(), Utilities.CommonEngine.MessageType.Success, Utilities.CommonEngine.MessageDuration.Short);
                //    Session["AlertMessage"] = null;
                //}
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
                    LoadValue();
                    LoadPageInformations();

                    if (Request.QueryString["PKey"] != null)
                    {
                        _PKey = Request.QueryString["PKey"].ToString();
                        btnSubmit_AddItemMaster.InnerText = "Update";
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            //GET Method  
                            string api = "api/stocks?filter={\"where\":{\"itemCode\":\"" + _PKey + "\"}}";
                            var response = client.GetAsync(api).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var a = response.Content.ReadAsStringAsync().Result;
                                List<itemMasInput> itemMasResult = JsonConvert.DeserializeObject<List<itemMasInput>>(a);
                                ddl_Div.Value = itemMasResult[0].itemDiv + "-" + itemMasResult[0].itemDivIdId;
                                ddl_Div.Disabled = true;
                                if (itemMasResult[0].itemDiv == "1")
                                {
                                    
                                }
                                txt_RunningNo1.Value = itemMasResult[0].itemCode.Substring(0, 3);
                                txt_RunningNo2.Value = itemMasResult[0].itemCode.Substring(3, itemMasResult[0].itemCode.Length-3 );
                                ddl_Dept.Value = itemMasResult[0].itemDept + "-" + itemMasResult[0].itemDeptIdId;
                                ddl_Dept.Disabled = true;
                                ddl_Class.Value = itemMasResult[0].itemClass + "-" + itemMasResult[0].itemClassIdId;

                                string filter = "";
                                if (itemMasResult[0].itemDiv == "1")
                                    filter = "retailProductBrand";
                                else if (itemMasResult[0].itemDiv == "2")
                                    filter = "retailProductBrand";
                                else if (itemMasResult[0].itemDiv == "3")
                                    filter = "itmstatus";
                                else if (itemMasResult[0].itemDiv == "4")
                                    filter = "voucherBrand";
                                else if (itemMasResult[0].itemDiv == "5")
                                    filter = "prepaidBrand";
                                else
                                    filter = "itmStatus";

                                //oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemBrands?filter={\"where\":{\"" + filter + "\":\"" + 1 + "\",\"itmStatus\":\"True\"}}"), (typeof(DataTable)));
                               List<itemBrandsFetch> itemBrands = JsonConvert.DeserializeObject<List<itemBrandsFetch>>(GetapiCalling("api/ItemBrands?filter={\"where\":{\"" + filter + "\":\"" + 1 + "\",\"itmStatus\":\"True\"}}"));
                               ddl_Brand.Items.Clear();
                               ddl_Brand.Items.Add(new ListItem("Select your option", ""));
                               for(int i=0; i < itemBrands.Count; i++)
                                {
                                    ddl_Brand.Items.Add(new ListItem(itemBrands[i].itmDesc, itemBrands[i].itmCode));
                                }

                                ddl_Brand.Value = itemMasResult[0].itemBrand;

                                filter = "";
                                if (itemMasResult[0].itemDiv == "1")
                                    filter = "isproduct";
                                else if (itemMasResult[0].itemDiv == "2")
                                    filter = "isproduct";
                                else if (itemMasResult[0].itemDiv == "3")
                                    filter = "isservice";
                                else if (itemMasResult[0].itemDiv == "4")
                                    filter = "isvoucher";
                                else if (itemMasResult[0].itemDiv == "5")
                                    filter = "isprepaid";
                                else
                                    filter = "isproduct";

                                if (itemMasResult[0].itemDiv == "3")
                                {
                                    List<itemRangesFetch> itemRanges = JsonConvert.DeserializeObject<List<itemRangesFetch>>(GetapiCalling("api/ItemRanges?filter={\"where\":{\"" + filter + "\":\"" + 1 + "\",\"itmStatus\":\"True\",\"itmDept\":\"" + itemMasResult[0].itemDept + "\"}}"));
                                    ddl_Range.Items.Clear();
                                    ddl_Range.Items.Add(new ListItem("Select your option", ""));
                                    for (int i = 0; i < itemRanges.Count; i++)
                                    {
                                        ddl_Range.Items.Add(new ListItem(itemRanges[i].itmDesc, itemRanges[i].itmCode + "-" + itemRanges[i].itmId));
                                    }
                                }
                                else
                                {
                                    List<itemRangesFetch> itemRanges = JsonConvert.DeserializeObject<List<itemRangesFetch>>(GetapiCalling("api/ItemRanges?filter={\"where\":{\"" + filter + "\":\"" + 1 + "\",\"itmStatus\":\"True\",\"itmBrand\":\"" + itemMasResult[0].itemBrand + "\"}}"));
                                    ddl_Range.Items.Clear();
                                    ddl_Range.Items.Add(new ListItem("Select your option", ""));
                                    for (int i = 0; i < itemRanges.Count; i++)
                                    {
                                        ddl_Range.Items.Add(new ListItem(itemRanges[i].itmDesc, itemRanges[i].itmCode + "-" + itemRanges[i].itmId));
                                    }
                                }


                                ddl_Range.Value = itemMasResult[0].itemRange + "-" + itemMasResult[0].itemRangeIdId;
                                txt_StockName.Value = itemMasResult[0].itemName;
                                txt_StockDesc.Value = itemMasResult[0].itemDesc;

                                List<itemTypesFetch> itemTypes = JsonConvert.DeserializeObject<List<itemTypesFetch>>(GetapiCalling("api/ItemTypes"));
                                ddl_stockType.Items.Clear();
                                for (int i = 0; i < itemTypes.Count; i++)
                                {
                                    ddl_stockType.Items.Add(new ListItem(itemTypes[i].itmName, itemTypes[i].itmId));
                                }

                                if (!string.IsNullOrEmpty(itemMasResult[0].itemTypeIdId))
                                {
                                    ddl_stockType.Value = itemMasResult[0].itemTypeIdId;
                                }


                                if (ddl_stockType.Items[ddl_stockType.SelectedIndex].Text == "SINGLE")
                                {
                                    divPackage.Style.Add("display", "none");
                                    divPackageHeader.Style.Add("display", "none");
                                    brid10_ItemMaster.Style.Add("display", "none");
                                    ///ddl_stockType.SelectedIndex = 0;
                                }
                                else if(ddl_stockType.Items[ddl_stockType.SelectedIndex].Text == "PACKAGE")
                                {
                                    divPackage.Style.Add("display", "");
                                    divPackageHeader.Style.Add("display", "");
                                    brid10_ItemMaster.Style.Add("display", "");
                                    //ddl_stockType.SelectedIndex = 1;
                                }
                                else if (ddl_stockType.Items[ddl_stockType.SelectedIndex].Text == "COURSE")
                                {
                                    divPackage.Style.Add("display", "none");
                                    divPackageHeader.Style.Add("display", "none");
                                    brid10_ItemMaster.Style.Add("display", "none");

                                    divService.Style.Add("display", "");
                                    divServiceHeader.Style.Add("display", "");
                                    brid8_ItemMaster.Style.Add("display", "");

                                    //ddl_stockType.SelectedIndex = 2;
                                }

                                ddl_supplier.Value = itemMasResult[0].itemSupp;

                                //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "stockChange()", true);
                                if (itemMasResult[0].limitserviceFlexionly == true)
                                {
                                    chk_AutoAddOpenCode.Checked = true;
                                }
                                else
                                {
                                    chk_AutoAddOpenCode.Checked = false;
                                }
                                if (itemMasResult[0].isOpenPrepaid == true)
                                {
                                    chk_openPrepaid.Checked = true;
                                }
                                else
                                {
                                    chk_openPrepaid.Checked = false;
                                }
                                txt_price.Value = itemMasResult[0].itemPrice;
                                txt_floorPrice.Value = itemMasResult[0].itemPriceFloor;
                                txt_Cost.Value = itemMasResult[0].costPrice;
                                txt_DurationMinutes.Value = itemMasResult[0].srvDuration;
                                txt_Disc.Value = itemMasResult[0].disclimit;
                                txt_Cost.Value = itemMasResult[0].serviceCost;
                                if (itemMasResult[0].serviceCostPercent == true)
                                {
                                    chk_Percent.Checked = true;
                                }
                                else
                                {
                                    chk_Percent.Checked = false;
                                }

                                if (itemMasResult[0].disctypeamount == true)
                                {
                                    chk_discType.Checked = true;
                                }
                                else
                                {
                                    chk_discType.Checked = false;
                                }
                                if (itemMasResult[0].autocustdisc == true)
                                {
                                    chk_AutoCustDisc.Checked = true;
                                }
                                else
                                {
                                    chk_AutoCustDisc.Checked = false;
                                }
                                if (itemMasResult[0].itemIsactive == true)
                                {
                                    chk_Active.Checked = true;
                                }
                                else
                                {
                                    chk_Active.Checked = false;
                                }
                                if (itemMasResult[0].commissionable == true)
                                {
                                    chk_Commissionable.Checked = true;
                                    divCommissionHeader.Style.Add("display", "");
                                    divCommission.Style.Add("display", "");
                                    brid13_ItemMaster.Style.Add("display", "");
                                }
                                else
                                {
                                    chk_Commissionable.Checked = false;
                                    divCommissionHeader.Style.Add("display", "none");
                                    divCommission.Style.Add("display", "none");
                                    brid13_ItemMaster.Style.Add("display", "none");
                                    //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "CommisionClick(false)", true);
                                }
                                if (itemMasResult[0].itemFoc == true)
                                {
                                    chk_RedeemItem.Checked = true;
                                }
                                else
                                {
                                    chk_RedeemItem.Checked = false;
                                }
                                if (itemMasResult[0].isHaveTax == true)
                                {
                                    chk_Tax.Checked = true;
                                }
                                else
                                {
                                    chk_Tax.Checked = false;
                                }
                                if (itemMasResult[0].isGst == true)
                                {
                                    chk_Tax.Checked = true;
                                    divTaxHeader.Style.Add("display", "");
                                    divTax.Style.Add("display", "");
                                    brid11_ItemMaster.Style.Add("display", "");
                                }
                                else
                                {
                                    chk_Tax.Checked = false;
                                    divTaxHeader.Style.Add("display", "none");
                                    divTax.Style.Add("display", "none");
                                    brid11_ItemMaster.Style.Add("display", "none");
                                }
                                if (itemMasResult[0].isAllowFoc == true)
                               {
                                    chk_ItemallowFOC.Checked = true;
                               }
                                else
                                {
                                    chk_ItemallowFOC.Checked = false;
                                }
                                txt_AccCodeItemMaster.Value = itemMasResult[0].accountCode;
                                if (itemMasResult[0].voucherIsvalidUntilDate == true)
                                {
                                    chk_VoucherValidItemMaster.Checked = true;
                                }
                                else
                                {
                                    chk_VoucherValidItemMaster.Checked = false;
                                }

                                if(!string.IsNullOrEmpty(itemMasResult[0].voucherValidUntilDate))
                                    dt_VoucherValItemMaster.Value = Convert.ToDateTime(itemMasResult[0].voucherValidUntilDate).ToString("dd/MM/yyyy");

                                txtVouValueItemMaster.Value = itemMasResult[0].voucherValue;
                                if (itemMasResult[0].voucherValueIsAmount == true)
                                {
                                    option_Percent_ItemMaster.Checked = true;
                                }
                                else
                                {
                                    option_Amount_ItemMaster.Checked = true;
                                }
                                ddl_ValidityPeriodItemMaster.Value = itemMasResult[0].voucherValidPeriod;
                                ddl_ValidPeriodItemMaster.Value = itemMasResult[0].prepaidValidPeriod;
                                if (itemMasResult[0].membercardnoaccess == true)
                                {
                                    chk_MemberCardItemMaster.Checked = true;
                                }
                                else
                                {
                                    chk_MemberCardItemMaster.Checked = false;
                                }
                                txt_PrepaidValue.Value = itemMasResult[0].prepaidValue;
                                txt_PrepaidAmnt.Value = itemMasResult[0].prepaidSellAmt;
                                if (itemMasResult[0].reorderActive == true)
                                {
                                    chk_ReorderLevelItemMaster.Checked = true;
                                }
                                else
                                {
                                    chk_ReorderLevelItemMaster.Checked = false;
                                }
                                txt_minQtyItemMaster.Value = itemMasResult[0].reorderMinqty;
                                txt_ReplenishmentItemMaster.Value = itemMasResult[0].custReplenishDays;
                                txt_RemindAdvItemMaster.Value = itemMasResult[0].custAdvanceDays;
                                if (itemMasResult[0].trading == true)
                                {
                                    chk_ReplenishmentItemMaster.Checked = true;
                                }
                                else
                                {
                                    chk_ReplenishmentItemMaster.Checked = false;
                                }

                                ddlWorkCommGroup_itemMaster.Value = itemMasResult[0].workcomm;
                                ddlSalesCommGroup_itemMaster.Value = itemMasResult[0].salescomm;
                                txtworkPoints_ItemMaster.Value = itemMasResult[0].workcommpoints;
                                txtSalesPoints_ItemMaster.Value = itemMasResult[0].salescommpoints;
                                if (itemMasResult[0].serviceExpireActive == true)
                                {
                                    chkExpiryStatus_ItemMaster.Checked = true;
                                    txtserviceExpiryMonth_ItemMaster.Visible = true;
                                    txtserviceExpiryMonth_ItemMaster.Value = itemMasResult[0].serviceExpireMonth;
                                }
                                else
                                {
                                    chkExpiryStatus_ItemMaster.Checked = false;
                                }
                                if (itemMasResult[0].treatmentLimitActive == true)
                                {
                                    chkServiceLimit_ItemMaster.Checked = true;
                                    txtServiceLimit_ItemMaster.Visible = true;
                                    txtServiceLimit_ItemMaster.Value = itemMasResult[0].treatmentLimitCount;
                                }
                                else
                                {
                                    chkServiceLimit_ItemMaster.Checked = false;
                                }
                                if (itemMasResult[0].limitserviceFlexionly == true)
                                {
                                    chkServiceFlexi_ItemMaster.Checked = true;
                                    
                                }
                                else
                                {
                                    chkServiceFlexi_ItemMaster.Checked = false;
                                }
                                //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "SeviceChange()", true);
                                this.ClientScript.RegisterStartupScript(this.GetType(), "test", "DivChange()", true);

                                ddl1stTax_ItemMaster.Value = itemMasResult[0].t1TaxCode;
                                ddl2ndTax_ItemMaster.Value = itemMasResult[0].t2TaxCode;


                            }
                            else
                            {
                                Console.WriteLine("Internal server Error");
                            }
                        }

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            //GET Method  
                            string api = "api/PackageHdrs?filter={\"where\":{\"code\":\"" + _PKey + "\"}}";
                            var response = client.GetAsync(api).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var a = response.Content.ReadAsStringAsync().Result;
                                List<PackageHdrsInput> itemMasResult = JsonConvert.DeserializeObject<List<PackageHdrsInput>>(a);
                                if (itemMasResult.Count > 0)
                                {
                                    if (Convert.ToString(itemMasResult[0].istdt).ToUpper() == "TRUE")
                                    {
                                        chkApptTDT_ItemMaster.Checked = true;
                                    }
                                    else
                                    {
                                        chkApptTDT_ItemMaster.Checked = false;
                                    }
                                    dtFromDatePackage_ItemMaster.Value = Convert.ToDateTime(itemMasResult[0].fromDate).ToString("dd-MM-yyyy");
                                    dtToDatePackage_ItemMaster.Value = Convert.ToDateTime(itemMasResult[0].toDate).ToString("dd-MM-yyyy");
                                    dtFromTimePackage_ItemMaster.Value = itemMasResult[0].fromTime;
                                    dtToTimePackage_ItemMaster.Value = itemMasResult[0].toTime;

                                    txtcontentTot_ItemMaster.Value = itemMasResult[0].unitPrice;
                                    txtDiscAmnt_ItemMaster.Value = itemMasResult[0].discount;
                                    txtPackageTot_ItemMaster.Value = itemMasResult[0].price;

                                    string timeFromInHHMM = Convert.ToString(itemMasResult[0].fromTime).Substring(11, 5);
                                    string timeToInHHMM = Convert.ToString(itemMasResult[0].toTime).Substring(11, 5);

                                    if(Int32.Parse(timeFromInHHMM.Substring(0,2)) > 12)
                                    {
                                        dtFromTimePackage_ItemMaster.Value = Convert.ToString(Int32.Parse(timeFromInHHMM.Substring(0, 2)) - 12) + ":" + timeFromInHHMM.Substring(3, 2) + " PM";
                                    }
                                    else
                                    {
                                        dtFromTimePackage_ItemMaster.Value = timeFromInHHMM.Substring(0, 2) + ":" + timeFromInHHMM.Substring(3, 2) + " AM";
                                    }

                                    if (Int32.Parse(timeToInHHMM.Substring(0, 2)) > 12)
                                    {
                                        dtToTimePackage_ItemMaster.Value = Convert.ToString(Int32.Parse(timeToInHHMM.Substring(0, 2)) - 12) + ":" + timeToInHHMM.Substring(3, 2) + " PM";
                                    }
                                    else
                                    {
                                        dtToTimePackage_ItemMaster.Value = timeToInHHMM.Substring(0, 2) + ":" + timeToInHHMM.Substring(3, 2) + " AM";
                                    }


                                    if (Convert.ToString(itemMasResult[0].manualDisc).ToUpper() == "TRUE")
                                    {
                                        option_Manual_ItemMaster.Checked = true;
                                    }
                                    else
                                    {
                                        option_EvenlyAvg_ItemMaster.Checked = true;
                                    }

                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Internal server Error");
                            }
                        }

                        List<Data> itemUOM = JsonConvert.DeserializeObject<List<Data>>(GetapiCalling("api/ItemUomprices?filter={\"where\":{\"itemCode\":\"" + _PKey + "\"}}"));
                        if (itemUOM.Count> 0 && UOMModule.Rows.Count == 1)
                        {
                            for (int i = 0; i < itemUOM.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.Attributes.Add("style", "width: 10 %");
                                int a = i + 1;
                                Col_1.InnerText = a.ToString() ;
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.Attributes.Add("style", "width: 15 %");   
                                Col_2.InnerText = itemUOM[i].itemUom;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.Attributes.Add("style", "width: 15 %");
                                Col_3.InnerText = itemUOM[i].uomDesc;
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.Attributes.Add("style", "width: 10 %");
                                Col_4.InnerText = "=";
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.Attributes.Add("style", "width: 15 %");
                                Col_5.InnerText = itemUOM[i].uomUnit;
                                _Row.Controls.Add(Col_5);

                                HtmlTableCell Col_6 = new HtmlTableCell();
                                Col_6.Attributes.Add("style", "width: 15 %");
                                Col_6.InnerText = itemUOM[i].itemUom2;
                                _Row.Controls.Add(Col_6);

                                HtmlTableCell Col_7 = new HtmlTableCell();
                                Col_7.Attributes.Add("style", "width: 15 %");
                                Col_7.InnerText = itemUOM[i].uom2Desc;
                                _Row.Controls.Add(Col_7);

                                HtmlTableCell Col_8 = new HtmlTableCell();
                                Col_8.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_8.InnerHtml = "<div class='tools'><i class='Remove_mdlAddUOM glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_8);

                                HtmlTableCell Col_9 = new HtmlTableCell();
                                Col_9.Attributes.Add("style", "width: 20 %");
                                //EntryCol_3.InnerHtml = "<input type='checkbox' checked class='chk_mdlClassificationMaster editor - active' >";
                                //EntryCol_3.InnerHtml = "<input type='number' class=form-control' >";
                                Col_9.InnerHtml = "<input type='hidden' class=form-control' value=" + itemUOM[i].id + " id='txthiddenId_ItemUomprices' runat='server'>";
                               _Row.Controls.Add(Col_9);

                                UOMModule.Rows.Add(_Row);

                                HtmlTableRow _EntryRow = new HtmlTableRow();
                                HtmlTableCell EntryCol_1 = new HtmlTableCell();
                                EntryCol_1.Attributes.Add("style", "width: 10 %");
                                EntryCol_1.InnerText = a.ToString();
                                _EntryRow.Controls.Add(EntryCol_1);

                                HtmlTableCell EntryCol_2 = new HtmlTableCell();
                                EntryCol_2.Attributes.Add("style", "width: 15 %");
                                EntryCol_2.InnerText = itemUOM[i].uomDesc;
                                _EntryRow.Controls.Add(EntryCol_2);

                                HtmlTableCell EntryCol_3 = new HtmlTableCell();
                                EntryCol_3.Attributes.Add("style", "width: 20 %");
                                //EntryCol_3.InnerHtml = "<input type='checkbox' checked class='chk_mdlClassificationMaster editor - active' >";
                                //EntryCol_3.InnerHtml = "<input type='number' class=form-control' >";
                                EntryCol_3.InnerHtml = "<input type='number' class=form-control' value=" + itemUOM[i].itemPrice + " id='txtPrice_ItemMaster' runat='server'>";
                                _EntryRow.Controls.Add(EntryCol_3);

                                //HtmlTableCell EntryCol_3 = new HtmlTableCell();
                                //EntryCol_3.Attributes.Add("style", "width: 15 %");
                                //EntryCol_3.InnerText = "<input type='number' style='width: 100 %; Height: 30px; value=" + itemUOM[i].itemPrice + "  class='form - control' id='txtPrice_ItemMaster' runat='server' maxlength='255' placeholder='Enter Price'>";
                                //_EntryRow.Controls.Add(EntryCol_3);

                                HtmlTableCell EntryCol_4 = new HtmlTableCell();
                                EntryCol_4.Attributes.Add("style", "width: 20 %");
                                //string HtmlContent = "<input type='number' style='width: 100 %; Height: 30px; value=" + itemUOM[i].itemCost + "  class='form - control' id='txtPrice_ItemMaster' runat='server' maxlength='255' placeholder='Enter Price'>";
                                //EntryCol_4.Controls.Add(new Literal() { Text = HtmlContent });
                                EntryCol_4.InnerHtml = "<input type='number' class=form-control' value=" + itemUOM[i].itemCost + " id='txtCost_ItemMaster' runat='server'>";
                                _EntryRow.Controls.Add(EntryCol_4);

                                HtmlTableCell EntryCol_5 = new HtmlTableCell();
                                EntryCol_5.Attributes.Add("style", "width: 20 %");
                                EntryCol_5.InnerHtml = "<input type='number' class=form-control' value=" + itemUOM[i].minMargin + " id='txtMargin_ItemMaster' runat='server'>";
                                _EntryRow.Controls.Add(EntryCol_5);

                                HtmlTableCell EntryCol_6 = new HtmlTableCell();
                                EntryCol_6.Attributes.Add("style", "width: 10%; text-align:center");
                                EntryCol_6.InnerHtml = "<div class='tools'><i class='Remove_mdlAddUOMEntry glyphicon glyphicon-trash'></i></div>";
                                _EntryRow.Controls.Add(EntryCol_6);
                                UOMEntryModule.Rows.Add(_EntryRow);

                            }
                        }

                        string pkey1 = _PKey + "0000";
                        List<linkData> itemLink = JsonConvert.DeserializeObject<List<linkData>>(GetapiCalling("api/Itemlinks?filter={\"where\":{\"itemCode\":\"" + pkey1 + "\"}}"));
                        if (itemLink.Count > 0 && LinkModule.Rows.Count == 1)
                        {
                            for (int i = 0; i < itemLink.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.InnerText = itemLink[i].linkCode;
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.InnerText = itemLink[i].linkDesc;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.InnerText = "";
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_4.InnerHtml = "<div class='tools'><i class='edit_mdlAddLink glyphicon glyphicon-pencil'></i></div>";
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.InnerHtml = "<input type='hidden' class=form-control' value=" + itemLink[i].itmId + " id='txthiddenId_Itemlinks' runat='server'>";
                                _Row.Controls.Add(Col_5);

                                LinkModule.Rows.Add(_Row);

                            }
                        }

                        List<ServiceData> servicedt = JsonConvert.DeserializeObject<List<ServiceData>>(GetapiCalling("api/ItemFlexiservices?filter={\"where\":{\"itemCode\":\"" + _PKey + "\"}}"));
                        if (servicedt.Count > 0 && ServiceAvailabe.Rows.Count == 1)
                        {
                            for (int i = 0; i < servicedt.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.Attributes.Add("style", "width: 20%; text-align:left");
                                Col_1.InnerText = (i+1).ToString();
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.Attributes.Add("style", "width: 30%; text-align:left");
                                Col_2.InnerText = servicedt[i].itemSrvdesc;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.Attributes.Add("style", "width: 40%; text-align:left");
                                Col_3.InnerText = servicedt[i].itemSrvcode.Remove(servicedt[i].itemSrvcode.Length - 4) ;
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.Attributes.Add("style", "width: 20%; text-align:center");
                                Col_4.InnerHtml = "<div class='tools'><i class='Remove_AddItemToServiceAfterSave glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.Attributes.Add("style", "width: 0 % ;visibility:hidden;");
                                Col_5.InnerHtml = "<input type='hidden' class=form-control' value=" + servicedt[i].itmId + " id='txthiddenId_ItemServices' runat='server'>";
                                _Row.Controls.Add(Col_5);

                                ServiceAvailabe.Rows.Add(_Row);

                            }
                        }

                        List<PackageDtlsInput> packagedt = JsonConvert.DeserializeObject<List<PackageDtlsInput>>(GetapiCalling("api/PackageDtls?filter={\"where\":{\"packageCode\":\"" + _PKey + "\"}}"));
                        if (packagedt.Count > 0 && PackageEntryModule.Rows.Count == 1)
                        {
                            for (int i = 0; i < packagedt.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.Attributes.Add("style", "width: 8%; text-align:left");
                                Col_1.InnerText = packagedt[i].code.Remove(packagedt[i].code.Length - 4);
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.Attributes.Add("style", "width: 20%; text-align:left");
                                Col_2.InnerText = packagedt[i].description;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.Attributes.Add("style", "width: 7%; text-align:left");
                                Col_3.InnerText = packagedt[i].qty;
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.Attributes.Add("style", "width: 7%; text-align:left");
                                Col_4.InnerText = packagedt[i].unitPrice;
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.Attributes.Add("style", "width: 10%; text-align:left");
                                Col_5.InnerText = packagedt[i].ttlUprice;
                                _Row.Controls.Add(Col_5);


                                HtmlTableCell Col_6 = new HtmlTableCell();
                                Col_6.Attributes.Add("style", "width: 10%; text-align:left");
                                Col_6.InnerText = packagedt[i].discount;
                                _Row.Controls.Add(Col_6);

                                HtmlTableCell Col_7 = new HtmlTableCell();
                                Col_7.Attributes.Add("style", "width: 7%; text-align:left");
                                Col_7.InnerText = String.Format("{0:0.00}", float.Parse(packagedt[i].price));
                                _Row.Controls.Add(Col_7);

                                Col_7 = new HtmlTableCell();
                                Col_7.Attributes.Add("style", "width: 9%; text-align:left");
                                Col_7.InnerText = Convert.ToString(float.Parse(packagedt[i].qty) * float.Parse(packagedt[i].price));
                                _Row.Controls.Add(Col_7);

                                HtmlTableCell Col_8 = new HtmlTableCell();
                                Col_8.Attributes.Add("style", "width: 7%; text-align:left");
                                Col_8.InnerText = packagedt[i].uom;
                                _Row.Controls.Add(Col_8);

                                Col_8 = new HtmlTableCell();
                                Col_8.Attributes.Add("style", "width: 5%; text-align:left");
                                Col_8.InnerText = packagedt[i].isactive == true? "Yes":"No";
                                _Row.Controls.Add(Col_8);

                                if(packagedt[i].isactive == false)
                                {
                                    _Row.Attributes.Add("style", "color: red;");
                                }

                                Col_8 = new HtmlTableCell();
                                Col_8.Attributes.Add("style", "width: 0% ;display:none;");
                                Col_8.InnerText = packagedt[i].itemDiv;
                                _Row.Controls.Add(Col_8);

                                HtmlTableCell Col_9  = new HtmlTableCell();
                                Col_9.Attributes.Add("style", "width: 0 % ;display:none;");
                                Col_9.InnerText = packagedt[i].ID;  // "<input type='hidden' class=form-control' value=" + packagedt[i].ID + " id='txthiddenId_ItemPackage' runat='server'>";
                                _Row.Controls.Add(Col_9);

                                Col_9 = new HtmlTableCell();
                                Col_9.Attributes.Add("style", "width: 0 % ;display:none;");
                                Col_9.InnerText = Convert.ToString(i+1);  
                                _Row.Controls.Add(Col_9);

                                HtmlTableCell Col_10 = new HtmlTableCell();
                                Col_10.Attributes.Add("style", "width: 20%; text-align:center");
                                Col_10.InnerHtml = "<div class='tools'><i class='Edit_AddItemToPackage glyphicon glyphicon-pencil'></i></div>";
                                _Row.Controls.Add(Col_10);

                                PackageEntryModule.Rows.Add(_Row);

                            }
                        }

                        List<stockListingData> itemStockListing = JsonConvert.DeserializeObject<List<stockListingData>>(GetapiCalling("api/ItemStocklists?filter={\"where\":{\"itemCode\":\"" + _PKey + "\"}}"));
                        if(itemStockListing.Count>0)
                        {
                            for (int i = 0; i < stockListingMaster.Rows.Count; i++)
                            {
                                string col2 = stockListingMaster.Rows[i].Cells[0].InnerHtml;
                                var _lst = itemStockListing.Where(x => x.itemsiteCode == col2 && x.itemstocklistStatus==true ).ToList();
                                if (_lst.Count > 0)
                                {
                                    stockListingMaster.Rows[i].Cells[2].InnerHtml = "<input type='checkbox' checked class='case'>";
                                }
                                else
                                {
                                    stockListingMaster.Rows[i].Cells[2].InnerHtml = "<input type='checkbox' class='case'>";
                                }
                            }
                        }

                        List<itemUsageLevel> itemUsage = JsonConvert.DeserializeObject<List<itemUsageLevel>>(GetapiCalling("api/usagelevels?filter={\"where\":{\"itemCode\":\"" + pkey1 + "\"}}"));
                        if (itemUsage.Count > 0 && ItemUsageMasterModule.Rows.Count == 1)
                        {
                            for (int i = 0; i < itemUsage.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.InnerText = itemUsage[i].serviceCode;
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.InnerText = itemUsage[i].serviceDesc;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.InnerText = itemUsage[i].qty;
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.InnerText = itemUsage[i].uom;
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_5.InnerHtml = "<div class='tools'><i class='Remove_mdlAddItemUOm glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_5);

                                HtmlTableCell Col_6 = new HtmlTableCell();
                                Col_6.InnerHtml = "<input type='hidden' class=form-control' value=" + itemUsage[i].id + " id='txthiddenId_usagelevels' runat='server'>";
                                _Row.Controls.Add(Col_6);

                                ItemUsageMasterModule.Rows.Add(_Row);

                            }

                        }

                        List<prepaidConditionsInput> itemPrepaidConditions = JsonConvert.DeserializeObject<List<prepaidConditionsInput>>(GetapiCalling("api/VoucherConditions?filter={\"where\":{\"itemCode\":\"" + _PKey + "\"}}"));
                        if (itemPrepaidConditions.Count > 0 && PrepaidCondModule.Rows.Count == 1)
                        {
                            for (int i = 0; i < itemPrepaidConditions.Count; i++)
                            {
                                HtmlTableRow _Row = new HtmlTableRow();
                                HtmlTableCell Col_1 = new HtmlTableCell();
                                Col_1.Attributes.Add("style", "width: 6%; text-align:center");
                                Col_1.InnerText = itemPrepaidConditions[i].pItemtype;
                                _Row.Controls.Add(Col_1);

                                HtmlTableCell Col_2 = new HtmlTableCell();
                                Col_2.Attributes.Add("style", "width: 6%; text-align:center");
                                Col_2.InnerText = itemPrepaidConditions[i].conditiontype1;
                                _Row.Controls.Add(Col_2);

                                HtmlTableCell Col_3 = new HtmlTableCell();
                                Col_3.Attributes.Add("style", "width: 6%; text-align:center");
                                Col_3.InnerText = itemPrepaidConditions[i].conditiontype2;
                                _Row.Controls.Add(Col_3);

                                HtmlTableCell Col_4 = new HtmlTableCell();
                                Col_4.Attributes.Add("style", "width: 7%; text-align:center");
                                Col_4.InnerText = itemPrepaidConditions[i].amount;
                                _Row.Controls.Add(Col_4);

                                HtmlTableCell Col_5 = new HtmlTableCell();
                                Col_5.Attributes.Add("style", "width: 7%; text-align:center");
                                Col_5.InnerText = itemPrepaidConditions[i].rate;
                                _Row.Controls.Add(Col_5);

                                HtmlTableCell Col_6 = new HtmlTableCell();
                                Col_6.Attributes.Add("style", "width: 10%; text-align:center");
                                Col_6.InnerHtml = "<div class='tools'><i class='Remove_PrepaidCondModule glyphicon glyphicon-trash'></i></div>";
                                _Row.Controls.Add(Col_6);

                                HtmlTableCell Col_7 = new HtmlTableCell();
                                Col_7.InnerHtml = "<input type='hidden' class=form-control' value=" + itemPrepaidConditions[i].itemid + " id='txthiddenId_VoucherConditions' runat='server'>";
                                _Row.Controls.Add(Col_7);

                                PrepaidCondModule.Rows.Add(_Row);

                            }
                        }

                    }
                    else
                    {
                        _PKey = "";
                        btnSubmit_AddItemMaster.InnerText = "Add";
                        //txt_RunningNo1.Visible = false;
                        //txt_RunningNo2.Visible = false;
                        //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "PageloadItemMas()", true);
                    }

                }
            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Medium);
            }

        }

        ////(String)HttpContext.Current.Session["VariableName"]

        [WebMethod]
        public static void AddDivMasterData(string itmCode, string itmDesc, bool itmIsactive, string itmSeq, string siteCode)
        {
            if (string.IsNullOrEmpty(siteCode))
                siteCode = "HQ";

            using (var client = new HttpClient())
            {
                divMasInput p = new divMasInput { itmCode = itmCode, itmDesc = itmDesc, itmIsactive = itmIsactive, itmSeq = itmSeq};
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<divMasInput>("api/ItemDivs", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    int Newcontrol = int.Parse(itmCode);
                    int NewcontrolNo = Newcontrol + 1;
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "DIV CODE",sitecode= siteCode, controlnumber = Convert.ToString(NewcontrolNo) };
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
        public static void AddClassMasterData(string itmCode, string itmDesc, bool itmIsactive, string siteCode)
        {
            if (string.IsNullOrEmpty(siteCode))
                siteCode = "HQ";

            using (var client = new HttpClient())
            {
                divMasInput p = new divMasInput { itmCode = itmCode, itmDesc = itmDesc, itmIsactive = itmIsactive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<divMasInput>("api/ItemClasses", p);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    int Newcontrol = int.Parse(itmCode);
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
        public static void AddItemMasterData(List<itemMasInput> Details )
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<itemMasInput>>("api/stocks", Details);
                post.Wait();
                var response = post.Result;
                System.Net.ServicePointManager.Expect100Continue = false;
                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrEmpty(Details[0].siteCode))
                        Details[0].siteCode = "HQ";

                    using (var client1 = new HttpClient())
                    {
                        matrixInput p1 = new matrixInput { matrixX = "00", matrixY = "00", matrixCode = null, itemCode = Details[0].itemCode, itemBarcode = Details[0].itemCode +"0000", itemName = Details[0].itemName, itemPrice = Details[0].itemPrice, onhandQty = "0", onhandCst = "0", itemOnhandcost = "0", matrixUser = "", matrixDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), matrixTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
                        client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post1 = client.PostAsJsonAsync<matrixInput>("api/Matrices", p1);
                        post1.Wait();
                        var response1 = post1.Result;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        if (response1.IsSuccessStatusCode)
                        {
                            string control = Details[0].itemCode.Substring(3, Details[0].itemCode.Length - 3);
                           string controlNo = "1" + control;
                            int Newcontrol = int.Parse(controlNo);
                            int NewcontrolNo = Newcontrol + 1;
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "STOCK CODE", sitecode = Details[0].siteCode, controlnumber = Convert.ToString(NewcontrolNo) };
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
                            
                        }
                    }

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

        [WebMethod]
        public static void EditAddItemMasterData(List<itemMasInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<itemMasInput>("api/stocks/update?[where][itemCode]=" + Details[0].itemCode + "", Details[0]);
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

        //[WebMethod]
        //public static void EditAddItemMasterData(string itemCode, string itemDiv, string itemDept, string itemClass, string itemBrand, string itemRange, string itemName, string itemDesc, bool limitserviceFlexionly, bool isOpenPrepaid, string itemType, string itemSupp, string itemPrice, string itemPriceFloor, string costPrice, string disclimit, bool disctypeamount, bool autocustdisc, bool itemIsactive, bool commissionable, bool itemFoc, bool isGst, bool isAllowFoc, string accountCode, bool voucherIsvalidUntilDate, string voucherValidUntilDate, string voucherValue, bool voucherValueIsAmount, string voucherValidPeriod, string prepaidValidPeriod, bool membercardnoaccess, string prepaidValue, string prepaidSellAmt, bool reorderActive, string reorderMinqty, string custReplenishDays, string custAdvanceDays, bool trading)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        itemMasInput p = new itemMasInput { itemCode = itemCode, itemDiv = itemDiv, itemDept = itemDept, itemClass = itemClass, itemBrand = itemBrand, itemRange = itemRange, itemName = itemName, itemDesc = itemDesc, limitserviceFlexionly = limitserviceFlexionly, isOpenPrepaid = isOpenPrepaid, itemType = itemType, itemSupp = "", itemPrice = itemPrice, itemPriceFloor = itemPriceFloor, costPrice = costPrice, disclimit = disclimit, disctypeamount = disctypeamount, autocustdisc = autocustdisc, itemIsactive = itemIsactive, commissionable = commissionable, itemFoc = itemFoc, isGst = isGst, isAllowFoc = isAllowFoc, itemHavechild = true, valueApplytochild = true, havePackageDisc = true, mixbrand = true, serviceExpireActive = true, treatmentLimitActive = true, serviceCostPercent = true, isHaveTax = true, accountCode = accountCode, voucherIsvalidUntilDate = voucherIsvalidUntilDate, voucherValidUntilDate = voucherValidUntilDate, voucherValue = voucherValue, voucherValueIsAmount = voucherValueIsAmount, voucherValidPeriod = voucherValidPeriod, prepaidValidPeriod = prepaidValidPeriod, membercardnoaccess = membercardnoaccess, prepaidValue = prepaidValue, prepaidSellAmt = prepaidSellAmt, reorderActive = reorderActive, reorderMinqty = reorderMinqty, custReplenishDays = custReplenishDays, custAdvanceDays = custAdvanceDays, trading = trading };
        //        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        var post = client.PostAsJsonAsync<itemMasInput>("api/stocks/update?[where][itemCode]=" + itemCode + "", p);
        //        post.Wait();
        //        var response = post.Result;
        //        System.Net.ServicePointManager.Expect100Continue = false;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var errorMessage = response.Content.ReadAsStringAsync().Result;
        //            Console.Write("Success");
        //        }
        //        else
        //        {
        //            var errorMessage = response.Content.ReadAsStringAsync().Result;
        //            Console.Write("Error");
        //        }

        //    }
        //}

        [WebMethod]
        public static void Addstockdetails(List<stockdetailsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<stockdetailsInput>>("api/stockdetails", Details);
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

        [WebMethod]
        public static void EditAddstockdetails(List<stockdetailsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<stockdetailsInput>("api/stockdetails/update?[where][stockcode]=" + Details[0].stockcode+ "", Details[0]);
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

        [WebMethod]
        public static void AddItemMasterUOMData(List<Data> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    //List<Data> datelist = new List<Data>();
                    //Data a = new Data();
                    //foreach (Data dt in Details)
                    //{
                    //    a.itemCode = dt.itemCode;
                    //    a.itemUom = dt.itemUom;
                    //    a.uomDesc = dt.uomDesc;
                    //    a.uomUnit = dt.uomUnit;
                    //    datelist.Add(a);
                    //}

                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<Data>>("api/ItemUomprices", Details);
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
        }

        [WebMethod]
        public static void EditAddItemMasterUOMData(List<Data> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].id != "" && Details[i].id != null)
                {
                    using (var client = new HttpClient())
                    {
                        Data p = new Data { itemCode = Details[i].itemCode, itemUom = Details[i].itemUom, uomDesc = Details[i].uomDesc, uomUnit = Details[i].uomUnit, itemUom2 = Details[i].itemUom2, uom2Desc = Details[i].uom2Desc, itemPrice = Details[i].itemPrice, itemCost = Details[i].itemCost, minMargin = Details[i].minMargin, isactive = Details[i].isactive, itemUompriceSeq = Details[i].itemUompriceSeq };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Data>("api/ItemUomprices/update?[where][id]=" + Details[i].id + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        Data p = new Data { itemCode = Details[i].itemCode, itemUom = Details[i].itemUom, uomDesc = Details[i].uomDesc, uomUnit = Details[i].uomUnit, itemUom2 = Details[i].itemUom2, uom2Desc = Details[i].uom2Desc, itemPrice = Details[i].itemPrice, itemCost = Details[i].itemCost, minMargin = Details[i].minMargin, isactive = Details[i].isactive, itemUompriceSeq = Details[i].itemUompriceSeq };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Data>("api/ItemUomprices", p);
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
            }
        }

        [WebMethod]
        public static void AddItemMasterLinkData(List<linkData> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<linkData>>("api/Itemlinks", Details);
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
        }

        [WebMethod]
        public static void EditAddItemMasterLinkData(List<linkData> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].itmId != "" && Details[i].itmId != null)
                {
                    using (var client = new HttpClient())
                    {
                        linkData p = new linkData { itemCode = Details[i].itemCode, linkCode = Details[i].linkCode, linkDesc = Details[i].linkDesc, linkType = Details[i].linkType, itmIsactive = Details[i].itmIsactive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<linkData>("api/Itemlinks/update?[where][itmId]=" + Details[i].itmId + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        linkData p = new linkData { itemCode = Details[i].itemCode, linkCode = Details[i].linkCode, linkDesc = Details[i].linkDesc, linkType = Details[i].linkType, itmIsactive = Details[i].itmIsactive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<linkData>("api/Itemlinks", p);
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
            }
        }

        [WebMethod]
        public static void AddItemMasterstockListing(List<stockListingData> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<stockListingData>>("api/ItemStocklists", Details);
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
        }

        [WebMethod]
        public static void EditAddItemMasterstockListing(List<stockListingData> Details)
        {
            if (Details.Count > 0)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                string api = "api/ItemStocklists?filter={\"where\":{\"itemCode\":\"" + Details[0].itemCode + "\"}}";
                var response = client.GetAsync(api).Result;
                List<stockListingData> itemStockListing;
                var a = response.Content.ReadAsStringAsync().Result;
                itemStockListing = JsonConvert.DeserializeObject<List<stockListingData>>(a);

                if (itemStockListing.Count > 0)
                {
                    for (var i = 0; i < itemStockListing.Count; i++)
                    {
                        using (var client1 = new HttpClient())
                        {
                            client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var deleteTask = client1.DeleteAsync("api/ItemStocklists/" + itemStockListing[i].itemstocklistId);
                            deleteTask.Wait();
                            var response1 = deleteTask.Result;
                            if (response1.IsSuccessStatusCode)
                            {
                                var errorMessage = response1.Content.ReadAsStringAsync().Result;
                                Console.Write("Success");
                            }
                            else
                            {
                                var errorMessage = response.Content.ReadAsStringAsync().Result;
                                Console.Write("Error");
                            }

                        }
                    }
                }

                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    List<stockListingData> stockListingDatas = new List<stockListingData>();
                    for(int i=0;i< Details.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(Details[i].itemsiteCode))
                        {
                            stockListingData stockListingData = new stockListingData();
                            stockListingData = Details[i];
                            stockListingDatas.Add(stockListingData);
                        }
                    }

                    var post2 = client2.PostAsJsonAsync<List<stockListingData>>("api/ItemStocklists", stockListingDatas);
                    post2.Wait();
                    var response2 = post2.Result;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    if (response2.IsSuccessStatusCode)
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
        }

        //[WebMethod]
        //public static void EditAddItemMasterstockListing(List<stockListingData> Details)
        //{
        //    if (Details.Count > 0)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //            stockListingData c = new stockListingData { itemCode = Details[0].itemCode };
        //            string api = "api/ItemStocklists/" + Details[0].itemCode;
        //            var post = client.DeleteAsync(api);
        //            post.Wait();
        //            var response = post.Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                using (var client1 = new HttpClient())
        //                {
        //                    client1.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        //                    client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //                    var post1 = client1.PostAsJsonAsync<List<stockListingData>>("api/ItemStocklists", Details);
        //                    post1.Wait();
        //                    var response1 = post1.Result;
        //                    System.Net.ServicePointManager.Expect100Continue = false;
        //                    if (response1.IsSuccessStatusCode)
        //                    {
        //                        var errorMessage = response1.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Success");
        //                    }
        //                    else
        //                    {
        //                        var errorMessage = response1.Content.ReadAsStringAsync().Result;
        //                        Console.Write("Error");
        //                    }

        //                }
        //            }

        //        }


        //    }
        //}

        [WebMethod]
        public static void AddItemMasterItemUsage(List<itemUsageLevel> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<itemUsageLevel>>("api/usagelevels", Details);
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
        }

        [WebMethod]
        public static void EditAddItemMasterItemUsage(List<itemUsageLevel> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].id != "" && Details[i].id != null)
                {
                    using (var client = new HttpClient())
                    {
                        itemUsageLevel p = new itemUsageLevel { serviceCode = Details[i].serviceCode, itemCode = Details[i].itemCode, qty = Details[i].qty, uom = Details[i].uom, sequence = Details[i].sequence, serviceDesc = Details[i].serviceDesc, itemDesc = Details[i].itemDesc, isactive = Details[i].isactive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<itemUsageLevel>("api/usagelevels/update?[where][id]=" + Details[i].id + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        itemUsageLevel p = new itemUsageLevel { serviceCode = Details[i].serviceCode, itemCode = Details[i].itemCode, qty = Details[i].qty, uom = Details[i].uom, sequence = Details[i].sequence, serviceDesc = Details[i].serviceDesc, itemDesc = Details[i].itemDesc, isactive = Details[i].isactive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<itemUsageLevel>("api/usagelevels", p);
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
            }
        }

        [WebMethod]
        public static void AddItemMasterPrepaidConditions(List<prepaidConditionsInput> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<prepaidConditionsInput>>("api/VoucherConditions", Details);
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
        }

        [WebMethod]
        public static void EditAddItemMasterPrepaidConditions(List<prepaidConditionsInput> Details)
       {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].itemid != "" && Details[i].itemid != null)
                {
                    using (var client = new HttpClient())
                    {
                        prepaidConditionsInput p = new prepaidConditionsInput { pItemtype = Details[i].pItemtype, itemCode = Details[i].itemCode, conditiontype1 = Details[i].conditiontype1, conditiontype2 = Details[i].conditiontype2, amount = Details[i].amount, rate = Details[i].rate, membercardnoaccess = Details[i].membercardnoaccess };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<prepaidConditionsInput>("api/VoucherConditions/update?[where][itemid]=" + Details[i].itemid + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        prepaidConditionsInput p = new prepaidConditionsInput { pItemtype = Details[i].pItemtype, itemCode = Details[i].itemCode, conditiontype1 = Details[i].conditiontype1, conditiontype2 = Details[i].conditiontype2, amount = Details[i].amount, rate = Details[i].rate, membercardnoaccess = Details[i].membercardnoaccess };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<prepaidConditionsInput>("api/VoucherConditions", p);
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
            }
        }

        [WebMethod]
        public static void AddItemMasterItemBatch(List<itemBatchInput> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<itemBatchInput>>("api/ItemBatches", Details);
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
        }

        [WebMethod]
        public static void AddPackageDtlData(List<PackageDtlsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<PackageDtlsInput>>("api/PackageDtls", Details);
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

        [WebMethod]
        public static void EditPackageDtlData(List<PackageDtlsInput> Details)
        {
            for (var i = 0; i < Details.Count; i++)
            {
                if (Details[i].ID != "" && Details[i].ID != null)
                {
                    using (var client = new HttpClient())
                    {
                        PackageDtlsInput p = new PackageDtlsInput { code = Details[i].code, description = Details[i].description, 
                            cost = Details[i].cost, price = Details[i].price, discount = Details[i].discount, 
                            packageCode = Details[i].packageCode, qty = Details[i].qty, uom = Details[i].uom, 
                            packageBarcode = Details[i].packageBarcode, discPercent = Details[i].discPercent, 
                            unitPrice = Details[i].unitPrice, ttlUprice = Details[i].ttlUprice, siteCode = Details[i].siteCode, 
                            lineNo = Details[i].lineNo, serviceExpireActive = Details[i].serviceExpireActive, 
                            serviceExpireMonth = Details[i].serviceExpireMonth, treatmentLimitActive = Details[i].treatmentLimitActive, 
                            treatmentLimitCount = Details[i].treatmentLimitCount, limitserviceFlexionly = Details[i].limitserviceFlexionly, 
                            isactive = Details[i].isactive, itemDiv= Details[i].itemDiv};
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<PackageDtlsInput>("api/PackageDtls/update?[where][id]=" + Details[i].ID + "", p);
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
                else
                {
                    using (var client = new HttpClient())
                    {
                        PackageDtlsInput p = new PackageDtlsInput { code = Details[i].code, description = Details[i].description, cost = Details[i].cost, price = Details[i].price, discount = Details[i].discount, packageCode = Details[i].packageCode, qty = Details[i].qty, uom = Details[i].uom, 
                            packageBarcode = Details[i].packageBarcode, discPercent = Details[i].discPercent, unitPrice = Details[i].unitPrice, 
                            ttlUprice = Details[i].ttlUprice, siteCode = Details[i].siteCode, lineNo = Details[i].lineNo, serviceExpireActive = Details[i].serviceExpireActive, 
                            serviceExpireMonth = Details[i].serviceExpireMonth, treatmentLimitActive = Details[i].treatmentLimitActive, 
                            treatmentLimitCount = Details[i].treatmentLimitCount, limitserviceFlexionly = Details[i].limitserviceFlexionly, 
                            isactive = Details[i].isactive, itemDiv = Details[i].itemDiv };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<PackageDtlsInput>("api/PackageDtls", p);
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
            }
        }

        [WebMethod]
        public static void AddPackageMasData(List<PackageHdrsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<List<PackageHdrsInput>>("api/PackageHdrs", Details);
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

        [WebMethod]
        public static void EditPackageMasData(List<PackageHdrsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<PackageHdrsInput>("api/PackageHdrs/update?[where][code]=" + Details[0].code + "", Details[0]);
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

        [WebMethod]
        public static void AddServiceData(List<ServiceData> Details)
        {
            if (Details.Count > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var post = client.PostAsJsonAsync<List<ServiceData>>("api/ItemFlexiservices", Details);
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
        }

        [WebMethod]
        public static void EditServiceData(List<ServiceData> Details)
        {
            //commented on 16-02-2021 because of (list contains 256 rows for healspa.  which is too slow)
            //for (var i = 0; i < Details.Count; i++)
            //{
            //    if (Details[i].itmId != "" && Details[i].itmId != null)
            //    {
            //        using (var client = new HttpClient())
            //        {
            //            ServiceData p = new ServiceData { itemCode = Details[i].itemCode, itemSrvcode = Details[i].itemSrvcode, itemSrvdesc = Details[i].itemSrvdesc, itmIsactive = Details[i].itmIsactive };
            //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
            //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //            var post = client.PostAsJsonAsync<ServiceData>("api/ItemFlexiservices/update?[where][itmId]=" + Details[i].itmId + "", p);
            //            post.Wait();
            //            var response = post.Result;
            //            System.Net.ServicePointManager.Expect100Continue = false;
            //            if (response.IsSuccessStatusCode)
            //            {
            //                var errorMessage = response.Content.ReadAsStringAsync().Result;
            //                Console.Write("Success");
            //            }
            //            else
            //            {
            //                var errorMessage = response.Content.ReadAsStringAsync().Result;
            //                Console.Write("Error");
            //            }

            //        }
            //    }
            //    else
            //    {
            //        using (var client = new HttpClient())
            //        {
            //            ServiceData p = new ServiceData { itemCode = Details[i].itemCode, itemSrvcode = Details[i].itemSrvcode, itemSrvdesc = Details[i].itemSrvdesc, itmIsactive = Details[i].itmIsactive };
            //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
            //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //            var post = client.PostAsJsonAsync<ServiceData>("api/ItemFlexiservices", p);
            //            post.Wait();
            //            var response = post.Result;
            //            System.Net.ServicePointManager.Expect100Continue = false;
            //            if (response.IsSuccessStatusCode)
            //            {
            //                var errorMessage = response.Content.ReadAsStringAsync().Result;
            //                Console.Write("Success");
            //            }
            //            else
            //            {
            //                var errorMessage = response.Content.ReadAsStringAsync().Result;
            //                Console.Write("Error");
            //            }

            //        }
            //    }
            //}
        }

        [WebMethod]
        public static void DelServiceData(List<ServiceData> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                ServiceData c = new ServiceData { itmId = Details[0].itmId };
                string api = "api/ItemFlexiservices/" + Details[0].itmId;
                var post = client.DeleteAsync(api);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }

            }
        }

        [WebMethod]
        public static void DelPackageData(List<PackageDtlsInput> Details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                ServiceData c = new ServiceData { itmId = Details[0].ID };
                string api = "api/PackageDtls/" + Details[0].ID;
                var post = client.DeleteAsync(api);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }

            }
        }

        #endregion

        protected void ddl_Dept_ServerChange(object sender, EventArgs e)
        {
            ddl_Range.Items.Clear();
            var div = ddl_Dept.Value;
            oDT_General = (DataTable)JsonConvert.DeserializeObject(apiCalling(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemRanges"), (typeof(DataTable)));
            if (oDT_General.Rows.Count > 0)
            {
                DataView oDV4 = new DataView(oDT_General);
                oDV4.RowFilter = "itmDept='" + ddl_Dept.Value + "'";
                oDT_General = oDV4.ToTable();
            }
            ddl_Range.Items.Add(new ListItem("Select your option", ""));
            foreach (DataRow oDr in oDT_General.Rows)
            {
                ddl_Range.Items.Add(new ListItem(oDr["itmDesc"].ToString().Trim(), oDr["itmCode"].ToString().Trim()));
            }
        }
    }
}