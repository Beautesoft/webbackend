<%@ Page Title="Delivery Order Approval" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DOrderApproval.aspx.cs" Inherits="Sequoia_BE.DOrderApproval" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Delivery Order Approval
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <%--<li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>--%>
            <li><a href="DOWithGRNList.aspx">Delivery Order Approval List</a></li>
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
                                <label class="control-label">GRN No</label>
                                 <input type="text" class="form-control" runat="server" id="txtGRNNo_DOrderApproval" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                    <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">DO No</label>
                                 <input type="text" class="form-control" runat="server" id="txtDocNo_DOrderApproval" maxlength="255" readonly="readonly">
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">PO Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DocDateDOrderApproval"  >
                            </div>
                            </div>
                     </div>  
                             

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                                <label class="control-label">Supplier</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddl_supplierDOrderApproval"></select>
                            </div>
                     </div>
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Delivery Date</label>
                                <div class="input-group date" >
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dt_DeliveryDateDOrderApproval"  >
                            </div>
                            </div>
                     </div>  
                                       <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Status</label>
                                <input type="text" class="form-control" runat="server" id="txtStatus_DOrderApproval" maxlength="255" placeholder="Status" readonly="readonly">
                            </div>
                     </div>  

                                            <div class="col-md-4" style="display:none">
                             <div class="form-group required">
                                <label class="control-label">Term</label>
                                <input type="number" class="form-control" runat="server" id="txtTerm_DOrderApproval" value="0">
                            </div>
                     </div>  

                  </div>

                    <div class="row">
                    <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Ref No</label>
                                 <input type="text" runat="server" class="form-control" id="txtPO1Ref_DOrderApproval" maxlength="255" >
                            </div>
                     </div>
                        <div class="col-md-4" style="display:none">
                             <div class="form-group required">
                                <label class="control-label">GR Ref</label>
                                 <input type="text" runat="server" class="form-control"  id="txtGrn1Ref_DOrderApproval" maxlength="255" >
                            </div>
                     </div>  
                                            <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Store Code</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlStoreCode_DOrderApproval"></select>
                            </div>
                     </div>  
                        <div class="col-md-4">
                             <div class="form-group required">
                                <label class="control-label">Created By</label>
                                 <select class="form-control select2" style="width: 100%;" clientidmode="Static" runat="server" id="ddlCreatedBy_DOrderApproval"></select>
                            </div>
                     </div>

                  </div>

                    <div class="row">
                    
                        <div class="col-md-12">
                             <div class="form-group required">
                                <label class="control-label">Remark</label>
                                 <input type="text" runat="server" class="form-control" id="txtRemark_DOrderApproval" maxlength="255" >
                            </div>
                     </div>  
                                          

                  </div>

                    

                   </div>

                <br />

                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tabDOrderApproval1" data-toggle="tab">Detail</a></li>
                        <li><a href="#tabDOrderApproval2" data-toggle="tab">Delivery Address</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tabDOrderApproval1">
                            
                            <%--<a id="btn_AddRow_GRN" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>--%>

                            <br />

                            <table id="DOrderApprovalEntryModule" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
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
                                   <input type="number" maxlength="50" runat="server" class="form-control" id="txt_TotAmntDOrderApproval" style="text-align:left" readonly="readonly">
                                </div>
                                <div class="col-md-2">
                                    
                                </div>
                            </div>



                        </div>
                        <div class="tab-pane" id="tabDOrderApproval2">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Attn To:</label>
                                <input type="text" id="txtAttnTo_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                </div>
                             </div>
                           
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Address</label>
                                <input type="text" id="txtAddress1_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Ship To Address</label>
                                <input type="text" id="txtShipToAddress1_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <input type="text" id="txtAddress2_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <input type="text" id="txtShipToAddress2_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <input type="text" id="txtAddress3_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <input type="text" id="txtShipToAddress3_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Post Code</label>
                                <input type="text" id="txtPostCode_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Post Code</label>
                                <input type="text" id="txtPostCodeTo_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtCity_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtCityTo_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">State</label>
                                <input type="text" id="txtState_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">City</label>
                                <input type="text" id="txtStateTo_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Country</label>
                                <input type="text" id="txtCountry_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       <div class="form-group required">
                                <label class="control-label">Country</label>
                                <input type="text" id="txtCountryTo_DOrderApproval" class="form-control" runat="server" >
                            </div>
                                </div>
                             </div>
                            <div class="row" style="display:none">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Remark1</label>
                                <input type="text" id="txtRemark1_DOrderApproval" class="form-control" runat="server">
                            </div>
                                </div>
                                   <div class="col-md-6">
                                       
                                </div>
                             </div>
                            <div class="row" style="display:none">
                                <div class="col-md-6">
                                    <div class="form-group required">
                                <label class="control-label">Remark2</label>
                                <input type="text" id="txtRemark2_DOrderApproval" class="form-control" runat="server">
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
                <div style="align-items:flex-end">
                <button id="btnSubmit_AddDOrderApproval" type="button" visible="false"  runat="server" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Ok" class="btn btn-primary">Ok</button>
                <button id="btnSubmit_PostDOrderApproval" type="button" disabled="disabled"  runat="server" data-loading-text="<i class='fa fa-spinner fa-spin '></i> DO Approval" class="btn btn-primary">DO Approval</button>
                <button id="btnSubmit_ListDOrderApproval" type="button"  runat="server" data-loading-text="<i class='fa fa-spinner fa-spin '></i> List" class="btn btn-primary">List</button>
            </div>
                </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
