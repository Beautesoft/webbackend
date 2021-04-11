using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using Sequoia_BE.Utilities;
using Sequoia_BE;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Sequoia_BE.Utilities
{

    /// <summary>
    /// Summary description for DataModels
    /// </summary>
    public class DataModels : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        string _ID = string.Empty;
        string _UserCode = string.Empty;
        string _SiteCode = string.Empty;
        CommonEngine oCommonEngine = new CommonEngine();
        DataTable oDT_CourseSyllabus = new DataTable();

        public void ProcessRequest(HttpContext context)
        {
            
            _ID = context.Request.QueryString["ID"].ToString();
            _UserCode = (string)context.Session["User_UserCode"];
            _SiteCode = (string)context.Session["User_SiteCode"];

            if (_ID == "SiteList")
            {
                var _Masters = ItemSiteLists.GetItemSiteLists(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] {  M.itemsiteCode, M.itemsiteDesc, M.itemsiteAddress})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "VendorList")
            {
                var _Masters = ItemSupplies.GetVendorList(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.splyCode, M.supplydesc, M.splyDate,M.splyactive, M.splyTelno,M.numberOfTotalPOs,})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ConfigEquipmentList")
            {
                var _Masters = ConfigEquipmentList.GetConfigEquipmentListMasters(_UserCode, _SiteCode, oCommonEngine, Convert.ToString(context.Request.QueryString["PKey"]));
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.equipmentCode, M.equipmentName, M.equipmentDescription, M.equipmentIsactive, M.id })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "StudentList")
            {
                var _Masters = Student.GetMasters(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.StudentCode, M.StudentName, M.Site, M.ID, M.Contact.ToString(), M.RegistrationDate.ToString(), M.Balance.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PaymentTypeList")
            {
                var _Masters = PaymentTypeLists.GetPaymentTypeList(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.payCode, M.payDescription, M.payGroup, M.sequence, M.payIsactive, M.payIsGst })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            //Mari
            else if (_ID == "ItemList")
            {
                var _Masters = ItemList.GetItemListMasters(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.linkCode, M.type, M.division, M.class1, M.department, M.isactive, M.brand, M.range })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PackageItemList")
            {
                var _Masters = PackageItemList.GetPackgeItemListMasters(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.division, M.class1, M.department, M.brand, M.range, M.item_uom, M.uom_unit, M.item_price})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "BrandList")
            {
                var _Masters = BrandList.GetBrandListMasters(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmStatus, M.retailProductBrand, M.voucherBrand, M.prepaidBrand })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "RangeProductList")
            {
                var _Masters = RangeProductList.GetRangeProductListMasters(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmBrand, M.itmStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "RangeServiceList")
            {
                var _Masters = RangeServiceList.GetRangeServiceListMasters(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmDept, M.itmStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DeptListMaster")
            {
                var _Masters = DeptListMaster.GetDeptListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmSeq, M.itmStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CommissionListMaster")
            {
                var _Masters = CommissionListMaster.GetCommissionListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.code, M.description, M.type, M.isactive })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DivListMaster")
            {
                var _Masters = DivListMaster.GetDivListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmIsactive })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ClassListMaster")
            {
                var _Masters = ClassListMaster.GetClassListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmIsactive })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DeptCodeCheck")
            {
                var _Masters = DeptCodeCheck.GetDeptCodeCheck(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc, M.itmSeq, M.itmStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DivCodeCheck")
            {
                var _Masters = DivCodeCheck.GetDivCodeCheck(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ClassCodeCheck")
            {
                var _Masters = DivCodeCheck.GetDivCodeCheck(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ItemUsage")
            {
                var _Masters = ItemUsage.GetItemUsageMasters(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itemName, M.itemCode, M.itemBarcode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ItemUsage1")
            {
                var _Masters = ItemUsage1.GetItemUsageMasters1(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString(), context.Request.QueryString["PKey1"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itemName, M.itemCode, M.itemBarcode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DivInfo")
            {
                var _Masters = DivInfo.GetDivInfo(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itemCode, M.itemDesc, M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DeptInfo")
            {
                var _Masters = DeptInfo.GetDeptInfo(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString(), context.Request.QueryString["PKey1"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itemCode, M.itemDesc, M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CodeCheckExist")
            {
                var _Masters = CodeCheckExist.GetCodeCheckExist(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString(), context.Request.QueryString["PKey1"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "BrandControlNo")
            {
                var _Masters = BrandControlNo.GetBrandControlNo(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DivControlNo")
            {
                var _Masters = DivControlNo.GetDivControlNo(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DeptControlNo")
            {
                var _Masters = DeptControlNo.GetDeptControlNo(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ClassControlNo")
            {
                var _Masters = ClassControlNo.GetClassControlNo(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "UsageUom")
            {
                var _Masters = UsageUom.GetUsageUom(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.uomCode, M.uomDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "UsageUomPrice")
            {
                var _Masters = UsageUomPrice.GetUsageUomPrice(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.uomCode, M.uomDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "EmployeeLevel")
            {
                var _Masters = EmployeeLevel.GetEmployeeLevel(_UserCode, _SiteCode, oCommonEngine,"");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.levelCode, M.levelDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "RangeBasedDept")
            {
                var _Masters = RangeBasedDept.GetRangeBasedDept(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "getDiv")
            {
                var _Masters = getDiv.GetgetDiv(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PrepaidDept")
            {
                var _Masters = PrepaidDept.GetPrepaidDept(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.itmCode, M.itmDesc })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }

            //Mari

            //Inventory

            else if (_ID == "ServiceItemSearchList")
            {
                var _Masters = ServiceItemSearchList.GetServiceItemSearchList(_UserCode, _SiteCode, oCommonEngine, "isactive");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.Uom, M.brand, M.linkCode, M.range, M.quantity, M.UomCode, M.brandCode, M.rangeCode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }

            else if (_ID == "PackageItemSearchList")
            {
                var _Masters = PackageItemSearchList.GetPackageItemSearchList(_UserCode, _SiteCode, oCommonEngine, "isactive");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.Uom, M.brand, M.linkCode, M.range, M.quantity, M.UomCode, M.brandCode, M.rangeCode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }

            else if (_ID == "GRNItemSearchList")
            {
                var _Masters = GRNItemSearchList.GetGRNItemSearchList(_UserCode, _SiteCode, oCommonEngine, "isactive");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.Uom, M.brand, M.linkCode, M.range, M.quantity, M.UomCode, M.brandCode, M.rangeCode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "POItemSearchList")
            {
                var _Masters = POItemSearchList.GetPOItemSearchList(_UserCode, _SiteCode, oCommonEngine, "isactive");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.stockcode, M.stockname, M.Uom, M.brand, M.itemPrice, M.quantity, M.moqqty, M.linkCode, M.range, M.UomCode, M.brandCode, M.rangeCode })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ListWithSupplier")
            {
                var _Masters = GRNListMaster.GetGRNListMaster(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.docNo, M.docDate, M.docRef1, M.supplyNo, M.docAmt, M.recStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ListWithoutSupplier")
            {
                var _Masters = GRNOutListMaster.GetGRNOutListMaster(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.docNo, M.docDate, M.docRef1, M.docRef2, M.docAmt, M.recStatus })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "REQListMaster")
            {
                var _Masters = REQListMaster.GetREQListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.reqNo, M.reqDate, M.supplierName, M.reqTtqty, M.reqStatus, M.reqRemk1 })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "POListMaster")
            {
                var _Masters = POListMaster.GetPOListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.poNo, M.poDate, M.suppCode, M.poTtqty, M.poStatus, M.poRemk1 })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "AppListMaster")
            {
                var _Masters = AppListMaster.GetAppListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.ponumber, M.pono, M.podate, M.supplier, M.pototalqty, M.appqty, M.postatus, M.poremark })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "AppGRNListMaster")
            {
                var _Masters = AppGRNListMaster.GetAppGRNListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.poNumber, M.grnno, M.podate, M.supplier, M.pototalqty, M.appqty, M.postatus, M.poremark })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "AppDOGRNListMaster")
            {
                var _Masters = AppDOGRNListMaster.GetAppDOGRNListMaster(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.donumber, M.grnno, M.dodate, M.supplier, M.dototalqty, M.appqty, M.dostatus, M.doremark })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "Supplier")
            {
                var _Masters = Supplier.GetSupplier(_UserCode, _SiteCode, oCommonEngine, "");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.splyCode, M.supplydesc, M.splyDate, M.splyactive, M.splyTelno, M.numberOfTotalPOs})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "SupplierInfo")
            {
                var _Masters = SupplierInfo.GetSupplierInfo(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.splyAttn, M.splyAddr1, M.splyAddr2, M.splyAddr3, M.splyPoscd, M.splyCity, M.splyState, M.splyCntry
                        , M.splyRemk1, M.splyRemk2, M.splymaddr1, M.splymaddr2, M.splymaddr3, M.splymposcd, M.splymcity, M.splymstate, M.splymcntry})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "GetControlNo")
            {
                var _Masters = GetControlNo.GetControlNoInfo(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.controlPrefix, M.siteCode, M.controlNo })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }

            //Inventory

            else if (_ID == "CourseList")
            {
                var _Masters = Course.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.CourseCode, M.CourseName, M.Category, M.Duration.ToString(), M.Cost.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ModuleList")
            {
                var _Masters = Module.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.ModuleCode, M.ModuleName, M.Duration.ToString(), M.Cost.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ProductList")
            {
                var _Masters = Product.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.ProductCode, M.ProductName, M.ProductGroup, M.UOM, M.Cost.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "EmployeeList")
            {
                var _Masters = Employee.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.EmployeeCode, M.EmployeeName, M.EmployeeType, M.Contact.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "UserList")
            {
                var _Masters = User.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.UserCode, M.UserName, M.UserType, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "SiteList")
            {
                var _Masters = Site.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.SiteCode, M.SiteName, M.Address, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "LeadList")
            {
                var _Masters = Lead.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.LeadCode, M.LeadName, M.AddedDate, M.LeadSource,M.Contact, M.LeadStatus.ToString(), M.Courses.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ActivityList")
            {
                var _Masters = ActivityTable.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.Date, M.Code, M.Name, M.Source, M.Subject, M.DateInfo, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CorporateList")
            {
                var _Masters = Corporate.GetMasters(_UserCode, _SiteCode, oCommonEngine,"");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.CorporateCode, M.CorporateName, M.Address, M.StudentCount, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "LeadGroup")
            {
                var _Masters = LeadGroup.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.LeadGroupCode, M.LeadGroupName, M.DateAdded, M.LeadsCount, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CampaignLeadGroup")
            {
                var _Masters = CampaignLeadGroup.GetMasters(_UserCode, _SiteCode, oCommonEngine, context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.LeadGroupCode, M.LeadGroupName, M.DateAdded, M.LeadsCount })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "Campaign")
            {
                var _Masters = CampaignMaster.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.Code, M.Name, M.DateAdded, M.LastRun, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "Template")
            {
                var _Masters = TemplateCL.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.Code, M.Name, M.DateAdded, M.Format, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "MenuList")
            {
                var _Masters = Menu.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.MenuCode, M.MenuName, M.Authorization })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            if (_ID == "CRMStudents")
            {
                var _Masters = Student.GetMasters(_UserCode, _SiteCode, oCommonEngine, "No");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.StudentCode, M.StudentName, M.ID, M.Contact.ToString(), M.RegistrationDate.ToString(), M.Balance.ToString(), M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            if (_ID == "CRMCorporates")
            {
                var _Masters = Corporate.GetMasters(_UserCode, _SiteCode, oCommonEngine,"No");
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.CorporateCode, M.CorporateName, M.Address, M.StudentCount, M.Status.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PaymentList")
            {
                var _Masters = PaymentListPage.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.PaymentNo, M.PaymentDate, M.StudentName, M.PaymentTotal })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "InvoiceList")
            {
                var _Masters = InvoiceListPage.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.InvoiceNo, M.InvoiceDate, M.StudentName, M.InvoiceTotal , M.Paid , M.Outstanding })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "QuotationList")
            {
                var _Masters = QuotationListPage.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.InvoiceNo, M.InvoiceDate, M.StudentName, M.InvoiceTotal })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CorporateInvoiceList")
            {
                var _Masters = CorporateInvoiceListPage.GetMasters(_UserCode, _SiteCode, oCommonEngine);
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.InvoiceNo, M.InvoiceDate, M.CorporateName, M.InvoiceTotal,M.OutStanding })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CourseModule")
            {
                var _Masters = CourseModule.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.ModuleCode, M.ModuleName, M.Duration.ToString(), M.Cost.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "EmployeeCourse")
            {
                var _Masters = EmployeeCourse.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.CourseCode, M.CourseName, M.Category, M.Duration.ToString(), M.Cost.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CourseInfo")
            {
                var _Masters = CourseInfo.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.CourseCode, M.CompCode, M.Category, M.Duration.ToString(), M.Cost.ToString(), M.CourseMode, M.TrainingArea, M.Industry, M.AccreditationScope, M.CourseOrigin })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "SyllabusInfo")
            {
                var _Masters = SyllabusInfo.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString(), context.Request.QueryString["DateValue"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.Topic, M.Trainer, M.Duration, M.Room })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CourseSyllabus")
            {
                oDT_CourseSyllabus=oCommonEngine.ExecuteDataTable("EXEC [Get_Syllabus] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','" + context.Request.QueryString["Course"].ToString() + "','" + context.Request.QueryString["Employee"].ToString() + "','" + context.Request.QueryString["StartDate"].ToString().Trim() + "','" + context.Request.QueryString["StartTime"].ToString().Trim() + "','" + context.Request.QueryString["SchedulerType"].ToString().Trim() + "','" + context.Request.QueryString["ScheduleWeek"].ToString().Trim() + "','"+ context.Request.QueryString["SortBy"].ToString().Trim() + "'");
                context.Session["oDT_CourseSyllabus"] = oDT_CourseSyllabus;
                var _Masters = CourseSyllabus.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["Course"].ToString(), context.Request.QueryString["Employee"].ToString(), context.Request.QueryString["StartDate"].ToString(), context.Request.QueryString["StartTime"].ToString(), context.Request.QueryString["SchedulerType"].ToString(), context.Request.QueryString["ScheduleWeek"].ToString(), context.Request.QueryString["SortBy"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.LineNo, M.ModuleCode, M.ModuleName, M.TopicName, M.StartDate, M.StartTime, M.Day, M.Duration.ToString(), M.EmployeeCode, M.EmployeeName, M.Sequence, M.Room, M.Status,M.Info, M.URL })
                            };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CourseProduct")
            {
                var _Masters = CourseProduct.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.ProductCode, M.ProductName, M.UOM,  M.Cost.ToString()})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CourseEnrollment")
            {
                var _Masters = CourseEnrollmentStudent.GetMasters(_UserCode, _SiteCode, oCommonEngine,context.Request.QueryString["PKey"].ToString());
                var result = new
                {
                    iTotalRecords = _Masters.Count(),
                    iTotalDisplayRecords = _Masters.Count(),
                    aaData = _Masters
                        .Select(M => new[] { M.StudentCode, M.StudentName, M.Contact, M.EMail.ToString(), M.RegistrationDate.ToString() })
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }          
            else if (_ID == "AcedemicYear" || _ID == "Holidays" || _ID == "ID" || _ID == "Race" || _ID == "Country" || _ID == "Qualification" || _ID == "NextProgression" || _ID == "ModeOfCommunication" || _ID == "CourseMode" || _ID == "CourseOrigin" || _ID == "Language" || _ID == "CourseIndustry" || _ID == "CourseTrainingArea" || _ID == "CourseAccreditationScope" || _ID == "EmployeeType" || _ID == "EmployeeSubType" || _ID == "AreaSpecialization" || _ID == "ProductGroup" || _ID == "ProductUOM" || _ID == "Category")
            {
                var _Masters = CommonMasterList.GetMasters(_UserCode, _SiteCode, oCommonEngine,_ID);
                var result = new
                {
                    aaData = _Masters
                        .Select(M => new[] { M.Code, M.Name, M.InActive ,M.RefCount})
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "Download")
            {
                try
                {
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "text/plain";
                    response.AddHeader("Content-Disposition",
                                       "attachment; filename=" + context.Request.QueryString["FileName"].ToString() + ";");
                    response.TransmitFile(Path.Combine((string)context.Session["AttachmentPath"].ToString().Trim(), context.Request.QueryString["Key"].ToString(), context.Request.QueryString["FileName"].ToString()));
                    response.Flush();
                    response.End();
                }
                catch
                { }
               
            }
            else if (_ID == "InvoicePrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_InvoicePrint]  '" + context.Request.QueryString["Info"].ToString().Trim() + "','" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();               
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "CorporateInvoicePrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_CorporateInvoicePrint]  '" + context.Request.QueryString["Info"].ToString().Trim() + "','" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PaymentPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_PaymentPrint]  '" + context.Request.QueryString["Info"].ToString().Trim() + "','" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                //byte[] _SignImage = (byte[])oDT_Invoice.Rows[0]["SignatureImg"];
                //string base64String = Convert.ToBase64String(_SignImage);
                //oDT_Invoice.Rows[0]["SignatureImg"] = String.Format("data:image/jpeg;base64,{0}", base64String);
                //oDT_Invoice.AcceptChanges();
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "GraduationPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select T1.StudentName,T3.CourseName,CASE WHEN T0.AllowEditGraduation='N' THEN CONVERT(VARCHAR(10),T0.NoticeDate,103) ELSE CONVERT(VARCHAR(10),GETDATE(),103) END [NoticeDate],T0.Shift,T0.Day,T0.Duration,T0.BeYourOwnBoss,T0.CategoryInterested,T0.Contact,T0.EMail,T0.GRemarks from CourseEnrollment T0 JOIN StudentMaster T1 ON T0.StudentCode=T1.StudentCode JOIN CourseScheduler T2 ON T2.ID=T0.SchedulerKey JOIN CourseMaster T3 ON T3.CourseCode=T2.CourseCode Where T0.SchedulerKey='" + context.Request.QueryString["SKey"].ToString().Trim() + "' AND T0.StudentCode='" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "TrainingFeedbackPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select T1.StudentName,T3.CourseName,CONVERT(VARCHAR(10),TFDate,103) [TFDate],TFRegnAdminSuprt,TFContent,TFNotes,TFPresentation,TFOverallEnjoyment,TFComments,T4.EmployeeName from FeedbackRecords T0 JOIN StudentMaster T1 ON T0.StudentCode=T1.StudentCode JOIN CourseScheduler T2 ON T2.ID=T0.SchedulerKey JOIN CourseMaster T3 ON T3.CourseCode=T2.CourseCode Join EmployeeMaster T4 ON T4.EmployeeCode=T0.EmployeeCode Where T0.SchedulerKey='" + context.Request.QueryString["SKey"].ToString().Trim() + "' AND T0.StudentCode='" + context.Request.QueryString["PKey"].ToString().Trim() + "' And T0.EmployeeCode='" + context.Request.QueryString["EKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "EvaluationPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_StudentEvaluation] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','" + context.Request.QueryString["PKey"].ToString().Trim() + "','" + context.Request.QueryString["SKey"].ToString().Trim() + "','Student','','" + context.Request.QueryString["EKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "SchedulerPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_SchedulerPrint] '" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "EnrolmentFormPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_EnrolmentFormPrint] '" + context.Request.QueryString["PKey"].ToString().Trim() + "','" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "PDPAPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select StudentName,CASE When PDPA Like '%Phone%' Then 'Y' Else 'N' End [Phone] ,CASE When PDPA Like '%SMS%' Then 'Y' Else 'N' End [SMS] ,CASE When PDPA Like '%Email%' Then 'Y' Else 'N' End [Email] ,CASE When PDPA Like '%Letter%' Then 'Y' Else 'N' End [Letter] ,SignatureImg from StudentMaster T0 Where T0.StudentCode='" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "ANPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select StudentName,StudentName +', NRIC / Passport Number ' + IDNumber [NameWithID],ANSignatureImg,ANRemarks,Convert(Varchar(10),ISNULL(ANDate,GETDATE()),103) [ANDate],ISNULL(ANBlended,'N') [ANBlended],ISNULL(ANEligibility,'N') [ANEligibility] from StudentMaster T0 Where T0.StudentCode='" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select StudentName,StudentCode,D_Sign,Convert(Varchar(10),ISNULL(D_Date,GETDATE()),103) [D_Date],ISNULL(D_Address,'') [D_Address],ISNULL(D_PostalCode,'') [D_PostalCode],D_yes,D_No,D_A1,D_A2,D_T1,D_T2,D_T3,D_T4,D_C1,D_C2,D_C3,D_C4,D_C5,D_C6,D_C7,D_C8,D_C9,D_C10,D_C11,D_C12,D_C13,D_C14,D_C15,D_C16,D_C17,D_C18,D_C19,D_C20,D_C21,D_C22,D_C23,D_C24,D_C25,D_C26,D_C27,D_C28,D_C29,D_C30,D_C31,D_C32,D_C33,D_C34,D_C35,D_C36,D_C37,D_C38,D_C39,D_C40,D_C41,D_C42,D_C43,D_C44,D_C45,D_C46,D_C47,D_C48,D_C49,D_C50,D_C51,D_C52,D_C53,D_C54,D_C55,D_C56,D_C57,D_C58,D_C59,D_C60,D_C61,D_C62,D_C63,D_C64,D_C65,D_C66,D_C67,D_C68,D_C69,D_C70,D_C71,D_C72 From StudentMaster T0 Where T0.StudentCode='" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "AssessmentPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_AssessmentPrint] '" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "AttendancePrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_AttendancePrint] '" + context.Request.QueryString["SKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            
            else if (_ID == "CourseDetailPrint")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_CourseDetailPrint] '" + context.Request.QueryString["PKey"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DashBoardCalender")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_DashBoardCalender] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','" + context.Request.QueryString["IntervalName"].ToString().Trim() + "','" + context.Request.QueryString["IntervalStart"].ToString().Trim() + "','" + context.Request.QueryString["For"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DashBoardCalenderPopup")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("EXEC [Get_DashBoardCalenderPopup] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','" + context.Request.QueryString["PKey"].ToString().Trim() + "','" + context.Request.QueryString["SDate"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else if (_ID == "DashBoardCalenderComment")
            {
                DataTable oDT_Invoice = new DataTable();
                oDT_Invoice = oCommonEngine.ExecuteDataTable("Select T0.ID,T0.Comments,T1.UserName [By], Convert(Varchar(17),T0.CreateDate,113) [When],Case When T1.UserCode='" + _UserCode.Trim() + "' Then 'Y' Else 'N'  End [Action]  From CalenderComments T0 JOIN UserMaster T1 ON T0.CreateUser=T1.UserCode Where EventId='" + context.Request.QueryString["PKey"].ToString().Trim() + "' And Convert(VArchar(10),EventDate,103)= '" + context.Request.QueryString["SDate"].ToString().Trim() + "'");
                Dictionary<string, object> result = new Dictionary<string, object>();
                object[] arr = new object[oDT_Invoice.Rows.Count + 1];
                for (int i = 0; i <= oDT_Invoice.Rows.Count - 1; i++)
                {
                    arr[i] = oDT_Invoice.Rows[i].ItemArray;
                }
                result.Add(oDT_Invoice.TableName, arr);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(result);
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

}

public class ItemSiteLists
{

    public string itemsiteCode { get; set; }
    public string itemsiteDesc { get; set; }
    public string itemsiteAddress { get; set; }


    public static IEnumerable<ItemSiteLists> GetItemSiteLists(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemSiteLists"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSiteLists"));
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

        DataTable oDT_Master = new DataTable();

        oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
     
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ItemSiteLists
            {
                itemsiteCode = _Row["itemsiteCode"].ToString(),
                itemsiteDesc = _Row["itemsiteDesc"].ToString(),
                itemsiteAddress = _Row["itemsiteAddress"].ToString()

            };
        }

    }

}

public class ItemSupplies
{

    public string splyCode { get; set; }
    public string supplydesc { get; set; }
    public string splyDate { get; set; }
    public string splyactive { get; set; }
    public string splyTelno { get; set; }
    public string numberOfTotalPOs { get; set; }
   // public string splyId { get; set; }


    public static IEnumerable<ItemSupplies> GetVendorList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemSupplies"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemSupplies"));
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

        DataTable oDT_Master = new DataTable();

        oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

        ////if (PKey != "")
        ////{
        ////    DataView oDV = new DataView(oDT_Master);
        ////    oDV.RowFilter = "" + PKey + " = True";
        ////    oDT_Master = oDV.ToTable();
        ////}

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ItemSupplies
            {
                splyCode = _Row["splyCode"].ToString(),
                supplydesc = _Row["supplydesc"].ToString(),
                splyDate = _Row["splyDate"].ToString(),
                splyactive = _Row["splyactive"].ToString() == "1" ? "Yes" : "No",
                splyTelno = _Row["splyTelno"].ToString(),
                numberOfTotalPOs = _Row["numberOfTotalPOs"].ToString(),
                //splyId = _Row["splyId"].ToString()

            };
        }

    }

}

public class ConfigEquipmentList
{

    public string equipmentCode { get; set; }
    public string equipmentName { get; set; }
    public string equipmentDescription { get; set; }
    public string equipmentIsactive { get; set; }
    public string id { get; set; }

    public static IEnumerable<ConfigEquipmentList> GetConfigEquipmentListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Myequipments"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Myequipments"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        //if (PKey != "")
        //{
        //    DataView oDV = new DataView(oDT_Master);
        //    oDV.RowFilter = "" + PKey + " = True";
        //    oDT_Master = oDV.ToTable();
        //}
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ConfigEquipmentList
            {
                equipmentCode = _Row["equipmentCode"].ToString(),
                equipmentName = _Row["equipmentName"].ToString(),
                equipmentDescription = _Row["equipmentDescription"].ToString(),
                equipmentIsactive = _Row["equipmentIsactive"].ToString() == "True" ? "Yes" : "No",
                id = _Row["id"].ToString()

            };
        }
    }
}

public class Student
{
   
    public string StudentCode { get; set; }
    public string StudentName { get; set; }
    public string Site { get; set; }
    public string ID { get; set; }
    public string Contact { get; set; }
    public string RegistrationDate { get; set; }
    public decimal Balance { get; set; }
    public string Status { get; set; }

    public static IEnumerable<Student> GetMasters(string _UserCode, string _SiteCode,CommonEngine oCommonEngine,string InActive)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Student'");
        if (InActive!="")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "Status='"+ InActive + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Student
            {
                StudentCode = _Row["StudentCode"].ToString(),
                StudentName = _Row["StudentName"].ToString(),
                Site = _Row["Site"].ToString(),
                ID = _Row["ID"].ToString(),
                Contact = _Row["Contact"].ToString(),
                RegistrationDate = _Row["RegDate"].ToString(),
                Balance =Convert.ToDecimal( _Row["Balance"]),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class PaymentTypeLists
{
    public string payCode { get; set; }
    public string payDescription { get; set; }
    public string payGroup { get; set; }
    public string sequence { get; set; }
    public string payIsactive { get; set; }
    public string payIsGst { get; set; }
    // public string splyId { get; set; }


    public static IEnumerable<PaymentTypeLists> GetPaymentTypeList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Paytables"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Paytables"));
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

        DataTable oDT_Master = new DataTable();

        oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

        ////if (PKey != "")
        ////{
        ////    DataView oDV = new DataView(oDT_Master);
        ////    oDV.RowFilter = "" + PKey + " = True";
        ////    oDT_Master = oDV.ToTable();
        ////}

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new PaymentTypeLists
            {               
                payCode = _Row["payCode"].ToString(),
                payDescription = _Row["payDescription"].ToString(),
                payGroup = _Row["payGroup"].ToString(),
                sequence = _Row["sequence"].ToString(),
                payIsGst = _Row["payIsGst"].ToString() == "True" ? "Yes" : "No",
                payIsactive = _Row["payIsactive"].ToString() == "True" ? "Yes" : "No",

            };
        }

    }

}



public class ItemList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string type { get; set; }
    public string isactive { get; set; }
    public string division { get; set; }
    public string range { get; set; }
    public string department { get; set; }
    public string class1 { get; set; }
    public string brand { get; set; }
    public string linkCode { get; set; }

    public static IEnumerable<ItemList> GetItemListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {
        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/stockdetails"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/stockdetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (InActive != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "Status='" + InActive + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ItemList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                type = _Row["type"].ToString(),
                isactive = _Row["isactive"].ToString(),
                division = _Row["division"].ToString(),
                range = _Row["range"].ToString(),
                department = _Row["department"].ToString(),
                class1 = _Row["class"].ToString(),
                brand = _Row["brand"].ToString(),
                linkCode = ""

            };
        }
    }
}

public class PackageItemList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string type { get; set; }
    public string isactive { get; set; }
    public string division { get; set; }
    public string range { get; set; }
    public string department { get; set; }
    public string class1 { get; set; }
    public string brand { get; set; }
    public string linkCode { get; set; }
    public string item_uom { get; set; }
    public string uom_unit { get; set; }
    public string item_price { get; set; }

    public static IEnumerable<PackageItemList> GetPackgeItemListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        //string deptCode = "";
        //if (Value.Length > 1) deptCode = "?filter={\"where\":{\"deptcode\":\"" + Value + "\"}}"; 

        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/PackageItemDetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        if (Value.Length >1)
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "deptcode='" + Value + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new PackageItemList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                type = _Row["type"].ToString(),
                isactive = _Row["isactive"].ToString(),
                division = _Row["division"].ToString(),
                range = _Row["range"].ToString(),
                department = _Row["department"].ToString(),
                class1 = _Row["class"].ToString(),
                brand = _Row["brand"].ToString(),
                linkCode = "",
                item_price = _Row["item_Price"].ToString(),
                item_uom = _Row["itemUom"].ToString(),
                uom_unit = _Row["uomUnit"].ToString()

            };
        }
    }
}

public class BrandList
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmStatus { get; set; }
    public string retailProductBrand { get; set; }
    public string voucherBrand { get; set; }
    public string prepaidBrand { get; set; }

    public static IEnumerable<BrandList> GetBrandListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {
        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemBrands"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemBrands"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (InActive != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "Status='" + InActive + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new BrandList
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmStatus = _Row["itmStatus"].ToString() == "True" ? "Yes" : "No",
                retailProductBrand = _Row["retailProductBrand"].ToString() == "True" ? "Yes" : "No",
                voucherBrand = _Row["voucherBrand"].ToString() == "True" ? "Yes" : "No",
                prepaidBrand = _Row["prepaidBrand"].ToString() == "True" ? "Yes" : "No",
            };
        }
    }
}

public class RangeProductList
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmBrand { get; set; }
    public string itmStatus { get; set; }

    public static IEnumerable<RangeProductList> GetRangeProductListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/rangelists"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/rangelists"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new RangeProductList
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmBrand = _Row["brand"].ToString(),
                itmStatus = _Row["itmStatus"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class RangeServiceList
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmDept { get; set; }
    public string itmStatus { get; set; }

    public static IEnumerable<RangeServiceList> GetRangeServiceListMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/rangelists"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/rangelists"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new RangeServiceList
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmDept = _Row["department"].ToString(),
                itmStatus = _Row["itmStatus"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class DeptListMaster
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmSeq { get; set; }
    public string itmStatus { get; set; }

    public static IEnumerable<DeptListMaster> GetDeptListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDepts"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDepts"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new DeptListMaster
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmSeq = _Row["itmSeq"].ToString(),
                itmStatus = _Row["itmStatus"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}


public class CommissionListMaster
{

    public string code { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public string isactive { get; set; }

    public static IEnumerable<CommissionListMaster> GetCommissionListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

       
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/CommGroupHdrs"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CommissionListMaster
            {
                code = _Row["code"].ToString(),
                description = _Row["description"].ToString(),
                type = _Row["type"].ToString(),
                isactive = _Row["isactive"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class DivListMaster
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmIsactive { get; set; }

    public static IEnumerable<DivListMaster> GetDivListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDivs"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDivs"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new DivListMaster
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmIsactive = _Row["itmIsactive"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class ClassListMaster
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmIsactive { get; set; }

    public static IEnumerable<ClassListMaster> GetClassListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemClasses"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemClasses"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ClassListMaster
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmIsactive = _Row["itmIsactive"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class DeptCodeCheck
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }
    public string itmSeq { get; set; }
    public string itmStatus { get; set; }

    public static IEnumerable<DeptCodeCheck> GetDeptCodeCheck(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDepts"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDepts"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmCode='" + PKey + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new DeptCodeCheck
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString(),
                itmSeq = _Row["itmSeq"].ToString(),
                itmStatus = _Row["itmStatus"].ToString() == "True" ? "Yes" : "No"

            };
        }
    }
}

public class DivCodeCheck
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }

    public static IEnumerable<DivCodeCheck> GetDivCodeCheck(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDivs"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDivs"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmCode='" + PKey + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new DivCodeCheck
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString()
            };
        }
    }
}

public class ClassCodeCheck
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }

    public static IEnumerable<ClassCodeCheck> GetClassCodeCheck(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {

        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemClasses"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemClasses"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmCode='" + PKey + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ClassCodeCheck
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString()
            };
        }
    }
}


public class ItemUsage
{
    public string itemName { get; set; }
    public string itemCode { get; set; }
    public string itemBarcode { get; set; }

    public static IEnumerable<ItemUsage> GetItemUsageMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string InActive)
    {
        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Stocks"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Stocks"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        DataView oDV = new DataView(oDT_Master);
        oDV.RowFilter = "itemDiv='2'";
        oDT_Master = oDV.ToTable();

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ItemUsage
            {
                itemCode = _Row["itemCode"].ToString(),
                itemName = _Row["itemName"].ToString(),
                itemBarcode = _Row["AccountCode"].ToString()
            };
        }
    }
}

public class ItemUsage1
{
    public string itemName { get; set; }
    public string itemCode { get; set; }
    public string itemBarcode { get; set; }

    public static IEnumerable<ItemUsage1> GetItemUsageMasters1(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Salon, string Retail)
    {
        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/Stocks"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/Stocks"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

        if (Salon == "checked" && Retail == "checked")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itemDiv in ('1' ,'2')";
            oDT_Master = oDV.ToTable();
        }
        else if (Salon == "unchecked" && Retail == "unchecked")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itemDiv =100";
            oDT_Master = oDV.ToTable();
        }
        else if (Salon == "checked" || Retail == "checked")
        {
            if (Salon == "checked")
            {
                DataView oDV = new DataView(oDT_Master);
                oDV.RowFilter = "itemDiv ='2' ";
                oDT_Master = oDV.ToTable();

            }
            else if (Retail == "checked")
            {
                DataView oDV = new DataView(oDT_Master);
                oDV.RowFilter = "itemDiv ='1' ";
                oDT_Master = oDV.ToTable();

            }

        }

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ItemUsage1
            {
                itemCode = _Row["itemCode"].ToString(),
                itemName = _Row["itemName"].ToString(),
                itemBarcode = _Row["AccountCode"].ToString()
            };
        }
    }
}

//public class DivInfo
//{

//    public string itemCode { get; set; }
//    public string itemDesc { get; set; }
//    public string controlNo { get; set; }

//    public static IEnumerable<DivInfo> GetDivInfo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
//    {
//        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDivs"));
//        WebReq.Method = "GET";
//        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
//        Console.WriteLine(WebResp.StatusCode);
//        Console.WriteLine(WebResp.Server);
//        string jsonString;
//        using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
//        {
//            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
//            jsonString = reader.ReadToEnd();
//        }
//        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
//        if (DivValue != "")
//        {
//            DataView oDV = new DataView(oDT_Master);
//            oDV.RowFilter = "itmCode='" + DivValue + "'";
//            oDT_Master = oDV.ToTable();
//        }


//        HttpWebRequest WebReq1 = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDepts"));
//        WebReq1.Method = "GET";
//        HttpWebResponse WebResp1 = (HttpWebResponse)WebReq1.GetResponse();
//        Console.WriteLine(WebResp1.StatusCode);
//        Console.WriteLine(WebResp1.Server);
//        string jsonString1;
//        using (Stream stream1 = WebResp1.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
//        {
//            StreamReader reader1 = new StreamReader(stream1, System.Text.Encoding.UTF8);
//            jsonString1 = reader1.ReadToEnd();
//        }
//        DataTable oDT_Master1 = (DataTable)JsonConvert.DeserializeObject(jsonString1, (typeof(DataTable)));
//        if (DivValue != "")
//        {
//            DataView oDV1 = new DataView(oDT_Master1);
//            oDV1.RowFilter = "itmDesc='" + oDT_Master.Rows[0]["itmDesc"].ToString() + "'";
//            oDT_Master1 = oDV1.ToTable();
//        }

//        HttpWebRequest WebReq2 = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ControlNos"));
//        WebReq2.Method = "GET";
//        HttpWebResponse WebResp2 = (HttpWebResponse)WebReq2.GetResponse();
//        string jsonString2;
//        using (Stream stream2 = WebResp2.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
//        {
//            StreamReader reader2 = new StreamReader(stream2, System.Text.Encoding.UTF8);
//            jsonString2 = reader2.ReadToEnd();
//        }
//        DataTable oDT_Master2 = (DataTable)JsonConvert.DeserializeObject(jsonString2, (typeof(DataTable)));
//        DataView oDV2 = new DataView(oDT_Master2);
//        oDV2.RowFilter = "controlDescription='STOCK CODE'";
//        oDT_Master2 = oDV2.ToTable();
//        var controlNo = oDT_Master2.Rows[0]["controlNo"].ToString();

//        if (oDT_Master1.Rows.Count > 0)
//        {
//            foreach (DataRow _Row in oDT_Master1.Rows)
//            {
//                yield return new DivInfo
//                {
//                    itemCode = _Row["itmCode"].ToString(),
//                    itemDesc = _Row["itmDesc"].ToString(),
//                    controlNo = controlNo
//                };
//            }
//        }
//        else
//        {
//            yield return new DivInfo
//            {
//                itemCode = "00",
//                itemDesc = "",
//                controlNo = controlNo
//            };
//        }
//    }
//}

public class DivInfo
{

    public string itemCode { get; set; }
    public string itemDesc { get; set; }
    public string controlNo { get; set; }

    public static IEnumerable<DivInfo> GetDivInfo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        //var client = new HttpClient();
        //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"]);
        //client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        ////GET Method  
        ////string codeDesc = "STOCK CODE";
        ////string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
        //string api = "api/GetDivRunningNo?DivCode=" + Value + "";
        ////string api = "api/GetDivRunningNo?div={" + Value + "}";
        //var response = client.GetAsync(api).Result;
        //var a = response.Content.ReadAsStringAsync().Result;
        //List<DivInfo> ControlNo = JsonConvert.DeserializeObject<List<DivInfo>>(a);


        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"] + "api/GetDivRunningNo?DivCode=" + Value + "");
        req.ContentType = "application/json;";
        req.Method = "GET";
        WebResponse response1 = req.GetResponse();
        Stream responseStream = response1.GetResponseStream();
        StreamReader sr = new StreamReader(responseStream);
        JavaScriptSerializer js = new JavaScriptSerializer();
        dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
        dynamic MyDynamic_Result = MyDynamic["result"];
        JavaScriptSerializer js_result = new JavaScriptSerializer();
        js_result.MaxJsonLength = Int32.MaxValue;
        js_result.RecursionLimit = 100;
        var json = js_result.Serialize(MyDynamic_Result);
        List<DivInfo> ControlNo = JsonConvert.DeserializeObject<List<DivInfo>>(json);
        //_retVal = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));


        yield return new DivInfo
        {
            itemCode = ControlNo[0].itemCode,
            itemDesc= ControlNo[0].itemDesc,
            //controlNo = ControlNo[0].controlNo.Substring(1, ControlNo[0].controlNo.Length - 1)
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class DeptInfo
{
    public string itemCode { get; set; }
    public string itemDesc { get; set; }
    public string controlNo { get; set; }

    public static IEnumerable<DeptInfo> GetDeptInfo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string div, string dept)
    {
        
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"] + "api/GetDeptRunningNo?DivCode=" + div + "&DeptCode=" + dept + "");
        req.ContentType = "application/json;";
        req.Method = "GET";
        WebResponse response1 = req.GetResponse();
        Stream responseStream = response1.GetResponseStream();
        StreamReader sr = new StreamReader(responseStream);
        JavaScriptSerializer js = new JavaScriptSerializer();
        dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
        dynamic MyDynamic_Result = MyDynamic["result"];
        JavaScriptSerializer js_result = new JavaScriptSerializer();
        js_result.MaxJsonLength = Int32.MaxValue;
        js_result.RecursionLimit = 100;
        var json = js_result.Serialize(MyDynamic_Result);
        List<DivInfo> ControlNo = JsonConvert.DeserializeObject<List<DivInfo>>(json);
        //_retVal = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));


        yield return new DeptInfo
        {
            itemCode = ControlNo[0].itemCode,
            itemDesc = ControlNo[0].itemDesc,
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class CodeCheckExist
{
    public string itmCode { get; set; }
    public static IEnumerable<CodeCheckExist> GetCodeCheckExist(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value, string Value1)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        if(Value=="Div")
        {
            string api = "api/itemdivs?filter={\"where\":{\"itmCode\":\"" + Value1 + "\"}}";
            var response = client.GetAsync(api).Result;
            var a = response.Content.ReadAsStringAsync().Result;
            List<CodeCheckExist> itmCode = JsonConvert.DeserializeObject<List<CodeCheckExist>>(a);
            if (itmCode.Count > 0)
            {
                yield return new CodeCheckExist
                {
                    //itmCode = (itmCode[0].itmCode.ToString() == "" ? Value1 : "")
                    itmCode = ""
                };
            }
            else
            {
                yield return new CodeCheckExist
                {
                    
                    itmCode = Value1
                };
            }
        }
        else if (Value == "Dept")
        {
            string api = "api/ItemDepts?filter={\"where\":{\"itmCode\":\"" + Value1 + "\"}}";
            var response = client.GetAsync(api).Result;
            var a = response.Content.ReadAsStringAsync().Result;
            List<CodeCheckExist> itmCode = JsonConvert.DeserializeObject<List<CodeCheckExist>>(a);
            if (itmCode.Count > 0)
            {
                yield return new CodeCheckExist
                {
                    //itmCode = (itmCode[0].itmCode.ToString() == "" ? Value1 : "")
                    itmCode = ""
                };
            }
            else
            {
                yield return new CodeCheckExist
                {

                    itmCode = Value1
                };
            }
        }
        else if (Value == "Class")
        {
            string api = "api/ItemClasses?filter={\"where\":{\"itmCode\":\"" + Value1 + "\"}}";
            var response = client.GetAsync(api).Result;
            var a = response.Content.ReadAsStringAsync().Result;
            List<CodeCheckExist> itmCode = JsonConvert.DeserializeObject<List<CodeCheckExist>>(a);
            if (itmCode.Count > 0)
            {
                yield return new CodeCheckExist
                {
                    //itmCode = (itmCode[0].itmCode.ToString() == "" ? Value1 : "")
                    itmCode = ""
                };
            }
            else
            {
                yield return new CodeCheckExist
                {

                    itmCode = Value1
                };
            }
        }
    }
}

public class BrandControlNo
{

    public string controlNo { get; set; }

    public static IEnumerable<BrandControlNo> GetBrandControlNo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string codeDesc = "BRAND CODE";
        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<BrandControlNo> ControlNo = JsonConvert.DeserializeObject<List<BrandControlNo>>(a);

        yield return new BrandControlNo
        {
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class DivControlNo
{

    public string controlNo { get; set; }

    public static IEnumerable<DivControlNo> GetDivControlNo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string codeDesc = "DIV CODE";
        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<DivControlNo> ControlNo = JsonConvert.DeserializeObject<List<DivControlNo>>(a);

        yield return new DivControlNo
        {
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class DeptControlNo
{

    public string controlNo { get; set; }

    public static IEnumerable<DeptControlNo> GetDeptControlNo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string codeDesc = "DEPT CODE";
        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<DeptControlNo> ControlNo = JsonConvert.DeserializeObject<List<DeptControlNo>>(a);

        yield return new DeptControlNo
        {
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class ClassControlNo
{

    public string controlNo { get; set; }

    public static IEnumerable<ClassControlNo> GetClassControlNo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string codeDesc = "CLASS CODE";
        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + codeDesc + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<ClassControlNo> ControlNo = JsonConvert.DeserializeObject<List<ClassControlNo>>(a);

        yield return new ClassControlNo
        {
            controlNo = ControlNo[0].controlNo
        };
    }
}

public class UsageUom
{

    public string uomCode { get; set; }
    public string uomDesc { get; set; }

    public static IEnumerable<UsageUom> GetUsageUom(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
    {
        ////HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemUOMs"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemUOMs"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //if (DivValue != "")
        //{
        //    DataView oDV = new DataView(oDT_Master);
        //    oDV.RowFilter = "itmCode='" + DivValue + "'";
        //    oDT_Master = oDV.ToTable();
        //}

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new UsageUom
            {
                uomCode = _Row["uomCode"].ToString(),
                uomDesc = _Row["uomDesc"].ToString()
            };
        }
    }
}

public class UsageUomPrice
{

    public string uomCode { get; set; }
    public string uomDesc { get; set; }

    public static IEnumerable<UsageUomPrice> GetUsageUomPrice(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemUomprices"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        if (DivValue != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itemCode='" + DivValue + "'";
            oDT_Master = oDV.ToTable();
        }

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new UsageUomPrice
            {
                uomCode = _Row["itemUom"].ToString(),
                uomDesc = _Row["uomDesc"].ToString()
            };
        }
    }
}

public class EmployeeLevel
{

    public string levelCode { get; set; }
    public string levelDesc { get; set; }

    public static IEnumerable<EmployeeLevel> GetEmployeeLevel(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //if (DivValue != "")
        //{
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "levelIsActive='True'";
            oDT_Master = oDV.ToTable();
        //}

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new EmployeeLevel
            {
                levelCode = _Row["levelCode"].ToString(),
                levelDesc = _Row["levelDesc"].ToString()
            };
        }
    }
}

public class RangeBasedDept
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }

    public static IEnumerable<RangeBasedDept> GetRangeBasedDept(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DeptValue)
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemRanges"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        if (DeptValue != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmDept='" + DeptValue + "'";
            oDT_Master = oDV.ToTable();
        }

        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new RangeBasedDept
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString()
            };
        }
    }
}

public class getDiv
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }

    public static IEnumerable<getDiv> GetgetDiv(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
    {
        //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://103.253.14.203:3000/api/ItemDivs"));
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/ItemDivs"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new getDiv
            {
                itmCode = _Row["itmCode"].ToString(),
                itmDesc = _Row["itmDesc"].ToString()
            };
        }
    }
}

public class PrepaidDept
{

    public string itmCode { get; set; }
    public string itmDesc { get; set; }

    public static IEnumerable<PrepaidDept> GetPrepaidDept(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string DivValue)
    {

        string apiName = "";
        if (DivValue == "Product Only")
            apiName = "ItemBrands";
        else
            apiName = "ItemDepts";

        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/" + apiName));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        if (DivValue == "Product Only")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmStatus =True and retailProductBrand = True";   // "itmStatus =True and isRetailproduct = True or isSalonproduct = True   ";
            oDT_Master = oDV.ToTable();
        }
        else if (DivValue == "Service Only")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "itmStatus =True and isService = True  ";
            oDT_Master = oDV.ToTable();
        }
        if (DivValue == "All")
        {
            yield return new PrepaidDept
            {
                itmCode = "All",
                itmDesc = "All"
            };
        }
        else
        {
            foreach (DataRow _Row in oDT_Master.Rows)
            {
                yield return new PrepaidDept
                {
                    itmCode = _Row["itmCode"].ToString(),
                    itmDesc = _Row["itmDesc"].ToString()
                };
            }
        }
    }
}



//Inventory

public class PackageItemSearchList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string Uom { get; set; }
    public string brand { get; set; }
    public string linkCode { get; set; }
    public string range { get; set; }
    public string quantity { get; set; }
    public string UomCode { get; set; }
    public string brandCode { get; set; }
    public string rangeCode { get; set; }

    public static IEnumerable<PackageItemSearchList> GetPackageItemSearchList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {


        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/stockdetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True and type='PACKAGE' ";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new PackageItemSearchList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                Uom = _Row["uomDescription"].ToString(),
                brand = _Row["brand"].ToString(),
                linkCode = _Row["linkCode"].ToString(),
                range = _Row["range"].ToString(),
                //quantity = (_Row["quantity"].ToString() == "" ? 0 : Convert.ToDecimal(_Row["quantity"]))
                quantity = _Row["quantity"].ToString(),
                UomCode = _Row["uom"].ToString(),
                brandCode = _Row["brandcode"].ToString(),
                rangeCode = _Row["rangecode"].ToString()

            };
        }
    }
}

public class ServiceItemSearchList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string Uom { get; set; }
    public string brand { get; set; }
    public string linkCode { get; set; }
    public string range { get; set; }
    public string quantity { get; set; }
    public string UomCode { get; set; }
    public string brandCode { get; set; }
    public string rangeCode { get; set; }

    public static IEnumerable<ServiceItemSearchList> GetServiceItemSearchList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {


        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/stockdetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True and division='Service' ";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ServiceItemSearchList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                Uom = _Row["uomDescription"].ToString(),
                brand = _Row["brand"].ToString(),
                linkCode = _Row["linkCode"].ToString(),
                range = _Row["range"].ToString(),
                //quantity = (_Row["quantity"].ToString() == "" ? 0 : Convert.ToDecimal(_Row["quantity"]))
                quantity = _Row["quantity"].ToString(),
                UomCode = _Row["uom"].ToString(),
                brandCode = _Row["brandcode"].ToString(),
                rangeCode = _Row["rangecode"].ToString()

            };
        }
    }
}

public class GRNItemSearchList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string Uom { get; set; }
    public string brand { get; set; }
    public string linkCode { get; set; }
    public string range { get; set; }
    public string quantity { get; set; }
    public string UomCode { get; set; }
    public string brandCode { get; set; }
    public string rangeCode { get; set; }

    public static IEnumerable<GRNItemSearchList> GetGRNItemSearchList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {


        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/stockdetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new GRNItemSearchList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                Uom = _Row["uomDescription"].ToString(),
                brand = _Row["brand"].ToString(),
                linkCode = _Row["linkCode"].ToString(),
                range = _Row["range"].ToString(),
                //quantity = (_Row["quantity"].ToString() == "" ? 0 : Convert.ToDecimal(_Row["quantity"]))
                quantity = _Row["quantity"].ToString(),
                UomCode = _Row["uom"].ToString(),
                brandCode = _Row["brandcode"].ToString(),
                rangeCode = _Row["rangecode"].ToString()

            };
        }
    }
}

public class POItemSearchList
{

    public string stockcode { get; set; }
    public string stockname { get; set; }
    public string Uom { get; set; }
    public string brand { get; set; }
    public string itemPrice { get; set; }
    public string quantity { get; set; }
    public string moqqty { get; set; }
    public string linkCode { get; set; }
    public string range { get; set; }
    public string UomCode { get; set; }
    public string brandCode { get; set; }
    public string rangeCode { get; set; }

    public static IEnumerable<POItemSearchList> GetPOItemSearchList(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string PKey)
    {


        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(System.Configuration.ConfigurationManager.AppSettings["uri"] + "api/stockdetails"));
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
        DataTable oDT_Master = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
        //DataTable oDT_Master = JsonConvert.DeserializeAnonymousType(jsonString, new { result = default(DataTable) }).result;
        if (PKey != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "" + PKey + " = True";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new POItemSearchList
            {
                stockcode = _Row["stockcode"].ToString(),
                stockname = _Row["stockname"].ToString(),
                Uom = _Row["uomDescription"].ToString(),
                brand = _Row["brand"].ToString(),
                itemPrice = _Row["itemPrice"].ToString(),
                quantity = _Row["quantity"].ToString(),
                moqqty = _Row["moqqty"].ToString(),
                linkCode = _Row["linkCode"].ToString(),
                range = _Row["range"].ToString(),
                UomCode = _Row["uom"].ToString(),
                brandCode = _Row["brandcode"].ToString(),
                rangeCode = _Row["rangecode"].ToString()

            };
        }
    }
}

public class Supplier
{
    public string splyCode { get; set; }
    public string supplydesc { get; set; }
    public string splyDate { get; set; }
    public string splyactive { get; set; }
    public string splyTelno { get; set; }
    public string numberOfTotalPOs { get; set; }

    public static IEnumerable<Supplier> GetSupplier(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/ItemSupplies";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<Supplier> SupplierInfo = JsonConvert.DeserializeObject<List<Supplier>>(a);

        foreach (var item in SupplierInfo)
        {
            yield return new Supplier
            {
                splyCode = item.splyCode,
                supplydesc = item.supplydesc,
                splyDate = Convert.ToDateTime(item.splyDate).ToString("dd/MM/yyyy"),
                splyactive = item.splyactive.ToString().ToUpper() == "1" ? "Yes" : "No",
                splyTelno = item.splyTelno,
                numberOfTotalPOs = item.numberOfTotalPOs
            };
        }
    }
}

public class SupplierInfo
{
    public string splyAttn { get; set; }
    public string splyAddr1 { get; set; }
    public string splyAddr2 { get; set; }
    public string splyAddr3 { get; set; }
    public string splyPoscd { get; set; }
    public string splyCity { get; set; }
    public string splyState { get; set; }
    public string splyCntry { get; set; }
    public string splyRemk1 { get; set; }
    public string splyRemk2 { get; set; }
    public string splymaddr1 { get; set; }
    public string splymaddr2 { get; set; }
    public string splymaddr3 { get; set; }
    public string splymposcd { get; set; }
    public string splymcity { get; set; }
    public string splymstate { get; set; }
    public string splymcntry { get; set; }

    public static IEnumerable<SupplierInfo> GetSupplierInfo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/ItemSupplies?filter={\"where\":{\"splyCode\":\"" + Value + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<SupplierInfo> SupplierInfo = JsonConvert.DeserializeObject<List<SupplierInfo>>(a);

        yield return new SupplierInfo
        {
            splyAttn = SupplierInfo[0].splyAttn,
            splyAddr1 = SupplierInfo[0].splyAddr1,
            splyAddr2 = SupplierInfo[0].splyAddr2,
            splyAddr3 = SupplierInfo[0].splyAddr3,
            splyPoscd = SupplierInfo[0].splyPoscd,
            splyCity = SupplierInfo[0].splyCity,
            splyState = SupplierInfo[0].splyState,
            splyCntry = SupplierInfo[0].splyCntry,
            splyRemk1 = SupplierInfo[0].splyRemk1,
            splyRemk2 = SupplierInfo[0].splyRemk2,
            splymaddr1 = SupplierInfo[0].splymaddr1,
            splymaddr2 = SupplierInfo[0].splymaddr2,
            splymaddr3 = SupplierInfo[0].splymaddr3,
            splymposcd = SupplierInfo[0].splymposcd,
            splymcity = SupplierInfo[0].splymcity,
            splymstate = SupplierInfo[0].splymstate,
            splymcntry = SupplierInfo[0].splymcntry

        };
    }
}

public class GetControlNo
{
    public string controlPrefix { get; set; }
    public string siteCode { get; set; }
    public string controlNo { get; set; }

    public static IEnumerable<GetControlNo> GetControlNoInfo(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        string api = "api/ControlNos?filter={\"where\":{\"controlDescription\":\"" + Value + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<GetControlNo> ControlNo = JsonConvert.DeserializeObject<List<GetControlNo>>(a);

        yield return new GetControlNo
        {
            controlPrefix = ControlNo[0].controlPrefix,
            siteCode = ControlNo[0].siteCode,
            controlNo = ControlNo[0].controlNo
        };
    }
}


public class GRNListMaster
{

    public string docNo { get; set; }
    public string docDate { get; set; }
    public string docRef1 { get; set; }
    public string supplyNo { get; set; }
    public string docAmt { get; set; }
    public string recStatus { get; set; }
    public string PoNo { get; set; }
    

    public static IEnumerable<GRNListMaster> GetGRNListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/StkMovdocHdrs?filter={\"where\":{\"movCode\":\"" + Value + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<GRNListMaster> GRNListMasterInfo = JsonConvert.DeserializeObject<List<GRNListMaster>>(a);
        List<GRNListMaster> GRNListMasterInfo1 = GRNListMasterInfo.Where(f => f.PoNo == "" || f.PoNo == null ).ToList();

        foreach (var item in GRNListMasterInfo1)
        {
            yield return new GRNListMaster
            {
                docNo = item.docNo,
                docDate = Convert.ToDateTime(item.docDate).ToString("dd/MM/yyyy"),
                docRef1 = item.docRef1,
                supplyNo = item.supplyNo,
                docAmt = item.docAmt,
                recStatus = item.recStatus== null ? "Open": item.recStatus.ToString() == "1" ? "Posted" : "Open"
            };
        }
    }
}

public class REQListMaster
{

    public string reqNo { get; set; }
    public string reqDate { get; set; }
    public string supplierName { get; set; }
    public string reqTtqty { get; set; }
    public string reqStatus { get; set; }
    public string reqRemk1 { get; set; }

    public static IEnumerable<REQListMaster> GetREQListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/reqs";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<REQListMaster> REQListMasterInfo = JsonConvert.DeserializeObject<List<REQListMaster>>(a);

        foreach (var item in REQListMasterInfo)
        {
            yield return new REQListMaster
            {
                reqNo = item.reqNo,
                reqDate = Convert.ToDateTime(item.reqDate).ToString("dd/MM/yyyy"),
                supplierName = item.supplierName,
                reqTtqty = item.reqTtqty,
                reqStatus = item.reqStatus,
                reqRemk1 = item.reqRemk1
            };
        }
    }
}

public class POListMaster
{

    public string poNo { get; set; }
    public string poDate { get; set; }
    public string suppCode { get; set; }
    public string poTtqty { get; set; }
    public string poStatus { get; set; }
    public string poRemk1 { get; set; }

    public static IEnumerable<POListMaster> GetPOListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/pos";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<POListMaster> POListMasterInfo = JsonConvert.DeserializeObject<List<POListMaster>>(a);

        foreach (var item in POListMasterInfo)
        {
            yield return new POListMaster
            {
                poNo = item.poNo,
                poDate = Convert.ToDateTime(item.poDate).ToString("dd/MM/yyyy"),
                suppCode = item.suppCode,
                poTtqty = item.poTtqty,
                poStatus = item.poStatus,
                poRemk1 = item.poRemk1
            };
        }
    }
}

public class AppListMaster
{

    public string ponumber { get; set; }
    public string pono { get; set; }
    public string podate { get; set; }
    public string supplier { get; set; }
    public string pototalqty { get; set; }
    public string appqty { get; set; }
    public string postatus { get; set; }
    public string poremark { get; set; }

    public static IEnumerable<AppListMaster> GetAppListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        //string api = "api/approvedpolists";
        string api = "api/approveddolists";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<AppListMaster> AppListMasterInfo = JsonConvert.DeserializeObject<List<AppListMaster>>(a);
        List<AppListMaster> AppListMasterInfo1 = AppListMasterInfo.Where(f => f.postatus == "Posted" || f.postatus == "Approved").ToList();

        foreach (var item in AppListMasterInfo1)
        {
            yield return new AppListMaster
            {
                ponumber = item.ponumber,
                pono = item.pono,
                podate = Convert.ToDateTime(item.podate).ToString("dd/MM/yyyy"),
                supplier = item.supplier,
                pototalqty = item.pototalqty,
                appqty = item.appqty,
                postatus = item.postatus,
                poremark = item.poremark
            };
        }
    }
}

public class AppGRNListMaster
{

    public string grnno { get; set; }
    public string poNumber { get; set; }
    public string podate { get; set; }
    public string supplier { get; set; }
    public string pototalqty { get; set; }
    public string appqty { get; set; }
    public string postatus { get; set; }
    public string poremark { get; set; }

    public static IEnumerable<AppGRNListMaster> GetAppGRNListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/approvedGRNlists";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<AppGRNListMaster> AppListMasterInfo = JsonConvert.DeserializeObject<List<AppGRNListMaster>>(a);
        List<AppGRNListMaster> AppListMasterInfo1 = AppListMasterInfo.Where(f => f.postatus == "Posted" || f.postatus == "Approved").ToList();

        foreach (var item in AppListMasterInfo1)
        {
            yield return new AppGRNListMaster
            {
                grnno = item.grnno,
                poNumber = item.poNumber,
                podate = Convert.ToDateTime(item.podate).ToString("dd/MM/yyyy"),
                supplier = item.supplier,
                pototalqty = item.pototalqty,
                appqty = item.appqty,
                postatus = item.postatus,
                poremark = item.poremark
            };
        }
    }
}

public class AppDOGRNListMaster
{

    public string grnno { get; set; }
    public string donumber { get; set; }
    public string dodate { get; set; }
    public string supplier { get; set; }
    public string dototalqty { get; set; }
    public string appqty { get; set; }
    public string dostatus { get; set; }
    public string doremark { get; set; }

    public static IEnumerable<AppDOGRNListMaster> GetAppDOGRNListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/approvedDOGRNlists";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<AppDOGRNListMaster> AppListMasterInfo = JsonConvert.DeserializeObject<List<AppDOGRNListMaster>>(a);
        List<AppDOGRNListMaster> AppListMasterInfo1 = AppListMasterInfo.Where(f => f.dostatus == "Delivered" || f.dostatus == "Approved").ToList();

        foreach (var item in AppListMasterInfo1)
        {
            yield return new AppDOGRNListMaster
            {
                grnno = item.grnno,
                donumber = item.donumber,
                dodate = Convert.ToDateTime(item.dodate).ToString("dd/MM/yyyy"),
                supplier = item.supplier,
                dototalqty = item.dototalqty,
                appqty = item.appqty,
                dostatus = item.dostatus,
                doremark = item.doremark
            };
        }
    }
}

public class GRNOutListMaster
{

    public string docNo { get; set; }
    public string docDate { get; set; }
    public string docRef1 { get; set; }
    public string docRef2 { get; set; }
    public string docAmt { get; set; }
    public string recStatus { get; set; }

    public static IEnumerable<GRNOutListMaster> GetGRNOutListMaster(string _UserCode, string _SiteCode, CommonEngine oCommonEngine, string Value)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        string api = "api/StkMovdocHdrs?filter={\"where\":{\"movCode\":\"" + Value + "\"}}";
        var response = client.GetAsync(api).Result;
        var a = response.Content.ReadAsStringAsync().Result;
        List<GRNOutListMaster> GRNOutListMasterInfo = JsonConvert.DeserializeObject<List<GRNOutListMaster>>(a);

        foreach (var item in GRNOutListMasterInfo)
        {
            yield return new GRNOutListMaster
            {
                docNo = item.docNo,
                docDate = Convert.ToDateTime(item.docDate).ToString("dd/MM/yyyy"),
                docRef1 = item.docRef1,
                docRef2 = item.docRef2,
                docAmt = item.docAmt,
                recStatus = item.recStatus == null ? "Open" : item.recStatus.ToString() == "1" ? "Posted" : "Open"
            };
        }
    }
}

//Inventory

public class Course
{
   
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string Category { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
    public string Status { get; set; }


    public static IEnumerable<Course> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Course'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Course
            {
                CourseCode = _Row["CourseCode"].ToString(),
                CourseName = _Row["CourseName"].ToString(),
                Category = _Row["Category"].ToString(),
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString()),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Module
{
    public string ModuleCode { get; set; }
    public string ModuleName { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
    public string Status { get; set; }


    public static IEnumerable<Module> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Module'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Module
            {
                ModuleCode = _Row["ModuleCode"].ToString(),
                ModuleName = _Row["ModuleName"].ToString(),
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString()),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Product
{

    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string ProductGroup { get; set; }
    public string UOM { get; set; }
    public decimal Cost { get; set; }
    public string Status { get; set; }


    public static IEnumerable<Product> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Product'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Product
            {
                ProductCode = _Row["ProductCode"].ToString(),
                ProductName = _Row["ProductName"].ToString(),
                ProductGroup = _Row["ProductGroup"].ToString(),
                UOM = _Row["UOM"].ToString(),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString()),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Employee
{
   

    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeType { get; set; }
    public string Contact { get; set; }
    public string Status { get; set; }

    public static IEnumerable<Employee> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Employee'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Employee
            {
                EmployeeCode = _Row["EmployeeCode"].ToString(),
                EmployeeName = _Row["EmployeeName"].ToString(),
                EmployeeType = _Row["EmployeeType"].ToString(),
                Contact = _Row["Contact"].ToString(),              
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class User
{
 
    public string UserCode { get; set; }
    public string UserName { get; set; }
    public string UserType { get; set; }

    public string Status { get; set; }


    public static IEnumerable<User> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)

    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','User'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new User
            {
                UserCode = _Row["UserCode"].ToString(),
                UserName = _Row["UserName"].ToString(),
                UserType = _Row["UserType"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Site
{
   
    public string SiteCode { get; set; }
    public string SiteName { get; set; }
    public string Address { get; set; }

    public string Status { get; set; }


    public static IEnumerable<Site> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master =oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Site'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Site
            {
                SiteCode = _Row["SiteCode"].ToString(),
                SiteName = _Row["SiteName"].ToString(),
                Address = _Row["Address"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Lead
{

    public string LeadCode { get; set; }
    public string LeadName { get; set; }
    public string AddedDate { get; set; }
    public string LeadSource { get; set; }
    public string Contact { get; set; }
    public string Status { get; set; }

    public string LeadStatus { get; set; }

    public string Courses { get; set; }


    public static IEnumerable<Lead> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Lead'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Lead
            {
                LeadCode = _Row["LeadCode"].ToString(),
                LeadName = _Row["LeadName"].ToString(),
                AddedDate = _Row["AddedDate"].ToString(),
                LeadSource = _Row["LeadSource"].ToString(),
                Contact = _Row["Contact"].ToString(),               
                Status = _Row["Status"].ToString(),
                LeadStatus= _Row["LeadStatus"].ToString(),
                Courses= _Row["Courses"].ToString()
            };
        }

    }
}

public class ActivityTable
{

    public string Date { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Source { get; set; }
    public string Subject { get; set; }
    public string DateInfo { get; set; }
    public string Status { get; set; }

    public static IEnumerable<ActivityTable> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Activity'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new ActivityTable
            {
                Date = _Row["Date"].ToString(),
                Code = _Row["Code"].ToString(),
                Name = _Row["Name"].ToString(),
                Source = _Row["Source"].ToString(),
                Subject = _Row["Subject"].ToString(),
                DateInfo = _Row["DateInfo"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Corporate
{
  
    public string CorporateCode { get; set; }
    public string CorporateName { get; set; }
    public string Address { get; set; }
    public string StudentCount { get; set; }
    public string Status { get; set; }

    public static IEnumerable<Corporate> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string InActive)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Corporate'");
        if (InActive != "")
        {
            DataView oDV = new DataView(oDT_Master);
            oDV.RowFilter = "Status='" + InActive + "'";
            oDT_Master = oDV.ToTable();
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Corporate
            {
                CorporateCode = _Row["CorporateCode"].ToString(),
                CorporateName = _Row["CorporateName"].ToString(),
                Address = _Row["Address"].ToString(),
                StudentCount = _Row["StudentCount"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class LeadGroup
{
   
    public string LeadGroupCode { get; set; }
    public string LeadGroupName { get; set; }
    public string DateAdded { get; set; }
    public string LeadsCount { get; set; }
    public string Status { get; set; }

    public static IEnumerable<LeadGroup> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','LeadGroup'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new LeadGroup
            {
                LeadGroupCode = _Row["Code"].ToString(),
                LeadGroupName = _Row["Name"].ToString(),
                DateAdded = _Row["AddedDate"].ToString(),
                LeadsCount = _Row["LeadsCount"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class CampaignLeadGroup
{

    public string LeadGroupCode { get; set; }
    public string LeadGroupName { get; set; }
    public string DateAdded { get; set; }
    public string LeadsCount { get; set; }


    public static IEnumerable<CampaignLeadGroup> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string Code)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T1.Code,T1.Name,Convert(Varchar(10),T1.AddedDate,103) [DateAdded],(Select Count(*) from LeadGroup_Info X Where X.Code=T1.Code) [LeadCount] from LeadGroup T1 Where T1.Code='"+ Code + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CampaignLeadGroup
            {
                LeadGroupCode = _Row["Code"].ToString(),
                LeadGroupName = _Row["Name"].ToString(),
                DateAdded = _Row["DateAdded"].ToString(),
                LeadsCount = _Row["LeadCount"].ToString()
            };
        }

    }
}

public class TemplateCL
{

    public string Code { get; set; }
    public string Name { get; set; }
    public string DateAdded { get; set; }
    public string Format { get; set; }
    public string Status { get; set; }

    public static IEnumerable<TemplateCL> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Template'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new TemplateCL
            {
                Code = _Row["Code"].ToString(),
                Name = _Row["Name"].ToString(),
                DateAdded = _Row["AddedDate"].ToString(),
                Format = _Row["Format"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class CampaignMaster
{

    public string Code { get; set; }
    public string Name { get; set; }
    public string DateAdded { get; set; }
    public string LastRun { get; set; }

    public string Status { get; set; }
    public static IEnumerable<CampaignMaster> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Campaign'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CampaignMaster
            {
                Code = _Row["Code"].ToString(),
                Name = _Row["Name"].ToString(),
                DateAdded = _Row["AddedDate"].ToString(),
                LastRun = _Row["LastRun"].ToString(),
                Status = _Row["Status"].ToString()
            };
        }

    }
}

public class Menu
{
   
    public string MenuCode { get; set; }
    public string MenuName { get; set; }
    public string Authorization { get; set; }

    public static IEnumerable<Menu> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','Menu'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new Menu
            {
                MenuCode = _Row["MenuCode"].ToString(),
                MenuName = _Row["MenuName"].ToString(),
                Authorization = _Row["Authorization"].ToString()
            };
        }

    }
}

public class InvoiceListPage
{
 
    public string InvoiceNo { get; set; }
    public string InvoiceDate { get; set; }
    public string StudentName { get; set; }
    public string InvoiceTotal { get; set; }
    public string Paid { get; set; }
    public string Outstanding { get; set; }

    public static IEnumerable<InvoiceListPage> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_SalesDocuments] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','List','Invoice'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new InvoiceListPage
            {
                InvoiceNo = _Row["InvoiceNo"].ToString(),
                InvoiceDate = _Row["InvoiceDate"].ToString(),
                StudentName = _Row["StudentName"].ToString(),
                InvoiceTotal = _Row["InvoiceTotal"].ToString(),
                Paid = _Row["PaidToDate"].ToString(),
                Outstanding = _Row["OutStanding"].ToString()
            };
        }

    }
}

public class QuotationListPage
{

    public string InvoiceNo { get; set; }
    public string InvoiceDate { get; set; }
    public string StudentName { get; set; }
    public string InvoiceTotal { get; set; }


    public static IEnumerable<QuotationListPage> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_SalesDocuments] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','List','Quotation'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new QuotationListPage
            {
                InvoiceNo = _Row["InvoiceNo"].ToString(),
                InvoiceDate = _Row["InvoiceDate"].ToString(),
                StudentName = _Row["StudentName"].ToString(),
                InvoiceTotal = _Row["InvoiceTotal"].ToString()
            };
        }

    }
}

public class PaymentListPage
{

    public string PaymentNo { get; set; }
    public string PaymentDate { get; set; }
    public string StudentName { get; set; }
    public string PaymentTotal { get; set; }
   
    public static IEnumerable<PaymentListPage> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_SalesDocuments] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','List','Payment'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new PaymentListPage
            {
                PaymentNo = _Row["PaymentNo"].ToString(),
                PaymentDate = _Row["PaymentDate"].ToString(),
                StudentName = _Row["StudentName"].ToString(),              
                PaymentTotal = _Row["PaymentTotal"].ToString()
            };
        }

    }
}

public class CorporateInvoiceListPage
{
    public string InvoiceNo { get; set; }
    public string InvoiceDate { get; set; }
    public string CorporateName { get; set; }
    public string InvoiceTotal { get; set; }
    public string OutStanding { get; set; }
    
    public static IEnumerable<CorporateInvoiceListPage> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_CorporateSalesDocuments] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','List','Invoice'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CorporateInvoiceListPage
            {
                InvoiceNo = _Row["InvoiceNo"].ToString(),
                InvoiceDate = _Row["InvoiceDate"].ToString(),
                CorporateName = _Row["CorporateName"].ToString(),
                InvoiceTotal = _Row["InvoiceTotal"].ToString(),
                OutStanding = _Row["OutStanding"].ToString()
            };
        }

    }
}

public class CommonMasterList
{

    public string Code { get; set; }
    public string Name { get; set; }
    public string InActive { get; set; }
    public string RefCount { get; set; }
    
    public static IEnumerable<CommonMasterList> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string Type)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master =oCommonEngine.ExecuteDataTable("EXEC [Get_Masters] '" + _UserCode.Trim() + "','" + _SiteCode.Trim() + "','" + Type + "'");
        if (oDT_Master.Rows.Count > 0)
        {
            if (oDT_Master.Rows[oDT_Master.Rows.Count - 1][0].ToString() == "DEFINE-NEW")
            {
                oDT_Master.Rows.RemoveAt(oDT_Master.Rows.Count - 1);
            }
        }
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CommonMasterList
            {
                Code = _Row["Code"].ToString(),
                Name = _Row["Name"].ToString(),
                InActive = _Row["InActive"].ToString()
              
            };
        }

    }
}

public class CourseModule
{
    public string ModuleCode { get; set; }
    public string ModuleName { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
    
    public static IEnumerable<CourseModule> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.ModuleCode,T0.ModuleName,T0.Duration,T0.Cost from  ModuleMaster T0  Where T0.ModuleCode='" + PKey + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CourseModule
            {
                ModuleCode = _Row["ModuleCode"].ToString(),
                ModuleName = _Row["ModuleName"].ToString(),
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString())
            };
        }

    }
}

public class EmployeeCourse
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string Category { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
   
    public static IEnumerable<EmployeeCourse> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.CourseCode,T0.CourseName,T0.Category,T0.Duration,T0.Cost from CourseMaster T0 Where T0.CourseCode='" + PKey + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new EmployeeCourse
            {
                CourseCode = _Row["CourseCode"].ToString(),
                CourseName = _Row["CourseName"].ToString(),
                Category = _Row["Category"].ToString(),
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString())
            };
        }

    }
}

public class CourseInfo
{
  
    public string CourseCode { get; set; }   
    public string CompCode { get; set; }
    public string Category { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
    public string CourseMode { get; set; }
    public string TrainingArea { get; set; }
    public string Industry { get; set; }
    public string AccreditationScope { get; set; }
    public string CourseOrigin { get; set; }
   
    public static IEnumerable<CourseInfo> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.CourseCode,T0.CompCode,T2.Name,T0.Duration,T0.Cost,T0.CourseMode,T0.TraningArea,T0.Industry,T0.AccreditationScope,T0.CourseOrigin from CourseMaster T0 JOIN CategoryMaster T2 ON T2.Code=T0.Category Where T0.CourseCode='"+ PKey + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CourseInfo
            {
                CourseCode = _Row["CourseCode"].ToString(),
                CompCode = _Row["CompCode"].ToString(),
                Category = _Row["Name"].ToString(),
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString()),
                CourseMode = _Row["CourseMode"].ToString(),
                TrainingArea = _Row["TraningArea"].ToString(),
                Industry = _Row["Industry"].ToString(),
                AccreditationScope = _Row["AccreditationScope"].ToString(),
                CourseOrigin = _Row["CourseOrigin"].ToString(),              
            };
        }

    }
}

public class SyllabusInfo
{
   
    public string Topic { get; set; }
    public string Trainer { get; set; }
    public string Duration { get; set; }
    public string Room { get; set; }
   

    public static IEnumerable<SyllabusInfo> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey, string DateValue)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.TopicName+' ('+T0.ModuleCode+')' [Topic],T1.EmployeeName [Trainer],T0.Duration,T0.Room from CourseSyllabus T0 JOIN EmployeeMaster T1 ON T0.EmployeeCode=T1.EmployeeCode Where T0.SchedulerKey='" + PKey + "' And Convert(Varchar(10),T0.StartDate,112)='" + DateValue + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new SyllabusInfo
            {
                Topic = _Row["Topic"].ToString(),
                Trainer = _Row["Trainer"].ToString(),
                Duration = _Row["Duration"].ToString(),
                Room = _Row["Room"].ToString(),               
            };
        }

    }
}

public class CourseProduct
{
  
    public string ProductCode { get; set; }
    public string ProductName { get; set; }   
    public string UOM { get; set; }
    public decimal Cost { get; set; }
   
    public static IEnumerable<CourseProduct> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.ProductCode,T0.ProductName,T0.UOM,T0.Cost from ProductMaster T0 Where T0.ProductCode='" + PKey + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CourseProduct
            {
                ProductCode = _Row["ProductCode"].ToString(),
                ProductName = _Row["ProductName"].ToString(),             
                UOM = _Row["UOM"].ToString(),
                Cost = Convert.ToDecimal(_Row["Cost"].ToString())
            };
        }

    }
}

public class CourseEnrollmentStudent
{
    public string StudentCode { get; set; }
    public string StudentName { get; set; }
    public string Contact { get; set; }
    public string EMail { get; set; }
    public string RegistrationDate { get; set; }
  
    public static IEnumerable<CourseEnrollmentStudent> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string PKey)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("Select T0.StudentCode,T0.StudentName,T0.Contact,T0.EMail,Convert(Varchar(10),T0.RegDate,103) [RegDate] from StudentMaster T0 Where T0.StudentCode='" + PKey + "'");
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CourseEnrollmentStudent
            {
                StudentCode = _Row["StudentCode"].ToString(),
                StudentName = _Row["StudentName"].ToString(),
                Contact = _Row["Contact"].ToString(),
                EMail = _Row["EMail"].ToString(),
                RegistrationDate = _Row["RegDate"].ToString(),
            };
        }

    }
}

public class CourseSyllabus
{

    public string LineNo { get; set; }
    public string ModuleCode { get; set; }
    public string ModuleName { get; set; }
    public string TopicName { get; set; }
    public string StartDate { get; set; }
    public string StartTime { get; set; }
    public string Day { get; set; }
    public decimal Duration { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Sequence { get; set; }
    public string Room { get; set; }
    public string Status { get; set; }
    public string Info { get; set; }
    public string Note1 { get; set; }
    public string Note2 { get; set; }
    public string URL { get; set; }

    public static IEnumerable<CourseSyllabus> GetMasters(string _UserCode, string _SiteCode, CommonEngine oCommonEngine,string Course, string Employee, string StartDate, string StartTime, string SchedulerType, string ScheduleWeek, string SortBy)
    {
        DataTable oDT_Master = new DataTable();
        oDT_Master = oCommonEngine.ExecuteDataTable("EXEC [Get_Syllabus] '"+ _UserCode.Trim()+"','"+ _SiteCode.Trim() + "','"+ Course.Trim() + "','"+ Employee.Trim() + "','"+ StartDate.Trim() + "','"+ StartTime.Trim() + "','"+ SchedulerType.Trim() + "','"+ ScheduleWeek.Trim() + "','"+ SortBy.Trim() + "'");
       
        foreach (DataRow _Row in oDT_Master.Rows)
        {
            yield return new CourseSyllabus
            {
                LineNo= _Row["LineNo"].ToString(),
                ModuleCode = _Row["ModuleCode"].ToString(),
                ModuleName = _Row["ModuleName"].ToString(),
                TopicName = _Row["TopicName"].ToString(),
                StartDate = _Row["StartDate"].ToString(),
                StartTime = _Row["StartTime"].ToString(),
                Day = _Row["Day"].ToString(),               
                Duration = Convert.ToDecimal(_Row["Duration"].ToString()),
                EmployeeCode = _Row["EmployeeCode"].ToString(),
                EmployeeName = _Row["EmployeeName"].ToString(),
                Sequence = _Row["Sequence"].ToString(),
                Room = _Row["Room"].ToString(),
                Status = _Row["Status"].ToString(),                
                Info = _Row["Info"].ToString()   ,
                Note1 = _Row["Note1"].ToString(),
                Note2 = _Row["Note2"].ToString(),
                URL = _Row["URL"].ToString()

            };
        }

    }
}









