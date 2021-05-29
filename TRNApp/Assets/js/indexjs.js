let teamMap = new Map();
let newsMap = new Map();

function getByValue(map, searchValue) {
    for (let [key, value] of map.entries()) {
        if (value === searchValue)
            return key;
    }
}

function getByKey(map, searchValue) {
    for (let [key, value] of map.entries()) {
        if (key === searchValue)
            return value;
    }
}

$(function () {
    // Detect window scroll and update navbar
    $(window).scroll(function (e) {
        if ($(document).scrollTop() > 120) {
            $('.tm-navbar').addClass("scroll");
        } else {
            $('.tm-navbar').removeClass("scroll");
        }
    });

    // Scroll to corresponding section with animation
    $('#tmNav').singlePageNav();

    // Add smooth scrolling to all links
    // https://www.w3schools.com/howto/howto_css_smooth_scroll.asp
    $("a").on('click', function (event) {
        if (this.hash !== "") {
            event.preventDefault();
            var hash = this.hash;

            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 400, function () {
                window.location.hash = hash;
            });
        } // End if
    });
});

// Fill table groups
$(document).ready(function () {
    // Send an AJAX request to fill team tables
    $("#players").hide();
    $.ajax({
        type: "GET",
        //url: 'https://localhost:44325/gateway/teams',
        url: 'http://localhost:8082/api/TeamObjs',
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            var a = 1;
            var b = 1;
            $.each(data, function (index, data) {
                if (data.teamGroup == "A")
                {
                    teamMap.set(data.teamName, data.teamId);
                    $('#group-a').append("<tr><td>" + a + "</td><td>" + data.teamAbr + "</td><td>" +
                        "<a href='#players'><div class='player-row'>" + data.teamName + "</div></a>"
                        + "</td><td>" + data.gamesPlayed + "</td><td>" + data.goalsScored + "</td><td>" + data.goalsAgainst + "</td><td>" + data.points + "</td></tr>");
                    a += 1;
                }
                if (data.teamGroup == "B") {
                    teamMap.set(data.teamName, data.teamId);
                    $('#group-b').append("<tr><td>" + b + "</td><td>" + data.teamAbr + "</td><td>" +
                        "<a href='#players'><div class='player-row'>" + data.teamName + "</div></a>"
                        + "</td><td>" + data.gamesPlayed + "</td><td>" + data.goalsScored + "</td><td>" + data.goalsAgainst + "</td><td>" + data.points + "</td></tr>");
                    b += 1;
                }
            });
        },
        failure: function (response) {
            alert("Error");
        }
    });

    // Fill latest news
    $.ajax({
        type: "GET",
        url: 'http://localhost:8084/api/NewsObjs',
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            var len = data.length;

            $.each(data, function (index, data) {
                if (index>=len-4)
                {
                    newsMap.set(data.title, data.body);
                    $('#news-table').append("<tr><th scope='row'><a href='#information'>" + data.title + "</a></td></tr>");
                }
            });
        },
        failure: function (response) {
            alert("Error");
        }
    });

    // Fill recent results
    $.ajax({
        type: "GET",
        //url: 'https://localhost:44325/gateway/games',
        url: 'http://localhost:8083/api/GamesObjs',
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            $.each(data, function (index, data) {
                var firstWin = data.firstTeamGoals > data.secondTeamGoals;
                var firstTeamName = getByValue(teamMap, data.firstTeamId);
                var secondTeamName = getByValue(teamMap, data.secondTeamId);
                if (data.finished == 1)
                {
                    if (firstWin) {
                        $('#recent-results-tab').append(
                            "<div class='row'><div class='col'><p style='color:green;'>" + firstTeamName + "</p></div>" +
                            "<div class='col'><p> " + data.firstTeamGoals + "  -  " + data.secondTeamGoals + "</p></div>" +
                            "<div class='col'><p>" + secondTeamName + "</p></div></div>"
                        );
                    }
                    else {
                        $('#recent-results-tab').append(
                            "<div class='row'><div class='col'><p>" + firstTeamName + "</p></div>" +
                            "<div class='col'><p id=> " + data.firstTeamGoals + "  -  " + data.secondTeamGoals + "</p></div>" +
                            "<div class='col'><p style='color:green;'>" + secondTeamName + "</p></div></div>"
                        );
                    }
                }
            });
        },
        failure: function (response) {
            alert("Error");
        }
    });

    // Fill future games
    $.ajax({
        type: "GET",
        //url: 'https://localhost:44325/gateway/games',
       url: 'http://localhost:8083/api/GamesObjs',
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            $.each(data, function (index, data) {
                var firstTeamName = getByValue(teamMap, data.firstTeamId);
                var secondTeamName = getByValue(teamMap, data.secondTeamId);
                if (data.finished == 0) {
                    $('#future-games-tab').append(
                        "<div class='row'><div class='col'><p>" + firstTeamName + "</p></div>" +
                        "<div class='col'><p> " + data.firstTeamGoals + "  -  " + data.secondTeamGoals + "</p></div>" +
                        "<div class='col'><p>" + secondTeamName + "</p></div></div>"
                    );
                }
            });
        },
        failure: function (response) {
            alert("Error");
        }
    });


    // On team clicked fill team player table
    $(document).bind("click", function (e) {
        $(e.target).closest("td").toggleClass(".tb-groups");
        var fieldTxt = $(event.target).text();

        if (teamMap.has(fieldTxt)) {
            var teamId = teamMap.get($(event.target).text());
            $("#players").show();

            $.ajax({
                type: "GET",
                url: 'http://localhost:8082/api/PlayerObjs/teamPlayers/' + teamId,
                //url: 'http://localhost:44325/gateway/team-games/' + teamId,
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    document.getElementById('players-team-name').innerHTML = fieldTxt + " spēlētāji";
                    $("#player-table tr").remove();

                    $.each(data, function (index, data) {
                        $('#player-table').append("<tr><th scope='row'>" + data.playerNumber + "</th><td>" + data.playerName + "</td><td>" + data.playerLastName +
                            "</td><td>" + data.playerPosition + "</td><td>" + data.goals + "</td><td>" + data.assists + "</td><td>" + data.penaltyMinutes + "</td></tr>");
                    });
                },
                failure: function (response) {
                    alert("Error");
                }
            });
        }
        else if(newsMap.has(fieldTxt))
        {
            document.getElementById('selected-news-p').innerHTML = newsMap.get(fieldTxt);
        }
    });

});

$(document).ready(function () {
    $('#ApproveAll').on('click',
        function (e) {

            alert("You have been subscribed to the Newsletter with the email - " + $("#email-text").val());

            var jsonObject = {
                "subId": 0,
                "subscriptionEmail": $("#email-text").val()
            };

            $.ajax({
                url: 'http://localhost:8081/api/SubscriptionObjs',
                type: "POST",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(jsonObject),
                traditional: true,
                statusCode: {
                    415: function () {
                        Response.redirect("/Admin/Index");
                    }
                },
                success: function (result) {
                    console.log(result);
                }
            });
            e.preventDefault();
        });


    $('#SubmitLogin').on('click',
        function (e) {
            if ($("#username").val() == "admin" && $("#password").val() == "123")
            {
                window.open('https://localhost:44386/admin-form.html', '_blank');
            }

        });
});
