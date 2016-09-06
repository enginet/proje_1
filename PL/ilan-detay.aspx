<%@ Page Title="Buraya ilan başlığı gelecek" Language="C#" MasterPageFile="~/site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ilan-detay.aspx.cs" Inherits="PL.ilan_detaylari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .box-title {
            padding: 0px;
            border: 0px;
        }
    </style>
    <link href="libraries/assets/plugins/bxslider/jquery.bxslider.css" rel="stylesheet" />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <link href="libraries/assets/css/owl.carousel.css" rel="stylesheet" />
    <link href="libraries/assets/css/owl.theme.css" rel="stylesheet" />

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDFMOi-Vi2hXZROzNxUjmg9keIYxvsyuxM&callback=initMap" async defer></script>
    <script type="text/javascript">

        var index = 0;

        function initMap(ilan) {
            var map;
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 6,
                center: { lat: 39, lng: 36 },
                mapTypeId: google.maps.MapTypeId.ROAD
            });


            //var layer = new google.maps.FusionTablesLayer({
            //    query: {
            //        select: '',
            //        from: '420419',
            //        where: 'name_0=\'Turkey\''
            //    },
            //    styles: [{
            //        polygonOptions: {
            //            fillColor: "#00FF00",
            //            fillOpacity: 0.1,
            //            strokeColor: "#000000",
            //            strokeWeight: 0.5
            //        }
            //    }]
            //});

            //layer.setMap(map);

            for (var i = 0; i < ilan.length; i++) {

                if (ilan[i]["koordinat"] != "-1") {
                    var koordinatlar = [];

                    var renk = "";

                    if (ilan[i]["magazaId"] != "-1") {
                        //emlakçıdan
                        if (ilan[i]["kimden"] == 2) {
                            renk = '#2a0cae';
                        }

                        //belediyeden
                        if (ilan[i]["kimden"] == 3) {
                            renk = '#6a12bc';
                        }

                        //bankadan
                        if (ilan[i]["kimden"] == 4) {
                            renk = '#fffc00';
                        }

                        //izaley-i şuyudan
                        if (ilan[i]["kimden"] == 5) {
                            renk = '#a0fcff';
                        }

                        //icradan
                        if (ilan[i]["kimden"] == 6) {
                            renk = '#ffb400';
                        }

                        //milli hazineden (sayışı devam eden)
                        if (ilan[i]["kimden"] == 7) {
                            renk = '#9d9d9d';
                        }

                        //milli hazineden (satılamayan)
                        if (ilan[i]["kimden"] == 8) {
                            renk = '#86ed00';
                        }

                        //özelleştirme idaresinden
                        if (ilan[i]["kimden"] == 9) {
                            renk = '#8b8b8b';
                        }

                        //inşaat firmasından
                        if (ilan[i]["kimden"] == 10) {
                            renk = '#fa5fd7';
                        }

                        //diğer kamu kurumlarından
                        if (ilan[i]["kimden"] == 11) {
                            renk = '#e3fffe';
                        }
                    }
                    else {
                        renk = '#ff0000';
                    }

                    for (var j = 0; j < ilan[i]["koordinat"]["coordinates"][0][0].length; j++) {
                        koordinatlar.push({ lat: ilan[i]["koordinat"]["coordinates"][0][0][j][1], lng: ilan[i]["koordinat"]["coordinates"][0][0][j][0]});
                    }

                    var sekil = "sekil" + index;
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
                        title: "konum"
                    });

                    index++;
                    map.setZoom(17);
                    map.setCenter({ lat: koordinatlar[0]["lat"], lng: koordinatlar[0]["lng"] });
                }
                else {
                    $("#konum").css("display", "none");
                    $("#ilan_detay").addClass("active");
                    $(".tab-pane").removeClass("active")
                    $("#tab2").addClass("active")
                }
            }
        }
    </script>
    <div class="main-container">
        <div class="container">
            <ol class="breadcrumb pull-left">
<%--                <li><a href="#"><i class="icon-home fa"></i></a></li>
                <li><a href="category.html">All Ads</a></li>
                <li><a href="sub-category-sub-location.html">Electronics</a></li>
                <li class="active">Mobile Phones</li>--%>
            </ol>
            <div class="pull-right backtolist">
<%--                <a href="sub-category-sub-location.html"><i
                    class="fa fa-angle-double-left"></i>Arama sonuçlarına geri dön</a>--%>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-9 page-content col-thin-right">
                    <div class="inner inner-box ads-details-wrapper">
                        <h2>
                            <asp:Label ID="lblBaslik" runat="server"></asp:Label>
                            <small class="label label-default adlistingtype">
                                <asp:Label ID="lblkimdenTop" runat="server"></asp:Label></small>
                        </h2>
                        <span class="info-row"><span class="date"><i class=" icon-clock"></i>
                            <asp:Label ID="lblTarih" runat="server"></asp:Label></span>- <span
                                class="category">
                                <asp:Label ID="lblCat" runat="server"></asp:Label>
                            </span>- <span class="item-location"><i
                                class="fa fa-map-marker"></i>
                                <asp:Label ID="lblIl" runat="server"></asp:Label>
                            </span></span>

                        <div class="ads-image" runat="server" id="notImage" visible="false">
                            <h1 class="pricetag">
                                <asp:Label ID="notlblFiyat" runat="server"></asp:Label></h1>
                            <ul class="bxslider">

                                <li>
                                    <img src='upload/ilan/not-found-image.jpg' alt="img" /></li>
                            </ul>
                            <div id="bx-pager">

                                <a class="thumb-item-link" data-slide-index="0" href="">
                                    <img
                                        src='upload/ilan/not-found-image.jpg' alt="img" /></a>
                            </div>
                        </div>


                        <div class="ads-image" runat="server" id="foundImage" visible="false">
                            <h1 class="pricetag">
                                <asp:Label ID="lblFiyat" runat="server"></asp:Label></h1>
                            <ul class="bxslider">
                                <asp:Repeater ID="sliderRepeater" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img src='upload/ilan/<%# Eval("resim") %>' alt="img" /></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div id="bx-pager">
                                <asp:Repeater ID="pagerRepeater" runat="server">
                                    <ItemTemplate>
                                        <a class="thumb-item-link" data-slide-index='<%# Convert.ToInt32(Eval("resim").ToString().Split('_')[1].Split('.')[0])-1 %>' href="">
                                            <img
                                                src='upload/ilan/<%# Eval("resim") %>' alt="img" /></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--ads-image-->

                        <div class="Ads-Details">
                            <h5 class="list-title"><strong>İlan Detayları</strong></h5>

                            <div class="row">
                                <div class="ads-details-info col-md-8">

                                    <div class="ads-action">
                                        <ul class="list-border">
                                            <li><strong>İlan No:</strong>&nbsp;
                                                <asp:Label ID="lblNo" runat="server"></asp:Label></li>
                                            <li><strong>İlan Tarihi:</strong>&nbsp;
                                                <asp:Label ID="lblIlanTarih" runat="server"></asp:Label></li>
                                            <li><strong>Emlak Tipi:</strong>&nbsp;
                                                <asp:Label ID="lblTip" runat="server"></asp:Label></li>
                                            <asp:Repeater runat="server" ID="girilenRepeater">
                                                <ItemTemplate>
                                                    <li><strong><%# Eval("ozellikAdi") %>: </strong>&nbsp; <%# Eval("deger") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Repeater runat="server" ID="secilebilirRepeater">
                                                <ItemTemplate>
                                                    <li><strong><%# Eval("ozellikAdi") %>: </strong>&nbsp; <%# Eval("deger") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <li><strong>Kimden:</strong>&nbsp;
                                                <asp:Label ID="lblkimden" runat="server"></asp:Label></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="ads-action">
                                        <ul class="list-border">
                                            <li>
                                                <asp:LinkButton ID="favoriLink" runat="server" OnClick="favoriLink_Click"><i class="fa fa-heart"></i>Favorilerime Ekle</asp:LinkButton>
                                                <asp:LinkButton ID="favoriCikar" runat="server" OnClick="favoriCikar_Click"><i class="fa fa-heart"></i>Favorilerime Eklendi</asp:LinkButton></li>
                                            <li><a href="#"><i class="fa fa-facebook"></i>Facebook ile Paylaş </a></li>
                                            <li><a href="#"><i class="fa fa-twitter"></i>Twitter ile Paylaş </a></li>
                                            <li><a href='#'><i class="fa fa-google-plus"></i>Google Plus ile Paylaş </a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <%--                            <div class="content-footer text-left">
                                <a class="btn  btn-default" data-toggle="modal"
                                    href="#contactAdvertiser"><i
                                        class=" icon-mail-2"></i>Send a message </a><a class="btn  btn-info"><i
                                            class=" icon-phone-1"></i>01680 531 352 </a>
                            </div>--%>
                        </div>
                    </div>
                    <!--/.ads-details-wrapper-->

                </div>
                <!--/.page-content-->
                <div class="col-sm-3  page-sidebar-right">
                    <aside>
                        <div class="panel sidebar-panel panel-contact-seller">
                            <div class="panel-heading"></div>
                            <div class="panel-content user-info">
                                <div class="panel-body text-center">
                                    <div class="seller-info">
                                        <div class="col-md-12 no-padding photobox">
                                            <div class="add-image">
                                                <a href="ads-details.html">
                                                    <img
                                                        class="thumbnail no-margin" src='upload/magaza/<%= sellerProfil %>'
                                                        alt="img" /></a>
                                            </div>
                                        </div>

                                        <h3 class="no-margin">
                                            <br />
                                            <asp:Label ID="lblSatici" runat="server"></asp:Label></h3>

                                        <p><strong></strong></p>

                                        <p><strong></strong></p>
                                    </div>
                                    <div class="user-ads-action">
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-success btn-block" runat="server" OnClick="LinkButton3_Click"><i class=" icon-docs"></i> Tüm İlanları</asp:LinkButton>

                                        <%--                                        <asp:HyperLink ID="HyperLink1" CssClass="btn btn-danger btn-block" NavigateUrl='<%# Eval(magazaId,"~/magaza-profil.aspx?store={0}") %>' runat="server"><i class=" icon-docs"></i> Tüm İlanları</asp:HyperLink>--%>
                                        <%--<asp:HyperLink ID="HyperLink2" CssClass="btn btn-danger btn-block" NavigateUrl='<%# Eval(kullaniciId,"~/magaza-profil.aspx?store={0}") %>' runat="server"><i class=" icon-docs"></i> Tüm İlanları</asp:HyperLink>--%>

                                        <%-- <asp:HyperLink ID="HyperLink2" CssClass="btn btn-success btn-block" runat="server"><i class=" icon-plus"></i> Takip Et</asp:HyperLink>
                                         <asp:HyperLink ID="HyperLink3" CssClass="btn btn-danger btn-block" runat="server"><i class=" icon-minus"></i> Takibi Bırak</asp:HyperLink>--%>

                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success btn-block" runat="server" OnClick="LinkButton1_Click"><i class=" icon-plus"></i> Takip Et</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger btn-block" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-minus"></i> Takibi Bırak</asp:LinkButton>

                                        <a href="#contactAdvertiser" data-toggle="modal"
                                            class="btn btn-success btn-block"><i
                                                class=" icon-mail-2"></i>Soru Sor </a>
                                        <asp:Repeater ID="telefonRepater" runat="server">
                                            <ItemTemplate>
                                                <a
                                                    class="btn btn-info btn-block"><i class="icon-phone-1"></i>
                                                    <%# telefonTurDondur(Eval("telefonTur")) %>  <%# Eval("telefon") %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel sidebar-panel">
                            <div class="panel-heading">Güvenlik İpuçları</div>
                            <div class="panel-content">
                                <div class="panel-body text-left">
                                    <%-- <ul class="list-check">
                                        <li>Meet seller at a public place</li>
                                        <li>Check the item before you buy</li>
                                        <li>Pay only after collecting the item</li>
                                    </ul>
                                    <p>
                                        <a class="pull-right" href="#">Know more <i
                                            class="fa fa-angle-double-right"></i></a>
                                    </p>--%>
                                </div>
                            </div>
                        </div>
                        <div class="inner-box no-padding">
                            <div class="inner-box-content">
                                <a href="#">
                                    <asp:Image ID="kutu1Rklm" runat="server" Style="width: 100%; height: 230px;" />
                            </div>
                        </div>
                        <!--/.categories-list-->
                    </aside>
                </div>

                <div class="col-lg-12 content-box ">
                    <div class="row row-featured">

                        <div style="clear: both"></div>

                        <div class=" relative  content  clearfix">
                            <div class="">
                                <div class="tab-lite">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs " role="tablist">
                                        <li role="presentation" id="konum" class="active"><a href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab"><i class="icon-location-2"></i>Konumu</a></li>
                                        <li role="presentation" id="ilan_detay"><a href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab"><i class="icon-search"></i>İlan Detayları</a></li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane active" id="tab1">
                                            <div class="col-lg-12 tab-inner">
                                                <div class="intro-inner">
                                                    <div class="contact-intro">
                                                        <div id="map" style="width: 100%; height: 350px;">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div role="tabpanel" class="tab-pane" id="tab2">
                                            <div class="col-lg-12 tab-inner">
                                                <div class="row" runat="server" id="box_footer">
                                                    <div class="form-group">
                                                        <div class="box box-primary collapsed-box box-solid">
                                                            <div class="box-header with-border">
                                                                <h3 class="box-title">Açıklama</h3>
                                                                <div class="box-tools pull-right">
                                                                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                                                                </div>
                                                                <!-- /.box-tools -->
                                                            </div>
                                                            <!-- /.box-header -->
                                                            <div class="box-body" id="lblAciklama" runat="server">
                                                                <%--                <div class="form-group" id="lblAciklama" runat="server">
                                                                </div>--%>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </div>
                                                        <!-- /.box -->
                                                    </div>
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
                                                </div>
                                            </div>
                                        </div>
                                        <div role="tabpanel" class="tab-pane" id="tab3">
                                            <div class="col-lg-12 tab-inner">
                                                <div class="row">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--/.page-side-bar-->
            </div>
        </div>
    </div>
    <!-- /.main-container -->

    <!-- Modal contactAdvertiser -->
    <div class="modal fade" id="reportAdvertiser" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span
                            class="sr-only">Close</span></button>
                    <h4 class="modal-title"><i class="fa icon-info-circled-alt"></i>There's something wrong with this ads?
                    </h4>
                </div>
                <div class="modal-body">
                    <div role="form">
                        <div class="form-group">
                            <label for="report-reason" class="control-label">Reason:</label>
                            <select name="report-reason" id="report-reason" class="form-control">
                                <option value="">Select a reason</option>
                                <option value="soldUnavailable">Item unavailable</option>
                                <option value="fraud">Fraud</option>
                                <option value="duplicate">Duplicate</option>
                                <option value="spam">Spam</option>
                                <option value="wrongCategory">Wrong category</option>
                                <option value="other">Other</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="recipient-email" class="control-label">Your E-mail:</label>
                            <input type="text" name="email" maxlength="60" class="form-control" id="recipient-email">
                        </div>
                        <div class="form-group">
                            <label for="message-text2" class="control-label">Message <span class="text-count">(300) </span>:</label>
                            <textarea class="form-control" id="message-text2"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary">Send Report</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /.modal -->

    <!-- Modal contactAdvertiser -->

    <div class="modal fade" id="contactAdvertiser" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span
                            class="sr-only">Close</span></button>
                    <h4 class="modal-title"><i class=" icon-mail"></i>Soru Sor </h4>
                </div>
                <div class="modal-body">
                    <div role="form">
                        <div class="item-list">
                            <div class="col-sm-2 no-padding photobox">
                                <div class="add-image">
                                    <span class="photo-count"><i
                                        class="fa fa-hashtag" runat="server" id="txtid"></i></span><a href="ads-details.html">
                                            <img
                                                class="thumbnail no-margin" src='upload/ilan/<%= postResim %>'
                                                alt="img"></a>
                                </div>
                            </div>
                            <!--/.photobox-->
                            <div class="col-sm-5 add-desc-box">
                                <div class="add-details">
                                    <h5 class="add-title">
                                        <asp:HyperLink ID="hypBaslik" runat="server"></asp:HyperLink>
                                    </h5>
                                    <span class="info-row"><span class="add-type business-ads tooltipHere"
                                        data-toggle="tooltip"
                                        data-placement="right"
                                        title="Business Ads">B </span><span
                                            class="date" runat="server" id="txtTarih"><i class=" icon-clock"></i></span>- <span
                                                class="category" runat="server" id="txtkategori"></span>- <span
                                                    class="item-location" runat="server" id="txtIl"><i class="fa fa-map-marker"></i></span></span>
                                </div>
                            </div>
                            <!--/.add-desc-box-->
                            <div class="col-sm-5 text-right  price-box">
                                <h2 class="item-price">
                                    <asp:Label ID="lblPostfiyaTur" runat="server"></asp:Label>
                                    <asp:Label ID="lblPostFiyat" runat="server"></asp:Label></h2>
                            </div>
                            <!--/.add-desc-box-->
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="control-label">Mesajınız </label>
                            <textarea class="form-control" id="txtMesaj"
                                data-placement="top" data-trigger="manual" runat="server"></textarea>
                        </div>
                        <div class="form-group">
                            <p class="help-block pull-left text-danger hide" id="form-error">
                                &nbsp; The form is not
                            valid.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Vazgeç</button>
                    <asp:Button ID="Gonder" CssClass="btn btn-success pull-right" runat="server" OnClick="Gonder_Click" Text="Gönder" />
                </div>
            </div>
        </div>
    </div>


    <script src="libraries/assets/js/form-validation.js"></script>

    <script src="libraries/assets/plugins/bxslider/jquery.bxslider.min.js"></script>

    <script>
        $('.bxslider').bxSlider({
            pagerCustom: '#bx-pager'
        });
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
    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/select2/select2.full.min.js") %>'></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
            $(".box.box-primary.box-solid.collapsed-box").removeClass("collapsed-box");
            $(".box-tools.pull-right").css("display", "none");

            $(".icheckbox_square-blue").addClass("disabled");

            $(".icheckbox_square-blue input").attr("disabled", "disabled");
        });

        $("#konum a:first-child").css("display", "none");
    </script>
    <script src="management/dist/js/app.min.js"></script>
</asp:Content>
