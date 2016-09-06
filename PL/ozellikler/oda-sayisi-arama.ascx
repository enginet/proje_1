<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="oda-sayisi-arama.ascx.cs" Inherits="PL.ozellikler.oda_sayisi_arama" %>
<label for="txtAcikMetreKare">Oda Sayısı</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtOdaSayisiMin" CssClass="form-control" runat="server" name="83_1" placeholder="min oda sayısı"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtOdaSayisiMax" CssClass="form-control" runat="server" name="83_2" placeholder="max oda sayısı"></asp:TextBox>
</div>