$(function () {
    $(document).on('keyup', '.search input', function () {
        let searchValue = $('.search input').val().toLowerCase().trim();
        $(".name-th").filter(function () {
            $(this).parent().toggle($(this).text().toLowerCase().trim().indexOf(searchValue) > -1)
        });

    });
});