$(document).ready(function () {
    $("#SaveContact").click(function () {
        var form = $("#contact-form");
        var formData = form.serialize();
        $('.contact-response').show();      
        $.ajax({
            url: "/Home/SaveContact", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Home/Contact'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });
});