<%@ Page Title="Department Master" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DepartmentMaster.aspx.cs" Inherits="Sequoia_BE.DepartmentMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">

    <section class="content-header">
        <h1>Department Data Entry
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="DeptMasterList.aspx">Department List</a></li>
            <li class="active">Add</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body">

            <asp:UpdatePanel ID="updatepanel" runat="server">

               <ContentTemplate>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group required">
                            <label class="control-label">Department Code</label>
                                <input type="number" class="txtDeptCodeDeptMaster form-control" runat="server" id="txtDeptCode_DeptMaster" maxlength="2"  placeholder="Enter Code"><%--disabled="disabled"--%>
                        </div>
                        <div class="form-group required">
                            <label class="control-label">Description</label>
                            <input type="text" class="form-control" runat="server" id="txtDeptDesc_DeptMaster" maxlength="255" placeholder="Enter Descripion">
                        </div>
                        <div class="form-group">
                            <label class="control-label">Validity Period</label>
                             <asp:DropDownList ID="ddl_ValidityPeriodDeptMaster" class="form-control select2" AutoPostBack="true" runat="server" style="width:100%;"  OnSelectedIndexChanged="DropDownValidityPeriod_SelectedIndexChanged">
                                 <asp:ListItem Text="Select" Value="0"/>
                                 <asp:ListItem Text="1 year" Value="1"/>
                                 <asp:ListItem Text="2 year" Value="2"/>
                                 <asp:ListItem Text="3 year" Value="3"/>
                                 <asp:ListItem Text="Unlimited" Value="4"/>
                                 <%-- <option value="0">Select</option>
                                    <option value="1">1 year</option>
                                    <option value="2">2 year</option>
                                    <option value="3">3 year</option>
                                    <option value="4">Unlimited</option>--%>
                           </asp:DropDownList>  
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                  <label class="control-label">Validity From</label>
                                     <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="txtValidityFrom_DeptMaster">
                                    </div>
                                 </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Validity To</label>
                                     <div class="input-group date" >
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" class="form-control pull-right" id="txtValidityTo_DeptMaster">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label class="control-label">FE Sequence No</label>
                            <input type="number" class="form-control" runat="server" id="txtSeqNo_DeptMaster" maxlength="255"  value="0">
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkActive_DeptMaster" checked="checked">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Department is currently active
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkAllowCashSales_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Allow Cash Sales 
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkShowOnSales_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Show on Sales 
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkFirstTrial_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is first trial
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkRetail_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is retail product
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkSaolon_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is salon product
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkService_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is service
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkVoucher_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is voucher
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkPrepaid_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is prepaid
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkPackage_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is package
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chkCompound_DeptMaster">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp This is compound
                                </label>
                            </div>
                        </div>
                        <!-- /.form-group -->
                    </div>
                    <!-- /.col -->
                    <div class="col-md-6">
                       <div class="form-group" style="visibility:hidden">
                            <label class="control-label">Picture</label>
                        </div>
                        <div class="form-group" style="visibility:hidden">
                            <input id="fileupload" type="file" />
                            </div>
                        <div class="form-group" style="visibility:hidden">
                           
                            
                            <hr />
                            <%--<b>Live Preview</b>--%>
                            <%--<br />
                            <br />--%>
                            <div id="dvPreview">
                            </div>
                            <label id='lblImageName'></label>
                            <%--<button id='removeImg'>Remove Image</button>--%>
                        </div>
                    </div>
                </div>

              </ContentTemplate>

                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_ValidityPeriodDeptMaster" EventName="SelectedIndexChanged" />
                </Triggers>

            </asp:UpdatePanel>

                <!-- /.box-body -->
            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddDeptMaster" type="button" runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
