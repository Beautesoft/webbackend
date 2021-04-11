<%@ Page Title="Invoice & Do with Outlet PO" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="InvDoWithOutletPO.aspx.cs" Inherits="Sequoia_BE.InvDoWithOutletPO" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Invoice & Do with Outlet PO
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <%--<li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>--%>
            <li><a href="POAppList.aspx">Invoice & Do with Outlet PO List</a></li>
            <li class="active">Add</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body">
                <div>
                    <div class="row">
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Invoice No</label>
                                 <input type="text" class="form-control" runat="server" id="txtInvNo_InvDoWithOutletPO" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                    <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">PO No</label>
                                 <input type="text" class="form-control" runat="server" id="txtDocNo_InvDoWithOutletPO" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DocDateInvDoWithOutletPO"  >
                            </div>
                            </div>
                     </div>  
                             

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                                <label class="control-label">Supplier</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_supplierInvDoWithOutletPO"></select>
                            </div>
                     </div>
                        <div class="col-md-4">
                            <div class="form-group required">
                                <label class="control-label">Total Quantity</label>
                                 <input type="text" runat="server" class="form-control"  id="txtTotQty_InvDoWithOutletPO" maxlength="255" readonly="readonly">
                            </div>
                     </div>  
                                            <div class="col-md-4">
                                                <div class="form-group required">
                                <label class="control-label">Store Code</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlStoreCode_InvDoWithOutletPO"></select>
                            </div>
                             
                     </div>  

                  </div>

                    <div class="row">
                                       <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Status</label>
                                <input type="text" class="form-control" runat="server" id="txtStatus_InvDoWithOutletPO" maxlength="255" placeholder="Status" readonly="readonly">
                            </div>
                     </div>  
                    <div class="col-md-8">
                             <div class="form-group required">
                                <label class="control-label">Remark</label>
                                 <input type="text" runat="server" class="form-control" id="txtRemark_InvDoWithOutletPO" maxlength="255" >
                            </div>
                     </div>  
                  </div>
                   </div>

                <br />
                 <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tabInvDoWithOutletPO1" data-toggle="tab">Detail</a></li>
                        <li><a href="#tabInvDoWithOutletPO2" data-toggle="tab">Delivery Address</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tabInvDoWithOutletPO1">
                            
                            <br />
                            
                            <table id="InvDoWithOutletPOEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 0%; visibility:hidden">reqId</th>
                                        <%--<th style="width: 0%; visibility:hidden">docUom</th>--%>
                                        <th style="width: 10%;">S No</th>
                                        <th style="width: 10%;">Item Code</th>
                                        <th style="width: 20%;">Description</th>
                                        <th style="width: 10%;">Brand </th>
                                        <th style="width: 10%;">Price</th>
                                        <th style="width: 10%;">Stock Qty</th>
                                        <th style="width: 10%;">MOQ Qty</th>
                                        <th style="width: 10%;">Required Qty</th>
                                        <%--<th style="width: 10%;">Product Code</th>--%>
                                        <th style="width: 5%; text-align: center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>

                            <div class="row">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                     
                                </div>
                                <div class="col-md-2">
                                    <label>
                                        Total Qty
                                    </label>
                                </div>
                                <div class="col-md-2">
                                   <input type="number" maxlength="50" runat="server" class="form-control" id="txt_TotAmntInvDoWithOutletPO" style="text-align:left" readonly="readonly">
                                </div>
                                <div class="col-md-2">
                                    
                                </div>
                            </div>



                          </div>
                        <div class="tab-pane" id="tabInvDoWithOutletPO2">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Attn To:</label>
                                <input type="text" id="txtAttnTo_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                </div>
                             </div>
                           
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Billing Address</label>
                                <input type="text" id="txtAddress1_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Ship To Address</label>
                                <input type="text" id="txtShipToAddress1_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <input type="text" id="txtAddress2_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <input type="text" id="txtShipToAddress2_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <input type="text" id="txtAddress3_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <input type="text" id="txtShipToAddress3_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Post Code</label>
                                <input type="text" id="txtPostCode_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Post Code</label>
                                <input type="text" id="txtPostCodeTo_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtCity_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtCityTo_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">State</label>
                                <input type="text" id="txtState_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtStateTo_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Country</label>
                                <input type="text" id="txtCountry_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Country</label>
                                <input type="text" id="txtCountryTo_InvDoWithOutletPO" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Remark1</label>
                                <input type="text" id="txtRemark1_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Remark2</label>
                                <input type="text" id="txtRemark2_InvDoWithOutletPO" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                </div>
                             </div>

                        </div>
                    </div>
                    <!-- /.tab-content -->
                </div>



            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddInvDoWithOutletPO" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
                <button id="btnSubmit_PostInvDoWithOutletPO" type="button" disabled="disabled"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Post">Post</button>
                <button id="btnSubmit_ListInvDoWithOutletPO" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> List">List</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
