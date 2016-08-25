<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="magaza-fiyatları.aspx.cs" Inherits="PL.magaza_fiyatları" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .toggle-header {
            padding: 10px 0;
            margin: 10px 0;
            background-color: black;
            color: white;
        }

        .txt-green {
            color: green;
        }

        .txt-red {
            color: red;
        }
    </style>
    <style>
        .pricing-table .plan {
            margin-left: 0px;
            border-radius: 5px;
            text-align: center;
            background-color: #f3f3f3;
            -moz-box-shadow: 0 0 6px 2px #b0b2ab;
            -webkit-box-shadow: 0 0 6px 2px #b0b2ab;
            box-shadow: 0 0 6px 2px #b0b2ab;
        }

        .plan:hover {
            background-color: #fff;
            -moz-box-shadow: 0 0 12px 3px #b0b2ab;
            -webkit-box-shadow: 0 0 12px 3px #b0b2ab;
            box-shadow: 0 0 12px 3px #b0b2ab;
        }

        .plan {
            padding: 20px;
            margin-left: 0px;
            color: #ff;
            background-color: #5e5f59;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-bronze {
            padding: 20px;
            color: #fff;
            background-color: #665D1E;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-silver {
            padding: 20px;
            color: #fff;
            background-color: #C0C0C0;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .plan-name-gold {
            padding: 20px;
            color: #fff;
            background-color: #FFD700;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .pricing-table-bronze {
            padding: 20px;
            color: #fff;
            background-color: #f89406;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            border-radius: 5px 5px 0 0;
        }

        .pricing-table .plan .plan-name span {
            font-size: 20px;
        }

        .pricing-table .plan ul {
            list-style: none;
            margin: 0;
            -moz-border-radius: 0 0 5px 5px;
            -webkit-border-radius: 0 0 5px 5px;
            border-radius: 0 0 5px 5px;
        }

            .pricing-table .plan ul li.plan-feature {
                padding: 15px 10px;
                border-top: 1px solid #c5c8c0;
                margin-right: 35px;
            }

        .pricing-three-column {
            margin: 0 auto;
            width: 80%;
        }

        .pricing-variable-height .plan {
            float: none;
            margin-left: 2%;
            vertical-align: bottom;
            display: inline-block;
            zoom: 1;
            *display: inline;
        }

        .plan-mouseover .plan-name {
            background-color: #4e9a06 !important;
        }

        .btn-plan-select {
            padding: 8px 25px;
            font-size: 18px;
        }
    </style>
    <div class="main-container">
        <div class="container">
            <div class="row form-group">
                <div class="col-xs-12">
                    <ul class="nav nav-pills nav-justified thumbnail setup-panel">
                        <li class="active"><a href="#step-1">
                            <h4 class="list-group-item-heading"><i class="fa fa-home fa-2x"></i></h4>
                            <p class="list-group-item-text">Emlak</p>
                        </a></li>
                        <li class="active"><a href="#step-2">
                            <h4 class="list-group-item-heading"><i class="fa fa-taxi fa-2x"></i></h4>
                            <p class="list-group-item-text">Vasıta</p>
                        </a></li>
                    </ul>
                </div>
            </div>
            <div class="row setup-content" id="step-1">
          
                 <div class="row">
                            <div class="panel panel-primary clearfix">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Mağaza Fiyatları</h3>

                                </div>

                                <div class="col-xs-12 toggle-header">
                                    <div class="col-xs-6">
                                        <button type="button" class="btn btn-primary btn-sm hidden-xs" data-toggle="collapse" data-target="#feature-1">
                                            <i class="glyphicon glyphicon-resize-vertical"></i>Gizle
                                        </button>
                                        <button type="button" class="btn btn-primary btn-xs visible-xs" data-toggle="collapse" data-target="#feature-1">
                                            <i class="glyphicon glyphicon-resize-vertical"></i>Gizle
                                        </button>
                                    </div>
                                    <div class="col-xs-2 text-center">
                                        <span class="hidden-xs">Standart Mağaza</span>
                                        <span class="visible-xs">Stndrt Mğz</span>
                                    </div>
                                    <div class="col-xs-2 text-center">
                                        <span class="hidden-xs">Premium Mağaza</span>
                                        <span class="visible-xs">Prmm Mğz</span>
                                    </div>
                                </div>

                                <div id="feature-1" class="collapse in">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                Fiyat                                             
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-ok txt-green"></i>
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-ok txt-green"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                Fotoğraf
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-remove txt-red"></i>
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-remove txt-red"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                Mağaza Kullanıcısı
                                            </div>
                                            <div class="col-xs-2 text-center">
                                               5 Adet
                                            </div>
                                            <div class="col-xs-2 text-center">
                                               15 Adet
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                Listelerde Fotoğraflı Gösterim
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-remove txt-red"></i>
                                            </div>
                                            <div class="col-xs-2 text-center">
                                                <i class="glyphicon glyphicon-ok txt-green"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
               
            </div>
            <div class="row setup-content" id="step-2">
                <div class="col-xs-12">
                </div>
            </div>
            <%--            <div class="row setup-content" id="step-3">
                <div class="col-xs-12">
                    <div class="col-md-12 well">
                        <h1 class="text-center">STEP 3</h1>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
    <script>
        $(document).ready(function () {

            var navListItems = $('ul.setup-panel li a'),
                allWells = $('.setup-content');

            allWells.hide();

            navListItems.click(function (e) {
                e.preventDefault();
                var $target = $($(this).attr('href')),
                    $item = $(this).closest('li');

                if (!$item.hasClass('disabled')) {
                    navListItems.closest('li').removeClass('active');
                    $item.addClass('active');
                    allWells.hide();
                    $target.show();
                }
            });

            $('ul.setup-panel li.active a').trigger('click');

            // DEMO ONLY //
            $('#activate-step-2').on('click', function (e) {
                $('ul.setup-panel li:eq(1)').removeClass('disabled');
                $('ul.setup-panel li a[href="#step-2"]').trigger('click');
                $(this).remove();
            })
            $('#activate-step-3').on('click', function (e) {
                $('ul.setup-panel li:eq(1)').removeClass('disabled');
                $('ul.setup-panel li a[href="#step-3"]').trigger('click');
                $(this).remove();
            })
        });


    </script>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>

</asp:Content>
