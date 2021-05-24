$(document).ready(function () {
    loadTaskTablePartial();
});

function loadTaskTablePartial() {
    $('#taskTablePartial').load('LoadTaskTablePartial', function () {
        addTableEventHandlers();
    });
}

$('#addTaskBtn').on('click', function () {
    loadTaskPartial('add');
});

$('#saveProjectBtn').on('click', function () {
    //TODO Fix datatosend
    let dataToSend = $('#taskForm :input').serializeArray();

    $.post('/Project/SubmitProject', dataToSend, function () {
        //TODO Reload the project data
    });
});

$('#deleteProjectBtn').on('click', function () {
    //TODO Fix datatosend
    let dataToSend = $('#taskForm :input').serializeArray();

    $.post('/Project/SubmitProject', dataToSend, function () {
        //TODO Go back to the dashboard
    });
});

function addTableEventHandlers() {
    $('.editTaskBtn').on('click', function () {
        loadTaskPartial('edit', $(this));
    });

    $('.deleteTaskBtn').on('click', function () {
        loadTaskPartial('delete', $(this));
    });
}

function loadTaskPartial(mode, context) {
    let taskId;

    if (mode === 'edit' || mode === 'delete') {
        taskId = context.closest('tr').find('.taskId').val();
    }

    let dataToSend = {
        'mode': mode,
        'taskId': taskId
    };

    $('#taskPartial').load('LoadTaskPartial', dataToSend, function () {
        submitTaskEvent();
    });
}

function submitTaskEvent() {
    $('#submitTaskBtn').click(function () {
        let dataToSend = $('#taskForm :input').serializeArray();

        $.post('/Project/SubmitTask', dataToSend, function () {
            loadTaskTablePartial();
            $('#taskPartial').empty();
        });
    });
}
