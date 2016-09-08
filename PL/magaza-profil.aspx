<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="magaza-profil.aspx.cs" Inherits="PL.magaza_profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="main-container inner-page">
        <div class="container">
            <div class="row user-menu-container square">
                <div class="col-md-7 user-details">
                    <div class="row coralbg white">
                        <div class="col-md-6 no-pad">
                            <div class="user-pad">
                                <h1>
                                    <asp:Label ID="lblMagazaAdi" runat="server"></asp:Label></h1>
                                <br />
                                <br />
                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-labeled btn-danger" runat="server" OnClick="LinkButton1_Click"><span class="btn-label"><i class="fa fa-plus"></i></span> Takip Et</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-labeled btn-danger" runat="server" OnClick="LinkButton2_Click"><span class="btn-label"><i class="fa fa-minus"></i></span> Takip Bırak</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-6 no-pad">
                            <div class="user-image">
                                <img onerror="this.src='../upload/system_resim/not-found-store.png'" src='upload/magaza/<%= storeLogo %>' class="img-responsive thumbnail" alt="img" />
                            </div>
                        </div>
                    </div>
                    <div class="row overview">
                        <div class="col-md-4 user-pad text-center">
                            <h3>Takipçileri</h3>
                            <h4>0</h4>
                        </div>
                        <div class="col-md-4 user-pad text-center">
                            <h3>İlan Sayısı</h3>
                            <h4>0</h4>
                        </div>
                        <div class="col-md-4 user-pad text-center">
                            <h3>Danışman Sayısı</h3>
                            <h4>0</h4>
                        </div>
                    </div>
                </div>
                <div class="col-md-1 user-menu-btns">
                    <div class="btn-group-vertical square" id="responsive">
                        <a href="#" class="btn btn-block btn-default active">
                            <i class="fa fa-phone fa-3x"></i>
                        </a>
                        <a href="#" class="btn btn-default">
                            <i class="fa fa-envelope-o fa-3x"></i>
                        </a>
                        <a href="#" class="btn btn-default">
                            <i class="fa fa-question fa-3x"></i>
                        </a>
                        <a href="#" class="btn btn-default">
                            <i class="fa fa-life-buoy fa-3x"></i>
                        </a>
                    </div>
                </div>
                <div class="col-md-4 user-menu user-pad">
                    <div class="user-menu-content active">
                        <h3>Bizimle İletişime Geçin
                        </h3>
                        <div class="share-links">
                            <div>
                                <%--                                <asp:HyperLink ID="hypIsTlf" runat="server" style="margin-bottom: 15px;" CssClass="btn btn-lg btn-labeled btn-success"><span class="btn-label"><i class="fa fa-phone"></i></span></asp:HyperLink>--%>
                                <asp:Repeater ID="telefonRepeater" runat="server">
                                    <ItemTemplate>
                                        <button type="button" class="btn btn-lg btn-labeled btn-success" href="#" style="margin-bottom: 15px;" runat="server">
                                            <span class="btn-label"><i class="fa fa-phone"></i><%# telefonTurDondur(Eval("telefonTur")) %></span><%# Eval("telefon") %>
                                        </button>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="user-menu-content">
                        <h3>Bizimle Mesajlaşın
                        </h3>
<%--                        <ul class="user-menu-list">
                            <li>
                                <h4>From Roselyn Smith <small class="coral"><strong>NEW</strong> <i class="fa fa-clock-o"></i>7:42 A.M.</small></h4>
                            </li>
                            <li>
                                <h4>From Jonathan Hawkins <small class="coral"><i class="fa fa-clock-o"></i>10:42 A.M.</small></h4>
                            </li>
                            <li>
                                <h4>From Georgia Jennings <small class="coral"><i class="fa fa-clock-o"></i>10:42 A.M.</small></h4>
                            </li>
                            <li>
                                <button type="button" class="btn btn-labeled btn-danger" href="#">
                                    <span class="btn-label"><i class="fa fa-envelope-o"></i></span>View All Messages</button>
                            </li>
                        </ul>--%>
                    </div>
                    <div class="user-menu-content">
                        <h3>Hakkımızda
                        </h3>
                        <ul class="user-menu-list">
                            <li>
                                <h4>
                                    <asp:Label ID="lblAciklama" runat="server"></asp:Label></h4>
                            </li>
                        </ul>
                    </div>
                    <div class="user-menu-content">
                        <h2 class="text-center">Danışmanlarımız
                        </h2>
                        <div class="share-links">
                            <asp:Repeater ID="kullaniciRepeater" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <button type="button" class="btn btn-lg btn-labeled btn-warning" href="#">
                                            <span class="btn-label"><i class="fa fa-user"></i></span><%# Eval("kullaniciAdSoyad") %>
                                        </button>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div class="section-content">
                <div class="section-block">
                    <div class="row">
                        <div class="col-sm-9 col-thin-left page-content ">
                            <div class="category-list">
                                <div class="tab-box ">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs add-tabs" role="tablist">
                                        <li class="active"><a href="#allAds" role="tab" data-toggle="tab">Mağazanın Tüm İlanları
                                            <span class="badge">0</span></a></li>

                                    </ul>

                                    <div class="tab-filter">
                                        <select class="selectpicker" data-style="btn-select" data-width="auto">
                                            <option>Sırala</option>
                                            <option>Fiyat Artam</option>
                                            <option>Fiyat Azalan</option>
                                        </select>
                                    </div>
                                </div>
                                <!--/.tab-box-->

                                <div class="listing-filter">
                                    <div class="pull-left col-xs-6">
                                        <%--                                        <div class="breadcrumb-list">
                                            <a href="#" class="current">
                                                <span>Tüm İlanlar</span></a> in New York <a href="#selectRegion"
                                                    id="dropdownMenu1"
                                                    data-toggle="modal"><span
                                                        class="caret"></span></a>
                                        </div>--%>
                                    </div>
                                    <div class="pull-right col-xs-6 text-right listing-view-action">
                                        <span
                                            class="list-view active"><i class="  icon-th"></i></span><span
                                                class="compact-view"><i class=" icon-th-list  "></i></span><span
                                                    class="grid-view "><i class=" icon-th-large "></i></span>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                                <!--/.listing-filter-->


                                <div class="adds-wrapper">
                                    <asp:Repeater ID="ilanRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="item-list">
                                                <div class="cornerRibbons featuredAds" runat="server" visible='<%# doping_Tur(Eval("ilanId"),14)==true?true:false %>'>
                                                    <a href="#">Fiyatı Düştü</a>
                                                </div>
                                                <div class="cornerRibbons urgentAds" runat="server" visible='<%# doping_Tur(Eval("ilanId"),13)==true?true:false %>'>
                                                    <a href="#">Acil Acil</a>
                                                </div>
                                                <div class="col-sm-2 no-padding photobox">
                                                    <div class="add-image">
                                                        <span class="photo-count"><i
                                                            class="fa fa-hashtag"></i><%# Eval("ilanId") %> </span><a href="ads-details.html">
                                                                <img
                                                                    class="thumbnail no-margin" src='upload/ilan/<%# Eval("resim") %>'
                                                                    alt="img"></a>
                                                    </div>
                                                </div>
                                                <!--/.photobox-->
                                                <div class="col-sm-7 add-desc-box">
                                                    <div class="add-details">
                                                        <h5 class="add-title"><a href="ads-details.html"><%# Eval("baslik") %> </a></h5>
                                                        <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                            data-toggle="tooltip"
                                                            data-placement="right"
                                                            title="Güvenli İlan">S </span><span
                                                                class="date"><i class=" icon-clock"></i><%# Eval("baslangicTarihi") %> </span>- <span
                                                                    class="category"><%# Eval("kategoriAdi") %> </span>- <span
                                                                        class="item-location"><i class="fa fa-map-marker"></i>&nbsp;<%# Eval("ilAdi") %> </span>
                                                            <span
                                                                class="item-location"><i class="fa fa-eye"></i>&nbsp;<%# Eval("ziyaretci") %> </span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <!--/.add-desc-box-->
                                                <div class="col-sm-3 text-right  price-box">
                                                    <h2 class="item-price"><%# DAL.toolkit.fiyat_Tur(Eval("fiyatTurId")) %> <%# Eval("fiyat") %> </h2>
                                                </div>
                                                <!--/.add-desc-box-->
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--/.adds-wrapper-->

                                <div class="tab-box  save-search-bar text-center">
                                    <a href=""><i class=" icon-plus"></i>
                                        Mağazayı Takip Et </a>
                                </div>
                            </div>
                            <div class="pagination-bar text-center">
                                <ul class="pagination">
                                    <li class="active"><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li><a href="#">...</a></li>
                                    <li><a class="pagination-btn" href="#">Sonraki &raquo;</a></li>
                                </ul>
                            </div>
                            <!--/.pagination-bar -->

                            <div class="post-promo text-center">
                                <h2>Bir şeyler satmak mı istiyorsun ? </h2>
                                <a href="post-ads.html" class="btn btn-lg btn-border btn-post btn-danger">Ücretsiz ilan ver</a>
                            </div>
                            <!--/.post-promo-->

                        </div>


                        <div class="col-sm-3  page-sidebar-right">
                            <aside>
                                <div class="panel sidebar-panel panel-contact-seller">
                                    <div class="panel-heading">
                                        Takipçileri <span class="badge">0</span>
                                    </div>
                                    <div class="panel-content user-info">
                                        <div class="panel-body text-center">
                                            <ul class="list-unstyled list-user-list long-list-user">
                                                <asp:Repeater ID="takipciRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <li><a>
                                                            <img alt="img" src='upload/profil/<%# Eval("profilResim") %>'
                                                                class="img-circle"></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <%--                                <div class="panel sidebar-panel">
                                    <div class="panel-heading">Safety Tips for Buyers</div>
                                    <div class="panel-content">
                                        <div class="panel-body text-left">
                                            <ul class="list-check">
                                                <li>Meet seller at a public place</li>
                                                <li>Check the item before you buy</li>
                                                <li>Pay only after collecting the item</li>
                                            </ul>
                                            <p>
                                                <a class="pull-right" href="#">Know more <i
                                                    class="fa fa-angle-double-right"></i></a>
                                            </p>
                                        </div>
                                    </div>
                                </div>--%>
                                <!--/.categories-list-->
                            </aside>
                        </div>
                        <!--/.page-side-bar-->
                    </div>
                </div>


            </div>

        </div>
    </div>

    <!-- Modal contactAdvertiser -->

    <div class="modal fade" id="contactAdvertiser" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span
                            class="sr-only">Kapat</span></button>
                    <h4 class="modal-title"><i class=" icon-mail-2"></i>Contact advertiser </h4>
                </div>
                <div class="modal-body">
                    <div role="form">
                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Adınız:</label>
                            <input class="form-control required" id="recipient-name" placeholder="Adınız"
                                data-placement="top" data-trigger="manual"
                                data-content="Must be at least 3 characters long, and must only contain letters."
                                type="text">
                        </div>
                        <div class="form-group">
                            <label for="sender-email" class="control-label">E-mail:</label>
                            <input id="sender-email" type="text"
                                data-content="Must be a valid e-mail address (user@gmail.com)" data-trigger="manual"
                                data-placement="top" placeholder="email@.." class="form-control email">
                        </div>
                        <div class="form-group">
                            <label for="recipient-Phone-Number" class="control-label">Cep Telefonu:</label>
                            <input type="text" maxlength="60" class="form-control" id="Cep Telefonu">
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="control-label">Mesaj <span class="text-count">(300) </span>:</label>
                            <textarea class="form-control" id="message-text" placeholder="Mesajınız..."
                                data-placement="top" data-trigger="manual"></textarea>
                        </div>
                        <div class="form-group">
                            <p class="help-block pull-left text-danger hide" id="form-error">
                                &nbsp; Doğru girilmeyen bilgi var.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Vazgeç</button>
                    <button type="submit" class="btn btn-success pull-right">Gönder!</button>
                </div>
            </div>
        </div>
    </div>

    <!-- /.modal -->


    <!-- Modal Change City -->

    <div class="modal fade" id="selectRegion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span
                            class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="exampleModalLabel"><i class=" icon-map"></i>Select your region </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12">

                            <p>
                                Popular cities in <strong>New York</strong>
                            </p>

                            <div style="clear: both"></div>
                            <div class="col-sm-6 no-padding">
                                <select class="form-control selecter  " id="region-state" name="region-state">
                                    <option value="">All States/Provinces</option>
                                    <option value="Alabama">Alabama</option>
                                    <option value="Alaska">Alaska</option>
                                    <option value="Arizona">Arizona</option>
                                    <option value="Arkansas">Arkansas</option>
                                    <option value="California">California</option>
                                    <option value="Colorado">Colorado</option>
                                    <option value="Connecticut">Connecticut</option>
                                    <option value="Delaware">Delaware</option>
                                    <option value="District of Columbia">District of Columbia</option>
                                    <option value="Florida">Florida</option>
                                    <option value="Georgia">Georgia</option>
                                    <option value="Hawaii">Hawaii</option>
                                    <option value="Idaho">Idaho</option>
                                    <option value="Illinois">Illinois</option>
                                    <option value="Indiana">Indiana</option>
                                    <option value="Iowa">Iowa</option>
                                    <option value="Kansas">Kansas</option>
                                    <option value="Kentucky">Kentucky</option>
                                    <option value="Louisiana">Louisiana</option>
                                    <option value="Maine">Maine</option>
                                    <option value="Maryland">Maryland</option>
                                    <option value="Massachusetts">Massachusetts</option>
                                    <option value="Michigan">Michigan</option>
                                    <option value="Minnesota">Minnesota</option>
                                    <option value="Mississippi">Mississippi</option>
                                    <option value="Missouri">Missouri</option>
                                    <option value="Montana">Montana</option>
                                    <option value="Nebraska">Nebraska</option>
                                    <option value="Nevada">Nevada</option>
                                    <option value="New Hampshire">New Hampshire</option>
                                    <option value="New Jersey">New Jersey</option>
                                    <option value="New Mexico">New Mexico</option>
                                    <option selected value="New York">New York</option>
                                    <option value="North Carolina">North Carolina</option>
                                    <option value="North Dakota">North Dakota</option>
                                    <option value="Ohio">Ohio</option>
                                    <option value="Oklahoma">Oklahoma</option>
                                    <option value="Oregon">Oregon</option>
                                    <option value="Pennsylvania">Pennsylvania</option>
                                    <option value="Rhode Island">Rhode Island</option>
                                    <option value="South Carolina">South Carolina</option>
                                    <option value="South Dakota">South Dakota</option>
                                    <option value="Tennessee">Tennessee</option>
                                    <option value="Texas">Texas</option>
                                    <option value="Utah">Utah</option>
                                    <option value="Vermont">Vermont</option>
                                    <option value="Virgin Islands">Virgin Islands</option>
                                    <option value="Virginia">Virginia</option>
                                    <option value="Washington">Washington</option>
                                    <option value="West Virginia">West Virginia</option>
                                    <option value="Wisconsin">Wisconsin</option>
                                    <option value="Wyoming">Wyoming</option>
                                </select>
                            </div>
                            <div style="clear: both"></div>

                            <hr class="hr-thin">
                        </div>
                        <div class="col-md-4">
                            <ul class="list-link list-unstyled">
                                <li><a href="#" title="">All Cities</a></li>
                                <li><a href="#" title="Albany">Albany</a></li>
                                <li><a href="#" title="Altamont">Altamont</a></li>
                                <li><a href="#" title="Amagansett">Amagansett</a></li>
                                <li><a href="#" title="Amawalk">Amawalk</a></li>
                                <li><a href="#" title="Bellport">Bellport</a></li>
                                <li><a href="#" title="Centereach">Centereach</a></li>
                                <li><a href="#" title="Chappaqua">Chappaqua</a></li>
                                <li><a href="#" title="East Elmhurst">East Elmhurst</a></li>
                                <li><a href="#" title="East Greenbush">East Greenbush</a></li>
                                <li><a href="#" title="East Meadow">East Meadow</a></li>

                            </ul>
                        </div>
                        <div class="col-md-4">
                            <ul class="list-link list-unstyled">
                                <li><a href="#" title="Elmont">Elmont</a></li>
                                <li><a href="#" title="Elmsford">Elmsford</a></li>
                                <li><a href="#" title="Farmingville">Farmingville</a></li>
                                <li><a href="#" title="Floral Park">Floral Park</a></li>
                                <li><a href="#" title="Flushing">Flushing</a></li>
                                <li><a href="#" title="Fonda">Fonda</a></li>
                                <li><a href="#" title="Freeport">Freeport</a></li>
                                <li><a href="#" title="Fresh Meadows">Fresh Meadows</a></li>
                                <li><a href="#" title="Fultonville">Fultonville</a></li>
                                <li><a href="#" title="Gansevoort">Gansevoort</a></li>
                                <li><a href="#" title="Garden City">Garden City</a></li>


                            </ul>
                        </div>
                        <div class="col-md-4">
                            <ul class="list-link list-unstyled">
                                <li><a href="#" title="Oceanside">Oceanside</a></li>
                                <li><a href="#" title="Orangeburg">Orangeburg</a></li>
                                <li><a href="#" title="Orient">Orient</a></li>
                                <li><a href="#" title="Ozone Park">Ozone Park</a></li>
                                <li><a href="#" title="Palatine Bridge">Palatine Bridge</a></li>
                                <li><a href="#" title="Patterson">Patterson</a></li>
                                <li><a href="#" title="Pearl River">Pearl River</a></li>
                                <li><a href="#" title="Peekskill">Peekskill</a></li>
                                <li><a href="#" title="Pelham">Pelham</a></li>
                                <li><a href="#" title="Penn Yan">Penn Yan</a></li>
                                <li><a href="#" title="Peru">Peru</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- include carousel slider plugin  -->
    <script src="libraries/assets/js/owl.carousel.min.js"></script>

    <!-- include form-validation plugin || add this script where you need validation   -->
    <script src="libraries/assets/js/form-validation.js"></script>
    <script>
        $(document).ready(function () {
            var $btnSets = $('#responsive'),
            $btnLinks = $btnSets.find('a');

            $btnLinks.click(function (e) {
                e.preventDefault();
                $(this).siblings('a.active').removeClass("active");
                $(this).addClass("active");
                var index = $(this).index();
                $("div.user-menu>div.user-menu-content").removeClass("active");
                $("div.user-menu>div.user-menu-content").eq(index).addClass("active");
            });
        });

        $(document).ready(function () {
            $("[rel='tooltip']").tooltip();

            $('.view').hover(
                function () {
                    $(this).find('.caption').slideDown(250); //.fadeIn(250)
                },
                function () {
                    $(this).find('.caption').slideUp(250); //.fadeOut(205)
                }
            );
        });
    </script>
</asp:Content>
