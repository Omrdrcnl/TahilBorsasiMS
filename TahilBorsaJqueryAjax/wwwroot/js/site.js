var baseUrl = "https://localhost:7234/api/";


// Veriyi çekmek için genel bir fonksiyon oluşturduk örne// fetchData("Farmer/TumCiftciler", handleSuccess);
function fetchData(action, success) {
    $.ajax({
        type: "GET",
        url: `${baseUrl}${action}`,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
            // Ajax isteği başlamadan önce yüklenme göstergesini görünür yap
            $("#loading-indicator").show();
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        complete: function () {
            // Ajax isteği tamamlandığında yüklenme göstergesini gizle
            $("#loading-indicator").hide();
        },
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
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
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