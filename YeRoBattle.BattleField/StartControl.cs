using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YeRoBattle.Engine.Models;

namespace YeRoBattle.BattleField
{
    public partial class StartControl : UserControl
    {
        public StartControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var map = new Map() { Height = 5, Width = 7 };
            var team1 = new Team();
            team1.Id = 1;
            team1.Characters.Add(new Character() { Step = 1});
            var teamsPosition1 = new TeamsPositons();
            teamsPosition1.TeamId = team1.Id;
            teamsPosition1.Positions.Add(new Position(0, 0));

            var team2 = new Team();
            team2.Id = 2;
            team2.Characters.Add(new Character() { Step = 2 });
            var teamsPosition2 = new TeamsPositons();
            teamsPosition2.TeamId = team2.Id;
            teamsPosition2.Positions.Add(new Position(0, 6));

            map.TeamsPositons.Add(teamsPosition1);
            map.TeamsPositons.Add(teamsPosition2);

            var gameDetails = new GameDetails 
            {
                ActiveTeamId = team1.Id,
                Map = map,
            };

            gameDetails.Teams.Add(team1);
            gameDetails.Teams.Add(team2);

            this.ParentForm.Controls.Add(new MapControl(gameDetails));
        }
    }
}
