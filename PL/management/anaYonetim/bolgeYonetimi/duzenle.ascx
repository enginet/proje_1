﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="duzenle.ascx.cs" Inherits="PL.management.anaYonetim.bolgeYonetimi.ilduzenle" %>
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Bölge Düzenle
            <small>buradan bölge düzenleyebilirsiniz.</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">General Elements</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
<div class="col-md-3">
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Bana özel</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <li>
                                <asp:HyperLink NavigateUrl="~/management/araclar/araclar.aspx?page=gelenkutusu" runat="server"><i class="fa fa-inbox"></i>Gelen Kutusu </asp:HyperLink></li>
                            <li>
                                <asp:HyperLink NavigateUrl="~/management/araclar/araclar.aspx?page=gonderilen-kutusu" runat="server"><i class="fa fa-envelope-o"></i>Gönderilen Kutusu</asp:HyperLink></li>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /. box -->
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Online Kullanıcılar</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <asp:Repeater ID="onlineRepeater" runat="server">
                                <ItemTemplate>
                                    <li><a href="#"><i class="fa fa-circle text-success"></i><%# Eval("kullaniciAdSoyad") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- left column -->
            <div class="col-md-9">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Bölge Düzenle Formu</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div>
                                <div class="form-group">
                                    <label for="txtIl">Bölge Adı</label>
                                    <input type="text" class="form-control" id="txtIl" runat="server">
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <asp:Button ID="Kaydet" runat="server" CssClass="btn btn-success" Text="Kaydet" OnClick="Kaydet_Click" />
                            <asp:Button ID="Vazgeç" runat="server" CssClass="btn btn-danger" Text="Vazgeç" OnClick="Vazgeç_Click" />
                        </div>
                    </div>
                </div>
                <!-- /.box -->
            </div>
            <!--/.col (left) -->
            <!-- right column -->
            <!--/.col (right) -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->
