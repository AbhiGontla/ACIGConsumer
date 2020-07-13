"use strict";
//Feilds definition
var Nationalid;
var dateofbirth;
var sentotp;
var enterpin;
var confirmpin;
var langcode;
// Class Definition
var KTLogin = function () {
    var _login;
    var kt_login;

    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-forgot-on');
        _login.removeClass('login-signin-on');
        _login.removeClass('login-signup-on');
        _login.removeClass('login-verify-on');
        _login.removeClass('login-verifyOTP-on');
        _login.removeClass('login-forgotPIN-on');
        _login.addClass(cls);




        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }
    //$('#kt_body').click(function () {
    //    $('kt_login_verify_form').hide();
    //});

    //$('#kt_body').click(function () {
    //    $('kt_login_verifyOTP_form').show();
    //});

    var _handleSignInForm = function () {
        var validation;


        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_signin_form'),
            {
                fields: {
                    username: {
                        validators: {
                            notEmpty: {
                                message: 'Username is required'
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: 'Password is required'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#kt_login_signin_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    swal.fire({
                        text: "All is cool! Now you submit this form",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                } else {
                    swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle forgot button
        $('#kt_login_forgot').on('click', function (e) {
            e.preventDefault();
            $('#kt_login_forgot_form').hide();
            $('#kt_login_forgotPIN_form').show();
            _showForm('forgotPIN');
        });

        // Handle forgotPIN button
        //$('#kt_login_forgotPIN').on('click', function (e) {
        //    e.preventDefault();
        //    _showForm('forgotPIN');
        //    $('#kt_forgotPIN').show();

        //});


        // Handle signup
        $('#kt_login_signup').on('click', function (e) {
            e.preventDefault();
            _showForm('signup');
        });
    }

    var _handleSignUpForm = function (e) {
        var validation;
        var form = KTUtil.getById('kt_login_signup_form');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    fullname: {
                        validators: {
                            notEmpty: {
                                message: 'Username is required'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'Email address is required'
                            },
                            emailAddress: {
                                message: 'The value is not a valid email address'
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: 'The password is required'
                            }
                        }
                    },
                    cpassword: {
                        validators: {
                            notEmpty: {
                                message: 'The password confirmation is required'
                            },
                            identical: {
                                compare: function () {
                                    return form.querySelector('[name="password"]').value;
                                },
                                message: 'The password and its confirm are not the same'
                            }
                        }
                    },
                    agree: {
                        validators: {
                            notEmpty: {
                                message: 'You must accept the terms and conditions'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );
        //Handle signup button redirect to verify page if click on submit
        $('#kt_login_signup_submit').on('click', function (e) {
            debugger;
            e.preventDefault();
            Nationalid = $("#nId").val();
            dateofbirth = $("#dob").val();


        });

        // Handle cancel button
        $('#kt_login_signup_cancel').on('click', function (e) {
            e.preventDefault();
            _showForm('signin');
        });

        //Handle redirect to verify details page
        $('#kt_login_signup_submit').on('click', function (e) {
            debugger;
            e.preventDefault();
            Nationalid = $("#nId").val();
            dateofbirth = $("#dob").val();
            var nid = Nationalid;
            var status = "true";
            if (nid == "") {
                $("#signuperror").show();
                $("#signuperror").text("Please enter valid nationalId");
                status = "false";
            } else if (Nationalid.length < 10) {
                $("#signuperror").show();
                $("#signuperror").text("Please enter valid nationalId");
                status = "false";
            } else if (Nationalid.length > 10) {
                $("#signuperror").show();
                $("#signuperror").text("Please enter valid nationalId");
                status = "false";
            }else {
                _showForm('verify');
                if (document.getElementById('kt_login_signup_submit').click) {
                    document.getElementById('kt_login_verify_form').style.display = 'block';
                } else {
                    document.getElementById('kt_login_verifyOTP_form').style.display = 'none';
                }
            }

        });



        $("#dob").keyup(function () {

            $("#errormessage").hide();

        });
        //Handle redirect to login page if click on verify OTP page
        $('#kt_login_verifyOTP_submit').on('click', function (e) {
            e.preventDefault();
            var enteredotp = $("#codeBox1").val() + $("#codeBox2").val() + $("#codeBox3").val() + $("#codeBox4").val();
            if (sentotp != enteredotp) {
                $("#otpError").text("Please enter valid OTP");
            } else {               
                _showForm('forgot');
                $('#kt_login_verifyOTP').hide();
                $('#kt_login_forgot_form').show();
            }

        });





        //Handle redirect to signup page if click no
        $('#kt_login_verify_cancel').on('click', function (e) {
            e.preventDefault();
            _showForm('signup');
            $('#kt_login_verify_form').hide();
        });

    }



    var _handleForgotForm = function (e) {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_forgot_form'),
            {
                fields: {
                    text: {
                        validators: {
                            notEmpty: {
                                message: 'Email address is required'
                            },
                            text: {
                                message: 'The value is not a valid email address'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        // Handle submit button
        $('#kt_login_forgot_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    // Submit form
                    KTUtil.scrollTop();
                } else {
                    swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });



        // Handle cancel button
        $('#kt_login_forgot_cancel').on('click', function (e) {
            e.preventDefault();
            _showForm('signin');
        });
    }

    var _handleForgotPINForm = function (e) {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_forgotPIN_form'),
            {
                fields: {
                    text: {
                        validators: {
                            notEmpty: {
                                message: 'Mobile number is required'
                            },
                            text: {
                                message: 'The value is not a valid Mobile Number'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        // Handle submit button
        $('#kt_login_forgotPIN_submit').on('click', function (e) {
            e.preventDefault();
            $('#kt_login_verifyOTP_form').show();
            _showForm('verifyOTP');
            $('#kt_login_forgotPIN_form').hide();
        });



        // Handle cancel button
        $('#kt_login_forgotPIN_cancel').on('click', function (e) {
            e.preventDefault();
            $('#kt_login_forgotPIN_form').hide();
            _showForm('signin');
        });
    }

    // Public Functions
    return {
        // public functions
        init: function () {
            _login = $('#kt_login');
            _handleSignInForm();
            _handleSignUpForm();
            _handleForgotForm();
            _handleVerifyForm();
            _handleForgotPINForm();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
    $("#kt_login_verify_form").hide();
    $("#kt_login_verifyOTP_form").hide();
    $("#kt_login_forgotPIN_form").hide();
    $('#kt_login_signin_arform').hide(); 
    $('#btnenlang').hide(); 
});

var _handleVerifyForm = function (e) {
    var validation;

    // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
    validation = FormValidation.formValidation(
        KTUtil.getById('kt_login_verify_form'),
        {
            plugins: {
                trigger: new FormValidation.plugins.Trigger(),
                bootstrap: new FormValidation.plugins.Bootstrap()
            }
        }
    );

    //// Handle Verify_submit button
    //$('#kt_login_verify_submit').on('click', function (e) {
    //    debugger;
    //    e.preventDefault();



    //});



    // Handle Verify_cancel button
    $('#kt_login_verify_cancel').on('click', function (e) {
        e.preventDefault();
        _showForm('signup');
        $('#kt_login_verify_form').hide();
    });
}

//Handle redirect to verify OTP page if click yes
$('#kt_login_verify_submit').on('click', function (e) {
    e.preventDefault();

    if (document.getElementById('kt_login_verify_submit').click) {
        document.getElementById('kt_login_verifyOTP_form').style.display = 'block';

    } else {
        document.getElementById('kt_login_verify_form').style.display = 'none';
    }
    //_showForm('verifyOTP');
    $('#kt_login_verify_form').hide();
    $.ajax({
        type: "POST",
        url: "/Login/sendsms",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            sentotp = $.trim(result.sentotp).toUpperCase();
            alert(sentotp);

            //$("#dataDiv").html(result);
        },
        error: function (error) {
            //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
        }
    });
});
//once u click on create pin submit button
$('#pinbutton').on('click', function (e) {
    e.preventDefault();
    debugger;
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
            url: "/Login/RegisterUser",
            data: { nid: Nationalid, dob: dateofbirth, enterpin: epin, confirmpin: cpin },
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
                    location.href = "https://localhost:44310/Home/Index";
                }
            },
            error: function (error) {
                //$("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)

            }

        });
    }
});

$("#nId").keyup(function () {
    validateNid();
    $("#signuperror").hide();
    $("#errormessage").hide();

});

function validateNid() {
    $("#signuperror").hide();
  
    Nationalid = $("#nId").val();
    dateofbirth = $("#dob").val();
    var nid = Nationalid;
    var status = "true";
    if (Nationalid.length < 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
    } else if (Nationalid.length > 10) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter valid nationalId");
        status = "false";
    } else if (!(/^\S{3,}$/.test(Nationalid))) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter whithout space");
        status = "false";
        return false;
    } else if (!$.isNumeric(Nationalid)) {
        $("#signuperror").show();
        $("#signuperror").text("Please enter number only");
        status = "false";
    }
    else if (Nationalid.length = 10) {
        $("#signuperror").hide();
        status = "true";
    } else {
        return true;
    }
}





$('#btnarlang').on('click', function (e) {
    e.preventDefault();
    $('#kt_login_signin_form').hide();
    $('#btnarlang').hide();
    langcode = "ar";
    $('#kt_login_signin_arform').show();
    $('#btnenlang').show(); 
    
});
$('#btnenlang').on('click', function (e) {
    e.preventDefault();
    $('#kt_login_signin_arform').hide();
    $('#btnenlang').hide();
    langcode = "en";
    $('#kt_login_signin_form').show();
    $('#btnarlang').show();
});

