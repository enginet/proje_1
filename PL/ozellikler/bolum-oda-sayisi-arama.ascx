<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bolum-oda-sayisi-arama.ascx.cs" Inherits="PL.ozellikler.bolum_oda_sayisi_arama" %>

<label for="txtAcikMetreKare">Bölüm / Oda Sayısı </label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtBolumOdaSayiMin" CssClass="form-control" runat="server" name="25_1" placeholder="min sayı"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtBolumOdaSayiMax" CssClass="form-control" runat="server" name="25_2" placeholder="max sayı"></asp:TextBox>
</div>
