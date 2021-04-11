<%@ Page Language="C#"  MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SiteMaster.aspx.cs" Inherits="Sequoia_BE.SiteMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Site Creation       
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="SiteMaster.aspx">Site Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Site Data Entry</h3>
                <label id="lblLastUpdateInfo_Corporate" style="font-weight: lighter;" runat="server"></label>
            </div>
            <!-- /.box-header -->
            <div class="box-body">

                <div class="row">

                    <div class="col-md-6">
                        <div class="form-group required">
                            <label class="control-label">Site Code</label>
                             <input type="text" maxlength="255" id="txtSiteCode_Site" class="form-control" runat="server" placeholder="Enter Site Code"/>
                        </div>
                        <!-- /.form-group -->
                        <div class="form-group required">
                            <label class="control-label">Site Desc</label>
                            <input type="text" maxlength="255" id="txtSiteDesc_Site" class="form-control" runat="server" placeholder="Enter Site Description"/>
                        </div>
                         <div class="form-group">
                            <label>City</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlCity" clientidmode="Static" runat="server">
                            </select>
                        </div>
                        <div class="form-group">
                            <label>State</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlState" clientidmode="Static" runat="server">
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Country</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlCountry" clientidmode="Static" runat="server">
                            </select>
                        </div>
                        <div class="form-group required">
                            <label class="control-label">PostCode</label>
                            <input type="text" maxlength="20" id="Text1" class="form-control" runat="server" placeholder="Enter PostCode"/>
                        </div>
                        <div class="form-group required">
                            <label class="control-label">Address</label>
                            <textarea class="form-control" cols="1" rows="5" id="txtAddress_Corporate" placeholder="Enter Address" runat="server"></textarea>
                        </div>
                        <!-- /.form-group -->
                    </div>

                    <!-- /.col -->
                    <div class="col-md-6">

                         <div class="form-group required">
                            <label class="control-label">E-Mail</label>
                            <input type="email" maxlength="100" runat="server" class="form-control" id="txtEMail_Site" placeholder="Enter E-Mail"/>
                        </div>
                         <div class="form-group">
                            <label>Fax</label>
                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtFax_Site" placeholder="Enter Fax"/>
                        </div>
                         <div class="form-group required">
                            <label class="control-label">Phone 1</label>
                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtContact1_Site" placeholder="Enter Phone 1"/>
                        </div>
                        <div class="form-group">
                            <label>Phone 2</label>
                            <input type="number" maxlength="50" runat="server" class="form-control" id="txtContact2_Site" placeholder="Enter Phone 2"/>
                        </div>
                        <div class="form-group">
                            <label>Site Group</label>
                            <select class="form-control select2" style="width: 100%;" id="ddlSiteGroup" clientidmode="Static" runat="server">
                            </select>
                        </div>
                         <div class="form-group required">
                            <label class="control-label">Account Code</label>
                            <input type="text" maxlength="255" id="txtSiteAcCode_Site" class="form-control" runat="server" placeholder="Enter Account Code"/>
                        </div>

                        <!-- /.form-group -->

                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkGstActive_Site">
                                    GST Active
                                </label>
                            </div>
                        </div>
                          <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkSalesActive_Site">
                                    Sales Currently Active
                                </label>
                            </div>
                        </div>
                        <!-- /.form-group -->
                    </div>
                    <!-- /.col -->

                </div>

                <!-- /.row -->
                <!-- /.box-body -->

            </div>
            <div class="box-footer">
                <button id="btnOperation" type="button" onserverclick="Operation_Click" runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
            </div>
        </div>
        <!-- /.box -->
    </section>
</asp:Content>