<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listele.ascx.cs" Inherits="PL.management.anaYonetim.projeYonetimi.listele" %>
 <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Projeler
            <small>tüm projeler burada listelenir.</small>
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
                  <h3 class="box-title">Proje Listesi</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <table id="example1" class="table table-bordered table-striped">
                    <thead>
                      <tr>
                        <th>Proje No</th>
                        <th>Adı</th>
                        <th>Kategori</th>
                        <th>Bölge</th>
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
                        <td>Trident</td>
                        <td>
                          <button class="btn btn-success btn-xs">Düzenle</button>
                          <button class="btn btn-danger btn-xs">Sil</button>
                      </tr>
                       <tr>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>Trident</td>
                        <td>
                          <button class="btn btn-success btn-xs">Düzenle</button>
                          <button class="btn btn-danger btn-xs">Sil</button>
                      </tr>
                    </tbody>
                    <tfoot>
                       <tr>
                        <th>Proje No</th>
                        <th>Adı</th>
                        <th>Kategori</th>
                        <th>Bölge</th>
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

    <!-- page script -->
    <script>
      $(function () {
        $("#example1").DataTable();
        $('#example2').DataTable({
          "paging": true,
          "lengthChange": false,
          "searching": false,
          "ordering": true,
          "info": true,
          "autoWidth": false
        });
      });
    </script>
