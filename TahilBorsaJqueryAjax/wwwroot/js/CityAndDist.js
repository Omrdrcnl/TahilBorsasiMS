function populateCities(data) {
    var cityDropdown = $("#cityDropdown");
    cityDropdown.empty();
    cityDropdown.append($("<option>").val("").text("İl Seçiniz"));

    $.each(data, function (index, city) {
        cityDropdown.append($("<option>").val(city.id).text(city.name));
    });
}

function populateDistricts(data) {
    var districtDropdown = $("#districtDropdown");
    districtDropdown.empty();
    districtDropdown.append($("<option>").val("").text("İlçe Seçiniz"));

    $.each(data, function (index, district) {
        districtDropdown.append($("<option>").val(district.id).text(district.name));
    });
}

//// İllerin çekildiği Ajax isteği
//$.ajax({
//    url: "https://localhost:7234/api/City/TumIller",
//    type: "GET",
//    dataType: "json",
//    contentType: "application/json; charset=utf-8",
//    success: function (response) {
//        if (response.success) {
//            populateCities(response.data);
//        } else {
//            alert(response.message);
//        }
//    },
//    error: function (XMLHttpRequest, textStatus, errorThrown) {
//        console.log("Tüm iller Error:", XMLHttpRequest, textStatus, errorThrown);
//    }
//});

//// Seçilen ile göre ilçelerin çekildiği Ajax isteği
//$("#cityDropdown").change(function () {
//    var selectedCityId = $(this).val();
//    $.ajax({
//        url: "https://localhost:7234/api/District/" + selectedCityId,
//        type: "GET",
//        dataType: "json",
//        success: function (response) {
//            if (response.success) {
//                populateDistricts(response.data);
//            } else {
//                alert(response.message);
//            }
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            console.log("Error:", textStatus, errorThrown);
//        }
//    });
//});
