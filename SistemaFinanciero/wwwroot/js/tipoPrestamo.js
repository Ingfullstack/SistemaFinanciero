let datatable;

$(document).ready(() => {
    datatable = $("#tblDatos").DataTable({
        "ajax": {
            "url": "/Admin/TipoPrestamos/ObtenerTodo"
        },
        "columns": [
            { data: "nombre" },
            { data: "tasaInteresAnual" },
            { data: "plazoMaximoMeses" },
            { data: "montoMaximo" },
            { data: "porcentajeRefinanciamiento" },
            {
                data: "id",
                "render": function (data) {
                    return `<div>
                                <a href="/Admin/TipoPrestamos/Editar/${data}" class=" btn btn-success btn-sm"> <i class="bi bi-pencil-square"></i> </a>
                                <a onclick=Eliminar("/Admin/TipoPrestamos/Eliminar/${data}") class=" btn btn-danger btn-sm"> <i class="bi bi-trash"></i> </a>
                            </div>`
                }
            },
        ]
    })
});

const Eliminar = (url) => {
    Swal.fire({
        title: "Estas seguro?",
        text: "No podrás revertir esto!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#2dc653",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si Eliminar!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
