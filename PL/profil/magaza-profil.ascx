<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="magaza-profil.ascx.cs" Inherits="PL.profil.magaza_profil" %>

<link rel="stylesheet" href="../management/plugins/datepicker/datepicker3.css" />
<link rel="stylesheet" href="../management/plugins/select2/select2.min.css" />
<link rel="stylesheet" href="../management/dist/css/AdminLTE.min.css" />
<style>
    .square, .btn {
        border-radius: 0px !important;
    }

    /* -- color classes -- */
    .coralbg {
        background-color: #16A085;
    }

    .coral {
        color: #16A085;
    }

    .turqbg {
        background-color: #16A085;
    }

    .turq {
        color: #16A085;
    }

    .white {
        color: #fff !important;
    }

    /* -- The "User's Menu Container" specific elements. Custom container for the snippet -- */
    div.user-menu-container {
        z-index: 10;
        background-color: #fff;
        margin-top: 20px;
        background-clip: padding-box;
        opacity: 0.97;
        filter: alpha(opacity=97);
        -webkit-box-shadow: 0 1px 6px rgba(0, 0, 0, 0.175);
        box-shadow: 0 1px 6px rgba(0, 0, 0, 0.175);
    }

        div.user-menu-container .btn-lg {
            padding: 0px 12px;
        }

        div.user-menu-container h4 {
            font-weight: 300;
            color: #8b8b8b;
        }

        div.user-menu-container a, div.user-menu-container .btn {
            transition: 1s ease;
        }

        div.user-menu-container .thumbnail {
            width: 100%;
            min-height: 200px;
            border: 0px !important;
            padding: 0px;
            border-radius: 0;
            border: 0px !important;
        }

        /* -- Vertical Button Group -- */
        div.user-menu-container .btn-group-vertical {
            display: block;
        }

            div.user-menu-container .btn-group-vertical > a {
                padding: 20px 25px;
                background-color: #16A085;
                color: white;
                border-color: #fff;
            }

    div.btn-group-vertical > a:hover {
        color: white;
        border-color: white;
    }

    div.btn-group-vertical > a.active {
        background: #8b8b8b;
        box-shadow: none;
        color: white;
    }
    /* -- Individual button styles of vertical btn group -- */
    div.user-menu-btns {
        padding-right: 0;
        padding-left: 0;
        padding-bottom: 0;
    }

        div.user-menu-btns div.btn-group-vertical > a.active:after {
            content: '';
            position: absolute;
            left: 100%;
            top: 50%;
            margin-top: -13px;
            border-left: 0;
            border-bottom: 13px solid transparent;
            border-top: 13px solid transparent;
            border-left: 10px solid #16A085;
        }
    /* -- The main tab & content styling of the vertical buttons info-- */
    div.user-menu-content {
        color: #323232;
    }

    ul.user-menu-list {
        list-style: none;
        margin-top: 20px;
        margin-bottom: 0;
        padding: 10px;
        border: 1px solid #eee;
    }

        ul.user-menu-list > li {
            padding-bottom: 8px;
            text-align: center;
        }

    div.user-menu div.user-menu-content:not(.active) {
        display: none;
    }

    /* -- The btn stylings for the btn icons -- */
    .btn-label {
        position: relative;
        left: -12px;
        display: inline-block;
        padding: 6px 12px;
        background: rgba(0,0,0,0.15);
        border-radius: 3px 0 0 3px;
    }

    .btn-labeled {
        padding-top: 0;
        padding-bottom: 0;
    }

    /* -- Custom classes for the snippet, won't effect any existing bootstrap classes of your site, but can be reused. -- */

    .user-pad {
        padding: 20px 25px;
    }

    .no-pad {
        padding-right: 0;
        padding-left: 0;
        padding-bottom: 0;
    }

    .user-details {
        background: #eee;
        min-height: 333px;
    }

    .user-image {
        max-height: 200px;
        overflow: hidden;
    }

    .overview h3 {
        font-weight: 300;
        margin-top: 15px;
        margin: 10px 0 0 0;
    }

    .overview h4 {
        font-weight: bold !important;
        font-size: 40px;
        margin-top: 0;
    }

    .view {
        position: relative;
        overflow: hidden;
        margin-top: 10px;
    }

        .view p {
            margin-top: 20px;
            margin-bottom: 0;
        }

    .caption {
        position: absolute;
        top: 0;
        right: 0;
        background: rgba(70, 216, 210, 0.44);
        width: 100%;
        height: 100%;
        padding: 2%;
        display: none;
        text-align: center;
        color: #fff !important;
        z-index: 2;
    }

        .caption a {
            padding-right: 10px;
            color: #fff;
        }

    .info {
        display: block;
        padding: 10px;
        background: #eee;
        text-transform: uppercase;
        font-weight: 300;
        text-align: right;
    }

        .info p, .stats p {
            margin-bottom: 0;
        }

    .stats {
        display: block;
        padding: 10px;
        color: white;
    }

    .share-links {
        border: 1px solid #eee;
        padding: 15px;
        margin-top: 15px;
    }

    .square, .btn {
        border-radius: 5px !important;
    }

    /* -- media query for user profile image -- */
    @media (max-width: 767px) {
        .user-image {
            max-height: 400px;
        }
    }
</style>
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
    <div class="row user-menu-container square">
        <div class="col-md-12 user-details">
            <div class="row coralbg white">
                <div class="col-md-6 no-pad">
                    <div class="user-pad">
                        <h1 runat="server" id="h3MagazaAdi"></h1>
                        <br />
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" CssClass="btn btn-labeled btn-danger" runat="server"><span class="btn-label"><i class="fa fa-chain"></i></span> Mağazama Git</asp:HyperLink>
                    </div>
                </div>
                <div class="col-md-6 no-pad">
                    <div class="user-image">
                        <img src="../libraries/images/user.jpg" class="img-responsive thumbnail" alt="img" />
                    </div>
                </div>
            </div>
            <div class="row overview">
                <div class="col-md-4 user-pad text-center">
                    <h3>Takipçiler</h3>
                    <h4>2,784</h4>
                </div>
                <div class="col-md-4 user-pad text-center">
                    <h3>İlan Sayısı</h3>
                    <h4>456</h4>
                </div>
                <div class="col-md-4 user-pad text-center">
                    <h3>Danışman Sayısı</h3>
                    <h4>4,901</h4>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="inner-box">
        <div id="accordion" class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Mağaza Bilgilerim </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB1">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3">Firma Adı</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtMagazaAdi" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Firma Tipi</label>
                                <div class="col-sm-9">
                                    <asp:RadioButtonList ID="rdBireyseli" runat="server" RepeatDirection="Horizontal" Height="33px" Width="241px" Enabled="false">
                                        <asp:ListItem Value="false" Selected> Bireysel</asp:ListItem>
                                        <asp:ListItem Value="true"> Kurumsal</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <!-- /.form group -->
                            <div class="form-group">
                                <label class="col-sm-3">İş Telefonu</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtIsTlf" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <!-- /.form group -->
                            <div class="form-group">
                                <label class="col-sm-3">İş Telefonu 2</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtIsTlf2" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">İl</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">İlçe</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Mahalle</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label id="lblTc" class="col-sm-3" runat="server">TC Kimlik No</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtTcNo" runat="server" disabled="disabled">
                                </div>
                            </div>
                            <div class="form-group" id="vergiPnl" runat="server">
                                <label class="col-sm-3">Vergi Dairesi</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpVergi" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- Button  -->
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>

                                <div class="col-md-8">
                                    <asp:Button ID="btnKaydet" CssClass="btn btn-success btn-lg" runat="server" OnClick="btnKaydet_Click" Text="Bilgilerimi Güncelle" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-box End-->
        <div id="accordion" class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB3" data-toggle="collapse">Mağaza Detay Bilgileri </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB3">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3">Kategori</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKategori" runat="server"></asp:DropDownList>
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
                                <label class="col-sm-3 control-label">Mağaza Logosu</label>
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
                                    <asp:Button ID="Button2" CssClass="btn btn-success btn-lg" runat="server" Text="Kaydet" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="accordion" class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB2" data-toggle="collapse">Mağazama Kullanıcı Ekle </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB2">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3">Ad Soyad</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKullanici" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>
                                <div class="col-md-8">
                                    <asp:Button ID="Ekle" CssClass="btn btn-success btn-lg" runat="server" Text="Kullanıcı Ekle" OnClick="Ekle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
