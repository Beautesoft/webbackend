﻿<%@ Page Title="Brand" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_ApptBookingStatusMaster.aspx.cs" Inherits="Sequoia_BE.ConfigInterface_ApptBookingStatusMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">

    <script type="text/javascript">

        function Color_Changed(sender) {

            sender.get_element().value = "#" + sender.get_selectedColor();
            //document.getElementById("divColor2").style.backgroundColor = 'red';
            //var a = document.getElementById("divColor2");
            //a.style.backgroundColor = "#" + sender.get_selectedColor();
            //document.getElementById("divColor2").style.backgroundColor = "#CCFF00";
            //$("divColor").value = "#" + sender.get_selectedColor();

        }

    </script>


    <section class="content-header">
        <h1>Appointment Booking Status
                <small></small>
        </h1>
        <ol class="breadcrumb">
             <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Appointment Config</a></li>
            <li><a href="ConfigInterface_ApptBookingStatus.aspx">Booking Status List</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body">

                <div>

                    <div class="row">
                    <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Code</label>
                                 <input type="text" class="form-control" runat="server" id="txtCode_ApptBookingStatus" maxlength="255" disabled="disabled">
                            </div>
                     </div>
                        <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Description</label>
                                <input type="text" class="form-control" runat="server" id="txtDesc_ApptBookingStatus" maxlength="255" placeholder="Enter Description">
                            </div>
                     </div>                         

                  </div>

                    <div class="row">

                        <div class="col-md-6">

                              <div class="form-group">

                                    <label class="control-label">Color Code</label>

                                    <asp:TextBox ID="txtColor" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" class="form-control" runat="server" maxlength="255" placeholder="Enter Color Code"/>
                                
                                </div>

                        </div>

                       <%-- <div class="col-md-1">
                            <input type="color" id="divColor" runat="server" name="favcolor" value="">
                        </div>
                        
                         <div class="col-md-1"  id="divColor2" runat="server" clientidmode="Static"  style="height:20px;width:50px;background-color:green">
                        </div>--%>

                        <div class="col-md-3">

                            <div class="form-group">

                              <label class="control-label"> </label>
                              <asp:Button ID="btnPicker" runat="server" style="margin-top:27px" class="btn-default" Text="Choose Color" />

                              <asp:colorpickerextender id="ColorPicker1" runat="server" targetcontrolid="txtColor" samplecontrolid="PreviewColor" popupbuttonid="btnPicker" popupposition="Right" onclientcolorselectionchanged="Color_Changed" />

                           </div>

                        </div>


                    </div>

                    <div class="row">

                        <div class="col-md-6">
                         <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chk_ApptBookingStatus" checked="checked">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp  Is Currently Active
                                </label>
                                </div>
                             </div>
                        </div>

                    </div>


                </div>

                <br />

            </div>
            <div class="box-footer">

                <button type="button" class="btn btn-primary" runat="server" id="btnSubmit_AddApptStatusMaster" onserverclick="Operation_Click"
                    data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>

            </div>
        </div>

        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
