var statData;
var cityData;
var stateCityMapping;
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
        formData.set("Category", $("#Category :selected").text());
        formData.set("CategorySlug", $("#Category :selected").val());
        formData.set("StateId", $("#StateId :selected").val());
        formData.set("CityId", $("#CityId :selected").val());
        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddNews", // URL to send the request to
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
                    window.location.href = '/Admin/CategoriesList'; // Redirect to another page on success
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
    $("#SubmitState").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var form = $("#StateForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element

        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddState", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/StateList'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });
    $("#SubmitCity").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var form = $("#CityForm")[0]; // Get the form element
        var formData = new FormData(form); // Create FormData object from the form element
        formData.set("s_id", $("#s_id :selected").val());
        $('.contact-response').show();

        $.ajax({
            url: "/Admin/AddCity", // URL to send the request to
            type: 'POST', // HTTP method
            data: formData, // Form data
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set content type to false as jQuery will tell the server its a query string request
            success: function (response) {
                setTimeout(() => {
                    window.location.href = '/Admin/CityList'; // Redirect to another page on success
                }, 1000);
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        });
    });

    if (!statData) {
        $.get('/Home/GetStateList', (res) => {
            statData = res;
        });
    }
    if (!cityData) {
        $.get('/Home/GetCityList', (res) => {
            cityData = res;
            setTimeout(() => {
                stateCityMapping = statData?.map(function (state) {
                    state.cities = cityData?.filter(function (city) {
                        return city.s_id === state.s_id;
                    }).map(function (city) {
                        return {
                            "c_id": city.c_id,
                            "city_hindi": city.city_hindi,
                            "city_eng": city.city_eng
                        };
                    });
                    return state;
                });
                var _html = '';
                stateCityMapping.forEach(function (state) {
                    _html += '<li>';
                    _html += '<a href="#">' + state.state_hindi + '</a>';

                    // Check if state has cities
                    if (state.cities && state.cities.length > 0) {
                        _html += '<ul class="ne-dropdown-submenu">';

                        // Loop through each city within the state
                        state.cities.forEach(function (city) {
                            _html += '<li>';
                            _html += '<a href="/Home/Place/' + city.city_eng +'">' + city.city_hindi + '</a>';
                            _html += '</li>';
                        });

                        _html += '</ul>';
                    }

                    _html += '</li>';
                });
                $('#cascadeStateCity').append(_html);
            }, 2000)
        });
    }
});
var LoadStateDDL = (selector, stateId = 0) => {
    $.get('/Home/GetStateList', (res) => {
        selector.empty().append('<option value="0">Select State</option>').append(res.map(a => {
            return `<option value="${a.s_id}">${a.state_eng}</option>`;
        }));
        setTimeout(() => {
            if (stateId) {
                selector.val(`${stateId}`).change();
            }
        }, 1);
    });
}
var LoadCityDDL = (selector, stateId = 0, cityId = 0) => {
    $.get('/Home/GetCityList', { stateId }, (res) => {
        selector.empty().append('<option value="0">Select City</option>').append(res.map(a => {
            return `<option value="${a.c_id}">${a.city_eng}</option>`;
        }));
        if (cityId) {
            selector.val(`${cityId}`).change();
        }
        setTimeout(() => {
            if (cityId) {
                selector.val(`${cityId}`).change();
            }
        }, 1000);

    }); 
}

