
function AddEntryProduct() {
    var p = {
        Id: 0,
        tblProductId: $('#tblProductId').val(),
        tblFarmerId: $("#tblFarmerId").val(),
        DateTime: $('#DateTime').val(),
        Process: false

    };

}

$(document).ready(function () {


    fetchData("Product/AllProducts", function (response) {

        console.log("veri :", response)
        var tblProductIdDropdown = $("#ProductId");

        $.each(response, function (index, product) {
            tblProductIdDropdown.append($("<option>").val(product.id).text(product.name));
        });
    });
    var currentDate = new Date().toISOString().split('T')[0]; // Bugünkü tarihi alıyoruz
    $("#DateTime").val(currentDate);
})
