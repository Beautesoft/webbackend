<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_ApptSecondaryStatus.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_ApptSecondaryStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Secondary Status
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Appointment Config</a></li>
            <li><a href="#">Secondary Status</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

            <ContentTemplate>

                <div class="box">

                    <div class="box-body">

                        <div class="box-header with-border">
                            <h3 class="box-title">List of Secondary Status</h3>
                        </div>
                        <table id="tblApptSecondaryStatus" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                   <th style="width: 20%">Code</th>
                                    <th style="width: 35%">Description</th>
                                    <th style="width: 25%">Color Code</th>
                                    <th style="width: 10%; text-align: center">Active</th>
                                    <th style="width: 10%; text-align: center;display: none">Action</th>
                                    <th style="display: none">ID</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <br />
                        <%--<a id="btnApptSecondaryStatus_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>--%>
                        <div class="fabIcon"><a style="color: white" href="ConfigInterface_ApptSecondaryStatusMaster.aspx">+ </a></div>
                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </section>
</asp:Content>
