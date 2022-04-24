﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeRoBattle.Engine.Models;
using YeRoBattle.Logger;

namespace YeRoBattle.Engine
{
    public class BattleCalculator
    {
        public BattleCalculator(ILogger logger)
        {
            _logger = logger;
        }

        private ILogger _logger;

        public void Hit(Character attacker, Character defender) 
        {
            var damage = attacker.Damage - defender.Armor;

            if (damage > 0)
            {
                _logger.WriteLine($@"Attacker {attacker.Name} hit {defender.Name} by {damage}");
                defender.CurrentHealth = defender.CurrentHealth - damage;
            }

            if (defender.CurrentHealth <= 0)
            {
                defender.IsDead = true;
            }
        }
        public void Healing(Character character)
        {
            var heal = character.HealPower;


            if (heal > 0)
            {
                character.Health = character.Health + heal;
            }

            if (character.CurrentHealth == character.Health)
            {
                character.HealPower = 0;
            }
            else
            {
                character.Health = character.Health + heal;
            }



        }
    }
}
