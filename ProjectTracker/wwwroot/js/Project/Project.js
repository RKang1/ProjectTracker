$(document).ready(function () {
    loadTaskTablePartial();
});

function loadTaskTablePartial() {
    $('#taskTablePartial').load('LoadTaskTablePartial', function () {
    });
}
