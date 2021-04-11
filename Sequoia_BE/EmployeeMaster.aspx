<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="Sequoia_BE.EmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

     <script type="text/javascript">  
        function alertMessage() {  
            alert('Something Wrong.. Please Check Payment Type or Descripton for Duplicate!');  
        }  
    </script>  

    <section class="content-header">
        <h1>Employee Master       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Employee Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                  <div class="row">

                            <div class="col-md-12">

                                 <asp:Panel runat="server" ID="panelEmpLevelCreationHeader">
                                    <div class="panlheader">
                                       <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Employee Level Creation
                                                <asp:Label runat="server" ID="Label6" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelEmpLevelCreation" CssClass="collapsepanelbody">

                                    <div></div>

                                    <div class="col-md-6">
                                        <br />
                                        <div class="form-group required">
                                            <label class="control-label">Code</label>
                                            <input type="text" disabled="disabled" maxlength="255" id="txt_EmpLevelCode" class="form-control" runat="server" placeholder="Enter Code" />
                                        </div>
                                        <!-- /.form-group -->
                                        <div class="form-group required">
                                            <label class="control-label">Description</label>
                                            <input type="text" maxlength="255" id="txt_EmpLevelDesc" class="form-control" runat="server" placeholder="Enter Description" />
                                        </div>

                                        <!-- /.form-group -->
                                    </div>

                                    <!-- /.col -->
                                    <div class="col-md-6">

                                        <br />
                                        <div class="form-group">
                                            <label class="control-label">Sequence</label>
                                            <input type="text" maxlength="100" runat="server" class="form-control" id="txt_EmpLevelSequence" placeholder="Enter Sequence" />
                                        </div>
                                        <!-- /.form-group -->

                                        <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" id="chkAllowAllSpa" />
                                                    &nbsp;&nbsp;&nbsp;Allow to view all SPA
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" runat="server" checked="checked" id="chkActive" />
                                                     &nbsp;&nbsp;&nbsp; Active
                                                </label>
                                            </div>
                                        </div>
                                        <!-- /.form-group -->
                                    </div>


                                    <div class="pull-left">
                                        <button id="btn_AddEmployeeLevel" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" type="button" onserverclick="Operation_Click" runat="server" class="btn btn-primary">Add</button>
                                    </div>

                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblepanelEmpLevelCreation" TargetControlID="panelEmpLevelCreation" CollapseControlID="panelEmpLevelCreationHeader" ExpandControlID="panelEmpLevelCreationHeader"
                                    Collapsed="true"  BehaviorID="collapse"
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image7" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>


                        </div>

                        <br />

                    <div class="row">

                            <div class="col-md-12">

                                <asp:Panel runat="server" ID="panelEmployeeLevelHeader">
                                    <div class="panlheader">
                                        <table width="100%">
                                            <tr style="height: 35px">
                                                <td class="tableheaderleft">Employee Level List
                                                <asp:Label runat="server" ID="Label5" />
                                                </td>
                                                <td class="tableheaderright">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Img/plus3.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="panelEmployeeLevel">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">List of Employee Level</h3>
                                    </div>
                                    <table id="tblEmployeeLevel" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Code</th>
                                                <th>Description</th>
                                                <th>Sequence</th>
                                                <th style="text-align: center">Active</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                    <br />
                                    <%--<a id="btnEmployeeMaster_EmpLevel_AddNew" class="btn btn-default" ><span class="fa fa-list margin-r-5"></span>Add Row</a>--%>
                                </asp:Panel>

                                <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="CollapsiblePanelEmployeeLevel" TargetControlID="panelEmployeeLevel" CollapseControlID="panelEmployeeLevelHeader" ExpandControlID="panelEmployeeLevelHeader"
                                    Collapsed="true" CollapsedSize="0" 
                                    ExpandedText="" CollapsedText="" TextLabelID="textLabel" ImageControlID="Image6" ExpandedImage="~/Img/minus2.png" CollapsedImage="~/Img/plus3.png"></ajaxToolkit:CollapsiblePanelExtender>

                            </div>

                        </div>

                <br />

            </div>

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>