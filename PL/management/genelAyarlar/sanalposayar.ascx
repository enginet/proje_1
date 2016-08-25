<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sanalposayar.ascx.cs" Inherits="PL.management.genelAyarlar.sanalposayar" %>
<!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Sanal POS Ayarları
            <small>tüm sanal POS ayarları burada listelenir.</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
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
                  <h3 class="box-title">Sanal POS Listesi</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <table id="example1" class="table table-bordered table-striped">
                    <thead>
                      <tr>
                        <th>Banka No</th>
                        <th>Adı</th>
                        <th>Mod</th>
                        <th>Durum</th>
                        <th>İşlemler</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>
                          <button class="btn btn-warning btn-xs">Düzenle</button>
                          <button class="btn btn-success btn-xs">Aktifleştir</button>
                      </tr>
                       <tr>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>
                          <button class="btn btn-warning btn-xs">Düzenle</button>
                          <button class="btn btn-success btn-xs">Aktifleştir</button>
                      </tr>
                    </tbody>
                    <tfoot>
                       <tr>
                        <th>Banka No</th>
                        <th>Adı</th>
                        <th>Mod</th>
                        <th>Durum</th>
                        <th>İşlemler</th>
                      </tr>
                    </tfoot>
                  </table>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->