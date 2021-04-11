<%@ Page Title="Division List" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DivMaster.aspx.cs" Inherits="Sequoia_BE.DivMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Division List
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="DivisionMaster.aspx">Division  List</a></li>
            <li class="active">Add</li>
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
                                 <input type="text" class="txtCodeDivMaster form-control" runat="server" id="txtCode_DivMaster" maxlength="2" ><%--disabled="disabled"--%>
                            </div>
                     </div>
                        <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Description</label>
                                <input type="text" class="form-control" runat="server" id="txtName_DivMaster" maxlength="255" placeholder="Enter Description">
                            </div>
                     </div>                         

                  </div>

                    <div class="row">
                        <div class="col-md-6" style="margin-top: 2%">
                         <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chk_ActiveDivMaster" checked="checked">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp Active
                                </label>
                                </div>
                             </div>
                        </div>
                       <div class="col-md-6">
                           </div>


                    </div>
                   </div>

                <br />

            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddDivMaster" type="button"  runat="server" class="btn btn-primary" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add">Add</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
