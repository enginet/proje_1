<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="kimden-ozellik.ascx.cs" Inherits="PL.ozellikler.kimden_ozellik" %>


<div class="form-group">
    <label for="editor1">Özel Açıklama</label>
    <div>
        <asp:TextBox ID="ozelAciklama" runat="server" CssClass="form-control" name="65" TextMode="MultiLine" ></asp:TextBox>
    </div>
</div>

<div class="form-group">
    <label for="txtMuammen">Muammen Bedeli</label>
    <asp:TextBox ID="txtMuammen" CssClass="form-control" runat="server" name="60"></asp:TextBox>
</div>

<div class="form-group">
    <label for="txtAidat">Teminat Miktarı</label>
    <asp:TextBox ID="txtTeminat" CssClass="form-control" name="61" runat="server"></asp:TextBox>
</div>

<div class="form-group">
    <label for="txtAidat">Satış Yeri</label>
    <asp:TextBox ID="txtSatisYeri" CssClass="form-control" name="62" runat="server"></asp:TextBox>
</div>

<div class="form-group">
    <label>1. Satış Tarihi :</label>

    <div class="input-group date">
        <div class="input-group-addon">
            <i class="fa fa-calendar"></i>
        </div>
        <asp:TextBox ID="txtSatisTarih1" runat="server" name="63" CssClass="form-control pull-right satisTarih"></asp:TextBox>
    </div>
</div>

<div class="form-group">
    <label>2. Satış Tarihi :</label>

    <div class="input-group date">
        <div class="input-group-addon">
            <i class="fa fa-calendar"></i>
        </div>
        <asp:TextBox ID="txtSatisTarih2" runat="server" name="64" CssClass="form-control pull-right satisTarih"></asp:TextBox>
    </div>
</div>

