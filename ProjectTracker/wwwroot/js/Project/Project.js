﻿$(document).ready(function () {
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

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let dataToSend = $('#projectForm :input').serializeArray();

        $.post('/Project/SubmitProject', dataToSend, function () {
            loadTablePartial();
            $('#projectPartial').empty();
        });
    });
}
