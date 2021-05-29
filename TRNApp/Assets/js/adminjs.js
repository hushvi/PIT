$(document).ready(function () {
    $('#SubmitNews').on('click',
        function (e) {

            alert("News added");

            var jsonObject = {
                "newsId": 0,
                "title": $("#add-news-title").val(),
                "body": $("#add-news-text").val(),
                "publishedDate": "2021-05-29T09:02:43.989Z"
            };

            $.ajax({
                url: 'http://localhost:8084/api/NewsObjs',
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

    // TEAMS
    $('#SubmitTeam').on('click',
        function (e) {

            var alterTeam = getByKey(teamMap, $("#add-team-name").val());

            var jsonObject = {
                "teamId": alterTeam,
                "teamName": $("#add-team-name").val(),
                "teamAbr": $("#add-team-abr").val(),
                "teamGroup": $("#add-team-group").val(),
                "gamesPlayed": parseInt($("#add-gp").val(), 10),
                "goalsScored": parseInt($("#add-gs").val(), 10),
                "goalsAgainst": parseInt($("#add-ga").val(), 10),
                "points": parseInt($("#add-p").val(), 10)
            };

            if (alterTeam) {
                alert("Team info changed");

                $.ajax({
                    url: 'http://localhost:8082/api/TeamObjs/' + alterTeam,
                    type: "PUT",
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(jsonObject),
                    traditional: true,
                    statusCode: {
                        415: function () {
                            Response.redirect("/Admin/Index");
                        }
                    },
                });
                e.preventDefault();
            }
            else
            {
                alert("Team added");

                $.ajax({
                    url: 'http://localhost:8082/api/TeamObjs',
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
            }
        });

    $('#DeleteTeam').on('click',
        function (e) {

            alert("Team deleted");
            var alterTeam = getByKey(teamMap, $("#delete-team").val());

            if (alterTeam)
            {
                $.ajax({
                    url: 'http://localhost:8082/api/TeamObjs/' + alterTeam,
                    type: "DELETE",
                    contentType: "application/json;charset=utf-8",
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

            }

        });

    // players
    $('#SubmitPlayer').on('click',
        function (e) {

            alert("Player added");

            var alterTeam = getByKey(teamMap, $("#add-player-club").val());

            var jsonObject = {
                "playerId": 0,
                "playerName": $("#add-player-name").val(),
                "playerLastName": $("#add-player-surname").val(),
                "playerNumber": $("#add-player-nr").val(),
                "playerBirthData": "2021-05-29T09:02:43.989Z",
                "playerPosition": $("#add-player-pos").val(),
                "clubId": alterTeam,
                "goals": 0,
                "assists": 0,
                "penaltyMinutes": 0

            };

            $.ajax({
                url: 'http://localhost:8082/api/PlayerObjs',
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

    $('#DeletePlayer').on('click',
        function (e) {

            alert("Player deleted");

            $.ajax({
                url: 'http://localhost:8082/api/PlayerObjs/' + $("#delete-player").val(),
                type: "DELETE",
                contentType: "application/json;charset=utf-8",
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

    // Games
    $('#SubmitGame').on('click',
        function (e) {

            alert("Game added");

            var fTeam = getByKey(teamMap, $("#add-game-id1").val());
            var sTeam = getByKey(teamMap, $("#add-game-id2").val());

            var jsonObject = {
                "gameId": 0,
                "firstTeamId": fTeam,
                "secondTeamId": sTeam,
                "firstTeamGoals": $("#add-game-goals1").val(),
                "secondTeamGoals": $("#add-game-goals2").val(),
                "overtime": $("#add-overtime").val(),
                "startingTime": "2021-05-29T10:03:22.707Z",
                "gameType": $("#add-game-type").val(),
                "finished": $("#add-finished").val()
            };

            $.ajax({
                url: 'http://localhost:8083/api/GamesObjs',
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
            
            // Change team scores

            var fTeamData;
            var sTeamData;

            // Get both teams
            
            $.ajax({
                type: "GET",
                url: 'http://localhost:8082/api/TeamObjs/' + fTeam,
                contentType: "application/json",
                dataType: "json",
                async: false,
                success: function (data) {
                    fTeamData = data;
                    alert(data.teamName);
                },
                failure: function (response) {
                    alert("Error");
                }
            });
            $.ajax({
                type: "GET",
                url: 'http://localhost:8082/api/TeamObjs/' + sTeam,
                contentType: "application/json",
                dataType: "json",
                async: false,
                success: function (data) {
                    sTeamData = data;
                    alert(data.teamName);
                },
                failure: function (response) {
                    alert("Error");
                }
            });
            


            var fTeamPoints;
            var sTeamPoints;
            if ($("#add-game-goals1").val() > $("#add-game-goals2").val()) {
                fTeamPoints = 3;
                sTeamPoints = 0;
            }
            else if ($("#add-game-goal21").val() > $("#add-game-goals1").val()) {
                fTeamPoints = 1;
                sTeamPoints = 3;
            }
            else
            {
                fTeamPoints = 1;
                sTeamPoints = 1;
            }

            alert(fTeamData.teamName);
            alert(sTeamData.teamName);


            // Change first team
            var teamJsonObject = {
                "teamId": fTeam,
                "teamName": fTeamData.teamName,
                "teamAbr": fTeamData.teamAbr,
                "teamGroup": fTeamData.teamGroup,
                "gamesPlayed": fTeamData.gamesPlayed + 1,
                "goalsScored": fTeamData.goalsScored + $("#add-game-goals1").val(),
                "goalsAgainst": fTeamData.goalsAgainst + $("#add-game-goals2").val(),
                "points": fTeamData.points + fTeamPoints
            };

            $.ajax({
                url: 'http://localhost:8082/api/TeamObjs/' + fTeam,
                type: "PUT",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(teamJsonObject),
                traditional: true,
                statusCode: {
                    415: function () {
                        Response.redirect("/Admin/Index");
                    }
                },
            });
            e.preventDefault();

            // Change second team
            var teamJsonObject = {
                "teamId": sTeam,
                "teamName": sTeamData.teamName,
                "teamAbr": sTeamData.teamAbr,
                "teamGroup": sTeamData.teamGroup,
                "gamesPlayed": sTeamData.gamesPlayed + 1,
                "goalsScored": sTeamData.goalsScored + $("#add-game-goals2").val(),
                "goalsAgainst": sTeamData.goalsAgainst + $("#add-game-goals1").val(),
                "points": sTeamData.points + sTeamPoints
            };

            $.ajax({
                url: 'http://localhost:8082/api/TeamObjs/' + sTeam,
                type: "PUT",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(teamJsonObject),
                traditional: true,
                statusCode: {
                    415: function () {
                        Response.redirect("/Admin/Index");
                    }
                },
            });
            e.preventDefault();
            
        });

    $('#DeleteGame').on('click',
        function (e) {

            alert("Game deleted");

            $.ajax({
                url: 'http://localhost:8082/api/GamesObjs/' + $("#delete-game").val(),
                type: "DELETE",
                contentType: "application/json;charset=utf-8",
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


});

