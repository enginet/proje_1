<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="arama-sonuclari.aspx.cs" Inherits="PL.arama_sonuclari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-container">
        <div class="container">        
            <div class="row">
                <div class="col-sm-12 page-content col-thin-right">
                    <div class="inner-box category-content">
                        <h2 class="title-2">Arama Sonuçları </h2>

                        <div class="row">
                            <div class="col-md-4 col-sm-4 ">
                                <div class="cat-list">
                                    <h3 class="cat-title"><a href="#"><i class="icon-home ln-shadow"></i>
                                        Emlak <span class="count">228,705</span></a> <span data-target=".cat-id-4"
                                            data-toggle="collapse"
                                            class="btn-cat-collapsed collapsed"><span
                                                class=" icon-down-open-big"></span></span></h3>
                                    <ul class="cat-collapse collapse in cat-id-2">
                                        <asp:Repeater ID="kategoriRepeater" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <li>
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# catKind(Eval("kategoriId"))==true?Eval("kategoriId","~/kategoriler.aspx?kategoriId={0}")
                                                                 :String.Format("~/ilan-liste.aspx?kategoriId={0}",Eval("kategoriId"))
                                                                              %>'> <%# Eval("kategoriAdi") %></asp:HyperLink>
                                                        <%--                                                        <asp:HyperLink ID="hypTur" NavigateUrl='<%# GetRouteUrl("kategori", new { kategoriAd = DAL.toolkit.UrlDonustur(Eval("kategoriAdi")), kategoriId = Eval("kategoriId")  }) %>' runat="server"><%# Eval("kategoriAdi") %></asp:HyperLink>--%>
                                                    </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>          
            </div>
        </div>
    </div>
</asp:Content>
