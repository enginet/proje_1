<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="cep-aktivasyon.aspx.cs" Inherits="PL.cep_aktivasyon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-md-8 page-content" style="background-color:white; padding:20px; min-height:467px;" id="onay" runat="server">
                    <p>Cep telefonunuza gelen kodu giriniz</p>
                    <div class="clearfix"></div>
                    <div class="form-group required">
                        <label class="control-label">Onay Kodu <sup>*</sup></label>
                        <asp:TextBox ID="txtOnayKodu" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="dogrula" runat="server" Text="Doğrula" CssClass="btn btn-success" OnClick="dogrula_Click" />
                    </div>
                </div>
                <!-- /.page-content -->
                <div class="col-md-3 reg-sidebar">
                    <div class="reg-sidebar-inner text-center">
                        <div class="promo-text-box">
                            <i class=" icon-picture fa fa-4x icon-color-1"></i>
                            <h3><strong>İlanlarını Ücretsiz Yayınla</strong></h3>
                            <p>
                                Post your free online classified ads with us. Lorem ipsum dolor sit amet, consectetur
                                adipiscing elit.
                            </p>
                        </div>
                        <div class="panel sidebar-panel">
                            <div class="panel-heading uppercase">
                                <small><strong>How to sell quickly?</strong></small>
                            </div>
                            <div class="panel-content">
                                <div class="panel-body text-left">
                                    <ul class="list-check">
                                        <li>Use a brief title and description of the item</li>
                                        <li>Make sure you post in the correct category</li>
                                        <li>Add nice photos to your ad</li>
                                        <li>Put a reasonable price</li>
                                        <li>Check the item before publish</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
