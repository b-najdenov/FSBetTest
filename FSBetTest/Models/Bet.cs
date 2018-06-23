using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSBetTest.Models
{
    public class Bet
    {
        public int BetID { get; set; }
        public int GameID { get; set; }
        public int PersonID { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public string Prediction { get; set; }

        public virtual Person Person { get; set; }
        public virtual Game Game { get; set; }
    }
}