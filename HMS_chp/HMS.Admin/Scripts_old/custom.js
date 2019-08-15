function DeleteConfirm() {
    if (confirm("Are you sure want to delete record?"))
        return true;
    else
        return false;
}
function EditConfirm() {
    if (confirm("Are you sure want to edit record?"))
        return true;
    else
        return false;
}
function AddConfirm() {
    if (confirm("Are you sure want to add record?"))
        return true;
    else
        return false;
}

function PartialReceivedConfirm() {
    if (confirm("Are you sure to submit material receive partially?"))
        return true;
    else
        return false;
}
function CompletedRequisition() {
    if (confirm("Are you sure you want to Complete Requisition?"))
        return true;
    else
        return false;
}
function SubmitRQConfirm() {
    if (confirm("Are you sure to submit Requisition?"))
        return true;
    else
        return false;
}
function ApprovedRQConfirm() {
    if (confirm("Are you sure want to approved Requisition?"))
        return true;
    else
        return false;
}
function RejectRQConfirm() {
    if (confirm("Are you sure want to Reject Requisition?"))
        return true;
    else
        return false;
}
function SendSMSConfirm() {
    if (confirm("Are you sure want to sent SMS?"))
        return true;
    else
        return false;
}
function LoadDropDownList(objDDLId, url, optionalLabel, objDataTableToReload) {
    var objDDL = $("#" + objDDLId);
    objDDL.empty();
    if (optionalLabel != null) {
        objDDL.append($('<option/>', {
            value: "",
            text: optionalLabel
        }));
    }
    $.ajax({
        cache: false,
        url: url,
        type: "GET",
        beforeSend: function () {
        },
        complete: function () {
        },
        success: function (data) {

            $.each(data, function (index, itemData) {
                objDDL.append($('<option/>', {
                    value: data[index]["Key"],
                    text: data[index]["Value"]
                }));
            });

            if (objDataTableToReload != null) {
                DataTableRedraw(objDataTableToReload);
            }
        },
        error: function (x, e) {
            //alert('error');
        }
    }); //end ajax call
}
function InputOnlyDecimalNumber(el) {
    var ex = /^[0-9]+\.?[0-9]*$/;
    if (ex.test(el.value) == false) {
       el.value = "0.00"//el.value.substring(0, el.value.length - 1);
      //  el.value =el.value.substring(0, el.value.length - 1);
    }
}
function InputOnlyDecimalNumberSetEmpty(el) {
    var ex = /^[0-9]+\.?[0-9]*$/;
    if (ex.test(el.value) == false) {
        el.value = ""//el.value.substring(0, el.value.length - 1);
        //  el.value =el.value.substring(0, el.value.length - 1);
    }
}
//function InputOnlyDecimalNumber(event, pControl) {
//    if (event.charCode == 46)
//        return true;
//    if (event.charCode < 48 || event.charCode > 57) {
//        pControl.value = 0.00;
//        return false;
//    }
//    else
//        return true;
//}

//function InputOnlyDecimalNumber(event) {
//    if (event.charCode == 46)
//        return true;
//    if (event.charCode < 48 || event.charCode > 57) {
//        event.charCode = 000;
//        return false;
//    }
//    else
//        return true;
//}

//function SendSMSConfirm() {
//    if (confirm("Are you sure want to sent SMS?"))
//        return true;
//    else
//        return false;
//}
$(document).ready(function () {
    $(".alert button").click(function () {
        $("div.alert").fadeOut(400);
    });
    var interval = setInterval(function () {
        $(".alert button").trigger("click");
    }, 3000);

    $body = $("body");
    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    });
});