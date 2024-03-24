window.onload = () => {
    sessionStorage.setItem("Items", "");
}
function AddJa(event, Id) {
    event.stopImmediatePropagation();
    var items = sessionStorage.getItem("Items");
    if (items == null || items == "") {
        sessionStorage.setItem("Items", Id);
    }
    else {
        items += "," + Id;
        sessionStorage.setItem("Items", items);
    }
}
function Add(Id) {
    var items = sessionStorage.getItem("Items");
    if (items == null || items == "") {
        sessionStorage.setItem("Items", Id);
    }
    else {
        items += "," + Id;
        sessionStorage.setItem("Items", items);
    }
}
function Fetch() {
    var ids = sessionStorage.getItem("Items");
    return ids == null ? "" : ids;
}
function CallCartPage(url) {
    window.location.href = url.replace("IdsValue", Fetch());
    sessionStorage.setItem("Items", "");
} 
function CallPage(url) {
    window.location.href = url.replace("ids", Fetch());
}
function CallTope(url, Id) {
    Add(Id);
    CallPage(url);
}

function FixWidth(item, url, currentpage) {
    if (parseInt(item.value) > parseInt(item.max))
        item.value = item.max;
    else if (parseInt(item.value) < 1)
        item.value = 1;

    item.style.width = (item.value.length + 1) + 'ch';
    if (parseInt(currentpage) != parseInt(item.value))
        CallPage(url.replace("NotSet", item.value));
}