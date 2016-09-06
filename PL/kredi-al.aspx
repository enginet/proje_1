<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="kredi-al.aspx.cs" Inherits="PL.kredi_al" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/select2/select2.min.css") %>'>
    <%--    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/dropzone/dropzone.css") %>' />--%>
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>' />
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>' />
    <div class="main-container">
        <div class="container">
            <div class="row">
                <div class="col-md-9" style="background: #fff">
                    <table id="example1" class="table table-responsive table-hover" style="padding-bottom:30px;">
                        <thead>
                            <tr>
                                <th class="col-md-3" style="font-size: 16px;">Kredi Miktarı (Adet)</th>
                                <th class="col-md-3" style="font-size: 16px;">Birim Fiyat (TL)</th>
                                <th class="col-md-3" style="font-size: 16px;">Kazanç (%)</th>
                                <th class="col-md-3" style="font-size: 16px;">Toplam (TL)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">2</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">2.5</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">-</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">5</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">10</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">2.5</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">-</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">25</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">25</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">2.0</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">20</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">50</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">50</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1.6</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">36</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">80</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">100</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1.4</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">44</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">140</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">250</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1.3</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">48</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">325</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">500</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1.2</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">52</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">600</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 16px;">1000</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">60</span>
                                </td>
                                <td>
                                    <span style="font-size: 16px;">1000</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="form-group col-xs-4" style="padding:0">
                            <label>Kredi</label>
                            <asp:DropDownList CssClass="form-control select2" Style="width: 100%;" ID="drpKredi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpKredi_SelectedIndexChanged">
                                <asp:ListItem Value="">Seçiniz</asp:ListItem>
                                <asp:ListItem Value="1">2 Kredi</asp:ListItem>
                                <asp:ListItem Value="2">10 Kredi</asp:ListItem>
                                <asp:ListItem Value="3">25 Kredi</asp:ListItem>
                                <asp:ListItem Value="4">50 Kredi</asp:ListItem>
                                <asp:ListItem Value="5">100 Kredi</asp:ListItem>
                                <asp:ListItem Value="6">250 Kredi</asp:ListItem>
                                <asp:ListItem Value="7">500 Kredi</asp:ListItem>
                                <asp:ListItem Value="8">1000 Kredi</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="clearfix"></div>
                        <asp:Label ID="lblTutar" runat="server" Text="Toplam : " style="font-size:16px;"><asp:Label ID="tutar" runat="server" Text="" style="font-weight:bold;"></asp:Label></asp:Label>
                        <div class="clearfix"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Devam Et" style="float:right; margin-bottom:15px;" OnClick="Button1_Click"/>
                </div>

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

    <script type='text/javascript'>

        $(document).ready(function () {
            document.getElementById("ContentPlaceHolder1_FileUpload1").style.display = "none";
        });
        function triggerFileUpload() {
            document.getElementById("ContentPlaceHolder1_FileUpload1").click();
        }

        var files;
        function preview(input) {
            if (input.files && input.files[0]) {
                $(".resimler").remove();
                var filelist = input.files || [];

                if (filelist.length <= 10) {
                    for (var i = 0; i < filelist.length; i++) {
                        var filedr = new FileReader();
                        filedr.onload = function (e) {
                            var element = "<div class='col-xs-6 col-sm-3 resimler'>" +
                                              "<a class='thumbnail'><img class='deneme' src='" + e.target.result + "'/></a>" +
                                              "<div class='clearfix'></div>" +
                                          "</div>";
                            $("#previews").append(element);
                        }
                        filedr.readAsDataURL(input.files[i]);
                    }
                    files = document.getElementById("ContentPlaceHolder1_ctl00_FileUpload1").files;
                }
                else {
                    alert("Maksimum 10 resim seçebilirsiniz");
                }

            }
        }
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


    <!-- include carousel slider plugin  -->
    <script src="libraries/assets/js/owl.carousel.min.js"></script>
    <%--    <script src="management/plugins/dropzone/dropzone.js"></script>--%>
    <script type='text/javascript'>

        Dropzone.options.myDropzone = {

            // Prevents Dropzone from uploading dropped files immediately
            autoProcessQueue: false,

            init: function () {
                var submitButton = document.querySelector("#submit-all")
                myDropzone = this; // closure

                submitButton.addEventListener("click", function () {
                    myDropzone.processQueue(); // Tell Dropzone to process all queued files.
                });

                // You might want to show the submit button only when 
                // files are dropped here:
                this.on("addedfile", function () {
                    // Show submit button here and/or inform user to click it.
                });

            }
        };
    </script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/management/plugins/select2/select2.full.min.js") %>'></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            //Initialize Select2 Elements
            $(".select2").select2();
        });
    </script>

    <script src="management/dist/js/app.min.js"></script>

</asp:Content>
