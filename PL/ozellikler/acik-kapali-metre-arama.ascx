<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="acik-kapali-metre-arama.ascx.cs" Inherits="PL.ozellikler.acik_kapali_metre_arama" %>

<label for="txtAcikMetreKare">Açık Alan Metrekare</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtAcikMetreKareMin" CssClass="form-control double" runat="server" name="1_1" placeholder="min metrekare"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtAcikMetreKareMax" CssClass="form-control double" runat="server" name="1_2" placeholder="max metrekare"></asp:TextBox>
</div>
<div class="clearfix"></div>
<label for="txtKapaliMetreKare">Kapalı Alan Metrekare</label>
<div class="clearfix"></div>
<div class="form-group col-xs-6" style="padding-left: 0;">
    <asp:TextBox ID="txtKapaliMetreKareMin" CssClass="form-control double" runat="server" placeholder="min metrekare" name="2_1"></asp:TextBox>
</div>
<div class="form-group col-xs-6" style="padding-right: 0;">
    <asp:TextBox ID="txtKapaliMetreKareMax" CssClass="form-control double" runat="server" placeholder="max metrekare" name="2_2"></asp:TextBox>
</div>
