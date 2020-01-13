function patientList() {
    // Call Web API to get a list of Patients
    $.ajax({
        url: '/api/Patients/',
        type: 'GET',
        dataType: 'json',
        success: function (patients) {
            patientListSuccess(patients);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function patientListSuccess(patients) {
    $("#patientTable tbody").remove();
    // Iterate over the collection of data
    $.each(patients, function (index, patient) {
        // Add a row to the Patient table
        patientAddRow(patient);
    });
}

function patientAddRow(patient) {
    // Check if <tbody> tag exists, add one if not
    if ($("#patientTable tbody").length == 0) {
        $("#patientTable").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#patientTable tbody").append(
        patientBuildTableRow(patient));
}

function patientBuildTableRow(patient) {
    var ret =
        "<tr>" +
        "<td>" + patient.name + "</td>" +
        "<td>" + patient.identificationNumber + "</td>" +
        "<td>" + patient.phoneNumber + "</td>" +
        "<td>" + patient.email + "</td>" +
        "</tr>";
    return ret;
}

function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}

$(document).ready(function () {
    patientList();
});

function addClick() {
    // Build patient object from inputs
    patient = new Object();
    patient.name = $("#patientName").val();
    patient.identificationNumber = $("#identificationNumber").val();
    patient.phoneNumber = $("#phoneNumber").val();
    patient.email = $("#email").val();
    patientAdd(patient);
}

function patientAdd(patient) {
    $.ajax({
        url: "/api/Patients",
        type: 'POST',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(patient),
        success: function (worked) {
            if (worked) {
                patientAddSuccess();
            }
            else {
                alert("Patient can't be created.");
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function patientAddSuccess() {
    patientList();
    formClear();
}

function formClear() {
    $("#patientName").val("");
    $("#identificationNumber").val("");
    $("#phoneNumber").val("");
    $("#email").val("");
}
function clearClick() {
    formClear();
}