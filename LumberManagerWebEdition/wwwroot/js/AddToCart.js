
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

function subtractQuantity() {
    let input = $(this).siblings("#qty").val();
    let url = $(this).attr("href");
    input = input - 1;
    url = url.replace("0", input);
    $(this).attr("href", url);
}

function addQuantity() {
    let input = $(this).siblings("#qty").val();
    let num = parseInt(input);
    let url = $(this).attr("href");
    num = num + 1;
    url = url.replace("0", num);
    $(this).attr("href", url);
}