$(document).ready(function () {
    //on input change invoke function that call controller that return list of cities
    $("#searchInput").on('input', function (e) {
        $.ajax({
            url: 'Home/getCiteis',
            data: { startsWith: e.currentTarget.value },
            type: 'POST',
            success: function (data) {
                $('#result').empty();
                if (data.length) {
                    $.each(data, function (index, value) {
                        $("#result").append("<label id='showMeCityDetail' class='cityName'>" + value.description + "</label>");
                    });
                }
            }
        });
    });
    // on click form list of cities go to city controller with city name and id as one (string)parm 
    $(document).on('click', '#showMeCityDetail', function (e) {
        window.location.href = "/Home/City/" + e.currentTarget.dataset.id + "_" + e.currentTarget.innerHTML;
    });
});
