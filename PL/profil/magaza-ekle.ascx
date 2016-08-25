<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="magaza-ekle.ascx.cs" Inherits="PL.profil.mağaza_ekle" %>
<link rel="stylesheet" href="../management/plugins/select2/select2.min.css">
<link rel="stylesheet" href="../management/dist/css/AdminLTE.min.css">
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <div id="accordion" class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Mağaza Fatura Bilgileri </a></h4>
                </div>
                <div class="panel-collapse collapse in" id="collapseB1">
                    <div class="panel-body">
                        <div class="col-md-9 form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3">Firma Adı</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtMagazaAdi" runat="server">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Firma Tipi</label>
                                <div class="col-sm-9">
                                    <asp:RadioButtonList ID="rdBireyseli" runat="server" RepeatDirection="Horizontal" Height="33px" Width="386px" OnSelectedIndexChanged="rdBireyseli_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="false" Selected>  Şahıs Şirketi </asp:ListItem>
                                        <asp:ListItem Value="true"> Limited veya Anonim Şirket</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Cep Telefonu</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtCepTlf" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <!-- /.form group -->
                            <div class="form-group">
                                <label class="col-sm-3">İş Telefonu</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtIsTlf" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <!-- /.form group -->
                            <div class="form-group">
                                <label class="col-sm-3">İş Telefonu 2</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="txtIsTlf2" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.input group -->
                            </div>

                            <div class="form-group">
                                <label class="col-sm-3">İl</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">İlçe</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3">Mahalle</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label id="lblTc" class="col-sm-3" runat="server">TC Kimlik No</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="txtTcNo" runat="server">
                                </div>
                            </div>
                            <div class="form-group" id="vergiPnl" runat="server">
                                <label class="col-sm-3">Vergi Dairesi</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList CssClass="form-control" Style="width: 100%;" ID="drpVergi" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- Button  -->
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>
                                <div class="col-md-8">
                                    <asp:Button ID="btnKaydet" CssClass="btn btn-success btn-lg" runat="server" Text="Kaydet ve Devam Et" OnClick="btnKaydet_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-box End-->
    </div>
</div>
<script src="../management/plugins/input-mask/jquery.inputmask.js"></script>
<script src="../management/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../management/plugins/input-mask/jquery.inputmask.extensions.js"></script>
<script src="../management/plugins/select2/select2.full.min.js"></script>

<script>
    $(function () {
        $(".select2").select2();
        //Datemask dd/mm/yyyy
        $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
        //Datemask2 mm/dd/yyyy
        $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
        //Money Euro
        $("[data-mask]").inputmask();
    });
</script>
