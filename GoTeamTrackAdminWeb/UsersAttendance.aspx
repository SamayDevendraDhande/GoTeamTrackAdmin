<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="UsersAttendance.aspx.cs" Inherits="UsersAttendance" %>

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
                    <h3>Attendance Report
                    </h3>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal" style="display: block">
                        <fieldset>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">
                                        User</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlMember" CssClass="chosen" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="requirefield1" runat="server" InitialValue="0" ControlToValidate="ddlMember" ErrorMessage="Required">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-actions">
                            <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" class="btn btn-primary"
                                Text="Show" />
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="datatable1 table table-bordered table-hover">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>Date Time
                                </th>
                                <th>Duty Status
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrUsersAttendance" runat="server">
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <a href="UserMap.aspx?ucode=<%# Eval("UCode")  %>&Date=<%# Eval("DutyTime","{0:dd-MM-yyyy}")  %>">
                                                <%# Eval("DutyTime")%></a>
                                        </td>
                                        <td>
                                            <%# Eval("DutyStatus")%>
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

