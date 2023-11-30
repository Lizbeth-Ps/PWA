window.onload = function () {
	listarTipoLibro();
}

function listarTipoLibro() {

	pintar({
		url: "TipoLibro/listarTipoLibro",
		propiedades: ["nombre", "descripcion"],
		cabeceras: ["Tipo Libro", "Descripcion"],
		titlePopup: "Tipo Libro",
		rowClickRecuperar: true
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
				}
			]
		]

	}
	)

}