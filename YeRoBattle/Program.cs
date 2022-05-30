using YeRoBattle.Engine.Models;
using YeRoBattle.Engine;
using YeRoBattle.Logger;


ILogger logger = new ConsoleLogger();

logger.WriteLine(Environment.NewLine);

Character character1 = new Character
{
    Name = "Yevhen",                //character1.Name = "Yevhen";
    Health = 100,                   //character1.Health = 100;
    CurrentHealth = 100,
    Armor = 4,
    Damage = 10,
    HealPower = 2,
    CriticalChance = 10,
    
};

#region BUFFS Character1
BUFF c1bUFF1 = new BUFF(); //c1 - character1
BUFF c1bUFF2 = new BUFF();
BUFF c1bUFF3 = new BUFF();
BUFF c1bUFF4 = new BUFF();
BUFF c1bUFF5 = new BUFF();

c1bUFF1.Name = "Healthbuff";
c1bUFF2.Name = "Damagebuff";
c1bUFF3.Name = "Armorbuff";
c1bUFF4.Name = "Healbuff";
c1bUFF4.Name = "Critbuff";
    
c1bUFF1.Value = 2;
c1bUFF2.Value = 2;
c1bUFF3.Value = 2;
c1bUFF4.Value = 2;
c1bUFF5.Value = 2;
    
c1bUFF1.AffectedTo = "Health";
c1bUFF1.AffectedTo = "CurrentHealth";
c1bUFF2.AffectedTo = "Damage";
c1bUFF3.AffectedTo = "Armor";
c1bUFF4.AffectedTo = "HealPower";
c1bUFF5.AffectedTo = "CriticalChance";

character1.Buffs.Add(c1bUFF1);
character1.Buffs.Add(c1bUFF2);
character1.Buffs.Add(c1bUFF3);
character1.Buffs.Add(c1bUFF4);
character1.Buffs.Add(c1bUFF5);
#endregion



Character character2 = new Character
{
    Name = "Roman",
    Health = 100,
    CurrentHealth = 100,
    Armor = 2,
    Damage = 12,
    HealPower = 2,
    CriticalChance = 60,

};

#region BUFFS Character2
BUFF c2bUFF1 = new BUFF();   // c2 - Character2
BUFF c2bUFF2 = new BUFF();
BUFF c2bUFF3 = new BUFF();
BUFF c2bUFF4 = new BUFF();
BUFF c2bUFF5 = new BUFF();

c2bUFF1.Name = "Healthbuff";
c2bUFF2.Name = "Damagebuff";
c2bUFF3.Name = "Armorbuff";
c2bUFF4.Name = "Healbuff";
c2bUFF4.Name = "Critbuff";

c2bUFF1.Value = 2;
c2bUFF2.Value = 2;
c2bUFF3.Value = 2;
c2bUFF4.Value = 2;
c2bUFF5.Value = 2;

c2bUFF1.AffectedTo = "Health";
c2bUFF1.AffectedTo = "CurrentHealth";
c2bUFF2.AffectedTo = "Damage";
c2bUFF3.AffectedTo = "Armor";
c2bUFF4.AffectedTo = "HealPower";
c2bUFF5.AffectedTo = "CriticalChance";

character2.Buffs.Add(c2bUFF1);
character2.Buffs.Add(c2bUFF2);
character2.Buffs.Add(c2bUFF3);
character2.Buffs.Add(c2bUFF4);
character2.Buffs.Add(c2bUFF5);
#endregion


var battleCalculator = new BattleCalculator(logger);

logger.WriteLine(@$"Battle: {character1.Name} VS {character2.Name}");

var attacker = character1;
var defender = character2;
var round = 1;

battleCalculator.GetBuffs(character1);
battleCalculator.GetBuffs(character2);
battleCalculator.ApplyBuffs(character1);
battleCalculator.ApplyBuffs(character2);


while (!character1.IsDead && !character2.IsDead)
{
    logger.WriteLine(@$"Round {round} Attacker {attacker.Name} {attacker.CurrentHealth} Defender {defender.Name} {defender.CurrentHealth}");
    round++;

    battleCalculator.Hit(attacker, defender);
    battleCalculator.Healing(attacker, attacker); // (second attacker is the target to heal)

    
    var switcher = attacker;
    attacker = defender;
    defender = switcher;
}

if (!character1.IsDead)
{
    logger.WriteLine(@$"Winner {character1.Name}");
}
else
{
    logger.WriteLine(@$"Winner {character2.Name}");
}