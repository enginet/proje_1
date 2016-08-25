<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="kredi-takas.ascx.cs" Inherits="PL.ozellikler.kredi_takas" %>
<div class="form-group">
    <div class="checkbox icheck">
        <asp:CheckBox ID="chcKredi" type="checkbox" Text="Kredi Uygun" runat="server" value="295_296"/>
    </div>
</div>
<div class="form-group">
    <label>Takaslı</label>
    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpTakasli" runat="server" name="105"></asp:DropDownList>
</div>
