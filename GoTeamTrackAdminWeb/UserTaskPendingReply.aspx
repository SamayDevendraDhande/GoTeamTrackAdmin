<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="UserTaskPendingReply.aspx.cs" Inherits="UserTaskPendingReply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dvMap {
            width: 100%;
            height: 500px;
        }

        .dropdown-menu li > a:hover {
            text-decoration: none;
            background-image: none;
            background-color: #b1b1b1;
            color: #333;
            filter: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span6">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>
                        <b>
                            Pending Tasks</b>
                    </h3>
                </div>
                <div class="portlet-body">
                    <table class="datatable1WithFilter table table-bordered">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>Task</th>
                                <th>Target Date</th>
                                <th>Remarks Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrPendingTask" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <a href="UserTaskDetail.aspx?TID=<%# Eval("Timestamp")%>"><%# Eval("Task")%></a>
                                        </td>
                                        <td>
                                            <%# Eval("TargetDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                        <td>
                                            <%# Eval("RemarksDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <a id="lastrow"></a>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="span6">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>
                        <b>
                            Reply Tasks</b>
                    </h3>
                </div>
                <div class="portlet-body">
                    <table class="datatable1WithFilter table table-bordered">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>Task</th>
                                <th>Target Date</th>
                                <th>Remarks Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrReplyTasks" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <a href="UserTaskDetail.aspx?TID=<%# Eval("Timestamp")%>"><%# Eval("Task")%></a>
                                        </td>
                                        <td>
                                            <%# Eval("TargetDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                        <td>
                                            <%# Eval("RemarksDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <a id="lastrow"></a>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

