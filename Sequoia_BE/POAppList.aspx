<%@ Page Title="Invoice With Outlet PO List" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="POAppList.aspx.cs" Inherits="Sequoia_BE.POAppList" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <script type="text/javascript" src="Script/BEJavascript.js"></script>

    <section class="content-header">
        <h1>Invoice With Outlet PO List
       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Invoice With Outlet PO List</a></li>
        </ol>
    </section>
    

    <section class="content">
        <div class="box">
            <div class="box-body">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_PoAppListMaster" data-toggle="buttons">
                                    <label class="btn btn-default active">
                                        <input type="radio" name="status" value="" checked="checked">
                                        All
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="Posted">
                                        Posted
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="Approved">
                                        Approved
                                    </label>                                   
                                </div>
                            </div>
                        </div>
                    </div>  
                    <table id="PoAppListMaster" style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                        <thead>
                            <tr>
                                <th>PO Number</th>
                                <th>Invoice Number</th>
                                <th>Date</th>
                                <th>Supplier</th>
                                <th>Request Quantity</th>
                                <th>Approved Quantity</th>
                                <th>Status</th>
                                <th>Remark</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        <!-- /.box -->

    </section>
</asp:Content>
