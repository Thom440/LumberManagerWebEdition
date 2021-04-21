window.onload = function () {
    let wwCheckBox = document.getElementById("ww");
    let twoFiveCheckBox = document.getElementById("25");
    let fourOCheckBox = document.getElementById("40");
    let sixOCheckBox = document.getElementById("60");
    let acqCheckBox = document.getElementById("acq");
    let ccaCheckBox = document.getElementById("cca");
    wwCheckBox.onclick = disableCheckBoxes;
    twoFiveCheckBox.onclick = disableCheckBoxes;
    fourOCheckBox.onclick = disableCheckBoxes;
    sixOCheckBox.onclick = disableCheckBoxes;
    acqCheckBox.onclick = disableCheckBoxes;
    ccaCheckBox.onclick = disableCheckBoxes;
}

function disableCheckBoxes() {
    if (this == document.getElementById("ww")) {
        if (this.checked) {
            $("input.group2").prop("disabled", true);
            $("input.group3").prop("disabled", true);
            $("#acq").prop("checked", false);
            $("#cca").prop("checked", false);
        }
        else {
            $("input.group2").prop("disabled", false);
            $("input.group3").prop("disabled", false);
        }
    }
    else if (this == document.getElementById("25")) {
        if (this.checked) {
            $("input.group1").prop("disabled", true);
            $("#40").prop("checked", false);
            $("#60").prop("checked", false);
        }
        else if ($("#acq").prop("checked") == false && $("#cca").prop("checked") == false) {
            $("input.group1").prop("disabled", false);
        }
    }
    else if (this == document.getElementById("40")) {
        if (this.checked) {
            $("input.group1").prop("disabled", true);
            $("#25").prop("checked", false);
            $("#60").prop("checked", false);
        }
        else if ($("#acq").prop("checked") == false && $("#cca").prop("checked") == false) {
            $("input.group1").prop("disabled", false);
        }
    }
    else if (this == document.getElementById("60")) {
        if (this.checked) {
            $("input.group1").prop("disabled", true);
            $("#25").prop("checked", false);
            $("#40").prop("checked", false);
        }
        else if ($("#acq").prop("checked") == false && $("#cca").prop("checked") == false) {
            $("input.group1").prop("disabled", false);
        }
    }
    else if (this == document.getElementById("acq")) {
        if (this.checked) {
            $("input.group1").prop("disabled", true);
            $("#cca").prop("checked", false);
        }
        else {
            if ($("#25").prop("checked") == false && $("#40").prop("checked") == false &&
                $("#60").prop("checked") == false) {
                $("input.group1").prop("disabled", false);
            }
        }
    }
    else {
        if (this.checked) {
            $("input.group1").prop("disabled", true);
            $("#acq").prop("checked", false);
        }
        else if ($("#25").prop("checked") == false && $("#40").prop("checked") == false &&
                  $("#60").prop("checked") == false) {
            $("input.group1").prop("disabled", false);
        }
    }
}