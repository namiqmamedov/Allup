
$(document).ready(() => {

    $(".addtobasket").click(function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {
                $(".header-cart").html(data);
            })
    })

    $(document).on('click', ".single-cart-item", function () {
        $(this).parent().remove();
        updateTotal();
    });


    function updateTotal() {
        var cartContent = document.getElementsByClassName("single-cart-item")[0]
        var basketBoxes = single - cart - item.getElementsByClassName("cart-item-thumb");
        var total = 0;
        for (var i = 0; i < basketBoxes.length; i++) {
            var basketBox = basketBoxes[i];
            var priceElement = basketBox.getElementsByClassName("product-price")[0];
            var quantityElement = basketBox.getElementsByClassName("product-quantity")[0];
            var price = parseFloat(priceElement.innerText.replace("$", ""));
            var quantity = quantityElement.value;
            total = total + price * quantity;

            document.getElementsByClassName("value")[0].innerHTML = "$" + total;
        }
    }




    $(".modalBtn").click(function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {
                $(".modal .modal-dialog .modal-content .modal-body").html(data);
                $("modal").show();

                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })
    })

    $(".srcBtn").click(() => {
        let srcInput = $(".srcInput").val();
        let srcCategory = $(".srcCategory option:selected").val();

        if (srcInput.length >= 0) {
            fetch("/shop/search/" + srcCategory + '?search=' + srcInput)
                .then(response => {
                    return response.text();
                })
                .then(data => {
                    $("#srcList").html(data);
                })

            // Old Partial
            //fetch("/shop/search/" + srcCategory + '?search=' + srcInput)
            //    .then(response => {
            //        return response.json();
            //    }).then(data => {
            //        /* console.log(data);*/

            //        let liItems = '';

            //        for (var i = 0; i < data.length; i++) {
            //            let liItem = `<li>
            //                                <img width="100" src="/assets/images/product/${data[i].image}" alt="Alternate Text" />
            //                                <a href="#">${data[i].title}</a>
            //                            </li>`

            //            liItems += liItem;
            //        }

            //        /*console.log(liItems)*/
            //        $("#srcList").html(liItems);
            //    })
        }
    })


    $(".srcInput").keyup(function () {

        let inputVal = $(this).val();

        console.log(inputVal.length);
        if (inputVal.length <= 0) {
            $("#srcList").html('');
        }
    })


})





//function ready() {

//    // Remove Cart
//    let removeCartButtons = document.querySelectorAll(".fa-times");
//    console.log(removeCartButtons);
//    removeCartButtons.forEach(btn => {
//        btn.addEventListener("click", handle_removeCartItem);
//    });
//}

//ready();

//function handle_removeCartItem() {
//    this.parentElement.remove();
//}



function deleteItem(id) {
    var ipt = $("[name=removefromcart][value=" + id.toString() + "]");
    ipt.attr('checked', true);
}