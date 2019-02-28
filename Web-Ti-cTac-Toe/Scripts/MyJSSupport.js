//as the page loads asks the player's name
function AskName()
{
    var namePlayer = prompt("Введите своё имя");
    $("h3").get(0).prepend(namePlayer + ", ");   
    //TODO: set name in DB
}

//puts the cross on the click
function Cross(arg)
{
    $(arg).attr("disabled", "disabled");
    $(arg).children(0).attr("src", "../Content/site/cross.png");
    //CheckWin();
    setTimeout(Zero,700);   
}

//computer turn
function Zero()
{      
    for (var i = 0; i < 9; i++) {
        var tempVar = $(".buttonGame").get(i); 
        if (!($(tempVar).prop("disabled")))
        {  
            $(tempVar).children(0).attr("src", "../Content/site/circle.png");
            $(tempVar).attr("disabled", "disabled");
            //CheckWin();
            return;
        }      
    }    
}

//Checks whether won
function CheckWin() {
    //TODO: code this block, checking conditions win
    if (true)
        alert("Поздравляю с победой над ИИ");
    else
        alert("В этот раз, Вы проиграли, попробуйте ещё раз");
    //set data in BD    
}