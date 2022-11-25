$(document).ready(() => {
<<<<<<< HEAD
=======
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

>>>>>>> 176c302 (refactor:update modal with shop controller)
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