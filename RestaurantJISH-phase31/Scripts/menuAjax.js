/*picture slider*/
$('.carousel').carousel();
/*modal using angularJs*/
$(document).on("click", "#open-ModalDialog", function () {
    var foodName = $(this).data('foodname');
    var foodImage = $(this).data('foodimage');
    var foodprice = $(this).data('foodprice');
    var description = $(this).data('description');
    var restaurantid = $(this).data('resturantsid');
    var imageaddress = "../../assets/" + restaurantid + "/" + foodImage;
    $(".modal-body #imageArea").attr("src",imageaddress )
    $(".modal-title").html(foodName);
    $(".modal-body #priceArea").html("Price: $" + foodprice);
    $(".modal-body #descriptionArea").html(description);
});



 
  
