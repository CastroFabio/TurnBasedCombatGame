using TurnBasedCombatGame.Models;

Paladin vilao = new Paladin("Sauron");
Fighter heroi = new Fighter("Aragorn");

Console.WriteLine("=== Personagens ===");
heroi.Apresentar();
Console.WriteLine();
vilao.Apresentar();
Console.WriteLine();

Console.WriteLine("Para iniciar o combate, pressione ENTER");
Console.ReadKey(true);
Console.Clear();
Console.WriteLine("=== Combate ===");
int rodada = 1;
while (heroi.IsAlive() && vilao.IsAlive())
{
    Console.WriteLine($"--------- Rodada {rodada} ---------");

    heroi.EscolherAcoes(vilao);
    Console.WriteLine($"{heroi.Name} atacou {vilao.Name}!");
    vilao.ApresentarSimplificado();
    Console.WriteLine();

    vilao.EscolherAcoes(heroi);
    Console.WriteLine($"{vilao.Name} atacou {heroi.Name}!");
    heroi.ApresentarSimplificado();
    Console.WriteLine();

    vilao.PassouTurno();
    heroi.PassouTurno();

    rodada++;

    Console.WriteLine("Para iniciar o combate, pressione ENTER");
    Console.ReadKey(true);
    Console.Clear();
}
