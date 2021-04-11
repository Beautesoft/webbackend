<%@ Page Title="Stock Count " Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StockCount.aspx.cs" Inherits="Sequoia_BE.StockCount" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <script type="text/javascript" src="Script/BEJavascript.js"></script>
    <section class="content-header">
        <h1>Stock Count 
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder"></i>Home</a></li>
        </ol>
    </section>
    <section class="content">
        <div class="box box-default">

            <div class="box-body">
                <div>
                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group required">
                            <label class="control-label">Date</label>
                            <div class="input-group date">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" runat="server" class="form-control pull-right" id="dtDate_StockCount">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Div </label>
                            <select class="form-control select2" style="width: 100%;" id="ddlDiv_StockCount" clientidmode="Static" runat="server">
                            </select>
                        </div>
                    </div>
                        <div class="col-md-4">
                                <div class="form-group" style="text-align: center">
                            <button id="btnOperation" type="button" runat="server" onserverclick="Operation_Click" class="btn btn-app btn-primary"><i class="fa fa-play"></i>Proceed</button>
                        </div>
                            </div>
                </div>
                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Item </label>
                            <select class="form-control select2" style="width: 100%;" id="ddlItem_StockCount" clientidmode="Static" runat="server">
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Brand</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlBrand_StockCount" clientidmode="Static" runat="server">
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Range</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlRange_StockCount" clientidmode="Static" runat="server">
                            </select>
                        </div>
                    </div>
                </div>
                    </div>

                <br />
                <div>
                    <table id="tblStockCount" runat="server" style="width: 100%;" clientidmode="Static" cellspacing="0" width="100%" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 5%;">Item Code</th>
                                        <th style="width: 10%;">Item Name</th>
                                        <th style="width: 10%;">Brand </th>
                                        <th style="width: 10%;">Range</th>
                                        <th style="width: 10%;">UOM</th>
                                        <th style="width: 5%;">AESTHETIQ WELLNESS HQ</th><%--AWHQ--%>
                                        <th style="width: 5%;">WEST AVENUE</th><%--AW01--%>
                                        <th style="width: 5%;">MARILAO</th><%--AW02--%>
                                        <th style="width: 5%;">TELABESTAGAN</th><%--AW03--%>
                                        <th style="width: 5%;">URDANETA</th><%--AW04--%>
                                        <th style="width: 5%;">VISAYAS</th><%--AW05--%>
                                        <th style="width: 5%;">Silayan</th><%--AW06--%>
                                        <th style="width: 5%;">SM Tarlac</th><%--AW07--%>
                                        <th style="width: 5%;">CABANATUAN</th><%--AW08--%>
                                        <th style="width: 5%;">BALIWAG</th><%--AW09--%>
                                        <th style="width: 5%;">MALOLOS</th><%--AW10--%>
                                        <th style="width: 5%;">CALASIAO</th><%--AW11--%>
                                        <th style="width: 5%;">Balance</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                </div>
                </div>
        
            </div>
    </section>
</asp:Content>
