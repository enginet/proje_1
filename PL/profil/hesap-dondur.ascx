<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hesap-dondur.ascx.cs" Inherits="PL.profil.hesap_dondur" %>
<div class="col-sm-9 page-content">


    <div class="inner-box">
        <h2 class="title-2"><i class="icon-cancel-circled "></i>Hesabımı Kapat</h2>

        <p>
            Üyeliğinizi iptal etmek istemenize üzüldük...<br />
            <br />

            Sizi netteilanver.com ailesinin bir üyesi olarak görmeye devam etmek istediğimiz için görüşleriniz bizim için çok değerli. Üyeliğiniz ile ilgili yaşadığınız bir sorun veya sormak istedikleriniz varsa bize Destek Merkezi üzerinden ulaşabilirsiniz.
            <br />
            netteilanver.com üyeliğinizi iptal ederseniz;
        </p>
        <ol>
            <li><i class="fa fa-minus-square"></i>  Yayında olan ilanlarınızın tamamı yayından kalkacaktır,</li>
            <li><i class="fa fa-minus-square"></i>  Doping kullandığınız ilanınız varsa ücret iadesi yapılamayacaktır,</li>
            <li><i class="fa fa-minus-square"></i>  E-posta adresinizin yeni bir üyelikte kullanılamayacağını da üzülerek hatırlatmak isteriz.</li>
        </ol>
        <br />
        <asp:Button ID="Iptal" type="submit" CssClass="btn btn-primary" runat="server" Text="Üyeliğimi İptal Etmek İstiyorum" OnClick="Iptal_Click" />
    </div>
    <!--/.inner-box-->
</div>
