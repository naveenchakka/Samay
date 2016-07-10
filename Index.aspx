<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Aspfiles_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div class="content container">
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-title">Welcome Context </h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="widget widget-nopad">
                    <div class="widget-header">
                        <i class="icon-list-alt"></i>
                        <h3>User Profile</h3>
                    </div>
                    <!-- /widget-header -->
                    <div class="widget-content">
                        <div class="widget big-stats-container">
                            <div class="form-horizontal">
                                <div class="col-lg-12" style="height: 210px !important;">
                                    <fieldset>
                                        <div class="control-group2">
                                            <span class="control-label">Username -</span>
                                            <span class="userProfile">
                                                <strong>
                                                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></strong>
                                            </span>
                                        </div>
                                        <div class="control-group2">
                                            <span class="control-label">Mobile &nbsp;-</span>
                                            <span class="userProfile">
                                                <strong>
                                                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></strong>
                                            </span>
                                        </div>
                                        <div class="control-group2">
                                            <span class="control-label">Email &nbsp;-</span>
                                            <span class="userProfile">
                                                <strong><a href="">
                                                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></a></strong>
                                            </span>
                                        </div>
                                        <div class="control-group2">
                                            <span class="control-label">Last Login &nbsp;-</span>
                                            <span class="userProfile">
                                                <strong>
                                                    <asp:Label ID="lblLastLogin" runat="server" Text=""></asp:Label></strong>
                                            </span>
                                        </div>
                                    </fieldset>
                                </div>
                                <!-- Clm1 end -->
                            </div>
                            <!-- /widget-content -->
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="widget">
                    <div class="widget-header">
                        <i class="icon-bookmark"></i>
                        <h3>Important Shortcuts</h3>
                    </div>
                    <!-- /widget-header -->
                    <div class="widget-content">
                        <div class="shortcuts">
                            <a class="shortcut" href="send-single-sms.aspx"><i class="shortcut-icon icon-comment"></i><span class="shortcut-label">Send Single SMS</span> </a>
                            <a class="shortcut" href="send-bulk-sms.aspx"><i class="shortcut-icon icon-comments"></i><span class="shortcut-label">Send Bulk SMS</span> </a>
                            <a class="shortcut" href="Sent-history.aspx"><i class="shortcut-icon icon-time"></i><span class="shortcut-label">Sent History</span> </a>
                            <%--<a class="shortcut" href="javascript:;"> <i class="shortcut-icon icon-user"></i><span class="shortcut-label">User Accounts</span> </a>--%>
                            <a class="shortcut" href="Credits-history.aspx"><i class="shortcut-icon icon-credit-card"></i><span class="shortcut-label">Credit History</span> </a>
                            <a class="shortcut" href="Sender-id.aspx"><i class="shortcut-icon icon-th-list"></i><span class="shortcut-label">Sender Id</span> </a>
                            <a class="shortcut" href="Templates.aspx"><i class="shortcut-icon icon-picture"></i><span class="shortcut-label">Templates</span> </a>
                            <a class="shortcut" href="Ac-settings.aspx"><i class="shortcut-icon icon-cogs"></i><span class="shortcut-label">A/C Settings</span> </a>
                        </div>
                        <!-- /shortcuts -->
                    </div>
                    <!-- /widget-content -->
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="widget widget-nopad">
                    <div class="widget-header">
                        <i class="icon-list-alt"></i>
                        <h3>Account Information</h3>
                    </div>
                    <!-- /widget-header -->
                    <div class="widget-content">
                        <div class="widget big-stats-container">
                            <div class="form-horizontal">
                                <div class="col-lg-12" style="height: 220px !important;">
                                    <fieldset>
                                        <div class="control-group2">
                                            <span class="control-label">Credits -</span>
                                            <span class="userProfile">
                                                <strong><asp:Label ID="lblCredits" runat="server" Text="Label"></asp:Label></strong>
                                            </span>
                                        </div>
                                        <div class="control-group2">
                                            <span class="control-label">Account Type &nbsp;-</span>
                                            <span class="userProfile">
                                                <strong><asp:Label ID="lblTransaction" runat="server" Text="Label"></asp:Label></strong>
                                            </span>
                                        </div>
                                    </fieldset>
                                </div>
                                <!-- Clm1 end -->
                            </div>
                        </div>
                        <!-- /widget-content -->
                    </div>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>

