﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="yeni-sifre.aspx.cs" Inherits="PL.yeni_sifre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-5 login-box">
                    <div class="panel panel-default">
                        <div class="panel-intro text-center">
                            <h2 class="logo-title">
                                <!-- Original Logo will be placed here  -->
                                <span class="logo-icon"><i
                                    class="icon icon-search-1 ln-shadow-logo shape-0"></i></span>BOOT<span>CLASSIFIED </span>
                            </h2>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <div class="form-group">
                                    <label for="sender-email" class="control-label">Yeni Şifre</label>
                                    <div class="input-icon">
                                        <i class="icon-user fa"></i>
                                        <input id="txtSifre" type="password" runat="server"
                                            class="form-control email" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Gonder" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Devam" OnClick="Gonder_Click"/>
                                 <%--   <button type="submit" class="btn btn-primary btn-lg btn-block">
                                        Yeni Şifre Oluştur
                                    </button>--%>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <p class="text-center ">
                                <asp:HyperLink ID="hypAna" runat="server" NavigateUrl="~/default.aspx"><strong>Ana Sayfaya git</strong></asp:HyperLink>
                            </p>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="login-box-btm text-center">
                        <p>
                            Üye değil misiniz?
                            <br>
                            <asp:HyperLink ID="hypUyeOl" runat="server" NavigateUrl="~/uye-ol.aspx"><strong>Hemen Üye Ol</strong></asp:HyperLink>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
