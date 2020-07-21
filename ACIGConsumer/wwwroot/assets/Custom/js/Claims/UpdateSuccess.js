"use strict";


// Class Definition
var KTLogin = function () {
    // Public Functions

    function show() {
        debugger;
        swal.fire({
            text: "Claim Update Successful.",
            icon: "success",
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
            show();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});
