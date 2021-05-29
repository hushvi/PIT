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

            alert("Team added");

            var jsonObject = {
                "teamId": 0,
                "teamName": $("#add-team-name").val(),
                "teamAbr": $("#add-team-abr").val(),
                "teamGroup": $("#add-team-group").val(),
                "gamesPlayed": 0,
                "goalsScored": 0,
                "goalsAgainst": 0,
                "points": 0
            };

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

        });

    $('#DeleteTeam').on('click',
        function (e) {

            alert("Team added");


            $.ajax({
                url: 'http://localhost:8082/api/TeamObjs/' + $("#delete-team").val(),
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

    // players
    $('#SubmitPlayer').on('click',
        function (e) {

            alert("Player added");

            var jsonObject = {
                "playerId": 0,
                "playerName": $("#add-player-name").val(),
                "playerLastName": $("#add-player-surname").val(),
                "playerNumber": $("#add-player-nr").val(),
                "playerBirthData": "2021-05-29T09:02:43.989Z",
                "playerPosition": $("#add-player-pos").val(),
                "clubId": $("#add-player-club").val(),
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

            alert("Team added");


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
    $('#SubmitPlayer').on('click',
        function (e) {

            alert("Game added");

            var jsonObject = {
                "gameId": 0,
                "firstTeamId": $("#add-game-id1").val(),
                "secondTeamId": $("#add-game-id2").val(),
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