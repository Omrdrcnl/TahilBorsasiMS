
function getBulletin(selectedDate) {



    fetchData(`Product/Bulletin?selectedDate=${selectedDate}`, function (response) {

        console.log("bulten", response);

        var col = $("#col");
        col.empty();

        $.each(response, function (index, p) {
            const s = moment(p.saleDate); // Moment objesi oluştur
            const formattedDate = s.format("DD.MM.YYYY")
            const row = ` <div class="col">
                            <div class="card" style="width: 18rem;">
                                        <img src="${p.photo}" height="200" class="card-img-top" alt="...">
                                <div class="card-body">
                                        <h5 class="card-title">${p.productName}</h5>
                                </div>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item"></li>
                                            <li class="list-group-item">Toplam Miktar:${p.totalQuantity} kg</li>
                                                <li class="list-group-item">En Düşük Fiyat:₺ ${p.totalBasePrice}</li>
                                                <li class="list-group-item">En Yüksek Fiyat:₺ ${p.totalActualPrice}</li>
                                </ul>
                                <div class="card-body">
                                    <p>
                                                        Tarih:  <b>${formattedDate}</b>
                                    </p>
                                </div>
                            </div>
                        </div>`

            col.append(row);
        })

    })
}


$(document).ready(function () {

    let k = Date.now();
    const s = moment(k); // Moment objesi oluştur
    const formDate = s.format("MM.DD.YYYY")


    getBulletin(formDate);

    $("#getBulletinButton").click(function () {
        var selectedDate = $('#selectedDate').val();

        function formatDate(inputDate) {
            var parts = inputDate.split("-");
            if (parts.length !== 3) {
                return "Geçersiz tarih formatı";
            }
            return parts[1] + "." + parts[2] + "." + parts[0];
        }
        var formattedDate = formatDate(selectedDate)

        getBulletin(formattedDate);
    });

})
