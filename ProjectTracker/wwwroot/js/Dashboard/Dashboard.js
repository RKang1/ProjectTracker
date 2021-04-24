//TODO Create a function to async reload the project table on the dashboard
$(document).ready(function () {
    loadTablePartial();
});

$('#addProjectBtn').on('click', function () {
    loadProjectPartial('add')
});

function loadTablePartial() {
    $('#dashboardTablePartial').load('Dashboard/LoadTablePartial', function () {
        addTableEventHandlers();
    });
}

function addTableEventHandlers() {
    $('.editProjectBtn').on('click', function () {
        let projectId = $(this).attr('projectId');
        loadProjectPartial('edit', projectId);
    });

    $('.deleteProjectBtn').on('click', function () {
        let projectId = $(this).attr('projectId');
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
        let mode = $('#submitProjectBtn').attr('mode');
        let dataToSend = $('#projectForm :input').serializeArray();
        dataToSend.push({ name: 'mode', value: mode });

        $.post('/Dashboard/SubmitProject', dataToSend, function () {
            loadTablePartial();
            $('#projectPartial').empty();
        });
    });
}
