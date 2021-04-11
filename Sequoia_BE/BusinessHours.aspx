<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BusinessHours.aspx.cs" Inherits="Sequoia_BE.BusinessHours" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_PageBody" runat="server">
<section class="content-header">
        <h1>Business Hours       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Business Hours</a></li>
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

                                <asp:Panel runat="server" ID="panelBusinessHoursCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Business Hours Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelBusinessHoursCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Business Day</label>
                                            <input type="text" maxlength="255" id="txt_BusinessDay" class="form-control" runat="server" placeholder="Enter Business Day" />
                                        </div>

                                        <div class="form-group required">
                                            <label class="control-label">Status</label>
                                            <input type="text" maxlength="100" id="txt_Status" class="form-control" runat="server" placeholder="Enter Status" />
                                        </div>

                                         <div class="form-group">
                                            <label class="control-label">Start Time</label>
                                            <input type="text" maxlength="100" id="txt_StartTime" class="form-control" runat="server" placeholder="Enter Start Time" ClientIDMode="Static"  />
                                        </div>
                                         <div class="form-group">
                                            <label class="control-label">End Time</label>
                                            <input type="text" maxlength="100" id="txt_EndTime" class="form-control" runat="server" placeholder="Enter End Time" ClientIDMode="Static"  />
                                        </div>
                                         <div class="form-group">
                                            <label class="control-label">Site Code</label>
                                            <input type="text" maxlength="100" id="txt_SiteCode" class="form-control" runat="server" placeholder="Enter Site Code" />
                                        </div>
                                        <br />
                                         <div class="box-footer">
                                            <button id="btn_AddBusinessHours" type="button" style="text-align: center" onserverclick="Operation_Click" runat="server" class="btn btn-primary center-block">Add</button>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>


                                </asp:Panel>
                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelBusinessHoursCreation" TargetControlID="panelBusinessHoursCreation" CollapseControlID="panelBusinessHoursCreationHeader" ExpandControlID="panelBusinessHoursCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelBusinessHoursListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Business Hours List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelBusinessHoursList">


                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Business Hours</h3>
                                    </div>
                                    <table width="100%" id="tbl_BusinessHoursList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Business Day</th>
                                                <th>Status</th>
                                                <th>Start Time</th>
                                                <th>End Time</th>
                                                <%--<th>Site Code</th>--%>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelBusinessHoursList" TargetControlID="panelBusinessHoursList" CollapseControlID="panelBusinessHoursListHeader" ExpandControlID="panelBusinessHoursListHeader"
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
