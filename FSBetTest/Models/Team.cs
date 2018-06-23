using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSBetTest.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}