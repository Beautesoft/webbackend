<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_ItemStatusGroup.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_ItemStatusGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <%-- <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>--%>

    <section class="content-header">
        <h1>Item Status Group      
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#">Masters</a></li>
            <li><a href="#">Interface Settings</a></li>
            <li><a href="#">Item Status Groups</a></li>
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

                                <asp:Panel runat="server" ID="panelItemStatusGroupsCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Item Status Groups Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelItemStatusGroupsCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Status Group Code </label>
                                            <input type="text" disabled="disabled" maxlength="255" id="txt_StausCode" class="form-control" runat="server" placeholder="Enter Code" />
                                        </div>

                                        <div class="form-group required">
                                            <label class="control-label">Description</label>
                                            <input type="text" maxlength="100" id="txt_Desc" class="form-control" runat="server" placeholder="Enter Description" />
                                        </div>

                                         <div class="form-group">
                                            <label class="control-label">Short Description</label>
                                            <input type="text" maxlength="100" id="txt_ShortDesc" class="form-control" runat="server" placeholder="Enter Short Description" />
                                        </div>
                                        <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkActive" />
                                                     &nbsp;&nbsp;&nbsp; Active
                                                </label>
                                            </div>
                                        </div>
                                        <br />
                                         <div class="box-footer">
                                            <button id="btn_AddItemStatusGroups" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" type="button" style="text-align: center"  runat="server" onserverclick="Operation_Click" class="btn btn-primary center-block">Add</button>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>


                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelItemStatusGroupsCreation" TargetControlID="panelItemStatusGroupsCreation" CollapseControlID="panelItemStatusGroupsCreationHeader" ExpandControlID="panelItemStatusGroupsCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelItemStatusGroupsListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Item Status Groups List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelItemStatusGroupsList">


                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Item Status Groups</h3>
                                    </div>
                                    <table width="100%" id="tbl_ItemStatusGroupsList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                            <th style="width: 20%">Code</th>
                                            <th style="width: 25%">Description</th>
                                            <th style="width: 25%">Short Desc</th>
                                            <th style="width: 20%; text-align: center">Active</th>
                                            <th style="display: none">ID</th>
                                            </tr>
                                        </thead>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelItemStatusGroupsList" TargetControlID="panelItemStatusGroupsList" CollapseControlID="panelItemStatusGroupsListHeader" ExpandControlID="panelItemStatusGroupsListHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image2" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            
                            </div>

                        </div>

 
                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>