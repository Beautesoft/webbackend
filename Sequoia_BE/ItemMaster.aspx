<%@ Page Title="Article Master" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="Sequoia_BE.ItemMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    
    <section class="content-header">
        <h1>Article Master       
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="ItemMasterList.aspx">Article Master</a></li>
            <li class="active">Add</li>
        </ol>
    </section>

    <section class="content">

        <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-default">

                <div class="box-header with-border">
                    <h3 class="box-title">Stock Item Data Entry</h3>
                </div>
                <!-- /.box-header -->

                <div class="box-body">

                    <div class="panel-heading" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divGeneral">
                        <h3 class="panel-title">General</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divGeneral">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group required">
                                    <label class="control-label">Stock Division</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Div">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <button id="btn_AddDivItemMaster" type="button" runat="server" class="btn btn-primary2" style="visibility: hidden">Add New</button>
                                </div>
                            </div>

                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                   <%-- <input type="text" runat="server" id="txt_ItemMasterDivisonCode" maxlength="255" disabled="disabled">
                                    <input type="text" runat="server" id="txt_ItemMasterDeptCode" maxlength="255" disabled="disabled">--%>
                                    <input type="text" runat="server" id="txt_RunningNo1" maxlength="255" disabled="disabled"><%--style="visibility:hidden"--%>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <input type="text" runat="server" id="txt_RunningNo2" maxlength="255" disabled="disabled">
                                </div>
                            </div>
                            <div class="col-md-4" style="margin-top: 2%">
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group required">
                                    <label class="control-label">Department</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Dept" name="ddl_Dept">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <button id="btn_AddDeptItemMaster" type="button" runat="server" class="btn btn-primary2">Add New</button>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group required">
                                    <label class="control-label">Class</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Class">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <button id="btn_AddClassItemMaster" type="button" runat="server" class="btn btn-primary2">Add New</button>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group required">
                                    <label class="control-label">Brand</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Brand">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <button id="btn_AddBrandItemMaster" type="button" runat="server" class="btn btn-primary2">Add New</button>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group required">
                                    <label class="control-label">Range</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Range">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%; display: none">
                                <div class="form-group">
                                    <button id="btn_AddRangeItemMaster" type="button" runat="server" class="btn btn-primary">Add New</button>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Picture</label>
                                </div>
                                <div class="form-group">
                                    <input id="fileupload" type="file" />
                                </div>
                            </div>
                            <div class="col-md-6">

                                <div class="form-group">


                                    <hr />
                                    <%--<b>Live Preview</b>--%>
                                    <%--<br />
                            <br />--%>
                                    <div id="dvPreview">
                                    </div>
                                    <label id='lblImageName'></label>
                                    <%--<button id='removeImg'>Remove Image</button>--%>
                                </div>
                            </div>
                        </div>
                        <%--</fieldset>
            </asp:Panel>--%>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Stock Name</label>
                                    <input type="text" class="form-control" runat="server" id="txt_StockName" maxlength="255" placeholder="Enter Stock Name" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Description</label>
                                    <input type="text" class="form-control" runat="server" id="txt_StockDesc" maxlength="255" placeholder="Enter Stock Description" clientidmode="Static" />
                                </div>

                            </div>
                        </div>



                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Stock Type</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_stockType">
                                    </select>
                                        <%--<option value="SINGLE">SINGLE</option>
                                    <option value="PACKAGE">PACKAGE</option>
                                    <option value="COURSE">COURSE</option>--%>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Duration (Minutes)</label>
                                    <input type="number" min="0" class="form-control" runat="server" id="txt_DurationMinutes" oninput="this.value = !!this.value && Math.abs(this.value) >= 0 ? Math.abs(this.value) : null" placeholder="Enter Duration">


                                    <label class="control-label" id="lblopenPrepiad" style="display: none">Check</label>
                                    <div class="checkbox icheck">
                                        <label id="OpenCodeId" style="display: none">
                                            <input type="checkbox" runat="server" id="chk_AutoAddOpenCode">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Auto Add Course
                                        </label>
                                        <label id="PrepaidId" style="display: none">
                                            <input type="checkbox" runat="server" id="chk_openPrepaid">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Open Prepaid
                                        </label>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row" id="supplierId" style="display: none">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Supplier Code</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_supplier">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>

                        <div class="row" id="PriceId">
                            <div class="col-md-3" id="PriceId1">
                                <div class="form-group">
                                    <label class="control-label">Price</label>
                                    <input type="number" class="form-control" runat="server" id="txt_price" placeholder="Enter Price">
                                </div>
                            </div>
                            <div class="col-md-3" id="PriceId2">
                                <div class="form-group">
                                    <label class="control-label">Floor Price</label>
                                    <input type="number" class="form-control" runat="server" id="txt_floorPrice" placeholder="Enter Floor Price">
                                </div>

                            </div>
                            <div class="col-md-3" id="PriceId3">
                                <div class="form-group">
                                    <label class="control-label">Cost</label>
                                    <input type="number" class="form-control" runat="server" id="txt_Cost" placeholder="Enter Cost">
                                </div>

                            </div>
                            <div class="col-md-3" id="PriceId4">
                                <div class="form-group">
                                    <label class="control-label">Check</label>
                                    <div class="checkbox icheck">
                                        <label>
                                            <input type="checkbox" runat="server" id="chk_Percent">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Percent
                                        </label>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row" id="DiscId">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Discount Limit</label>
                                    <input type="number" class="form-control" runat="server" id="txt_Disc" placeholder="Enter Discount">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Check</label>
                                    <div class="checkbox icheck">
                                         <input type="checkbox" runat="server" id="chk_discType" name="percent" checked="checked">
                                         <label for="percent" style="margin-left: 15px">Percent</label>

                                         <span style="margin-left: 35px">
                                             <input type="checkbox" runat="server" id="chk_AutoCustDisc" name="autocustdisc" checked="checked">
                                             <label for="autocustdisc">Auto Cust Disc</label>
                                         </span>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2" style="margin-left: 15px">
                                <div class="form-group">
                                    <div class="checkbox icheck" >
                                            <input type="checkbox" checked="checked" runat="server" name="active" id="chk_Active">
                                            <label for="active" style="margin-left: 15px">Active</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="checkbox icheck">
                                        <input type="checkbox" runat="server" id="chk_Commissionable" name="commissionable" onchange="CommisionClick(this)">
                                        <label for="commissionable" style="margin-left: 15px">Commissionable</label>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="checkbox icheck">
                                        <input type="checkbox" runat="server" id="chk_RedeemItem" name="redeemItem" >
                                        <label for="redeemItem" style="margin-left: 15px">Redeem Item</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="checkbox icheck">
                                        <input type="checkbox" runat="server" id="chk_Tax" name="tax" onchange="TaxClick(this)">
                                        <label for="tax" style="margin-left: 15px">Tax</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="checkbox icheck">
                                        <input type="checkbox" runat="server" id="chk_ItemallowFOC" name="itemallowfoc">
                                        <label for="itemallowfoc" style="margin-left: 15px">Item allow FOC</label>
                                    </div>
                                </div>
                            </div>

                        </div>


                    </div>

                   <%-- <br id="brid1_ItemMaster" runat="server" clientidmode="Static"/>--%>

                    <div class="panel-heading" style="display: none" clientidmode="Static"  runat="server" id="divCommissionHeader" data-toggle="collapse" data-parent="#accordion2" href="#divCommission" aria-expanded="false">
                        <h3 class="panel-title">Commission</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" runat="server" clientidmode="Static"  id="divCommission" style="display: none">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Sales Commission Group</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlSalesCommGroup_itemMaster"></select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Sales Points</label>
                                    <input type="text" class="form-control" runat="server" id="txtSalesPoints_ItemMaster" maxlength="255" placeholder="Enter Sales Points" clientidmode="Static" />
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Work Commission Group</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlWorkCommGroup_itemMaster"></select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Work Points</label>
                                    <input type="text" class="form-control" runat="server" id="txtworkPoints_ItemMaster" maxlength="255" placeholder="Enter Work Points" clientidmode="Static" />
                                </div>

                            </div>
                        </div>


                    </div>

                    <br id="brid13_ItemMaster" runat="server" clientidmode="Static" style="display: none" />

                    <div class="panel-heading" clientidmode="Static"  runat="server" style="display: none" id="divPackageHeader" data-toggle="collapse" data-parent="#accordion2" href="#divPackage" aria-expanded="false">
                        <h3 class="panel-title">Package</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divPackage" clientidmode="Static"  runat="server" style="display: none">

                        <div class="row">
                            <div class="col-md-8">
                                <label class="control-label">1. Validity</label>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">2. Discount Method</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-8">
                                <div class="col-md-6">
                                    <label class="control-label">From Date</label>
                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="dtFromDatePackage_ItemMaster">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label class="control-label">To Date</label>
                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="dtToDatePackage_ItemMaster">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" style="margin-top: 2%">
                                <label>
                                    <input type="radio" name="option_DiscMethod_ItemMaster" runat="server" id="option_EvenlyAvg_ItemMaster" value="Evenly Average" checked="">Evenly Average</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-8">
                                <div class="col-md-6">
                                    <label class="control-label">From Time</label>
                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="dtFromTimePackage_ItemMaster">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label class="control-label">To Time</label>
                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="dtToTimePackage_ItemMaster">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" style="margin-top: 2%">
                                <label>
                                    <input type="radio" name="option_DiscMethod_ItemMaster" runat="server" id="option_Manual_ItemMaster" value="Manual">Manual</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-8">
                                <div class="col-md-6" style="margin-top: 2%">
                                    <div class="checkbox">
                                        <label style="color: red">
                                            <input type="checkbox" class="form-check-input" runat="server" id="chkApptTDT_ItemMaster" onchange="ApptClick(this)">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Appt TDT
                                        </label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label style="color: red" class="control-label">min. select for Appt.:</label>
                                    <input type="text" class="form-control" runat="server" id="txtminAppt_ItemMaster" maxlength="1" readonly="readonly" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>

                        <br />

                          <div class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label>Package Item Department</label>
                                        <select id="ddlDept_mdlPackageItem" name="select2" runat="server" class="form-control select2" style="width: 100%;" />
                                    </div>
                                    <!-- /.form-group -->
                                </div>

                             <div class="col-md-4 " style="margin-top: 2%">
                                <%--<label class="control-label">3. Search Item</label>--%>
                                <a id="btn_Search_ItemMaster" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Search Item</a>
                            </div>
                
                         </div>

                          <div class="row">
                                <div class="col-md-12">

                                    <table id="tblPackageItemSearchList" style="font-size: 13px;" width="100%"  class="table table-bordered table-striped datatable">
                                        <thead>
                                            <tr>
                                                <th style="width: 0%; visibility:hidden">Stock Code</th>
                                                <th style="width: 45%;">Stock Name </th>
                                                <th style="width: 10%;">Division</th>
                                                <th style="width: 0%; visibility:hidden">Class</th>
                                                <th style="width: 10%;">Dept</th>
                                                <th style="width: 10%;">Brand</th>
                                                <th style="width: 10%;">Range</th>
                                                <th style="width: 5%;">UOM</th>
                                                <th style="width: 5%;">UOM Unit</th>
                                                <th style="width: 5%;">Price</th>
                                                <th style="width: 5%;"></th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>

                                </div>
                            </div>


                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Code</label>
                                    <input type="text" class="form-control" runat="server" id="txtPackageSelected_ItemCode" maxlength="50" disabled="disabled">
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Name</label>
                                    <input type="text" class="form-control" runat="server" id="txtPackageSelected_ItemName" maxlength="255" disabled="disabled">
                                </div>
                            </div>
                        </div>

                         <div class="row">
                              <div class="col-md-3">
                                  <label class="control-label">UOM</label>
                                  <input type="text" class="form-control" runat="server" id="txt_PackageItemUOM" maxlength="50" disabled="disabled">
                              </div>

                             <div class="col-md-2">
                                 <label class="control-label">Price</label>
                                 <input type="number" class="form-control" runat="server" id="txt_PackageItemPrice" oninput="this.value = !!this.value && Math.abs(this.value) >= 0 ? Math.abs(this.value) : null"  placeholder="Enter Price">
                             </div>

                             <div class="col-md-2">
                                 <label class="control-label">Qty</label>
                                 <input type="number" class="form-control" runat="server" id="txt_PackageItemQty" oninput="this.value = !!this.value && Math.abs(this.value) >= 0 ? Math.abs(this.value) : null"  placeholder="Enter Qty">
                                 <input type="text" runat="server" id="txt_PackageItemDivision" style="visibility:hidden" maxlength="255" disabled="disabled">
                                 <input type="text" runat="server" id="txt_PackageItemId" style="visibility:hidden" maxlength="255" disabled="disabled">
                                 <input type="number" runat="server" id="txt_PackageItemRowIndex" style="visibility:hidden" maxlength="10" disabled="disabled">
                                 <input type="text" runat="server" id="txt_PackageItemOperation" value="Insert" style="visibility:hidden" maxlength="10" disabled="disabled">
                             </div>

                               <div class="col-md-2">
                                 <label class="control-label">Discount</label>
                                 <input type="number" class="form-control" runat="server" id="txt_PackageItemDiscount" oninput="this.value = !!this.value && Math.abs(this.value) >= 0 ? Math.abs(this.value) : null"  placeholder="Enter Discount">
                             </div>

                             <div class="col-md-2" style="margin-top: 2%">
                                 <div class="form-group">
                                      <button id="btn_AddPackageItemSelected" type="button" runat="server" class="btn btn-primary2">Insert/Update</button>
                                  </div>
                             </div>
                             <div class="col-md-1" style="margin-top: 2%">
                                 <div class="form-group">
                                      <button id="btn_DeletePackageItemSelected" type="button" runat="server" class="btn btn-primary2">Remove</button>
                                  </div>
                             </div>

                         </div>

                        <table id="PackageItemSearch" style="font-size: 13px;display:none" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 10%;">Item Code</th>
                                    <th style="width: 20%;">Item Description</th>
                                    <th style="width: 10%;">UOM</th>
                                    <th style="width: 10%;">Brand</th>
                                    <th style="width: 10%;">Link Code</th>
                                    <th style="width: 10%;">Range</th>
                                    <th style="width: 10%;">On Hand Qty</th>
                                    <th>UOM Code</th>
                                    <th>Brand Code</th>
                                    <th>Range Code</th>
                                    <th style="width: 10%;">Qty</th>
                                    <th style="width: 10%;">Cost</th>
                                    <th style="width: 5%;"></th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <label class="control-label">4. Package Content</label>
                            </div>
                        </div>

                        <table id="PackageEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 8%;">Item Code</th>
                                    <th style="width: 20%;">Description</th>
                                    <th style="width: 7%;">Qty</th>
                                    <th style="width: 7%;">U.Price</th>
                                    <th style="width: 10%;">Total</th>
                                    <th style="width: 10%;">Unit.Disc</th>
                                    <th style="width: 7%;">P.Price</th>
                                    <th style="width: 9%;">Total Amount</th>
                                    <th style="width: 7%;">UOM</th>
                                    <th style="width: 5%;">Active</th>
                                    <th style="width: 0%; display:none">Division</th>
                                    <th style="width: 0%; display:none">Package Id</th>
                                    <th style="width: 0%; display:none">Row Index</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <div class="row">
                            <div class="col-md-2" style="margin-top:1%">
                                <label>Content Total</label>
                            </div>
                            <div class="col-md-2">
                                <input type="number" maxlength="50" runat="server" disabled="disabled" class="form-control" id="txtcontentTot_ItemMaster">
                            </div>
                            <div class="col-md-1" style="margin-top:1%" id="packageDiscLabel">
                                <label class="control-label" id="lblPackageDisc" runat="server">Disc Amount</label>
                            </div>
                            <div class="col-md-2" id="packageDisc">
                                <input type="number" maxlength="50" runat="server" class="form-control" id="txtDiscAmnt_ItemMaster" oninput="this.value = !!this.value && Math.abs(this.value) >= 0 ? Math.abs(this.value) : null" >
                            </div>
                            <div class="col-md-2" id="PackageDiscountButton">
                                 <div class="form-group" >
                                      <button id="btn_PackageItemDiscount" type="button" runat="server" class="btn btn-primary2">Apply Discount</button>
                                  </div>
                            </div>
                            <div class="col-md-1" style="margin-top:1%">
                                <label>Total Price</label>
                            </div>
                            <div class="col-md-2">
                                <input type="number" maxlength="50" runat="server" class="form-control" id="txtPackageTot_ItemMaster">
                            </div>
                           
                        </div>


                    </div>

                    <br id="brid10_ItemMaster" runat="server" clientidmode="Static" style="display: none" />

                    <div class="panel-heading" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divUOM" id="divUOMHeader">
                        <h3 class="panel-title">UOM</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divUOM">

                        <table id="UOMModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 10%;">No</th>
                                    <th style="width: 15%;">UOMC Code</th>
                                    <th style="width: 15%;">UOMC Description</th>
                                    <th style="width: 10%;">=</th>
                                    <th style="width: 15%;">UOM Unit</th>
                                    <th style="width: 15%;">UOM Code</th>
                                    <th style="width: 15%;">UOM Description</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                        <a id="btn_AddRow_UOM" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>

                        <br />
                        <table id="UOMEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 10%;">No</th>
                                    <th style="width: 25%;">UOMC Desc</th>
                                    <th style="width: 15%;">Price</th>
                                    <th style="width: 15%;">Cost</th>
                                    <th style="width: 15%;">Min Margin %</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>


                    </div>

                    <br id="brid2_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" id="divStkBalanceHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divStkBalance">
                        <h3 class="panel-title">Stk.Balance</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divStkBalance">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Site Code</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_siteCode">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-3" style="margin-top: 2%">
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" runat="server" id="chk_ReorderLevelItemMaster" onchange="ReorderClick(this)">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Re-Order Level
                                        </label>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-3" style="margin-top: 2%; display: none" id="Reorderlevel_ItemMaster">

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Min Qty</label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <input type="number" class="form-control" runat="server" id="txt_minQtyItemMaster" value="0">
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label class="control-label">UOM Code</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_Uom">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-1" style="margin-top: 2%">
                                <div class="form-group">
                                    <button id="btn_Refresh" type="button" runat="server" class="btn btn-primary2">Refresh</button>
                                </div>
                            </div>
                            <div class="col-md-6" style="margin-top: 2%">
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" runat="server" id="chk_ReplenishmentItemMaster" onchange="ReplenishmentClick(this)">
                                            &nbsp&nbsp&nbsp&nbsp&nbsp Customer Replenishment
                                        </label>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <table id="STkBalance" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 25%;">NO</th>
                                        <th style="width: 75%;">Qty</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-md-6" style="margin-top: 2%; display: none" id="Replenishment_ItemMaster">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Replenishment</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <input type="number" class="form-control" runat="server" id="txt_ReplenishmentItemMaster" value="0">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Days</label>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6" style="margin-top: 2%; display: none" id="Replenishment_ItemMaster1">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Remind advance</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <input type="number" class="form-control" runat="server" id="txt_RemindAdvItemMaster" value="0">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Days</label>
                                </div>
                            </div>

                        </div>


                    </div>

                    <br id="brid3_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" id="divLinkCodeHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divLinkCode">
                        <h3 class="panel-title">Link Code</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divLinkCode">
                        <table id="LinkModule" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th>Link Code</th>
                                    <th>Link Description</th>
                                    <th>Rpt Code</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                        <a id="btn_AddRow_LINK" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                    </div>

                    <br id="brid4_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" id="divStockListingHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divStockListing">
                        <h3 class="panel-title">Stock Listing</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divStockListing">
                        <table id="stockListingMaster" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th>Store Code</th>
                                    <th>Store Description</th>
                                    <th style="text-align: center">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-10" style="color: red;text-align:center">All</div>
                                            <div class="col-lg-12 col-md-2" style="color: red">
                                                <input type="checkbox" checked="checked" id="selectall" /></div>

                                        </div>

                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                    </div>

                    <br id="brid5_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" id="divItemUsageHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divItemUsage">
                        <h3 class="panel-title">Item Usage</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divItemUsage">
                        <div class="row">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chk_showSalon" checked="checked">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Show Salon
                                    </label>

                                    <label>
                                        <input type="checkbox" id="chk_showRetail">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Show Retail
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="table-wrapper">
                            <table id="ItemUsageMaster" style="font-size: 13px; width: 100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Description </th>
                                        <th>Item Code</th>
                                        <th>BarCode</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                            <br />

                            <table id="ItemUsageMasterModule" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                <thead>
                                    <tr>
                                        <th>Item Code</th>
                                        <th>Item Description</th>
                                        <th>Quantity</th>
                                        <th>UOM</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>


                        </div>

                    </div>

                    <br id="brid6_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" id="divVoucherHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divVoucher">
                        <h3 class="panel-title">Voucher</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divVoucher">

                        <div class="row">
                            <div class="col-md-3">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" class="form-check-input" runat="server" id="chk_VoucherValidItemMaster" onchange="VocherClick(this)">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Voucher Valid Until DATE:
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group date" id="VoucherDate_ItemMaster" style="display: none">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <input type="text" runat="server" class="form-control pull-right" id="dt_VoucherValItemMaster">
                                </div>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>
                                    Validity Period
                                </label>
                            </div>
                            <div class="col-md-3">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_ValidityPeriodItemMaster">
                                    <%--<option value="">Select</option>
                                    <option value="45">45 days</option>
                                    <option value="180">180 days</option>
                                    <option value="365">365 days</option>
                                    <option value="730">730 days</option>
                                    <option value="1095">1095 days</option>--%>
                                </select>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-3">
                                <label>
                                    Value
                                </label>
                            </div>
                            <div class="col-md-3">
                                <input type="number" maxlength="50" runat="server" class="form-control" id="txtVouValueItemMaster" placeholder="Enter The Value.">
                            </div>
                            <div class="col-md-3">
                                <label>
                                    <input type="radio" name="option_Value_ItemMaster" runat="server" id="option_Amount_ItemMaster" value="Amount" checked="">
                                    Amount
                                </label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp
                                            <label>
                                                <input type="radio" name="option_Value_ItemMaster" runat="server" id="option_Percent_ItemMaster" value="Percent">
                                                Percent
                                            </label>

                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>

                    </div>

                    <br id="brid7_ItemMaster" runat="server" clientidmode="Static"/>

                    <div class="panel-heading" id="divPrepaidHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divPrepaid">
                        <h3 class="panel-title">Prepaid</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divPrepaid">

                        <div class="row">
                            <div class="col-md-2">
                                <label>
                                    Valid Period
                                </label>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_ValidPeriodItemMaster">
                                    <%--<option value="">Select</option>
                                    <option value="45">45 days</option>
                                    <option value="180">180 days</option>
                                    <option value="365">365 days</option>
                                    <option value="730">730 days</option>
                                    <option value="1095">1095 days</option>--%>
                                </select>
                            </div>
                            <div class="col-md-6">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" class="form-check-input" id="chk_MemberCardItemMaster" runat="server">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Member Card No. Accessible
                                    </label>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-2">
                                <label>
                                    Inclusive Type
                                </label>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_InclusiveType">
                                    <option value="">Select</option>
                                    <option value="Product Only">Product Only</option>
                                    <option value="Service Only">Service Only</option>
                                    <option value="All">All</option>
                                </select>
                            </div>
                            <div class="col-md-1">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chk_InclusiveAll">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp All
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_InclusiveDept">
                                </select>
                            </div>
                            <div class="col-md-2">
                                <input type="number" maxlength="255" id="txtInclusive_amnt" class="form-control" runat="server" placeholder="Price">
                            </div>
                            <div class="col-md-2">
                                <div class="radio">
                                    <label>
                                        <input type="radio" name="option_InclAmnt" id="option_ItemMaster_InclAmnt" value="Amount" checked="">
                                        Amount $
                                    </label>
                                </div>

                            </div>
                            <div class="col-md-1">
                                <button type="button" class="btn btn-default" id="btnSubmit_AddInclusive">Add</button>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <label>
                                    Exclusive
                                </label>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_ExclusiveType">
                                    <option value="">Select</option>
                                    <option value="Product Only">Product Only</option>
                                    <option value="Service Only">Service Only</option>
                                </select>
                            </div>
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-2">
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_ExclusiveDept">
                                </select>
                            </div>
                            <div class="col-md-2">
                                <button type="button" class="btn btn-default" id="btnSubmit_AddExclusive">Add</button>
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-1">
                            </div>
                        </div>
                        <br />

                        <table id="PrepaidCondModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 15%; text-align: center">Type</th>
                                    <th style="width: 25%; text-align: center">Condition Type 1</th>
                                    <th style="width: 25%; text-align: center">Condition Type 2</th>
                                    <th style="width: 15%; text-align: center">Amount</th>
                                    <th style="width: 15%; text-align: center">Rate</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <div class="row">
                            <div class="col-md-2">
                                <label>
                                    Prepaid Value
                                </label>
                            </div>
                            <div class="col-md-2">
                                <input type="number" maxlength="50" runat="server" disabled="disabled" class="form-control" id="txt_PrepaidValue" placeholder="Enter The Amount.">
                            </div>
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-2">
                                <label>
                                    Prepaid Amount
                                </label>
                            </div>
                            <div class="col-md-2">
                                <input type="number" maxlength="50" runat="server" class="form-control" id="txt_PrepaidAmnt" placeholder="Enter The Amount.">
                            </div>
                        </div>


                    </div>

                    <br id="brid12_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" runat="server" clientidmode="Static" style="display: none" id="divServiceHeader" data-toggle="collapse" data-parent="#accordion2" href="#divService" aria-expanded="false">
                        <h3 class="panel-title">Service Option</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divService" runat="server" clientidmode="Static">

                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="checkbox icheck">
                                    <label>
                                        <input type="checkbox" runat="server" onchange="ExpiryStatusClick(this)" id="chkExpiryStatus_ItemMaster">&nbsp&nbsp&nbsp&nbsp&nbsp
                                   Expiry Status</label>
                                </div>
                            </div>
                            <div class="col-md-4" id="serviceExpiryMonth" style="display: none">
                                <input type="number" class="form-control" runat="server" id="txtserviceExpiryMonth_ItemMaster">
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Month(s)</label>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="checkbox icheck">
                                    <label>
                                        <input type="checkbox" runat="server" onchange="ServiceLimitClick(this)" id="chkServiceLimit_ItemMaster">&nbsp&nbsp&nbsp&nbsp&nbsp 
                                   Service Limit</label>
                                </div>
                            </div>
                            <div class="col-md-4" id="ServiceLimit" style="display: none">
                                <input type="number" class="form-control" runat="server" id="txtServiceLimit_ItemMaster">
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Xs</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="checkbox icheck">
                                    <label>
                                        <input type="checkbox" onchange="ServiceFlexiClick(this)" runat="server" id="chkServiceFlexi_ItemMaster">
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Limited Service-Flexi Only</label>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="row" id="serviceOption1" style="display: none">
                            <div class="col-md-12">
                                <label class="control-label">3.Service Search </label>
                            </div>
                        </div>

                        <table id="ServiceSearch" style="font-size: 13px; display: none" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 10%;">Item Code</th>
                                    <th style="width: 20%;">Item Description</th>
                                    <th style="width: 10%;">UOM</th>
                                    <th style="width: 10%;">Brand</th>
                                    <th style="width: 10%;">Link Code</th>
                                    <th style="width: 10%;">Range</th>
                                    <th style="width: 10%;">On Hand Qty</th>
                                    <th>UOM Code</th>
                                    <th>Brand Code</th>
                                    <th>Range Code</th>
                                    <th style="width: 10%;">Qty</th>
                                    <th style="width: 10%;">Cost</th>
                                    <th style="width: 5%;"></th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <br />
                        <div class="row" id="serviceOption2">
                            <div class="col-md-12">
                                <label class="control-label">4.Service Available</label>
                            </div>
                        </div>

                        <table id="ServiceAvailabe" runat="server" style="width: 100%" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th style="width: 10%;">No</th>
                                    <th style="width: 20%;">Service Name</th>
                                    <th style="width: 10%;">Service Code</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>


                    </div>

                    <br id="brid8_ItemMaster" runat="server" clientidmode="Static" style="display: none" />

                    <div class="panel-heading" id="divAccCodeHeader" data-toggle="collapse" data-parent="#accordion2" href="#divAccCode" aria-expanded="false">
                        <h3 class="panel-title">Account Code</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divAccCode">

                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label">Account Code</label>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <%--<input type="number" class="form-control" runat="server" id="txt_AccCodeItemMaster" placeholder="Enter Account Code">--%>
                                    <input type="text" class="form-control" runat="server" id="txt_AccCodeItemMaster" placeholder="Enter Account Code">
                                </div>
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>

                    </div>

                    <br id="brid9_ItemMaster" runat="server" clientidmode="Static" />

                    <div class="panel-heading" runat="server" clientidmode="Static"  style="display: none" id="divTaxHeader" data-toggle="collapse" data-parent="#accordion2" href="#divTax" aria-expanded="false">
                        <h3 class="panel-title">Tax Code</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" runat="server" clientidmode="Static"  id="divTax" style="display: none">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">1st Tax Code</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl1stTax_ItemMaster"></select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">2nd Tax Code</label>
                                    <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl2ndTax_ItemMaster"></select>
                                </div>

                            </div>
                        </div>

                    </div>


                    <br id="brid11_ItemMaster" runat="server" clientidmode="Static"  style="display: none" />

                </div>

                <div class="box-footer">
                    <button id="btnSubmit_AddItemMaster" type="button" runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
                </div>

            </div>

        </div>
        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>

