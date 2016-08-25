<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="reklam-ekle.ascx.cs" Inherits="PL.profil.reklam_ekle" %>
<link rel="stylesheet" href="../management/plugins/daterangepicker/daterangepicker-bs3.css">
<link rel="stylesheet" href="../management/plugins/datepicker/datepicker3.css">
<link rel="stylesheet" href="../management/dist/css/skins/_all-skins.min.css">
<style>
    .image-preview-input {
        position: relative;
        overflow: hidden;
        margin: 0px;
        color: #333;
        background-color: #fff;
        border-color: #ccc;
    }

        .image-preview-input input[type=file] {
            position: absolute;
            top: 0;
            right: 0;
            margin: 0;
            padding: 0;
            font-size: 20px;
            cursor: pointer;
            opacity: 0;
            filter: alpha(opacity=0);
        }

    .image-preview-input-title {
        margin-left: 2px;
    }
</style>
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <div id="accordion" class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Reklam Bilgileri </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB1">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Reklam Adı</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtReklamAd" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Reklam Türü</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="drpReklamTur" CssClass="form-control select2 reklamTur" Style="width: 100%;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpReklamTur_SelectedIndexChanged">
                                        <asp:ListItem Selected>Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="1">Site İçi</asp:ListItem>
                                        <asp:ListItem Value="2">Harita Çevresi</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Reklam Konumu</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="drpKonum" CssClass="form-control select2 reklamKonum" Style="width: 100%;" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected Value="null">Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="1">Anasayfa - 728 * 90</asp:ListItem>
                                        <asp:ListItem Value="2">Anasayfa - sağ üst - 230 * 230</asp:ListItem>
                                        <asp:ListItem Value="3">Anasayfa - sağ alt - 230 * 230</asp:ListItem>
                                        <asp:ListItem Value="4">Liste - 728 * 90</asp:ListItem>
                                        <asp:ListItem Value="4">Detay - 230 * 230</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="col-sm-3 control-label">İl</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Tarih Aralığı</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <asp:TextBox ID="txtTarih" CssClass="tarih form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <!-- /.form group -->
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Reklam Resmi</label>
                                <div class="col-sm-9">
                                    <div class="input-group image-preview">
                                        <input type="text" class="form-control image-preview-filename" disabled="disabled">
                                        <!-- don't give a name === doesn't send on POST/GET -->
                                        <span class="input-group-btn">
                                            <!-- image-preview-clear button -->
                                            <button type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                                <span class="glyphicon glyphicon-remove"></span>Sil
                                            </button>
                                            <!-- image-preview-input -->
                                            <div class="btn btn-default image-preview-input">
                                                <span class="glyphicon glyphicon-folder-open"></span>
                                                <span class="image-preview-input-title">Resim Yükle</span>
                                                <asp:FileUpload ID="FileUpload1" CssClass="resimSec" accept="image/png, image/jpeg, image/gif" runat="server" />
                                                <!-- rename it -->
                                            </div>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- /input-group image-preview [TO HERE]-->
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Reklam Linki</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtReklamLink" runat="server" class="form-control" placeholder="www.netteilanver.com/"></asp:TextBox>
                                </div>
                            </div>
                            <!-- Button  -->
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>
                                <div class="col-md-8">
                                    <asp:Button ID="btnKaydet" CssClass="btn btn-success btn-lg" runat="server" Text="Kaydet" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-box End-->

    </div>
</div>
<script src="../management/plugins/input-mask/jquery.inputmask.js"></script>
<script src="../management/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../management/plugins/input-mask/jquery.inputmask.extensions.js"></script>
<!-- date-range-picker -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
<script src="../management/plugins/daterangepicker/daterangepicker.js"></script>
<!-- bootstrap datepicker -->
<script src="../management/plugins/datepicker/bootstrap-datepicker.js"></script>
<script>
    $(document).on('click', '#close-preview', function () {
        $('.image-preview').popover('hide');
        // Hover befor close the preview
        $('.image-preview').hover(
            function () {
                $('.image-preview').popover('show');
            },
                function () {
                    $('.image-preview').popover('hide');
                }
        );
    });
    $(function () {
        // Create the close button
        var closebtn = $('<button/>', {
            type: "button",
            text: 'kapat',
            id: 'close-preview',
            style: 'font-size: initial;',
        });
        closebtn.attr("class", "close pull-right");
        // Set the popover default content
        $('.image-preview').popover({
            trigger: 'manual',
            html: true,
            title: "<strong>Önizleme</strong>" + $(closebtn)[0].outerHTML,
            content: "Önizleme için resim yok",
            placement: 'bottom'
        });
        // Clear event
        $('.image-preview-clear').click(function () {
            $('.image-preview').attr("data-content", "").popover('hide');
            $('.image-preview-filename').val("");
            $('.image-preview-clear').hide();
            $('.image-preview-input input:file').val("");
            $(".image-preview-input-title").text("Resim Yükle");
        });

        $(".image-preview-input input:file").change(function () {

            var genislik, yukseklik;
            var kontrol = true;
            if ($("#ContentPlaceHolder1_ctl00_drpReklamTur").val() == "Harita Çevresi") {
                genislik = 250;
                yukseklik = 150;
            }
            else if ($("#ContentPlaceHolder1_ctl00_drpReklamTur").val() == "Site İçi") {
                if ($("#ContentPlaceHolder1_ctl00_drpKonum").val() == "Anasayfa - 728 * 90") {
                    genislik = 728;
                    yukseklik = 90;
                }
                else if ($("#ContentPlaceHolder1_ctl00_drpKonum").val() == "Anasayfa - sağ üst - 230 * 230") {
                    genislik = 230;
                    yukseklik = 230;
                }
                else if ($("#ContentPlaceHolder1_ctl00_drpKonum").val() == "Anasayfa - sağ alt - 230 * 230") {
                    genislik = 230;
                    yukseklik = 230;
                }
                else if ($("#ContentPlaceHolder1_ctl00_drpKonum").val() == "Liste - 728 * 90") {
                    genislik = 728;
                    yukseklik = 90;
                }
                else if ($("#ContentPlaceHolder1_ctl00_drpKonum").val() == "Detay - 230 * 230") {
                    genislik = 230;
                    yukseklik = 230;
                }
                else {
                    kontrol = false;
                }
            }
            else {
                kontrol = false;
            }

            if (kontrol == true) {
                var img = $('<img/>', {
                    height: yukseklik,
                    width: genislik
                });
                var file = this.files[0];
                var reader = new FileReader();
                // Set preview image into the popover data-content
                reader.onload = function (e) {
                    $(".image-preview-input-title").text("Değiştir");
                    $(".image-preview-clear").show();
                    $(".image-preview-filename").val(file.name);
                    img.attr('src', e.target.result);
                    $(".image-preview").attr("data-content", $(img)[0].outerHTML).popover("show");
                }
                reader.readAsDataURL(file);
            }
            else {

                alert("Lütfen Resim Tür veya Resim konum Seçiniz");
            }
        });
    });
</script>
<script>
    $(function () {
        //Date range picker
        $('.tarih').daterangepicker();

        //Datemask dd/mm/yyyy
        //Money Euro
        $("[data-mask]").inputmask();

    });
</script>