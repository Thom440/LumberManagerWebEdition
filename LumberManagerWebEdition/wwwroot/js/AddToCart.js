function changeQuantity(button) {
    let input = $(button).siblings("#qty").val();
    let url = $(button).attr("href");
    url = url.replace("0", input);
    $(button).attr("href", url);
}