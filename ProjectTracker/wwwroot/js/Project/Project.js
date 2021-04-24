//TODO Create a function to async reload the projectPartial div on the dashboard

$('#addProjectBtn').click(function () {
    loadProjectView('add')
});

$('.editProjectBtn').click(function () {
    let projectId = $(this).attr('projectId');
    loadProjectView('edit', projectId);
});

function loadProjectView(mode, projectId) {
    switch (mode) {
        case 'add':
            $('#projectPartial').load('/Dashboard/LoadNewProject', function () {
                submitProjectEvent();
            });
            break;
        case 'edit':
            $('#projectPartial').load('/Dashboard/LoadEditProject', { 'projectId': projectId }, function () {
                submitProjectEvent();
            });
            break;
    }
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
