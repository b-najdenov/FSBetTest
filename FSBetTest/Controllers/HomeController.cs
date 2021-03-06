﻿using FSBetTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSBetTest.Controllers
{
    public class HomeController : Controller
    {
        private BetsDB db = new BetsDB();

        public ActionResult Index()
        {

            updateScores();
            List<Person> resultPeople = db.People.ToList();

            updateFromAPI();

            //return View(db.People.ToList());
            return View(resultPeople.OrderByDescending(x => x.Score));
        }

        private void updateFromAPI()
        {
            APIAccess aPIAccess = new APIAccess();
            RootObject result = aPIAccess.tryToFetch();

            result.Results
                .ForEach(resultItem =>
            {

                //check if home team exists
                if (db.Teams.Any(t => t.TeamID.Equals(resultItem.Home.IdTeam)) == false)
                {
                    Team team = new Team { TeamID = resultItem.Home.IdTeam, TeamName = resultItem.Home.TeamName[0].Description };
                    db.Teams.Add(team);
                    db.SaveChanges();
                }

                //check if away team exists
                if(db.Teams.Any(t => t.TeamID.Equals(resultItem.Away.IdTeam)) == false)
                {
                    Team team = new Team { TeamID = resultItem.Away.IdTeam, TeamName = resultItem.Away.TeamName[0].Description };
                    db.Teams.Add(team);
                    db.SaveChanges();
                }

            int gameID = Int32.Parse(resultItem.IdMatch);
                //check if it is not an existing game
                if (db.Games.Any(g => g.GameID == gameID) == false)

                 {
                    if (resultItem.HomeTeamScore != null)
                    {
                        string outcome = "x";
                        if (resultItem.HomeTeamScore > resultItem.AwayTeamScore)
                            outcome = "1";
                        else if (resultItem.HomeTeamScore < resultItem.AwayTeamScore)
                            outcome = "2";

                        Game game = new Game { GameID = Int32.Parse(resultItem.IdMatch), TeamAID = resultItem.Home.IdTeam, TeamBID = resultItem.Away.IdTeam, Outcome = outcome };
                        db.Games.Add(game);
                        db.SaveChanges();
                    }
                }
                //game.
            }
            );

        }

        private void updateScores()
        {

            db.People
                .ToList()
                .ForEach(personRow => 
                    {
                        int personScore = 0;
                        personRow.Bets
                            .ToList()
                            .ForEach(betRow =>
                                {
                                    if (betRow.Prediction.Equals(betRow.Game.Outcome))
                                    {
                                        personScore += betRow.Points;
                                    }
                                        
                                }
                            );
                        personRow.Score = personScore;
                    }
                );

            db.SaveChanges();

            //var peopleRows = from DataRow row in db.People.AsEnumerable()
            //                    select row;
        }

    }
}