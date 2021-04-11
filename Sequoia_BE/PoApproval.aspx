<%@ Page Title="Purchase Approval" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PoApproval.aspx.cs" Inherits="Sequoia_BE.PoApproval" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Purchase Approval
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="POAppList.aspx">Purchase Approval List</a></li>
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
                                <label class="control-label">Req No</label>
                                 <input type="text" class="form-control" runat="server" id="txtDocNo_POApp" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">PO No</label>
                                 <input type="text" class="form-control" runat="server" id="txtPoNo_POApp" maxlength="255" readonly="readonly">
                            </div>
                     </div>  
                                            <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DocDatePOApp"  >
                            </div>
                            </div>
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                                <label class="control-label">Status</label>
                                <input type="text" class="form-control" runat="server" id="txtStatus_POApp" maxlength="255" placeholder="Status" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                            <div class="form-group required">
                                <label class="control-label">Supplier</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_supplierPOApp"></select>
                            </div>
                     </div>  
                       <div class="col-md-4">
                            <div class="form-group required">
                                <label class="control-label">Total Quantity</label>
                                 <input type="text" runat="server" class="form-control"  id="txtTotQty_POApp" maxlength="255" readonly="readonly">
                            </div>
                           </div>

                  </div>

                    <div class="row">
                        <div class="col-md-4">
                                                <div class="form-group required">
                                <label class="control-label">Store Code</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlStoreCode_POApp"></select>
                            </div>
                             
                     </div> 
                    <div class="col-md-8">
                             <div class="form-group required">
                                <label class="control-label">Remark</label>
                                 <input type="text" runat="server" class="form-control" id="txtRemark_POApp" maxlength="255" >
                            </div>
                     </div>  
                  </div>
                   </div>

                <br />

                        <div>
                            
                            <div style="display:none">
                            <table id="POAppItemSearch"  style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                    <thead>
                        <tr>
                            <th style="width: 10%;">Item Code</th>
                            <th style="width: 20%;">Item Description</th>
                            <th style="width: 5%;">UOM</th>
                            <th style="width: 10%;">Brand</th>
                            <th style="width: 5%;">Price</th>
                            <th style="width: 8%;">Stock Qty</th>
                            <th style="width: 8%;">Moq Qty</th>
                            <th style="width: 10%;">Product Code</th>
                            <th style="width: 10%;">Range</th>
                            <th>UOM Code</th>
                            <th>Brand Code</th>
                            <th>Range Code</th>
                            <th style="width: 10%;">Approved Qty</th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                                </div>
                            <br />

                            <table id="POAppEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
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
                                        <th style="width: 10%;">Approved Qty</th>
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
                                <div class="col-md-4">
                                     
                                </div>
                                <div class="col-md-1">
                                    <label>
                                        Total Qty
                                    </label>
                                </div>
                                <div class="col-md-2">
                                   <input type="number" maxlength="50" runat="server" class="form-control" id="txt_TotAmntPOApp" style="text-align:right" readonly="readonly">
                                </div>
                                <div class="col-md-1">
                                    
                                </div>
                            </div>



                        </div>



            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddPOApp" type="button"  runat="server" visible="false" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
                <button id="btnSubmit_PostPOApp" type="button" disabled="disabled"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Save Approval">Save Approval</button>
                <button id="btnSubmit_ListPOApp" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> List">List</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
