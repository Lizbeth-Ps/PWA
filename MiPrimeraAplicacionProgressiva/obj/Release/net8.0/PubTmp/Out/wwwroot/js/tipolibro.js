window.onload = function () {
	listarTipoLibro();
}

function listarTipoLibro() {

	pintar({
		url: "TipoLibro/listarTipoLibro",
		propiedades: ["nombre", "descripcion"],
		cabeceras: ["Tipo Libro", "Descripcion"],
		titlePopup: "Tipo Libro",
		rowClickRecuperar: true,
		propiedadId: "iidtipolibro"
	},
		{
			url: "TipoLibro/listarTipoLibro",
			formulario: [
				[
					{
						class: "col-md-6",
						label: "Nombre Tipo Libro",
						name: "nombretipolibrobusqueda",
						type: "text"
					}
				]
			]
		}, {
		type: "popup",
		urlguardar: "TipoLibro/guardarTipoLibro",
		urlrecuperar: "TipoLibro/recuperarTipoLibro",
		parametrorecuperar: "id",
		formulario: [
			[
				{
					class: "d-none",
					label: "Id Tipo Libro",
					name: "iidtipolibro",
					type: "text"
				},
				{
					class: "col-md-6",
					label: "Nombre Tipo Libro",
					name: "nombre",
					type: "text"
				},
				{
					class: "col-md-6",
					label: "Descripcion Tipo Libro",
					name: "descripcion",
					type: "textarea"
				},
				{
					class: "col-md-6",
					label: "Suba una Foto",
					name: "fotoEnviar",
					type: "file",
					preview: true,
					imgwidth: 100,
					imgheight: 100,
					namefoto: "base64"
				}
			]
		],
		callbackGuardar: function () {
			var frm = new FormData();
			var contenido = "Se guardo los cambios del tipo libro " + getN("nombre")
			frm.append("parametroPorContenido", "Registro Satisfactorio_" + contenido + "_/img/icon-512.png")
			fetchPost("Notificacion/enviarNotificaciones", "text", frm, () => { })
		}

	}
	)

}