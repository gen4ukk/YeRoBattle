using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.BattleField.Models
{
    public class GameTeam
    {
        public int Id { get; set; }
        public List<GameCharacter> Characters { get; set; } = new List<GameCharacter>();
    }
}
