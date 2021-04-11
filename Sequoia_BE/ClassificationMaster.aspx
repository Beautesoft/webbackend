<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ClassificationMaster.aspx.cs" Inherits="Sequoia_BE.ClassificationMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Classification List       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="ClassificationMaster.aspx">Classification List</a></li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-body">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row" style="margin-bottom:10px">                            
                            <div class="col-lg-12">
                                <div class="btnFillter_ClassListMaster" data-toggle="buttons">
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
                <table id="ClassificationMasterPage"  style="font-size: 13px;"  class="table table-bordered table-striped datatable">
                    <thead>
                        <tr>
                            <th style="width: 30%">Classification Code</th>
                            <th style="width: 30%">Description</th>
                            <th style="width: 30%">Classification is currently active</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                </div>
                <div class="fabIcon"><a style="color: white" href="ClassMaster.aspx">+ </a></div>
                <!-- /.box-body -->
            </div>
        <!-- /.box -->

    </section>
</asp:Content>
