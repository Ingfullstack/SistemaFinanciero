let datatable;

$(document).ready(() => {
    datatable = $("#tblDatos").DataTable({
        "ajax": {
            "url": "/Admin/Clientes/ObtenerTodo"
        },
        "columns": [
            { data: "nombre" },
            { data: "apellido" },
            { data: "telefono" },
            { data: "email" },
            { data: "cedula" },
            {
                data: "id",
                "render": function (data) {
                    return `<div>
                                <a href="/Admin/Clientes/Editar/${data}" class=" btn btn-success btn-sm"> <i class="bi bi-pencil-square"></i> </a>
                                <a onclick=Eliminar("/Admin/Clientes/Eliminar/${data}") class=" btn btn-danger btn-sm"> <i class="bi bi-trash"></i> </a>
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
