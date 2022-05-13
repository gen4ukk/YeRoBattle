using YeRoBattle.Engine.Models;
using YeRoBattle.Engine;
using YeRoBattle.Logger;

// ghth
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
#region  BUFFS_For_CHARACTER1
Buff c1buff1 = new Buff
{
    Healthbuff = character1.Health + 10,
};
Buff c1buff2 = new Buff
{
    Damagebuff = character1.Damage + 1,
};
Buff c1buff3 = new Buff
{
    Armorbuff = character1.Armor + 10,
};
Buff c1buff4 = new Buff
{
    CriticalChancebuff = character1.CriticalChance + 10,
};
Buff c1buff5 = new Buff
{
    HealPowerbuff = character1.HealPower + 10,
};
character1.Buffs.Add(c1buff1);
character1.Buffs.Add(c1buff2);
character1.Buffs.Add(c1buff3);
character1.Buffs.Add(c1buff4);
character1.Buffs.Add(c1buff5);
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
#region BUFFS_FOR_CHARACTER2
Buff c2buff1 = new Buff
{
    Healthbuff = character2.Health + 10,
};
Buff c2buff2 = new Buff
{
    Damagebuff = character2.Damage + 1,
};
Buff c2buff3 = new Buff
{
    Armorbuff = character2.Armor + 10,
};
Buff c2buff4 = new Buff
{
    CriticalChancebuff = character2.CriticalChance + 10,
};
Buff c2buff5 = new Buff
{
    HealPowerbuff = character2.HealPower + 10,
};
character2.Buffs.Add(c2buff1);
character2.Buffs.Add(c2buff2);
character2.Buffs.Add(c2buff3);
character2.Buffs.Add(c2buff4);
character2.Buffs.Add(c2buff5);
#endregion

var battleCalculator = new BattleCalculator(logger);

logger.WriteLine(@$"Battle: {character1.Name} VS {character2.Name}");

var attacker = character1;
var defender = character2;
var round = 1;
//place for the buffs method
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