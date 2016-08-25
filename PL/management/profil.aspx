<%@ Page Title="" Language="C#" MasterPageFile="~/management/admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="profil.aspx.cs" Inherits="PL.management.profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="plugins/select2/select2.min.css">
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Profil
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Examples</a></li>
                <li class="active">User profile</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">

            <div class="row">
                <div class="col-md-3">

                    <!-- Profile Image -->
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <img class="profile-user-img img-responsive img-circle" src="../../../management/dist/img/user4-128x128.jpg" alt="User profile picture">
                            <h3 class="profile-username text-center">Burak Tahtacıoğlu</h3>
                            <p class="text-muted text-center">Software Engineer</p>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
                <div class="col-md-9">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#timeline" data-toggle="tab">Ayarlar</a></li>
                            <li><a href="#settings" data-toggle="tab">Zaman Tüneli</a></li>
                        </ul>
                        <div class="tab-content">
                            <!-- /.tab-pane -->
                            <div class="active tab-pane" id="timeline">
                                <!-- The timeline -->
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Ad</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtAd" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail" class="col-sm-2 control-label">Soyad</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtSoyad" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

<%--                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">E-Posta</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>--%>

                                    <div class="form-group">
                                        <label for="inputSkills" class="col-sm-2 control-label">İl</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputSkills" class="col-sm-2 control-label">İlçe</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged">
                                                <asp:ListItem Value="null">İlçe Seçiniz</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputSkills" class="col-sm-2 control-label">Mahalle</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpMahalle" runat="server">
                                                <asp:ListItem Value="null">Mahalle Seçiniz</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">TC Kimlik No</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtKimlikNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Eğitim Durumu</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="drpEgitim" class="form-control select2" runat="server">
                                                <asp:ListItem Value="1">Üniversite</asp:ListItem>
                                                <asp:ListItem Value="2">Yüksek Okul</asp:ListItem>
                                                <asp:ListItem Value="3">Lise</asp:ListItem>
                                                <asp:ListItem Value="4">Ortaokul</asp:ListItem>
                                                <asp:ListItem Value="5">İlkokul</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Meslek</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="drpMeslek" class="form-control select2" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Cinsiyet</label>
                                        <div class="col-sm-10">
                                            <asp:RadioButtonList ID="rdCinsiyet" runat="server">
                                                <asp:ListItem Value="True">Erkek</asp:ListItem>
                                                <asp:ListItem Value="False">Kadın</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Cep Telefonu 2</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtGsm2" runat="server" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">Sabit Telefonu</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtSabit" runat="server" class="form-control" data-inputmask='"mask": "(999) 999-9999"' data-mask></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <asp:Button ID="Kaydet" runat="server" CssClass="btn btn-primary" Text="Bilgilerimi Güncelle" OnClick="Kaydet_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.tab-pane -->

                            <div class="tab-pane" id="settings">
                                <ul class="timeline timeline-inverse">
                                    <!-- timeline time label -->
                                    <li class="time-label">
                                        <span class="bg-red">10 Feb. 2014
                                        </span>
                                    </li>
                                    <!-- /.timeline-label -->
                                    <!-- timeline item -->
                                    <li>
                                        <i class="fa fa-clock-o bg-aqua"></i>
                                        <div class="timeline-item">
                                            <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                            <h3 class="timeline-header no-border"><a href="#">Sarah Young</a> accepted your friend request</h3>
                                        </div>
                                    </li>
                                    <!-- END timeline item -->
                                    <!-- END timeline item -->
                                    <!-- timeline item -->
                                    <li>
                                        <i class="fa fa-clock-o bg-aqua"></i>
                                        <div class="timeline-item">
                                            <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                            <h3 class="timeline-header no-border"><a href="#">Sarah Young</a> accepted your friend request</h3>
                                        </div>
                                    </li>
                                    <!-- END timeline item -->
                                    <!-- timeline time label -->
                                    <li class="time-label">
                                        <span class="bg-green">3 Jan. 2014
                                        </span>
                                    </li>
                                    <!-- /.timeline-label -->
                                    <!-- timeline item -->
                                    <li>
                                        <i class="fa fa-clock-o bg-aqua"></i>
                                        <div class="timeline-item">
                                            <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                            <h3 class="timeline-header no-border"><a href="#">Sarah Young</a> accepted your friend request</h3>
                                        </div>
                                    </li>
                                    <li>
                                        <i class="fa fa-clock-o bg-gray"></i>
                                    </li>
                                </ul>
                            </div>
                            <!-- /.tab-pane -->
                        </div>
                        <!-- /.tab-content -->
                    </div>
                    <!-- /.nav-tabs-custom -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->

        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->

    <script src="plugins/select2/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <script>
        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();


        });
    </script>

</asp:Content>
