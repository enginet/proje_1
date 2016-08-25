<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="alt-yapi.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.ozellikler.alt_yapi" %>
<%--<link rel="stylesheet" href="management/plugins/iCheck/flat/blue.css">--%>
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>'>
<div class="form-group">
    <div class="box box-primary collapsed-box box-solid">
        <div class="box-header with-border">
            <h3 class="box-title">Alt Yapı</h3>
            <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
            </div>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="form-group">
                <asp:Repeater ID="altYapiRepeater" runat="server">
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
<!-- /.col -->
<script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
<%--<script src="management/plugins/iCheck/icheck.min.js"></script>--%>
<!-- Page Script -->
<script>
    $(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    });
</script>
