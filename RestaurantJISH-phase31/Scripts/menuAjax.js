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

//Add animation to ordering item
$(document).on("click", ".product a", function () {
    var cart = $('.b-cart');
    var imgtodrag = $(this).parent('.thumbnail').find("img").eq(0);

    if (imgtodrag) {      
        var imgclone = imgtodrag.clone()
            .offset({
                top: imgtodrag.offset().top,
                left: imgtodrag.offset().left
            })
            .css({
                'opacity': '0.5',
                'position': 'absolute',
                'height': '100px',
                'width': '200px',
                'z-index':200000000000,
            })
            .appendTo($('body'))
            .animate({
                'top': cart.offset().top + 10,
                'left': cart.offset().left + 10,
                'width': 75,
                'height': 45
            }, 1000, 'easeInOutExpo');

       

        imgclone.animate({
            'width': 0,
            'height': 0
        }, function () {
            $(this).detach()
        });
    }
});
 
  





   