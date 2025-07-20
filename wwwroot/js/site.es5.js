// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//if (document.getElementById('btcCzkChart')) {
//    console.log('Chart init');

//    const ctx = document.getElementById('btcCzkChart').getContext('2d');
//    const btcChart = new Chart(ctx, {
//        type: 'line',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'BTC/CZK',
//                data: data,
//                borderColor: 'rgba(255, 99, 132, 1)',
//                backgroundColor: 'rgba(255, 99, 132, 0.2)',
//                fill: true,
//                tension: 0.3
//            }]
//        },
//        options: {
//            responsive: true,
//            scales: {
//                y: {
//                    beginAtZero: false
//                }
//            }
//        }
//    });
//}

"use strict";

if (window.chartLabels && window.chartData) {
    var ctx = document.getElementById("btcCzkChart").getContext("2d");
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: window.chartLabels,
            datasets: [{
                label: 'BTC/CZK',
                data: window.chartData,
                borderColor: 'rgba(255, 0, 0, 1)',
                backgroundColor: 'rgba(255, 0, 0, 0.2)',
                fill: true,
                tension: 0.3
            }]
        }
    });
}

