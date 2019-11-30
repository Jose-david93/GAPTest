


$(document).ready(function () {
    $("#dni").change(function () {
        if ($(this).val() != "")
        {
            $.ajax({
                url: "https://localhost:44375/api/Patients/FindByDni/" + $(this).val(),
                success: function (data) {
                    console.log(data);
                },
                error: function () {
                    console.log("something worng");
                }
            });
        }
    });
});