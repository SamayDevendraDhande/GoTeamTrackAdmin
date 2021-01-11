<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TaskEdit.aspx.cs" Inherits="TaskEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>Task Edit
                    </h3>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">
                                        Create Date</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap date-picker" ID="txtCreateDate" Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Task</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtTask" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator1"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtTask"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Target Date</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap date-picker" ID="txtTargetDate" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        User</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlUser" CssClass="chosen" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Status</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlStatus" CssClass="chosen" runat="server">
                                            <asp:ListItem Text="Unallocated" Value="Unallocated"></asp:ListItem>
                                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                            <asp:ListItem Text="Reply" Value="Reply"></asp:ListItem>
                                            <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtRemarks" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks Date</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap date-picker" ID="txtRemarksDate" Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </fieldset>

                        <div class="form-actions">
                            <asp:Button ID="btnSave" ValidationGroup="btnSave" runat="server" class="btn btn-primary blue"
                                OnClick="btnSave_Click" Text="Save" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary red"
                                    OnCommand="btnUnallocated_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Unallocated"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary blue"
                                    OnCommand="btnPending_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Pending"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary green"
                                    OnCommand="btnCompleted_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Completed"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary grey"
                                    OnCommand="btnClosed_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Closed"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

