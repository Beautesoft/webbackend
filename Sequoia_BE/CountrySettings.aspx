<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CountrySettings.aspx.cs" Inherits="Sequoia_BE.CountrySettings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_PageBody" runat="server">

        <section class="content-header">
        <h1>Country Settings       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="SiteAddressMaster.aspx">Outlet Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

            <ContentTemplate>

                <div class="box">
                    <div class="box-body">

                        <div class="row">

                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCityHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">City
                                                <asp:Label runat="server" ID="textLabel" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="panelCity">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Cities</h3>
                                    </div>
                                    <table id="tblSiteAddress_City" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Name</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action</th>
                                                <th style="display: none">ID</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnOutletMaster_City_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCity" TargetControlID="panelCity" CollapseControlID="panelCityHeader" ExpandControlID="panelCityHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel"
                                    ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelStateHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">State
                                                <asp:Label runat="server" ID="Label1" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="panelState">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of States</h3>
                                    </div>
                                    <table id="tblSiteAddress_State" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Name</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnOutletMaster_State_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelState" TargetControlID="panelState" CollapseControlID="panelStateHeader" ExpandControlID="panelStateHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image2" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCountryHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Country
                                                <asp:Label runat="server" ID="Label2" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="panelCountry">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Countries</h3>
                                    </div>
                                    <table id="tblSiteAddress_Country" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Name</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnOutletMaster_Country_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCountry" TargetControlID="panelCountry" CollapseControlID="panelCountryHeader" ExpandControlID="panelCountryHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image3" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            </div>
                        </div>



                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </section>

</asp:Content>
