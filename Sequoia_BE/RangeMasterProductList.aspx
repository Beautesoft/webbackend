<%@ Page Title="Stock Item List" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RangeMasterProductList.aspx.cs" Inherits="Sequoia_BE.RangeMasterProductList" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Product Range
       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="RangeMasterProductList.aspx">Product Range </a></li>
        </ol>
    </section>
    

    <section class="content">
        <div class="box">
            <div class="box-body">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_RangeMasterProductList" data-toggle="buttons">
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

                    <table id="RangeProductListMaster" style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                        <thead>
                            <tr>
                                <th> Code</th>
                                <th> Description </th>
                                <th> Brand </th>
                                <th> Active </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="fabIcon"><a style="color: white" href="RangeMasterProduct.aspx">+ </a></div>
                <!-- /.box-body -->
            </div>
        <!-- /.box -->

    </section>
</asp:Content>
