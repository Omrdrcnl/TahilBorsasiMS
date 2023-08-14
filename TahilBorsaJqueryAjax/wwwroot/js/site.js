var baseUrl = "https://localhost:7234/api/";


// Veriyi çekmek için genel bir fonksiyon oluşturduk örne// fetchData("Farmer/TumCiftciler", handleSuccess);
function fetchData(action, success) {
    $.ajax({
        type: "GET",
        url: `${baseUrl}${action}`,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {
                success(response.data)
            } else {
                console.log("Data işlenirken hata var");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });


}

//Veri post etmek için base  fonksiyon
function postData(endpoint, data, success) {
    $.ajax({
        url: baseUrl + endpoint,
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function (response) {
            if (response.success) {
                success(response.data);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Post hatası", XMLHttpRequest + "-" + textStatus, errorThrown);
        }
    });
}

//Veri silmek için
function deleteData(endpoint, success) {
    $.ajax({
        url: baseUrl + endpoint,
        type: "DELETE",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {
                success(response);
                console.log("Silme İşlemi başarılı", response)
            }
            else {
                alert(response.message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Silme Hata:", textStatus, errorThrown);
        }
    });
}


//İller ve ilçeler base func

//function CityAndDistrict() {
//    $("#rolModal").on("show.bs.modal", function () {

//        fetchData("City/TumIller", (response) => {

//            console.log("veri :", response)
//            var cityDropdown = $("#cityDropdown");

//            $.each(response, function (index, city) {
//                cityDropdown.append($("<option>").val(city.id).text(city.name));
//            });
//        });

//        //Seçilen ile göre ilçeleri listeleme
//        $("#cityDropdown").change(function () {

//            var selectedCityId = $(this).val();
//            fetchData(`District/${selectedCityId}`, (data) => {

//                console.log("İlçe data", data)
//                var districtDropdown = $("#districtDropdown");
//                districtDropdown.empty();
//                districtDropdown.append($("<option>").val("").text("İlçe Seçiniz"));

//                $.each(data, function (index, district) {
//                    districtDropdown.append($("<option>").val(district.id).text(district.name));
//                });
//            });

//        });
//    });
//}



$(document).ready(function () {



});

//Loading Componenet fonksiyonları
function showLoading() {
    $('#loadingModal').modal('show');
}

function hideLoading() {
    $('#loadingModal').modal('hide');
}

$(document).ajaxStart(function () {
    showLoading();
});

$(document).ajaxStop(function () {
    hideLoading();
});