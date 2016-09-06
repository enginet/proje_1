<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bina-yasi-arama.ascx.cs" Inherits="PL.ozellikler.bina_yasi_arama" %>

<label for="txtAcikMetreKare">Bina Yaşı</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtBinaYasiMin" CssClass="form-control" runat="server" name="24_1" placeholder="min bina yaşı"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtBinaYasiMax" CssClass="form-control" runat="server" name="24_2" placeholder="max bina yaşı"></asp:TextBox>
</div>