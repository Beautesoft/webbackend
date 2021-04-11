<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_FOCReason.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_FOCReason" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <%-- <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>--%>

    <section class="content-header">
        <h1>FOC Reason      
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Interface Settings</a></li>
            <li><a href="#">FOC Reason</a></li>
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

                                <asp:Panel runat="server" ID="panelFOCReasonCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">FOC Reason Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelFOCReasonCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <asp:TextBox runat="server" ID="txtPrefix" CssClass="form-control" AutoPostBack="true" Style="display: none" />
                                        <asp:TextBox runat="server" ID="txtControlNo" CssClass="form-control" AutoPostBack="true" Style="display: none" />
                                        <div class="form-group required">
                                            <label class="control-label">Code</label>
                                            <input type="text" maxlength="255" id="txtCode_FOCReason" disabled="disabled" class="form-control" runat="server" placeholder="Enter Code" />
                                        </div>

                                         <div class="form-group required">
                                            <label class="control-label">Long Description</label>
                                            <input type="text" maxlength="255" id="txtDesc_FOCReason" class="form-control" runat="server" placeholder="Enter Description" />
                                        </div>
                                        
                                          <div class="form-group required">
                                            <label class="control-label">Short Desc.</label>
                                            <input type="text" maxlength="255" id="txtShortDesc_FOCReason" class="form-control" runat="server" placeholder="Enter Short Description" />
                                        </div>                                     
 
                                        
                                        <br />

                                         <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkStatusActive_FOCReason" />
                                                    &nbsp;&nbsp;&nbsp;Is Currently Active
                                                </label>
                                            </div>
                                        </div>

                                         <div class="box-footer">
                                            <button id="btn_AddFOCReason" type="button" style="text-align: center" runat="server" onserverclick="Operation_Click" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" class="btn btn-primary center-block">Add</button>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelFOCReasonCreation" TargetControlID="panelFOCReasonCreation" CollapseControlID="panelFOCReasonCreationHeader" ExpandControlID="panelFOCReasonCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelFOCReasonListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">FOC Reason List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelFOCReasonList">

                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of FOC Reason</h3>
                                    </div>
                                    <table width="100%" id="tblFOCReasonList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width:20%">Code</th>
                                                <th style="width:25%">Description</th>
                                                <th style="width:25%">Short Desc</th>
                                                <th style="width:10%;text-align: center">Active</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelFOCReasonList" TargetControlID="panelFOCReasonList" CollapseControlID="panelFOCReasonListHeader" ExpandControlID="panelFOCReasonListHeader"
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