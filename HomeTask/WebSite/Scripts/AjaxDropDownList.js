var ajaxDDL = function (textRenderer, valueStorage, url) {
    var elementCoords = $(textRenderer).offset();
    var width = $(textRenderer).outerWidth();
    var height = $(textRenderer).outerHeight(true);
    var maxHeight = height * 5;
    var font = $(textRenderer).css('font');
    var fontSize = $(textRenderer).css('font-size');

    var list = $('<div></div>').css({
        'max-height': maxHeight,
        'width': width,
        'position': 'absolute',
        'left': elementCoords.left,
        'top': elementCoords.top + height,
        'background': 'white',
        'font-family': font,
        'font-size': fontSize
    });
    list.html("first<br/>first<br/>first<br/>first<br/>first<br/>");

    $(textRenderer).focus(function () {
        $.getJSON(url, createList);
    });

    $(textRenderer).focusout(function () {
        list.empty();
        list.hide();
    });
    function createList(ddl) {
        list.empty();
        list.hide();
        if (ddl.text !== null || ddl.value !== null && ddl.text.length == ddl.value.length) {
            var ul = $('<ul></ul>').addClass("nav nav-pills nav-stacked");
            list.append(ul);
            $('body').append(list);
            for (var i = 0; i < ddl.text.length; i++) {
                var li = $('<li></li>');
                var link = $('<a href="#"></a>').attr('val', ddl.value[i]);
                link.text(ddl.text[i]);
                li.append(link);
                ul.append(li);
                $(link).live('click', function () {
                    alert("lf");
                });
            }       
            list.show();
        }
    }

    function onClick(e) {
        e.preventDefault();
        valueStorage.attr('value', $(this).attr('val'));
        $(textRenderer).text($(this.text));
    }
}