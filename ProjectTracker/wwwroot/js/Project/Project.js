//TODO Create a function to async reload the projectPartial div on the dashboard

$('#addProjectBtn').click(function () {
    loadProjectView('add')
});

$('.editProjectBtn').click(function () {
    let projectId = $(this).attr('projectId');
    loadProjectView('edit', projectId);
});

$('.deleteProjectBtn').click(function () {
    let projectId = $(this).attr('projectId');
    loadProjectView('delete', projectId);
});

function loadProjectView(mode, projectId) {
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
            $('#projectPartial').empty();
        });
    });
}
