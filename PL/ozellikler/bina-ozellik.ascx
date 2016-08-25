<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bina-ozellik.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.ozellikler.bina_ozellik" %>
<div class="form-group">
    <div class="box box-warning collapsed-box box-solid">
        <div class="box-header with-border">
            <h3 class="box-title">Bina Özellikleri</h3>
            <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="form-group">
                <asp:Repeater ID="binaOzelRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 col-xs-6">
                            <div class="checkbox icheck">
                                <asp:CheckBox ID="chcAltYapi" type="checkbox" Text='<%#Eval("deger") %>' value='<%#Eval("secilebilirOzellikDegerId") %>' runat="server" />

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->
</div>
