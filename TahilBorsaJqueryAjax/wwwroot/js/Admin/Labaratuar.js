

let currentPage = 1;
const itemsPerPage = 10;
let selectedEntryProductId = 0;

function getEntryProduct() {

    fetchData("Labaratuar/ReadyLab", function (response) {

        console.log("ReadyLab data", response);

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
    tbody.empty();
    $.each(response, function (index, t) {
        var row = $("<tr>");
        row.append($("<td>").text(t.entryProductId));
        row.append($("<td>").text(t.farmerId));
        row.append($("<td>").text(`${t.farmerName} ${t.farmerLastName}`));
        row.append($("<td>").text(t.name));
        row.append($("<td>").text(t.dateTime));
        row.append($("<td>").html(`<button data-bs-toggle="modal" data-bs-target="#rolModal" onClick="OpenLab(
                                                            '${t.entryProductId}',
                                                            '${t.name}'
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
                getEntryProduct();
            });
        }
        paginationContainer.append($("<li>").addClass("page-item").append(link));
    }
}




function OpenLab(entryProductId, name) {
    selectedEntryProductId = entryProductId;

    $('#EntryProductId').val(selectedEntryProductId);
    $("#ProductName").val(name);
}

function EditEntryProduct(entryProductId, farmerId, dateTime, productId) {
    $("#rolModal").modal("show");

    selectedEntryProductId = entryProductId;
    console.log("Edit Kısmı Entryproduct Id", selectedEntryProductId);

    //moment.js kütüphanesi kullanıldı

    const formattedDate = moment(dateTime).format('YYYY-MM-DD');
    console.log("cekilen veri dogum tarıhı", formattedDate)

    $('#FarmerId').val(farmerId);
    $('#EntryProductId').val(selectedEntryProductId);
    $("#ProductId").val(productId);
    $('#DateTime').val(formattedDate);

}

//Model açılınca ürünler gelsin
$("#rolModal").on("show.bs.modal", function () {

    fetchData("Product/AllProducts", function (response) {

        console.log("veri :", response)
        var tblProductIdDropdown = $("#ProductId");

        $.each(response, function (index, product) {
            tblProductIdDropdown.append($("<option>").val(product.id).text(product.name));
        });
    });
});



$(document).ready(function () {
    getEntryProduct();
})

