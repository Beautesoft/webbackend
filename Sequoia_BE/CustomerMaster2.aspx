<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerMaster2.aspx.cs" Inherits="Sequoia_BE.CustomerMaster2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Customer Master       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="CustomerMaster2.aspx">Customer Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelRaceHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Race
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelRace">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Race</h3>
                                    </div>
                                    <table id="tblRace" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_Race_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelRace" TargetControlID="panelRace" CollapseControlID="panelRaceHeader" ExpandControlID="panelRaceHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image6" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>


                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelAgeGroupHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Age Group
                                                <asp:Label runat="server" ID="Label7" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelAgeGroup">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Age Group</h3>
                                    </div>
                                    <table id="tblAgeGroup" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 20%">Code</th>
                                                <th style="width: 20%">Age Group</th>
                                                <th style="width: 40%">Description</th>
                                                <th style="width: 10%;text-align: center">Active</th>
                                                <th style="width: 10%;text-align: center">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_AgeGroup_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelAgeGroup" TargetControlID="panelAgeGroup" CollapseControlID="panelAgeGroupHeader" ExpandControlID="panelAgeGroupHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCorporateCustomerHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Corporate Customer
                                                <asp:Label runat="server" ID="Label1" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCorporateCustomer" CssClass="collapsepanelbody">
                                    <div class="box-header with-border" style="vertical-align:middle">
                                        <h3 class="box-title" style="margin-top:30px">List of Corporate Customer</h3>
                                         <span class="fabIconCustomerClass"><a style="color:white;text-align:right;text-align:center" href="CorporateCustomer.aspx"> + </a>
                                        </span>
                                    </div>
                                    <table id="tblCorporateCustomer" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center;display:none">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCorporateCustomer" TargetControlID="panelCorporateCustomer" CollapseControlID="panelCorporateCustomerHeader" ExpandControlID="panelCorporateCustomerHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image2" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelSkinTypeHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Skin Type
                                                <asp:Label runat="server" ID="Label2" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelSkinType">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Skin Type</h3>
                                    </div>
                                    <table id="tblSkinType" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_SkinType_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelSkinType" TargetControlID="panelSkinType" CollapseControlID="panelSkinTypeHeader" ExpandControlID="panelSkinTypeHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image3" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelLanguageHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Language
                                                <asp:Label runat="server" ID="Label3" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelLanguage">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Language</h3>
                                    </div>
                                    <table id="tblLanguage" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_Language_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelLanguage" TargetControlID="panelLanguage" CollapseControlID="panelLanguageHeader" ExpandControlID="panelLanguageHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image4" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelLocationHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Location
                                                <asp:Label runat="server" ID="Label4" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelLocation">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Location</h3>
                                    </div>
                                    <table id="tblLocation" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                               <th style="width: 30%">Code</th>
                                                <th style="width: 30%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_Location_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelLocation" TargetControlID="panelLocation" CollapseControlID="panelLocationHeader" ExpandControlID="panelLocationHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image5" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                 <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelGenderHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Gender
                                                <asp:Label runat="server" ID="Label9" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelGender">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Gender</h3>
                                    </div>
                                    <table id="tblGender" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width: 20%">Code</th>
                                                <th style="width: 40%">Description</th>
                                                <th style="width: 30% ; text-align: center">Active</th>
                                                <th style="width: 10% ; text-align: center">Action </th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <a id="btnCustomerMaster_Gender_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelGender" TargetControlID="panelGender" CollapseControlID="panelGenderHeader" ExpandControlID="panelGenderHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image5" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

         <%--        <br />--%>

                <div class="row" style="visibility:hidden">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelSourceHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Source
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelSource">
                                    <div class="box-header with-border">
                            <h3 class="box-title">List of Source</h3>
                        </div>
                        <table id="tblSource" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th style="width: 30%">Code</th>
                                    <th style="width: 30%">Description</th>
                                    <th style="width: 30%; text-align: center">Active</th>
                                    <th style="width: 10%; text-align: center">Action</th>
                                    <th style="display: none">ID</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <br />
                        <a id="btnSource_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelExtender1" TargetControlID="panelSource" CollapseControlID="panelSourceHeader" ExpandControlID="panelSourceHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image7" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

<%--                 <br />--%>

                <div class="row" style="visibility:hidden">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panlOccupationTypeheader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Occupation Type
                                                <asp:Label runat="server" ID="Label8" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelOccupationType">
                                  <div class="box-header with-border">
                            <h3 class="box-title">List of Occupation Type</h3>
                        </div>
                        <table id="tblOccupationType" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th style="width: 30%">Code</th>
                                    <th style="width: 30%">Name</th>
                                    <th style="width: 30%; text-align: center">Active</th>
                                    <th style="width: 10%; text-align: center">Action</th>
                                    <th style="display: none">ID</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <br />
                        <a id="btnOccupationType_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelExtender2" TargetControlID="panelOccupationType" CollapseControlID="panlOccupationTypeheader" ExpandControlID="panlOccupationTypeheader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image8" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

            </div>

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>