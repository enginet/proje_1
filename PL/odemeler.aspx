<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="odemeler.aspx.cs" Inherits="PL.odeme_deneme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .pricing-table .plan {
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

        .wizard {
        }

            .wizard .nav-tabs {
                position: relative;
                margin: 40px auto;
                margin-bottom: 0;
                border-bottom-color: #e0e0e0;
            }

            .wizard > div.wizard-inner {
                position: relative;
            }

        .connecting-line {
            height: 2px;
            background: #e0e0e0;
            position: absolute;
            width: 80%;
            margin: 0 auto;
            left: 0;
            right: 0;
            top: 50%;
            z-index: 1;
        }

        .wizard .nav-tabs > li.active > a, .wizard .nav-tabs > li.active > a:hover, .wizard .nav-tabs > li.active > a:focus {
            color: #555555;
            cursor: default;
            border: 0;
            border-bottom-color: transparent;
        }

        span.round-tab {
            width: 70px;
            height: 70px;
            line-height: 70px;
            display: inline-block;
            border-radius: 100px;
            background: #fff;
            border: 2px solid #e0e0e0;
            z-index: 2;
            position: absolute;
            left: 0;
            text-align: center;
            font-size: 25px;
        }

            span.round-tab i {
                color: #555555;
            }

        .wizard li.active span.round-tab {
            background: #fff;
            border: 2px solid #16A085;
        }

            .wizard li.active span.round-tab i {
                color: #16A085;
            }

        span.round-tab:hover {
            color: #333;
            border: 2px solid #333;
        }

        .wizard .nav-tabs > li {
            width: 25%;
        }

        .wizard li:after {
            content: " ";
            position: absolute;
            left: 46%;
            opacity: 0;
            margin: 0 auto;
            bottom: 0px;
            border: 5px solid transparent;
            border-bottom-color: #16A085;
            transition: 0.1s ease-in-out;
        }

        .wizard li.active:after {
            content: " ";
            position: absolute;
            left: 46%;
            opacity: 1;
            margin: 0 auto;
            bottom: 0px;
            border: 10px solid transparent;
            border-bottom-color: #16A085;
        }

        .wizard .nav-tabs > li a {
            width: 70px;
            height: 70px;
            margin: 20px auto;
            border-radius: 100%;
            padding: 0;
        }

            .wizard .nav-tabs > li a:hover {
                background: transparent;
            }

        .wizard .tab-pane {
            position: relative;
            padding-top: 50px;
        }

        .wizard h3 {
            margin-top: 0;
        }

        @media( max-width : 585px ) {

            .wizard {
                width: 90%;
                height: auto !important;
            }

            span.round-tab {
                font-size: 16px;
                width: 50px;
                height: 50px;
                line-height: 50px;
            }

            .wizard .nav-tabs > li a {
                width: 50px;
                height: 50px;
                line-height: 50px;
            }

            .wizard li.active:after {
                content: " ";
                position: absolute;
                left: 35%;
            }
        }
    </style>
    <div class="main-container">
        <div class="container">
            <div class="row">
                <section>
                    <div class="wizard">
                        <div class="wizard-inner">
                            <div class="connecting-line"></div>
                            <ul class="nav nav-tabs" role="tablist">

                                <li role="presentation" class="disabled">
                                    <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="Adım 1">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-folder-open"></i>
                                        </span>
                                    </a>
                                </li>

                                <li role="presentation" class="disabled">
                                    <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="Adım 2">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-pencil"></i>
                                        </span>
                                    </a>
                                </li>
                                <li role="presentation" class="active">
                                    <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Adım 3">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-scale"></i>
                                        </span>
                                    </a>
                                </li>

                                <li role="presentation" class="disabled">
                                    <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Tamamlandı">
                                        <span class="round-tab">
                                            <i class="glyphicon glyphicon-ok"></i>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <div role="form">
                            <div class="tab-content">
                                <div class="tab-pane" role="tabpanel" id="step1">
                                </div>
                                <div class="tab-pane" role="tabpanel" id="step2">
                                </div>
                                <div class="tab-pane active" role="tabpanel" id="step3">
                                    <div class="main-container">
                                        <div class="container">
                                            <div class="row">
                                                <!-- panel preview -->
                                                <div class="col-sm-5 col-md-5">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title">Kredi Kartı ile Öde
                                                            </h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <div role="form">
                                                                <div class="form-group">
                                                                    <label for="cardNumber">
                                                                        Kart Üzerindeki Ad Soyad</label>
                                                                    <div class="input-group">
                                                                        <input type="text" class="form-control" id="cardName"
                                                                            required />
                                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="cardNumber">
                                                                        Kart Numarası</label>
                                                                    <div class="input-group">
                                                                        <input type="text" class="form-control" id="cardNumber"
                                                                            required autofocus />
                                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-xs-7 col-md-7">
                                                                        <div class="form-group">
                                                                            <label for="expityMonth">
                                                                                Son Kullanma Tarihi</label>
                                                                            <div class="col-xs-6 col-lg-6 pl-ziro">
                                                                                <input type="text" class="form-control" id="expityMonth" placeholder="AY" required />
                                                                            </div>
                                                                            <div class="col-xs-6 col-lg-6 pl-ziro">
                                                                                <input type="text" class="form-control" id="expityYear" placeholder="YIL" required />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-xs-5 col-md-5 pull-right">
                                                                        <div class="form-group">
                                                                            <label for="cvCode">
                                                                                CVC</label>
                                                                            <input type="password" class="form-control" id="cvCode" required />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <a href="#" class="btn btn-success btn-lg btn-block" role="button">Ödemeyi Tamamla</a>
                                                </div>
                                                <div class="col-sm-7">
                                                    <h4>Sipariş Özeti</h4>
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <div class="table-responsive">
                                                                <table class="table preview-table">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Concept</th>
                                                                            <th>Description</th>
                                                                            <th>Amount</th>
                                                                            <th>Status</th>
                                                                            <th>Date</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody></tbody>
                                                                    <!-- preview content goes here-->
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row text-right">
                                                        <div class="col-xs-12">
                                                            <h4>Total: <strong><span class="preview-total"></span></strong></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- / panel preview -->

                                        </div>
                                    </div>
                                </div>


                                <div class="tab-pane" role="tabpanel" id="complete">
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>


            <!-- You can make it whatever width you want. I'm making it full width
             on <= small devices and 4/12 page width on >= medium devices -->
        </div>
    </div>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>

    <script>
        function calc_total() {
            var sum = 0;
            $('.input-amount').each(function () {
                sum += parseFloat($(this).text());
            });
            $(".preview-total").text(sum);
        }
        $(document).on('click', '.input-remove-row', function () {
            var tr = $(this).closest('tr');
            tr.fadeOut(200, function () {
                tr.remove();
                calc_total()
            });
        });

        $(function () {
            $('.preview-add-button').click(function () {
                var form_data = {};
                form_data["concept"] = $('.payment-form input[name="concept"]').val();
                form_data["description"] = $('.payment-form input[name="description"]').val();
                form_data["amount"] = parseFloat($('.payment-form input[name="amount"]').val()).toFixed(2);
                form_data["status"] = $('.payment-form #status option:selected').text();
                form_data["date"] = $('.payment-form input[name="date"]').val();
                form_data["remove-row"] = '<span class="glyphicon glyphicon-remove"></span>';
                var row = $('<tr></tr>');
                $.each(form_data, function (type, value) {
                    $('<td class="input-' + type + '"></td>').html(value).appendTo(row);
                });
                $('.preview-table > tbody:last').append(row);
                calc_total();
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            //Initialize tooltips
            $('.nav-tabs > li a[title]').tooltip();

            //Wizard
            $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

                var $target = $(e.target);

                if ($target.parent().hasClass('disabled')) {
                    return false;
                }
            });

            $(".next-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                $active.next().removeClass('disabled');
                nextTab($active);

            });
            $(".prev-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                prevTab($active);

            });
        });

        function nextTab(elem) {
            $(elem).next().find('a[data-toggle="tab"]').click();
        }
        function prevTab(elem) {
            $(elem).prev().find('a[data-toggle="tab"]').click();
        }
    </script>
</asp:Content>
