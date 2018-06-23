using FSBetTest.Models;
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

            //return View(db.People.ToList());
            return View(resultPeople.OrderByDescending(x => x.Score));
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