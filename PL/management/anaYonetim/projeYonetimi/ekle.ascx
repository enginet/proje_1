﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ekle.ascx.cs" Inherits="PL.management.anaYonetim.projeYonetimi.ekle" %>
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- daterange picker -->
    <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker-bs3.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="../../plugins/select2/select2.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">

<div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Proje Ekle
            <small>buradan proje ekleyebilirsiniz.</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">General Elements</li>
          </ol>
        </section>
        <!-- Main content -->
        <section class="content">
          <div class="row">
            <!-- left column -->
            <div class="col-md-12">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Proje Ekle Formu</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <div role="form">
                  <div class="box-body">
                    <div class="col-md-6">
                    <div class="form-group">
                      <label for="reklamadi">Proje Başlığı</label>
                      <input type="text" class="form-control" id="reklamadi" placeholder="Enter">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputFile">Proje Logosu</label>
                      <input type="file" id="exampleInputFile">
                      <p class="help-block">Example block-level help text here.</p>
                   </div>
                    <div class="form-group">
                      <label for="firmaadi">Firma Adı</label>
                      <input type="text" class="form-control" id="firmaadi" placeholder="Enter">
                    </div>
                    <div class="form-group">
                        <label>İl</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                        <label>İlçe</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                        <label>Kategori</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                        <label>Alt Kategori</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                        <label>Durum</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                        <label>Emlak Tipi</label>
                            <select class="form-control select2" style="width: 100%;">
                              <option selected="selected">Alabama</option>
                              <option>Alaska</option>
                              <option>California</option>
                              <option>Delaware</option>
                              <option>Tennessee</option>
                              <option>Texas</option>
                              <option>Washington</option>
                            </select>
                    </div><!-- /.form-group -->
                    <div class="form-group">
                      <label for="maralik">Metrekare Aralığı</label>
                      <input type="text" class="form-control" id="maralik" placeholder="Enter">
                    </div>
                    <div class="form-group">
                      <input type="text" class="form-control" id="maralik1" placeholder="Enter">
                    </div>
                    <div class="form-group">
                      <label for="palan">Proje Alanı</label>
                      <input type="text" class="form-control" id="palan" placeholder="Enter">
                    </div>
                    <div class="form-group">
                      <label for="odasalon">Oda/Salon</label>
                      <input type="text" class="form-control" id="oda" placeholder="Oda Sayısı">
                    </div>
                    <div class="form-group">
                      <input type="text" class="form-control" id="salon" placeholder="Salon Sayısı">
                    </div>
                   <div class="form-group">
                    <label>Teslim Tarihi</label>
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                      <input type="text" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                  <!-- phone mask -->
                  <div class="form-group">
                    <label>İletişim Bilgisi</label>
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i>
                      </div>
                      <input type="text" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                    <div class="form-group">
                        <label for="editor1">Proje Açıklaması</label>
                           <div>
                            <textarea id="editor1" name="editor1" rows="10" cols="80">
                                 This is my textarea to be replaced with CKEditor.
                            </textarea>
                           </div>
                    </div>
                 </div>
                </div><!-- /.box-body -->
                  <div class="box-footer">
                    <div class="box-header with-border">
                      <h3 class="box-title">Genel Özellikler</h3>
                    </div><!-- /.box-header -->
                  <!-- checkbox -->
                  <div class="form-group">
                    <div class="box-header with-border">
                      <h5>Sağlık</h5>
                    </div><!-- /.box-header -->
                 <div class="box-header with-border">
                    <label>
                      <input type="checkbox" class="flat-red">
                        Sağlık Ocağı
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red">
                        Poliklinik
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Eczane
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Veteriner
                    </label>
                 </div>
                  </div>
                  <div class="form-group">
                    <div class="box-header with-border">
                      <h5>Eğitim</h5>
                    </div><!-- /.box-header -->
                 <div class="box-header with-border">
                    <label>
                      <input type="checkbox" class="flat-red">
                        Sağlık Ocağı
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red">
                        Poliklinik
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Eczane
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Veteriner
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red">
                        Sağlık Ocağı
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red">
                        Poliklinik
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Eczane
                    </label>
                    <label>
                      <input type="checkbox" class="flat-red" >
                        Veteriner
                    </label>
                 </div>
                  </div>
                  </div>
                  <div class="box-footer">
                    <button type="submit" class="btn btn-primary">Ekle</button>
                  </div>
                </div>
              </div><!-- /.box -->
            </div><!--/.col (left) -->
            <!-- right column -->
            <!--/.col (right) -->
          </div>   <!-- /.row -->
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
    <!-- jQuery 2.1.4 -->
    <script src="../../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <!-- Select2 -->
    <script src="../../plugins/select2/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="../../plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="../../plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <!-- date-range-picker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script src="../../plugins/daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap color picker -->
    <script src="../../plugins/colorpicker/bootstrap-colorpicker.min.js"></script>
    <!-- bootstrap time picker -->
    <script src="../../plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <!-- SlimScroll 1.3.0 -->
    <script src="../../plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="../../plugins/iCheck/icheck.min.js"></script>
    <!-- FastClick -->
    <script src="../../plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../dist/js/demo.js"></script>
    <!-- Page script -->
    <script>
      $(function () {
        //Initialize Select2 Elements
        $(".select2").select2();

        //Datemask dd/mm/yyyy
        $("#datemask").inputmask("dd/mm/yyyy", {"placeholder": "dd/mm/yyyy"});
        //Datemask2 mm/dd/yyyy
        $("#datemask2").inputmask("mm/dd/yyyy", {"placeholder": "mm/dd/yyyy"});
        //Money Euro
        $("[data-mask]").inputmask();

        //Date range picker
        $('#reservation').daterangepicker();
        //Date range picker with time picker
        $('#reservationtime').daterangepicker({timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A'});
        //Date range as a button
        $('#daterange-btn').daterangepicker(
            {
              ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
              },
              startDate: moment().subtract(29, 'days'),
              endDate: moment()
            },
        function (start, end) {
          $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        }
        );

        //iCheck for checkbox and radio inputs
        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
          checkboxClass: 'icheckbox_minimal-blue',
          radioClass: 'iradio_minimal-blue'
        });
        //Red color scheme for iCheck
        $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
          checkboxClass: 'icheckbox_minimal-red',
          radioClass: 'iradio_minimal-red'
        });
        //Flat red color scheme for iCheck
        $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
          checkboxClass: 'icheckbox_flat-green',
          radioClass: 'iradio_flat-green'
        });

        //Colorpicker
        $(".my-colorpicker1").colorpicker();
        //color picker with addon
        $(".my-colorpicker2").colorpicker();

        //Timepicker
        $(".timepicker").timepicker({
          showInputs: false
        });
      });
    </script>
    <script src="https://cdn.ckeditor.com/4.4.3/standard/ckeditor.js"></script>
    <script>
      $(function () {
        // Replace the <textarea id="editor1"> with a CKEditor
        // instance, using default configuration.
        CKEDITOR.replace('editor1');
        //bootstrap WYSIHTML5 - text editor
        $(".textarea").wysihtml5();
      });
    </script>