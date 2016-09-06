<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ilan.ascx.cs" Inherits="PL.profil.ilan" %>
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
                                        <span>Yayındaki Tüm İlanlar</span></a>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <!--/.listing-filter-->

                        <div class="adds-wrapper">
                            <asp:Repeater ID="yayindaRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="item-list">
                                        <div class="col-sm-2 no-padding photobox">
                                            <div class="add-image">
                                                <span class="photo-count"><i
                                                    class="fa fa-hashtag"></i><%# Eval("ilanId") %> </span><a href="ads-details.html">
                                                        <img
                                                            class="thumbnail no-margin" src="../upload/ilan/<%#Eval("resim") %>"
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
                                                        class="date"><i class=" icon-clock"></i><%# Eval("baslangicTarihi","{0:dd.MMMM.yyyy}") %> </span>- <span
                                                            class="category"><%# Eval("kategoriAdi") %> </span>- <span
                                                                class="item-location"><i class="fa fa-map-marker"></i><%# Eval("ilAdi") %> </span>
                                                    <span
                                                        class="item-location"><i class="fa fa-eye"></i><%# Eval("ziyaretci") %> </span>
                                                </span>
                                            </div>
                                        </div>
                                        <!--/.add-desc-box-->
                                        <div class="col-sm-5 text-right  price-box">
                                            <h2 class="item-price"> <%# Eval("fiyat") %> </h2>
                                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=ilan&proc={0}&classified={1}", 2 ,Eval("ilanId"))%>'><i
                                                class="fa fa-times"></i><span>Yayından Kaldır</span></asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-primary  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/profil/profil.aspx?control=ilan&proc={0}&classified={1}", 3 ,Eval("ilanId"))%>'><i
                                                class="fa fa-certificate"></i><span>Doping</span></asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-warning  btn-sm make-favorite" NavigateUrl='<%# String.Format("~/ilan-duzenle.aspx?ilan={0}",Eval("ilanId"))%>'><i
                                                class="fa fa-pencil"></i><span>Düzenle</span></asp:HyperLink>
                                        </div>
                                        <!--/.add-desc-box-->
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--/.adds-wrapper-->

<%--                        <div class="tab-box  save-search-bar text-center">
                            <a href=""><i class=" icon-plus"></i>
                                Yayında İlanınız Bulunmamaktadır.  </a>
                        </div>--%>
                    </div>


<%--                    <div class="pagination-bar text-center">
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
                        <li class="postadd">
                            <asp:HyperLink ID="hypIlanVer" CssClass="btn  btn-border btn-post btn-danger" Style="font-size: 14px;" runat="server" NavigateUrl="~/kategori-secimi.aspx"><span class="ion ion-plus-round" style="font-size: 16px; padding-right: 5px;"></span> Ücretsiz İlan Ver</asp:HyperLink>
                        </li>
                    </div>
                    <!--/.post-promo-->

                </div>
            </div>
        </div>

    </div>
</div>
<script src="../libraries/assets/js/footable.js?v=2-0-1" type="text/javascript"></script>
<script src="../libraries/assets/js/footable.filter.js?v=2-0-1" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('#addManageTable').footable().bind('footable_filtering', function (e) {
            var selected = $('.filter-status').find(':selected').text();
            if (selected && selected.length > 0) {
                e.filter += (e.filter && e.filter.length > 0) ? ' ' + selected : selected;
                e.clear = !e.filter;
            }
        });

        $('.clear-filter').click(function (e) {
            e.preventDefault();
            $('.filter-status').val('');
            $('table.demo').trigger('footable_clear_filter');
        });

    });
</script>
<!-- include custom script for ads table [select all checkbox]  -->
<script>

    function checkAll(bx) {
        var chkinput = document.getElementsByTagName('input');
        for (var i = 0; i < chkinput.length; i++) {
            if (chkinput[i].type == 'checkbox') {
                chkinput[i].checked = bx.checked;
            }
        }
    }

</script>

<!-- include jquery.fs plugin for custom scroller and selecter  -->
<script src="../libraries/assets/plugins/jquery.fs.scroller/jquery.fs.scroller.js"></script>
<script src="../libraries/assets/plugins/jquery.fs.selecter/jquery.fs.selecter.js"></script>
<!-- include custom script for site  -->
<script src="../libraries/assets/js/script.js"></script>
