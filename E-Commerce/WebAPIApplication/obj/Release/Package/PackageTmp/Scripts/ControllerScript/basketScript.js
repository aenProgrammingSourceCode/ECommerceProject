

// Add product to basket method
function AddProductToBasket(Id) {

    $.ajax({
        url: '/api/Basket/AddProductItemToBasket?ProductId=' + Id,
        type: 'POST',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            GetBasketSummary();
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}

// Get basket summary
function GetBasketSummary() {
    $.ajax({
        url: '/api/Product/GetBasketSummary',
        type: 'GET',
        cache: false,
        async: true,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            // Render data jtemplate
            $("#basketSummaryHtml").setTemplate($("#basketSummaryTemp").html());
            $("#basketSummaryHtml").processTemplate(data);
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }

    });
}