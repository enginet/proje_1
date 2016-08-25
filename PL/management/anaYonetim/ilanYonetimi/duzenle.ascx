<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="duzenle.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.ilan_duzenle" %>
<link rel="stylesheet" href="../../plugins/select2/select2.min.css">
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>'>
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>'>

<style>


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


<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>İlan Düzenle
            <small>buradan ilanları düzenleyebilirsiniz.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">General Elements</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
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
                            <asp:DropDownList ID="drpKimden" runat="server" CssClass="select2" Style="width: 100%;" AutoPostBack="True" OnSelectedIndexChanged="drpKimden_SelectedIndexChanged">
                                <asp:ListItem Value="" Selected="True">Seçiniz</asp:ListItem>
                                <asp:ListItem Value="1">Sahibinden</asp:ListItem>
                                <asp:ListItem Value="2">Emlakçıdan</asp:ListItem>
                                <asp:ListItem Value="3">Belediyeden</asp:ListItem>
                                <asp:ListItem Value="4">Bankadan</asp:ListItem>
                                <asp:ListItem Value="5">İzale-i Şuyudan</asp:ListItem>
                                <asp:ListItem Value="6">İcradan</asp:ListItem>
                                <asp:ListItem Value="7">Milli Hazineden (Satışı Devam Eden)</asp:ListItem>
                                <asp:ListItem Value="8">Milli Hazineden (Satılamayan)</asp:ListItem>
                                <asp:ListItem Value="9">Özelleştirme İdaresinden</asp:ListItem>
                                <asp:ListItem Value="10">İnşaat Firmasından</asp:ListItem>
                                <asp:ListItem Value="11">Diğer Kamu Kurumlarından</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.box -->
        </div>
        <section class="content">
            <div class="row">
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
                                        <asp:TextBox ID="txtFiyat" CssClass="form-control" runat="server"></asp:TextBox>
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
                <!--/.col (left) -->
                <!-- right column -->
                <!--/.col (right) -->
            </div>
            <!-- /.row -->
        </section>
        <!--address section-->
        <section class="content">
            <div class="row">
                <!-- left column -->
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
                    <!--/.col (left) -->
                    <!-- right column -->
                    <!--/.col (right) -->
                </div>
                <!-- /.row -->
        </section>
        <!--fotograf section-->
        <section class="content">
            <div class="row">
                <!-- left column -->
                <div class="col-md-9 pull-right">
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
                    <!--/.col (left) -->
                    <!-- right column -->
                    <!--/.col (right) -->
                </div>
                <!-- /.row -->
        </section>

        <!-- /.content -->
        <div class="col-md-9 col-md-offset-3" style="float: none; padding-bottom: 30px">
            <asp:Button ID="Kaydet" runat="server" CssClass="btn btn-success" Text="Kaydet" OnClick="Kaydet_Click" />
            <asp:Button ID="Vezgec" runat="server" CssClass="btn btn-danger" Text="Vazgeç" OnClick="Vazgeç_Click" />
        </div>
    </section>
</div>

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
</script>
