<%@ Page Title="netteilanver" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PL._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href="libraries/assets/css/owl.carousel.css" rel="stylesheet" />
    <link href="libraries/assets/css/owl.theme.css" rel="stylesheet" />

    <div class="intro" style="background-image: url('../libraries/images/bg3.jpg');">
        <div class="dtable hw100">
            <div class="dtable-cell hw100">
                <div class="container text-center">
                    <h1 class="intro-title animated fadeInDown">Hemen İlan ara </h1>

                    <p class="sub animateme fittext3 animated fadeIn">
                        Tüm ilanlara ulaşmak senin elinde
                    </p>

                    <div class="row search-row animated fadeInUp text-center">
                      <div class="col-lg-4 col-sm-4 search-col relative locationicon">
                            <i class="icon-location-2 icon-append"></i>
                            <input type="text" name="country" disabled id="autocomplete-ajax"
                                class="form-control locinput input-rel  searchtag-input has-icon"
                                placeholder="Tüm şehirlerde" value="">
                        </div>
                        <div class="col-lg-4 col-sm-4 search-col relative">
                            <i class="icon-docs icon-append"></i>
                            <input type="text" name="ads" class="form-control has-icon " runat="server" id="txtAra"
                                placeholder="Kelime veya ilan no ile ara..." value="">
                        </div>
                        <div class="col-lg-4 col-sm-4 search-col">
                            <asp:LinkButton ID="AraBtn" runat="server" CssClass="btn btn-success btn-search btn-block" OnClick="Ara_Click"> <i
                                    class="icon-search"></i><strong>Ara</strong></asp:LinkButton>

<%--                            <button class="btn btn-success btn-search btn-block" runat="server" onclick="Ara_Click">
                                <i
                                    class="icon-search"></i><strong>Ara</strong></button>--%>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- /.intro -->

    <div class="main-container">
        <div class="container">

            <div class="col-lg-12 content-box ">
                <div class="row row-featured row-featured-category">
                    <div class="col-lg-12  box-title no-border">
                        <div class="inner">
                            <h2><span>ANASAYFA</span>
                                VİTRİNİ <a href="#" class="sell-your-item">TÜMÜNÜ GÖSTER <i
                                    class="  icon-th-list"></i></a></h2>
                        </div>
                    </div>
                    <asp:Repeater ID="anaVitrinRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-4 f-category">
                                <asp:HyperLink ID="hypBaslik" runat="server" NavigateUrl='<%# String.Format("~/ilan-detay.aspx?{0}&ilan={1}", DAL.toolkit.UrlDonustur(Eval("baslik")),Eval("ilanId")) %>'>
                                    <img src='upload/ilan/<%# Eval("resim") %>' class="img-responsive" alt="img" />
                                    <h6><%# Eval("baslik") %> </h6>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-9 page-content col-thin-right">
                    <div class="inner-box category-content">
                        <h2 class="title-2">KATEGORİLER </h2>

                        <div class="row">
                            <div class="col-md-4 col-sm-4 ">
                                <div class="cat-list">
                                    <h3 class="cat-title"><a href="#"><i class="icon-home ln-shadow"></i>
                                        Emlak <span class="count">228,705</span></a> <span data-target=".cat-id-4"
                                            data-toggle="collapse"
                                            class="btn-cat-collapsed collapsed"><span
                                                class=" icon-down-open-big"></span></span></h3>
                                    <ul class="cat-collapse collapse in cat-id-2">
                                        <asp:Repeater ID="kategoriRepeater" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <li>
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# catKind(Eval("kategoriId"))==true?Eval("kategoriId","~/kategoriler.aspx?kategoriId={0}")
                                                                 :String.Format("~/ilan-liste.aspx?kategoriId={0}",Eval("kategoriId") )
                                                                              %>'> <%# Eval("kategoriAdi") %></asp:HyperLink>
                                                        <%--                                                        <asp:HyperLink ID="hypTur" NavigateUrl='<%# GetRouteUrl("kategori", new { kategoriAd = DAL.toolkit.UrlDonustur(Eval("kategoriAdi")), kategoriId = Eval("kategoriId")  }) %>' runat="server"><%# Eval("kategoriAdi") %></asp:HyperLink>--%>
                                                    </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 ">
                                <div class="cat-list">
                                    <h3 class="cat-title"><a href="#"><i
                                        class="fa fa-star ln-shadow"></i>DOPİNGLİ İLANLAR <span
                                            class="count">45,526</span></a>
                                        <span data-target=".cat-id-5" data-toggle="collapse"
                                            class="btn-cat-collapsed collapsed"><span
                                                class=" icon-down-open-big"></span></span>
                                    </h3>
                                    <ul class="cat-collapse collapse in cat-id-4">

                                        <li>
                                            <asp:HyperLink ID="HyperLink1" runat="server">Acil Acil</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink2" runat="server">Fiyatı Düşenler</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink3" runat="server">Son 48 Saat</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Son 1 Hafta</asp:HyperLink></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4   last-column">
                                <div class="cat-list">
                                    <h3 class="cat-title"><a href="#"><i
                                        class="fa fa-thumbs-up ln-shadow"></i>SİZDEN GELENLER <span
                                            class="count">45,526</span></a>
                                        <span data-target=".cat-id-3" data-toggle="collapse"
                                            class="btn-cat-collapsed collapsed"><span
                                                class=" icon-down-open-big"></span></span>
                                    </h3>
                                    <ul class="cat-collapse collapse in cat-id-4">
                                        <li>
                                            <asp:HyperLink ID="HyperLink5" runat="server">İlan Deneyimini Bizimle Paylaş</asp:HyperLink></li>

                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="inner-box has-aff relative">
                        <a class="dummy-aff-img" href="#">
                            <img src="libraries/images/aff2.jpg" class="img-responsive"
                                alt=" aff">
                        </a>

                    </div>
                    <div class="col-lg-12 content-box ">
                        <div class="row row-featured">
                            <div class="col-lg-12  box-title ">
                                <div class="inner">
                                    <h2><span>ACİL </span>
                                        İLANLAR <a href="#" class="sell-your-item">TÜMÜNÜ GÖSTER <i
                                            class="  icon-th-list"></i></a></h2>
                                </div>
                            </div>

                            <div style="clear: both"></div>

                            <div class=" relative  content featured-list-row clearfix">

                                <nav class="slider-nav has-white-bg nav-narrow-svg">
                                    <a class="prev">
                                        <span class="nav-icon-wrap"></span>

                                    </a>
                                    <a class="next">
                                        <span class="nav-icon-wrap"></span>
                                    </a>
                                </nav>

                                <div class="no-margin featured-list-slider ">
                                    <asp:Repeater ID="acilRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="item">
                                                <asp:HyperLink ID="hypAcil" runat="server" NavigateUrl='<%# String.Format("~/ilan-detay.aspx?{0}&ilan={1}", DAL.toolkit.UrlDonustur(Eval("baslik")),Eval("ilanId")) %>'>
                                                    <span class="item-carousel-thumb">
                                                        <img class="img-responsive" src='upload/ilan/<%# Eval("resim") %>' alt="img">
                                                    </span>
                                                    <span class="item-name"><%# Eval("baslik") %>  </span>
                                                    <span class="price"><%# Eval("fiyat") %> <%# fiyat_Tur(Eval("fiyatTurId")) %> </span>
                                                </asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 content-box ">
                        <div class="row row-featured">
                            <div class="col-lg-12  box-title ">
                                <div class="inner">
                                    <h2><span>Son </span>
                                        48 Saat<a href="#" class="sell-your-item">TÜMÜNÜ GÖSTER <i
                                            class="  icon-th-list"></i></a></h2>
                                </div>
                            </div>

                            <div style="clear: both"></div>

                            <div class=" relative  content featured-list-row clearfix">

                                <nav class="slider-nav has-white-bg nav-narrow-svg">
                                    <a class="prev">
                                        <span class="nav-icon-wrap"></span>

                                    </a>
                                    <a class="next">
                                        <span class="nav-icon-wrap"></span>
                                    </a>
                                </nav>
                                <div class="no-margin featured-list-slider ">
                                    <asp:Repeater ID="sonSaatRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="item">
                                                <asp:HyperLink ID="hypSaat" runat="server" NavigateUrl='<%# krediKontrol(Eval("magazaId"))==true?
                                                        String.Format("~/ilan-detay.aspx?{0}&ilan={1}", DAL.toolkit.UrlDonustur(Eval("baslik")),Eval("ilanId")):"~/giris-yap.aspx"%>'>
                                                    <span class="item-carousel-thumb">
                                                        <img class="img-responsive" src='upload/ilan/<%# Eval("resim") %>' alt="img">
                                                    </span>
                                                    <span class="item-name"><%# Eval("baslik") %>  </span>
                                                    <span class="price"><%# Eval("fiyat") %> <%# fiyat_Tur(Eval("fiyatTurId")) %> </span>
                                                </asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="col-lg-12 content-box ">
                        <div class="row row-featured">

                            <div style="clear: both"></div>

                            <div class=" relative  content  clearfix">


                                <div class="">
                                    <div class="tab-lite">

                                        <!-- Nav tabs -->
                                        <ul class="nav nav-tabs " role="tablist">
                                            <li role="presentation" class="active"><a href="index.html" aria-controls="tab1"
                                                role="tab" data-toggle="tab"><i
                                                    class="icon-location-2"></i>EN ÇOK ARANANLAR </a></li>
                                            <li role="presentation"><a href="#tab2" aria-controls="tab2" role="tab"
                                                data-toggle="tab"><i class="icon-search"></i>POPÜLER ŞEHİRLER</a>
                                            </li>
                                            <li role="presentation"><a href="#tab3" aria-controls="tab3" role="tab"
                                                data-toggle="tab"><i class="icon-th-list"></i>POPÜLER KATEGORİLER</a>
                                            </li>
                                        </ul>

                                        <!-- Tab panes -->
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane active" id="tab1">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="#">Satılık daire </a></li>
                                                            <li><a href="#">Sahibinden villa </a></li>
                                                            <li><a href="#">Deniz manzaralı daire </a></li>
                                                            <li><a href="#">200 metrekare daire</a></li>
                                                            <li><a href="#">kiralık daire</a></li>
                                                            <li><a href="#">temiz daire </a></li>
                                                            <li><a href="#">her yere yakın daire</a></li>
                                                            <li><a href="#">Satılık işyeri </a></li>

                                                        </ul>


                                                    </div>

                                                </div>


                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab2">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="#">İstanbul </a></li>
                                                            <li><a href="#">Ankara </a></li>
                                                            <li><a href="#">İzmir </a></li>
                                                            <li><a href="#">İzmit</a></li>
                                                            <li><a href="#">Konya </a></li>
                                                            <li><a href="#">Trabzon </a></li>
                                                            <li><a href="#">Bursa</a></li>
                                                            <li><a href="#">Çanakkale </a></li>

                                                        </ul>


                                                        <ul class="cat-list col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="#">Çorum</a></li>
                                                            <li><a href="#">Erzurum </a></li>
                                                            <li><a href="#">Muğla </a></li>
                                                            <li><a href="#">Antalya </a></li>
                                                            <li><a href="#">Adana </a></li>
                                                            <li><a href="#">Afyon </a></li>
                                                            <li><a href="#">Aydın </a></li>
                                                            <li><a href="#">Yalova</a></li>
                                                        </ul>

                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab3">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="#">Daire  </a></li>
                                                            <li><a href="#">Residence </a></li>
                                                            <li><a href="#">Müstakil Ev </a></li>
                                                            <li><a href="#">Villa</a></li>
                                                            <li><a href="#">Çiftlik Evi </a></li>
                                                            <li><a href="#">Yalı</a></li>
                                                            <li><a href="#">Yalı Dairesi </a></li>
                                                            <li><a href="#">Yazlık </a></li>

                                                        </ul>


                                                        <ul class="cat-list col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="#">Arsa</a></li>
                                                            <li><a href="#">Köşk & Konuk </a></li>
                                                            <li><a href="#">Prefabrik Ev </a></li>
                                                            <li><a href="#">Fabrika </a></li>
                                                            <li><a href="#">Büfe </a></li>
                                                            <li><a href="#">Plaza Katı </a></li>
                                                            <li><a href="#">Dükkan & Mağaza </a></li>
                                                            <li><a href="#">Büro & Ofis</a></li>
                                                        </ul>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>

                </div>
                <div class="col-sm-3 page-sidebar col-thin-left">
                    <aside>
                        <div class="inner-box no-padding">
                            <div class="inner-box-content">
                                <a href="#">
                                    <img class="img-responsive"
                                        src="../libraries/images/site/app.jpg" alt="tv"></a>
                            </div>
                        </div>
                        <div class="inner-box">
                            <h2 class="title-2">POPÜLER KATEGORİLER </h2>

                            <div class="inner-box-content">
                                <ul class="cat-list arrow">
                                    <li><a href="sub-category-sub-location.html">Apparel (1,386) </a></li>
                                    <li><a href="sub-category-sub-location.html">Art (1,163) </a></li>
                                    <li><a href="sub-category-sub-location.html">Business Opportunities (4,974) </a>
                                    </li>
                                    <li><a href="sub-category-sub-location.html">Community and Events (1,258) </a></li>
                                    <li><a href="sub-category-sub-location.html">Electronics and Appliances
                                        (1,578) </a></li>
                                    <li><a href="sub-category-sub-location.html">Jobs and Employment (3,609) </a></li>
                                    <li><a href="sub-category-sub-location.html">Motorcycles (968) </a></li>
                                    <li><a href="sub-category-sub-location.html">Pets (1,188) </a></li>
                                    <li><a href="sub-category-sub-location.html">Services (7,583) </a></li>
                                    <li><a href="sub-category-sub-location.html">Vehicles (1,129) </a></li>
                                </ul>
                            </div>
                        </div>

                        <div class="inner-box no-padding">
                            <img class="img-responsive" src="../libraries/images/add2.jpg" alt="">
                        </div>
                    </aside>
                </div>
            </div>
        </div>
    </div>
    <!-- /.main-container -->
    <div class="page-info hasOverly" style="background: url(../libraries/images/bg.jpg); background-size: cover">
        <div class="bg-overly ">
            <div class="container text-center section-promo">
                <div class="row">
                    <div class="col-sm-3 col-xs-6 col-xxs-12">
                        <div class="iconbox-wrap">
                            <div class="iconbox">
                                <div class="iconbox-wrap-icon">
                                    <i class="icon  icon-group"></i>
                                </div>
                                <div class="iconbox-wrap-content">
                                    <h5><span>2200</span></h5>

                                    <div class="iconbox-wrap-text">Trusted Seller</div>
                                </div>
                            </div>
                            <!-- /..iconbox -->
                        </div>
                        <!--/.iconbox-wrap-->
                    </div>

                    <div class="col-sm-3 col-xs-6 col-xxs-12">
                        <div class="iconbox-wrap">
                            <div class="iconbox">
                                <div class="iconbox-wrap-icon">
                                    <i class="icon  icon-th-large-1"></i>
                                </div>
                                <div class="iconbox-wrap-content">
                                    <h5><span>100</span></h5>

                                    <div class="iconbox-wrap-text">Categories</div>
                                </div>
                            </div>
                            <!-- /..iconbox -->
                        </div>
                        <!--/.iconbox-wrap-->
                    </div>

                    <div class="col-sm-3 col-xs-6  col-xxs-12">
                        <div class="iconbox-wrap">
                            <div class="iconbox">
                                <div class="iconbox-wrap-icon">
                                    <i class="icon  icon-map"></i>
                                </div>
                                <div class="iconbox-wrap-content">
                                    <h5><span>700</span></h5>

                                    <div class="iconbox-wrap-text">Location</div>
                                </div>
                            </div>
                            <!-- /..iconbox -->
                        </div>
                        <!--/.iconbox-wrap-->
                    </div>

                    <div class="col-sm-3 col-xs-6 col-xxs-12">
                        <div class="iconbox-wrap">
                            <div class="iconbox">
                                <div class="iconbox-wrap-icon">
                                    <i class="icon icon-facebook"></i>
                                </div>
                                <div class="iconbox-wrap-content">
                                    <h5><span>50,000</span></h5>

                                    <div class="iconbox-wrap-text">Facebook Fans</div>
                                </div>
                            </div>
                            <!-- /..iconbox -->
                        </div>
                        <!--/.iconbox-wrap-->
                    </div>

                </div>

            </div>
        </div>
    </div>
    <!-- /.page-info -->

    <div class="page-bottom-info">
        <div class="page-bottom-info-inner">

            <div class="page-bottom-info-content text-center">
                <h1>If you have any questions, comments or concerns, please call the Classified Advertising department
                    at (000) 555-5555</h1>
                <a class="btn  btn-lg btn-primary-dark" href="tel:+9050732781 00">
                    <i class="icon-phone"></i><span class="hide-xs color50">7/24 Müşteri Hizmetleri:</span>(507) 327-8100 </a>
            </div>

        </div>
    </div>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/jquery.mockjax.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/jquery.autocomplete.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/usastates.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/autocomplete-demo.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>
</asp:Content>
