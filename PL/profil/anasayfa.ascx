<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.ascx.cs" Inherits="PL.profil.ansayfa" %>
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <div class="row">
            <div class="col-md-5 col-xs-4 col-xxs-12">
                <h3 class="no-padding text-center-480 useradmin"><a href="">
                    <img class="userImg"
                        src='../upload/profil/<%= sellerProfil %>'
                        alt="user">
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                </a></h3>
            </div>
            <div class="col-md-7 col-xs-8 col-xxs-12">
                <div class="header-data text-center-xs">
                    <!-- Traffic data -->
                    <div class="hdata">
                        <div class="mcol-left">
                            <!-- Icon with red background -->
                            <i class="fa fa-eye ln-shadow"></i>
                        </div>
                        <div class="mcol-right">
                            <!-- Number of visitors -->
                            <p><a href="#">0</a> <em>Ziyaretçi</em></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                    <!-- revenue data -->
                    <div class="hdata">
                        <div class="mcol-left">
                            <!-- Icon with green background -->
                            <i class="icon-th-thumb ln-shadow"></i>
                        </div>
                        <div class="mcol-right">
                            <!-- Number of visitors -->
                            <p><a href="#">0</a><em>İlan</em></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                    <!-- revenue data -->
                    <div class="hdata">
                        <div class="mcol-left">
                            <!-- Icon with blue background -->
                            <i class="fa fa-user ln-shadow"></i>
                        </div>
                        <div class="mcol-right">
                            <!-- Number of visitors -->
                            <p><a href="#">0</a> <em>Favori </em></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="inner-box">
        <div class="row">
            <div class="col-md-12">
                <div class="header-data pull-left">
                    <!-- Traffic data -->
                    <div class="hdata">
                        <div class="mcol-left">
                            <!-- Icon with red background -->
                            <i class="icon-docs ln-shadow"></i>
                        </div>
                        <div class="mcol-right">
                            <!-- Number of visitors -->
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <asp:HyperLink ID="HyperLink5" runat="server"><p><strong>Hemen İlan Ver</strong></p>
                 <p>Siz de sahibinden.com'a ilan verin, ilanınızın milyonlarca kullanıcı tarafından görüntülenmesini sağlayarak kısa sürede sonuca ulaşın. </p></asp:HyperLink>
            </div>
        </div>

    </div>
        <div class="inner-box">
        <div class="row">
            <div class="col-md-12">
                <div class="header-data pull-left">
                    <!-- Traffic data -->
                    <div class="hdata">
                        <div class="mcol-left">
                            <!-- Icon with red background -->
                            <i class="fa fa-star ln-shadow"></i>
                        </div>
                        <div class="mcol-right">
                            <!-- Number of visitors -->
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                
                <p><strong><asp:HyperLink ID="HyperLink4" runat="server">Favori İlanlar</asp:HyperLink></strong></p>
                 <p>İlgilendiğiniz ilanları favorilere ekleyin, fiyat değişikliği olduğunda size e-posta ile haber verelim.</p>

            </div>
        </div>

    </div>


    <div class="inner-box" runat="server" id="enSonİlan" visible="false">
        <div class="welcome-msg">
            <h4 class="page-sub-header2 clearfix no-padding">En Son Yayına Aldığım İlanım </h4>
            <br />
            <div class="item-list">
                <div class="col-sm-2 no-padding photobox">
                    <div class="add-image">
                        <span class="photo-count" ><i
                            class="fa fa-hashtag"> </i>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </span><a href="ads-details.html">
                                <img
                                    class="thumbnail no-margin" src='../upload/ilan/<%= classifiedPic %>'
                                    alt="img"></a>
                    </div>
                </div>
                <!--/.photobox-->
                <div class="col-sm-5 add-desc-box">
                    <div class="add-details">
                        <h5 class="add-title">
                            <asp:HyperLink ID="hypBaslik" runat="server" NavigateUrl='<%# Eval("ilanId","~/ilan-detay.aspx?ilan={0}") %>'></asp:HyperLink>
                        </h5>
                        <span class="info-row"><span class="add-type business-ads tooltipHere"
                            data-toggle="tooltip"
                            data-placement="right"
                            title="Business Ads">B </span><span
                                class="date" runat="server" id="txttarih"><i class=" icon-clock"></i></span>- <span
                                    class="category" runat="server" id="txtkategori"></span>- <span
                                        class="item-location" runat="server" id="txtIl"><i class="fa fa-map-marker"></i></span></span>
                    </div>
                </div>
                <!--/.add-desc-box-->
                <div class="col-sm-5 text-right  price-box">
                    <h2 class="item-price"> <asp:Label ID="lblFiyatTur" runat="server"></asp:Label><asp:Label ID="lblFiyat" runat="server"></asp:Label></h2>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=ilan&proc={0}&classified={1}", 2 ,Eval("ilanId"))%>'><i
                                                class="fa fa-times"></i><span>Yayından Kaldır</span></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-primary  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=ilan&proc={0}&classified={1}", 3 ,Eval("ilanId"))%>'><i
                                                class="fa fa-certificate"></i><span>Doping</span></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-warning  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/ilan-duzenle.aspx?page=duzenle&ilan={0}",Eval("ilanId"))%>'><i
                                                class="fa fa-pencil"></i><span>Düzenle</span></asp:HyperLink>
                </div>
                <!--/.add-desc-box-->
            </div>
        </div>

    </div>
</div>

