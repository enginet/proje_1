<%@ Page Title="Üye Ol" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="uye-ol.aspx.cs" Inherits="PL.uye_ol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>' />

    <style>
        .checkbox label{
            padding-left:0.5em !important;
        }
    </style>
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-md-8 page-content">
                    <div class="inner-box category-content">
                        <h2 class="title-2"><i class="icon-user-add"></i>Üye Ol</h2>

                        <div class="row">
                            <div class="col-sm-12">
                                <fieldset runat="server" id="uyelikField">

                                    <!-- Text input-->
                                    <div class="form-group required">
                                        <label class="control-label">Adınız <sup>*</sup></label>
                                        <asp:TextBox ID="txtAd" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    </div>

                                    <!-- Text input-->
                                    <div class="form-group required">
                                        <label class="control-label">Soyadınız <sup>*</sup></label>
                                        <asp:TextBox ID="txtSoyad" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Cep Telefonunuz</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <i class="fa fa-phone"></i>
                                            </div>
                                            <asp:TextBox ID="txtTlf" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                        </div>
                                        <!-- /.input group -->
                                    </div>

                                    <div class="form-group required">
                                        <label for="inputEmail3" class="control-label">Email<sup>*</sup></label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    </div>
                                    <div class="form-group required">
                                        <label for="inputPassword3" class="control-label">Şifre<sup>*</sup> </label>
                                        <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" CssClass="form-control input-md"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <div class="checkbox icheck">
                                            <asp:CheckBox ID="uyelikSozlesme" type="checkbox" Text="Üyelik Sözleşmesini Okudum ve Kabul ediyorum" runat="server" />
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                    <asp:Button ID="UyeOl" class="btn btn-primary" runat="server" Text="Üye Ol" OnClick="UyeOl_Click" style="margin:20px 0;"/>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.page-content -->

                <div class="col-md-4 reg-sidebar">
                    <div class="reg-sidebar-inner text-center">
                        <div class="promo-text-box">
                            <i class=" icon-picture fa fa-4x icon-color-1"></i>

                            <h3><strong>Ücretsiz ilan ver</strong></h3>

                            <p>
                                Post your free online classified ads with us. Lorem ipsum dolor sit amet, consectetur
                                adipiscing elit.
                            </p>
                        </div>
                        <div class="promo-text-box">
                            <i class=" icon-pencil-circled fa fa-4x icon-color-2"></i>

                            <h3><strong>İlan oluştur ve yönet</strong></h3>

                            <p>
                                Nam sit amet dui vel orci venenatis ullamcorper eget in lacus.
                                Praesent tristique elit pharetra magna efficitur laoreet.
                            </p>
                        </div>
                        <div class="promo-text-box">
                            <i class="  icon-heart-2 fa fa-4x icon-color-3"></i>

                            <h3><strong>İlanların favori listelere alınsın</strong></h3>
                            <p>
                                PostNullam quis orci ut ipsum mollis malesuada varius eget metus.
                                Nulla aliquet dui sed quam iaculis, ut finibus massa tincidunt.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </div>

    <script src="management/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="management/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="management/plugins/input-mask/jquery.inputmask.extensions.js"></script>


    <script>
        $(function () {

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();
        });
    </script>


    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>

</asp:Content>
