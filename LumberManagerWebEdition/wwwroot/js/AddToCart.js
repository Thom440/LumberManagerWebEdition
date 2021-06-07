
function changeQuantity() {
    let input = $(this).siblings("#qty").val();
    let url = $(this).attr("href");
    if (this.value == "-") {
        input = input - 1;
    }
    else {
        input = input + 1;
    }
    url = url.replace("0", input);
    $(this).attr("href", url);
}

window.onload = function () {
    let subtract = $(".subtract-button");
    let add = $(".add-button");
    add.on("click", addQuantity);
    subtract.on("click", subtractQuantity)
}

function subtractQuantity() {
    console.log(this);
    console.log($(this).siblings());
    let input = $(this).siblings("#qty").val();
    let num = parseInt(input);
    let url = $(this).attr("formaction");
    num = num - 1;
    url = url.replace("temp", num);
    $(this).attr("formaction", url);
}

function addQuantity() {
    let input = $(this).siblings("#qty").val();
    let num = parseInt(input);
    let url = $(this).attr("href");
    num = num + 1;
    url = url.replace("temp", num);
    $(this).attr("href", url);
}