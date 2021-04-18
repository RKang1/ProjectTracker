document.querySelector('#addProjectBtn').addEventListener('click', (e) => {
    $('#projectPartial').load('/Project/NewProject', function () {
        addFormSubmitEvent()
    });
});

function addFormSubmitEvent() {
    $('#createProjectBtn').click(function () {

        var dataToSend = $('#newProjectForm :input').serialize();

        $.post('/Project/AddProject', dataToSend, function () {
            $('#projectPartial').empty();
        });
    });
}
