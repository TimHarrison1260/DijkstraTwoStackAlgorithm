/// <reference path="../jquery-1.8.2.js" />

$(document).ready(function () {
    /*
    *   Attach handlers to button click events
    */
    $('input[class^=numberbutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val();
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("NumberButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });
    $('input[class^=operatorbutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val();
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("OperatorButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });
    $('input[class^=rightbracebutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val();
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("RightBraceButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });
    $('input[class^=cancelbutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val().substr(0,1);
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("CancelButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });
    $('input[class^=clearbutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val();
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("ClearButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });
    $('input[class^=computebutton]').click(function () {
        //  Get the parameter from the value of the button
        var c = $(this).val();
        var currentExpression = $('#displayExpression').val();
        var url = getUrl("EqualsButtonClick");

        //  Call the Home Controller, Button click method
        callControllerMethod(url, c, currentExpression);
    });

});


function callControllerMethod(url, character, currentExpression) {
    $.ajax({
        url: url,
        type: "POST",
        data: { value: character, expression: currentExpression },
        dataType: 'json',
        success: function (result) {
            //  Update the Expression
            var expression = result.Expression;
            var answer = result.Answer;
            var message = result.Message;

            $('#displayExpression').val(expression);    //           .val(expression);
            $('#displayAnswer').val(answer);
            $('#message').val(message);
        },
        error: function (xhr) {
            alert("Error occurred: " + xhr.status);
        }
    });
}

function getUrl(action) {
    var urlAction = $('#UrlAction').attr("data-urlaction").valueOf();  // use a dummy to resolve the url at run-time
    var url = urlAction.replace("PLACEHOLDER", action);
    return url;
}
