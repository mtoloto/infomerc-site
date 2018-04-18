$(function () {

    $('.register-form').validator();

    $('.register-form').on('submit', function (e) {
        if (!e.isDefaultPrevented()) {
            var url = "Login/Registro";
            $("#btn-register-form").addClass("hidden");
            $.ajax({
                type: "POST",
                url: url,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data);
                    $('.register-form').find('.messages').html("");
                    if (data.erros != null) {
                        $.each(data.erros, function (index, value) {
                            //alert(index + ": " + value);
                            var messageAlert = 'alert-success'; //+ data.type;
                            var messageText = value;

                            var alertBox = '<div class="alert ' + messageAlert + ' alert-dismissable">' + messageText + '</div>';

                            $('.register-form').find('.messages').append(alertBox);

                        });
                        $("#btn-register-form").removeClass("hidden");
                    }
                    else {

                        if (data.logado == true)
                            location.href = "minhaarea";

                    }
                }
            });
            return false;
        }
    });



    $('.login-form').validator();

    $('.login-form').on('submit', function (e) {
        if (!e.isDefaultPrevented()) {
            var url = "Login/Login";
            $("#btn-login-form").addClass("hidden");
            $.ajax({
                type: "POST",
                url: url,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data);
                    $('.register-form').find('.messages').html("");
                    if (data.erros != null) {
                        $.each(data.erros, function (index, value) {
                            //alert(index + ": " + value);
                            var messageAlert = 'alert-success'; //+ data.type;
                            var messageText = value;

                            var alertBox = '<div class="alert ' + messageAlert + ' alert-dismissable">' + messageText + '</div>';

                            $('.register-form').find('.messages').append(alertBox);

                        });
                        $("#btn-login-form").removeClass("hidden");
                    }
                    else {

                    }
                }
            });
            return false;
        }
    })
});