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
    CheckWin();    
    setTimeout(Zero, 300);   
}

//computer turn
function Zero() {      
    for (var i = 0; i < 9; i++) {
        var tempVar = $(".buttonGame").get(i); 
        if (!($(tempVar).prop("disabled")))
        {  
            $(tempVar).children(0).attr("src", "../Content/site/circle.png");
            $(tempVar).children(0).attr("alt", "circle");
            $(tempVar).attr("disabled", "disabled");
            //CheckWin();
            return;
        }      
    } 
}

//Checks whether won
function CheckWin() {
    //TODO: code this block, checking conditions win
    var x = $(".buttonGame").get(0).children(0);
    alert(x);

    if (true) 
    /*($(".buttonGame").get(0).children(0).prop("alt") == $(".buttonGame").get(1).children(0).prop("alt"))/* === $(".buttonGame").get(2).children(0).prop("alt"))*/ /*||
        ($(".buttonGame").get(3).attr("alt") == $(".buttonGame").get(4).attr("alt") == $(".buttonGame").get(5).attr("alt")) ||
        ($(".buttonGame").get(6).attr("alt") == $(".buttonGame").get(7).attr("alt") == $(".buttonGame").get(8).attr("alt")) ||
        ($(".buttonGame").get(0).attr("alt") == $(".buttonGame").get(3).attr("alt") == $(".buttonGame").get(6).attr("alt")) ||
        ($(".buttonGame").get(1).attr("alt") == $(".buttonGame").get(4).attr("alt") == $(".buttonGame").get(7).attr("alt")) ||
        ($(".buttonGame").get(2).attr("alt") == $(".buttonGame").get(5).attr("alt") == $(".buttonGame").get(8).attr("alt"))*/
    {
        alert("Поздравляю с победой над ИИ");
    }
    else {
        alert("В этот раз, Вы проиграли, попробуйте ещё раз");
    }
    //set data in BD    
}

//function Test(target) {
//    var targetAlt = $(target).children(0).prop("alt");
//    var targetId = $(target).attr("id");
//    $("#" + targetId[0] + "0").children(0).attr("alt");
//    $("#" + "0" + targetId[0]).children(0).attr("alt");
//    if (targetAlt==)   
//}

//function someF(target) {
//    var x = $(target).children(0).prop("alt");
//    var i = 0;
//    var bool = true;
//    while (bool) {
//        bool = (x == $("#" + targetId[0] + "0").children(0).attr("alt"));
//        if ((i == 3) && (bool)) {
//            alert("Победа ");
//            return;
//        }
//        i++;
//    }
//    i = 0;
//    while (bool) {
//        bool = (x == $("#" + "0" + targetId[0]).children(0).attr("alt"));
//        if ((i == 3) && (bool)) {
//            alert("Победа ");
//            return;
//        }
//        i++;
//    }
//}