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
    Heal = 10,
};

Character character2 = new Character
{
    Name = "Roman",
    Health = 100,
    CurrentHealth = 100,
    Armor = 2,
    Damage = 12,
    Heal = 10,
};

var battleCalculator = new BattleCalculator(logger);

logger.WriteLine(@$"Battle: {character1.Name} VS {character2.Name}");

var attacker = character1;
var defender = character2;
var round = 1;

while (!character1.IsDead && !character2.IsDead)
{
    logger.WriteLine(@$"Round {round} Attacker {attacker.Name} {attacker.CurrentHealth} Defender {defender.Name} {defender.CurrentHealth}");
    round++;

    battleCalculator.Hit(attacker, defender);

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