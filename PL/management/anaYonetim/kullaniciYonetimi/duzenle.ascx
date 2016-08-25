<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="duzenle.ascx.cs" Inherits="PL.management.anaYonetim.kullaniciYonetimi.duzenle" %>

<link rel="stylesheet" href="../../plugins/select2/select2.min.css">
<link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>'>
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Kullanıcı Düzenle
            <small>buradan kullanıcı düzenleyebilirsiniz.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">General Elements</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Bana özel</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <li>
                                <asp:HyperLink NavigateUrl="~/management/araclar/araclar.aspx?page=gelenkutusu" runat="server"><i class="fa fa-inbox"></i>Gelen Kutusu </asp:HyperLink></li>
                            <li>
                                <asp:HyperLink NavigateUrl="~/management/araclar/araclar.aspx?page=gonderilen-kutusu" runat="server"><i class="fa fa-envelope-o"></i>Gönderilen Kutusu</asp:HyperLink></li>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /. box -->
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Online Kullanıcılar</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <asp:Repeater ID="onlineRepeater" runat="server">
                                <ItemTemplate>
                                    <li><a href="#"><i class="fa fa-circle text-success"></i><%# Eval("kullaniciAdSoyad") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- left column -->
            <div class="col-md-9">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Kullanıcı Bilgileri</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div>
                                <div class="form-group">
                                    <label for="ad">Ad</label>
                                    <asp:TextBox ID="txtAd" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="soyad">Soyad</label>
                                    <asp:TextBox ID="txtSoyad" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="sifre">Şifre</label>
                                    <asp:TextBox ID="txtSifre" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="mail">Email</label>
                                    <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label>İl</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>İlçe</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged">
                                                <asp:ListItem Value="null">İlçe Seçiniz</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Mahalle</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server">
                                                <asp:ListItem Value="null">Mahalle Seçiniz</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="form-group">
                                    <label for="kredi">
                                        Kredi Sayısı
                                    </label>
                                    <asp:TextBox ID="txtKrediSayi" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="tcNo">TC Kimlik No</label>
                                    <asp:TextBox ID="txtKimlikNo" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Eğitim Durumu</label>
                                    <asp:DropDownList ID="drpEgitim" class="form-control select2" runat="server">
                                        <asp:ListItem Value="1">Üniversite</asp:ListItem>
                                        <asp:ListItem Value="2">Yüksek Okul</asp:ListItem>
                                        <asp:ListItem Value="3">Lise</asp:ListItem>
                                        <asp:ListItem Value="4">Ortaokul</asp:ListItem>
                                        <asp:ListItem Value="5">İlkokul</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- radio -->
                                <label>
                                    Cinsiyet
                                </label>
                                <div class="form-group">
                                    <asp:RadioButtonList ID="rdCinsiyet" runat="server" RepeatDirection="Horizontal" Height="27px" Width="363px">
                                        <asp:ListItem Value="True">Erkek</asp:ListItem>
                                        <asp:ListItem Value="False">Kadın</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>GSM</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtGsm1" runat="server" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask></asp:TextBox>
                                    </div>
                                </div>
                                <%--                                <div class="form-group">
                                    <label>GSM-2</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtGsm2" runat="server" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="form-group">
                                    <label>Sabit Telefon</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtSabit" runat="server" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Yetkisi</label>
                                    <asp:DropDownList ID="drpYetki" runat="server" class="form-control select2">
                                        <asp:ListItem Value="1">Yönetici</asp:ListItem>
                                        <asp:ListItem Value="2">Admin</asp:ListItem>
                                        <asp:ListItem Value="3">Editör</asp:ListItem>
                                        <asp:ListItem Value="4">Üye</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <asp:Button ID="Kaydet" class="btn btn-success" runat="server" OnClick="Kaydet_Click" Text="Kaydet" />
                            <asp:Button ID="Vazgec" class="btn btn-danger" runat="server" OnClick="Vazgec_Click" Text="Vazgeç" />
                        </div>
                    </div>
                </div>
                <!-- /.box -->
            </div>
            <!--/.col (left) -->
            <!-- right column -->
            <!--/.col (right) -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->

<script src="../../plugins/select2/select2.full.min.js"></script>
<!-- InputMask -->
<script src="../../plugins/input-mask/jquery.inputmask.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.extensions.js"></script>

<script>

    $(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            //Initialize Select2 Elements
            $(".select2").select2();

        });

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
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    });
</script>
