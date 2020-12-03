// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//------Fields
var createBtn = null;
var createEnv = null;

//-----Scripts
$(document).ready(function () {
    $('.toast').toast({ delay: 2000 });
    $('.toast').toast('show');
});


//----FUNCTIONS
function ShowCreate(event) {
    event.preventDefault();

    createEnv = $("#createEnviroment")
    const anchorElement = event.target;

    //console.log('#' + anchorElement.attributes["data-target"].value)
    //console.log(createEnv[0].attributes.class)

    if (createEnv[0].attributes.class.value == "collapse") {
        $.get(anchorElement.attributes.href.value, function (result) {
            $('#' + anchorElement.attributes["data-target"].value).html(result);
            $(createEnv).removeClass("collapse").addClass("collapse show");
        });
    }
    else if (createEnv[0].attributes.class.value == "collapse show") {
        $(createEnv).removeClass("collapse show").addClass("collapse");
    }

};

function PostCreate(event, createForm) {
    event.preventDefault();

    createEnv = $("#createEnviroment")

    $.post(createForm.action,
        {
            Name: createForm.Name.value,
            PhoneNum: createForm.PhoneNum.value,
            City: createForm.City.value
        },
        function (data, status) {
            $("#peopleListDiv").append(data);
            $("#createEnviroment").html("");
            $(createEnv).removeClass("collapse show").addClass("collapse");
        }).fail(function (badForm) {
            $("#createEnviroment").html(badForm.responseText);
        });
}

function ShowEdit(event) {
    event.preventDefault();
    
    const anchorElement = event.target;

    //console.log('#' + anchorElement.attributes["data-target"].value);
    //console.log(anchorElement.attributes.href.value);

    $.get(anchorElement.attributes.href.value, function (result) {
        $('#' + anchorElement.attributes["data-target"].value).replaceWith(result);
    });
}

function PostEdit(event, editForm) {
    event.preventDefault();

    $.post(editForm.action,
        {
            Name: editForm.Name.value,
            PhoneNum: editForm.PhoneNum.value,
            City: editForm.City.value
        },
        function (data, status) {
            $('#' + event.target.attributes[0].value).replaceWith(data);
        }).fail(function (badForm) {
            $('#' + event.target.attributes[0].value).html(badForm.responseText);
        });
}

function AjaxDelete(event) {
    event.preventDefault();
    anchor = event.target;

    $.get(anchor.attributes.href.value, function (data) {
        $('#' + anchor.attributes["data-target"].value).remove();
        //$("#toastMsg").html(data); Tried to insert a toast message but it just showed a blank space. 
    })
}