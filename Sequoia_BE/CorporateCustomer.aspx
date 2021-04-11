<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CorporateCustomer.aspx.cs" Inherits="Sequoia_BE.CorporateCustomer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Corporate Customer       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="CustomerMaster2.aspx">Customer Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        
        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                   <div class="row">

                            <div class="col-md-3">

                                <div class="form-group required">
                                    <label class="control-label">Code</label>
                                        <input type="text" maxlength="255" id="txtCode_CorporateCustomer" class="form-control" runat="server" disabled="disabled" placeholder="Enter Code"/>
                                </div>

                            </div>

                        </div>

                     <div class="row">

                            <div class="col-md-6">

                                 <div class="form-group required">
                                    <label class="control-label">Description</label>
                                    <input type="text" maxlength="255" id="txtName_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Description"/>
                                </div>


                            </div>

                               <div class="col-md-6">

                                <div class="form-group">
                                    <br />
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" runat="server" checked="checked" id="chkInActive_CorporateCustomer"/>
                                            &nbsp;&nbsp;&nbsp; Active
                                        </label>
                                    </div>
                                </div>

                            </div>
                             

                        </div>


                    <div class="row">

                            <div class="col-md-6">

                                <div class="form-group required">
                                    <label class="control-label">Address</label>
                                </div>

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress1_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Address1">
                                </div>

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress2_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Address2">
                                </div>

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress3_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Address3">
                                </div>

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress4_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Address4">
                                </div>

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress5_CorporateCustomer" class="form-control" runat="server" placeholder="Enter Address5">
                                </div>

                            </div>

                        </div>

                    <div class ="row">

                        <div class="col-md-6">

                                <div class="box-footer">
                                    <button id="btnCorporateOperation" type="button" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" onserverclick="Operation_Click" style="text-align: center" runat="server" class="btn btn-primary center-block">Add</button>
                                </div>

                        </div>

                    </div>

            </div> 

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>
