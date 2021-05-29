$(document).ready(function () {
    loadTablePartial();
});

function loadTablePartial() {
    $('#dashboardTablePartial').load('Dashboard/LoadTablePartial', function () {
        addTableEventHandlers();
    });
}

$('#addProjectBtn').on('click', function () {
    loadProjectPartial('add');
});

function addTableEventHandlers() {
    $('.editProjectBtn').on('click', function () {
        loadProjectPartial('edit', $(this));
    });

    $('.deleteProjectBtn').on('click', function () {
        loadProjectPartial('delete', $(this));
    });
}

function loadProjectPartial(mode, context) {
    let projectId;

    if (mode === 'edit' || mode === 'delete') {
        projectId = context.closest('tr').find('.projectId').val();
    }

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
