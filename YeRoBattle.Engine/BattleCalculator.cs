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
            var damage = CalculateDamage(attacker);
            damage = damage - defender.Armor;

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

        public void Healing(Character character, Character target)
        {
            target.CurrentHealth = target.CurrentHealth + character.HealPower;
            _logger.WriteLine($@"character {character.Name} has healed {target.Name} by {character.HealPower}");

            if (target.CurrentHealth > target.Health)
            {
                target.CurrentHealth = target.Health;
            }

        }

        private int CalculateDamage(Character attacker)
        {
            var damage = attacker.Damage;
            var random = new Random().Next(100);

            if (random <= attacker.CriticalChance)
            {
                damage = damage * 2;
                _logger.WriteLine(@$"Attacker {attacker.Name} will hit CRITICALLY ");
            }

            return damage;

        }

       /*/ Not sure, that adding method for every buff right decision.
             Lets assume we have 100 different kinds of buffs =>
            we should have 100 properties and 100 methods and call them 1 by 1 to make it work properly.
            Also, we should think about adding names for every buff and might be a picture.
            Try to find another way to implement buff feature. => 
           Buff should have his own class with properties like name, side effect, iconpath, etc. Use array to store buffs. */

        public void PrepareForBattle(Character character)
        {
       character.
        }
        
    }
    
}
