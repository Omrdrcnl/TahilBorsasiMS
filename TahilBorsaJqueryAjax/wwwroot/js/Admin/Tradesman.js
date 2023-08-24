


let SelectedAddressId = 0;


let currentPage = 1;
const itemsPerPage = 10;

var searchBox = $("#searchBox");
var searchButton = $("#searchButton");

function getTradesman() {
    fetchData("Tradesman/Tradesmans", function (response) {
        const totalPages = Math.ceil(response.length / itemsPerPage);

        const startIndex = (currentPage - 1) * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;
        const currentPageData = response.slice(startIndex, endIndex);

        updateTable(currentPageData);

        uptadePagination(totalPages);

    });
}

function updateTable(data) {
    const tbody = $("#tableBody");
    tbody.empty();

    $.each(data, function (index, t) {

        var row = $("<tr>");
        row.append($("<td>").text(t.id));
        row.append($("<td>").text(t.firstName));
        row.append($("<td>").text(t.lastName));
        row.append($("<td>").text(t.identityNo));
        row.append($("<td>").text(t.contact));
        //row.append($("<td>").text(t.tblAddress.tblCityName));
        row.append($("<td>").text(t.tblAddress.tblDistrict.name));
        row.append($("<td>").text(t.tblAddress.neighborhoodName));
        row.append($("<td>").text(t.tblAddress.fullAddress));
        row.append($("<td>").html(`<button type="button" data-tradesman-id="${t.id}"
                                    data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-danger">Sil</button>`));
        row.append($("<td>").html(`<button onClick="EditTradesman(
                                                    '${t.id}',
                                                    '${t.identityNo}',
                                                    '${t.birthDate}',
                                                    '${t.contact}',
                                                    '${t.firstName}',
                                                    '${t.lastName}',
                                                    '${t.tblAddress.fullAddress}',
                                                    '${t.tblAddress.tblCityId}',
                                                    '${t.tblAddress.tblDistrictId}',
                                                    '${t.tblAddress.neighborhoodName}',
                                                    '${t.tblAddressId}'
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
                getTradesman();
            });
        }
        paginationContainer.append($("<li>").addClass("page-item").append(link));
    }
}

function performSearch() {
    fetchData("Tradesman/Tradesmans", function (response) {
        const searchTerm = searchBox.val().toLowerCase();
        const filteredData = response.filter(function (t) {
            return (
                t.firstName.toLowerCase().includes(searchTerm) ||
                t.lastName.toLowerCase().includes(searchTerm)
            );
        });
        const totalPages = Math.ceil(filteredData.length / itemsPerPage);

        const startIndex = (currentPage - 1) * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;
        const currentPageData = filteredData.slice(startIndex, endIndex);

        updateTable(currentPageData);
        updatePagination(totalPages);
    });
}
//entera basınca ara
searchBox.keypress(function (event) {
    if (event.which === 13) {
        performSearch();
    }
})
//ara buttonuna basınca ara
searchButton.click(function () {
    performSearch();
});


function NewTradesman() {
    $('#Id').val("0");
    $('#IdentityNo').val("");
    $("#BirthDate").val("");
    $('#Contact').val("");
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#FullAddress').val("");
    $('#cityDropdown').val("");
    $('#districtDropdown').val("");
    $('#neighborhoodName').val("")
    $("#rolModal").modal("show");
}


//Delete İşlemi
$("#exampleModal").on("show.bs.modal", function (event) {
    var button = $(event.relatedTarget); // Tetikleyici düğme
    var tradesmanId = button.data("tradesman-id"); // data-tradesman-id değeri, modala atama yapmak için kullandık

    // Sil butonuna tıklama işlemini ayarladık
    var deleteButton = $("#exampleModal").find(".btn-danger");
    deleteButton.off("click").on("click", function () {
        DeleteTradesman(tradesmanId);
    });
});

function DeleteTradesman(id) {

    deleteData(`Tradesman/Delete/${id}`, (model) => {

        $("#exampleModal").modal("hide");
        $(".modal-backdrop").remove();
        getTradesman();
    });

}

//Model açılınca il ve ilçelerin listelenmesi

//İller ve ilçeler base func
$("#rolModal").on("show.bs.modal", function () {

    fetchData("City/AllCity", (response) => {

        console.log("veri :", response)
        var cityDropdown = $("#cityDropdown");

        $.each(response, function (index, city) {
            cityDropdown.append($("<option>").val(city.id).text(city.name));
        });
    });

    //Seçilen ile göre ilçeleri listeleme
    $("#cityDropdown").change(function () {

        var selectedCityId = $(this).val();
        fetchData(`District/${selectedCityId}`, (data) => {

            console.log("İlçe data", data)
            var districtDropdown = $("#districtDropdown");
            districtDropdown.empty();
            districtDropdown.append($("<option>").val("").text("İlçe Seçiniz"));

            $.each(data, function (index, district) {
                districtDropdown.append($("<option>").val(district.id).text(district.name));
            });
        });

    });
});


//Edit kısmı
function EditTradesman(id, identityNo, birthDate, contact, firstName, lastName,
    fullAddress, tblCityId, tblDistrictId, neighborhoodName, tblAddressId) {

   
    SelectedAddressId = tblAddressId;
    const formattedDate = moment(birthDate).format('YYYY-MM-DD');

    console.log("selectekıd", SelectedAddressId);
    $('#IdentityNo').val(identityNo);
    $('#Id').val(id);
    $("#BirthDate").val(formattedDate);
    $('#Contact').val(contact);
    $('#FirstName').val(firstName);
    $('#LastName').val(lastName);
    $('#FullAddress').val(fullAddress);
    $('#cityDropdown').val(tblCityId);
    $('#districtDropdown').val(tblDistrictId);
    $('#neighborhoodName').val(neighborhoodName);
    $("#rolModal").modal("show");
}


$(document).ready(function () {
    getTradesman();


})


