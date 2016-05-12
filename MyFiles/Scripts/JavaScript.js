$(document).ready(function () {
    console.log("ready!");
    //alert("refclick");
    GetResult();
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

function GetValue() {

    alert("Label Value is ");
    alert("TextBox Value is ");
}
function GetResult() {
    var e = document.getElementById("DropDownList1");
    var strUser = e.options[e.selectedIndex].text;

    //alert("кумуав");

    WebService.obnovit(strUser,function (result)
    {
        $get('TextBox1').innerHTML = result;        
    });
   
    setTimeout("GetResult();", 1000);
   }

function count_rabbits() {
    for(var i=1; i<=3; i++) {
        // оператор + соединяет строки
        alert("Из шляпы достали "+i+" кролика!")
    }
}
