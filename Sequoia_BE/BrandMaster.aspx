<%@ Page Title="Brand" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BrandMaster.aspx.cs" Inherits="Sequoia_BE.BrandMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Brand
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="BrandMasterList.aspx">Brand List</a></li>
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
                    <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Code</label>
                                 <input type="text" class="form-control" runat="server" id="txtCode_Brand" maxlength="255" disabled="disabled">
                            </div>
                     </div>
                        <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Description</label>
                                <input type="text" class="form-control" runat="server" id="txtName_Brand" maxlength="255" placeholder="Enter Description">
                            </div>
                     </div>                         

                  </div>

                    <div class="row">

                        <div class="col-md-3">
                         <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chk_ActiveBrandMaster" checked="checked">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Brand is Currently Active
                                </label>
                                </div>
                             </div>
                        </div>

                        <div class="col-md-3">
                         <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chk_showRetailBrandMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Show on retail
                                </label>
                                </div>
                             </div>
                        </div>

                        <div class="col-md-3">
                         <div class="form-group">
                            <div class="checkbox">
                                <label >
                                    <input type="checkbox" runat="server" id="chk_showVoucherBrandMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Show on voucher
                                </label>
                                
                                </div>
                             </div>
                        </div>

                        <div class="col-md-3">
                         <div class="form-group">
                            <div class="checkbox">
                                
                                <label>
                                    <input type="checkbox" runat="server" id="chk_showPrepaidBrandMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Show on prepaid
                                </label>
                                </div>
                             </div>
                        </div>

                    </div>


                                        </div>

                <br />

            </div>
            <div class="box-footer">
                <%--<button id="btnSubmit_AddBrandMaster" type="button"  runat="server" class="btn btn-primary" 
                    data-loading-text="<i class='fa fa-spinner fa-spin '></i> Processing Order>
                    Add
                    <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                    <span class="sr-only">Loading...</span>
                </button>--%>
                <%--<button type="button" class="btn btn-primary" id="btnSubmit_AddBrandMaster" runat="server"
                    data-loading-text="<i class='fa fa-spinner fa-spin '></i> Processing">Add</button>--%>

                <button type="button" class="btn btn-primary" runat="server" id="btnSubmit_AddBrandMaster" 
                    data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>

            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
