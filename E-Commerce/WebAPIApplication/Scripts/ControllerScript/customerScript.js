

function CreateCustomerForm() {
    var name = $("#txtCustomerName").val();
    //var contactName = $("#txtPrice").val();
    //var phoneNo = $("#ddlCategory").val();
    //var address = $("#ddlManufacture").val();
    //var relation = $("#ddlBrand").val();

    // Customer creating method
    CreateCustomer(name);

}

//function CreateCustomer(name, contactName, phoneNo, address, relation) 
function CreateCustomer(name) {

    var JsonData = {
         Name:name
    };

    
    $.ajax({
        url: '/api/Customer/CreateCustomer',
        type: 'GET',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(JsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {

            $("#btnCustomer").hide();
            $("#txtCustomerName").hide();
            $("#customerNameHtml").show();
            $("#customerNameHtml").append(data);
            $("#frmDeliveryAddress").show().fadeIn("slow");
            $("#txtCustomerName").hide;
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}

//function GetBasketSummary() {
//    $.ajax({
//        url: '/api/Product/GetBasketSummary',
//        type: 'GET',
//        cache: false,
//        async: true,
//        dataType: 'json',
//        contentType: 'application/json;charset-utf-8',
//        success: function (data) {
//            // Render data jtemplate
//            $("#basketSummaryHtml").setTemplate($("#basketSummaryTemp").html());
//            $("#basketSummaryHtml").processTemplate(data);
//        },
//        error: function (r) {
//            var jsonError = JSON.stringify(r);
//            alert("error" + jsonError);
//        }

//    });
//}
