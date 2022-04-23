using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeRoBattle.Engine.Models;

namespace YeRoBattle.BattleField.Models
{
    public class GameCharacter : Character
    {
        public Button Button { get; set; }

        public Position Position { get; set; } = new Position(0, 0);
    }
}
