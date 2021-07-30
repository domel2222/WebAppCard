////// index.js
////$(document).ready(function () {
////  var x = 0;
////  var s = "";

////  console.log("Hello Pluralsight!");




////  var theForm = $("#theForm");
////  theForm.hide();

////  var button = $("#buyButton");
////  button.on("click", function () {
////    console.log("Buying Item...");
////  });

////  var productInfo = $(".products-props li");
////  productInfo.on("click", function () {
////    console.log("You clicked on " + $(this).text());
////  });

////  var $loginToggle = $("#loginToggle");
////  var $popupForm = $(".popup-form");

////  $loginToggle.on("click", function () {
////    $popupForm.slideToggle(1000);
////  });
////});

$(document).ready(function () {
    console.log("Hello World");
    var theForm = $("#theForm");//document.getElementById("theForm");
    theForm.hide(); // hidden = true;

    var button = $("#button"); // document.getElementById("buyButton");
    //button.addEventListener("click", function () {
    //  alert("Buying...");
    //});
    button.on("click", function () {
        alert("Buying...");
    })

    var listItems = document.getElementsByClassName("product-info");
    listItems[0].addEventListener("click", function () {
        alert("prodList");
    });

    var popup = $("#login-block .popup-form");
    $("#login-block .toggle-item").on("click", function () {
        popup.slideToggle(250);
    });

});