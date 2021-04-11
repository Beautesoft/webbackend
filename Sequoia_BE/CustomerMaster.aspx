<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerMaster.aspx.cs" Inherits="Sequoia_BE.CustomerMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Customer Master       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="CustomerMaster.aspx">Customer Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                <%--<div class="row">

                    <div class="col-md-12">

                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" HeaderCssClass="headerCssClass" ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="true" TransitionDuration="500" AutoSize="None" SelectedIndex="0" >
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPaneCustomerClass" runat="server">
                                    <Header>Customer Class</Header>
                                    <Content>
                                         <div class="box-header with-border">
                                               <h3 class="box-title">List of Customer Class</h3>
                                         </div>
                                         <table width="100%" id="tblCustomerClass" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                        <br />
                                        <a id="btnCustomerMaster_Class_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPaneCustomerType" runat="server">
                                    <Header>Customer Type</Header>
                                    <Content>
                                          <div class="box-header with-border">
                                               <h3 class="box-title">List of Customer Type</h3>
                                         </div>
                                         <table width="100%" id="tblCustomerType" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                        <br />
                                        <a id="btnCustomerMaster_Type_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPaneCustomerGrp1" runat="server">
                                    <Header>Customer Group-1</Header>
                                    <Content>
                                          <div class="box-header with-border">
                                               <h3 class="box-title">List of Customer Group-1</h3>
                                         </div>
                                         <table width="100%" id="tblCustomerGrp1" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                        <br />
                                        <a id="btnCustomerMaster_Group1_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPaneCustomerGrp2" runat="server">
                                    <Header>Customer Group-2</Header>
                                    <Content>
                                          <div class="box-header with-border">
                                               <h3 class="box-title">List of Customer Group-2</h3>
                                         </div>
                                         <table width="100%" id="tblCustomerGrp2" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                        <br />
                                        <a id="btnCustomerMaster_Group2_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPaneCustomerGrp3" runat="server">
                                    <Header>Customer Group-3</Header>
                                    <Content>
                                          <div class="box-header with-border">
                                               <h3 class="box-title">List of Customer Group-3</h3>
                                         </div>
                                         <table width="100%" id="tblCustomerGrp3" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                        <br />
                                        <a id="btnCustomerMaster_Group3_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPaneProductGrp" runat="server">
                                    <Header>Product Group</Header>
                                    <Content>
                                          <div class="box-header with-border">
                                               <h3 class="box-title">List of ProductGrp</h3>
                                         </div>
                                         <table width="100%" id="tblProductGrp" class="table table-bordered table-striped datatable" runat="server">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th style="text-align: center">Inactive</th>
                                                    <th style="text-align: center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                         <br />
                                        <a id="btnCustomerMaster_ProductGroup_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                    </Content>
                                </ajaxToolkit:AccordionPane>

                            </Panes>
                        </ajaxToolkit:Accordion>

                        <br />

                    </div>

                </div>--%>

                <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelCustomerClassHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Class
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCustomerClass">
                                    <div class="box-header with-border">
                                        
                                        <div class="fabIconCustomerClass"><a style="color:white;text-align:right;direction:rtl" href="CustomerClass.aspx"> + </a>
                                        </div>
                                        <span> <h3 class="box-title" style="margin-top:30px">List of Customer Class</h3> </span>
                                    </div>
                                    <table id="tblCustomerClass" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Code</th>
                                                <th>Description</th>
                                                <th style="text-align: center">Active</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCustomerClass" TargetControlID="panelCustomerClass" CollapseControlID="panelCustomerClassHeader" ExpandControlID="panelCustomerClassHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image6" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                                

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelCustomerTypeHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Type
                                                <asp:Label runat="server" ID="Label7" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCustomerType">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Customer Types</h3>
                                    </div>
                                    <table id="tblCustomerType" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnCustomerMaster_Type_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCustomerType" TargetControlID="panelCustomerType" CollapseControlID="panelCustomerTypeHeader" ExpandControlID="panelCustomerTypeHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCustomerGrp1Header">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Group-1
                                                <asp:Label runat="server" ID="Label1" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCustomerGrp1">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Customer Group-1</h3>
                                    </div>
                                    <table id="tblCustomerGrp1" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnCustomerMaster_Group1_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCustomerGrp1" TargetControlID="panelCustomerGrp1" CollapseControlID="panelCustomerGrp1Header" ExpandControlID="panelCustomerGrp1Header"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image2" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCustomerGrp2Header">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Group-2
                                                <asp:Label runat="server" ID="Label2" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCustomerGrp2">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Customer Group-2</h3>
                                    </div>
                                    <table id="tblCustomerGrp2" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnCustomerMaster_Group2_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCustomerGrp2" TargetControlID="panelCustomerGrp2" CollapseControlID="panelCustomerGrp2Header" ExpandControlID="panelCustomerGrp2Header"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image3" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelCustomerGrp3Header">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Group-3
                                                <asp:Label runat="server" ID="Label3" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelCustomerGrp3">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Customer Group-3</h3>
                                    </div>
                                    <table id="tblCustomerGrp3" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnCustomerMaster_Group3_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelCustomerGrp3" TargetControlID="panelCustomerGrp3" CollapseControlID="panelCustomerGrp3Header" ExpandControlID="panelCustomerGrp3Header"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image4" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                <br />

                <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelProductGrpHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Customer Product Group
                                                <asp:Label runat="server" ID="Label4" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelProductGrp">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Customer Product Groups</h3>
                                    </div>
                                    <table id="tblProductGrp" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnCustomerMaster_ProductGroup_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelProductGrp" TargetControlID="panelProductGrp" CollapseControlID="panelProductGrpHeader" ExpandControlID="panelProductGrpHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image5" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

            </div>

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>
