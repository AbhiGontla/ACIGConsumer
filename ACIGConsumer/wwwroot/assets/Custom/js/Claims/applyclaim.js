"use strict";

// Class definition
var KTUppy = function () {
	const Tus = Uppy.Tus;
	const ProgressBar = Uppy.ProgressBar;
	const StatusBar = Uppy.StatusBar;
	const FileInput = Uppy.FileInput;
	const Informer = Uppy.Informer;

	// to get uppy companions working, please refer to the official documentation here: https://uppy.io/docs/companion/
	const Dashboard = Uppy.Dashboard;


	// Private functions
	var initUppy1 = function () {
		var id = '#kt_uppy_1';

		var options = {
			proudlyDisplayPoweredByUppy: false,
			target: id,
			inline: true,
			replaceTargetContent: true,
			showProgressDetails: true,

			height: 470,
			metaFields: [
				{ id: 'name', name: 'Name', placeholder: 'file name' },
				{ id: 'caption', name: 'Caption', placeholder: 'describe what the image is about' }
			],
			browserBackButtonClose: true
		}

		var uppyDashboard = Uppy.Core({
			autoProceed: true,
			restrictions: {
				maxFileSize: 1000000, // 1mb
				maxNumberOfFiles: 5,
				minNumberOfFiles: 1
			}
		});

		uppyDashboard.use(Dashboard, options);


	}


	return {
		// public functions
		init: function () {
			initUppy1();


			setTimeout(function () {

			}, 2000);
		}
	};
}();

jQuery(document).ready(function () {
	KTUppy.init();
});



$('#btnapply').on('click', function (e) {
	e.preventDefault();
	var claimtypeid = $("#claimtypeid").val();
	var banknameid = $("#banknameid").val();
	var ibanid = $("#ibanid").val();
	var claimamoutid = $("#claimamoutid").val();
	var vatid = $("#vatid").val();
	var noteid = $("#noteid").val();
	var status = "true";
	if (claimtypeid == "") {
		$("#errormessage").text("Please select claim type");
		status = "false";
	} if (banknameid == "") {
		$("#bnkerror").text("Please select bank name");
		status = "false";
	} if (ibanid == "") {
		$("#ibanerror").text("Please enter iban number");
		status = "false";
	}
	if (claimamoutid == "") {
		$("#claimerror").text("Please enter claim amount");
		status = "false";
	}
	if (vatid == "") {
		$("#vaterror").text("Please enter vat amount");
		status = "false";
	}
	if (noteid == "") {
		$("#noteerror").text("Please enter remarks");
		status = "false";
	} if (status == "true") {
		$.ajax({
			type: "GET",
			url: "/Login/ValidateUser",
			data: { claimtypeid: claimtypeid, banknameid: banknameid, ibanid: ibanid, claimamoutid: claimamoutid, vatid: vatid, noteid: noteid },
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


function checkclaimamoutid() {
	var claimamoutid = $("#claimamoutid").val();

	if (claimamoutid == "") {
		$("#claimerror").text("Please enter claim amount");
	}
	else if (!(/^\S{3,}$/.test(claimamoutid))) {
		$("#claimerror").show();
		$("#claimerror").text("Please enter only amount");
		return false;
	}
	else {
		return undefined;
	}


}