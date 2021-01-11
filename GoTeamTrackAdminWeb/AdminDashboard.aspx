<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/js/app.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3><asp:Label runat="server" ID="lblTitle"></asp:Label>
                    </h3>
                </div>
                <div class="portlet-body">
                    <table class="datatable1 table table-bordered table-hover">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>User
                                </th>
                                <%--<th>Total Task
                                </th>--%>
                                <th>On Duty
                                </th>
                                <th>Present
                                </th>
                                <th>
                                    <a href="TaskListOnGoing.aspx?status=Pending">Pending (<asp:Label ID="lblPendingTask" runat="server"></asp:Label>
                                        )</a>
                                </th>
                                <th>
                                    <a href="TaskListOnGoing.aspx?status=Reply">Reply (<asp:Label ID="lblReplyTask" runat="server"></asp:Label>
                                        )</a>
                                </th>
                                <th>
                                    <a href="TaskListOnGoing.aspx?status=Completed">Completed (<asp:Label ID="lblCompletedTask" runat="server"></asp:Label>
                                        )</a>
                                </th>
                                <th><a href="TaskListOnGoing.aspx">Total Open</a>
                                </th>
                                <th><a href="TaskListClosed.aspx">Closed</a>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrUsers" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <%# Eval("Name")%> (<%# Eval("UCode")%>)
                                        </td>
                                        <%--<td>
                                            <%# Eval("TotalCount")%>
                                        </td>--%>
                                        <td>
                                            <span style='<%# Eval("OnDuty").ToString() == "No" ? "background-color:yellow;": "background-color:#00FF00;" %>'><%# Eval("OnDuty")%></a></span>
                                        </td>
                                        <td>
                                            <span style='background-color: yellow; <%# Eval("Present").ToString().ToUpper() == "YES" ? "display:none;": "" %>'>No</span>
                                            <a style='background-color: #00FF00; <%# Eval("Present").ToString().ToUpper() == "NO" ? "display:none;": "" %>' href="UserMap.aspx?ucode=<%# Eval("UCode")  %>">Yes</a>

                                        </td>
                                        <td>
                                            <a href='<%# "TaskListOnGoing.aspx?status=Pending&ucode="+ Eval("UCode") %>' style='<%# Eval("PendingCount").ToString().ToUpper() == "0" ? "display:none;": "" %>'><%# Eval("PendingCount") %></a>
                                            <span style='<%# Eval("PendingCount").ToString().ToUpper() != "0" ? "display:none;": "" %>'>0</span>
                                        </td>
                                        <td>
                                            <a href='<%# "TaskListOnGoing.aspx?status=Reply&ucode="+ Eval("UCode") %>' style='<%# Eval("ReplyCount").ToString().ToUpper() == "0" ? "display:none;": "" %>'><%# Eval("ReplyCount") %></a>
                                            <span style='<%# Eval("ReplyCount").ToString().ToUpper() != "0" ? "display:none;": "" %>'>0</span>
                                        </td>
                                        <td>
                                            <a href='<%# "TaskListOnGoing.aspx?status=Completed&ucode="+ Eval("UCode") %>' style='<%# Eval("CompletedCount").ToString().ToUpper() == "0" ? "display:none;": "" %>'><%# Eval("CompletedCount") %></a>
                                            <span style='<%# Eval("CompletedCount").ToString().ToUpper() != "0" ? "display:none;": "" %>'>0</span>
                                        </td>
                                        <td><a href='<%# "TaskListOnGoing.aspx?ucode="+ Eval("UCode") %>' style='<%# Eval("TotalCount").ToString().ToUpper() == "0" ? "display:none;": "" %>'><%# Eval("TotalCount")%></a>
                                            <span style='<%# Eval("TotalCount").ToString().ToUpper() != "0" ? "display:none;": "" %>'>0</span>
                                        </td>
                                        <td>
                                            <a href='<%# "TaskListClosed.aspx?ucode="+ Eval("UCode") %>'>View</a>
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

