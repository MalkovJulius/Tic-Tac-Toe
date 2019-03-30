//as the page loads asks the player's name
function AskName() {
    var namePlayer = prompt("Введите своё имя", "anonymous");
    $("h3").get(0).prepend(namePlayer + ", ");
    //TODO: set name in DB
}

//puts the cross on the click
function Cross(arg) {
    $(arg).attr("disabled", "disabled");
    $(arg).children(0).attr("src", "../Content/site/cross.png");
    $(arg).children(0).attr("alt", "cross");
    CheckWin(arg);
    setTimeout(Zero, 300);
}

//computer turn
function Zero() {
    for (var i = 0; i < 9; i++) {
        var targetPC = $(".buttonGame").get(i);
        if (!($(targetPC).prop("disabled"))) {
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
    var valueProp = $(someArg).children(0).prop("alt");
    var valueID = $(someArg).prop("id");
    var countEqualProp = 0;
    for (var i = 0; i < 3; i++) {
        if (valueProp == $("#" + valueID[0] + i).children(0).prop("alt")) {
            countEqualProp++;
            if (countEqualProp == 3) {
                ShowWinMessage(valueProp)
            }
        }
        else break;
    }
    countEqualProp = 0;
    for (var i = 0; i < 3; i++) {
        if (valueProp == $("#" + i + valueID[1]).children(0).prop("alt")) {
            countEqualProp++;
            if (countEqualProp == 3) {
                ShowWinMessage(valueProp)
            }
        }
        else break;
    }

    if ((valueProp == $("#00").children(0).prop("alt")) &&
        (valueProp == $("#11").children(0).prop("alt")) &&
        (valueProp == $("#22").children(0).prop("alt"))) {
        ShowWinMessage(valueProp);
    }

    if ((valueProp == $("#02").children(0).prop("alt")) &&
        (valueProp == $("#11").children(0).prop("alt")) &&
        (valueProp == $("#20").children(0).prop("alt"))) {
        ShowWinMessage(valueProp);
    }
}

//everything is obvious
function ShowWinMessage(valueProp) {
    alert("Победил " + valueProp);
    //ViewBag.Winner = valueProp;        
    SetDataInController();
    location.reload();
    return;
}

//sends data to controller
function SetDataInController(valueProp) {
    var url = "/Home/AddData";
    $.get(url, valueProp, function () {
        $("#tableOfGame").append("<tr><td>@g.GameId</td><td>@g.YouWin</td><td>@g.MoveGame</td></tr>");
    })
        .fail(function () {
            alert("ERROR");
        });
    //TODO: set data in BD js
}

function ClearTable() {
    var url = "/Home/RemoveTable";
    $.get(url, null, function () {
        $("#tableOfGame").html("");
    })
        .fail(function () {
            alert("ERROR");
        });
}