﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="arsa-ozellik.ascx.cs" Inherits="PL.ozellikler.arsa_ozellik" %>
<div class="form-group">
    <label for="txtMetreFiyat">m<sup>2</sup> Fiyatı</label>
    <asp:TextBox ID="txtMetreFiyat" CssClass="form-control" runat="server" name="12"></asp:TextBox>
</div>
<div class="form-group">
    <label>Kask</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKask" runat="server" name="9"></asp:DropDownList>
</div>
<div class="form-group">
    <label>Gabari</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpGabari" runat="server" name="10"></asp:DropDownList>
</div>
<div class="form-group">
    <label>Kat Karşılığı</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKatKar" runat="server" name="11"></asp:DropDownList>
</div>
<div class="form-group" runat="server" id="pafta">
    <label for="txtPaftaNo">Pafta No</label>
    <asp:TextBox ID="txtPaftaNo" CssClass="form-control" runat="server" name="8" ></asp:TextBox>
</div>