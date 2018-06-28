using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSBetTest.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameID { get; set; }

        public string TeamAID { get; set; }
        public string TeamBID { get; set; }

        [Required]
        public string Outcome { get; set; }

        public virtual Team TeamA { get; set; }
        public virtual Team TeamB { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }

    //public class CheckValidOutcome : ValidationAttribute
    //{
    //    public CheckValidOutcome()
    //    {
    //        ErrorMessage = "Valid values are 1, 2 and x";
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        char outcome = (char) value;
    //        List<char> validValues = new List<char> { '1', '2', 'x' };

    //        if (validValues.Contains(outcome))
    //            return true;
    //        else
    //            return false;
    //    }
    //}
}