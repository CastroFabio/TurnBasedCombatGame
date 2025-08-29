using TurnBasedCombatGame.Models;

Paladin paladin = new Paladin("Uther");
Fighter fighter = new Fighter("Garrosh");

Dragon dragon = new Dragon("Deathwing");

Random random = new Random();

List<Character> characters = new List<Character> { paladin, fighter };

void IsAttacking(Character attacker, Character target)
{
    attacker.EscolherAcoes(target);
    Console.WriteLine($"{attacker.Name} atacou {target.Name}!");
    target.ApresentarSimplificado();
    Console.WriteLine();
}

Console.WriteLine("=== Personagens ===");
fighter.Apresentar();
Console.WriteLine();
paladin.Apresentar();
Console.WriteLine();
dragon.Apresentar();
Console.WriteLine();

Console.WriteLine("Para iniciar o combate, pressione ENTER");
Console.ReadKey(true);
Console.Clear();

Console.WriteLine("=== Combate ===");
int rodada = 1;
int maxCountTarget = 2;
while ((fighter.IsAlive() || paladin.IsAlive()) && dragon.IsAlive())
{
    Console.WriteLine($"--------- Rodada {rodada} ---------");

    Character target = characters[random.Next(0, maxCountTarget)];

    dragon.BasicAttack(target);
    Console.WriteLine($"{dragon.Name} atacou {target.Name}!");
    target.ApresentarSimplificado();
    Console.WriteLine();
    if (!target.IsAlive())
    {
        Console.WriteLine($"{target.Name} foi derrotado!");
        Console.WriteLine();
        characters.Remove(target);
        maxCountTarget -= 1;
    }

    if (fighter.IsAlive())
        IsAttacking(fighter, dragon);
    if (paladin.IsAlive())
        IsAttacking(paladin, dragon);

    paladin.PassouTurno();
    fighter.PassouTurno();

    rodada++;

    Console.WriteLine("Para passar a rodada, pressione ENTER");
    Console.ReadKey(true);
    Console.Clear();
}
