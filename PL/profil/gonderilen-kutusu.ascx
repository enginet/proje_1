﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gonderilen-kutusu.ascx.cs" Inherits="PL.profil.gönderilen_kutusu" %>
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <h2 class="title-2"><i class="icon-docs"></i>İlanlarım </h2>
        <div class="section-block">
            <div class="row">
                <div class="page-content ">

                    <div class="category-list">
                        <div class="tab-box ">

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
                            <div style="clear: both"></div>
                        </div>
                        <!--/.listing-filter-->

                        <div class="adds-wrapper">
                            <asp:Repeater ID="mesajRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="item-list">
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-hashtag"></i><%# Eval("ilanId") %> </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="images/item/tp/Image00015.jpg"
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
                                                        class="date"><i class=" icon-clock"></i></span>- <span
                                                            class="category"><%# Eval("kullaniciAdSoyad") %> </span></span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-3 text-right  price-box">
                                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=gonderilen-kutusu&proc={0}&to={1}&cla={2}", 1, Eval("kimeId") ,Eval("ilanId"))%>'><i
                                                class="fa fa-times"></i><span> Konuşmayı Sil</span></asp:HyperLink>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <!--/.adds-wrapper-->
<%--                        <div class="tab-box  save-search-bar text-center">
                            <a href=""><i class=" icon-plus"></i>
                                Follow User </a>
                        </div>--%>
                    </div>
                    <div class="pagination-bar text-center">
<%--                        <ul class="pagination">
                            <li class="active"><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">...</a></li>
                            <li><a class="pagination-btn" href="#">Sonraki &raquo;</a></li>
                        </ul>--%>
                    </div>
                    <!--/.pagination-bar -->

                    <div class="post-promo text-center">
                        <h2>Bir şeyler satmak mı istiyorsun ? </h2>
                        <a href="post-ads.html" class="btn btn-lg btn-border btn-post btn-danger">Ücretsiz ilan ver</a>
                    </div>
                    <!--/.post-promo-->

                </div>
            </div>
        </div>
    </div>
</div>
