function Cross(arg) {    
    $(arg).attr("disabled","disabled");
    $(arg).children(0).attr("src", '../Content/site/cross.png');
    Zero(arg);
}

function AskName() {
    var namePlayer = prompt("Введите своё имя");
    $("h3").get(0).prepend(namePlayer +", ");
}

function Zero(arg) {    
    //TODO: some metod click Circle 
}