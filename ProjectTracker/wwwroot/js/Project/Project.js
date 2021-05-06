$(document).ready(function () {
    loadTaskTablePartial();
});

function loadTaskTablePartial() {
    $('#taskTablePartial').load('LoadTaskTablePartial', function () {
        addTableEventHandlers();
    });
}

$('#addTaskBtn').on('click', function () {
    loadTaskHelper('add');
});

function addTableEventHandlers() {
    $('.editTaskBtn').on('click', function () {
        loadTaskHelper('edit');
    });

    $('.deleteTaskBtn').on('click', function () {
        loadTaskHelper('delete');
    });
}

function loadTaskHelper(mode) {
    let taskId;

    if (mode === 'edit' || mode === 'delete') {
        taskId = $(this).closest('tr').find('.taskId').val();
    }

    let dataToSend = {
        'mode': mode,
        'taskId': taskId
    };

    $('#taskPartial').load('LoadTaskPartial', dataToSend, function () {
        submitTaskEvent();
    });
}

function loadTaskPartial(mode, taskId) {
    let dataToSend = {
        'mode': mode,
        'taskId': taskId
    };

    $('#taskPartial').load('/Project/LoadTaskPartial', dataToSend, function () {
        submitTaskEvent();
    });
}

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let dataToSend = $('#projectForm :input').serializeArray();

        $.post('/Project/SubmitProject', dataToSend, function () {
            loadTablePartial();
            $('#projectPartial').empty();
        });
    });
}
