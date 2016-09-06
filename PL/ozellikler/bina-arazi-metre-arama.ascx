<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bina-arazi-metre-arama.ascx.cs" Inherits="PL.ozellikler.bina_arazi_metre_arama" %>

<label for="txtAcikMetreKare">Bina Metrekare</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtBinaMetrekareMin" CssClass="form-control" runat="server" name="19_1" placeholder="min metrekare"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtBinaMetrekareMax" CssClass="form-control" runat="server" name="19_2" placeholder="max metrekare"></asp:TextBox>
</div>
<div class="clearfix"></div>
<label for="txtKapaliMetreKare">Arazi Metrekare</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtAraziMetrekareMin" CssClass="form-control" runat="server" placeholder="min metrekare" name="20_1"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtAraziMetrekareMax" CssClass="form-control" runat="server" placeholder="max metrekare" name="20_2"></asp:TextBox>
</div>
