<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="ilan-form.aspx.cs" Inherits="PL.ilan_form1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/select2/select2.min.css") %>'>
    <%--    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/dropzone/dropzone.css") %>' />--%>
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <style>
        
        #uploadImage {
            float: none;
        }
        body {
            padding-top: 20px;
        }

        .pricing-table .plan {
            border-radius: 5px;
            text-align: center;
            background-color: #f3f3f3;
            -moz-box-shadow: 0 0 6px 2px #b0b2ab;
            -webkit-box-shadow: 0 0 6px 2px #b0b2ab;
            box-shadow: 0 0 6px 2px #b0b2ab;
        }

        .plan:hover {
            background-color: #fff;
            -moz-box-shadow: 0 0 12px 3px #b0b2ab;
            -webkit-box-shadow: 0 0 12px 3px #b0b2ab;
            box-shadow: 0 0 12px 3px #b0b2ab;
        }

        .plan {
            padding: 20px;
            color: #ff;
            background-color: #5e5f59;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-bronze {
            padding: 20px;
            color: #fff;
            background-color: #665D1E;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-silver {
            padding: 20px;
            color: #fff;
            background-color: #C0C0C0;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-gold {
            padding: 20px;
            color: #fff;
            background-color: #FFD700;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .pricing-table-bronze {
            padding: 20px;
            color: #fff;
            background-color: #f89406;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .pricing-table .plan .plan-name span {
            font-size: 20px;
        }

        .pricing-table .plan ul {
            list-style: none;
            margin: 0;
            -moz-border-radius: 0 0 5px 5px;
            -webkit-border-radius: 0 0 5px 5px;
            border-radius: 0 0 5px 5px;
        }

            .pricing-table .plan ul li.plan-feature {
                padding: 15px 10px;
                border-top: 1px solid #c5c8c0;
            }

        .pricing-three-column {
            margin: 0 auto;
            width: 80%;
        }

        .pricing-variable-height .plan {
            float: none;
            margin-left: 2%;
            vertical-align: bottom;
            display: inline-block;
            zoom: 1;
            *display: inline;
        }

        .plan-mouseover .plan-name {
            background-color: #4e9a06 !important;
        }

        .btn-plan-select {
            padding: 8px 25px;
            font-size: 18px;
        }

        .wizard {
        }

            .wizard .nav-tabs {
                position: relative;
                margin: 40px auto;
                margin-bottom: 0;
                border-bottom-color: #e0e0e0;
            }

            .wizard > div.wizard-inner {
                position: relative;
            }

        .connecting-line {
            height: 2px;
            background: #e0e0e0;
            position: absolute;
            width: 80%;
            margin: 0 auto;
            left: 0;
            right: 0;
            top: 50%;
            z-index: 1;
        }

        .wizard .nav-tabs > li.active > a, .wizard .nav-tabs > li.active > a:hover, .wizard .nav-tabs > li.active > a:focus {
            color: #555555;
            cursor: default;
            border: 0;
            border-bottom-color: transparent;
        }

        span.round-tab {
            width: 70px;
            height: 70px;
            line-height: 70px;
            display: inline-block;
            border-radius: 100px;
            background: #fff;
            border: 2px solid #e0e0e0;
            z-index: 2;
            position: absolute;
            left: 0;
            text-align: center;
            font-size: 25px;
        }

            span.round-tab i {
                color: #555555;
            }

        .wizard li.active span.round-tab {
            background: #fff;
            border: 2px solid #16A085;
        }

            .wizard li.active span.round-tab i {
                color: #16A085;
            }

        span.round-tab:hover {
            color: #333;
            border: 2px solid #333;
        }

        .wizard .nav-tabs > li {
            width: 20%;
        }

        .wizard li:after {
            content: " ";
            position: absolute;
            left: 46%;
            opacity: 0;
            margin: 0 auto;
            bottom: 0px;
            border: 5px solid transparent;
            border-bottom-color: #16A085;
            transition: 0.1s ease-in-out;
        }

        .wizard li.active:after {
            content: " ";
            position: absolute;
            left: 46%;
            opacity: 1;
            margin: 0 auto;
            bottom: 0px;
            border: 10px solid transparent;
            border-bottom-color: #16A085;
        }

        .wizard .nav-tabs > li a {
            width: 70px;
            height: 70px;
            margin: 20px auto;
            border-radius: 100%;
            padding: 0;
        }

            .wizard .nav-tabs > li a:hover {
                background: transparent;
            }

        .wizard .tab-pane {
            position: relative;
            padding-top: 50px;
        }

        .wizard h3 {
            margin-top: 0;
        }

        @media( max-width : 585px ) {

            .wizard {
                width: 90%;
                height: auto !important;
            }

            span.round-tab {
                font-size: 16px;
                width: 50px;
                height: 50px;
                line-height: 50px;
            }

            .wizard .nav-tabs > li a {
                width: 50px;
                height: 50px;
                line-height: 50px;
            }

            .wizard li.active:after {
                content: " ";
                position: absolute;
                left: 35%;
            }
        }

        .box-title {
            border: none !important;
        }

        .box-header h3 {
            padding-bottom: 0 !important;
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
    <div class="main-container">
        <div class="container">
            <div class="row">
                <section>
                    <div class="wizard">
                        <div class="wizard-inner">
                            <div class="connecting-line"></div>
                            <ul class="nav nav-tabs" role="tablist">

                                <li role="presentation" class="disabled">
                                    <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="Kategori Seçimi">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-folder-open"></i>
                                        </span>
                                    </a>
                                </li>

                                <li role="presentation" class="active">
                                    <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="İlan Detay">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-pencil"></i>
                                        </span>
                                    </a>
                                </li>
                                <li role="presentation" class="disabled">
                                    <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Doping">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-picture"></i>
                                        </span>
                                    </a>
                                </li>
                                <li role="presentation" class="disabled">
                                    <a href="#step3" data-toggle="tab" aria-controls="step4" role="tab" title="Ödeme">
                                        <span class="round-tab">
                                            <i class="fa fa-credit-card"></i>
                                        </span>
                                    </a>
                                </li>

                                <li role="presentation" class="disabled">
                                    <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Tamamlandı">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-ok"></i>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <div role="form">
                            <div class="tab-content">
                                <div class="tab-pane active" role="tabpanel" id="step1">
                                    <div class="main-container">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-md-9 page-content">
                                                    <div class="inner-box category-content">
                                                        <h2 class="title-2 uppercase"><strong><i class="icon-user fa"></i>İletişim Bilgileri</strong></h2>

                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-horizontal">
                                                                    <fieldset>
                                                                        <div>
                                                                            <div class="col-md-12">
                                                                                <div class="form-group">
                                                                                    <div class="checkbox icheck">
                                                                                        <asp:CheckBox ID="numaraYayinlansin" type="checkbox" Text="Numara Yayınlansın" runat="server" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </fieldset>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="col-md-9 page-content">
                                                    <div class="inner-box category-content">
                                                        <h2 class="title-2 uppercase"><strong><i class="icon-docs"></i>İlan Detayları</strong></h2>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-horizontal">
                                                                    <fieldset>
                                                                        <div class="col-md-12">
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
                                                                        </div>

                                                                        <div class="box-footer" id="box_footer" runat="server">
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
                                                                <div>
                                                                </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3 reg-sidebar">
                                                    <div class="reg-sidebar-inner text-center">
                                                        <div class="promo-text-box">
                                                            <i class=" icon-picture fa fa-4x icon-color-1"></i>
                                                            <h3><strong>İlanlarını Ücretsiz Yayınla</strong></h3>
                                                            <p>
                                                                Post your free online classified ads with us. Lorem ipsum dolor sit amet, consectetur
                                adipiscing elit.
                                                            </p>
                                                        </div>
                                                        <div class="panel sidebar-panel">
                                                            <div class="panel-heading uppercase">
                                                                <small><strong>How to sell quickly?</strong></small>
                                                            </div>
                                                            <div class="panel-content">
                                                                <div class="panel-body text-left">
                                                                    <ul class="list-check">
                                                                        <li>Use a brief title and description of the item</li>
                                                                        <li>Make sure you post in the correct category</li>
                                                                        <li>Add nice photos to your ad</li>
                                                                        <li>Put a reasonable price</li>
                                                                        <li>Check the item before publish</li>

                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-9 page-content">
                                                    <div class="inner-box category-content">
                                                        <h2 class="title-2 uppercase"><strong><i class="icon-address"></i>ADRES BİLGİLERİ</strong></h2>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-horizontal">
                                                                    <fieldset>
                                                                        <div class="col-md-4">
                                                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                                                        <%--<div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <div class="contact-intro">
                                                                                    <div class="w100 map">
                                                                                        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d26081603.294420466!2d-95.677068!3d37.06250000000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2s!4v1423809000824"
                                                                                            width="100%" height="350" frameborder="0" style="border: 0"></iframe>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>--%>
                                                                        <!-- terms -->
                                                                    </fieldset>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-9 page-content">
                                                    <div class="inner-box category-content">
                                                        <h2 class="title-2 uppercase"><strong><i class="icon-picture"></i>FOTOĞRAF</strong></h2>
                                                        <div class="row">
                                                            <div class="col-sm-12">
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
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-1 col-xs-offset-11" style="padding:0;">
                                                        <asp:Button ID="devam" runat="server" CssClass="btn btn-success" Text="Devam Et" OnClick="devam_Click1" Style="float: right; margin-top: 15px;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

    <script type='text/javascript'>

        $(document).ready(function () {
            document.getElementById("ContentPlaceHolder1_FileUpload1").style.display = "none";
        });
        function triggerFileUpload() {
            document.getElementById("ContentPlaceHolder1_FileUpload1").click();
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
                            var element = "<div class='col-xs-6 col-sm-3 resimler'>" +
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
    <script>
        $(document).ready(function () {
            //Initialize tooltips
            $('.nav-tabs > li a[title]').tooltip();

            //Wizard
            $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

                var $target = $(e.target);

                if ($target.parent().hasClass('disabled')) {
                    return false;
                }
            });

            $(".next-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                $active.next().removeClass('disabled');
                nextTab($active);

            });
            $(".prev-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                prevTab($active);

            });
        });

        function nextTab(elem) {
            $(elem).next().find('a[data-toggle="tab"]').click();
        }
        function prevTab(elem) {
            $(elem).prev().find('a[data-toggle="tab"]').click();
        }
    </script>


    <!-- include carousel slider plugin  -->
    <script src="libraries/assets/js/owl.carousel.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.4.3/standard/ckeditor.js"></script>
    <script>

        window.onload = function () {

            var editor = CKEDITOR.replace('<% = txtCKeditorAdi.ClientID %>');

        };

    </script>
    <%--    <script src="management/plugins/dropzone/dropzone.js"></script>--%>
    <script type='text/javascript'>

        Dropzone.options.myDropzone = {

            // Prevents Dropzone from uploading dropped files immediately
            autoProcessQueue: false,

            init: function () {
                var submitButton = document.querySelector("#submit-all")
                myDropzone = this; // closure

                submitButton.addEventListener("click", function () {
                    myDropzone.processQueue(); // Tell Dropzone to process all queued files.
                });

                // You might want to show the submit button only when 
                // files are dropped here:
                this.on("addedfile", function () {
                    // Show submit button here and/or inform user to click it.
                });

            }
        };
    </script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/select2/select2.full.min.js") %>'></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            //Initialize Select2 Elements
            $(".select2").select2();
        });
        $('.double').keypress(function (event) {
            if ((event.which != 44 || $(this).val().indexOf(',') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        jQuery('.metrekare').on('input propertychange paste', function () {
            if ($(this).val() != "") {
                if ($("#ContentPlaceHolder1_ctl00_txtFiyat").val() != "") {
                    $(".metrekareFiyat").val(((parseFloat($("#ContentPlaceHolder1_txtFiyat").val().replace(",", ".")) /
                                                                                parseFloat($(".metrekare").val().replace(",", "."))).toFixed(2)).replace(".", ","));
                }
            }
            else {
                $(".metrekareFiyat").val("");
            }
        });

        jQuery('#ContentPlaceHolder1_ctl00_txtFiyat').on('input propertychange paste', function () {
            if ($(this).val() != "") {
                if ($(".metrekare").val() != "") {
                    $(".metrekareFiyat").val(((parseFloat($("#ContentPlaceHolder1_txtFiyat").val().replace(",", ".")) /
                                                                                parseFloat($(".metrekare").val().replace(",", "."))).toFixed(2)).replace(".", ","));
                }
            }
            else {
                $(".metrekareFiyat").val("");
            }
        });

    </script>
    <script src="management/dist/js/app.min.js"></script>
</asp:Content>
