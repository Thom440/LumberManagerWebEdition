
window.onload = function() {
    let submit = document.getElementById("submit");
    submit.onclick = validateEntries;
}

function validateEntries() {
    let isValid = true;

    $("#firstName").blur(function () {
        if (!$.trim(0).length) {
            isValid = false;
            $("#confirm").submit(function (e){
                e.preventDefault();
            }
        }
    })
}