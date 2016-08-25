<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="kategoriler.aspx.cs" Inherits="PL.kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <link rel="stylesheet" href="management/dist/css/AdminLTE.min.css" />--%>
    <link href="libraries/assets/css/owl.carousel.css" rel="stylesheet" />
    <link href="libraries/assets/css/owl.theme.css" rel="stylesheet" />
    <link rel="stylesheet" href="management/plugins/select2/select2.min.css" />
    <!-- /.intro -->
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-3 page-sidebar col-thin-right">
                    <aside>
                        <div class="inner-box">
                            <h2 class="title-2"><%= _valueCat%></h2>
                            <div class="inner-box-content">
                                <ul class="cat-list arrow">
                                    <asp:Repeater ID="kategoriRepeater" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:HyperLink ID="hypTur"
                                                    NavigateUrl='<%# subCat(Request.QueryString["kategoriId"])==true? 
                                                    String.Format("~/ilan-liste.aspx?kategoriId={0}&tur={1}",Request.QueryString["kategoriId"],Eval("turId")) 
                                                    :String.Format("~/ilan-liste.aspx?kategoriId={0}&tur={1}&sub={2}",Request.QueryString["kategoriId"],Eval("turId"), Request.QueryString["kategoriId"] ) %>'
                                                    runat="server">
                                                    <%# DAL.toolkit.donustur(Eval("turId")) %></asp:HyperLink>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </aside>
                </div>
                <div class="col-sm-9 page-content col-thin-left">

                    <div class="col-lg-12 content-box ">
                        <div class="row row-featured">

                            <div style="clear: both"></div>

                            <div class=" relative  content  clearfix">


                                <div class="">
                                    <div class="tab-lite">

                                        <!-- Nav tabs -->
                                        <ul class="nav nav-tabs " role="tablist">
                                            <li role="presentation" class="active"><a href="#tab1" aria-controls="tab1"
                                                role="tab" data-toggle="tab"><i id="icon" runat="server"></i>&nbsp; <%= _valueCat %></a> </li>
                                        </ul>

                                        <!-- Tab panes -->
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane active" id="tab1">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">
                                                        <div class="cat-list col-sm-3  col-xs-6 col-xxs-12">


                                                            <div class="form-group">
                                                                <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKategori" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpTur" runat="server"></asp:DropDownList>
                                                            </div>

                                                        </div>

                                                        <div class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <div class="form-group">
                                                                <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                                            </div>


                                                        </div>

                                                        <div class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <div class="form-group">
                                                                <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <a href="posting-success.html" id="button2id"
                                                                    class="btn btn-success btn-lg">Haritada Ara</a>
                                                            </div>



                                                        </div>

                                                        <div class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <div class="form-group">
                                                                <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <a href="posting-success.html" id="button1id"
                                                                    class="btn btn-success btn-lg">Ara</a>
                                                            </div>


                                                        </div>

                                                    </div>

                                                </div>


                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab2">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>


                                                        <ul class="cat-list col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Atlanta</a></li>
                                                            <li><a href="category.html">Wichita </a></li>
                                                            <li><a href="category.html">Anchorage </a></li>
                                                            <li><a href="category.html">Dallas </a></li>
                                                            <li><a href="category.html">New York </a></li>
                                                            <li><a href="category.html">Santa Ana/Anaheim </a></li>
                                                            <li><a href="category.html">Miami </a></li>
                                                            <li><a href="category.html">Los Angeles</a></li>
                                                        </ul>

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>


                                                    </div>

                                                </div>


                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab3">

                                                <div class="col-lg-12 tab-inner">

                                                    <div class="row">


                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>


                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>


                                                        <ul class="cat-list col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Atlanta</a></li>
                                                            <li><a href="category.html">Wichita </a></li>
                                                            <li><a href="category.html">Anchorage </a></li>
                                                            <li><a href="category.html">Dallas </a></li>
                                                            <li><a href="category.html">New York </a></li>
                                                            <li><a href="category.html">Santa Ana/Anaheim </a></li>
                                                            <li><a href="category.html">Miami </a></li>
                                                            <li><a href="category.html">Los Angeles</a></li>
                                                        </ul>

                                                        <ul class="cat-list cat-list-border col-sm-3  col-xs-6 col-xxs-12">
                                                            <li><a href="category.html">Virginia Beach </a></li>
                                                            <li><a href="category.html">San Diego </a></li>
                                                            <li><a href="category.html">Boston </a></li>
                                                            <li><a href="category.html">Houston</a></li>
                                                            <li><a href="category.html">Salt Lake City </a></li>
                                                            <li><a href="category.html">San Francisco </a></li>
                                                            <li><a href="category.html">Tampa </a></li>
                                                            <li><a href="category.html">Washington DC </a></li>

                                                        </ul>


                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>


                            </div>

                        </div>
                    </div>

                </div>

            </div>
            <div class="col-lg-12 content-box ">
                <div class="row row-featured row-featured-category">
                    <div class="col-lg-12  box-title no-border">
                        <div class="inner">
                            <h2><span><%= _valueCat %></span>
                                VİTRİNİ <a href="category.html" class="sell-your-item">TÜMÜNÜ GÖSTER <i
                                    class="  icon-th-list"></i></a></h2>
                        </div>
                    </div>
                    <asp:Repeater ID="kategoriVitrinRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-4 f-category">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ilanId","~/ilan-detay.aspx?ilan={0}") %>'>
                                    <img src='upload/ilan/<%# Eval("resim") %>' class="img-responsive" alt="img" />
                                    <h6><%# Eval("baslik") %> </h6>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <!-- /.main-container -->

    <div class="page-bottom-info">
        <div class="page-bottom-info-inner">

            <div class="page-bottom-info-content text-center">
                <h1>If you have any questions, comments or concerns, please call the Classified Advertising department
                    at (000) 555-5555</h1>
                <a class="btn  btn-lg btn-primary-dark" href="tel:+000000000">
                    <i class="icon-mobile"></i><span class="hide-xs color50">Call Now:</span> (000) 555-5555 </a>
            </div>

        </div>
    </div>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>
    <script src="management/plugins/select2/select2.full.min.js"></script>
    <script src="management/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="management/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="management/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>


</asp:Content>
