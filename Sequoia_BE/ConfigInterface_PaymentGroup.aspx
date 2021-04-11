<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_PaymentGroup.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_PaymentGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <%-- <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>--%>

    <section class="content-header">
        <h1>Payment Group       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Config Interface</a></li>
            <li><a href="#">Room</a></li>
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

                                <asp:Panel runat="server" ID="panelPayGroupCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Payment Group Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelPayGroupCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Code</label>
                                            <input type="text" maxlength="255" id="txtCode_PayGroup" class="form-control" runat="server" placeholder="Enter Code" />
                                        </div>

                                        <div class="form-group required">
                                            <label class="control-label">Sequence</label>
                                            <input type="number" maxlength="10" id="txtSqe_PayGroup" class="form-control" runat="server" placeholder="Enter Sequence" />
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label">Picture</label>
                                        </div>
                                        <div class="form-group">
                                            <input id="img_Upload" type="file" runat="server"/>
                                        </div>

                                        <div class="form-group">
                                            <hr />
                                            <div id="dvPreview">
                                            </div>
                                            <label id="lblImageName" runat="server"></label>
                                        </div>

                                        <br />

                                         <div class="box-footer">
                                            <button id="btn_AddPayGroup" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" type="button" onserverclick="Operation_Click" style="text-align: center" runat="server" class="btn btn-primary center-block">Add</button>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>


                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelPayGroupCreation" TargetControlID="panelPayGroupCreation" CollapseControlID="panelPayGroupCreationHeader" ExpandControlID="panelPayGroupCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelPayListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Payment Group List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelPayList">


                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Payment Groups</h3>
                                    </div>
                                    <table width="100%" id="tblSiteList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th style="width:40%">Code</th>
                                                <th style="width:60%">Sequence</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelRoomList" TargetControlID="panelPayList" CollapseControlID="panelPayListHeader" ExpandControlID="panelPayListHeader"
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
