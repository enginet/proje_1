<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listele.ascx.cs" Inherits="PL.management.anaYonetim.magazaYonetimi.listele" %>
<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Mağazalar
            <small>tüm mağazalar burada listelenir.</small>
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
                        <h3 class="box-title">Mağaza Listesi</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Mağaza No</th>
                                    <th>Adı</th>
                                    <th>Türü</th>
                                    <th>Paket Adı</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="magazaRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("magazaId") %></td>
                                            <td><%#Eval("magazaAdi") %></td>
                                            <td><%#Eval("kategoriAdi") %></td>
                                            <td><%#Paket_Goster(Eval("magazaPaketId")) %></td>
                                            <td>
                                                <asp:HyperLink ID="onay" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=listele&proc={0}&store={1}", proc ,Eval("magazaId"))%>'
                                                    Visible='<%#proc=="3"?true:false %> '>Onay</asp:HyperLink>
                                                <asp:HyperLink ID="aktif" runat="server" CssClass="btn btn-success btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=listele&proc={0}&store={1}", proc ,Eval("magazaId"))%>'
                                                    Visible='<%#proc=="2"?true:false %> '>Aktifleştir</asp:HyperLink>
                                                <asp:HyperLink ID="pasif" runat="server" CssClass="btn btn-warning btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=listele&proc={0}&store={1}", proc ,Eval("magazaId"))%>'
                                                    Visible='<%#proc=="1"?true:false %> '>Pasifleştir</asp:HyperLink>
                                                <asp:HyperLink ID="hypGoruntule" runat="server" CssClass="btn btn-primary btn-xs" NavigateUrl='<%# Eval("magazaId","~/magaza.aspx?page=duzenle&magazaId={0}") %>'>Görüntüle</asp:HyperLink>
                                                <asp:HyperLink ID="hypDuzenle" runat="server" CssClass="btn btn-warning btn-xs" NavigateUrl='<%# Eval("magazaId","~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=duzenle&magazaId={0}") %>'>Düzenle</asp:HyperLink>
                                                <asp:HyperLink ID="hypSil" runat="server" CssClass="btn btn-danger btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=listele&proc={0}&store={1}&rem={2}", proc ,Eval("magazaId"), 4) %>'>Sil</asp:HyperLink>
                                                <asp:HyperLink ID="hypKullanici" runat="server" CssClass="btn btn-primary btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=kullanici-listele&magazaId={0}&how={1}", Eval("magazaId"),1) %>'>Kullanıcıları Görüntüle</asp:HyperLink>
                                                <asp:HyperLink ID="hypTakipci" runat="server" CssClass="btn btn-danger btn-xs" NavigateUrl='<%# String.Format("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=kullanici-listele&magazaId={0}&how={1}", Eval("magazaId"),2) %>'>Takipçileri Görüntüle</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Mağaza No</th>
                                    <th>Adı</th>
                                    <th>Türü</th>
                                    <th>Paket Adı</th>
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
