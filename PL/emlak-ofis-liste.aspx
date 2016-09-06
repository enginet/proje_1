<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="emlak-ofis-liste.aspx.cs" Inherits="PL.emlak_ofis_liste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/select2/select2.min.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <style>
        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
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
                                                        <asp:HyperLink ID="hypKategori" runat="server" NavigateUrl='<%# String.Format("~/emlak-ofis-liste.aspx?kategoriId={0}&tur={1}&cat={2}",Request.QueryString["kategoriId"],Request.QueryString["tur"], Eval("kategoriId") ) %>'><%# Eval("kategoriAdi") %><span class="count">(143)</span></asp:HyperLink></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ul>
                            </div>

                            <div class="locations-list  list-filter">
                                <h5 class="list-title"><strong><a href="#">Fİltre</a></strong></h5>
                                <div id="filtre">
                                    <%--                                    <span id="gizleGoster" class="bg-green fa fa-filter"></span>--%>
                                    <div>
                                        <div>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="form-group" style="padding-top: 15px;">
                                                        <label>İl</label>
                                                        <asp:DropDownList ID="drpIl" CssClass="form-control select2" Style="width: 100%;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>İlçe</label>
                                                        <asp:DropDownList ID="drpIlce" CssClass="form-control select2" Style="width: 100%;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Mahalle</label>
                                                        <asp:DropDownList ID="drpMahalle" CssClass="form-control select2" Style="width: 100%;" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <label>Fiyat</label>
                                            <div class="clearfix"></div>
                                            <div class="form-group col-xs-6" style="padding-left: 0">
                                                <asp:TextBox ID="txtMinFiyat" runat="server" CssClass="form-control" placeholder="min. fiyat"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-xs-6" style="padding-right: 0">
                                                <asp:TextBox ID="txtMaxFiyat" runat="server" CssClass="form-control" placeholder="max. fiyat"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label>Kimden</label>
                                                <asp:DropDownList ID="drpKimden" CssClass="form-control input-sm select2" Style="width: 100%;" runat="server">
                                                    <asp:ListItem Value="">Seçiniz</asp:ListItem>
                                                    <asp:ListItem Value="1">Sahibinden</asp:ListItem>
                                                    <asp:ListItem Value="2">Emlakçıdan</asp:ListItem>
                                                    <asp:ListItem Value="3">Belediyeden</asp:ListItem>
                                                    <asp:ListItem Value="4">Bankadan</asp:ListItem>
                                                    <asp:ListItem Value="5">İzaley-i Şuyudan</asp:ListItem>
                                                    <asp:ListItem Value="6">İcradan</asp:ListItem>
                                                    <asp:ListItem Value="7">Milli Hazineden (Satışı Devam Eden)</asp:ListItem>
                                                    <asp:ListItem Value="8">Milli Hazineden (Satılamayan)</asp:ListItem>
                                                    <asp:ListItem Value="9">Özelleştirme İdaresinden</asp:ListItem>
                                                    <asp:ListItem Value="10">İnşaat Firmasından</asp:ListItem>
                                                    <asp:ListItem Value="11">Dİğer Kamu Kurumlarından</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="yurt" runat="server">
                                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <div class="form-group" style="background-color: #fdfdfd; padding: 5px;">
                                                <label>İlan Tarihi</label>
                                                <div class="form-group">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                        <asp:ListItem Value="1">Son 1 Gün</asp:ListItem>
                                                        <asp:ListItem Value="3">Son 3 Gün</asp:ListItem>
                                                        <asp:ListItem Value="7">Son 1 Hafta</asp:ListItem>
                                                        <asp:ListItem Value="15">Son 15 Gün</asp:ListItem>
                                                        <asp:ListItem Value="30">Son 1 Ay</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtAra" CssClass="form-control" runat="server" placeholder="İlan no veya aranacak kelime"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="Button1" runat="server" Text="Ara" CssClass="form-control btn btn-success" OnClick="Button1_Click" Style="font-size: 20px; line-height: 0; color: #fff;" />
                                            </div>
                                            <div id="myModal" class="modal fade in">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <a class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span></a>
                                                        </div>
                                                        <div class="modal-body">
                                                            <p style="font-size: 16px;"><%= mesaj %></p>
                                                        </div>
                                                    </div>
                                                    <!-- /.modal-content -->
                                                </div>
                                                <!-- /.modal-dalog -->
                                            </div>
                                            <a class="clickMe" data-toggle="modal" data-target="#myModal" hidden="hidden"></a>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--/.list-filter-->
                            <div style="clear: both"></div>
                        </div>

                        <!--/.categories-list-->
                    </aside>
                </div>
                <!--/.page-side-bar-->
                <div class="col-sm-9 page-content col-thin-left">
                    
                    <%--Buraya reklam eklendi--%>
                    <div class="inner-box has-aff relative">
                        <a class="dummy-aff-img" href="#">
                            <asp:Image ID="dkdrtgnRklm" runat="server" style="width:100%; height:90px;"/>
                        </a>
                    </div>

                    <div class="category-list">
                        <div class="tab-box ">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs add-tabs" role="tablist">
                                <li><a href='<%= Page.ResolveUrl("~/ilan-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Tüm İlanlar <span class="badge" runat="server" id="tum_ilanlar"></span></a>
                                </li>
                                <li><a href='<%= Page.ResolveUrl("~/sahibinden-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Sahibinden
                                    <span class="badge" runat="server" id="sahibinden"></span></a></li>
                                <li class="active"><a href='<%= Page.ResolveUrl("~/emlak-ofis-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Emlak Ofisi
                                    <span class="badge" runat="server" id="emlakcidan"></span></a></li>

                                <li><a href='<%= Page.ResolveUrl("~/insaat-firmasi-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">İnşaat Firması
                                    <span class="badge" runat="server" id="insaat_firmasindan"></span></a></li>
                                <li role="presentation" class="dropdown">
                                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Diğer Mağazalar<span class="caret"></span>
                                    </a>
                                    <ul class="dropdown-menu">
                                        <li><a href='<%= Page.ResolveUrl("~/bankadan-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Banka
                                    <span class="badge" runat="server" id="bankadan"></span></a></li>

                                        <li><a href='<%= Page.ResolveUrl("~/izale-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">İzale-i Şuyu
                                    <span class="badge" runat="server" id="izaleyi_suyu"></span></a></li>
                                        <li><a href='<%= Page.ResolveUrl("~/belediye-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Belediye
                                    <span class="badge" runat="server" id="belediyeden"></span></a></li>
                                        <li><a href='<%= Page.ResolveUrl("~/icra-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">İcra
                                    <span class="badge" runat="server" id="icradan"></span></a></li>
                                        <li><a href='<%= Page.ResolveUrl("~/milli-hazine-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Milli Hazine
                                    <span class="badge" runat="server" id="milli_hazineden"></span></a></li>
                                        <li><a href='<%= Page.ResolveUrl("~/ozellestirme-idaresi-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Özelleştirme İdaresi
                                    <span class="badge" runat="server" id="ozellestirme_dairesinden"></span></a></li>
                                        <li><a href='<%= Page.ResolveUrl("~/kamu-kurumlari-liste.aspx?kategoriId=" + Request.QueryString["kategoriId"]+"&tur=" + Request.QueryString["tur"]) %>' role="tab">Kamu Kurumları
                                    <span class="badge" runat="server" id="kamu_kurumlarindan"></span></a></li>
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
                                <table id="example1" class="table table-responsive table-hover">
                                    <thead>
                                        <tr>
                                            <th class="col-md-2"></th>
                                            <th class="col-md-3">İlan Başlığı</th>
                                            <th class="col-md-1">m<sup>2</sup></th>
                                            <th class="col-md-1">Fiyat</th>
                                            <th class="col-md-2">İlan Tarihi</th>
                                            <th class="col-md-1">İl/İlçe</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="ilanRepeater" runat="server">
                                            <ItemTemplate>
                                                <asp:HyperLink NavigateUrl="#" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="col-md-12 no-padding photobox">
                                                                                <div class="add-image">
                                                                                    <span class="photo-count"><i
                                                                                        class="fa fa-hashtag"></i><%# Eval("ilanId") %> </span><asp:HyperLink NavigateUrl='<%# krediKontrol(Eval("magazaId"))==true?"~/ilan-detay.aspx?ilan="+Eval("ilanId"):"~/giris-yap.aspx"%>' runat="server">
                                                                                            <img
                                                                                                class="thumbnail no-margin" src='upload/ilan/<%# Eval("resim") %>'
                                                                                                alt="img" /></a></asp:HyperLink>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <h5 class="add-title"><strong> <%# Eval("baslik") %></strong></h5>
                                                                        </td>
<%--                                                                        <td>
                                                                            <h5 class="add-title"> <%# degerDondur(Eval("ilanId"),78) %></h5>
                                                                        </td>--%>
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
    <script src='<%= Page.ResolveUrl("~/management/plugins/select2/select2.full.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $(".select2").select2();
        });
    </script>
    <script src="libraries/assets/js/owl.carousel.min.js"></script>

    <!-- include form-validation plugin || add this script where you need validation   -->

    <script src="libraries/assets/js/form-validation.js"></script>
</asp:Content>
