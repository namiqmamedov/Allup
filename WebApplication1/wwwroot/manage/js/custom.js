$(document).ready(function () {
    let isMain = $("#IsMain").is(":checked");
    console.log("gftvyytg");

    if (isMain) {
        $("#parentList").addClass("d-none");
        $("#mainImage").removeClass("d-none");
    }
    else {
        $("#parentList").removeClass("d-none");
        $("#mainImage").addClass("d-none");
    }

    $("#IsMain").click(function () {
        let isMain = $(this).is(":checked");
        console.log("gftvyytg");

        if (isMain) {
            $("#parentList").addClass("d-none");
            $("#mainImage").removeClass("d-none");
        }
        else {
            $("#parentList").removeClass("d-none");
            $("#mainImage").addClass("d-none");
        }
    })
})