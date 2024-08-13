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
    $("#SubmitPost").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var form = $("#AddPostForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element

        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddNews", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/AddNews'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });
    $("#SubmitCategory").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var form = $("#CategoryForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element

        // Manually append checkbox values
        formData.set("IsActive", $("#IsActive").is(":checked"));
        formData.set("IsActiveForHome", $("#IsActiveForHome").is(":checked"));

        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddCategories", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/AddCategories'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });
    $("#btnAddUser").click(function (e) {
        e.preventDefault(); // Prevent the default form submission
        if ($('#username').val() == '') {
            $('.username').show();
            return false;
        }
        else {
            $('.username').hide();
        }
        if ($('#email').val() == '') {
            $('.email').show();
            return false;
        }
        else {
            $('.email').hide();
        }
        if ($('#password').val() == '') {
            $('.password').show();
            return false;
        }
        else {
            $('.password').hide();
        }
        var form = $("#btnAddUserForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element
        

        $('.contact-response').show();

        $.ajax({
            url: "/Account/AddUser", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/Index'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });

    
    $("#SubmitSlider").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var form = $("#AddSliderForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element

        formData.set("isShowOnHome", $("#isShowOnHome").is(":checked"));
        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddHomeSlider", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/AddHomeSlider'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });
});