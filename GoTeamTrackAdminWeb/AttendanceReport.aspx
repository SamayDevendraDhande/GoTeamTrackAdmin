<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="AttendanceReport" %>

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
                                        Year</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlYear" CssClass="chosen" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Full Day hrs</label>
                                    <div class="controls">
                                        <asp:TextBox class="span12 m-wrap" ID="txtFullDayHrs" runat="server"></asp:TextBox>
                                        <asp:RangeValidator runat="server" ErrorMessage="Invalid Time. It must be between 1.0 to 24.00" ControlToValidate="txtFullDayHrs"
                                            ValidationGroup ="btnSearch" MinimumValue="1.00" MaximumValue="24.00" Type="Double" Display="Dynamic" ></asp:RangeValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="txtFullDayHrs" ValidationGroup="btnSearch"
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" class="icon icon-color icon-close"
                                            SetFocusOnError="true" Display="Dynamic" Style="color: red;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">
                                        Month</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlMonth" CssClass="chosen" runat="server">
                                            <asp:ListItem Text="January" Value="01" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                            <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                            <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                            <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                            <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Half day hrs</label>
                                    <div class="controls">
                                        <asp:TextBox class="span12 m-wrap" ID="txtHalfDayHrs" runat="server"></asp:TextBox>
                                        <asp:RangeValidator runat="server" ErrorMessage="Invalid Time. It must be between 1.0 to 24.00" ControlToValidate="txtHalfDayHrs"
                                            ValidationGroup ="btnSearch" MinimumValue="1.00" MaximumValue="24.00" Type="Double" Display="Dynamic" ></asp:RangeValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="txtHalfDayHrs" ValidationGroup="btnSearch"
                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" class="icon icon-color icon-close"
                                            SetFocusOnError="true" Display="Dynamic" Style="color: red;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-actions">
                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" ValidationGroup="btnSearch" runat="server" class="btn btn-primary"
                                Text="Show" />
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="datatable1 table table-bordered table-hover">
                        <%--datatable1WithFilter--%>
                        <thead>
                            <tr>
                                <th>User ame
                                </th>
                                <th>User Code
                                </th>
                                <th>Full Days
                                </th>
                                <th>Half Days
                                </th>
                                <th>Other Days
                                </th>
                                <th>Date Time
                                </th>
                                <th>Duty Status
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptrUsersAttendance" runat="server">
                                <itemtemplate>
                                    <tr class="odd gradeX">
                                        
                                        <td>
                                            <%# Eval("UserName")%>
                                        </td>
                                        <td>
                                            <%# Eval("UCode")%>
                                        </td>
                                        <td>
                                            <%# Eval("FullDaysCount")%>
                                        </td>
                                        <td>
                                            <%# Eval("HalfDaysCount")%>
                                        </td>
                                        <td>
                                            <%# Eval("OtherDaysCount")%>
                                        </td>
                                        <td>
                                            <%--<a href="UserMap.aspx?ucode=<%# Eval("UCode")  %>&Date=<%# Eval("DutyTime","{0:dd-MM-yyyy}")  %>">
                                                <%# Eval("DutyTime")%></a>--%>
                                            <%# Eval("DutyTime")%>
                                        </td>
                                        <td>
                                            <%# Eval("DutyStatus")%>
                                        </td>
                                    </tr>
                                </itemtemplate>
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

