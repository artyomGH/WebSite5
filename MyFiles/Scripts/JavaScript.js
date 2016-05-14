$(document).ready(function () {
    console.log("ready!");
    //alert("refclick");
    str = document.location.href;
    if (str.indexOf('Comments') != -1)
        RefreshComment();
    if (str.indexOf('Mail') != -1)
        RefreshChat();
});
$('input[name=browser]').change(function () {
    var value = $('input[name=browser]:checked').val();
    alert(value);
    
});

function refclick()
{
    var b;
    alert("refclick");
    WebService.HelloWorld(function (result) {
        b = result;
        alert("HelloWorld");
        if (result == "a")
            alert("wergfers");
    });
    
    alert("wefwe");
}
$("#Button2").click(function () {
    alert("ascascas");    
});

function RefreshComment() {
    //alert("RefreshComment");
    WebService.refresh_comments(function (result) {
        $get('TextBox1').innerHTML = result;
    });
    setTimeout("RefreshComment();", 1000);
}
function RefreshChat() {
    //alert("RefreshChat");
    var e = document.getElementById("DropDownList1");
    var strUser = e.options[e.selectedIndex].text;
    WebService.obnovit(strUser, function (result) {
        $get('TextBox1').innerHTML = result;
    });

    setTimeout("RefreshChat();", 1000);
}
function GetValue() {

    alert("Label Value is ");
    alert("TextBox Value is ");
}


function count_rabbits() {
    for(var i=1; i<=3; i++) {
        // оператор + соединяет строки
        alert("Из шляпы достали "+i+" кролика!")
    }
}
