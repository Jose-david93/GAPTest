var orderTable;
$(document).ready(function () {
    $('#patients').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "searching": false,
        "ajax": {
            "url": "Patient/GetPatients",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "dni", "name": "dni" },
            { "data": "firstName", "name": "firstName" },
            { "data": "lastName", "name": "lastName" }
        ],

        language: language
    });

});