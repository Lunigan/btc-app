// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


if (window.chartLabels && window.chartData) {
    const ctx = document.getElementById("btcCzkChart").getContext("2d");
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

$('#select-all').on('change', function () {
    const checked = $(this).is(':checked');
    $('.row-check').prop('checked', checked);
});

$('#delete-selected').on('click', function () {
    const selectedIds = $('.row-check:checked')
        .map(function () {
            return $(this).data('id');
        })
        .get(); // convert to array

    if (selectedIds.length < 1) {
        ShowResultModal("Nevybrali jste žádné záznamy.");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/api/data/delete-many",
        contentType: "application/json",
        data: JSON.stringify(selectedIds),
        success: function () {
            location.reload(); // Refresh the table, or use JS to remove rows dynamically
        },
        error: function () {
            ShowResultModal("Chyba při mazání záznamů.");
        }
    });
});


$('.btc-record-save').on('click', function () {
    $note = $(this).parent().parent().find('input');
    $noteVal = '';

    if ($note.length > 0 && !$note.val() && !$note[0].checkValidity()) {
        $note[0].reportValidity();
        return;
    }
    if ($note && $note.val()) $noteVal = $note.val();

    let body = {
        timestamp: convertToISO($(this).data('timestamp')),
        instrument: $(this).data('instrument'),
        btcEurPrice: $(this).data('btceur').toString().replace(",", "."),
        eur2Czk: $(this).data('eurczk').toString().replace(",", "."),
        note: $noteVal
    }

    if ($(this).data('id')) body.id = $(this).data('id');

    $.ajax({
        type: "POST",
        url: '/api/data/save',
        data: JSON.stringify(body),
        contentType: "application/json",
        success: function (data, status) {
            ShowResultModal("Snapshot BTC kurzu byl úspěšně uložen.");
        }
    });
})

$(document).ready(function () {
    $('#btc-rates-snapshots').DataTable({
        select: true,
        columnDefs: [
            { targets: [2, 5], orderable: false } // Disable sorting for "Note" and "Action" columns
        ]
    });

    if ($('#btc-rates')) {
        setInterval(function () {
            console.log("check for updates");
            let last = getLatestTimeStamp(); // Get timestamp from table/chart

            $.post('/api/data/latest/check', { lastTimestamp: last }, function (data) {
                console.warn(data);
                if (data) {
                    console.log("new content!!!");
                    location.reload(); // Or trigger a table/chart refresh
                }
            });
        }, 30000); // Every 300 seconds
    }
});

function getLatestTimeStamp() {
    return $('#btc-rates .btc-record-timestamp').last().html();
}

function convertToISO(dateString) {
    const [day, month, yearAndTime] = dateString.split('.');
    const [year, time] = yearAndTime.split(' ');
    return `${year}-${month}-${day}T${time}`;
}

// fuknce zobrazi modalní okno (parametr msg bude zobrazen v jako obsah okna)
// function show modal window (content of windows will be msg parametr)
function ShowResultModal(msg, callback, ishtml) {
    var window = $('#resultModal');

    if (ishtml) {
        window.find('.msg-label').html(msg);
    } else {
        window.find('.msg-label').text(msg);
    }

    if (callback) {
        window.modal('show').on('hidden.bs.modal', callback);
    } else {
        window.modal('show');
    }
}