<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listele.ascx.cs" Inherits="PL.management.anaYonetim.kullaniciYonetimi.listele1" %>
<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Kullanıcılar
            <small>kullanıcılar burada listelenir.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Tables</a></li>
            <li class="active">Data tables</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">

        <script type="text/javascript">
            function Confirm() {
                alert("dsfasdf");
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Silmek üzeresiniz !")) {
                    confirm_value.value = "Devam Et";
                } else {
                    confirm_value.value = "Vazgeç";
                }
                document.forms[0].appendChild(confirm_value);
            }
        </script>
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Kullanıcı Listesi</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Kullanıcı No</th>
                                    <th>Ad Soyad</th>
                                    <th>Email</th>
                                    <th>Son Giriş Tarihi</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="kullaniciRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("kullaniciId") %></td>
                                            <td><%# Eval("kullaniciAdSoyad") %></td>
                                            <td><%# Eval("email") %></td>
                                            <td><%# Eval("sonGirisTarihi","{0:dd.MM.yyyy}") %></td>
                                            <td>
                                                <asp:HyperLink ID="detay" NavigateUrl='<%# Eval("kullaniciId","~/satici-profil.aspx?user={0}") %>' CssClass="btn btn-primary btn-xs" runat="server">Görüntüle</asp:HyperLink>
                                                <asp:HyperLink ID="duzenle" NavigateUrl='<%# Eval("kullaniciId","~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=duzenle&user={0}") %>' CssClass="btn btn-warning btn-xs" runat="server">Düzenle</asp:HyperLink>
                                                <asp:HyperLink ID="sil" NavigateUrl='<%# Eval("kullaniciId","~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele&user={0}") %>' CssClass="btn btn-danger btn-xs" runat="server">Sil</asp:HyperLink>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Kullanıcı No</th>
                                    <th>Ad Soyad</th>
                                    <th>Email</th>
                                    <th>Yetki</th>
                                    <th>Son Giriş Tarihi</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->
