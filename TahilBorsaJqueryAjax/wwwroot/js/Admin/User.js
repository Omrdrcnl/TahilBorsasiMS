


let currentPage = 1;
const itemsPerPage = 10;

function getAllUsers() {
    fetchData("User/AllUsers", function (response) {

        console.log("user data", response);
        const totalPages = Math.ceil(response.length / itemsPerPage);

        const startIndex = (currentPage - 1) * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;
        const currentPageData = response.slice(startIndex, endIndex);

        updateTable(currentPageData);

        uptadePagination(totalPages);
    });

}

function updateTable(response) {

    const tbody = $("#tableBody");

    console.log("baseprice", response)
    tbody.empty();


    $.each(response, function (index, t) {
        var row = $("<tr>");

        row.append($("<td>").text(`${t.firstName} ${t.lastName}`));
        row.append($("<td>").text(t.username));
        var maskedPassword = '*'.repeat(t.password.length); // Şifre uzunluğu kadar * karakteri oluşturur
        row.append($("<td>").text(maskedPassword));
        row.append($("<td>").text(t.tblRolId));
        row.append($("<td>").text(t.tblRol.name));
        row.append($("<td>").html(`<button type="button" data-user-id="${t.id}"
                            data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-danger">Sil</button>

                                                                                            `));
        row.append($("<td>").html(`<button data-bs-toggle="modal" data-bs-target="#rolModal" onClick="CallUser(
                                                                                                  '${t.id}',
                                                                                                  '${t.firstName}',
                                                                                                  '${t.lastName}',
                                                                                                  '${t.username}',
                                                                                                  '${t.password}',
                                                                                                  '${t.tblRolId}'
                                                                                            )" class="btn btn-success">Güncelle</button>
                                                                                            `));
        tbody.append(row);
    });

}
// TODO sayfada kaç veri olsun seçeneğini değişkene bağlayıp sayda seçtir

function uptadePagination(totalPages) {
    const paginationContainer = $("#paginationContainer");
    paginationContainer.empty();

    //sayfalama bağlantıları

    for (let i = 1; i <= totalPages; i++) {
        const link = $("<button>").text(i).addClass("page-link");
        if (i === currentPage) {
            link.addClass("active");
        } else {
            link.click(() => {
                currentPage = i;
                GetAllUsers();
            });
        }
        paginationContainer.append($("<li>").addClass("page-item").append(link));
    }
}


let selectedUserId = 0;

function NewUser() {

    $("#FirstName").val("");
    $('#LastName').val("");
    $('#Username').val("");
    $('#Password').val("");
    $('#Rol').val("");

    $("#rolModal").modal("show");
}



function AddUser() {
    var p = {
        Id: selectedUserId,
        FirstName: $('#FirstName').val(),
        LastName: $("#LastName").val(),
        Username: $("#Username").val(),
        Password: $("#Password").val(),
        RolId: $("#Rol").val(),
    };

    postData("User/AddUser", p, (data) => {
        GetAllUsers();

    });


    $("#rolModal").modal("hide");

    $("#successAlert").fadeIn();

    $(".modal-backdrop").remove();

    setTimeout(function () {
        $("#successAlert").fadeOut();
    }, 3000);
    setTimeout(function () {
        location.reload();
    }, 3500);

}

function CallUser(id, firstName, lastName, username, password, rolId) {

    selectedUserId = id;
    $('#Rol').val(rolId);

    $("#UserId").val(selectedUserId);
    $("#FirstName").val(firstName);
    $("#LastName").val(lastName);
    $("#Username").val(username);
    $("#Password").val(password);

}

//Model açılınca ürünler gelsin
$("#rolModal").on("show.bs.modal", function () {

    fetchData("Rol/AllRoles", function (response) {

        console.log("rol veri :", response)
        var rolId = $("#Rol");

        $.each(response, function (index, r) {
            rolId.append($("<option>").val(r.id).text(r.name));
        });
    });
});


//Delete İşlemi
$("#exampleModal").on("show.bs.modal", function (event) {
    var button = $(event.relatedTarget); // Tetikleyici düğme
    var userId = button.data("user-id"); // data-tradesman-id değeri

    // Sil butonuna tıklama işlemini ayarla
    var deleteButton = $("#exampleModal").find(".btn-danger"); // Sil butonunu seç
    deleteButton.off("click").on("click", function () {
        DeleteUser(userId);
    });
});

function DeleteUser(userId) {

    deleteData(`User/${userId}`, (model) => {

        $("#exampleModal").modal("hide");
        $(".modal-backdrop").remove();
        getAllUsers();
        setTimeout(function () {
            $("#deleteAlert").fadeOut();
        }, 3000);
        setTimeout(function () {
            location.reload();
        }, 3500);
    });

}


$(document).ready(function () {
    getAllUsers();
})
