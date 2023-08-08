var BASE_API_URL = "https://localhost:7234/api/";





$(document).ready(function () {
    $("#loginForm").submit(function (event) {
        event.preventDefault(); // Formun varsayılan submit işlemini engelle

        var username = $("#username").val();
        var password = $("#password").val();

        $.ajax({
            url: "https://localhost:7234/api/Auth/Login", // Hedef URL
            type: "POST", // HTTP method
            data: {
                Username: username,
                Password: password
            }, // Gönderilecek veri
            dataType: "json", // Veri tipi
            contentType: "application/json; chartset=utf-8",
            success: function (data) {
                // Giriş işlemi başarılı olduğunda çalışacak fonksiyon
                if (data.success) {
                    console.log("Veri gönderme başarılı");

                    console.log("Giriş datası", data.data)
                } else (data.message)
                {
                    console.log(this.message)
                }
                
                $("#loginMessage").html("<p>Login successful!</p>");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Giriş işlemi hata verdiğinde çalışacak fonksiyon
                $("#loginMessage").html("<p>Login failed. Please check your credentials.</p>");
            }
        });
    });
});