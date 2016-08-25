<%@ Page Title="Buraya kategori isimleri gelecek" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="ilan-liste.aspx.cs" Inherits="PL.ilan_liste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table td {
            vertical-align: middle !important;
        }

            .table td h5 {
                padding-bottom: 0 !important;
            }

        table.dataTable thead th {
            position: relative;
            background-image: none !important;
        }

            table.dataTable thead th.sorting:after,
            table.dataTable thead th.sorting_asc:after,
            table.dataTable thead th.sorting_desc:after {
                position: absolute;
                top: 12px;
                right: 8px;
                display: block;
                font-family: FontAwesome;
            }

            table.dataTable thead th.sorting:after {
                content: "\f0dc";
                color: #ddd;
                font-size: 0.8em;
                padding-top: 0.12em;
            }

            table.dataTable thead th.sorting_asc:after {
                content: "\f0de";
            }

            table.dataTable thead th.sorting_desc:after {
                content: "\f0dd";
            }
    </style>

    <div class="search-row-wrapper">
        <div class="container ">
            <div action="#" method="GET">
                <div class="col-sm-9">
                    <input class="form-control keyword" type="text" placeholder="e.g. Mobile Sale" />
                </div>

                <div class="col-sm-3">
                    <button class="btn btn-block btn-primary  "><i class="fa fa-search"></i></button>
                </div>
            </div>
        </div>
    </div>
    <!-- /.search-row -->

    <div class="main-container">
        <div class="container">
            <div class="row">
                <!-- this (.mobile-filter-sidebar) part will be position fixed in mobile version -->
                <div class="col-sm-3 page-sidebar mobile-filter-sidebar">
                    <aside>
                        <div class="inner-box">
                            <div class="categories-list  list-filter">
                                <h5 class="list-title"><strong>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx"><i class="fa fa-angle-left"></i>
                                    TÜM KATEGORİLER</asp:HyperLink></strong></h5>
                                <ul class=" list-unstyled">
                                    <li><a href="#"><span class="title"><strong runat="server" id="ustStr"></strong></span><span
                                        class="count">&nbsp;86626</span></a>
                                        <a href="#"><span class="title">&nbsp;<strong runat="server" id="altStr"></strong></span><span
                                            class="count">&nbsp;86626</span></a>
                                        <asp:HyperLink ID="HyperLink2" runat="server" Visible='<%# catKind(Eval("kategoriId"))==true?true:false %>'><span class="title">&nbsp;&nbsp;<strong runat="server"> <%= DAL.toolkit.donustur(Request.QueryString["tur"]) %></strong></span><span
                                        class="count">&nbsp;86626</span></asp:HyperLink>
                                        <ul class=" list-unstyled long-list">
                                            <asp:Repeater ID="kategoriRepeater" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:HyperLink ID="hypKategori" runat="server" NavigateUrl='<%# String.Format("~/ilan-liste.aspx?kategoriId={0}&tur={1}&sub={2}",Request.QueryString["kategoriId"],Request.QueryString["tur"], Eval("kategoriId") ) %>'><%# Eval("kategoriAdi") %><span class="count">(143)</span></asp:HyperLink></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ul>
                            </div>



                            <div class="locations-list  list-filter">
                                <h5 class="list-title"><strong><a href="#">Price range</a></strong></h5>

                                <div role="form" class="form-inline ">
                                    <div class="form-group col-sm-4 no-padding">
                                        <input type="text" placeholder="$ 2000 " id="minPrice" class="form-control">
                                    </div>
                                    <div class="form-group col-sm-1 no-padding text-center hidden-xs">-</div>
                                    <div class="form-group col-sm-4 no-padding">
                                        <input type="text" placeholder="$ 3000 " id="maxPrice" class="form-control">
                                    </div>
                                    <div class="form-group col-sm-3 no-padding">
                                        <button class="btn btn-default pull-right btn-block-xs" type="submit">
                                            GO
                                        </button>
                                    </div>
                                </div>
                                <div style="clear: both"></div>
                            </div>
                            <!--/.list-filter-->
                            <div class="locations-list  list-filter">
                                <h5 class="list-title"><strong><a href="#">Seller</a></strong></h5>
                                <ul class="browse-list list-unstyled long-list">
                                    <li><a href="sub-category-sub-location.html"><strong>All Ads</strong> <span
                                        class="count">228,705</span></a></li>
                                    <li><a href="sub-category-sub-location.html">Business <span
                                        class="count">28,705</span></a></li>
                                    <li><a href="sub-category-sub-location.html">Personal <span
                                        class="count">18,705</span></a></li>
                                </ul>
                            </div>
                            <!--/.list-filter-->
                            <div class="locations-list  list-filter">
                                <h5 class="list-title"><strong><a href="#">Condition</a></strong></h5>
                                <ul class="browse-list list-unstyled long-list">
                                    <li><a href="sub-category-sub-location.html">New <span class="count">228,705</span></a>
                                    </li>
                                    <li><a href="sub-category-sub-location.html">Used <span class="count">28,705</span></a>
                                    </li>
                                    <li><a href="sub-category-sub-location.html">None </a></li>
                                </ul>
                            </div>
                            <!--/.list-filter-->
                            <div style="clear: both"></div>
                        </div>

                        <!--/.categories-list-->
                    </aside>
                </div>
                <!--/.page-side-bar-->
                <div class="col-sm-9 page-content col-thin-left">
                    <div class="category-list">
<div class="tab-box ">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs add-tabs" role="tablist">
                                <li class="active" ><a href='<%= Page.ResolveUrl("~/ilan-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab"
                                    >Tüm İlanlar <span class="badge">228,705</span></a>
                                </li>
                                <li><a href='<%= Page.ResolveUrl("~/sahibinden-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Sahibinden
                                    <span class="badge">22,805</span></a></li>
                                <li><a href='<%= Page.ResolveUrl("~/emlak-ofis-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Emlak Ofisi
                                    <span class="badge">18,705</span></a></li>

                                <li><a href='<%= Page.ResolveUrl("~/insaat-firmasi-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >İnşaat Firması
                                    <span class="badge">18,705</span></a></li>
                                <li role="presentation" class="dropdown">
                                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Diğer<span class="caret"></span>
                                    </a>
                                    <ul class="dropdown-menu">
                                <li><a href='<%= Page.ResolveUrl("~/bankadan-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Banka
                                    <span class="badge">18,705</span></a></li>

                                <li><a href='<%= Page.ResolveUrl("~/izale-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >İzale-i Şuyu
                                    <span class="badge">18,705</span></a></li>
                                                                        <li><a href='<%= Page.ResolveUrl("~/belediye-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Belediye
                                    <span class="badge">18,705</span></a></li>
                                                                        <li><a href='<%= Page.ResolveUrl("~/icra-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">İcra
                                    <span class="badge">18,705</span></a></li>
                         <li><a href='<%= Page.ResolveUrl("~/milli-hazine-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Milli Hazine
                                    <span class="badge">18,705</span></a></li>
                         <li><a href='<%= Page.ResolveUrl("~/özellestirme-idaresi-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Özelleştirme İdaresi
                                    <span class="badge">18,705</span></a></li>
                                                                 <li><a href='<%= Page.ResolveUrl("~/kamu-kurumlari-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab" >Kamu Kurumları
                                    <span class="badge">18,705</span></a></li>
                                    </ul>
                                </li>

<%--                                <li><a href='#' role="tab" data-toggle="tab">Diğer
                                    <span class="badge">18,705</span></a></li>--%>
                            </ul>
                            <div class="tab-filter">
                            </div>
                        </div>
                        <!--/.tab-box-->


                        <!--/.listing-filter-->

                        <!-- Mobile Filter bar-->
                        <div class="mobile-filter-bar col-lg-12  ">
                            <ul class="list-unstyled list-inline no-margin no-padding">
                                <li class="filter-toggle">
                                    <a class="">
                                        <i class="  icon-th-list"></i>
                                        Filters
                                    </a>
                                </li>
                                <li>
                                 <div class="dropdown">
                                        <a data-toggle="dropdown" class="dropdown-toggle"><i class="caret "></i>Short
                                            by </a>
                                        <ul class="dropdown-menu">
                                            <li><a href="" rel="nofollow">Relevance</a></li>
                                            <li><a href="" rel="nofollow">Date</a></li>
                                            <li><a href="" rel="nofollow">Company</a></li>
                                        </ul>
                                    </div>

                                </li>
                            </ul>
                        </div>
                        <div class="menu-overly-mask"></div>
                        <!-- Mobile Filter bar End-->


                        <div class="adds-wrapper">
                            <div class="tab-content">
                                <%--                                <div class="tab-pane active" id="allAds">Loading...</div>--%>
                                <br />
                                <br />
                                <table id="example1" class="col-md-9 table table-responsive table-hover table-bordered text-center">
                                    <thead>
                                        <tr>
                                            <th class="col-md-2"></th>
                                            <th class="col-md-3">İlan Başlığı</th>
                                            <th class="col-md-1" runat="server" visible='<%# Convert.ToInt32(Request.QueryString["kategoriId"])==2?true:false %>'>m<sup>2</sup></th>
                                            <th class="col-md-1">Fiyat</th>
                                            <th class="col-md-2">İlan Tarihi</th>
                                            <th class="col-md-1">İl/İlçe</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="ilanRepeater" runat="server">
                                            <ItemTemplate>
                                                <asp:HyperLink NavigateUrl='' runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="col-md-12 no-padding photobox">
                                                                                <div class="add-image">
                                                                                    <span class="photo-count"><i
                                                                                        class="fa fa-hashtag"></i><%# Eval("ilanId") %> </span><asp:HyperLink NavigateUrl='<%# krediKontrol(Eval("magazaId"))==true?"~/ilan-detay.aspx?ilan="+Eval("ilanId"):"~/giris-yap.aspx"%>' runat="server">
                                                                                            <img
                                                                                                class="thumbnail no-margin" src='upload/ilan/<%# Eval("resim") %>'
                                                                                                alt="img" /></asp:HyperLink>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <h5 class="add-title"><strong> <%# Eval("baslik") %></strong></h5>
                                                                        </td>
                                                                        <td runat="server" visible='<%# Convert.ToInt32(Request.QueryString["kategoriId"])==2?true:false %>'>
                                                                            <h5 class="add-title"> <%# degerDondur(Eval("ilanId"),78) %></h5>
                                                                        </td>
                                                                        <td>
                                                                            <h5 class="item-price"><%# fiyat_Tur(Eval("fiyatTurId")) %> <%# Eval("fiyat") %> </h5>
                                                                        </td>
                                                                        <td><span
                                                                            class="date"><i class=" icon-clock"></i><%# Eval("baslangicTarihi","{0:dd.MMMM.yyyy}") %> </span></td>
                                                                        <td><span
                                                                            class="item-location"><i class="fa fa-map-marker"></i><%# Eval("ilAdi")%>/<%# Eval("ilceAdi")%> </span></td>
                                                                    </tr>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!--/.adds-wrapper-->

                        <div class="tab-box  save-search-bar text-center">
                            <a href=""><i class=" icon-star-empty"></i>
                                Save Search </a>
                        </div>
                    </div>
                    
                    <!--/.pagination-bar -->

                    <div class="post-promo text-center">
                        <h2>Do you get anything for sell ? </h2>
                        <h5>Sell your products online FOR FREE. It's easier than you think !</h5>
                        <a href="post-ads.html" class="btn btn-lg btn-border btn-post btn-danger">Post a Free Ad </a>
                    </div>
                    <!--/.post-promo-->

                </div>
                <!--/.page-content-->

            </div>
        </div>
    </div>

    <!-- include carousel slider plugin  -->
    <script src="management/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="management/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"></script>
    <script>
        $(function () {

            $('#example1').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": false,
                "ordering": true,
                "info": true,
                "autoWidth": false
            });


        });
    </script>

    <script src="libraries/assets/js/owl.carousel.min.js"></script>

    <!-- include form-validation plugin || add this script where you need validation   -->

    <script src="libraries/assets/js/form-validation.js"></script>
</asp:Content>
