$(document).ready(function () {
    $(document).on('click', '#sbm', function() {

        $.ajax({
            method: "POST",
            url: "/Security/Ajax",
            data: { "login": document.getElementById('login').value },
            dataType: "json",

            success: function (data) {
                let serialize = $.parseJSON(data);

                if (serialize == null) {
                    $('form').submit();
                    return;
                }

                $(".login").append(serialize["Login"]);
                $(".password").append(serialize["Password"]);
                const elemModal = document.querySelector('.modal');
                const modal = new bootstrap.Modal(elemModal, {
                    backdrop: true,
                    keyboard: true,
                    focus: true,
                });
                modal.show();
            },

            error: function () {
                alert("Failed.");
            },
        })
    });
});
