<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cep-telefonu.ascx.cs" Inherits="PL.profil.cep_telefonu" %>
<div class="col-sm-9 page-content">
    <div class="inner-box">
        <div runat="server" id="uyelikField">

            <div id="accordion" class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">Cep Telefonu </a></h4>
                    </div>
                    <div class="panel-collapse collapse in" id="collapseB1">
                        <div class="panel-body">
                            <div class="form-horizontal" role="form">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Kayıtlı cep telefonunuz</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtGsm1" CssClass="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9"></div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <asp:Button ID="Degistir" runat="server" CssClass="btn btn-primary btn-lg" Text="Değiştir" OnClick="Degistir_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</div>
<script src="../management/plugins/input-mask/jquery.inputmask.js"></script>
<script>
    $(function () {
        //Money Euro
        $("[data-mask]").inputmask();

    });
</script>
