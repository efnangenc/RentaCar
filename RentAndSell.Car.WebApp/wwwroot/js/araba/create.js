function CreateCar() {

    var formDataSerialize = $("#createCar").serialize();

    //console.log(formDataSerialize);
    //console.log(JSON.stringfy(formDataSerialize));

    var jsonData = JSON.stringfy(formDataSerialize);

    var token = $("#_token").val();

    $.ajax({
        url: "https://localhost:7027/api/Cars",
        headers: { 'Authorization': 'Bearer ' + token },
        method: "POST",
        data: jsonData,
        contentType: "application/json",
        success: function (data, statusText) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {

        }
    });
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}