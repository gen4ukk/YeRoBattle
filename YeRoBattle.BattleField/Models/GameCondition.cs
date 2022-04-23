using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YeRoBattle.Engine.Models;

namespace YeRoBattle.BattleField.Models
{
    public class GameCondition
    {
        public GameCondition(GameDetails gameDetails)
        {
            this.ActiveTeamId = gameDetails.ActiveTeamId;
        }

        public int ActiveTeamId { get; set; }
        public List<GameTeam> Teams { get; set; } = new List<GameTeam>();
    }
}
