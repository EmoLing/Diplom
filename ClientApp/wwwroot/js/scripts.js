
ymaps.ready(init);
function init() {
    if (navigator.geolocation) {
        getLocation();
    } else {
        document.getElementById("map").innerHTML = "Geolocation API не поддерживается в вашем браузере";
    }
}

function getLocation() {
    navigator.geolocation.getCurrentPosition(function (position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        var map = new ymaps.Map("map", {
            center: [latitude, longitude],
            zoom: 13
        });
        map.controls
            .add('zoomControl')
            .add('typeSelector')
            .add('mapTools');
        var place = new ymaps.Placemark(
            [latitude, longitude],
            { iconContent: "Вы здесь!" },
            { preset: "twirl#redStretchyIcon" }
        );
        map.geoObjects.add(place);
    });
}
