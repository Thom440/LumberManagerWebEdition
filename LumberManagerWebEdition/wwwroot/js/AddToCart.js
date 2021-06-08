
window.onload = function () {
    let subtract = $(".subtract-button");
    let add = $(".add-button");
    add.on("click", addQuantity);
    subtract.on("click", subtractQuantity)
}

/**
 * Subtracts quantity by 1 product from cart.
 **/
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

/**
 * Adds quantity by 1 product from cart.
 **/
function addQuantity() {
    let input = $(this).siblings("#qty").val();
    let num = parseInt(input);
    let url = $(this).attr("href");
    num = num + 1;
    url = url.replace("temp", num);
    $(this).attr("href", url);
}