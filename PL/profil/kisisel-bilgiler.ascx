<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="kisisel-bilgiler.ascx.cs" Inherits="PL.profil.kisisel_bilgiler" %>
<link rel="stylesheet" href="../management/plugins/datepicker/datepicker3.css">
<link rel="stylesheet" href="../management/plugins/select2/select2.min.css">
<link rel="stylesheet" href="../management/dist/css/AdminLTE.min.css">
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
                    <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Kişisel Bilgilerim </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB1">
                    <div class="panel-body">
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Ad</label>

                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtAd" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Soyad</label>

                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtSoyad" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">TC Kimlik no</label>

                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtKimlikNo" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Cinsiyet</label>
                                <div class="col-sm-9">
                                    <asp:RadioButtonList ID="rdCinsiyet" runat="server" RepeatDirection="Horizontal" Height="33px" Width="386px">
                                        <asp:ListItem Value="False">  Kadın </asp:ListItem>
                                        <asp:ListItem Value="True"> Erkek</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Doğum Tarihi</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask runat="server" id="txtTarih">
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <!-- /.form group -->

                            <div class="form-group">
                                <label class="col-sm-3 control-label">İl</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">İlçe</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Mahalle</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Eğitim Durumu</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpEgitim" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="1">Üniversite</asp:ListItem>
                                        <asp:ListItem Value="2">Yüksekokul</asp:ListItem>
                                        <asp:ListItem Value="3">Lise</asp:ListItem>
                                        <asp:ListItem Value="4">Ortaokul</asp:ListItem>
                                        <asp:ListItem Value="5">İlkokul</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
<%--                            <div class="form-group">
                                <label class="col-sm-3 control-label">Meslek</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control" Style="width: 100%;" ID="drpMeslek" runat="server"></asp:DropDownList>
                                </div>
                            </div>--%>

                            <div class="form-group hide">
                                <!-- remove it if dont need this part -->
                                <label class="col-sm-3 control-label">Facebook account map</label>

                                <div class="col-sm-9">
                                    <div class="form-control">
                                        <a class="link"
                                            href="fb.com">Jhone.doe</a> <a
                                                class=""><i class="fa fa-minus-circle"></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-3 col-sm-9"></div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-3 col-sm-9">
                                    <asp:Button ID="Guncelle" type="submit" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="Guncelle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB3" data-toggle="collapse">Fotoğrafım</a>
                    </h4>
                </div>
                <div class="panel-collapse collapse" id="collapseB3">
                    <div class="panel-body">
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Fotoğraf</label>
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
<script src="../management/plugins/select2/select2.full.min.js"></script>

<script>
    $(function () {
        $(".select2").select2();
        //Datemask dd/mm/yyyy
        $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
        //Datemask2 mm/dd/yyyy
        $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
        //Money Euro
        $("[data-mask]").inputmask();
    });
</script>
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
            text: 'x',
            id: 'close-preview',
            style: 'font-size: initial;',
        });
        closebtn.attr("class", "close pull-right");
        // Set the popover default content
        $('.image-preview').popover({
            trigger: 'manual',
            html: true,
            title: "<strong>Preview</strong>" + $(closebtn)[0].outerHTML,
            content: "There's no image",
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
        // Create the preview image
        $(".image-preview-input input:file").change(function () {
            var img = $('<img/>', {
                id: 'dynamic',
                width: 250,
                height: 200
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
        });
    });
</script>
