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
                                        <img src="../libraries/images/user.jpg" class="img-responsive thumbnail" alt="img">
                                    </a>
                                </div>
                                <h3 class="no-margin no-padding link-color ">Richard Aki</h3>
                                <div class="user-ads-action">
                                    <a class="btn btn-sm   btn-default " data-toggle="modal"
                                        href="#contactAdvertiser"><i class=" icon-mail-2"></i>Mesaj Gönder </a>
                                    <a class="btn btn-sm  btn-success "><i class=" icon-plus"></i>Takip Et </a>
                                </div>

                                <div class="seller-social-list">

                                    <ul class="share-this-post">
                                        <li><a class="google-plus"><i class="fa fa-google-plus"></i></a>
                                        </li>
                                        <li><a class="facebook"><i class="fa fa-facebook"></i></a>
                                        </li>
                                        <li><a><i class="fa fa-twitter"></i></a>
                                        </li>
                                        <li><a class="pinterest"><i class="fa fa-pinterest"></i></a>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">

                            <div class="seller-contact-info">

                                <h3 class="no-margin color-danger">İletişim Bilgileri </h3>

                                <dl class="dl-horizontal">

                                    <dt>Adres:</dt>
                                    <dd class="contact-sensitive">2142 Columbia Boulevard
                                        <br>
                                        Baltimore, MD 21212
                                    </dd>
                                    <dt>Telefon:</dt>
                                    <dd class="contact-sensitive">555-555-1230000</dd>

                                    <dt>Cep Telefonu:</dt>
                                    <dd class="contact-sensitive">+01 0234 6784</dd>

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
                                            <span class="badge">20</span></a></li>

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
                                                <span>Tüm İlanlar</span></a> in New York <a href="#selectRegion"
                                                    id="dropdownMenu1"
                                                    data-toggle="modal"><span
                                                        class="caret"></span></a>
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
                                    <div class="item-list">


                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00015.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Brand New Samsung Phones </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 320 </h2>
                                            <a class="btn btn-danger  btn-sm make-favorite"><i
                                                class="fa fa-certificate"></i><span>Top Ads</span> </a><a
                                                    class="btn btn-default  btn-sm make-favorite"><i
                                                        class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->

                                    <div class="item-list">
                                        <div class="cornerRibbons featuredAds">
                                            <a href="#">Featured Ads</a>
                                        </div>

                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00008.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Sony Xperia dual sim 100% brand new </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 250 </h2>
                                            <a class="btn btn-danger  btn-sm make-favorite"><i
                                                class="fa fa-certificate"></i><span>Featured Ads</span> </a><a
                                                    class="btn btn-default  btn-sm make-favorite"><i
                                                        class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>

                                    <div class="item-list">
                                        <div class="cornerRibbons urgentAds">
                                            <a href="#">Urgent</a>
                                        </div>
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin"
                                                            src="images/item/FreeGreatPicture.com-46404-google-drops-nexus-4-by-100-offers-15-day-price-protection-refund.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Google drops Nexus
                                                    4 </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 150 </h2>
                                            <a class="btn btn-danger  btn-sm make-favorite"><i
                                                class="fa fa-certificate"></i><span>Urgent</span> </a>
                                            <a class="btn btn-default  btn-sm make-favorite"><i
                                                class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->

                                    <!--/.item-list-->
                                    <div class="item-list">

                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00014.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Samsung Galaxy S Dous
                                                    (Brand New/ Intact Box) With 1year Warranty </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 230</h2>
                                            <a class="btn btn-default  btn-sm make-favorite"><i
                                                class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->
                                    <div class="item-list">
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00003.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">MSI GE70 Apache
                                                    Pro-061 17.3" Core i5-4200H/8GB DDR3/NV GTX860M Gaming Laptop </a>
                                                </h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 400 </h2>
                                            <a class="btn btn-default  btn-sm make-favorite"><i
                                                class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->
                                    <div class="item-list">
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00022.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Apple iPod touch 16 GB
                                                    3rd Generation </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 150 </h2>
                                            <a class="btn btn-default  btn-sm make-favorite"><i
                                                class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->
                                    <div class="item-list">
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-camera"></i>2 </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin"
                                                            src="images/item/FreeGreatPicture.com-46405-google-drops-price-of-nexus-4-smartphone.jpg"
                                                            alt="img"></a>
                                            </div>
                                        </div>
                                        <!--/.photobox-->
                                        <div class="col-sm-7 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><a href="ads-details.html">Google drops Nexus 4
                                                    by $100, offers 15 day price protection refund </a></h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i>Today 1:21 pm </span>- <span
                                                            class="category">Electronics </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i>New York </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <h2 class="item-price">$ 150 </h2>
                                            <a class="btn btn-default  btn-sm make-favorite"><i
                                                class="fa fa-heart"></i><span>Save</span> </a>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                    <!--/.item-list-->


                                </div>
                                <!--/.adds-wrapper-->

                                <div class="tab-box  save-search-bar text-center">
                                    <a href=""><i class=" icon-plus"></i>
                                        Follow User </a>
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
                                        Takip Ediyor <span class="badge">3</span>
                                    </div>
                                    <div class="panel-content user-info">
                                        <div class="panel-body text-center">
                                            <ul class="list-unstyled list-user-list">

                                                <li><a>
                                                    <img alt="img" src="images/users/13.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/9.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/7.jpg"
                                                        class="img-circle   "></a></li>
                                            </ul>


                                        </div>
                                    </div>
                                </div>
                                <div class="panel sidebar-panel panel-contact-seller">
                                    <div class="panel-heading">
                                        Takipçileri <span class="badge">81</span>
                                    </div>
                                    <div class="panel-content user-info">
                                        <div class="panel-body text-center">
                                            <ul class="list-unstyled list-user-list long-list-user">

                                                <li><a>
                                                    <img alt="img" src="images/users/1.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/2.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/3.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/4.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/5.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/6.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/7.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/8.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/9.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/10.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/11.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/12.jpg"
                                                        class="img-circle   "></a></li>

                                                <li><a>
                                                    <img alt="img" src="images/users/13.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/14.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/15.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/16.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/5.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/6.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/7.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/8.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/9.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/10.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/11.jpg"
                                                        class="img-circle   "></a></li>
                                                <li><a>
                                                    <img alt="img" src="images/users/12.jpg"
                                                        class="img-circle   "></a></li>
                                            </ul>


                                        </div>
                                    </div>
                                </div>
                                <div class="panel sidebar-panel">
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
                                </div>
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
    
    <script src="libraries/assets/js/owl.carousel.min.js"></script>

    <!-- include form-validation plugin || add this script where you need validation   -->
    <script src="libraries/assets/js/form-validation.js"></script>
</asp:Content>
