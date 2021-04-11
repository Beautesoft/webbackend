<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_RoomMaster.aspx.cs" Inherits="Sequoia_BE.RoomMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <%-- <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>--%>

    <section class="content-header">
        <h1>Room       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Appointment Config</a></li>
            <li><a href="#">Room</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->

     

                <div class="box">

                    <div class="box-body">

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelRoomCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Room Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelRoomCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Code</label>
                                            <input type="text" disabled="disabled" maxlength="255" id="txtCode_Room" class="form-control" runat="server" placeholder="Enter Code" />
                                        </div>

                                        

                                         <div class="form-group required">
                                            <label class="control-label">Room No.</label>
                                            <input type="text" maxlength="255" id="txt_RoomNo" class="form-control" runat="server" placeholder="Enter Room No." />
                                        </div>

                                        

                                        <div class="form-group">
                                            <label>Equipment</label>
                                            <select multiple class="form-control select2 chosen-select" data-placeholder="Select Multiple"  style="width: 100%;" id="ddlEquipment" clientidmode="Static" runat="server" >
                                            </select>
                                        </div>
                                        
                                          <%--<div class="form-group required">
                                            <label class="control-label">Equipment</label>
                                            <input type="text" maxlength="255" id="txtEquipment_Room" class="form-control" runat="server" placeholder="Enter Room Equipment" />
                                        </div>--%>


                                         <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkRoomActive_Room" />
                                                    &nbsp;&nbsp;&nbsp;Room is Currently Active
                                                </label>
                                            </div>
                                        </div>

                                         <div class="box-footer">
                                            <button id="btn_AddRoom" type="button" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" onserverclick="Operation_Click" style="text-align: center" runat="server" class="btn btn-primary center-block">Add</button>
                                        </div>

                                        <!-- /.form-group -->
                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                            <div class="form-group required">
                                            <label class="control-label">Site Code</label>
                                             <select class="form-control select2" style="width: 100%;" id="ddlSiteCode_Room" clientidmode="Static" runat="server">
                                            </select>
                                        </div>
                                        </div>
                                    <div class="col-md-6">
                                            <label class="control-label">Room Description</label>
                                            <input type="text" maxlength="255" id="txteDesc_Room" class="form-control" runat="server" placeholder="Enter Room Description" />
                                        </div>
                                    <div class="col-md-6" style="display:none">
                                            <label class="control-label">Room Type</label><br />

                                            <div class="row">
                                                <div class="col-md-3">
                                                     <input type="radio" id="rbtn_SingleRoom" runat="server" name="gender" value="Single"/> Single<br>
                                              <input type="radio" ID="rbtn_Double" runat="server" name="gender" value="Double"/> Double<br>
                                              <input type="radio" ID="rbtn_TripleRoom" runat="server" name="gender" value="Triple"/> Triple<br>  
                                              <input type="radio" ID="rbtn_QuadRoom" runat="server" name="gender" value="Quad"/> Quad<br>
                                                </div>

                                                <div class="col-md-3">
                                                      <input type="radio" ID="rbtn_Twin" runat="server" name="gender" value="Twin"/> Twin<br>
                                              <input type="radio" ID="rbtn_Family" runat="server" name="gender" value="Family"/> Family<br>
                                                      <input type="radio" ID="rbtn_King" runat="server" name="gender" value="King"/> King<br>
                                              <input type="radio" ID="rbtn_Queen" runat="server" name="gender" value="Queen"/> Queen<br>
                                                </div>
                                            </div>

                                           
                                            
                                        </div>  
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelRoomCreation" TargetControlID="panelRoomCreation" CollapseControlID="panelRoomCreationHeader" ExpandControlID="panelRoomCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                        <br />

           <asp:UpdatePanel ID="updatepanelsite" runat="server">

            <ContentTemplate>

                        <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelRoomListHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Room List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelRoomList">

                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Rooms</h3>
                                    </div>
                                    <table width="100%" id="tblSiteList" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Code</th>
                                                <th>Site Code</th>
                                                <th>Room Number</th>
                                                <th>Room Description</th>
                                                <th>Equipment</th>
                                                <th>Room Type</th>
                                                <th style="text-align: center">Room is Active</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />


                                    <!-- /.tab-content -->


                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelRoomList" TargetControlID="panelRoomList" CollapseControlID="panelRoomListHeader" ExpandControlID="panelRoomListHeader"
                                    Collapsed="true" CollapsedSize="0"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image2" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>
                            
                            </div>

                        </div>

 
        </ContentTemplate>

        </asp:UpdatePanel>

                    </div>

                </div>




    </section>

</asp:Content>
