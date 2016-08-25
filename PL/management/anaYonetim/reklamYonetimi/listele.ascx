<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listele.ascx.cs" Inherits="PL.management.anaYonetim.reklamYonetimi.listele" %>

<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Reklam İlanlar
            <small>tüm reklamlar burada listelenir.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Tables</a></li>
            <li class="active">Data tables</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Reklam Listesi</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Reklam No</th>
                                    <th>Kullanıcı Adı</th>
                                    <th>Reklam Adı</th>
                                    <th>Reklam Türü</th>
                                    <th>Reklam Konumu</th>
                                    <th>Reklam İli</th>
                                    <th>Başlangıç Tarihi</th>
                                    <th>Bitiş Tarihi</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="reklamRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("verilenReklamId") %></td>
                                            <td><%# Eval("kullaniciAdSoyad") %></td>
                                            <td><%# Eval("reklamAdi") %></td>
                                            <td><%# turDondur(Convert.ToInt32(Eval("reklamTurId"))) %></td>
                                            <td><%# konumDondur(Convert.ToInt32(Eval("reklamKonumuId"))) %></td>
                                            <td><%# ilDondur(Eval("ilId")) %></td>
                                            <td><%# Eval("baslangicTarihi","{0:dd.MM.yyyy}") %></td>
                                            <td><%# Eval("bitisTarihi","{0:dd.MM.yyyy}") %></td>
                                            <td>

                                                <asp:HyperLink ID="onay" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip={0}&advertisement={1}", tip ,Eval("verilenReklamId"))%>'
                                                    Visible='<%#tip=="1"?true:false %> '>Onay</asp:HyperLink>
                                                <asp:HyperLink ID="duzenle" runat="server" CssClass="btn btn-primary btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=duzenle&advertisement={0}" ,Eval("verilenReklamId"))%>'>Düzenle</asp:HyperLink>
                                                <asp:HyperLink ID="aktif" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip={0}&advertisement={1}", tip ,Eval("verilenReklamId"))%>'
                                                    Visible='<%#tip=="3"?true:false %> '>Aktifleştir</asp:HyperLink>
                                                <asp:HyperLink ID="pasif" runat="server" CssClass="btn btn-warning btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip={0}&advertisement={1}", tip ,Eval("verilenReklamId"))%>'
                                                    Visible='<%#tip=="2"?true:false %> '>Pasifleştir</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Reklam No</th>
                                    <th>Kullanıcı Adı</th>
                                    <th>Reklam Adı</th>
                                    <th>Reklam Türü</th>
                                    <th>Reklam Konumu</th>
                                    <th>Reklam İli</th>
                                    <th>Başlangıç Tarihi</th>
                                    <th>Bitiş Tarihi</th>
                                    <th>İşlemler</th>
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

<script>
    $(function () {
        $("#example1").DataTable();
        $('#example2').DataTable({
            "paging": true,
            "lengthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false
        });
    });
</script>
