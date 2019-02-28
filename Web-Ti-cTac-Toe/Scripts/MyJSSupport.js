function AskName() {
    var namePlayer = prompt("Введите своё имя");
    $("h3").get(0).prepend(namePlayer + ", ");    
}

function Cross(arg) {
    $(arg).attr("disabled", "disabled");
    $(arg).children(0).attr("src", "../Content/site/cross.png");
    //CheckWin();
    setTimeout(Zero(),500);   
}

function Zero() {      
    for (var i = 0; i < 9; i++)
    {
        var tempVar = $(".button").get(i); 
        if (!($(tempVar).prop("disabled"))) {  
            $(tempVar).children(0).attr("src", "../Content/site/circle.png");
            $(tempVar).attr("disabled", "disabled");
            //CheckWin();
            return;
        }      
    }    
}

function CheckWin() {
    //TODO: code this block, checking conditions win
}