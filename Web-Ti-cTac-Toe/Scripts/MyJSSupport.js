//as the page loads asks the player's name
function AskName() {
    var namePlayer = prompt("Введите своё имя");
    $("h3").get(0).prepend(namePlayer + ", ");   
    //TODO: set name in DB
}

//puts the cross on the click
function Cross(arg) {
    $(arg).attr("disabled", "disabled");
    $(arg).children(0).attr("src", "../Content/site/cross.png");
    $(arg).children(0).attr("alt","cross");
    CheckWin(arg);    
    setTimeout(Zero, 300);   
}

//computer turn
function Zero() {      
    for (var i = 0; i < 9; i++) {
    var targetPC = $(".buttonGame").get(i); 
        if (!($(targetPC).prop("disabled")))
        {  
            $(targetPC).children(0).attr("src", "../Content/site/circle.png");
            $(targetPC).children(0).attr("alt", "circle");
            $(targetPC).attr("disabled", "disabled");
            CheckWin(targetPC);
            return;
        }      
    } 
}

//Checks whether won
function CheckWin(someArg) {
    //TODO: code this block, checking conditions win    
    var x = $(someArg).children(0).prop("alt");
    alert(x);
    var y = $(someArg).prop("id");
    alert(y);
    var z = 0;   
    for (var i = 0; i < 3; i++) {
        var temp = "#" + y[0] + i;
        alert($("#" + y[0] + i).children(0).prop("alt"));
        alert($("#" + i + y[1]).children(0).prop("alt"));
    }
    //set data in BD    
}