<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="harita.aspx.cs" Inherits="PL.harita.harita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/select2/select2.min.css") %>'>
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/plugins/iCheck/square/blue.css") %>'>
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/management/dist/css/AdminLTE.min.css") %>'>
    <link href="../libraries/assets/css/owl.carousel.css" rel="stylesheet" />
    <link href="../libraries/assets/css/owl.theme.css" rel="stylesheet" />


    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAS1wH5TdTQ8gbD5zB6Ghi2hN4BpkkbJ5M&callback=initMap" async defer></script>
    <script runat="server">

    </script>
    <script type="text/javascript">
        var map;
        var infoWindow;
        var sekil;

        var ilanlar = Array();

        $(document).ready(function () {
            $("#footer").css("display","none");
            $("#map").css("height",$( window ).height()-280);
            $(".filtreIcerik").css("height",$( window ).height()-280);

            var top=($(".filtreIcerik").height()-$("#gizleGoster").height())/2;
            $("#gizleGoster").css("top",top);
        });

        var index = 0;

        var overlays=[];

        function initMap(ilan) {
            
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 6,
                center: { lat: 39, lng: 36 },
                mapTypeId: google.maps.MapTypeId.ROAD
            });


            //var layer = new google.maps.FusionTablesLayer({
            //    query: {
            //        select: '',
            //        from: '420419',
            //        where: 'name_0=\'Turkey\''
            //    },
            //    styles: [{
            //        polygonOptions: {
            //            fillColor: "#00FF00",
            //            fillOpacity: 0.1,
            //            strokeColor: "#000000",
            //            strokeWeight: 0.5
            //        }
            //    }]
            //});

            //layer.setMap(map);
            
            var kontrol = true;

            if(ilan.length!=0)
            {
                map.setZoom(8);
                map.setCenter({ lat:ilan[ilan.length-1]["lat"], lng: ilan[ilan.length-1]["lng"]});
            }
            if(ilan.length!=0)
            {
                for (var i = 0; i < ilan.length; i++) {
                    if (ilan[i]["koordinat"] != "-1")
                    {
                        //if (ilanlar.length != 0) {
                        //    for (var j = 0; j < ilanlar.length; j++) {
                        //        if (ilanlar[j]["ilanId"] == ilan[i]["ilanId"]) {
                        //            kontrol = false;
                        //        }
                        //    }
                        //}

                        if (kontrol == true && ilan != null) {
                            var koordinatlar = [];

                            var renk = "";
                            var kimden = "";
                            var kimdenSayi = 0;
                            var ilanTur = "";

                            if (ilan[i]["ilanTurId"] == 1) {
                                ilanTur = "Satılık";
                            }
                            if (ilan[i]["ilanTurId"] == 2) {
                                ilanTur = "Kiralık";
                            }
                            if (ilan[i]["ilanTurId"] == 3) {
                                ilanTur = "Günlük Kiralık";
                            }
                            if (ilan[i]["ilanTurId"] == 4) {
                                ilanTur = "Devren";
                            }
                            if (ilan[i]["ilanTurId"] == 5) {
                                ilanTur = "Devren Kiralık";
                            }
                            if (ilan[i]["ilanTurId"] == 6) {
                                ilanTur = "Devren Satılık Konut";
                            }

                        
                            if(ilan[i]["magazaId"]!="-1")
                            {   
                                //emlakçıdan
                                if (ilan[i]["kimden"] == 2) {
                                    renk = '#2a0cae';
                                    kimden = "Emlakçıdan";
                                    kimdenSayi = 2;
                                }

                                //belediyeden
                                if (ilan[i]["kimden"] == 3) {
                                    renk = '#6a12bc';
                                    kimden = "Belediyeden";
                                    kimdenSayi = 3;
                                }

                                //bankadan
                                if (ilan[i]["kimden"] == 4) {
                                    renk = '#fffc00';
                                    kimden = "Bankadan";
                                    kimdenSayi = 4;
                                }

                                //izaley-i şuyudan
                                if (ilan[i]["kimden"] == 5) {
                                    renk = '#a0fcff';
                                    kimden = "İzaley-i Şuyudan";
                                    kimdenSayi = 5;
                                }

                                //icradan
                                if (ilan[i]["kimden"] == 6) {
                                    renk = '#ffb400';
                                    kimden = "İcradan";
                                    kimdenSayi = 6;
                                }

                                //milli hazineden (sayışı devam eden)
                                if (ilan[i]["kimden"] == 7) {
                                    renk = '#9d9d9d';
                                    kimden = "Milli Hazine (Satışı devam eden)";
                                    kimdenSayi = 7;
                                }

                                //milli hazineden (satılamayan)
                                if (ilan[i]["kimden"] == 8) {
                                    renk = '#86ed00';
                                    kimden = "Milli Hazine (Satılamayan)";
                                    kimdenSayi = 8;
                                }

                                //özelleştirme idaresinden
                                if (ilan[i]["kimden"] == 9) {
                                    renk = '#8b8b8b';
                                    kimden = "Özelleştirme İdaresinden";
                                    kimdenSayi = 9;
                                }

                                //inşaat firmasından
                                if (ilan[i]["kimden"] == 10) {
                                    renk = '#fa5fd7';
                                    kimden = "İnşaat Firmasından";
                                    kimdenSayi = 110;
                                }

                                //diğer kamu kurumlarından
                                if (ilan[i]["kimden"] == 11) {
                                    renk = '#e3fffe';
                                    kimden = "Diğer Kamu Kurumlarından";
                                    kimdenSayi = 11;
                                }
                            }
                            else
                            {
                                renk = '#ff0000';
                                kimden = "Sahibinden";
                                kimdenSayi = 1;
                            }

                            for (var j = 0; j < ilan[i]["koordinat"]["coordinates"][0][0].length; j++) {
                                koordinatlar.push({ lat: ilan[i]["koordinat"]["coordinates"][0][0][j][1], lng: ilan[i]["koordinat"]["coordinates"][0][0][j][0]});
                            }


                            sekil = new google.maps.Polygon({
                                paths: koordinatlar,
                                strokeColor: renk,
                                strokeOpacity: 0.8,
                                strokeWeight: 3,
                                fillColor: renk,
                                fillOpacity: 0.35
                            });
                            sekil.setMap(map);

                            overlays.push(sekil);

                            var markerPosition={lat:koordinatlar[0]["lat"],lng:koordinatlar[0]["lng"]}
                            var marker = new google.maps.Marker({
                                position: markerPosition,
                                map: map,
                                title: ilan[i]["baslik"]
                            });

                            var contentString = '<div classs="col-xs-2" style="padding-right:0;">' +
                                                        '<h1>' + ilan[i]["baslik"] + '</h1><br />' +
                                                        '<div class="col-xs-4 center-block" style="padding:0;"><div class="thumbnail" style="height:150px;"><img src="../upload/ilan/' + ilan[i]["resim"] + '" alt="arsa"/></div></div>' +
                                                        '<div class="col-xs-8" style="padding-right:0;">' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>İlan No </label></div><div class="col-xs-9"><span style="color:#b02929; font-weight:bold;">' + ilan[i]["ilanId"] + '</span></div><div class="clearfix"></div></div>' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>İlan Tarihi </label></div><div class="col-xs-9"><span>' + ilan[i]["baslangicTarihi"] + '</span></div><div class="clearfix"></div></div>' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>Metrekare  </label></div><div class="col-xs-9"><span>' + ilan[i]["metreKare"] + ' m<sup>2</sup></span></div><div class="clearfix"></div></div>' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>Kimden  </label></div><div class="col-xs-9"><span>' + kimden + '</span></div><div class="clearfix"></div></div>' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>İlan Türü  </label></div><div class="col-xs-9"><span>' + ilanTur + '</span></div><div class="clearfix"></div></div>' +
                                                            '<div style="border-bottom:1px solid #dadada;"><div class="col-xs-3" style="padding: 0;"><label>Fiyatı  </label></div><div class="col-xs-9"><span style="color:#b02929; font-weight:bold;">' + ilan[i]["fiyat"] + ' TL</span></div><div class="clearfix"></div></div>' +
                                                        '</div><div class="clearfix"></div>' +
                                                    '<div class="col-xs-12" style="padding:0">'+
                                                    '<a onclick="krediKontrol('+kimdenSayi+','+ilan[i]["ilanId"]+')" style="float:right;" class="btn btn-success btn-md">Detay Gör</a></div></div>';
                       
                            var infowindow = new google.maps.InfoWindow({
                                content: ""
                            });
                            bagla(sekil, infowindow, contentString);

                            index++;
                        }

                        if (ilan[i]["acilMi"] == "True") {
                            map.setZoom(17);
                            map.setCenter({ lat: ilan[i]["koordinat"][0][1], lng: ilan[i]["koordinat"][0][0] });
                            infowindow.setContent(contentString);
                            infowindow.setPosition({ lat: ilan[i]["koordinat"][0][1], lng: ilan[i]["koordinat"][0][0] });
                            infowindow.open(map);
                        }
                    }
                    //else {
                    //    alert("yok ki be kardeş");
                    //}
                }
            }
            else
            {
                map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 6,
                    center: { lat: 39, lng: 36 },
                    mapTypeId: google.maps.MapTypeId.ROAD
                });
                uyariVer();
            }
        }


        function bagla(sekil, infowindow, icerik) {
            sekil.addListener('click', function (event) {
                infowindow.setContent(icerik);
                infowindow.setPosition(event.latLng);
                infowindow.open(map);
            });
        }

        function krediKontrol(kimden,id) {
            if (kimden == 3 || kimden == 4 || kimden == 5 || kimden == 6 || kimden == 7 || kimden == 8 || kimden == 9 || kimden == 11)
            {
                var kredi = <%= krediGuncelle()%>;
                if(kredi==-1)
                {
                    alert("Bu ilanı görebilmek için lütfen giriş yapın !");
                }
                else if (kredi >0) {
                    var ask = window.confirm("Krediniz 1 (Bir) azalacaktır. Devam etmek istiyor musunuz?");
                    if (ask) {

                        document.location.href = "../ilan-detay.aspx?ilan="+id;
                    }
                }
                else {
                    alert("Bu ilanın detaylarını görebilmek için yeterli krediniz bulunmamaktadır. Lütfen kredi yükleyiniz.");
                }
            }
            else
            {
                document.location.href = "../ilan-detay.aspx?ilan="+id;
            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            var kontrol = 0;
            $("#gizleGoster").click(function () {
                if (kontrol == 0) {
                    var boyut = "-" + $("#filtre").width();
                    $("#filtre").animate({ left: boyut });
                    kontrol = 1;
                }
                else {
                    $("#filtre").animate({ left: 0 });
                    kontrol = 0;
                }
            });
        });
    </script>


    <style>
        #map {
            width: 100%;
        }

        .haritaCevresi {
            width: 100%;
            height: 100px;
            background: black;
        }

        #harita_reklam {
            background-color: #f9f9f9;
            border-bottom: 1px solid #000;
        }

        #filtre {
            position: absolute;
            left: 0;
            top: 180px;
            background-color: #f4f4f4;
            padding: 0;
            border-right: 1px solid #343434;
        }

        .filtreIcerik {
            height: 550px;
            overflow: hidden;
            overflow-y: scroll;
            padding: 0;
        }

        #gizleGoster {
            position: absolute;
            right: -25px;
            width: 25px;
            display: block;
            color: #fff;
            padding: 13px 0;
            font-size: 20px;
            line-height: 24px;
            text-align: center;
            cursor: pointer;
        }

        .iradio_square-blue {
            margin-left: 10px;
        }

        #ContentPlaceHolder1_RadioButtonList1 label {
            margin-left: 10px !important;
        }
    </style>



    <div class="haritaCevresi col-xs-12" id="reklamlar" style="padding: 0;">
        <div id="harita_reklam" class="owl-carousel owl-theme">
            <asp:Repeater runat="server" ID="reklamRepeater">
                <ItemTemplate>
                    <div class="acil-ilan">
                        <asp:HyperLink ID="HyperLink1" runat="server" href='<%# Eval("reklamLink") %>' Target="_blank">
                            <div class="col-xs-12 acil-ilan-resim">
                                <img src='../upload/reklam/<%# Eval("reklamResim")%>' />
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="clearfix"></div>
    <div id="map"></div>
    <style>
        div.acil-ilan {
            float: left;
            height: 100px;
            max-height: 100px;
            overflow: hidden;
            text-align: left;
            border-left: 1px solid #343434;
            position: relative;
        }

        div#acililan {
            height: 100px;
            color: #343434;
            background-color: #f9f9f9;
            border-top: 1px solid #343434;
            border-bottom: 1px solid #343434;
        }

        .acilBilgi p {
            padding: 5px;
            height: 66px;
            overflow: hidden;
            font-size: 16px;
            line-height: 22px;
            font-weight: bold;
        }

        .acil-ilan-detay {
            position: absolute;
            display: none;
            left: 0;
            top: 0;
        }

            .acil-ilan-detay:hover {
                display: block;
            }


        .acil-ilan-resim {
            height: 100%;
            padding: 0;
        }

            .acil-ilan-resim img {
                height: 100%;
                width: 100%;
                margin: 0px auto;
            }

        .acil-ilan:hover span, .acil-ilan:hover h4 {
            opacity: 1.0;
        }

        .baslik {
            position: absolute;
            display: block;
            background-color: #343434;
            color: #fff;
            font-size: 14px;
            line-height: 18px;
            bottom: 0;
            width: 100%;
            opacity: 0.5;
            left: 0;
            padding: 5px;
        }

        .fiyat {
            color: #fff;
            font-weight: bold;
            position: absolute;
            left: 0;
            top: 10px;
            padding: 0 10px;
            background-color: #b91e1e;
            line-height: 20px;
            opacity: 0.5;
        }

        .metreKare {
            color: #fff;
            font-weight: bold;
            position: absolute;
            left: 0;
            top: 40px;
            padding: 0 10px;
            background-color: #1e69d0;
            line-height: 20px;
            opacity: 0.5;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#acililan").owlCarousel({

                autoPlay: 2000, //Set AutoPlay to 3 seconds
                items: 8,
                itemsDesktop: [1199, 3],
                itemsDesktopSmall: [979, 3],
                pagination: false

            });
            $("#harita_reklam").owlCarousel({

                autoPlay: 2000, //Set AutoPlay to 3 seconds
                items: 8,
                itemsDesktop: [1199, 3],
                itemsDesktopSmall: [979, 3],
                pagination: false

            });
        });
    </script>
    <div class="haritaCevresi col-xs-12" id="acilIlanlar" style="padding: 0;">
        <div id="acililan" class="owl-carousel owl-theme">
            <asp:Repeater runat="server" ID="acilRepeater">
                <ItemTemplate>
                    <div class="acil-ilan">
                        <a onclick='initMap(<%# jsonCevir(Eval("ilanId"),Eval("baslik"),Eval("fiyat"),Eval("resim"),(Eval("turId")), ozellikDondur(Eval("ilanId"),78),Eval("ilAdi"),Eval("ilceAdi"),Eval("mahalleAdi"),ozellikDondur(Eval("ilanId"),71),true,Eval("baslangicTarihi","{0:dd-MM-yyyy}"),Eval("ilanTurId"),Eval("magazaId")) %>)'>
                            <div class="col-xs-12 acil-ilan-resim">
                                <img src='../upload/ilan/<%# Eval("resim")%>' />
                            </div>
                            <h4 class="baslik"><%# Eval("baslik") %></h4>
                            <span class="fiyat"><%# Eval("fiyat") %> TL</span>
                            <span class="metreKare"><%# ozellikDondur(Eval("ilanId"),78) %> m<sup>2</sup></span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="filtre" class="col-xs-10 col-lg-2 col-md-2 col-sm-6">
        <span id="gizleGoster" class="bg-green fa fa-filter"></span>
        <div class="col-xs-12 filtreIcerik">
            <div class="icerik col-xs-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdateProgress ID="updateProgress" runat="server">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/upload/system_resim/ajax-loader.gif" AlternateText="Yükleniyor ..." ToolTip="Yükleniyor ..." Style="padding: 10px; position: fixed; top:45%; left:45%; width:125px; height:125px;"/>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="form-group" style="padding-top: 15px;">
                            <label>İl</label>
                            <asp:DropDownList ID="drpIl" CssClass="form-control select2 il" Style="width: 100%;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIl_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>İlçe</label>
                            <asp:DropDownList ID="drpIlce" CssClass="form-control select2" Style="width: 100%;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Mahalle</label>
                            <asp:DropDownList ID="drpMahalle" CssClass="form-control select2" Style="width: 100%;" runat="server">
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <label>Fiyat</label>
                <div class="clearfix"></div>
                <div class="form-group col-xs-6" style="padding-left: 0">
                    <asp:TextBox ID="txtMinFiyat" runat="server" CssClass="form-control" placeholder="min. fiyat"></asp:TextBox>
                </div>
                <div class="form-group col-xs-6" style="padding-right: 0">
                    <asp:TextBox ID="txtMaxFiyat" runat="server" CssClass="form-control" placeholder="max. fiyat"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Kimden</label>
                    <asp:DropDownList ID="drpKimden" CssClass="form-control input-sm select2" Style="width: 100%;" runat="server">
                        <asp:ListItem Value="">Seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Sahibinden</asp:ListItem>
                        <asp:ListItem Value="2">Emlakçıdan</asp:ListItem>
                        <asp:ListItem Value="3">Belediyeden</asp:ListItem>
                        <asp:ListItem Value="4">Bankadan</asp:ListItem>
                        <asp:ListItem Value="5">İzaley-i Şuyudan</asp:ListItem>
                        <asp:ListItem Value="6">İcradan</asp:ListItem>
                        <asp:ListItem Value="7">Milli Hazineden (Satışı Devam Eden)</asp:ListItem>
                        <asp:ListItem Value="8">Milli Hazineden (Satılamayan)</asp:ListItem>
                        <asp:ListItem Value="9">Özelleştirme İdaresinden</asp:ListItem>
                        <asp:ListItem Value="10">İnşaat Firmasından</asp:ListItem>
                        <asp:ListItem Value="11">Dİğer Kamu Kurumlarından</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="yurt" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
                </div>
                <div class="form-group" style="background-color: #fdfdfd; padding: 5px;">
                    <label>İlan Tarihi</label>
                    <div class="form-group">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Value="1">Son 1 Gün</asp:ListItem>
                            <asp:ListItem Value="3">Son 3 Gün</asp:ListItem>
                            <asp:ListItem Value="7">Son 1 Hafta</asp:ListItem>
                            <asp:ListItem Value="15">Son 15 Gün</asp:ListItem>
                            <asp:ListItem Value="30">Son 1 Ay</asp:ListItem>
                        </asp:RadioButtonList>

                    </div>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtAra" CssClass="form-control" runat="server" placeholder="İlan no veya aranacak kelime"></asp:TextBox>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Ara" CssClass="form-control btn btn-success" OnClick="Button1_Click" Style="font-size: 20px; line-height: 0; color: #fff;" />
                        </div>
                        <div id="myModal" class="modal fade in">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <a class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span></a>
                                    </div>
                                    <div class="modal-body">
                                        <p style="font-size: 16px;"><%= mesaj %></p>
                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dalog -->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <a class="clickMe" data-toggle="modal" data-target="#myModal" hidden="hidden"></a>
            </div>
        </div>
    </div>


    <script src='<%= Page.ResolveUrl("~/management/plugins/select2/select2.full.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/libraries/assets/js/owl.carousel.min.js") %>'></script>

    <script src='<%= Page.ResolveUrl("~/management/plugins/iCheck/icheck.min.js") %>'></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>--%>

    <script>
        function uyariVer() {
            $(".clickMe").click();
        }
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $(".select2").select2();
        });
    </script>


</asp:Content>
