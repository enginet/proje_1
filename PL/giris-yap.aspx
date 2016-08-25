<%@ Page Title="Giriş Yap" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="giris-yap.aspx.cs" Inherits="PL.giris_yap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- include form-validation plugin || add this script where you need validation   -->
    <script src="libraries/assets/js/form-validation.js"></script>

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
                                    class="icon icon-docs ln-shadow-logo shape-0"></i></span>BOOT<span>CLASSIFIED </span>
                            </h2>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <div class="form-group">
                                    <label for="sender-email" class="control-label">E-posta Adresiniz</label>

                                    <div class="input-icon">
                                        <i class="icon-user fa"></i>

                                        <input id="txtMail" type="text" runat="server" placeholder="Email yada Cep Telefonu"
                                            class="form-control email" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="user-pass" class="control-label">Şifreniz</label>

                                    <div class="input-icon">
                                        <i class="icon-lock fa"></i>
                                        <input type="password" class="form-control" runat="server" placeholder="Şifre"
                                            id="txtSifre" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Button1" CssClass="btn btn-primary  btn-block" runat="server" OnClick="Giris_Click" Text="Giriş Yap" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">

                            <div class="checkbox pull-left">
                                <label>

                                    <asp:CheckBox ID="chcBeniHatirla" type="checkbox" runat="server" AutoPostBack="true" OnCheckedChanged="chcBeniHatirla_CheckedChanged" />
                                    Beni Hatırla</label>
                            </div>
                            <p class="text-center pull-right">
                                <asp:HyperLink ID="hypGiris" runat="server" NavigateUrl="~/sifremi-unuttum.aspx"> Şifremi Unuttum</asp:HyperLink>
                            </p>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="login-box-btm text-center">
                        <p>
                            Üye değil misiniz?
                            <br>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/uye-ol.aspx"><strong>Hemen Üye Ol</strong></asp:HyperLink>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.main-container -->

</asp:Content>
