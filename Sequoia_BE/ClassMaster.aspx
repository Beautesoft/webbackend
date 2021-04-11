<%@ Page Title="Classification Entry" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ClassMaster.aspx.cs" Inherits="Sequoia_BE.ClassMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Class List
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="ClassificationMaster.aspx">Classification List</a></li>
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
                                 <input type="text" class="txtCodeClassMaster form-control" runat="server" id="txtCode_ClassMaster" maxlength="2" ><%--disabled="disabled"--%>
                            </div>
                     </div>
                        <div class="col-md-6">
                             <div class="form-group required">
                                <label class="control-label">Description</label>
                                <input type="text" class="form-control" runat="server" id="txtName_ClassMaster" maxlength="255" placeholder="Enter Description">
                            </div>
                     </div>                         

                  </div>

                    <div class="row">
                        <div class="col-md-6" style="margin-top: 2%">
                         <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" runat="server" id="chk_ActiveClassMaster" checked="checked">
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
                <button id="btnSubmit_AddClassMaster" type="button"  runat="server" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" class="btn btn-primary">Add</button>
            </div>
        </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>
