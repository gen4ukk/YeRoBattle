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
        public void StartGameBuffs(Character character)
        {
            
            //idk what logic should be here ...(character = character + character.Buff;)  ???
        }
    }

}
