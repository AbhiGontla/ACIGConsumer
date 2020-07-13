'use strict';

jQuery(document).ready(function () {
    var t; t = KTUtil.isRTL() ? {
        leftArrow: '<i class="la la-angle-right"></i>', rightArrow: '<i class="la la-angle-left"></i>'
    } : {
            leftArrow: '<i class="la la-angle-left"></i>', rightArrow: '<i class="la la-angle-right"></i>'
        };

    var arrows;
    if (KTUtil.isRTL()) {
        arrows = {
            leftArrow: '<i class="la la-angle-right"></i>',
            rightArrow: '<i class="la la-angle-left"></i>'
        }
    } else {
        arrows = {
            leftArrow: '<i class="la la-angle-left"></i>',
            rightArrow: '<i class="la la-angle-right"></i>'
        }
    }

    $("#kt_datepicker_2_modal").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, orientation: "bottom left", templates: t });

    $('#kt_daterangepicker_2').daterangepicker({
        buttonClasses: ' btn',
        applyClass: 'btn-primary',        
        cancelClass: 'btn-secondary'
    }, function (start, end, label) {
        $('#kt_daterangepicker_2 .form-control').val(start.format('YYYY-MM-DD') + ' / ' + end.format('YYYY-MM-DD'));
    });

    // range picker
    $('#kt_datepicker_5').datepicker({
        rtl: KTUtil.isRTL(),
        todayHighlight: true,
        templates: arrows
    });
    $('#kt_datepicker_4_2').datepicker({
        rtl: KTUtil.isRTL(),
        orientation: "top right",
        todayHighlight: true,
        templates: arrows,
        format: 'dd-mm-yyyy'
    });
    $('#kt_datepicker_4_3').datepicker({
        rtl: KTUtil.isRTL(),
        orientation: "bottom left",
        todayHighlight: true,
        templates: arrows
    });
});