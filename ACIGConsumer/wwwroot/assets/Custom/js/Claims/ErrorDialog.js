"use strict";



// Class Definition
var KTLogin = function () {
    // Public Functions

    function showError() {
        debugger;
        swal.fire({
            text: "Claim Request Failed. Please Try Again!",
            icon: "error",
            buttonsStyling: false,
            confirmButtonText: "OK",
            customClass: {
                confirmButton: "btn font-weight-bold btn-light-primary"
            }
        }).then(function () {
            KTUtil.scrollTop();
        });
    }

    return {
        // public functions
        init: function () {
            showError();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});
