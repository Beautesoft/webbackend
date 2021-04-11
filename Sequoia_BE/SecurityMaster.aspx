<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SecurityMaster.aspx.cs" Inherits="Sequoia_BE.SecurityMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">

     <script type="text/javascript">  
        function alertMessage() {  
            alert('Something Wrong.. Please Check Payment Type or Descripton for Duplicate!');  
        }  
    </script>  

    <section class="content-header">
        <h1>Security Master       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="DashBoard.aspx"><i class="fa fa-folder-o"></i>Home</a></li>
            <li><a href="#">Masters</a></li>
            <li><a href="#">Security Master</a></li>
            <li class="active">Operation</li>
        </ol>
    </section>
    <section class="content">

        <asp:UpdatePanel ID="updatepanelsite" runat="server">

        <ContentTemplate>

        <div class="box">

             <div class="box-body">

                        <div class="box-header with-border">
                            <h3 class="box-title">List of Security Level</h3>
                        </div>
                        <table id="tblSecurityLevel" clientidmode="Static" class="table table-bordered table-striped datatable" runat="server">
                            <thead>
                                <tr>
                                    <th style="width: 15%">Code</th>
                                    <th style="width: 25%">Name</th>
                                    <th style="width: 40%">Description</th>
                                    <th style="width: 10%; text-align: center">Is Active</th>
                                    <th style="width: 10%; text-align: center">Action</th>
                                    <th style="display: none">ID</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <br />
                        <a id="btnSecurityLevel_AddNew" class="btn btn-default" href="#"><span class="fa fa-list margin-r-5"></span>Add Row</a>

               </div>

        </div>

         </ContentTemplate>

        </asp:UpdatePanel>

    </section>



</asp:Content>