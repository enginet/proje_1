<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="magaza-detay-ekle.ascx.cs" Inherits="PL.profil.magaza_detay_ekle" %>
<style>
    .container {
        margin-top: 20px;
    }

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
                    <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Mağaza Detay Bilgileri </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB1">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3">Mağaza Adı</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtMagazaAdi" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Kategori</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control" Style="width: 100%;" ID="drpKategori" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Mağaza Paketi</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="drpPaket" CssClass="form-control select2" Style="width: 100%;" runat="server">
                                        <asp:ListItem Selected>Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="1">Standart</asp:ListItem>
                                        <asp:ListItem Value="2">Platinum</asp:ListItem>
                                        <asp:ListItem Value="3">Premium</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Paket Süresi</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="drpPaketSure" CssClass="form-control select2" Style="width: 100%;" runat="server">
                                        <asp:ListItem Selected>Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="1">2 Ay</asp:ListItem>
                                        <asp:ListItem Value="2">4 Ay</asp:ListItem>
                                        <asp:ListItem Value="3">6 Ay</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
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
                            <!-- Button  -->
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>
                                <div class="col-md-8">
                                    <asp:Button ID="btnKaydet" CssClass="btn btn-success btn-lg" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
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
