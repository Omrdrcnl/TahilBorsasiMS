

function getProduct() {

    var productList = $("#productList");

    fetchData("Product/AllProducts", function (response) {

        console.log("ürünler res", response)

        productList.empty();

        $.each(response, function (index, product) {
            var card = `
    <div class="card mb-3 col-md-6 col-sm-12">
        <img src="${product.photo}" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">${product.name}</h5>
                <p class="card-text">${product.information}</p>
            </div>
            <p class="card-text"><small class="text-muted">İşlem Numarası: ${product.id}</small></p>
            <p class="card-text"><small class="text-muted">Kat Sayı: ${product.factor}</small></p>
            <div class="btn-group m-1">
                <button type="button" data-bs-toggle="modal" data-bs-target="#exampleModal-${product.id}" class="btn btn-danger btn-round">Sil</button>
                <button onClick="EditProduct(
                                                                           '${product.id}',
                                                                           '${product.name}',
                                                                           '${product.information}',
                                                                           '${product.photo}',
                                                                           '${product.factor}'
                                                                      )" class="btn btn-outline-success btn-round">Güncelle</button>
            </div>
    </div>
    <div class="modal fade" id="exampleModal-${product.id}" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Sil</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Ürün Kaydını Silmek İstiyor musunuz ?
                </div>
                <div class="modal-footer">
                    <button type="button" onClick="" class="btn btn-secondary" data-bs-dismiss="modal">Vazgeç</button>
                    <button onClick="DeleteProduct(${product.id})" data-product-id="${product.id}" class="btn btn-outline-danger">Sil</button>
                </div>
            </div>
        </div>
    </div>
    `;
            productList.append(card);
        });
    });
}


function NewProduct() {

    $("#Name").val("");
    $("#Id").val("0");
    $('#Information').val("");
    $('#Photo').val("");
    $('#Factor').val("");

    $("#rolModal").modal("show");
}

function AddProduct() {

    if (!validateForm()) {
        return;
    }


    var p = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Information: $("#Information").val(),
        Photo: $('#Photo').val(),
        Factor: $('#Factor').val()

    };
    postData("Product/AddProduct", p, (data) => {

        $("#rolModal").modal("hide");
        getProduct();
    });

}

function DeleteProduct(id) {

    deleteData(`Product/${id}`, (model) => {

        $("#exampleModal").modal("hide");
        $(".modal-backdrop").remove();
        getProduct();
    });

}


//Edit kısmı
function EditProduct(id, name, information, photo, factor) {
    $("#rolModal").modal("show");
    console.log("Edit Kısmı product Id", id);
    $('#Information').val(information);
    $('#Id').val(id);
    $("#Name").val(name);
    $('#Photo').val(photo);
    $('#Factor').val(factor);

}

function validateForm() {
    var name = $("#Name").val();
    var information = $("#Information").val();
    var photo = $("#Photo").val();
    var factor = $("#Factor").val();

    if (name === "" || information === "" || photo === "" || factor === "") {
        alert("Lütfen tüm alanları doldurun.");
        return false;
    }

    return true;
}



$(document).ready(function () {
    getProduct();
});

