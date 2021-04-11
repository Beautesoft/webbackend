<%@ Page Title="Goods Transfer Out" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GRNOut.aspx.cs" Inherits="Sequoia_BE.GRNOut" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Goods Transfer Out
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <%--<li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>--%>
            <li><a href="GRNOutList.aspx">Goods Transfer Out List</a></li>
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
                                <label class="control-label">Doc NO</label>
                                 <input type="text" class="form-control" runat="server" id="txtDocNo_GRNOut" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Doc Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DocDateGRNOut"  >
                            </div>
                            </div>
                     </div>  
                                            <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Status</label>
                                <input type="text" class="form-control" runat="server" id="txtStatus_GRNOut" maxlength="255" placeholder="Status" readonly="readonly">
                            </div>
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                                <label class="control-label">GR Ref1</label>
                                 <input type="text" runat="server" class="form-control" id="txtPO1Ref_GRNOut" maxlength="255" >
                            </div>
                     </div>
                        <div class="col-md-4">
                            <div class="form-group required">
                                <label class="control-label">GR Ref2</label>
                                 <input type="text" runat="server" class="form-control"  id="txtGrn1Ref_GRNOut" maxlength="255" >
                            </div>
                     </div>  
                                            <div class="col-md-4">
                                                <div class="form-group required">
                                <label class="control-label">Store Code</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlStoreCode_GRNOut"></select>
                            </div>
                             
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">From Store</label>
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_FromStoreGRNOut"></select>
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">To Store</label>
                                <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_ToStoreGRNOut"></select>
                            </div>
                     </div>  
                                            <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Created By</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlCreatedBy_GRNOut"></select>
                            </div>
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-12">
                             <div class="form-group required">
                                <label class="control-label">Remark</label>
                                 <input type="text" runat="server" class="form-control" id="txtRemark_GRNOut" maxlength="255" >
                            </div>
                     </div>  
                                          

                  </div>

                   </div>

                <br />

                        <div>
                            
                            <table id="GRNOutItemSearch"  style="font-size: 13px;"  class="table table-bordered table-striped datatable">
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

                            <table id="GRNOutEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 0%; visibility:hidden">docId</th>
                                        <th style="width: 0%; visibility:hidden">docUom</th>
                                        <th style="width: 5%;">No</th>
                                        <th style="width: 10%;">Item Code</th>
                                        <th style="width: 20%;">Description</th>
                                        <th style="width: 10%;">Brand </th>
                                        <th style="width: 10%;">Range</th>
                                        <th style="width: 10%;">U.Cost</th>
                                        <th style="width: 10%;">UOM</th>
                                        <th style="width: 10%;">Qty</th>
                                        <th style="width: 10%;">Amount</th>
                                        <th style="width: 10%;">Remark</th>
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
                                        Total Cost
                                    </label>
                                </div>
                                <div class="col-md-2">
                                   <input type="number" maxlength="50" runat="server" class="form-control" id="txt_TotAmntGRNOut" style="text-align:left" readonly="readonly">
                                </div>
                                <div class="col-md-2">
                                    
                                </div>
                            </div>



                        </div>



            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddGRNOut" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Ok">Ok</button>
                <button id="btnSubmit_PostGRNOut" type="button" disabled="disabled"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Post">Post</button>
                <button id="btnSubmit_ListGRNOut" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> List">List</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
