using System.Text.Json.Serialization;

namespace YeRoBattle.BattleField.Models
{
    internal class GameConfig
    {
        [JsonInclude]
        public TeamsIcon[] TeamsIcons { get; set; }
    }

    internal class TeamsIcon
    {
        [JsonInclude]
        public int TeamId { get; set; }
        [JsonInclude]
        public string IconPath { get; set; }
    }
}
