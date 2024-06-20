
function ProductTitleDetailsBy(Id) {
    $.ajax({
        url: '/api/Product/GetProductDetails?id=' + Id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            // var cData = JSON.stringify(data);
            //alert(cData);
            $("#productDetailsHtml").setTemplate($("#productDetailsTemp").html());
            $("#productDetailsHtml").processTemplate(data);

        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}

function ProductTitleDeleteBy() {

    var Id = [];
    var arr = [7135, 7136];

    $.each(arr, function (key, value) {
        Id.push(value);
        alert(Id);
    });


    $.ajax({
        url: '/api/Product/DeleteproductTitle?ProductTitleId=' + Id,
        type: 'POST',
        cache: false,
        dataType: 'json',
        //data: ProductTitleId,
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            // var cData = JSON.stringify(data);
            //alert(cData);
            //$("#productDetailsHtml").setTemplate($("#productDetailsTemp").html());
            //$("#productDetailsHtml").processTemplate(data);
            alert("Delete success");
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}

function ProductTitleDetailsForEditingBy(Id) {
    $.ajax({
        url: '/api/Product/GetProductDetails?id=' + Id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            // var cData = JSON.stringify(data);
            //alert(cData);
            $("#productEditHtml").setTemplate($("#productTitlDetailsForEditingTemp").html());
            $("#productEditHtml").processTemplate(data);

        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function resetProductTitleForm() {
    $("#txtTitleName").val('');
    $("#txtPrice").val('');
    $("#ddlCategory").val();
    $("#ddlManufacture").val('0');
    $("#ddlBrand").val().val(0);
    $("#ddlProductModel").val(0);
    $("#txtDescription").val('');
}
function ModifyProductTitleBy(Id) {
    var name = $("#txtEditTitleName").val();
    var price = $("#txtEditPrice").val();
    var descriptions = $("#txtEditDescription").val();

    var categories = $("#ddlEditCategory").val();
    var manufactures = $("#ddlEditManufacture").val();
    var brands = $("#ddlEditBrand").val();
    var productModels = $("#ddlEditProductModel").val();


    ProductTitleEditingAjax(
        name,
        price,
        categories,
        manufactures,
        brands,
        productModels,
        descriptions,
        Id)
}
function ProductTitleEditingAjax(name, price, categories, manufactures, brands, productModels, descriptions, Id) {
    var jsonData =
     ({
         Name: name,
         Price: price,
         CategoryId: categories,
         ManufactureId: manufactures,
         BrandId: brands,
         ProductModelId: productModels,
         Description: descriptions
     });


    $.ajax({
        url: '/api/Product/ModifyProductTitles?productTitleId=' + Id,
        type: 'POST',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            ProductByCategoryAjax(categories)
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}

function createProductTitleWithAssign() {
    var name = $("#txtTitleName").val();
    var price = $("#txtPrice").val();
    var categories = $("#ddlCategory").val();
    var manufactures = $("#ddlManufacture").val();
    var brands = $("#ddlBrand").val();
    var productModels = $("#ddlProductModel").val();
    var descriptions = $("#txtDescription").val();

    ProductTitleWithAssignAjax(name, price, categories, manufactures, brands, productModels, descriptions)
}
function ProductTitleWithAssignAjax(name, price, categories, manufactures, brands, productModels, descriptions) {
    var jsonData =
     ({
         Name: name,
         Price: price,
         CategoryId: categories,
         ManufactureId: manufactures,
         BrandId: brands,
         ProductModelId: productModels,
         Description: descriptions
     });


    $.ajax({
        url: '/api/Product/CreateProductTitleWithAssign',
        type: 'POST',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            ProductByCategoryAjax(categories)
            resetProductTitleForm();
            hideFormElement("frmCreateProduct");
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function createProductTitle() {
    var name = $("#txtTitleName").val();
    var price = $("#txtPrice").val();
    var categories = $("#ddlCategory").val();
    var manufactures = $("#ddlManufacture").val();
    var brands = $("#ddlBrand").val();
    var productModels = $("#ddlProductModel").val();
    var descriptions = $("#txtDescription").val();
    ProductTitleAjax(name, price, categories, manufactures, brands, productModels, descriptions)
}
function ProductTitleAjax(name, price, categories, manufactures, brands, productModels, descriptions) {
    var jsonData =
     ({
         Name: name,
         Price: price,
         CategoryId: categories,
         ManufactureId: manufactures,
         BrandId: brands,
         ProductModelId: productModels,
         Description: descriptions
     });



    $.ajax({
        url: '/api/Product/CreateProductTitles',
        type: 'POST',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            ProductByCategoryAjax(categories);
            resetProductTitleForm();
            hideFormElement("frmCreateProduct");
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function ProductAjax() {
    //var jsonData =
    // ({
    //     Name: name,
    //     Price: price,
    //     CategoryId: categories,
    //     ManufactureId: manufactures,
    //     BrandId: brands,
    //     ProductModelId: productModels,
    //     Description: descriptions
    // });


    $.ajax({
        url: '/api/Product/AssignProductTitleToProduct',
        type: 'POST',
        cache: false,
        dataType: 'json',
        //data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            alert("Product title assigned successfully");
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function ProductImageUpload() {
    var data = new FormData();
    var files = $("#fileUpload").get(0).files;
    // Add the uploaded image content to the form data collection
    if (files.length > 0) {
        data.append("UploadImage", files[0]);
    }
    // Make Ajax request with the contentType = false, and procesDate = false
    var ajaxRequest = $.ajax({
        type: "POST",
        url: "/api/Product/filUpload",
        contentType: false,
        processData: false,
        data: data
    });
    ajaxRequest.done(function (xhr, textStatus) {
        createProductTitle();
    });
}
function ChangePicture(Id) {
    var data = new FormData();
    var files = $("#flChangePicture").get(0).files;
    // Add the uploaded image content to the form data collection
    if (files.length > 0) {
        data.append("UploadImage", files[0]);
    }
    // Make Ajax request with the contentType = false, and procesDate = false
    var ajaxRequest = $.ajax({
        type: "POST",
        url: "/api/Product/ChangePicture?ImageId=" + Id,
        contentType: false,
        processData: false,
        data: data

    });
    ajaxRequest.done(function (xhr, textStatus) {
        alert("Picture update success");
    });
}
function ChangeImageId(Id) {
    $.ajax({
        url: '/api/Product/ModifyProductImages?imageId=' + Id,
        type: 'POST',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            ProductByCategoryAjax(categories)
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function imageUploadwithAssignProduct() {
    var data = new FormData();
    var files = $("#fileUpload").get(0).files;
    // Add the uploaded image content to the form data collection
    if (files.length > 0) {
        data.append("UploadImage", files[0]);
    }
    // Make Ajax request with the contentType = false, and procesDate = false
    var ajaxRequest = $.ajax({
        type: "POST",
        url: "/api/Product/filUpload",
        contentType: false,
        processData: false,
        data: data
    });
    ajaxRequest.done(function (xhr, textStatus) {
        createProductTitleWithAssign();
        hideFormElement("frmCreateProduct");
    });
}
function ImagePreview() {
    $("#fileUpload").on('change', function () {
        //Get count of selected files
        var countFiles = $(this)[0].files.length;
        var imgPath = $(this)[0].value;
        var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
        var image_holder = $("#image-holder");
        image_holder.empty();
        if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
            if (typeof (FileReader) != "undefined") {
                //loop for each file selected for uploaded.
                for (var i = 0; i < countFiles; i++) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);
                    }
                    image_holder.show();
                    reader.readAsDataURL($(this)[0].files[i]);
                }
            } else {
                alert("This browser does not support FileReader.");
            }
        } else {
            alert("Pls select only images");
        }
    });
}
function ChangeImagePreview() {
    $("#flChangePicture").on('change', function () {
        //Get count of selected files
        var countFiles = $(this)[0].files.length;
        var imgPath = $(this)[0].value;
        var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
        var image_holder = $("#changeImage-holder");
        image_holder.empty();
        if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
            if (typeof (FileReader) != "undefined") {
                //loop for each file selected for uploaded.
                for (var i = 0; i < countFiles; i++) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);
                    }
                    image_holder.show();
                    reader.readAsDataURL($(this)[0].files[i]);
                }
            } else {
                alert("This browser does not support FileReader.");
            }
        } else {
            alert("Pls select only images");
        }
    });
}
function ProductTitleByCategoryAjax(Id) {
    $.ajax({
        url: '/api/Product/GetProductTitleByCategory?CategoryId=' + Id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            $("#productsHtml").setTemplate($("#productsTemp").html());
            $("#productsHtml").processTemplate(data);

        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function ProductByCategoryAjax(Id) {
    $.ajax({
        url: '/api/Product/GetProductByCategory?CategoryId=' + Id,
        type: 'GET',
        cache: false,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            $("#productsHtml").setTemplate($("#productsTemp").html());
            $("#productsHtml").processTemplate(data);
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
function GetProductByItem() {
    var paths = window.location.pathname;
    var pt = paths.length;
    var Id = paths.substring(20, pt);

    var Productmodels = $("#ddlProductModelCriteria").val();
    var Manufactures = $("#ddlManufactureCriteria").val();
    var Brands = $("#ddlBrandCriteria").val();
    var Categorys = Id;
    ProductByItemAjax(Productmodels, Manufactures, Brands, Categorys)
}
function ProductByItemAjax(productModel, manufacture, brand, category) {
    var jsonData =
        ({
            ProductModelId: productModel,
            ManufactureId: manufacture,
            BrandId: brand,
            CategoryId: category
        });
    $.ajax({
        url: '/api/Product/GetProductByProductItems',
        type: 'POST',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            $("#productsHtml").setTemplate($("#productsTemp").html());
            $("#productsHtml").processTemplate(data);
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}