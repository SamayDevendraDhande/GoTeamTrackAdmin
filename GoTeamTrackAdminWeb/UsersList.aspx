<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>User List&nbsp;
                    </h3>
                    <a href="UserDetails.aspx" class="btn btn-primary blue">Add New User</a>
                </div>
                <div class="portlet-body">
                    <table class="datatable1WithFilter table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>User Code
                                </th>
                                <th>Name
                                </th>
                                <th>Email
                                </th>
                                <th>Active
                                </th>
                                <th>Remarks
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrUsers" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <a href="UserDetails.aspx?UCode=<%# Eval("UCode")%>">
                                                <%# Eval("UCode")%></a>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Email")%>
                                        </td>
                                        <td>
                                            <%# Eval("IsActive")%>
                                        </td>
                                        <td>
                                            <%# Eval("Remarks")%>
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

