<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="arsa-ozellik.ascx.cs" Inherits="PL.ozellikler.arsa_ozellik" %>
<div class="form-group">
    <label for="txtPaftaNo" id="paftano" runat="server">Pafta No</label>
    <asp:TextBox ID="txtPaftaNo" CssClass="form-control double" runat="server" name="8"></asp:TextBox>
</div>
<div class="form-group" id="metrekarefiyat">
    <label for="txtMetreFiyat" runat="server" id="metrefiyat">m<sup>2</sup> Fiyatı</label>
    <asp:TextBox ID="txtMetreFiyat" CssClass="form-control double metrekareFiyat" runat="server" name="12"></asp:TextBox>
</div>
<div class="form-group">
    <label>Malik Durum</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMalikDrm" AutoPostBack="true" OnSelectedIndexChanged="drpMalikDrm_SelectedIndexChanged" runat="server" name="106"></asp:DropDownList>
</div>
<div class="form-group">
    <label for="txtHisseAlani" runat="server" id="lblHisseAlani" visible="false">Hisse Alanı</label>
    <asp:TextBox ID="txtHisseAlani" CssClass="form-control double" Visible="false" runat="server" name="107"></asp:TextBox>
</div>
<div class="form-group">
    <label runat="server" id="lblImarDrm">İmar Durumu</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpImarDrm" AutoPostBack="true" OnSelectedIndexChanged="drpImarDrm_SelectedIndexChanged" runat="server" name="108"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblImarNitelik" visible="false">İmar Niteliği</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpImarNitelik" runat="server" name="109"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblYapiNizam" visible="false">Yapı Nizamı</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpYapiNizam" runat="server" name="110"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblTask" visible="false">Task</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpTask" runat="server" name="111"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblKask" visible="false">Kask</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpKask" runat="server" name="9"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblEmsal" visible="false">Emsal</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpEmsal" runat="server" name="112"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblGabari" visible="false">Gabari (Yükseklik)</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpGabari" runat="server" name="10"></asp:DropDownList>
</div>
<div class="form-group">
    <label runat="server" id="lblKat" visible="false">Kat Karşılığı</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" Visible="false" ID="drpKatKar" runat="server" name="11"></asp:DropDownList>
</div>
