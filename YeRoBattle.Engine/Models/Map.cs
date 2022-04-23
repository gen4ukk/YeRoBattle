using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Engine.Models
{
    public class Map
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public List<TeamsPositons> TeamsPositons { get; set; } = new List<TeamsPositons>();
    }
}
