<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="odeme-tablo.ascx.cs" Inherits="PL.odeme_tablo" %>
<table id="example1" class="table table-responsive table-hover">
    <thead>
        <tr>
            <th class="col-md-5" style="font-size: 16px;">Hizmet</th>
            <th class="col-md-2" style="font-size: 16px;">Tutar</th>
            <th class="col-md-2" style="font-size: 16px;">Tarih</th>
            <th class="col-md-2" style="font-size: 16px;">Ödeme Tipi</th>
            <th class="col-md-1" style="font-size: 16px;">İşlem</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="odemeRepeater" runat="server" OnItemCommand="odemeRepeater_ItemCommand">
            <ItemTemplate>
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <tr>
                        <td>
                            <span style="font-size: 16px;"><%# Eval("hizmet") %></span>
                        </td>
                        <td>
                            <span style="font-size: 16px;" class="tutar"><%# Eval("miktar") %> TL</span>
                        </td>
                        <td>
                            <span style="font-size: 16px;"><%# DateTime.Now.ToShortDateString() %></span>
                        </td>
                        <td>
                            <span style="font-size: 16px;"><%# odemeTipDondur(Convert.ToInt32(Eval("odemeTipId"))) %></span>
                        </td>
                        <td>
                            <asp:LinkButton ID="OdemeSil" CommandName="Sil" OnClientClick="javascript:if(!confirm('Silmek istediğinizden emin misiniz ?'))return false;" CommandArgument='<%#Eval("odemeId") %>' Style="font-size: 14px; color: #343434;" Visible='<%# Convert.ToInt32(Eval("islemId")) == 14 ? false : true %>' runat="server"><span class="fa fa-close" style="margin-right:5px;"></span>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<div class="col-xs-3 col-xs-offset-9">
    <label style="float: right; font-size: 15px;">Toplam Tutar : <span id="toplamTutar" style="font-size: 16px; font-weight: bold; margin-left: 10px;"></span></label>
</div>

<script type="text/javascript">
    function hesapla() {

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            var tutar = 0;
            $('.tutar').each(function (i) {
                tutar += parseFloat($(this).text());
            });
            $("#toplamTutar").text(tutar + " TL");
        });
    }
</script>
