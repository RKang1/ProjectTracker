$('#addProjectBtn').click(function () {
    loadProjectView('add')
});

$('.editProjectBtn').click(function () {
    loadProjectView('edit');
});

function loadProjectView(mode) {
    switch (mode) {
        case 'add':
            $('#projectPartial').load('/Project/NewProject', function () {
                submitProjectEvent()
            });
            break;
        case 'edit':
            break;
    }
}

function submitProjectEvent() {
    $('#submitProjectBtn').click(function () {
        let mode = $('#submitProjectBtn').attr("mode");

        switch (mode) {
            case 'add':
                let dataToSend = $('#newProjectForm :input').serialize();

                $.post('/Project/AddProject', dataToSend, function () {
                    $('#projectPartial').empty();
                });
                break;
            case 'edit':
                break;
        }
    });
}
