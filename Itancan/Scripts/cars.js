//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});
//Load Data function
function loadData() {
    $.ajax({
        url: "/Traffic/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.RegistrationNumber + '</td>';
                html += '<td>' + item.CarModel + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#CarModel').val().trim() === "") {
        $('#CarModel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CarModel').css('border-color', 'lightgrey');
    }
    if ($('#RegistrationNumber').val().trim() === "") {
        $('#RegistrationNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RegistrationNumber').css('border-color', 'lightgrey');
    }
    if ($('#CarStatus').val().trim() === "") {
        $('#CarStatus').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CarStatus').css('border-color', 'lightgrey');
    }
    
    return isValid;
}
//Add Data Function
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var carObj = {
        Id: $('#Id').val(),
        CarModel: $('#CarModel').val(),
        RegistrationNumber: $('#RegistrationNumber').val(),
        CarStatus: $('#CarStatus').val()
      
    };
    $.ajax({
        url: "/Traffic/Save",
        data: JSON.stringify(carObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//function for updating employee's record
function Update() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var carObj = {
        Id: $('#Id').val(),
        CarModel: $('#CarModel').val(),
        RegistrationNumber: $('#RegistrationNumber').val(),
        CarStatus: $('#CarStatus').val()
    };
    $.ajax({
        url: "/Traffic/Update",
        data: JSON.stringify(carObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#CarModel').val("");
            $('#RegistrationNumber').val("");
            $('#CarStatus').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Traffic/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for getting the Data Based upon Employee ID
function getbyID(CarID) {
    $('#CarModel').css('border-color', 'lightgrey');
    $('#RegistrationNumber').css('border-color', 'lightgrey');
    $('#CarStatus').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Traffic/getbyID/" + CarID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#CarModel').val(result.CarModel);
            $('#RegistrationNumber').val(result.RegistrationNumber);
            $('#CarStatus').val(result.CarStatus);
             $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


