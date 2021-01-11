<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TeamNew.aspx.cs" Inherits="TeamNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>Add New Team
                    </h3>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">
                                        Team Code</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtTeamCode" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator3"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtTeamCode"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Password</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtPassword" runat="server" autocomplete="new-password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator5"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtPassword"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Team Name</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtTeamName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator2"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtTeamName"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Active</label>
                                    <div class="controls">
                                        <asp:CheckBox CssClass="m-wrap" ID="chkActive" Checked="true" runat="server"></asp:CheckBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Start Date
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap span4 date-picker" autocomplete="off" ID="txtStartDate"
                                            placeholder="DD-MM-YYYY HH:MM:SS" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator1"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtStartDate"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        End Date
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap span4 date-picker" autocomplete="off" ID="txtEndDate"
                                            placeholder="DD-MM-YYYY HH:MM:SS" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator6"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtEndDate"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtRemarks" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator7"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtRemarks"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Max Users</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtMaxUsers" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator4"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtMaxUsers"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator"
                                            Type="Integer" MinimumValue="1" MaximumValue="100" ControlToValidate="txtMaxUsers"
                                            ValidationGroup="btnSave"></asp:RangeValidator>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnSave" ValidationGroup="btnSave" runat="server" class="btn btn-primary blue"
                                        OnClick="btnSave_Click" Text="Save" />
                                    
                                    <asp:Button ID="Button1" ValidationGroup="Button1" runat="server" class="btn btn-primary blue"
                                        OnClick="Button1_Click" Text="TEST1" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

