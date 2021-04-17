document.querySelector('#displayAddProjectPartialBtn').addEventListener('click', (e) => {
    $('#projectPartial').load('/Project/AddProjectPartial', function () {
        addFormSubmitEvent()
    });
});

function addFormSubmitEvent() {
    $('#addProjectBtn').click(function () {

        var dataToSend = $('#addProjectForm :input').serialize();

        $.post('/Project/AddProject', dataToSend, function () {
            $('#projectPartial').empty();
        });
    });
}
