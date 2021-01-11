<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TaskListOnGoing.aspx.cs" Inherits="TaskListOnGoing" %>

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
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>
                        <b>
                            <asp:Label ID="lblOnGoingTitle" runat="server"></asp:Label></b>
                    </h3>
                </div>
                <div class="portlet-body">
                    <table class="datatable1WithFilter table table-bordered">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>Task
                                </th>
                                <th>Status
                                </th>
                                <th>User</th>
                                <th>Action</th>
                                <th>Create Date</th>
                                <th>Target Date</th>
                                <th>Remarks</th>
                                <th>Remarks Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrTaskOngoing" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <a href="TaskEdit.aspx?TID=<%# Eval("Timestamp")%>"><%# Eval("Task")%></a>
                                        </td>
                                        <td>
                                            <%# Eval("Status")%>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%> (<%# Eval("UCode")%>)
                                        </td>
                                        <td>
                                            <div class="btn-group">
                                                <a class="btn dropdown-toggle tbl-link" data-toggle="dropdown" href="#">Actions<i class="icon-angle-down"></i>
                                                </a>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" class="changeStatus"
                                                            OnCommand="btnUnallocated_Command" Style="width: 100px;" CommandArgument='<%# Eval("Timestamp")%>'
                                                            Text="Unallocated"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" class="changeStatus"
                                                            OnCommand="btnPending_Command" Style="width: 100px;" CommandArgument='<%# Eval("Timestamp")%>'
                                                            Text="Pending"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" class="changeStatus"
                                                            OnCommand="btnCompleted_Command" Style="width: 100px;" CommandArgument='<%# Eval("Timestamp")%>'
                                                            Text="Completed"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" class="changeStatus"
                                                            OnCommand="btnClosed_Command" Style="width: 100px;" CommandArgument='<%# Eval("Timestamp")%>'
                                                            Text="Closed"></asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("CreateDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                        <td>
                                            <%# Eval("TargetDate", "{0:dd/MM/yyyy}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Remarks")%>
                                        </td>
                                        <td>
                                            <%# Eval("RemarksDate")%>
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

