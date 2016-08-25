<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bildirim-oku.ascx.cs" Inherits="PL.profil.bildirim_oku" %>
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <h2 class="title-2"><i class="icon-docs"></i>Bilgilendirme </h2>
        <div class="item-list">
            <!--/.photobox-->
            <div class="col-sm-7 add-desc-box">
                <div class="add-details">
                    <h5  class="add-title" ><p runat="server" id="baslik"> </p></h5>
                    <span class="info-row"><span class="add-type business-ads tooltipHere"
                        data-toggle="tooltip"
                        data-placement="right"
                        title="Business Ads">B </span><span
                            class="date" runat="server" id="tarih"><i class=" icon-clock"></i></span></span>
                </div>
            </div>
        </div>
        <div runat="server" id="mesaj">
        </div>
    </div>
</div>
