<%@ Page Language="C#"  MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConfigInterface_EquipmentMaster.aspx.cs" Inherits="Sequoia_BE.EquipmentMaster" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server" enctype="multipart/form-data">
    <section class="content-header">
        <h1>Equipment
                <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="ConfigInterface_EquipmentsList.aspx">Equipment List</a></li>
            <li class="active">Add</li>
        </ol>
    </section>
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body">

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required">
                                <label class="control-label">Equiptment ID</label>
                                <input type="text" class="form-control" runat="server" id="txtEquipmentID_ConfigInterface" maxlength="255" disabled="disabled"/>                                
                            </div>

                             <div class="form-group required">
                                <label class="control-label">Equipment Name</label>
                                <input type="text" class="form-control" runat="server" id="txtEquipmentName_ConfigInterface" maxlength="255" placeholder="Enter Equipment Name"/>
                            </div>

                            <div class="form-group">
                                <label class="control-label">Description</label>
                                <textarea class="form-control" cols="1" rows="5"  runat="server" id="txtEquipmentDescription_ConfigInterface" placeholder="Enter Equipment Description"></textarea>
                            </div>

                            <div class="form-group">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" runat="server" id="chk_ActiveEquipment" checked="checked"/>
                                        &nbsp&nbsp&nbsp&nbsp&nbsp Active
                                    </label>
                                </div>
                            </div>

                        </div>
                       

                    </div>

                </div>
                <br />


            </div>
            <div class="box-footer">
                <button id="btnSubmit_AddEquipmentMaster" type="button" runat="server" onserverclick="Operation_Click" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Add" class="btn btn-primary">Add</button>
            </div>


        <!-- /.box -->
    </section>
    <%--</form>--%>
</asp:Content>