
window.onload = function() {
    let onSubmit = document.getElementById("submit");
    onSubmit.onclick = validateEntries;
}

function validateEntries() {
    let isValid = true;

    $("#firstName").blur(function () {
        if (!$.trim(0).length) {
            isValid = false;
            $("#confirm").submit(function (e){
                e.preventDefault();
            })
        }
    })
}