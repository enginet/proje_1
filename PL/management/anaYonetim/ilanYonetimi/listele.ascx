<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listele.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.listele" %>
<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>İlanlar
            <small>tüm ilanlar burada listelenir.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Tables</a></li>
            <li class="active">Data tables</li>
        </ol>
    </section>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Sil ?")) {
                confirm_value.value = "Evet";
            } else {
                confirm_value.value = "Hayır";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">İlanlar Listesi</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>İlan No</th>
                                    <th>İl</th>
                                    <th>Fiyat</th>
                                    <th>Kayıt Tarihi</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="ilanRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ilanId") %></td>
                                            <td><%# Eval("ilAdi") %></td>
                                            <td><%# Eval("fiyat") %>
                                            </td>
                                            <td><%# Eval("baslangicTarihi","{0:dd MMMM yyyy}") %></td>
                                            <td id="islemler">
                                                <asp:HyperLink ID="onay" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}&proc={2}", tip ,Eval("ilanId"),1)%>'
                                                    Visible='<%#(tip=="1"||tip=="10") ?true:false %> '>Onay</asp:HyperLink>
                                                <asp:HyperLink ID="onaylama" runat="server" CssClass="btn btn-danger btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}&proc={2}", tip ,Eval("ilanId") ,2)%>'
                                                    Visible='<%#tip=="1"?true:false %> '>Onaylama</asp:HyperLink>
                                                <asp:HyperLink ID="goruntule" runat="server" CssClass="btn btn-primary btn-xs"  NavigateUrl='<%# String.Format("~/ilan-detay.aspx?{0}&ilan={1}", DAL.toolkit.UrlDonustur(Eval("baslik")),Eval("ilanId")) %>'>Görüntüle</asp:HyperLink>
                                                <asp:HyperLink ID="duzenle" runat="server" CssClass="btn btn-info btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=duzenle&ilan={0}" ,Eval("ilanId"))%>'>Düzenle</asp:HyperLink>

                                                <asp:HyperLink ID="kaldir" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}", tip ,Eval("ilanId"))%>'
                                                    Visible='<%#tip=="4"?true:false %> '>Şikayeti Kaldır</asp:HyperLink>

                                                <asp:HyperLink ID="pasif" runat="server" CssClass="btn btn-warning btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}", tip ,Eval("ilanId"))%>'
                                                    Visible='<%#tip=="2"?true:false %> '>Pasifleştir</asp:HyperLink>

                                                <asp:HyperLink ID="aktif" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}", tip ,Eval("ilanId"))%>'
                                                    Visible='<%#tip=="3"?true:false %> '>Aktifleştir</asp:HyperLink>

                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/ilanYonetimi/ilan.aspx?page=listele&tip={0}&cla={1}&proc=sil", tip ,Eval("ilanId"))%>'>Sil</asp:HyperLink>


                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>İlan No</th>
                                    <th>Başlık</th>
                                    <th>Kategori</th>
                                    <th>Fiyat</th>
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

