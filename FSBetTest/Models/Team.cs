using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSBetTest.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TeamID { get; set; }

        public string TeamName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}