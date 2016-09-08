<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mesaj-oku.ascx.cs" Inherits="PL.profil.mesaj_oku" %>
<!-- Direct Chat -->
<link rel="stylesheet" href="../management/dist/css/AdminLTE.min.css" />
<style>
    .testimonial {
        margin-bottom: 10px;
    }

    .testimonial-section {
        width: 100%;
        height: auto;
        padding: 15px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
        position: relative;
        border: 1px solid #fff;
    }

        .testimonial-section:after {
            top: 100%;
            left: 50px;
            border: solid transparent;
            content: " ";
            position: absolute;
            border-top-color: #fff;
            border-width: 15px;
            margin-left: -15px;
        }

    .testimonial-desc {
        margin-top: 20px;
        text-align: left;
        padding-left: 15px;
    }

        .testimonial-desc img {
            border: 1px solid #f5f5f5;
            border-radius: 150px;
            height: 70px;
            padding: 3px;
            width: 70px;
            display: inline-block;
            vertical-align: top;
        }

    .testimonial-writer {
        display: inline-block;
        vertical-align: top;
        padding-left: 10px;
    }

    .testimonial-writer-name {
        font-weight: bold;
    }

    .testimonial-writer-designation {
        font-size: 85%;
    }

    .testimonial-writer-company {
        font-size: 85%;
    }
    /*---- Outlined Styles ----*/
    .testimonial.testimonial-default {
    }

        .testimonial.testimonial-default .testimonial-section {
            border-color: #777;
        }

            .testimonial.testimonial-default .testimonial-section:after {
                border-top-color: #777;
            }

        .testimonial.testimonial-default .testimonial-desc {
        }

            .testimonial.testimonial-default .testimonial-desc img {
                border-color: #777;
            }

        .testimonial.testimonial-default .testimonial-writer-name {
            color: #777;
        }

    .testimonial.testimonial-primary {
    }

        .testimonial.testimonial-primary .testimonial-section {
            border-color: #337AB7;
            color: #286090;
            background-color: rgba(51, 122, 183, 0.1);
        }

            .testimonial.testimonial-primary .testimonial-section:after {
                border-top-color: #337AB7;
            }

        .testimonial.testimonial-primary .testimonial-desc {
        }

            .testimonial.testimonial-primary .testimonial-desc img {
                border-color: #337AB7;
            }

        .testimonial.testimonial-primary .testimonial-writer-name {
            color: #337AB7;
        }

    .testimonial.testimonial-info {
    }

        .testimonial.testimonial-info .testimonial-section {
            border-color: #5BC0DE;
            color: #31b0d5;
            background-color: rgba(91, 192, 222, 0.1);
        }

            .testimonial.testimonial-info .testimonial-section:after {
                border-top-color: #5BC0DE;
            }

        .testimonial.testimonial-info .testimonial-desc {
        }

            .testimonial.testimonial-info .testimonial-desc img {
                border-color: #5BC0DE;
            }

        .testimonial.testimonial-info .testimonial-writer-name {
            color: #5BC0DE;
        }


    .testimonial.testimonial-success {
    }

        .testimonial.testimonial-success .testimonial-section {
            border-color: #5CB85C;
            color: #449d44;
            background-color: rgba(92, 184, 92, 0.1);
        }

            .testimonial.testimonial-success .testimonial-section:after {
                border-top-color: #5CB85C;
            }

        .testimonial.testimonial-success .testimonial-desc {
        }

            .testimonial.testimonial-success .testimonial-desc img {
                border-color: #5CB85C;
            }

        .testimonial.testimonial-success .testimonial-writer-name {
            color: #5CB85C;
        }

    .testimonial.testimonial-warning {
    }

        .testimonial.testimonial-warning .testimonial-section {
            border-color: #F0AD4E;
            color: #d58512;
            background-color: rgba(240, 173, 78, 0.1);
        }

            .testimonial.testimonial-warning .testimonial-section:after {
                border-top-color: #F0AD4E;
            }

        .testimonial.testimonial-warning .testimonial-desc {
        }

            .testimonial.testimonial-warning .testimonial-desc img {
                border-color: #F0AD4E;
            }

        .testimonial.testimonial-warning .testimonial-writer-name {
            color: #F0AD4E;
        }

    .testimonial.testimonial-danger {
    }

        .testimonial.testimonial-danger .testimonial-section {
            border-color: #D9534F;
            color: #c9302c;
            background-color: rgba(217, 83, 79, 0.1);
        }

            .testimonial.testimonial-danger .testimonial-section:after {
                border-top-color: #D9534F;
            }

        .testimonial.testimonial-danger .testimonial-desc {
        }

            .testimonial.testimonial-danger .testimonial-desc img {
                border-color: #D9534F;
            }

        .testimonial.testimonial-danger .testimonial-writer-name {
            color: #D9534F;
        }

    /*---- Filled Styles ----*/
    .testimonial.testimonial-default-filled {
    }

        .testimonial.testimonial-default-filled .testimonial-section {
            color: #fff;
            border-color: #777;
            background-color: #777;
        }

            .testimonial.testimonial-default-filled .testimonial-section:after {
                border-top-color: #777;
            }

        .testimonial.testimonial-default-filled .testimonial-desc {
        }

            .testimonial.testimonial-default-filled .testimonial-desc img {
                border-color: #777;
                background-color: #777;
            }

        .testimonial.testimonial-default-filled .testimonial-writer-name {
            color: #777;
        }

    .testimonial.testimonial-primary-filled {
    }

        .testimonial.testimonial-primary-filled .testimonial-section {
            color: #fff;
            background-color: #337ab7;
            border-color: #2e6da4;
        }

            .testimonial.testimonial-primary-filled .testimonial-section:after {
                border-top-color: #337AB7;
            }

        .testimonial.testimonial-primary-filled .testimonial-desc {
        }

            .testimonial.testimonial-primary-filled .testimonial-desc img {
                border-color: #2e6da4;
                background-color: #337ab7;
            }

        .testimonial.testimonial-primary-filled .testimonial-writer-name {
            color: #337AB7;
        }

    .testimonial.testimonial-info-filled {
    }

        .testimonial.testimonial-info-filled .testimonial-section {
            color: #fff;
            background-color: #5bc0de;
            border-color: #46b8da;
        }

            .testimonial.testimonial-info-filled .testimonial-section:after {
                border-top-color: #5BC0DE;
            }

        .testimonial.testimonial-info-filled .testimonial-desc {
        }

            .testimonial.testimonial-info-filled .testimonial-desc img {
                border-color: #46b8da;
                background-color: #5bc0de;
            }

        .testimonial.testimonial-info-filled .testimonial-writer-name {
            color: #5BC0DE;
        }


    .testimonial.testimonial-success-filled {
    }

        .testimonial.testimonial-success-filled .testimonial-section {
            color: #fff;
            background-color: #5cb85c;
            border-color: #4cae4c;
        }

            .testimonial.testimonial-success-filled .testimonial-section:after {
                border-top-color: #5CB85C;
            }

        .testimonial.testimonial-success-filled .testimonial-desc {
        }

            .testimonial.testimonial-success-filled .testimonial-desc img {
                border-color: #4cae4c;
                background-color: #5cb85c;
            }

        .testimonial.testimonial-success-filled .testimonial-writer-name {
            color: #5CB85C;
        }

    .testimonial.testimonial-warning-filled {
    }

        .testimonial.testimonial-warning-filled .testimonial-section {
            color: #fff;
            background-color: #f0ad4e;
            border-color: #eea236;
        }

            .testimonial.testimonial-warning-filled .testimonial-section:after {
                border-top-color: #F0AD4E;
            }

        .testimonial.testimonial-warning-filled .testimonial-desc {
        }

            .testimonial.testimonial-warning-filled .testimonial-desc img {
                border-color: #eea236;
                background-color: #f0ad4e;
            }

        .testimonial.testimonial-warning-filled .testimonial-writer-name {
            color: #F0AD4E;
        }

    .testimonial.testimonial-danger-filled {
    }

        .testimonial.testimonial-danger-filled .testimonial-section {
            color: #fff;
            background-color: #d9534f;
            border-color: #d43f3a;
        }

            .testimonial.testimonial-danger-filled .testimonial-section:after {
                border-top-color: #D9534F;
            }

        .testimonial.testimonial-danger-filled .testimonial-desc {
        }

            .testimonial.testimonial-danger-filled .testimonial-desc img {
                border-color: #d43f3a;
                background-color: #D9534F;
            }

        .testimonial.testimonial-danger-filled .testimonial-writer-name {
            color: #D9534F;
        }
</style>
<div class="col-sm-9 page-content">
    <div class="inner-box">


        <div class="welcome-msg">
            <br />
            <div class="item-list">
                <div class="col-sm-2 no-padding photobox">
                    <div class="add-image">
                        <span class="photo-count"><i
                            class="fa fa-hashtag" runat="server" id="txtid"></i></span><a href="ads-details.html">
                                <img
                                    class="thumbnail no-margin" src='../upload/ilan/<%= picPath %>'
                                    alt="img"></a>
                    </div>
                </div>
                <!--/.photobox-->
                <div class="col-sm-5 add-desc-box">
                    <div class="add-details">
                        <h5 class="add-title">
                            <asp:HyperLink ID="hypBaslik" runat="server" NavigateUrl='<%# Eval("ilanId","~/ilan-detay.aspx?ilan={0}") %>'></asp:HyperLink>
                        </h5>
                        <span class="info-row"><span class="add-type business-ads tooltipHere"
                            data-toggle="tooltip"
                            data-placement="right"
                            title="Business Ads">B </span><span
                                class="date" runat="server" id="txttarih"><i class=" icon-clock"></i></span>- <span
                                    class="category" runat="server" id="txtkategori"></span>- <span
                                        class="item-location" runat="server" id="txtIl"><i class="fa fa-map-marker"></i></span></span>
                    </div>
                </div>
                <!--/.add-desc-box-->
                <div class="col-sm-5 text-right  price-box">
                    <h2 class="item-price">
                        <asp:Label ID="lblFiyatTur" runat="server"></asp:Label> 
                        <asp:Label ID="lblFiyat" runat="server"></asp:Label>
                    </h2>
                </div>
                <!--/.add-desc-box-->
            </div>
        </div>
        <div class="section-block">
            <div class="well">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Repeater ID="mesajRepeater" runat="server">
                            <ItemTemplate>
                                <div id="tb-testimonial" class="testimonial testimonial-danger">
                                    <div class="testimonial-section">
                                        <%# Eval("mesaj") %>
                                    </div>
                                    <div class="testimonial-desc">
                                        <img onerror="this.src='../upload/system_resim/user.jpg'" src='../upload/profil/<%# Eval("profilResim") %>' alt="" />
                                        <div class="testimonial-writer">
                                            <div class="testimonial-writer-name"><%# Eval("kullaniciAdSoyad") %></div>
                                            <div class="testimonial-writer-designation"><%# Eval("tarih","{0:dd MMMM yyyy}") %></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div action="#" method="post">
                        <div class="input-group">
                            <div class="col-md-2">
                                <label>Mesajınız</label></div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtMesaj" type="text" name="message" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <%--                            <input type="text" name="message" class="form-control">--%>
                            <br />
                            <span class="input-group-btn">
                                <asp:Button ID="Gonder" CssClass="btn btn-danger" runat="server" OnClick="Gonder_Click" Text="Gönder" />
                            </span>
                        </div>
                    </div>

                </div>
            </div>

            <!--/.direct-chat -->
        </div>
    </div>
</div>
