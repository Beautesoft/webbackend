<%@ Page Title="Brand List" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BrandMasterList.aspx.cs" Inherits="Sequoia_BE.BrandMasterList" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <script type="text/javascript" src="Script/BEJavascript.js"></script>

    <section class="content-header">
        <h1>Brand List
       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="BrandMasterList.aspx">Brand </a></li>
        </ol>
    </section>
    

    <section class="content">
        <div class="box">
            <div class="box-body">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_BrandList" data-toggle="buttons">
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
                                        Non Active
                                    </label>                                   
                                </div>
                            </div>
                        </div>
                    </div>

                    <table id="BrandListMaster" style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                        <thead>
                            <tr>
                                <th> Code</th>
                                <th> Description </th>
                                <th> Active </th>
                                <th> Show on retail </th>
                                <th> Show on voucher </th>
                                <th> Show on prepaid </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="fabIcon"><a style="color: white" href="BrandMaster.aspx">+ </a></div>
                <!-- /.box-body -->
            </div>
        <!-- /.box -->

    </section>
</asp:Content>
