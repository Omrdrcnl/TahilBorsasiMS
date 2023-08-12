var baseUrl = "https://localhost:7234/api/";


// Veriyi çekmek için genel bir fonksiyon oluşturduk örne// fetchData("Farmer/TumCiftciler", handleSuccess);
function fetchData(endpoint, successCallback) {
    $.ajax({
        url: baseUrl + endpoint,
        type: "GET",
        dataType: "json",
        contentType: "application/json; chartset=utf-8",
        success: successCallback,
         error: function(XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

//Veri post etmek için base  fonksiyon
function postData(endpoint, data, success) {
    $.ajax({
        url: baseUrl + endpoint,
        type: "POST",
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
            console.log(XMLHttpRequest + "-" + textStatus, errorThrown);
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
                success(response.data);
            }
            else {
                alert(response.message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Hata:", textStatus, errorThrown);
        }
    });
}

//İller ve ilçeler base func

function CityAndDistrict() {
    $.ajax({
        url: "https://localhost:7234/api/City/TumIller",
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {

            if (response.success) {


                console.log("veri :", response.data)
                var cityDropdown = $("#cityDropdown");

                $.each(response.data, function (index, city) {
                    cityDropdown.append($("<option>").val(city.id).text(city.name));
                });

            } else {
                alert(response.message);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Tüm iller Error:", XMLHttpRequest, textStatus, errorThrown);
        }
    });

    //Seçilen ile göre ilçeleri listeleme
    $("#cityDropdown").change(function () {
        var selectedCityId = $(this).val();
        $.ajax({
            url: "https://localhost:7234/api/District/" + selectedCityId,
            type: "GET",
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    console.log("İlçe data", response.data)
                    var districtDropdown = $("#districtDropdown");
                    districtDropdown.empty();
                    districtDropdown.append($("<option>").val("").text("İlçe Seçiniz"));
                    $.each(response.data, function (index, district) {
                        districtDropdown.append($("<option>").val(district.id).text(district.name));
                    });
                } else {
                    alert(response.message)
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("Error:", textStatus, errorThrown);
            }
        });
    });
}

$(document).ready(function () {
    //$("#loginForm").submit(function (event) {
    //    event.preventDefault(); // Formun varsayılan submit işlemini engelle

    //    var username = $("#username").val();
    //    var password = $("#password").val();

    //    $.ajax({
    //        url: "https://localhost:7234/api/Auth/Login", // Hedef URL
    //        type: "POST", // HTTP method
    //        data: {
    //            Username: username,
    //            Password: password
    //        }, // Gönderilecek veri
    //        dataType: "json", // Veri tipi
    //        contentType: "application/json; chartset=utf-8",
    //        success: function (data) {
    //            // Giriş işlemi başarılı olduğunda çalışacak fonksiyon
    //            if (data.success) {
    //                console.log("Veri gönderme başarılı");

    //                console.log("Giriş datası", data.data)
    //            } else (data.message)
    //            {
    //                console.log(this.message)
    //            }
                
    //            $("#loginMessage").html("<p>Login successful!</p>");
    //        },
    //        error: function (jqXHR, textStatus, errorThrown) {
    //            // Giriş işlemi hata verdiğinde çalışacak fonksiyon
    //            $("#loginMessage").html("<p>Login failed. Please check your credentials.</p>");
    //        }
    //    });
    //});
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