$('#loginbutton').on('click', function (e) {
    e.preventDefault();
    var nid = $("#natenId").val();
    var pin = $("#enpincode").val();
    var status = "true";
    if (nid == "" && pin == "") {
        $("#errormessage").text("Please enter valid credentials");
        status = "false";
    } else if (nid == "") {
        $("#Niderror").text("Please enter valid nationalId");
        status = "false";
    } else if (pin == "") {
        $("#pinerror").text("Please enter 4 digit pin");
        status = "false";
    } else if (nid.length < 10 || nid.length > 10) {
        $("#Niderror").text("Please enter 10 digit nationalId");
    } else if (pin.length < 4 || pin.length > 4) {
        $("#pinerror").text("Please enter valid pin");
    }else if (status == "true") {
        $.ajax({
            type: "GET",
            url: "/Login/ValidateUser",
            data: { nid: nid, pin: pin },
            dataType: "json",
            success: function (result) {
                debugger;
                if ($.trim(result.success).toUpperCase() === "FALSE") {
                    $("#errormessage").show();
                    $("#errormessage").text("Please enter valid credentials");
                    $("#natId").val("");
                    $("#pincode").val("");

                }
                if ($.trim(result.success).toUpperCase() === "TRUE") {
                    location.href = "https://localhost:44310/Home/Index?lang=en";
                }
            },
            error: function (error) {
                //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });
    }




});
$("#natId").keyup(function () {
    checkNid();
    $("#errormessage").hide();

});

$("#pincode").keyup(function () {
    checkpin();
    $("#errormessage").hide();

});

function checkNid() {
    var nid = $("#natId").val();

    if (nid == "") {
        $("#Niderror").text("Please enter valid nationalId");
    }
    if (nid.length < 10) {
        $("#Niderror").show();
        $("#Niderror").text("Please enter 10 digit nationalId");
    } else if (nid.length > 10) {
        $("#Niderror").show();
        $("#Niderror").text("Please enter 10 digit nationalId");
    } else if (!(/^\S{3,}$/.test(nid))) {
        $("#Niderror").show();
        $("#Niderror").text("Please enter whithout space");
        return false;
    } else if (!$.isNumeric(nid)) {
        $("#Niderror").show();
        $("#Niderror").text("Please enter number only");
    }
    else if (nid.length = 10) {
        $("#Niderror").hide();
    }
    else {
        return undefined;
    }


}
function checkpin() {
    var pin = $("#pincode").val();
    if (pin == "") {
        $("#pinerror").show();
        $("#pinerror").text("Please enter 4 digit pin");
    }
    if (pin.length < 4) {
        $("#pinerror").show();
        $("#pinerror").text("Please enter 4 digit pin");
    } else if (pin.length > 4) {
        $("#pinerror").show();
        $("#pinerror").text("Please enter 4 digit pin");
    } else if (!(/^\S{3,}$/.test(pin))) {
        $("#pinerror").show();
        $("#pinerror").text("Please enter without space");
        return false;
    } else if (!$.isNumeric(pin)) {
        $("#pinerror").show();
        $("#pinerror").text("Please enter number only");
    }
    else if (pin.length = 4) {
        $("#pinerror").hide();
    }
    else {
        return undefined;
    }
}

$('#loginarbutton').on('click', function (e) {
    e.preventDefault();
    var nid = $("#natarId").val();
    var pin = $("#arpincode").val();
    var status = "true";
    if (nid == "" && pin == "") {
        $("#errorarmessage").text("Please enter valid credentials");
        status = "false";
    } else if (nid == "") {
        $("#Nidarerror").text("Please enter 10 digit nationalId");
        status = "false";
    } else if (pin == "") {
        $("#pinarerror").text("Please enter 4 digit pin");
        status = "false";
    } else if (status == "true") {
        $.ajax({
            type: "GET",
            url: "/Login/ValidateUser",
            data: { nid: nid, pin: pin },
            dataType: "json",
            success: function (result) {
                debugger;
                if ($.trim(result.success).toUpperCase() === "FALSE") {
                    $("#errorarmessage").show();
                    $("#errorarmessage").text("Please enter valid credentials");
                    $("#natarId").val("");
                    $("#arpincode").val("");

                }
                if ($.trim(result.success).toUpperCase() === "TRUE") {
                    location.href = "https://localhost:44310/Home/Index?lang=ar";
                }
            },
            error: function (error) {
                //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });
    }
});
$("#natarId").keyup(function () {
    checkNid();
    $("#errorarmessage").hide();

});

$("#arpincode").keyup(function () {
    checkpin();
    $("#errorarmessage").hide();

});

function checkNid() {
    var nid = $("#natarId").val();

    if (nid == "") {
        $("#Nidarerror").text("Please enter valid nationalId");
    }
    if (nid.length < 10) {
        $("#Nidarerror").show();
        $("#Nidarerror").text("Please enter 10 digit nationalId");
    } else if (nid.length > 10) {
        $("#Nidarerror").show();
        $("#Nidarerror").text("Please enter 10 digit nationalId");
    } else if (!(/^\S{3,}$/.test(nid))) {
        $("#Nidarerror").show();
        $("#Nidarerror").text("Please enter whithout space");
        return false;
    } else if (!$.isNumeric(nid)) {
        $("#Nidarerror").show();
        $("#Nidarerror").text("Please enter number only");
    }
    else if (nid.length = 10) {
        $("#Nidarerror").hide();
    }
    else {
        return undefined;
    }


}
function checkpin() {
    var pin = $("#arpincode").val();
    if (pin == "") {
        $("#pinarerror").show();
        $("#pinarerror").text("Please enter 4 digit pin");
    }
    if (pin.length < 4) {
        $("#pinarerror").show();
        $("#pinarerror").text("Please enter 4 digit pin");
    } else if (pin.length > 4) {
        $("#pinarerror").show();
        $("#pinarerror").text("Please enter 4 digit pin");
    } else if (!(/^\S{3,}$/.test(pin))) {
        $("#pinarerror").show();
        $("#pinarerror").text("Please enter without space");
        return false;
    } else if (!$.isNumeric(pin)) {
        $("#pinarerror").show();
        $("#pinarerror").text("Please enter number only");
    }
    else if (pin.length = 4) {
        $("#pinarerror").hide();
    }
    else {
        return undefined;
    }
}