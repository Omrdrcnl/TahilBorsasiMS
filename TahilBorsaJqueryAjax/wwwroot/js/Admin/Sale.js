
let currentPage = 1;
const itemsPerPage = 10;
function getReadySale() {
    fetchData("Sale/ReadySales", function (response) {

        console.log("ReadySale data", response);
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
        row.append($("<td>").text(t.entryId));
        row.append($("<td>").text(t.farmerId));
        row.append($("<td>").text(`${t.farmerFirstName} ${t.farmerLastName}`));
        row.append($("<td>").text(t.farmerIdentityNo));
        row.append($("<td>").text(t.productName));
        row.append($("<td>").text("₺ " + t.basePrice));
        row.append($("<td>").text(t.nutritionalValue));
        row.append($("<td>").html(`<button data-bs-toggle="modal" data-bs-target="#rolModal" onClick="EnterSale(

                                                                                         '${t.entryId}',
                                                                                         '${t.productName}',
                                                                                         '${t.nutritionalValue}',
                                                                                             '${t.saleId}',
                                                                                             '${t.labId}',
                                                                                             '${t.basePrice}'
                                                                                    )" class="btn btn-success">Değer Gir</button>
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
                getReadySale();
            });
        }
        paginationContainer.append($("<li>").addClass("page-item").append(link));
    }
}

let selectedSaleId = 0;
let selectedLabId = 0;
let selectedEntryId = 0;

function AddSale() {
    var p = {
        Id: selectedSaleId,
        EntryId: selectedEntryId,
        LabDataId: selectedLabId,
        BasePrice: $('#BasePrice').val(),
        ActualPrice: $("#ActualPrice").val(),
        Quantity: $("#Quantity").val(),
        TradesmanId: $("#TradesmanId").val(),
        Date: $("#Date").val(),
        Process: true
    };

}

function EnterSale(entryId, ProductName, nutritionalValue, saleId, labId, basePrice) {

    selectedEntryId = entryId;

    $("#ProductName").val(ProductName);
    $("#NutritionalValue").val(nutritionalValue);
    $('#EntryId').val(selectedEntryId);
    $('#SaleId').val(saleId);
    $('#LabId').val(labId);
    $('#BasePrice').val(basePrice);
    selectedSaleId = saleId;
    selectedLabId = labId;
}






$(document).ready(function () {
    getReadySale();

    var currentDate = new Date().toISOString().split('T')[0]; // Bugünkü tarihi alıyoruz
    $("#Date").val(currentDate); // Input alanına değeri atıyoruz
})


