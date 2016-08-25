<%@ Page Title="Profilim" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="hesap-anasayfa.aspx.cs" Inherits="PL.hesap_anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../management/plugins/datepicker/datepicker3.css" />
    <link rel="stylesheet" href="../management/plugins/select2/select2.min.css" />
    <link rel="stylesheet" href="../management/dist/css/AdminLTE.min.css" />
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-3 page-sidebar">
                    <aside>
                        <div class="inner-box">
                            <div class="user-panel-sidebar">
                                <div class="collapse-box">
                                    <h5 class="collapse-title no-border">
                                        <asp:Label ID="lblUsername" runat="server"></asp:Label><a href="#My"
                                        data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="My">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypTur" NavigateUrl='~/profil/profil.aspx?control=anasayfa' runat="server"><i class="icon-home"></i>BENİM SAYFAM <span
                                                class="badge">42</span></asp:HyperLink>

                                                <%--                                                <asp:hyperlink id="hlUrunler" navigateurl="<%$ RouteUrl:RouteName=bilgilerim%>" runat="server"><i class="icon-home"></i>BENİM SAYFAM <span
                                                class="badge">42</span></asp:hyperlink>--%>
                                                <%--                                                <asp:HyperLink ID="hypBenim" runat="server" NavigateUrl="~/profil/profil.aspx?control=anasayfa"><i class="icon-home"></i>BENİM SAYFAM <span
                                                class="badge">42</span></asp:HyperLink>--%></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.collapse-box  -->
                                <div class="collapse-box">
                                    <h5 class="collapse-title">İLAN YÖNETİMİ <a href="#MyAds" data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="MyAds">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypYayin" runat="server" NavigateUrl="~/profil/profil.aspx?control=ilan"><i class="icon-docs"></i>YAYINDA <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypArsiv" runat="server" NavigateUrl="~/profil/profil.aspx?control=arsiv"><i class="icon-folder-close"></i>ARŞİVLENMİŞ <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="htpOnay" runat="server" NavigateUrl="~/profil/profil.aspx?control=onay-bekleyen"><i class="icon-hourglass"></i>ONAY BEKLEYEN <span
                                                class="badge">42</span></asp:HyperLink></li>
                                                                                        <li>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/profil/profil.aspx?control=onay-bekleyen"><i class="fa fa-times"></i>ONAYLANMAMIŞ <span
                                                class="badge">42</span></asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="collapse-box">
                                    <h5 class="collapse-title">FAVORİLER <a href="#MyFavori" data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="MyFavori">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypFavoriIlan" runat="server" NavigateUrl="~/profil/profil.aspx?control=favori-ilan"><i class="icon-heart"></i>FAVORİ İLANLAR <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="htpFavoriSatici" runat="server" NavigateUrl="~/profil/profil.aspx?control=favori-satici"><i class="icon-heart"></i>FAVORİ SATICILAR <span
                                                class="badge">42</span></asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="collapse-box">
                                    <h5 class="collapse-title">MESAJLAR <a href="#MyMesaj" data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="MyMesaj">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypGelen" runat="server" NavigateUrl="~/profil/profil.aspx?control=gelen-kutusu"><i class="icon-post"></i>GELEN KUTUSU <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypGönderilen" runat="server" NavigateUrl="~/profil/profil.aspx?control=gönderilen-kutusu"><i class="icon-post"></i>GÖNDERİLEN KUTUSU <span
                                                class="badge">42</span></asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.collapse-box  -->

                                <div class="collapse-box">
                                    <h5 class="collapse-title">MAĞAZAM <a href="#MyStore" data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="MyStore">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypMagazaBilgi" runat="server" NavigateUrl="~/profil/profil.aspx"><i class="icon-info"></i>MAĞAZA BİLGİLERİM </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypKullanici" runat="server" NavigateUrl="~/profil/profil.aspx?control=kullanicilar"><i class="icon-user"></i>KULLANICILARI <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypDoping" runat="server" NavigateUrl="~/profil/profil.aspx?control=kullanicilar"><i class="icon-star"></i>DOPİNGLERİ <span
                                                class="badge">42</span></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypGit" runat="server" NavigateUrl="~/profil/profil.aspx?control=kullanicilar"><i class="icon-link"></i>MAĞAZAMA GİT </asp:HyperLink></li>

                                        </ul>
                                    </div>
                                </div>

                                <div class="collapse-box">
                                    <h5 class="collapse-title">HESAP İŞLEMLERİ <a href="#TerminateAccount"
                                        data-toggle="collapse"
                                        class="pull-right"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="TerminateAccount">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypDoundur" runat="server" NavigateUrl="~/profil/profil.aspx?control=hesap-dondur"><i class="icon-cancel-circled"></i>HESAP DONDUR </asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.collapse-box  -->
                            </div>
                        </div>
                        <!-- /.inner-box  -->
                    </aside>
                </div>
                <!--/.page-sidebar-->
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <!--/.page-content-->
            </div>
            <!--/.row-->
        </div>
        <!--/.container-->
    </div>
    <!-- /.main-container -->

    <%--    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/jquery.mockjax.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/jquery.autocomplete.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/usastates.js") %>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/libraries/assets/plugins/autocomplete/autocomplete-demo.js") %>'></script>--%>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>

</asp:Content>
