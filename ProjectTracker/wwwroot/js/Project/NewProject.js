document.querySelector('#displayNewProjectPartialBtn').addEventListener('click', (e) => {
    $('#projectPartial').load('/Project/NewProjectPartial', function () {
        addFormSubmitEvent()
    });
});

function addFormSubmitEvent() {
    $('#addProjectBtn').click(function () {

        var dataToSend = $('#newProjectForm :input').serialize();

        $.post('/Project/AddProject', dataToSend, function () {
            $('#projectPartial').empty();
        });
    });
}
