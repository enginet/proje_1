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
                                    <h5 class="collapse-title no-border">üyelik bilgilerim<a href="#My"
                                        data-toggle="collapse"
                                        class="pull-right "><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse in" id="My">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypTur" NavigateUrl='~/profil/profil.aspx?control=anasayfa' runat="server"><i class="fa fa-user-secret"></i>&nbsp;benim sayfam </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink2" NavigateUrl='~/profil/profil.aspx?control=kisisel-bilgiler' runat="server"><i class="fa fa-user"></i>&nbsp;kişisel bilgiler </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink3" NavigateUrl='~/profil/profil.aspx?control=eposta' runat="server"><i class="fa fa-edit"></i>&nbsp;E-Posta </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink4" NavigateUrl='~/profil/profil.aspx?control=cep-telefonu' runat="server"><i class="fa fa-mobile"></i>&nbsp;Cep Telefonu </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink5" NavigateUrl='~/profil/profil.aspx?control=hesap-dondur' runat="server"><i class="fa fa-trash"></i>&nbsp;Hesap Dondur </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink6" NavigateUrl='~/profil/profil.aspx?control=bildirimler' runat="server"><i class="fa fa-info-circle"></i>&nbsp;bilgilendirmeler </asp:HyperLink>
                                                <asp:HyperLink ID="HyperLink7" NavigateUrl='~/profil/profil.aspx?control=bildirimler' runat="server"><i class="fa fa-credit-card"></i>&nbsp;hesap hareketlerim </asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.collapse-box  -->
                                <div class="collapse-box">
                                    <h5 class="collapse-title">İLAN YÖNETİMİ <a href="#MyAds" data-toggle="collapse"
                                        class="pull-right collapsed"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse" id="MyAds">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypYayin" runat="server" NavigateUrl="~/profil/profil.aspx?control=ilan"><i class="icon-docs"></i>YAYINDA </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypArsiv" runat="server" NavigateUrl="~/profil/profil.aspx?control=arsiv"><i class="icon-folder-close"></i>ARŞİVLENMİŞ </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="htpOnay" runat="server" NavigateUrl="~/profil/profil.aspx?control=onay-bekleyen"><i class="icon-hourglass"></i>ONAY BEKLEYEN </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/profil/profil.aspx?control=onaylanmamis"><i class="fa fa-times"></i>&nbsp;ONAYLANMAMIŞ </asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="collapse-box">
                                    <h5 class="collapse-title">FAVORİLER <a href="#MyFavori" data-toggle="collapse"
                                        class="pull-right collapsed"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse" id="MyFavori">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypFavoriIlan" runat="server" NavigateUrl="~/profil/profil.aspx?control=favori-ilan"><i class="icon-heart"></i>favori ilanlar </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="htpFavoriSatici" runat="server" NavigateUrl="~/profil/profil.aspx?control=favori-satici"><i class="icon-heart"></i>takip ettiğim satıcılar </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/profil/profil.aspx?control=favori-magaza"><i class="icon-heart"></i>takip ettiğim mağazalar </asp:HyperLink></li>

                                        </ul>
                                    </div>
                                </div>

                                <div class="collapse-box">
                                    <h5 class="collapse-title">MESAJLAR <a href="#MyMesaj" data-toggle="collapse"
                                        class="pull-right collapsed"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse" id="MyMesaj">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypGelen" runat="server" NavigateUrl="~/profil/profil.aspx?control=gelen-kutusu"><i class="icon-post"></i>GELEN KUTUSU </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypGönderilen" runat="server" NavigateUrl="~/profil/profil.aspx?control=gönderilen-kutusu"><i class="icon-post"></i>GÖNDERİLEN KUTUSU </asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.collapse-box  -->

                                <div class="collapse-box" runat="server" id="store_plate" visible="false">
                                    <h5 class="collapse-title">MAĞAZAM <a href="#MyStore" data-toggle="collapse"
                                        class="pull-right collapsed"><i
                                            class="fa fa-angle-down"></i></a></h5>

                                    <div class="panel-collapse collapse" id="MyStore">
                                        <ul class="acc-list">
                                            <li>
                                                <asp:HyperLink ID="hypMagazaBilgi" runat="server" NavigateUrl="~/profil/profil.aspx"><i class="icon-info"></i>MAĞAZA BİLGİLERİM </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypKullanici" runat="server" NavigateUrl="~/profil/profil.aspx?control=kullanicilar"><i class="icon-user"></i>KULLANICILARI </asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypGit" runat="server" NavigateUrl="~/profil/profil.aspx?control=kullanicilar"><i class="icon-link"></i>MAĞAZAMA GİT </asp:HyperLink></li>

                                        </ul>
                                    </div>
                                </div>
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
