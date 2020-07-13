/// <reference path="jquery.session.js" />
var Nationalid;
var dateofbirth;
var sentotp;
var enterpin;
var confirmpin;
var langcode;
var flag = 0;

$("#nId").keyup(function () {
    validateNid();
    $("#signuperror").hide();
    $("#errormessage").hide();

});

function validateNid() {
    $("#signuperror").hide();

    Nationalid = $("#nId").val();
    dateofbirth = $(".dob").val();
    var nid = Nationalid;
    var status = "true";
    if (Nationalid.length < 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (!(/^\S{3,}$/.test(Nationalid))) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter whithout space");
        status = "false";
        return status;
    }
    if (!$.isNumeric(Nationalid)) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter number only");
        status = "false";
        return status;
    }
    if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (Nationalid.length = 10) {
        $("#signuperror").hide();
        status = "true";
        flag = 1;
        return status;
    } else {
        return status;
    }
}


function validateNidar() {
    $("#signuperror").hide();

    Nationalid = $("#nIdar").val();
    dateofbirth = $(".dobar").val();
    var nid = Nationalid;
    var status = "true";
    if (Nationalid.length < 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (!(/^\S{3,}$/.test(Nationalid))) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter whithout space");
        status = "false";
        return status;
    }
    if (!$.isNumeric(Nationalid)) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter number only");
        status = "false";
        return status;
    }
    if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
        return status;
    }
    if (Nationalid.length = 10) {
        $("#signuperror").hide();
        status = "true";
        flag = 1;
        return status;
    } else {
        return status;
    }
}



$('#btn_signup_submit').on('click', function (e) {
    e.preventDefault();
    Nationalid = $("#nId").val();
    dateofbirth = $(".dob").val();
    var status = "false";
    if (Nationalid.length < 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";      
    }
    if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";      
    }
    if (!(/^\S{3,}$/.test(Nationalid))) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter whithout space");
        status = "false";       
    }
    if (!$.isNumeric(Nationalid)) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter number only");
        status = "false";      
    }
    if (Nationalid.length > 10 || Nationalid.length < 10 || Nationalid.length == 0) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";      
    } else {
        $.ajax({
            type: "GET",
            url: "/Test/VerifyDetails",
            data: { nid: Nationalid, dob: dateofbirth },
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.success) {
                    location.href = "https://localhost:44310/Test/VerifyDetails?lang=en";
                }

                //$("#dataDiv").html(result);
            },
            error: function (error) {
                //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });
    }

});


$('#btnar_signup_submit').on('click', function (e) {
    e.preventDefault();
    Nationalid = $("#nIdar").val();
    dateofbirth = $(".dobar").val();
    $.session.set("Nationid", Nationalid);
 
    validateNidar();
    if (flag = 1) {
        $.ajax({
            type: "GET",
            url: "/Test/VerifyDetails",
            data: { nid: Nationalid, dob: dateofbirth },
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.success) {
                    location.href = "https://localhost:44310/Test/VerifyDetails?lang=ar";
                }

                //$("#dataDiv").html(result);
            },
            error: function (error) {
                //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });
    }


});
$('#btn_verify').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Login/sendsms",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            if ($.trim(result.success).toUpperCase() == "TRUE") {
                sentotp = $.trim(result.sentotp).toUpperCase();
                alert(sentotp);
                location.href = "https://localhost:44310/Test/VerifyOTP?lang=en";
                //$("#dataDiv").html(result);
            } else {               
                $("#sendError").text("OTP Sending Failed");
            }
           
        },
        error: function (error) {

        }
    });
});
$('#btn_verify_ar').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Login/sendsms",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            if ($.trim(result.success).toUpperCase() == "TRUE") {
                sentotp = $.trim(result.sentotp).toUpperCase();
                alert(sentotp);
                location.href = "https://localhost:44310/Test/VerifyOTP?lang=en";
                //$("#dataDiv").html(result);
            } else {
                
                $("#otpError").text("OTP Sending Failed");
            }
        },
        error: function (error) {

        }
    });
});

//Handle redirect to login page if click on verify OTP page
$('#btn_otp_verify').on('click', function (e) {
    e.preventDefault();
    alert(sentotp);
    var enteredotp = $("#codeBox1").val() + $("#codeBox2").val() + $("#codeBox3").val() + $("#codeBox4").val();

    $.ajax({
        type: "GET",
        url: "/Login/validateOTP",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: { otp: enteredotp },
        dataType: "json",
        success: function (result) {
            debugger;
            if (result.success) {
                location.href = "https://localhost:44310/Test/CreatePin?lang=en";
            } else {
                $("#otpError").text("Please enter valid OTP");
            }
        },
        error: function (error) {
            $("#otpError").text("Please enter valid OTP");
        }
    });
});
$('#btn_otp_verify_ar').on('click', function (e) {
    e.preventDefault();

    var enteredotp = $("#codeBox1").val() + $("#codeBox2").val() + $("#codeBox3").val() + $("#codeBox4").val();

    $.ajax({
        type: "GET",
        url: "/Login/validateOTP",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: { otp: enteredotp },
        dataType: "json",
        success: function (result) {
            debugger;
            if (result.success) {
                location.href = "https://localhost:44310/Test/CreatePin?lang=ar";
            } else {
                $("#otpError").text("Please enter valid OTP");
            }
        },
        error: function (error) {
            $("#otpError").text("Please enter valid OTP");
        }
    });
});

$('#btn_verify_pin').on('click', function (e) {
    e.preventDefault();

    var epin = $("#enterpin").val();
    var cpin = $("#confirmpin").val();
    if (epin == "" || cpin == "") {
        $("#peror").show();
        $("#peror").text("Please enter valid pin");

    } else if (epin.length > 4 || cpin.length > 4) {
        $("#peror").show();
        $("#peror").text("Please enter 4 digit pin");
    } else if (epin.length < 4 || cpin.length < 4) {
        $("#peror").show();
        $("#peror").text("Please enter 4 digit pin");
    } else if (epin != cpin) {
        $("#peror").show();
        $("#peror").text("Please enter same pin");
    } else if (epin == cpin) {
        $("#peror").hide();
        $.ajax({
            type: "POST",
            url: "/Test/RegisterUser",
            data: { enterpin: epin, confirmpin: cpin },
            dataType: "json",
            success: function (result) {
                debugger;
                if ($.trim(result.success).toUpperCase() === "FALSE") {
                    $("#peror").show();
                    $("#peror").text("User Registration Failed");
                    $("#nId").val("");
                    $("#dob").val("");

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
$('#btn_verify_pin_ar').on('click', function (e) {
    e.preventDefault();

    var epin = $("#enterpin").val();
    var cpin = $("#confirmpin").val();
    if (epin == "" || cpin == "") {
        $("#peror").show();
        $("#peror").text("Please enter valid pin");

    } else if (epin.length > 4 || cpin.length > 4) {
        $("#peror").show();
        $("#peror").text("Please enter 4 digit pin");
    } else if (epin.length < 4 || cpin.length < 4) {
        $("#peror").show();
        $("#peror").text("Please enter 4 digit pin");
    } else if (epin != cpin) {
        $("#peror").show();
        $("#peror").text("Please enter same pin");
    } else if (epin == cpin) {
        $("#peror").hide();
        $.ajax({
            type: "POST",
            url: "/Test/RegisterUser",
            data: { enterpin: epin, confirmpin: cpin },
            dataType: "json",
            success: function (result) {
                debugger;
                if ($.trim(result.success).toUpperCase() === "FALSE") {
                    $("#peror").show();
                    $("#peror").text("User Registration Failed");
                    $("#nId").val("");
                    $("#dob").val("");

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