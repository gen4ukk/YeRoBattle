using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Engine.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public bool IsDead { get; set; }
        public int HealPower { get; set; }
    }
}
