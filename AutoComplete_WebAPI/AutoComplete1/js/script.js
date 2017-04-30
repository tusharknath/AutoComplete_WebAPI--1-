var resultDIV = null;
var urlType = null;
var MinChar = null;
var Global_Url = null;
var maximumItem = null;

function makeUL(array, searchTxtId) {
    // Create the list element:
    var arrayLen = 0;
    if (maximumItem == 0)
    {
        arrayLen = array.length;
    }
    else
    {
        arrayLen = array.slice(0, maximumItem).length;
    }

    var list = document.createElement('ul');
    list.setAttribute('Id', 'Menu');
    
    for (var i = 0; i < arrayLen; i++) {
        // Create the list item:
        var item = document.createElement('li');
        var val = array[i];
        var link = document.createElement('a');
        link.innerHTML = val;

        link.setAttribute("href", "javascript:liOnClick(\"" + val + "\" , \"" + searchTxtId + "\")");
        item.appendChild(link);

        list.appendChild(item);
    }

    // Finally, return the constructed list:
    return list;
}

var getJSON = function (url, Type, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open(Type, url, true);
    xhr.responseType = 'json';
    xhr.onload = function () {
        var status = xhr.status;
        if (status == 200) {
            callback(null, xhr.response);
        } else {
            callback(status);
        }
    };
    xhr.send();
};


function autoComplete(Text, Url, Type, MinLength, resDivID, searchTxt, maxItems) {
    resultDIV = resDivID;
    urlType = Type;
    MinChar = MinLength;
    Global_Url = Url;
    maximumItem = maxItems;

    putCss(searchTxt, resultDIV);

    if (Text.length >= MinLength) {
        var query = Text;

        getJSON(Url + '?query=' + Text, Type, function (err, data) {
            if (err != null) {
            } else {                
                document.getElementById(resDivID).innerHTML = makeUL(data, searchTxt).outerHTML;                
            }
        });
    }
    
}

function liOnClick(selectedWord, searchTxt) {
    document.getElementById(searchTxt).value = selectedWord;
    autoComplete(selectedWord, Global_Url, urlType, MinChar, resultDIV, searchTxt, maximumItem);
}

function putCss(searchTxt, resDivID)
{
    //var offset1 = document.getElementById(searchTxt).offsetLeft;
    //var width1 = document.getElementById(searchTxt).width - 2;

    //document.getElementById(resDivID).style.left = offset1 - 10;
    //document.getElementById(resDivID).style.width = width1;
    document.getElementById(resDivID).style.border = "1px solid #8789E7";
    document.getElementById(resDivID).style.position = "absolute";
}


