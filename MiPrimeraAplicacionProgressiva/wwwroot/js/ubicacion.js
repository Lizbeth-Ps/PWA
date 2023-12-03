window.onload = function () {
	navigator.geolocation.getCurrentPosition(getPost)
}



function getPost(position) {

	//alert("Latitud " + position.coords.latitude)
	//   alert("Longitud " + position.coords.longitude)
	verMapa("map", position.coords.longitude, position.coords.latitude)

}