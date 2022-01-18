$(document).ready(function () {
});

function AddTopic() {
    $.ajax({
        url: '/api/sitecore/Topics/AddTopic',
        data: { Content: $("#topicContent").val() },
        type: "POST",
        success: function (data) {
            $("#topicContent").val('');
            $('#AddTopicModal').modal('hide');
            $('#getAllTopicsDiv').html(data);
        }
    });
}

