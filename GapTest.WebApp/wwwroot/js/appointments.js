function appointmentList() {
    // Call Web API to get a list of Appointments
    $.ajax({
        url: '/api/Appointments/',
        type: 'GET',
        dataType: 'json',
        success: function (appointments) {
            appointmentListSuccess(appointments);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function appointmentListSuccess(appointments) {
    $("#appointmentTable tbody").remove();
    // Iterate over the collection of data
    $.each(appointments, function (index, appointment) {
        // Add a row to the Appointment table
        appointmentAddRow(appointment);
    });
}

function appointmentAddRow(appointment) {
    // Check if <tbody> tag exists, add one if not
    if ($("#appointmentTable tbody").length == 0) {
        $("#appointmentTable").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#appointmentTable tbody").append(
        appointmentBuildTableRow(appointment));
}

function appointmentBuildTableRow(appointment) {
    var ret =
        "<tr>" +
        "<td>" + appointment.patient.name + "</td>" +
        "<td>" + appointment.date + "</td>" +
        "<td>" + appointment.specialty.name + "</td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='appointmentDelete(this);' " +
        "class='btn btn-default' " +
        "data-id='" + appointment.id + "'>" +
        "<span>x</span>" +
        "</button>" +
        "</td>" +
        "</tr>";
    return ret;
}

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
    // Iterate over the collection of data
    $.each(patients, function (index, patient) {
        // Add a option to the Specialty select
        patientAddOption(patient);
    });
}

function patientAddOption(patient) {
    // Append option to <select>
    $("#patientList").append(
        "<option value='" + patient.id + "'>" + patient.name + "</option>");
}

function specialtyList() {
    // Call Web API to get a list of Specialties
    $.ajax({
        url: '/api/Specialities/',
        type: 'GET',
        dataType: 'json',
        success: function (specialties) {
            specialtyListSuccess(specialties);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function specialtyListSuccess(specialties) {
    // Iterate over the collection of data
    $.each(specialties, function (index, specialty) {
        // Add a option to the Specialty select
        specialtyAddOption(specialty);
    });
}

function specialtyAddOption(specialty) {
    // Append option to <select>
    $("#specialtyList").append(
        "<option value='" + specialty.id + "'>" + specialty.name + "</option>");
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
    appointmentList();
    patientList();
    specialtyList();
});

function addClick() {
    // Build appointment object from inputs
    appointment = new Object();
    appointment.patientId = parseInt($("#patientList option:selected").val());
    appointment.date = $("#appointmentDate").val();
    appointment.specialtyId = parseInt($("#specialtyList option:selected").val());
    appointmentAdd(appointment);
}

function appointmentAdd(appointment) {
    $.ajax({
        url: "/api/Appointments",
        type: 'POST',
        contentType:"application/json;charset=utf-8",
        data: JSON.stringify(appointment),
        success: function (worked) {
            if (worked) {
                appointmentAddSuccess();
            }
            else {
                alert("Appointment can't be created.");
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function appointmentAddSuccess() {
    appointmentList();
    formClear();
}

function formClear() {
    $("#patientList").val("");
    $("#appointmentDate").val("");
    $("#specialtyList").val("");
}

function clearClick() {
    formClear();
}

function appointmentDelete(ctl) {
    var id = $(ctl).data("id");

    $.ajax({
        url: "/api/Appointments/" + id,
        type: 'DELETE',
        success: function (worked) {
            if (worked) {
                $(ctl).parents("tr").remove();
            }
            else {
                alert("Appointment can't be canceled.");
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}