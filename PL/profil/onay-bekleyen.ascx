<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="onay-bekleyen.ascx.cs" Inherits="PL.profil.onay_bekleyen" %>

<div class="col-sm-9 page-content">
    <div class="inner-box">
        <h2 class="title-2"><i class="icon-hourglass"></i>Onay Bekleyen İlanlar </h2>
        <div class="section-block">
            <div class="row">
                <div class="page-content ">

                    <div class="category-list">
                        <div class="tab-box ">

<%--                            <div class="tab-filter">
                                <select class="selectpicker" data-style="btn-select" data-width="auto">
                                    <option>Sırala</option>
                                    <option>Fiyat Artam</option>
                                    <option>Fiyat Azalan</option>
                                </select>
                            </div>--%>
                        </div>
                        <!--/.tab-box-->

                        <div class="listing-filter">
                            <div class="pull-left col-xs-6">
                                <div class="breadcrumb-list">
                                    <a href="#" class="current">
                                        <span>Onay Bekleyen Tüm İlanlar</span></a>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <!--/.listing-filter-->

                        <div class="adds-wrapper">
                            <asp:Repeater ID="onayBekleyenRepeater" runat="server">
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
                                        <div class="col-sm-5 add-desc-box">
                                            <div class="add-details">
                                                <h5 class="add-title"><%# Eval("baslik") %> </h5>
                                                <span class="info-row"><span class="add-type business-ads tooltipHere"
                                                    data-toggle="tooltip"
                                                    data-placement="right"
                                                    title="Business Ads">B </span><span
                                                        class="date"><i class=" icon-clock"></i> <%# Eval("baslangicTarihi", "{0:d-MMMM-yyyy}" ) %> </span>- <span
                                                            class="category"><%# Eval("kategoriAdi") %> </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i><%# Eval("ilAdi") %> </span>
                                                                                                        <span
                                                        class="item-location"><i class="fa fa-eye"></i><%# Eval("ziyaretci") %> </span>
                                                </span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-5 text-right  price-box">
                                            <h2 class="item-price"><%# Eval("fiyat") %> </h2>
                                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=onay-bekleyen&proc={0}&classified={1}", 2 ,Eval("ilanId"))%>'><i
                                                class="fa fa-times"></i><span> İlanı Sil</span></asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-warning  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=onay-bekleyen&proc={0}&classified={1}", 4 ,Eval("ilanId"))%>'><i
                                                class="fa fa-pencil"></i><span> Düzenle</span></asp:HyperLink>
                                             <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-primary  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=onay-bekleyen&proc={0}&classified={1}", 3 ,Eval("ilanId"))%>'><i
                                                class="fa fa-folder"></i><span> Arşive Al</span></asp:HyperLink>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--/.adds-wrapper-->

<%--                        <div class="tab-box  save-search-bar text-center">
                            <a href=""><i class=" icon-plus"></i>
                                Onay Bekleyen İlanınız Bulunmamaktadır. </a>
                        </div>--%>
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
                        <li class="postadd">
                            <asp:HyperLink ID="hypIlanVer" CssClass="btn  btn-border btn-post btn-danger" Style="font-size: 14px;" runat="server" NavigateUrl="~/kategori-secimi.aspx"><span class="ion ion-plus-round" style="font-size: 16px; padding-right: 5px;"></span> Ücretsiz İlan Ver</asp:HyperLink>
                        </li>                      </div>
                    <!--/.post-promo-->

                </div>
            </div>
        </div>
    </div>
</div>

