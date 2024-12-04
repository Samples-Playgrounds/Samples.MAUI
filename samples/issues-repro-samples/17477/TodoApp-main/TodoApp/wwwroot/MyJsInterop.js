function setCaretPosition(elemId, caretPos) {
    var el = document.getElementById(elemId);

    el.value = el.value;
    // ^ this is used to not only get "focus", but
    // to make sure we don't have it everything -selected-
    // (it causes an issue in chrome, and having it doesn't hurt any other browser)

    if (el !== null) {

        if (el.createTextRange) {
            var range = el.createTextRange();
            range.move('character', caretPos);
            range.select();
            return true;
        }

        else {
            // (el.selectionStart === 0 added for Firefox bug)
            if (el.selectionStart || el.selectionStart === 0) {
                el.focus();
                el.setSelectionRange(caretPos, caretPos);
                return true;
            }

            else { // fail city, fortunately this never happens (as far as I've tested) :)
                el.focus();
                return false;
            }
        }
    }
}

window.MyJSFunctions = {
    GetElementActualLeft: function (el) {
        if (document.getElementById(el) !== null) {
            let rect = document.getElementById(el).getBoundingClientRect();
            return rect.left;
        }
        else {
            return 0;
        }
    },
    setTextToCurrentPos: function (el, value) {
        const curPos = document.getElementById(el).selectionStart;
        const obj = document.getElementById(el);
        const textToInsert = obj.value.slice(0, curPos) + ' ' + value + ' ' + obj.value.slice(curPos);
        obj.value = textToInsert;
        setCaretPosition(el, curPos + textToInsert.length)
        return obj.value;
    }
}