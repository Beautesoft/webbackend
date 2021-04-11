<%@ Page Title="Goods Receieve Note List" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GRNList.aspx.cs" Inherits="Sequoia_BE.GRNList" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Goods Receieve Note List      
            <small></small>
        </h1>
        <%--<ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="GRNList.aspx">Goods Receieve Note List</a></li>
        </ol>--%>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
           
            <div class="box-body">
            <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_GRNListMaster" data-toggle="buttons">
                                    <label class="btn btn-default active">
                                        <input type="radio" name="status" value="" checked="checked">
                                        All
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="Open">
                                        Open
                                    </label>
                                    <label class="btn btn-default">
                                        <input type="radio" name="status" value="Posted">
                                        Posted
                                    </label>                                   
                                </div>
                            </div>
                        </div>
                    </div>                            
                <table id="GRNMasterPage"  style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                    <thead>
                        <tr>
                            <th style="width: 20%">Invoice Number</th>
                            <th style="width: 10%">Invoice Date</th>
                            <th style="width: 10%">Ref Num</th>
                            <th style="width: 30%">Supplier</th>
                            <th style="width: 10%">Total Amount</th>
                            <th style="width: 20%">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                </div>
                <div class="fabIcon"><a style="color: white" href="GRN.aspx">+ </a></div>
                <!-- /.box-body -->
            </div>
        <!-- /.box -->

    </section>
</asp:Content>
