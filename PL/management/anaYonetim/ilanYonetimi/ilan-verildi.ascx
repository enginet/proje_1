<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ilan-verildi.ascx.cs" Inherits="PL.management.anaYonetim.ilanYonetimi.ilan_verildi" %>
<link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>'>

<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">General Elements</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12" style="margin-top:25px;">
                <div class="alert alert-success">
                    <h2 style="padding:0; margin:0">İlan başarıyla yayına verildi</h2>
                </div>
                <div class="clearfix"></div>
                <label style="font-size:21px;">İlan numarası : <span style="font-weight: bold; padding:0 10px; color:#5ec716; background:#fff;" id="ilanNo" runat="server"></span></label>
            </div>
        </div>
    </section>
</div>
