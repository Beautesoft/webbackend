<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SiteAddressMaster.aspx.cs" Inherits="Sequoia_BE.SiteAddressMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <%-- <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>--%>

    <section class="content-header">
        <h1>Outlet Master       
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

                                <asp:Panel runat="server" ID="panelSiteCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Site Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelSiteCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Site Code</label>
                                            <input type="text" maxlength="255" id="txtSiteCode_Site" class="form-control" runat="server" placeholder="Enter Site Code" />
                                        </div>
                                        <!-- /.form-group -->
                                        <div class="form-group required">
                                            <label class="control-label">Site Desc</label>
                                            <input type="text" maxlength="255" id="txtSiteDesc_Site" class="form-control" runat="server" placeholder="Enter Site Description" />
                                        </div>
                                        <div class="form-group required">
                                            <label>City</label>
                                            <select class="form-control select2" style="width: 100%;border-radius:10px" id="ddlCity" clientidmode="Static" runat="server">
                                            </select>
                                        </div>
                                        <div class="form-group required">
                                            <label>State</label>
                                            <select class="form-control select2" style="width: 100%;" id="ddlState" clientidmode="Static" runat="server">
                                            </select>
                                        </div>
                                        <div class="form-group required">
                                            <label>Country</label>
                                            <select class="form-control select2" style="width: 100%;" id="ddlCountry" clientidmode="Static" runat="server">
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">PostCode</label>
                                            <input type="text" maxlength="20" id="txtPostCode_Site" class="form-control" runat="server" placeholder="Enter PostCode" />
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Address</label>
                                            <textarea class="form-control" cols="1" rows="5" id="txtAddress_Site" placeholder="Enter Address" runat="server"></textarea>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>

                                    <!-- /.col -->
                                    <div class="col-md-6">

                                        <br />
                                        <div class="form-group">
                                            <label class="control-label">E-Mail</label>
                                            <input type="email" maxlength="100" runat="server" class="form-control" id="txtEMail_Site" placeholder="Enter E-Mail" />
                                        </div>
                                        <div class="form-group">
                                            <label>Fax</label>
                                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtFax_Site" placeholder="Enter Fax" />
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Phone 1</label>
                                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtContact1_Site" placeholder="Enter Phone 1" />
                                        </div>
                                        <div class="form-group">
                                            <label>Phone 2</label>
                                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtContact2_Site" placeholder="Enter Phone 2" />
                                        </div>
                                        <div class="form-group">
                                            <label>Site Group</label>
                                            <select class="form-control select2" style="width: 100%;" id="ddlSiteGroup" clientidmode="Static" runat="server">
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Account Code</label>
                                            <input type="text" maxlength="255" id="txtSiteAcCode_Site" class="form-control" runat="server" placeholder="Enter Account Code" />
                                        </div>

                                        <!-- /.form-group -->
                                        <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkGstActive_Site" />
                                                    &nbsp;&nbsp;&nbsp;GST Active
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" checked="checked" id="chkSalesActive_Site" />
                                                     &nbsp;&nbsp;&nbsp; Active
                                                </label>
                                            </div>
                                        </div>
                                        <!-- /.form-group -->
                                    </div>


                                    <div class="pull-left">
                                        <button id="btn_AddSite" type="button" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" onserverclick="Operation_Click" runat="server" class="btn btn-primary">Add</button>
                                    </div>

                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelSiteCreation" TargetControlID="panelSiteCreation" CollapseControlID="panelSiteCreationHeader" ExpandControlID="panelSiteCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image7" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelSiteListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Site List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelSiteList">

                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Sites</h3>
                                    </div>
                                    <table width="100%" id="tblSiteList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Code</th>
                                                <th>Name</th>
                                                <th style="text-align: center;display:none">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelSiteList" TargetControlID="panelSiteList" CollapseControlID="panelSiteListHeader" ExpandControlID="panelSiteListHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image6" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            
                            </div>

                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel runat="server" ID="panelSiteGroupHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Site Group
                                                <asp:Label runat="server" ID="Label3" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelSiteGroup">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Site Groups</h3>
                                    </div>
                                    <table id="tblSite_Group" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
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
                                    <a id="btnOutletMaster_SiteGroup_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelSiteGroup" TargetControlID="panelSiteGroup" CollapseControlID="panelSiteGroupHeader" ExpandControlID="panelSiteGroupHeader"
                                    Collapsed="true" CollapsedSize="0" ExpandedSize="300"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image4" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>
                        </div>

                        <br />

                       <%-- <div class="row">

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
                                                <th style="width: 30% ; text-align: center">Inactive</th>
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
                                                <th style="width: 30% ; text-align: center">Inactive</th>
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
                                                <th style="width: 30% ; text-align: center">Inactive</th>
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
                        </div>--%>



                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>
