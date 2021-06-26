$(document).ready(function () {
    loadTaskTablePartial();
});

function loadTaskTablePartial() {
    let projectId = $('#Id').val();

    $('#taskTablePartial').load('LoadTaskTablePartial', { projectId: projectId }, function () {
        addTableEventHandlers();
    });
}

$('#addTaskBtn').on('click', function () {
    loadTaskPartial('add');
});

$('#saveProjectBtn').on('click', function () {
    let dataToSend = $('#projectForm :input').serializeArray();
    dataToSend.push({ name: "Mode", value: "edit" });

    $.post('/Project/SubmitProject', dataToSend, function () {
        location.reload();
    });
});

$('#deleteProjectBtn').on('click', function () {
    let dataToSend = $('#projectForm :input').serializeArray();
    dataToSend.push({ name: "Mode", value: "delete" });

    $.post('/Project/SubmitProject', dataToSend, function () {
        window.location.href = "/";
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
    let projectId = $('#Id').val();
    let taskId;

    if (mode === 'edit' || mode === 'delete') {
        taskId = context.closest('tr').find('.taskId').val();
    }

    let dataToSend = {
        'projectId': projectId,
        'mode': mode,
        'taskId': taskId
    };

    $('#taskPartial').load('LoadTaskPartial', dataToSend, function () {
        addSubmitTaskEvent();
    });
}

function addSubmitTaskEvent() {
    $('#submitTaskBtn').click(function () {
        let dataToSend = $('#taskForm :input').serializeArray();

        $.post('/Project/SubmitTask', dataToSend, function () {
            loadTaskTablePartial();
            $('#taskPartial').empty();
        });
    });
}
