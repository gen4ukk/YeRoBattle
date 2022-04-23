using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Engine.Models
{
    public class Team
    {
        public int Id { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
