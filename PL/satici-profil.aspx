<%@ Page Title="satıcı-profil" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="satici-profil.aspx.cs" Inherits="PL.satici_profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-container inner-page">
        <div class="container">
            <div class="section-content">
                <div class="inner-box ">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="seller-info seller-profile">
                                <div class="seller-profile-img">
                                    <a>
                                        <img onerror="this.src='../upload/profil/user.jpg'" src="../libraries/images/" class="img-responsive thumbnail" alt="user image"/>
                                    </a>
                                </div>
                                <h3 class="no-margin no-padding link-color ">
                                    <asp:Label ID="lblSellerName" runat="server" Text="Label"></asp:Label></h3>
                                <div class="user-ads-action">
                                    <asp:LinkButton Text="text" ID="LinkButton1" CssClass="btn btn-sm  btn-success" runat="server"><i class=" icon-plus"></i> Takip Et</asp:LinkButton>
                                    <asp:LinkButton Text="text" ID="LinkButton2" CssClass="btn btn-sm  btn-danger" runat="server"><i class="fa fa-minus"></i> Takibi Bırak</asp:LinkButton>
                                </div>

                                <div class="seller-social-list">

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">

                            <div class="seller-contact-info">

                                <h3 class="no-margin color-danger">İletişim Bilgileri </h3>

                                <dl class="dl-horizontal">

                                    <asp:Repeater ID="telefonRepeater" runat="server">
                                        <ItemTemplate>
                                            <dt><%# telefonTurDondur(Eval("telefonTur")) %></dt>
                                            <dd class="contact-sensitive"><%# Eval("telefon") %></dd>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </dl>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="section-block">
                    <div class="row">
                        <div class="col-sm-9 col-thin-left page-content ">

                            <div class="category-list">
                                <div class="tab-box ">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs add-tabs" role="tablist">
                                        <li class="active"><a href="#allAds" role="tab" data-toggle="tab">Kullanıcının Tüm İlanları
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
                                        <div class="breadcrumb-list">
                                            <a href="#" class="current">
                                                <span>Tüm İlanlar</span></a>
                                        </div>
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
                                                                title="Business Ads">B </span><span
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
                                </div>
                                <!--/.adds-wrapper-->

<%--                                <div class="tab-box  save-search-bar text-center">
                                    <a href=""><i class=" icon-plus"></i>
                                        Follow User </a>
                                </div>--%>
                            </div>
<%--                            <div class="pagination-bar text-center">
                                <ul class="pagination">
                                    <li class="active"><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li><a href="#">...</a></li>
                                    <li><a class="pagination-btn" href="#">Sonraki &raquo;</a></li>
                                </ul>
                            </div>--%>
                            <!--/.pagination-bar -->

                            <div class="post-promo text-center">
                                <h2>Bir şeyler satmak mı istiyorsun ? </h2>
                                <a href="#" class="btn btn-lg btn-border btn-post btn-danger">Ücretsiz ilan ver</a>
                            </div>
                            <!--/.post-promo-->

                        </div>


                        <div class="col-sm-3  page-sidebar-right">
                            <aside>
                                <div class="panel sidebar-panel panel-contact-seller">
                                    <div class="panel-heading">
                                        Takip Ediyor <span class="badge">0</span>
                                    </div>
                                    <div class="panel-content user-info">
                                        <div class="panel-body text-center">
                                            <ul class="list-unstyled list-user-list">
                                                <asp:Repeater ID="takipEdilenRepeater" runat="server">
                                                    <ItemTemplate>
                                                <li><a>
                                                    <img alt="img" src='upload/profil/<%# Eval("profilResim") %>'
                                                        class="img-circle   "></a></li>
                                                                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>


                                        </div>
                                    </div>
                                </div>
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
                                                        class="img-circle   "></a></li>
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
                    <form role="form">
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
                    </form>
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
    <script src="libraries/assets/js/owl.carousel.min.js"></script>
    <!-- include form-validation plugin || add this script where you need validation   -->
    <script src="libraries/assets/js/form-validation.js"></script>
</asp:Content>
