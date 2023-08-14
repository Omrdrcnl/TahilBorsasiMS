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
