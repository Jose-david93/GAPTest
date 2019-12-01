var dates;
function fillServices() {
    $.ajax({
        url: "https://localhost:44375/api/Dates/GetServices",
        success: function (data) {
            if (data.success) {
                for (var i = 0; i < data.data.length; i++)
                {
                    $("#servicios").append(`<option value=${data.data[i].id}>${data.data[i].name}</option>`);
                }
            }
        },
        error: function () {
            console.log("something worng");
        }
    });
}
function validate() {
    band = true;
    $(".required").each(function (index) {
        if ($(this).val() == "")
            band = false;
    });
    if (!(moment($("#fechaCita").val(), 'YYYY-MM-DDTHH:mm', true).isValid())) {
        band = false;
    }
    return band;
}

function agendar() {
    DateObj = {
        IdPatientJs: $("#idPatient").val(),
        IdServiceJs: $("#servicios").val(),
        DateService: $("#fechaCita").val(),
        Dni: $("#dni").val(),
        FirstName: $("#nombre").val(),
        LastName: $("#apellido").val(),
        Description: $("#descripcion").val()
    };

    request = JSON.stringify(DateObj);
    if (validate()) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44375/api/Dates/CreateDate",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: request,
            success: function (data) {
                if (data.success) {
                    $(".rem, .rem2, #dni").val("");
                    $("#mensaje").text(data.message);
                    $("#mensaje").addClass("alert-success").removeClass("text-hide").removeClass("alert-warning");
                }
                else {
                    $("#mensaje").text(data.message);
                    $("#mensaje").addClass("alert-warning").removeClass("text-hide").removeClass("alert-success");
                }
            },
            error: function () {
                console.log("something worng");
            }
        });
    }
    else {
        $("#mensaje").text("Valida que todos los campos requeridos esten bien llenos");
        $("#mensaje").addClass("alert-warning").removeClass("text-hide").removeClass("alert-success");
    }
}

$(document).ready(function () {
    fillServices();

    $("#agendar").click(function () {
        agendar();
    });

    $("#dni").change(function () {
        if ($(this).val() !== "") {
            $.ajax({
                url: "https://localhost:44375/api/Patients/FindByDni/" + $(this).val(),
                success: function (data) {
                    if (data.success) {

                        $("#idPatient").val(data.data.id);
                        $("#dni").val(data.data.dni);
                        $("#nombre").val(data.data.firstName);
                        $("#apellido").val(data.data.lastName);
                        $("#dni").val(data.data.dni);
                    }
                    else {
                        $(".rem").val("");
                    }
                },
                error: function () {
                    console.log("something worng");
                }
            });
        }
        else {
            $(".rem").val("");
        }
    });

    dates = $('#dates').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "searching": false,
        "responsive": true,
        "ajax": {
            "url": "GetDates",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "name": "id" },
            { "data": "dni", "name": "dni" },
            { "data": "firstName", "name": "firstName" },
            { "data": "lastName", "name": "lastName" },
            { "data": "service", "name": "service" },
            { "data": "description", "name": "status" },
            { "data": "statusM", "name": "status" },
            { "data": "dateService", "name": "dateService", "type": "date" }
        ],
        "columnDefs": [
            {
                "targets": 0,
                "visible": false
            },
            {
                "targets": 8,
                "data": null,
                "defaultContent": "<button class='btn btn-success' type='button'>Cancelar</button>"
            }],
        language: language
    });

    $('#dates tbody').on('click', 'button', function () {
        var data = dates.row($(this).parents('tr')).data();
        DateObj = {
            IdJs: data.Id
        };

        request = JSON.stringify(DateObj); 

        $.ajax({
            url: "https://localhost:44375/api/Dates/CancelDate/" + data.id,
            success: function (data)
            {
                if (data.success) {
                    location.reload();
                }
                else {
                    $("#mensaje").text(data.message);
                    $("#mensaje").addClass("alert-warning").removeClass("text-hide").removeClass("alert-success");
                }
            },
            error: function () {
                console.log("something worng");
            }
        });
    });
});