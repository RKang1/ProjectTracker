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
            $('#projectPartial').load('/Project/LoadNewProject', function () {
                submitProjectEvent();
            });
            break;
        case 'edit':
            $('#projectPartial').load('/Project/LoadEditProject', { 'projectId': projectId }, function () {
                submitProjectEvent();
            });
            break;
    }
}

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let mode = $('#submitProjectBtn').attr("mode");
        let dataToSend = $('#projectForm :input').serialize();

        switch (mode) {
            case 'add':
                $.post('/Project/AddProject', dataToSend, function () {
                    $('#projectPartial').empty();
                });
                break;
            case 'edit':
                $.post('/Project/EditProject', dataToSend, function () {
                    $('#projectPartial').empty();
                });
                break;
        }
    });
}
