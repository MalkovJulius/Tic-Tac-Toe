function AskName() {
    var namePlayer = prompt("Введите своё имя");
    $("h3").get(0).prepend(namePlayer + ", ");    
}

function Cross(arg) {
    $(arg).attr("disabled", "disabled");
    $(arg).children(0).attr("src", "../Content/site/cross.png");
    //CheckWin();
    Zero();
}

function Zero() {  
    //for (var i = 0; i < 9; i++) {
    var tempVar = $("button.button[disabled='false']").get(0);
    var temp2 = $(tempVar).children(0);
    alert($(temp2));
            if ($(tempVar).html() == "<img src='~/Content/site/emptyPic.png' style='width:30px; height:30px' />")
            {               
                alert("WiN");                   
                $(tempVar).children(0).attr("src", "../Content/site/circle.png");
                $(tempVar).attr("disabled", "disabled");
                //CheckWin();
                return;
            }
            else alert("Something wrong");
       //}
}

function CheckWin() {
    //TODO: code this block, checking conditions win
}