<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VendorMaster.aspx.cs" Inherits="Sequoia_BE.VendorMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

    <section class="content-header">
        <h1>Vendor     
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="VendorList.aspx">Vendor List</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        
        <asp:UpdatePanel ID="updatepanelVendor" runat="server">

        <ContentTemplate>

        <div class="box">

            <div class="box-body">

                     <div class="row">

                            <div class="col-md-12">

                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="control-label col-xs-1 text-left">Code</label>
                                        <div class="form-group required col-xs-2">
                                            <input type="text" maxlength="255" id="txtCode_VendorMaster" class="form-control" runat="server" placeholder="Enter Code"/>
                                        </div>

                                        <label class="control-label col-xs-2 text-left" style="margin-left:10px">Account No</label>
                                        <div class="form-group required col-xs-2">
                                            <input type="text" id="txtAccountNo_VendorMaster" class="form-control" runat="server"/>
                                        </div>
                                    </div>


                                     <div class="form-group required">

                                         <label class="control-label col-xs-1 text-left">Date</label>
                                         <div class="form-group required col-xs-2">
                                                  <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                    <input type="text" id="txtDate_VendorMaster" class="form-control pull-right" runat="server" ClientIDMode="Static" />
                                                   </div>
                                        </div>

                                        <label class="control-label col-xs-2 text-left" style="margin-left:10px">Supplier Name</label>
                                        <div class="form-group required col-xs-5">
                                            <input type="text" maxlength="255" id="txtSupplierName_VendorMaster" class="form-control" runat="server" placeholder="Enter Supplier Name"/>
                                        </div>

                                    </div>

                                     <div class="form-group">

                                         <div class="checkbox col-xs-3 text-left">
                                               <label class="control-label">
                                                   <input type="checkbox" runat="server" id="chkActive_VendorMaster" checked="checked"/>
                                                   &nbsp;&nbsp;&nbsp;Supplier is currently active
                                               </label>
                                          </div>
                                        
                                       <label class="control-label col-xs-2 text-left">Supplier Attn.</label>
                                        <div class="form-group required col-xs-3">
                                            <input type="text" maxlength="255" id="txtSupplierAtn_VendorMaster" class="form-control" runat="server" placeholder="Enter Supplier Attn."/>
                                        </div>
                                     </div>


                                </div>

                            </div>

                        </div>

                     <div class="row">

                            <div class="col-md-5">

                                 <div class="form-group">
                                    <label class="control-label">Address</label>
                                    <input type="text" maxlength="255" id="txtAddress1_VendorMaster" class="form-control" runat="server" placeholder="Enter Address1" />
                                </div>

                                <div class="form-group">
                                    <input type="text" maxlength="255" id="txtAddress2_VendorMaster" class="form-control" runat="server" placeholder="Enter Address2"/>
                                </div>

                               

                            </div>

                          <div class="col-md-1">
                              <br /><br /><br />
                              <%--<input type="button" id="btnSameMailing" value=">>"  />--%>
                              <button id="btncopy" style="text-align: center" runat="server" type="button" onserverclick="Copy_Click">>></button>
                          </div>


                           <div class="col-md-5">

                                 <div class="form-group">
                                    <label class="control-label">Mailing Address</label>
                                    <input type="text" maxlength="255" id="txtMailAddress1_VendorMaster" class="form-control" runat="server" placeholder="Enter Address1" />
                                </div>

                                <div class="form-group">
                                    <input type="text" maxlength="255" id="txtMailAddress2_VendorMaster" class="form-control" runat="server" placeholder="Enter Address2"/>
                                </div>

                            </div>
                             

                     </div>

                     <div class="row">

                            <div class="col-md-5">

                                 <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtAddress3_VendorMaster" class="form-control" runat="server" placeholder="Enter Address3" />
                                </div>
                               
                            </div>

                           <div class="col-md-offset-1 col-md-5">

                                <div class="form-group required">
                                    <input type="text" maxlength="255" id="txtMailAddress3_VendorMaster" class="form-control" runat="server" placeholder="Enter Address3"/>
                                </div>


                            </div>
                             

                     </div>

                     <div class="row">

                            <div class="col-md-5">

                                 <div class="form-group">
                                    <label class="control-label">Postcode</label>
                                    <input type="text" maxlength="8" id="txtPostCode_VendorMaster" class="form-control" runat="server" placeholder="Enter Postcode" />
                                </div>

                                  <div class="form-group">
                                    <label class="control-label">City</label>
                                    <input type="text" maxlength="255" id="txtCity_VendorMaster" class="form-control" runat="server" placeholder="Enter City" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">State</label>
                                    <input type="text" maxlength="255" id="txtState_VendorMaster" class="form-control" runat="server" placeholder="Enter State" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Country</label>
                                    <input type="text" maxlength="255" id="txtCountry_VendorMaster" class="form-control" runat="server" placeholder="Enter Country" />
                                </div>

                            </div>


                           <div class="col-md-offset-1 col-md-5">

                                  <div class="form-group">
                                    <label class="control-label">Postcode</label>
                                    <input type="text" maxlength="8" id="txtMailPostCode_VendorMaster" class="form-control" runat="server" placeholder="Enter Postcode" />
                                </div>

                                  <div class="form-group">
                                    <label class="control-label">City</label>
                                    <input type="text" maxlength="255" id="txtMailCity_VendorMaster" class="form-control" runat="server" placeholder="Enter City" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">State</label>
                                    <input type="text" maxlength="255" id="txtMailState_VendorMaster" class="form-control" runat="server" placeholder="Enter State" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Country</label>
                                    <input type="text" maxlength="255" id="txtMailCountry_VendorMaster" class="form-control" runat="server" placeholder="Enter Country" />
                                </div>


                            </div>
                             

                     </div>

                     <div class="row" style="margin-top:20px">

                            <div class="col-md-5">

                                 <div class="form-group">
                                    <label class="control-label">Telephone No.</label>
                                    <input type="number" maxlength="12" id="txtPhoneNo_VendorMaster" class="form-control" runat="server" placeholder="Enter Telephone No." />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Fax No.</label>
                                    <input type="number" maxlength="12" id="txtFaxNo_VendorMaster" class="form-control" runat="server" placeholder="Enter Fax No." />
                                </div>

                            </div>


                           <div class="col-md-offset-1 col-md-5">

                                  <div class="form-group">
                                    <label class="control-label">Terms</label>
                                    <input type="number" maxlength="5" id="txtTerms_VendorMaster" class="form-control" runat="server" placeholder="Enter Terms" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Commission</label>
                                    <input type="number" maxlength="10" id="txtCommission_VendorMaster" class="form-control" runat="server" placeholder="Enter Commission" />
                                </div>


                            </div>
                             

                     </div>

                    <div class ="row">

                        <div class="col-md-12">

                                <div class="box-footer">
                                    <button id="btnVendorOperation" type="button" onserverclick="Operation_Click" style="text-align: center" runat="server" class="btn btn-primary center-block" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
                                   <%-- <button id="btnVendorOperation" type="button" onserverclick="Operation_Click" style="text-align: center" runat="server" class="btn btn-primary center-block">Add</button>--%>
                                </div>

                        </div>

                    </div>

            </div> 

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>

 

</asp:Content>


