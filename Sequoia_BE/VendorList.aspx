<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VendorList.aspx.cs" Inherits="Sequoia_BE.VendorList" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Vendor Master
       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li class="active">VendorList</li>
        </ol>
    </section>
    <section class="content">
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">List of Vendors</h3>
            </div>

            <div class="box-body">
                <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_tblVendorList" data-toggle="buttons">
                                    <label class="btn btn-default active">
                                        <input type="radio" name="status" value="" checked="checked">
                                        All
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="Yes">
                                        Active
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="No">
                                        Inactive
                                    </label>                                   
                                </div>
                            </div>
                        </div>
                    </div>  
                <table id="tblVendorList" class="table table-bordered table-striped datatable">
                    <thead>
                        <tr>
                            <th>Supply Code</th>
                            <th>Supplier Name</th>
                            <th>Supply Date</th>
                            <th>Active</th>
                            <th>Contact No</th>
                            <th>No.of POS</th>
<%--                            <th>Active</th>
                            <th>Contact No.</th>
                            <th>No. of POS</th>--%>
                            <th style="display:none">ID</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="fabIcon"><a style="color: white" href="VendorMaster.aspx">+ </a></div>
            <!-- /.box-body -->
        </div>
        <!-- /.box -->

    </section>
</asp:Content>

