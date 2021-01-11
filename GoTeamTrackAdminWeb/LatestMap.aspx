<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCand.master" AutoEventWireup="true" CodeFile="LatestMap.aspx.cs" Inherits="LatestMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dvMap {
            width: 100%;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <h3>Current Location
                    </h3>
                </div>
                <div class="portlet-body">
                    <asp:TextBox ID="txtJson1" CssClass="txtJson1" Style="display: none;" runat="server"></asp:TextBox>
                    <asp:PlaceHolder ID="PlaceHolderMap" Visible="true" runat="server">
                        <div id="dvMap" class="dvMap">
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBfYmy4TVKk4eqPCqgC-VA110aIrfwbMjY"></script>

    <script type="text/javascript">
        var geocoder;
        var map;
        var marker;
        //alert(1);
        function initialize() {
            //alert(2);
            var latlng = new google.maps.LatLng(22.32, 73.03);
            var myOptions = { zoom: 12, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP };
            map = new google.maps.Map(document.getElementById("dvMap"), myOptions);
            //alert(3);
            var rendererOptions = { map: map };
            directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);

            var str = $(".txtJson1").val();
            //alert(str);
            var locations = JSON.parse(str);
            //alert(locations);
            //alert(locations.length);
            var path = [];
            var i = 0;

            var image = 'images/mappoint1.png';
            var polyline = new google.maps.Polyline({
                // set desired options for color, opacity, width, etc.
                strokeColor: "#0000FF",
                strokeOpacity: 0.4,
                strokeWeight: 4
            });

            for (i = 0; i < locations.length; i++) {
                //alert(locations[i].Latitude);
                //alert(" "+locations[i].Longitude);
                var point1 = new google.maps.LatLng(locations[i].Latitude, locations[i].Longitude);
                path.push(point1);
                var marker = new google.maps.Marker({
                    position: point1,
                    map: map,
                    title: locations[i].GPSTime,
                    icon: image
                });
            }
            if (path.length >= 2) {
                // display the polyline once it has more than one point
                //polyline.setMap(map);
                //polyline.setPath(path);
            }
            //alert("Map loaded-1");
        }
        google.maps.event.addDomListener(window, "load", initialize);
        //alert("Map loaded-2");
    </script>

</asp:Content>

