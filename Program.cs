using TurnBasedCombatGame.Models;

Character vilao = new Character("Sauron", "Vilão");
Character heroi = new Character("Aragorn", "Herói");

Console.WriteLine("=== Personagens ===");
heroi.Apresentar();
Console.WriteLine();
vilao.Apresentar();
Console.WriteLine();

while (heroi.IsAlive() && vilao.IsAlive())
{
    heroi.Attack(vilao);
    Console.WriteLine($"{heroi.Name} atacou {vilao.Name}!");
    vilao.ApresentarSimplificado();
    Console.WriteLine();

    vilao.Attack(heroi);
    Console.WriteLine($"{vilao.Name} atacou {heroi.Name}!");
    heroi.ApresentarSimplificado();
    Console.WriteLine();
}
