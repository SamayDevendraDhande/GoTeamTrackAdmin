<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="UserTaskDetail.aspx.cs" Inherits="UserTaskDetail" %>

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
                                        <asp:Label CssClass="m-wrap" ID="lblCreateDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Task</label>
                                    <div class="controls">
                                        <asp:Label CssClass="m-wrap" ID="lblTask" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Status</label>
                                    <div class="controls">
                                        <asp:Label CssClass="m-wrap" ID="lblStatus" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Target Date</label>
                                    <div class="controls">
                                        <asp:Label CssClass="m-wrap" ID="lblTargetDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks</label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="m-wrap" ID="txtRemarks" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Remarks Date</label>
                                    <div class="controls">
                                        <asp:Label CssClass="m-wrap" ID="lblRemarksDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </fieldset>

                        <div class="form-actions">
                                <asp:LinkButton ID="lnkBtnCompleted" runat="server" class="btn btn-primary green"
                                    OnCommand="btnCompleted_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Completed"></asp:LinkButton>
                                <asp:LinkButton ID="lnkBtnReply" runat="server" class="btn btn-primary blue"
                                    OnCommand="btnReply_Command" Style="width: 100px;" CommandArgument=''
                                    Text="Reply"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

