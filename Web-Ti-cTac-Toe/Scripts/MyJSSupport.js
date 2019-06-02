function Main() {
    AskName();
    DisplayScore();
}

//as the page loads asks the player's name
function AskName() {
    var namePlayer = prompt("Введите своё имя", "anonymous");
    $("h3").get(0).prepend(namePlayer + ", ");
    $("#playersName").text(namePlayer);
}

function DisplayScore() {
    var url = "/Home/ShowScore";
    $.get(url, null, function (data) {
        $("#tableOfScore").append("<tr><td>" + data.winPl + "</td><td>" + data.winPC + "</td></tr>");
    }, "json")
        .fail(function (e) {
            alert("not all excelent");
        });
}

//puts the cross on the click
function Cross(buttonData) {
    $(buttonData).attr("disabled", "disabled");
    $(buttonData).children(0).attr("src", "../Content/site/cross.png");
    $(buttonData).children(0).attr("alt", "cross");
    StepCounting();
    CheckWin(buttonData);
    setTimeout(Zero, 300);
}

function StepCounting() {
    var count = $("#counter").text();
    count++;
    $("#counter").text(count);
}

//computer turn
function Zero() {
    for (var i = 0; i < 9; i++) {
        var buttonData = $(".buttonGame").get(i);
        if (!($(buttonData).prop("disabled"))) {
            $(buttonData).children(0).attr("src", "../Content/site/circle.png");
            $(buttonData).children(0).attr("alt", "circle");
            $(buttonData).attr("disabled", "disabled");
            CheckWin(buttonData);
            return;
        }
    }
}

//Checks whether won
function CheckWin(buttonData) {
    var valueProp = $(buttonData).children(0).prop("alt");
    var valueID = $(buttonData).prop("id");
    var countEqualProp = 0;
    
    for (var i = 0; i < 3; i++) {
        if (valueProp == $("#" + valueID[0] + i).children(0).prop("alt")) {
            countEqualProp++;
            if (countEqualProp == 3) {
                Result(valueProp)
            }
        }
        else break;
    }
    countEqualProp = 0;
    for (var i = 0; i < 3; i++) {
        if (valueProp == $("#" + i + valueID[1]).children(0).prop("alt")) {
            countEqualProp++;
            if (countEqualProp == 3) {
                Result(valueProp)
            }
        }
        else break;
    }

    if ((valueProp == $("#00").children(0).prop("alt")) &&
        (valueProp == $("#11").children(0).prop("alt")) &&
        (valueProp == $("#22").children(0).prop("alt"))) {
        Result(valueProp);
    }

    if ((valueProp == $("#02").children(0).prop("alt")) &&
        (valueProp == $("#11").children(0).prop("alt")) &&
        (valueProp == $("#20").children(0).prop("alt"))) {
        Result(valueProp);
    }
}

function Result(winner) {
    SetDataInController(winner);
    ShowWinMessage(winner);
}
//everything is obvious
function ShowWinMessage(valueProp) {
    alert("Победил " + valueProp);
    location.reload();
}

//sends data to controller
function SetDataInController(winner) {
    var url = "/Home/AddData";   
    var nameWin = (winner == "circle") ? "PC" : $("#playersName").text();
    var countStep = $("#counter").text();

    var setUserData = {
        nameWin: nameWin,
        countStep: countStep
    }    
    $.post(url, setUserData);
}

function ClearTable() {
    var url = "/Home/RemoveTable";
    $.post(url, null, function () {
        $("#tableOfGame").html("<tr><td></td><td></td><td></td></tr>");
        $("#tableOfScore").html("<tr><td>0</td><td>0</td></tr>");
    },)
}

function InstallCookie(someDataName, someDataPassword) {
    //TODO: set for check login and password to backend
    var expire = new Date();
    expire.setDate(expire.getDay() + 3);
    document.cookie = "login=" + someDataName + ";expires=" + expire.toUTCString() + ";";
    document.cookie = "password=" + someDataPassword + ";expires" + expire.toUTCString() + ";";
}

//should authentication users
function getCookiesValue() {
    var cookies = document.cookie.split(";");
    for (i = 0; i < cookies.length; i++){
        var parts = cookies[i].split("=");
        var name = parts[0];
        var val = parts[1];
        alert("name of cookie = " + name);
        alert("value of cookie = " + val);
    }
}

function SignUpFormProcessing() {   
    
}

function SignInFormProcessing() {
  
}

