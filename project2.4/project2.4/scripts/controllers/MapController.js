angular.module('mapApp')
    .controller('MapController', function ($scope) {

    var mapOptions = {
        zoom: 12,
        center: new google.maps.LatLng(53.219383, 6.566502),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.markers = [];

    var infoWindow = new google.maps.InfoWindow();

    var createMarker = function (info) {

        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(info.lat, info.long),
            title: info.place
        });
        marker.content = '<div class="infoWindowContent">' + info.desc + '<br />' + info.lat + ' E,' + info.long + ' N, </div>';

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.setContent('<h2>' + marker.title + '</h2>' +
                marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);

    }

    for (i = 0; i < cities.length; i++) {
        createMarker(cities[i]);
    }

    $scope.openInfoWindow = function (e, selectedMarker) {
        e.preventDefault();
        google.maps.event.trigger(selectedMarker, 'click');
    }

});