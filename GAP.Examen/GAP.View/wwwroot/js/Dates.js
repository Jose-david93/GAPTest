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
    $.ajax({
        type: "POST",
        url: "https://localhost:44375/api/Dates/CreateDate",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: request,
        success: function (data) {
            if (data.success) {
                $("#mensaje").text(data.message);
                $("#mensaje").addClass("alert-success").removeClass("text-hide").removeClass("alert-warning");
            }
            else {
                $("#mensaje").text(data.message);
                $("#mensaje").addClass("alert-warning").removeClass("text-hide").removeClass("alert-warning");
            }
        },
        error: function () {
            console.log("something worng");
        }
    });
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
                    console.log(data);
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
});