<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_AppointmentGroup.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_AppointmentGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_PageBody" runat="server">
      <section class="content-header">
        <h1>Appointment Group
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Config Interface Settings</a></li>
            <li><a href="#">Appointment Group</a></li>
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
                            <h3 class="box-title">List of Appointment Group</h3>
                        </div>
                        <table id="tblAppointmentGroup" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th style="width: 30%">Code</th>
                                    <th style="width: 30%">Description</th>
                                    <th style="width: 30%; text-align: center">Active</th>
                                   <%-- <th style="width: 30%;">Sequence</th>--%>
                                    <th style="width: 10%; text-align: center">Action</th>
                                    <th style="display: none">ID</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <br />
                        <a id="btnAppointmentGroup_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>

                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </section>
</asp:Content>
