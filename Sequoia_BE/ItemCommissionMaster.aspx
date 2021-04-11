<%@ Page Title="Department Master" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ItemCommissionMaster.aspx.cs" Inherits="Sequoia_BE.ItemCommissionMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    
    <section class="content-header">
        <h1>Commission Group Entry
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="ItemCommissionMasterList.aspx">Commission Group List</a></li>
            <li class="active">Add</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body">

                  <div class="panel-heading" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divGeneral">
                        <h3 class="panel-title">General</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divGeneral">

                         <div class="row">

                            <div class="col-md-6">
                                <div class="form-group required">
                                    <label class="control-label">Code</label>
                                    <input type="text" class="form-control" runat="server" id="txtCode_CommissionGroup" maxlength="255" disabled="disabled">
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <div class="form-group required">
                                    <label class="control-label">Description</label>
                                    <input type="text" class="form-control" runat="server" id="txtDescription_CommissionGroup" maxlength="255" placeholder="Enter Description">
                                </div>
                            </div>              

                         </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                     <label>Commission Group Type</label>
                                       <select class="form-control select2" style="width: 100%;border-radius:10px" id="ddlCommissionGroup" clientidmode="Static" runat="server">
                                            <option>Sales</option>
                                            <option>Work</option>
                                            <option>Prepaid</option>
                                      </select>
                                </div> 
                             </div> 

                          <div class="col-md-6" id="rowPrepaidType" style="display:none">
                                     <div class="form-group">
                                         <label>Prepaid Type</label>
                                           <select class="form-control select2" style="width: 100%;border-radius:10px" id="ddlCommPrepaidType" clientidmode="Static" runat="server">
                                         </select>
                                    </div> 
                             </div>

                        </div>

                      <%--  <div class="row" id="rowPrepaidType" style="display:none">
                            <div class="col-md-6">
                                     <div class="form-group">
                                         <label>Prepaid Type</label>
                                           <select class="form-control select2" style="width: 100%;border-radius:10px" id="ddlCommPrepaidType" clientidmode="Static" runat="server">
                                         </select>
                                    </div> 
                             </div>
                        </div>--%>

                        <div class="row">
                            <div class="col-md-6">
                              <div class="form-group">
                                    <div class="checkbox icheck" style="margin-top:25px;margin-left:15px" >
                                            <input type="checkbox" checked="checked" runat="server" name="active" id="chk_CommissionGroupActive">
                                            <label for="active" style="margin-left: 15px">Currently Active</label>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <br id="brid1_ItemCommissionMaster" />

                    <div class="panel-heading" id="divCommissionDetailHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divCommissionDetail">
                        <h3 class="panel-title">Commission Detail</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                    <div class="panel-body collapse" id="divCommissionDetail">
                        <table id="tblCommissionDetail" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th style="display:none">Level Code</th>
                                    <th>Level</th>
                                    <th>From Range</th>
                                    <th>To Range</th>
                                    <th>Rate</th>
                                    <th>Is Percent</th>
                                    <th>Calc. Method</th>
                                    <th>Type</th>
                                    <th>Is Active</th>
                                    <th style="width: 5%; text-align: center">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                        <a id="btn_AddRow_CommissionDetail" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>
                    </div>

                    <br id="brid2_ItemCommissionMaster" />

                    <div class="panel-heading" id="divCommissionSiteGroupHeader" data-toggle="collapse" data-parent="#accordion2" aria-expanded="false" href="#divCommissionSiteGroup">
                        <h3 class="panel-title">Site Group Listing</h3>
                        <h4 style="margin-top: -1%" class="panel-title text-right">
                            <a>
                                <i class="fa fa-plus"></i>
                                <i class="fa fa-minus"></i>
                            </a></h4>
                    </div>

                   <div class="panel-body collapse" id="divCommissionSiteGroup">
                        <table id="tblCommissionSiteGroup" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th>Code</th>
                                    <th>Description</th>
                                    <th style="text-align: center">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-10" style="color: red;text-align:center">All</div>
                                            <div class="col-lg-12 col-md-2" style="color: red">
                                                <input type="checkbox" checked="checked" id="selectall" /></div>

                                        </div>

                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                    </div>

                <!-- /.box-body -->
            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddCommissionMaster" type="button" runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
