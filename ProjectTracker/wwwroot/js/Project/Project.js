$('#addProjectBtn').click(function () {
    loadProjectView('add')
});

$('.editProjectBtn').click(function () {
    loadProjectView('edit');
});

function loadProjectView(mode) {
    switch (mode) {
        case 'add':
            $('#projectPartial').load('/Project/LoadNewProject', function () {
                submitProjectEvent();
            });
            break;
        case 'edit':
            let projectId = $(this).attr('projectId');

            $('#projectPartial').load('/Project/LoadEditProject', projectId, function () {
                submitProjectEvent();
            });
            break;
    }
}

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let mode = $('#submitProjectBtn').attr("mode");

        switch (mode) {
            case 'add':

                let dataToSend = $('#projectForm :input').serialize();

                $.post('/Project/AddProject', dataToSend, function () {
                    $('#projectPartial').empty();
                });
                break;
            case 'edit':
                break;
        }
    });
}
