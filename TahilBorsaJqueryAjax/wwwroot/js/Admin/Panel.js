
//Toplam Satış, esnaf vb. yapıları tuttuk.
function getTotalAction() {

    fetchData("Sale/Total", function (response) {

        console.log("panel sale", response)

        var totalQuantity = response.totalQuantity;
        var totalAmount = response.totalAmount;
        var totalTradesman = response.totalTradesman;
        var totalSale = response.totalSale;
        var totalFarmer = response.totalFarmer;



        $("#totalSale").text(totalSale);
        $("#totalQuantity").text(totalQuantity + "Kg");
        $("#totalAmount").text("₺" + totalAmount);
        $("#totalTradesman").text(totalTradesman);
        $("#totalSale").text(totalSale);
        $("#totalFarmer").text(totalFarmer);

    });
}

//Ürüne göre grupladıgımız toplam değerleri tuttuk.
function getQuantityByProduct() {
    var products = [];
    var quantities = [];

    console.log("pie", quantities)
    const tbody = $("#row")
    fetchData("Sale/ProTotal", function (response) {

        console.log("prototal", response)

        $.each(response, function (index, t) {
            products.push(t.product);
            quantities.push(t.quantity);
            var row = `
    <div class="col-lg-3 col-md-6 col-sm-6">
        <div class="card card-stats">
            <div class="card-body ">
                <div class="row">
                    <div class="col-5 col-md-4">
                        <div class="icon-big text-center icon-warning">
                            <i class="nc-icon nc-globe text-warning"></i>
                        </div>
                    </div>
                    <div class="col-7 col-md-8">
                        <div class="numbers">
                            <p class="card-category">${t.product} Miktarı</p>
                            <p id="totalQuantity" class="card-title">${t.quantity} Kg<p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer ">
                    <hr>
                        <div class="stats">
                            <i onclick="getTotalAction()" class="fa fa-refresh"></i>
                            Güncel
                        </div>
                </div>
            </div>
        </div>

        `

            tbody.append(row);
        });

        createPieChart(products, quantities);

    });
}

//Aylara göre grupladıgımız toplam hacim miktarınını tuttuk
function getAmountChart() {

    var labels = [];
    var chartData = [];
    console.log("data", chartData)
    //asenkron işlem oldugu için callback fonksiyon kullanarak önce chart verileri dolduk sonra Createchart js 'i cagırdık
    fetchData("Sale/AmountChart", function (response) {

        console.log("amountchart", response)

        for (var key in response) {
            labels.push("Month " + key);
            chartData.push(parseInt(response[key]));
        }
        createAmountChart(chartData);

    });



}
//Fiyatları aylara ve ürünlere göre gruplayıp fiyat grafiği tasarladık
function getPriceChart() {

    fetchData("Sale/PriceChart", function (response) {

        console.log("Price", response)



        const products = [...new Set(response.map(item => item.productName))];
        const chartContainer = $("#chartContainer");

        products.forEach(product => {
            const productData = response.filter(item => item.productName === product);

            const productChartId = product.replace(/\s+/g, '_');// ürün adlarından gelen boslukları değiştir


            console.log("productDat", productData)

            const card = $('<div>', { class: 'card card-chart' });
            card.html(`
                <div class="card-header">
                    <h5 class="card-title">${product} Ürün Fiyat Grafiği</h5>
                    <p class="card-category">kg/₺</p>
                </div>
                <div class="card-body">
                    <canvas id="${productChartId}-chart" width="400" height="250"></canvas>
                </div>
                <div class="card-footer">
                    <div class="chart-legend"></div>
                    <hr />
                    <div class="card-stats">
                        <i class="fa fa-check"></i>
                    </div>
                </div>
                `);

            chartContainer.append(card);
            createLineChart(product, productData);
        });





        const datasets = products.map(product => {
            const productData = response.filter(item => item.productName === product);
            const data = Array.from({ length: 12 }, (_, monthIndex) => {
                const matchingEntry = productData.find(item => item.month === monthIndex + 1);
                return matchingEntry ? matchingEntry.actualPrice : 0;
            });
            return {
                label: product,
                data: data,
                borderColor: getRandomColor(),
                fill: false
            };
        });

        const ctx = document.getElementById('priceChart').getContext('2d');
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Agu", "Eyl", "Eki", "Kas", "Ara"],
                datasets: datasets
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });


    });


}

//fiyat grafiğine rastgele renk atama
function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

//İşlemler asenkron oldugundan callback fonksiyon kullanarak aşagıda ki  fonksiyonları kullandık
function createAmountChart(chartData) {

    chartColor = "#FFFFFF";

    ctx = document.getElementById('chartHours').getContext("2d");


    myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct"],
            datasets: [{
                borderColor: "#6bd098",
                backgroundColor: "#6bd098",
                pointRadius: 0,
                pointHoverRadius: 0,
                borderWidth: 3,
                data: chartData
            }
            ]
        },
        options: {
            legend: {
                display: false
            },

            tooltips: {
                enabled: false
            },

            scales: {
                yAxes: [{

                    ticks: {
                        fontColor: "#9f9f9f",
                        beginAtZero: false,
                        maxTicksLimit: 5,
                        //padding: 20
                    },
                    gridLines: {
                        drawBorder: false,
                        zeroLineColor: "#ccc",
                        color: 'rgba(255,255,255,0.05)'
                    }

                }],

                xAxes: [{
                    barPercentage: 1.6,
                    gridLines: {
                        drawBorder: false,
                        color: 'rgba(255,255,255,0.1)',
                        zeroLineColor: "transparent",
                        display: false,
                    },
                    ticks: {
                        padding: 20,
                        fontColor: "#9f9f9f"
                    }
                }]
            },
        }
    });
}

function createPieChart(product, quantities) {
    ctx = document.getElementById('chartEmail').getContext("2d");

    myChart2 = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: product,
            datasets: [{
                label: "Emails",
                pointRadius: 0,
                pointHoverRadius: 0,
                backgroundColor: [
                    '#e3e3e3',
                    '#4acccd',
                    '#fcc468',
                    '#ef8157',
                    '#343a40',
                    '#007bff',
                    '#28a745'
                ],
                borderWidth: 0,
                data: quantities
            }]
        },

        options: {

            legend: {
                display: false
            },

            pieceLabel: {
                render: 'percentage',
                fontColor: ['white'],
                precision: 2
            },

            tooltips: {
                enabled: false
            },

            scales: {
                yAxes: [{

                    ticks: {
                        display: false
                    },
                    gridLines: {
                        drawBorder: false,
                        zeroLineColor: "transparent",
                        color: 'rgba(255,255,255,0.05)'
                    }

                }],

                xAxes: [{
                    barPercentage: 1.6,
                    gridLines: {
                        drawBorder: false,
                        color: 'rgba(255,255,255,0.1)',
                        zeroLineColor: "transparent"
                    },
                    ticks: {
                        display: false,
                    }
                }]
            },
        }
    });
}


function createLineChart(productName, productData) {
    const data = Array.from({ length: 12 }, (_, monthIndex) => {
        const matchingEntry = productData.find(item => item.month === monthIndex + 1);
        return matchingEntry ? matchingEntry.actualPrice : 0;
    });

    const productChartId = productName.replace(/\s+/g, '_');// ürün adlarından gelen boslukları değiştir


    const canvasId = `${productChartId}-chart`;

    const ctx = $(`#${canvasId}`);
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Agu", "Eyl", "Eki", "Kas", "Ara"],
            datasets: [{
                label: productName,
                data: data,
                borderColor: getRandomColor(),
                fill: false
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function bestTradesman() {
    var bodytr = $("#tbodytr")

    fetchData("Sale/BestTradesmans", (response) => {
        console.log("best tr", response);

        $.each(response, function (index, t) {
            var tra = $("<tr>");
            tra.append($("<td>").text(index + 1));
            tra.append($("<td>").text(t.name));
            tra.append($("<td>").text(t.lastName));
            tra.append($("<td>").text(t.totalQuantity + " Kg"));

            bodytr.append(tra);
        });

    })
}

function bestFarmer() {
    var bodytr = $("#tbodytr1")

    fetchData("Sale/BestFarmers", (response) => {
        console.log("best tr", response);

        $.each(response, function (index, t) {
            var tra = $("<tr>");
            tra.append($("<td>").text(index + 1));
            tra.append($("<td>").text(t.name));
            tra.append($("<td>").text(t.lastName));
            tra.append($("<td>").text(t.totalQuantity +" Kg"));

            bodytr.append(tra);
        });

    })
}


$(document).ready(function () {

    getTotalAction();
    getQuantityByProduct();
    getAmountChart();
    getPriceChart();
    bestTradesman()
    bestFarmer();
})

