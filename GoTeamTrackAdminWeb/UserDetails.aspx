<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>User Details
                    </h3>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">
                                        User Code</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtUserCode" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator1"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtUserCode"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Password</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtPassword" runat="server" autocomplete="new-password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldtxtPassword"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtPassword"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Name</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator class="icon icon-color icon-close" ID="RequiredFieldValidator2"
                                            runat="server" SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtName"
                                            EnableClientScript="true" Display="Dynamic" ValidationGroup="btnSave">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Email</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtEmail" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtRemarks" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Active</label>
                                        <div class="controls">
                                            <asp:CheckBox CssClass="m-wrap" ID="chkActive" Checked="true" runat="server"></asp:CheckBox>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnSave" ValidationGroup="btnSave" runat="server" class="btn btn-primary blue"
                                            OnClick="btnSave_Click" Text="Save" />
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnInOut" runat="server" Visible="false" class="btn btn-primary blue"
                                            OnClick="btnInOut_Click" OnClientClick="skipLoader=1;" Text="Download In Out Log" />
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnLocationLog" runat="server" Visible="false" class="btn btn-primary blue"
                                            OnClick="btnLocationLog_Click" OnClientClick="skipLoader=1;" Text="Download Location Log" />
                                    </div>
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

