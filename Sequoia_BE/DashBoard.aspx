<%@ Page Title="Dash Board" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="DashBoard.aspx.cs" Inherits="Sequoia_BE.DashBoard" %>

<asp:Content ID="Content_NestedPage" ContentPlaceHolderID="Content_PageBody" runat="server">
    <section class="content-header">
        <h1>Dash Board
       
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-folder-o"></i>Home</a></li>
        </ol>
    </section>
    <section class="content">

        <div class="box box-default"  style="display:none">
            <div class="box-header with-border">
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="col-md-3">
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h3>
                                    <label id="lbl_Tile1" runat="server">Employee Name</label></h3>
                                <p>Students</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-child"></i>
                            </div>
                            <a href="StudentList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                        <!-- /.form-group -->
                    </div>
                    <!-- /.col -->
                    <div class="col-md-3">
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h3>
                                    <label id="lbl_Tile2" runat="server">0</label><sup style="font-size: 20px"></sup></h3>
                                <p>Events</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-clock-o"></i>
                            </div>
                            <a href="ScheduledCourseList.aspx?PKey=Scheduler" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                        <!-- /.form-group -->
                    </div>

                    <div class="col-md-3">
                        <div class="small-box bg-yellow">
                            <div class="inner">
                                <h3>
                                    <label id="lbl_Tile3" runat="server">0</label></h3>
                                <p>All Courses</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-book"></i>
                            </div>
                            <a href="CourseList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                        <!-- /.form-group -->
                    </div>

                    <div class="col-md-3">
                        <div class="small-box bg-red">
                            <div class="inner">
                                <h3>
                                    <label id="lbl_Tile4" runat="server">0</label></h3>
                                <p>Employees</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-male"></i>
                            </div>
                            <a href="EmployeeList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                        <!-- /.form-group -->
                    </div>
                    <!-- /.col -->
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="box-body">
                            <a class="btn btn-app" href="Sales.aspx">
                                <i class="fa fa-dollar"></i>Invoice & Payments
                            </a>
                            <a class="btn btn-app" href="CorporateSales.aspx">
                                <i class="fa fa-gg"></i>Corporate Invoice
                            </a>
                            <a class="btn btn-app" href="LeadMaster.aspx">
                                <i class="fa fa-globe"></i>Create New Lead
                            </a>
                            <a class="btn btn-app" href="Campaign.aspx">
                                <i class="fa fa-bullhorn"></i>Create Campaign
                            </a>
                        </div>


                        <!-- /.box-header -->

                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12">

                        <div class="nav-tabs-custom" style="cursor: move;">
                            <!-- Tabs within a box -->
                            <ul class="nav nav-tabs pull-right ui-sortable-handle">
                                <li ><a href="#TimeLine" data-toggle="tab">TimeLine</a></li>
                                <li class="active"><a href="#Calender" data-toggle="tab">Calender</a></li>
                            </ul>
                            <div class="tab-content no-padding">
                                <div class="chart tab-pane" id="TimeLine" style="position: relative; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="box-header ui-sortable-handle" style="cursor: move;">
                                                <i class="ion ion-clipboard"></i>
                                                <h3 class="box-title">Today Sessions</h3>
                                            </div>
                                            <div class="box-body">
                                                <ul class="todo-list ui-sortable">
                                                    <asp:Repeater ID="rptrTodayClasses" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <span class="text"><a href="<%#Eval("URL")%>"><%#Eval("ConsolidatedInfo")%></a></span>
                                                                <small class="label label-success"><i class="fa fa-clock-o margin-r-5"></i><%#Eval("TodayTime")%></small>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <ul class="timeline">
                                                <asp:Repeater ID="rptrTimeLineHeader" runat="server" OnItemDataBound="ItemBound">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHeaderKey" Visible="false" Text='<%#Eval("DateInfo")%>' runat="server"></asp:Label>
                                                        <li class="time-label">
                                                            <span style="font-size: 12px" class="bg-<%#Eval("DateColor")%>"><%#Eval("DateInfo")%>
                                                            </span>
                                                        </li>
                                                        <asp:Repeater ID="rptrTimeLineDetails" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <i class="fa <%#Eval("Icon")%> bg-<%#Eval("Color")%>"></i>
                                                                    <div class="timeline-item">
                                                                        <h6 style="font-size: 14px" class="timeline-header"><a href="#"><%#Eval("Header")%></a>   <%#Eval("Details")%></h6>
                                                                        <div style="font-size: 12px" class="timeline-body <%#Eval("BodyHideStatus")%>">
                                                                            <%#Eval("Content")%>
                                                                        </div>
                                                                    </div>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <li>
                                                    <i class="fa fa-clock-o bg-gray"></i>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="chart tab-pane active" id="Calender" style="position: relative;">
                                    <div class="box box-primary">
                                        <div class="box-body no-padding">                                           
                                            <div id="calendar"></div>
                                        </div>                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <!-- /.row -->


            <!-- /.box-body -->
        </div>




    </section>
    <!-- /.content -->
</asp:Content>
