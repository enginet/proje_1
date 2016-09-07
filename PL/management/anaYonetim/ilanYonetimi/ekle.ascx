<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ekle.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.ekle" %>
<link rel="stylesheet" href="../../plugins/select2/select2.min.css">
<!-- Theme style -->
<%--<link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">--%>
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>'>
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>'>
<link rel="stylesheet" href="../../plugins/dropzone/dropzone.css" />


<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAS1wH5TdTQ8gbD5zB6Ghi2hN4BpkkbJ5M&callback=initMap" async defer></script>
<style>
    #map {
        width: 100%;
        height: 350px;
    }

    #uploadImage {
        float: none;
    }

    .secili {
        border: 4px solid #679b12;
    }

    .dz-image {
        cursor: pointer !important;
    }

    .dropzone {
        cursor: pointer;
        background-color: #f8f8f8;
        height: 100%;
        border-style: dashed;
        height: auto;
    }

        .dropzone.dz-drag-hover {
            border-style: dashed;
            background-color: #f4f4f4;
        }

            .dropzone.dz-drag-hover span {
                color: #959595 !important;
            }

    .dz-default span {
        text-align: center;
        display: block;
        vertical-align: center;
        font-family: 'Tahoma';
        font-size: 24px;
        color: #959595;
    }

    .dSec {
        border: 3px solid #007e44;
        width: 150px;
        height: 150px;
        background-color: #008d4c;
        border-radius: 4px;
        color: #fff;
        cursor: pointer;
        font-size: 20px;
        font-weight: bold;
        line-height: 210px;
        text-align: center;
        display: block;
        margin-bottom: 20px;
    }

        .dSec:hover {
            background-color: #007e44;
            color: #fff;
        }

        .dSec span {
            display: block;
            position: absolute;
            left: 66px;
            top: 30px;
        }

    .dz-image {
        border-radius: 0 !important;
    }

    .resimler {
        height: 180px;
        margin-bottom: 20px;
    }

        .resimler a {
            height: 100%;
        }

        .resimler img {
            height: 100%;
        }

        .resimler span {
            display: block;
            cursor: pointer;
            color: #fff;
            text-align: center;
            line-height: 30px;
            position: absolute;
            bottom: 10px;
            padding: 0 15px;
        }

        .resimler .resimSil {
            background-color: #ba0d0d;
            right: 16px;
            bottom: 50px;
        }

            .resimler .resimSil:hover {
                background-color: #a30f0f;
            }

        .resimler .vitrin {
            background-color: #1666aa;
            right: 16px;
        }

            .resimler .vitrin:hover {
                background-color: #1886aa;
            }
</style>
<style>
    .checkbox .btn,
    .checkbox-inline .btn {
        padding-left: 2em;
        min-width: 8em;
    }

    .checkbox label,
    .checkbox-inline label {
        text-align: left;
        padding-left: 0.5em;
    }
</style>
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>İlan Ekle
            <small>buradan ilan ekleyebilirsiniz.</small>
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
            <div class="col-md-9">
                <div class="box box-success">
                    <div class="box-body" runat="server" id="box_body">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Kimden Seçiniz</label>
                                <div class="clearfix"></div>
                                <asp:DropDownList ID="drpKimden" runat="server" CssClass="select2 kimden" Style="width: 100%;" AutoPostBack="True" OnSelectedIndexChanged="drpKimden_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-xs-12 pull-right">
                <!-- general form elements -->
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">Adres Bilgileri</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <div class="col-md-4">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label>İl</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>İlçe</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Mahalle</label>
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server"></asp:DropDownList>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- /.box -->
                </div>
            </div>

            <div class="col-md-9 col-xs-12 pull-right">
                <!-- general form elements -->
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">Harita</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div class="col-md-12">
                                <div id="map"></div>
                                <!-- Harita -->
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                    <!-- /.box -->
                </div>
            </div>

            <div class="col-md-9 col-xs-12 pull-right">
                <!-- general form elements -->
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">Fotoğraf</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div id='uploadImage'>
                                        <asp:FileUpload ID="FileUpload1" CssClass="fUp" runat="server" AllowMultiple="true" onChange="preview(this)" maxRequestLength="2048" />
                                        <a class="dSec" onclick="triggerFileUpload()"><span class="fa fa-camera" style="font-size: 45px;"></span>Resim Seç</a>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="previews">
                                    </div>
                                </div>

                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                    <!-- /.box -->
                </div>
            </div>

            <!-- left column -->
            <div class="col-md-9 pull-right">
                <!-- general form elements -->
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">İlan Detayları</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div>
                                <div class="form-group">
                                    <label for="txtBaslik">İlan Başlığı</label>
                                    <asp:TextBox ID="txtBaslik" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label for="txtFiyat">Fiyat</label>
                                    <asp:TextBox ID="txtFiyat" CssClass="form-control double" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="editor1">Açıklama</label>
                                    <div>
                                        <asp:TextBox ID="txtCKeditorAdi" runat="server" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="box-footer" id="box_footer" runat="Server">
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder21" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder22" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder23" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder24" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder25" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder26" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder27" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder28" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder29" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder30" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <!-- /.box -->
            </div>
        </div>
    </section>
    <div class="col-md-9 col-md-offset-3" style="float: none; padding-bottom: 30px">
        <asp:Button ID="Kaydet" runat="server" CssClass="btn btn-success" Text="Kaydet" OnClick="Kaydet_Click" />
        <asp:Button ID="Vezgec" runat="server" CssClass="btn btn-danger" Text="Vazgeç" OnClick="Vazgeç_Click" />
    </div>
</div>
<!-- /.content-wrapper -->

<script src="../../plugins/select2/select2.full.min.js"></script>

<!-- InputMask -->
<script src="../../plugins/input-mask/jquery.inputmask.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.extensions.js"></script>
<!-- date-range-picker -->
<%--<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>--%>
<script src="../../plugins/dropzone/dropzone.js"></script>
<script type='text/javascript'>

    $(document).ready(function () {
        document.getElementById("ContentPlaceHolder1_ctl00_FileUpload1").style.display = "none";
    });
    function triggerFileUpload() {
        document.getElementById("ContentPlaceHolder1_ctl00_FileUpload1").click();
    }

    var files;
    function preview(input) {
        if (input.files && input.files[0]) {
            $(".resimler").remove();
            var filelist = input.files || [];

            if (filelist.length <= 10) {
                for (var i = 0; i < filelist.length; i++) {
                    var filedr = new FileReader();
                    filedr.onload = function (e) {
                        var element = "<div class='col-xs-6 col-sm-2 resimler'>" +
                                          "<a class='thumbnail'><img class='deneme' src='" + e.target.result + "'/></a>" +
                                          "<div class='clearfix'></div>" +
                                      "</div>";
                        $("#previews").append(element);
                    }
                    filedr.readAsDataURL(input.files[i]);
                }
                files = document.getElementById("ContentPlaceHolder1_ctl00_FileUpload1").files;
            }
            else {
                alert("Maksimum 10 resim seçebilirsiniz");
            }

        }
    }
</script>
<!-- Page script -->
<script>
    $(function () {
        //Initialize Select2 Elements
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

<script src="https://cdn.ckeditor.com/4.4.3/standard/ckeditor.js"></script>
<script>

    window.onload = function () {

        var editor = CKEDITOR.replace('<% = txtCKeditorAdi.ClientID %>');

    };

</script>


<script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
<script src='<%= Page.ResolveUrl("~/management/plugins/datepicker/bootstrap-datepicker.js") %>'></script>
<script>
    $(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    });

    //Date picker
    $('.satisTarih').datepicker({
        autoclose: true
    });

    $('.double').keypress(function (event) {
        if ((event.which != 44 || $(this).val().indexOf(',') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    var map;
    function initMap(koordinat) {
        var koordinatlar = [];
        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 6,
            center: { lat: 39, lng: 36 },
            mapTypeId: google.maps.MapTypeId.ROAD
        });

        var renk = '';
        
        if ($(".kimden").val() == '100000001') { // belediye
            renk = '#6a12bc';
        }
        else if ($(".kimden").val() == '100000002') { // icra
            renk = '#ffb400';
        }
        else if ($(".kimden").val() == '100000003') { // izaleyi luyu
            renk = '#a0fcff';
        }
        else if ($(".kimden").val() == '100000004') { // milli hazine güncel olamayan
            renk = '#86ed00';
        }
        else if ($(".kimden").val() == '100000005' ||
            $(".kimden").val() == '100000006' ||
            $(".kimden").val() == '100000007' ||
            $(".kimden").val() == '100000008' ||
            $(".kimden").val() == '100000009' ||
            $(".kimden").val() == '1000000010' ||
            $(".kimden").val() == '1000000011' ||
            $(".kimden").val() == '1000000012' ||
            $(".kimden").val() == '1000000013' ||
            $(".kimden").val() == '1000000014' ||
            $(".kimden").val() == '1000000015' ||
            $(".kimden").val() == '1000000016' ||
            $(".kimden").val() == '1000000017' ||
            $(".kimden").val() == '1000000018' ||
            $(".kimden").val() == '1000000019' ||
            $(".kimden").val() == '1000000020' ||
            $(".kimden").val() == '1000000021' ||
            $(".kimden").val() == '1000000022' ||
            $(".kimden").val() == '1000000023') {
            renk = '#fffc00';
        }
        else if ($(".kimden").val() == '1000000024') {
            renk = '#e3fffe';
        }
        else if ($(".kimden").val() == '1000000025') {
            renk = '#8b8b8b';
        }
        else if ($(".kimden").val() == '1000000028') {
            renk = '#9d9d9d';
        }

        var obj = JSON.parse(koordinat);

        for (var j = 0; j < obj["features"][0]["geometry"]["coordinates"][0].length; j++) {
            koordinatlar.push({ lat: obj["features"][0]["geometry"]["coordinates"][0][j][1], lng: obj["features"][0]["geometry"]["coordinates"][0][j][0] });
        }
        sekil = new google.maps.Polygon({
            paths: koordinatlar,
            strokeColor: renk,
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: renk,
            fillOpacity: 0.35
        });
        sekil.setMap(map);

        var markerPosition = { lat: koordinatlar[0]["lat"], lng: koordinatlar[0]["lng"] }
        var marker = new google.maps.Marker({
            position: markerPosition,
            map: map,
            title: "ilan"
        });

        map.setZoom(17);
        map.setCenter({ lat: koordinatlar[0]["lat"], lng: koordinatlar[0]["lng"] });
    }

    jQuery('.koordinat').focusout(function () {
        initMap($(this).val());
    });
</script>
