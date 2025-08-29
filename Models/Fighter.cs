using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedCombatGame.Models
{
    public class Fighter : Character
    {
        bool HasActionSurge = true;
        int ExtraAttackCount = 2;
        bool HasExtraAttack = true;

        public Fighter(string name)
            : base(name) { }

        public void ExtraAttack(Character target)
        {
            int temp = AttackPowerMax;
            ExtraAttackCount = 0;
            HasExtraAttack = false;
            if (AttackPowerMax - 5 < AttackPowerMin)
            {
                BasicAttack(target);
                AttackPowerMax = AttackPowerMin + 1;
                BasicAttack(target);
                AttackPowerMax = temp;

                return;
            }

            BasicAttack(target);
            AttackPowerMax -= 5;
            BasicAttack(target);
            AttackPowerMax += 5;
        }

        public void ActionSurge(Character target)
        {
            if (HasActionSurge)
            {
                HasActionSurge = false;

                BasicAttack(target);
                return;
            }
            Console.WriteLine($"{Name} já usou Action Surge e não pode usar novamente.");
        }

        public override void ListaDeAcoes()
        {
            Console.WriteLine("1 - Basic Attack");
            Console.WriteLine("2 - Extra Attack");
        }

        public override void PassouTurno()
        {
            if (ExtraAttackCount <= 2)
                ExtraAttackCount++;
            if (ExtraAttackCount == 2)
                HasExtraAttack = true;
        }

        public override void EscolherAcoes(Character target)
        {
            ListaDeAcoes();
            Console.WriteLine($"Qual ataque você deseja usar?");
            string escolha = Console.ReadLine() ?? "1";
            Console.WriteLine();
            switch (escolha)
            {
                case "1":
                    BasicAttack(target);
                    break;
                case "2":
                    if (HasExtraAttack)
                    {
                        Console.WriteLine("Extra Attack!");
                        ExtraAttack(target);
                        break;
                    }
                    BasicAttack(target);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Usando Basic Attack. ");
                    BasicAttack(target);
                    break;
            }
        }
    }
}
