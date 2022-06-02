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

            //if (target.CurrentHealth > target.Health)
            //{
            //    target.CurrentHealth = target.Health;
            //}

        }

        private int CalculateDamage(Character attacker)
        {
           
            
          var randomdamage = new Random().Next(attacker.MinDamage,attacker.Damage);
            var damage = randomdamage;
            attacker.Damage = damage;

            if (randomdamage <= attacker.CriticalChance)
            {
                damage = damage * 2;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                _logger.WriteLine(@$"Attacker {attacker.Name} will hit CRITICALLY ");
                Console.ResetColor();
            }
            return damage;

        }


        public void GetBuffs(Character character)
        {
            _logger.WriteLine($"{character.Name} Choose your Buff");
            _logger.WriteLine("1 - HealthBuff, 2 - DamageBuff, 3 - Armorbuff, 4 - Critbuff");

            string choise = Console.ReadLine();
            switch (choise)

            {
                case "1":
                    {
                        _logger.WriteLine($"HealthBuff - {character.Buffs[0].Name} ");
                        break;
                    }
                case "2":
                    {
                        _logger.WriteLine($"DamageBuff - {character.Buffs[1].Name} ");
                        break;
                    }
                case "3":
                    {
                        _logger.WriteLine($"Armorbuff - {character.Buffs[2].Name} ");
                        break;
                    }
                case "4":
                    {
                        _logger.WriteLine($"HealBuff - {character.Buffs[3].Name} ");
                        break;
                    }

            }


        }

        public  void ApplyBuffs(Character character)
        {


            var characterType = typeof(Character);
            //_logger.WriteLine(character.Armor + " " + character.Damage + " " + character.Armor + " " + character.Health);
            foreach (BUFF element in character.Buffs)
            {

                var Value = (int)character.GetType().GetProperty(element.AffectedTo).GetValue(character, null);

                character.GetType().GetProperty(element.AffectedTo).SetValue(character, element.Value + Value);

            }
           // _logger.WriteLine(character.Armor + " " + character.Damage + " " + character.Armor + " " + character.Health);

        }

        


    }
    }


