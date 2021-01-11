<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TaskNew.aspx.cs" Inherits="TaskNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>New task
                    </h3>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span12">
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

                            </div>
                        </fieldset>

                        <div class="form-actions">
                            <asp:Button ID="btnSave" ValidationGroup="btnSave" runat="server" class="btn btn-primary blue"
                                OnClick="btnSave_Click" Text="Save" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

