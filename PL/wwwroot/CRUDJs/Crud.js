

$(document).ready(function () {
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5118/api/Empleado/GetAll',
        success: function (result) {
            $("#tblEmpleado tbody").empty();
            $.each(result.objects, function (i, empleado) {
                var fila =
                    '<tr>'
                    //+ '<td> </td>'

                    + '<td class="text-center"> <a href="#" class="btn btn-warning" onclick="GetById(' + empleado.idEmpleado + ')"> <span><i class="bi bi-pencil-square"> </i></span></a></td>'
                        + '<td class="text-center hidden" style="display :none;">' + empleado.idEmpleado + '</td>'
                            + '<td class="text-center">' + empleado.numeroNomina + '</td>'
                        + '<td class="text-center">' + empleado.nombreEmpleado + '</td>'
                        + '<td class="text-center">' + empleado.apellidoPaterno + '</td>'
                        + '<td class="text-center">' + empleado.apellidoMaterno + '</td>'
                        + '<td class="text-center" style="display :none;">' + empleado.estado.idEstado + '</td>'
                        + '<td class="text-center">' + empleado.estado.nombreEstado + '</td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.idEmpleado + ')"><span style="color:#FFFFFF"><i class="bi bi-trash"></i> </span></button></td>'
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
    LimpiarEmpleado();
}

function ModalCerrar() {
    var cerrar = $('#ModalUpdate').modal('hide');
    GetAll();
}


function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5118/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstado").append('<option disabled="disabled" value="' + 0 +'">'+'Seleccion un estado'+'</option>');
            $.each(result.objects, function (i, estado) {
                $("#ddlEstado").append('<option value="' + estado.idEstado + '" >'
                    + estado.estado1 + '</option>');
            });
        }
    });
}


function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5118/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#txtNombreEmpleado').val(result.object.nombreEmpleado);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
            $('#ddlEstado').val(result.object.estado.idEstado);


            $('#ModalUpdate').modal('show'); //Mostrar Modal
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}


function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5118/api/Empleado/Add/',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' );
        }
    });
}

function Update(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5118/api/Empleado/Update/',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
            error: function (result) {
            alert('Error en la consulta.');
        }
    });
}


function Aceptar() {
    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(),
        numeroNomina: $('#txtNumeroNomina').val(),
        nombreEmpleado: $('#txtNombreEmpleado').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        estado: {
            idEstado: $('#ddlEstado').val()
        }
    }

    if (empleado.idEmpleado == '') {
        empleado.idEmpleado = 0; //Para que no llegue como vacio a add
        Add(empleado);

    }
    else {
        Update(empleado);
    }
}

function Eliminar(IdEmpleado) {
    if (confirm("Deseas eliminar el empleado")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5118/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });
    }
}

function LimpiarEmpleado() {

    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(''),
        numeroNomina: $('#txtNumeroNomina').val(''),
        nombreEmpleado: $('#txtNombreEmpleado').val(''),
        apellidoPaterno: $('#txtApellidoPaterno').val(''),
        apellidoMaterno: $('#txtApellidoMaterno').val(''),
        estado: {
            idEstado: $('#ddlEstado').val(0)
        }
    }

}