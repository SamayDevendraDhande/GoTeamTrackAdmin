<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TaskListClosed.aspx.cs" Inherits="TaskListClosed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dvMap {
            width: 100%;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3><asp:Label ID="lblClosedTitle" runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="portlet-body">
                    <table class="datatable1 table table-bordered table-hover">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>Task
                                </th>
                                <th>Status
                                </th>
                                <th>User</th>
                                <th>Create Date</th>
                                <th>Target Date</th>
                                <th>Remarks</th>
                                <th>RemarksDate</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrTaskOngoing" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <%# Eval("Task")%>
                                        </td>
                                        <td>
                                            <%# Eval("Status")%>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%> (<%# Eval("UCode")%>)
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
                                        <td>
                                            <asp:LinkButton ID="btnPending" runat="server" class="btn btn-primary green-stripe tbl-link"
                                                OnCommand="btnPending_Command" CommandArgument='<%# Eval("Timestamp")%>'
                                                Text="Pending"></asp:LinkButton>
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

