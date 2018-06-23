using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FSBetTest.Models
{
    public class BetsInitializer : DropCreateDatabaseAlways<BetsDB>
    {
        protected override void Seed(BetsDB context)
        {

            var people = new List<Person>
            {
                new Person {PersonName = "Bojan" },
                new Person {PersonName = "Mads"},
                new Person {PersonName = "Pernille"}
            };
            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game {GameID = 101, TeamAID = 1, TeamBID = 2, Outcome = "1"},
                new Game {GameID = 102, TeamAID = 1, TeamBID = 3, Outcome = "2"},
                new Game {GameID = 103, TeamAID = 1, TeamBID = 4, Outcome = "x"},
                new Game {GameID = 104, TeamAID = 2, TeamBID = 3, Outcome = "2"},
                new Game {GameID = 105, TeamAID = 2, TeamBID = 4, Outcome = "1"},
                new Game {GameID = 106, TeamAID = 3, TeamBID = 4, Outcome = "x"}
            };
            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();

            var teams = new List<Team>
            {
                new Team { TeamName = "Spain"},
                new Team { TeamName = "Denmark"},
                new Team { TeamName = "Macedonia"},
                new Team { TeamName = "Portugal"}
            };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();

            var bets = new List<Bet>
            {
                new Bet {PersonID = 1, GameID = 101, Points = 100, Prediction = "1"},
                new Bet {PersonID = 1, GameID = 102, Points = 125, Prediction = "x"},
                new Bet {PersonID = 1, GameID = 103, Points = 150, Prediction = "x"},
                new Bet {PersonID = 1, GameID = 104, Points = 90, Prediction = "2"},
                new Bet {PersonID = 1, GameID = 105, Points = 80, Prediction = "1"},
                new Bet {PersonID = 1, GameID = 106, Points = 70, Prediction = "x"},

                new Bet {PersonID = 2, GameID = 101, Points = 125, Prediction = "2"},
                new Bet {PersonID = 2, GameID = 102, Points = 90, Prediction = "x"},
                new Bet {PersonID = 2, GameID = 103, Points = 110, Prediction = "2"},
                new Bet {PersonID = 2, GameID = 104, Points = 150, Prediction = "1"},
                new Bet {PersonID = 2, GameID = 105, Points = 70, Prediction = "1"},
                new Bet {PersonID = 2, GameID = 106, Points = 80, Prediction = "x"},

                new Bet {PersonID = 3, GameID = 101, Points = 80, Prediction = "x"},
                new Bet {PersonID = 3, GameID = 102, Points = 100, Prediction = "x"},
                new Bet {PersonID = 3, GameID = 103, Points = 150, Prediction = "1"},
                new Bet {PersonID = 3, GameID = 104, Points = 90, Prediction = "x"},
                new Bet {PersonID = 3, GameID = 105, Points = 110, Prediction = "1"},
                new Bet {PersonID = 3, GameID = 106, Points = 70, Prediction = "x"},
            };
            bets.ForEach(s => context.Bets.Add(s));
            context.SaveChanges();


        }
    }
}