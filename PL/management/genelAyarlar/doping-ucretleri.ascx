<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="doping-ucretleri.ascx.cs" Inherits="PL.management.genelAyarlar.doping_ucretleri" %>
<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Doping Ücretleri
            <small>tüm doping ücretleri burada listelenir.</small>
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
                        <h3 class="box-title">Doping Ücret Listesi</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Kategori</th>
                                    <th>Doping Adı</th>
                                    <th>Doping Süre</th>
                                    <th>Ücret</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="dopingUcretRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("kategoriAdi") %></td>
                                            <td><%#Eval("dopingAdi") %></td>
                                            <td><%#Eval("dopingSureId") %></td>
                                            <td><%#Eval("fiyat") %></td>

                                            <td>
                                                <button class="btn btn-warning btn-xs">Düzenle</button>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Kategori</th>
                                    <th>Doping Adı</th>
                                    <th>Doping Süre</th>
                                    <th>Ücret</th>
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
