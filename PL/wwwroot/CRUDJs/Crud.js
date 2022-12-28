

$(document).ready(function () {
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5118/api/Empleado/api/GetAll',
        success: function (result) {
            $("#tblEmpleado tbody").empty();
            $.each(result.objects, function (i, empleado) {
                var fila =
                    '<tr>'
                    //+ '<td> </td>'

                    + '<td class="text-center"> <a class="btn btn-warning"> <span><i class="bi bi-pencil-square"> </i></span></a></td>'
                    //+ '<td class="text-center"><a href="#" class="btn btn-warning"><i class="bi bi-trash3-fill"></i></a></td>'
                    //+ '<td class="text-center">'+'<a href="#" class="btn btn-warning">'+'<i class="bi bi-trash3-fill">'+'</i>'+'</a>'+'</td>'
                        + '<td class="text-center hidden" style="display :none;">' + empleado.idEmpleado + '</td>'
                            + '<td class="text-center">' + empleado.numeroNomina + '</td>'
                        + '<td class="text-center">' + empleado.nombreEmpleado + '</td>'
                        + '<td class="text-center">' + empleado.apellidoPaterno + '</td>'
                        + '<td class="text-center">' + empleado.apellidoMaterno + '</td>'
                        + '<td class="text-center" style="display :none;">' + empleado.estado.idEstado + '</td>'
                        + '<td class="text-center">' + empleado.estado.nombreEstado + '</td>'
                        + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar()"><span style="color:#FFFFFF"><i class="bi bi-trash"></i> </span></button></td>'
                    + '</tr>';
                $("#tblEmpleado tbody").append(fila);
            });
        },
        error: function (result) {
            alert('Error en la consulta');
        }
    });
};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    //IniciarEmpleado();

}