using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSBetTest.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required]
        public string PersonName { get; set; }

        public int Score { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}