using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Engine.Models
{
    public class GameDetails
    {
        public int ActiveTeamId { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public Map Map { get; set; }
    }
}
