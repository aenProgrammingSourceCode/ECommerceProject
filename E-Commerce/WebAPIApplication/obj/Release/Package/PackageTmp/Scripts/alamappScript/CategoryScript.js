/*
$(document).ready(function () {
    //GetAllCategory
    GetAllData("categories", "categoryTemp", 'Category/GetAllCategories');

    /*
    // CategoryId selection from url
    var paths = window.location.pathname;
    var pt = paths.length;
    var categoryId = paths.substring(14, pt);
    GetDataById('products', 'productsTemp', 'Product/GetProductsByAjax?id=1', categoryId);
   
});

*/ 

/* Statrt edit category details */
function getCategoryDetails(Id) {
    $.ajax({
        url: '/api/Category/GetCategory?id='+ Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            $("#categoryUpdateHtml").setTemplate($("#categoryUpdateTemp").html());
            $("#categoryUpdateHtml").processTemplate(data);
        },
        error: function (er) {
            var errorSycronim = JSON.stringify(er);
            alert("eoorr" + errorSycronim);
        }
    });
}
/* End edit category details */


function showCategoryForm()
{
    $("#hideCatregoryForm").show();
    $("#showFormCategory").hide();
}
function hideCategoryForm() {
    $("#hideCatregoryForm").hide();
    $("#showCatregoryForm").show();
}

  
// Category method
function createCategory() {
    var categoryName = $("#txtCategoryName").val();
    var description = $("#txtDescription").val();
   
    if (categoryName != "" && description != "") {
        categoryAjax(categoryName, description);
        
    }
}
function categoryAjax(name, description) {
    var jsonData =
     ({
         Name: name,
         Description: description
     });

    $.ajax({
        url: '/api/Category/CreateCategory',
        type: 'POST',
        cache: false,
        dataType: 'json',
        data: JSON.stringify(jsonData),
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
          
            submitNotification();
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }
    });
}
 

function GetAllCategory() {
    showLoader('lg-Loader')
    var Criteria = $("#txtSearchCriteria").val();
    $.ajax({
        url:'/api/Category/GetAllCategories?id='+Criteria,
        type: 'GET',
        cache: false,
        async: true,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            var myData = { categories: data };
            // Render data jtemplate
            $("#categoriesHtml").setTemplate($("#categoriesTemp").html());
            $("#categoriesHtml").processTemplate(myData);
            hideLoader('lg-Loader');
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }

    });
}
function GetDataById() {
    var jsonData =
        {
            id: 1
        };

    showLoader("lg-Loader");
    $.ajax({
        url: "/api/Category/GetCategory?id=1",
        type: 'GET',
        cache: false,
        async: true,
        data: jsonData,
        dataType: 'json',
        contentType: 'application/json;charset-utf-8',
        success: function (data) {
            $("#categoryHtml").setTemplate($("#categoryTemp").html());
            $("#categoryHtml").processTemplate(data);
        },
        error: function (r) {
            var jsonError = JSON.stringify(r);
            alert("error" + jsonError);
        }

    });
}

// --------------------Utility---------------//
// Submit success notification
function submitNotification() {
    $("#msg").fadeIn("slow");
    $("#msg").fadeOut(3000);
}
// Render data jtemplate
function renderData(idOfHtml, idOfTemp, data) {
    $("#" + idOfHtml).setTemplate($("#" + idOfTemp).html());
    $("#" + idOfHtml).processTemplate(data);
    hideLoader("lg-Loader");
}
//loading progress
function showLoader(idShowLoader) {
    $("#" + idShowLoader).show();
}
function hideLoader(idHideLoader) {
    $("#" + idHideLoader).hide();
}
// Category validation
function CategoryValidation() {
    
    $("#categoryForm").validate({
        debug: false,
        rules: {
            name: "required",
            description: "required"
        },
        messages: {
            name: "Category must have name",
            description: "Category must have description"
        }
    });
}
 
 
 