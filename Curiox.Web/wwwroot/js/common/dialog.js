$('#question-box').dialog({
    autoOpen: false,
    title: "Add Question",
    modal: true,
    resizable: false,
    width: 620,
    height: 210,
    beforeClose: function (event) {
        $('.selector_input').val('');
    },
    buttons: [
        {
            text: "Add Question",
            id: 'btnSubmitQuestion',
            class: 'btn btn-primary',
            click: function () {
                $.ajax({
                    method: "GET",
                    url: Curiox.Config.loginUrl,
                    success: function (data, status, xhr) {
                        CommonJS.showSuccessMsg('Success!');
                    },
                    error: function (err, stt, xhr) {
                        window.location.href = "/";
                    }
                });
            }
        },
        {
            text: "Cancel",
            id: 'btnCancel',
            class: 'btn',
            click: function () {
                $(this).dialog("close");
            }
        }
    ]
});