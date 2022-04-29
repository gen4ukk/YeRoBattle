using YeRoBattle.Engine.Models;
using YeRoBattle.BattleField.Models;
using Microsoft.Extensions.Configuration;

namespace YeRoBattle.BattleField.Engine
{
    public class MapCreator
    {
        private UserControl _userControl;
        private GameCondition _gameCondition;
        private GameConfig _gameConfig;

        public bool Create(UserControl userControl, GameDetails gameDetails) 
        {
            _userControl = userControl;
            _gameCondition = new GameCondition(gameDetails);

            if (_gameConfig == null)
            {
                _gameConfig = Program.Configuration.GetSection("GameConfig").Get<GameConfig>();
            }    

            try
            {
                var buttonHeight = userControl.Height / gameDetails.Map.Height;
                var buttonWidth = userControl.Width / gameDetails.Map.Width;
                for (int i = 0; i < gameDetails.Map.Height; i++)
                {
                    for (int j = 0; j < gameDetails.Map.Width; j++)
                    {

                        var button = new Button()
                        {
                            Location = new Point(j * buttonWidth, i * buttonHeight),
                            Height = buttonHeight,
                            Width = buttonWidth,
                            Name = @$"{i},{j}",
                            ImageAlign = ContentAlignment.MiddleCenter
                        };
                        button.Click += button1_Click;
                        SetTexture(button);

                        userControl.Controls.Add(button);
                    }
                }

                //create characters
                foreach (var team in gameDetails.Teams)
                {
                    var gameTeam = new GameTeam();
                    gameTeam.Id = team.Id;
                    _gameCondition.Teams.Add(gameTeam);

                    for (int i = 0; i < team.Characters.Count; i++)
                    {
                        GameCharacter gameCharacter = new GameCharacter 
                        {
                            Name = team.Characters[i].Name,
                            Armor = team.Characters[i].Armor,
                            Damage = team.Characters[i].Damage,
                            Health = team.Characters[i].Health,
                            CurrentHealth = team.Characters[i].CurrentHealth,
                            IsDead = team.Characters[i].IsDead,
                            HealPower = team.Characters[i].HealPower,
                          
                        };
                        var teamPosition = gameDetails.Map.TeamsPositons.Where(x => x.TeamId == team.Id).First();
                        gameCharacter.Position = teamPosition.Positions[i];
                        var controls = _userControl.Controls.Find(@$"{gameCharacter.Position.X},{gameCharacter.Position.Y}", true);

                        gameCharacter.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), _gameConfig.TeamsIcons.Where(x=> x.TeamId == team.Id).First().IconPath));
                        ((Button)controls[0]).Image = gameCharacter.Image;
                        gameTeam.Characters.Add(gameCharacter);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var activeCharacter = _gameCondition.Teams.Where(x => x.Id == _gameCondition.ActiveTeamId).First().Characters.First();
            var control = _userControl.Controls.Find(@$"{activeCharacter.Position.X},{activeCharacter.Position.Y}", true);
            RemoveImage((Button)control[0]);

            var button = (Button)sender;
            activeCharacter.Position.X = Convert.ToInt32(button.Name.Split(",")[0]);
            activeCharacter.Position.Y = Convert.ToInt32(button.Name.Split(",")[1]);
            
            button.Image = activeCharacter.Image;

            _gameCondition.ActiveTeamId = _gameCondition.Teams.Where(x => x.Id != _gameCondition.ActiveTeamId).First().Id;
        }

        private void RemoveImage(Button button)
        {
            button.Image = null;
        }

        private void SetTexture(Button button)
        {
            button.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "Icons\\texture.png"));
        }
    }
}
