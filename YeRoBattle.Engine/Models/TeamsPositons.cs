using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Engine.Models
{
    public class TeamsPositons
    {
        public int TeamId { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
