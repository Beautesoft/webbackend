<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerClass.aspx.cs" Inherits="Sequoia_BE.CustomerClass" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Customer Class       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="CustomerMaster.aspx">Customer Master</a></li>
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

                                <input type="number" name="txtClassId" id ="txtClassID" value="5"  style="display:none" runat="server"/>

                                <div class="form-group required">
                                        <label class="control-label">Code</label>
                                        <input type="text" maxlength="255" id="txtCode_CustomerClass" class="form-control" runat="server" disabled="disabled"   placeholder="Enter Code"/>
                                </div>
                              

                            </div>
                 </div>

                  <div class="row">

                      <div class="col-md-6">

                              <div class="form-group required">
                                    <label class="control-label">Description</label>
                                    <input type="text" maxlength="255" id="txtName_CustomerClass" class="form-control" runat="server" placeholder="Enter Description"/>
                                </div>

                      </div>

                       <div class="col-md-6">

                           <br />
                              <div class="form-group">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" checked="checked" runat="server" id="chkInActive_CustomerClass">
                                            &nbsp;&nbsp;&nbsp; Active
                                        </label>
                                    &nbsp;&nbsp;</div>
                                </div>

                      </div>

                  </div>

                   <div class="row">

                    <div class ="col-md-6">

                          <div id="divDiscount">
                                    <table id="tblDiscount" runat="server" style="width: 100%;" clientidmode="Static" class="table table-bordered table-striped datatable">
                                        <thead>
                                            <tr>
                                                <th style="width: 15%;">Code</th>
                                                <th style="width: 70%;">Department</th>
                                                <th style="width: 15%;text-align: center">Discount</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                             </div>

                             <div class="box-footer">
                                    <button id="btnOperation" type="button" onserverclick="Operation_Click" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" style="text-align: center" runat="server" class="btn btn-primary center-block">Add</button>
                                 
                                  <%--<button id="btnOperation" type="button" onserverclick="Operation_Click" runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>--%>
                             </div>

                    </div>

                </div>


            </div> 

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>
