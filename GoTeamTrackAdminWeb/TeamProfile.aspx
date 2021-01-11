<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="TeamProfile.aspx.cs" Inherits="TeamProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>Team Profile
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
                                        <asp:TextBox CssClass="m-wrap" Enabled="false" ID="txtTeamCode" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Team Name</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" Enabled="false" ID="txtTeamName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Active</label>
                                    <div class="controls">
                                        <asp:CheckBox CssClass="m-wrap" Enabled="false" ID="chkActive" Checked="true" runat="server"></asp:CheckBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Start Date
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap span4 date-picker" Enabled="false" autocomplete="off" ID="txtStartDate"
                                            placeholder="DD-MM-YYYY HH:MM:SS" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        End Date
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap span4 date-picker" Enabled="false" autocomplete="off" ID="txtEndDate"
                                            placeholder="DD-MM-YYYY HH:MM:SS" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Max Users</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" Enabled="false" ID="txtMaxUsers" runat="server"></asp:TextBox>
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

