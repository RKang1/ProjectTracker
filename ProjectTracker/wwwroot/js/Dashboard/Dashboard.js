$(document).ready(function () {
    loadTablePartial();
});

function loadTablePartial() {
    $('#dashboardTablePartial').load('Dashboard/LoadTablePartial', function () {
        addTableEventHandlers();
    });
}

$('#addProjectBtn').on('click', function () {
    loadProjectPartial('add')
});

function addTableEventHandlers() {
    $('.editProjectBtn').on('click', function () {
        let projectId = $(this).closest('tr').find('.projectId').val();
        loadProjectPartial('edit', projectId);
    });

    $('.deleteProjectBtn').on('click', function () {
        let projectId = $(this).closest('tr').find('.projectId').val();
        loadProjectPartial('delete', projectId);
    });
}

function loadProjectPartial(mode, projectId) {
    let dataToSend = {
        'mode': mode,
        'projectId': projectId
    };

    $('#projectPartial').load('/Dashboard/LoadProjectPartial', dataToSend, function () {
        submitProjectEvent();
    });
}

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let dataToSend = $('#projectForm :input').serializeArray();

        $.post('/Dashboard/SubmitProject', dataToSend, function () {
            loadTablePartial();
            $('#projectPartial').empty();
        });
    });
}
