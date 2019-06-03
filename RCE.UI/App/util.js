$(document).ajaxError(function (a, error) {
    util.loader(false);
    if (typeof error.responseJSON === 'undefined') {
        console.error(error);
        if ($(".error-div").length > 0)
            $(".error-div").html("<br /><div class=\"alert alert-danger\">" + error.statusText + "</div>");
        else
            alert(error.statusText);
    }
    else {
        var messages = error.responseJSON;
        console.error(messages);
        if ($(".error-div").length > 0)
            $(".error-div").html("<br /><div class=\"alert alert-danger\">" + messages[0] + "</div>");
        else
            alert(messages[0]);
    }
});

var util = {
    initialize: function (theme) {
        $(":input").attr("autocomplete", "off");
        if (!theme) theme = "dark";
        $.Loading.setDefaults({ theme: theme, message: 'Loading...' });
    },

    loader: function (isVisible, target) {
        var t = 'body';
        if (target) t = target;
        if (isVisible)
            $(t).loading('start');
        else 
            $(':loading').loading('stop');
    },

    showModal: function (targetId, actionUrl, data, http, callback) {
        var method = "GET";
        if (http) method = http;
        util.loader(true);
        $.ajax(actionUrl,
            {
                method: method,
                data: data,
                success: function (modal) {
                    $(targetId + "Div").html(modal);
                    $(targetId).modal({ backdrop: 'static', keyboard: false });
                    util.initialize();
                    if (callback) callback();
                    util.loader(false);
                    $(targetId).css('z-index','99999999999999999999999999999999999999999999999999999999999999999999999999999999999999')
                },
            });
    },
    getHtml: function (targetId, actionUrl, data, http, callback) {
        var method = "GET";
        if (http) method = http;
        util.loader(true);
        $.ajax(actionUrl,
            {
                method: method,
                data: data,
                success: function (html) {
                    $(targetId).html(html);
                    util.initialize();
                    if (callback) callback();
                    util.loader(false);
                },
            });
    },
    getJson: function (actionUrl, data, http, callback) {
        var method = "GET";
        if (http) method = http;
        $.ajax(actionUrl,
            {
                method: method,
                data: data,
                success: function (data) {
                    if (callback) callback(data);
                },
            });
    },
    validate: function (element) {
        let errorClass = 'input-validation-error';
        let value = element.val();
        let notValid = element.hasClass(errorClass)
        if (!value || notValid) {
            element.addClass(errorClass)
            return false;
        }
        if (element.hasClass(errorClass)) {
            element.removeClass(errorClass)
        }
        return true;
    },
    setValueToElements: function (data) {
        var propertyNames = getPropertyNames(data);
        for (var item of propertyNames) {
            $("#" + item).val(data[item])
        }
    }
}

function getPropertyNames(obj) {
    var hasOwn = Object.prototype.hasOwnProperty;
    var propertyNames = Object_keys(obj);
    function Object_keys(obj) {
        var keys = [], name;
        for (name in obj) {
            if (hasOwn.call(obj, name)) {
                keys.push(name);
            }
        }
        return keys;
    }
    return propertyNames;
}