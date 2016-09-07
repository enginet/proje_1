<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="banyo-sayisi-arama.ascx.cs" Inherits="PL.ozellikler.banyo_sayisi_text_arama" %>
<label for="txtAcikMetreKare">Banyo Sayısı</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtBanyoSayisiMin" CssClass="form-control double " runat="server" name="17_1" placeholder="min banyo sayısı"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtBanyoSayisiMax" CssClass="form-control double " runat="server" name="17_2" placeholder="max banyo sayısı"></asp:TextBox>
</div>