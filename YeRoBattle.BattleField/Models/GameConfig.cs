namespace YeRoBattle.BattleField.Models
{
    internal class GameConfig
    {
        public List<TeamsIcon> TeamsIcons { get; set; }
    }

    internal class TeamsIcon
    {
        public int TeamId { get; set; }
        public string IconPath { get; set; }
    }
}
