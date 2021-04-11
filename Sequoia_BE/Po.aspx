<%@ Page Title="Purchase Request" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Po.aspx.cs" Inherits="Sequoia_BE.Po" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Purchase Order
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <%--<li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>--%>
            <li><a href="POList.aspx">Purchase Order List</a></li>
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
                                <label class="control-label">PO No</label>
                                 <input type="text" class="form-control" runat="server" id="txtDocNo_Po" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DocDatePo"  >
                            </div>
                            </div>
                     </div>  
                                            <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Status</label>
                                <input type="text" class="form-control" runat="server" id="txtStatus_Po" maxlength="255" placeholder="Status" readonly="readonly">
                            </div>
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                                <label class="control-label">Supplier</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_supplierPo"></select>
                            </div>
                     </div>
                        <div class="col-md-4">
                            <div class="form-group required">
                                <label class="control-label">Total Quantity</label>
                                 <input type="text" runat="server" class="form-control"  id="txtTotQty_Po" maxlength="255" readonly="readonly">
                            </div>
                     </div>  
                                            <div class="col-md-4">
                                                <div class="form-group required">
                                <label class="control-label">Store Code</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlStoreCode_Po"></select>
                            </div>
                             
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-12">
                             <div class="form-group required">
                                <label class="control-label">Remark</label>
                                 <input type="text" runat="server" class="form-control" id="txtRemark_Po" maxlength="255" >
                            </div>
                     </div>  
                  </div>
                   </div>

                <br />

                        <div>
                            
                            <table id="PoItemSearch"  style="font-size: 13px;"  class="table table-bordered table-striped datatable">
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
                            <th style="width: 10%;">Required Qty</th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>

                            <br />
                            <table id="PoEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 0%; visibility:hidden">poId</th>
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
                                   <input type="number" maxlength="50" runat="server" class="form-control" id="txt_TotAmntPo" style="text-align:left" readonly="readonly">
                                </div>
                                <div class="col-md-2">
                                    
                                </div>
                            </div>



                        </div>



            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddPo" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
                <button id="btnSubmit_PostPo" type="button" disabled="disabled"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Post">Post</button>
                <button id="btnSubmit_ListPo" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> List">List</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
