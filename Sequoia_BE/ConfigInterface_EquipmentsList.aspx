<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_EquipmentsList.aspx.cs" Inherits="Sequoia_BE.ConfigInterface" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Equipment
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Appointment Config</a></li>
            <li><a href="#">Equipment</a></li>
            <li class="active"><a href="#">Operation</a></li>
        </ol>
    </section>

    <section class="content">

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                 <div class="table-wrapper" >
                                        <div class="table-title">
                                            <div class="row" style="margin-bottom: 10px">
                                                <div class="col-lg-12">
                                                    <div class="btnFillter_ConfigEquipmentList" data-toggle="buttons">
                                                        <label class="btn btn-default active">
                                                            <input type="radio" name="status" value="" checked="checked">
                                                            All
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="status" value="Yes">
                                                            Active
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="status" value="No">
                                                            Non Active
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <table id="ConfigEquipmentListMaster" style="font-size: 13px; width: 100%" class="table table-bordered table-striped datatable">
                                            <thead>
                                                <tr>
                                                    <th>Code</th>
                                                    <th>Name</th>
                                                    <th>Description </th>
                                                    <th>Active </th>
                                                    <th style="display:none">ID </th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                    </div>

                 <div class="fabIcon"><a style="color: white" href="ConfigInterface_EquipmentMaster.aspx">+ </a></div>

               <%-- <div class="row">

                            <div class="col-md-12">

<%--                                <asp:Panel runat="server" ID="panelEquipmentHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Equipments
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>--%>

<%--                                <asp:Panel runat="server" ID="panelEquipment">
                                    <div class="box-header with-border">
                                        
                                        <div class="fabIconCustomerClass"><a style="color:white;text-align:right;direction:rtl" href="EquipmentMaster.aspx"> + </a>
                                        </div>
                                    </div>

                                   
                        

                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelEquipment" TargetControlID="panelEquipment" CollapseControlID="panelEquipmentHeader" ExpandControlID="panelEquipmentHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image6" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>--%>

              <%--  <br />--%>

            </div>

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>
