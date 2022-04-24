using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeRoBattle.Engine.Models;
using YeRoBattle.BattleField.Models;

namespace YeRoBattle.BattleField.Engine
{
    public class MapCreator
    {
        private UserControl _userControl;
        private GameCondition _gameCondition;
        

        public bool Create(UserControl userControl, GameDetails gameDetails) 
        {
            _userControl = userControl;
            _gameCondition = new GameCondition(gameDetails);

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
                            Heal = team.Characters[i].Heal,
                          
                        };
                        var teamPosition = gameDetails.Map.TeamsPositons.Where(x => x.TeamId == team.Id).First();
                        gameCharacter.Position = teamPosition.Positions[i];
                        var controls = _userControl.Controls.Find(@$"{gameCharacter.Position.X},{gameCharacter.Position.Y}", true);
                        SetImage((Button)controls[0]);
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
            SetImage(button);

            _gameCondition.ActiveTeamId = _gameCondition.Teams.Where(x => x.Id != _gameCondition.ActiveTeamId).First().Id;
        }

        private void SetImage(Button button) 
        {
            button.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "Icons\\hero_2.png"));
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
