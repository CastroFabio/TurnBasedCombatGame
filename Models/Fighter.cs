using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedCombatGame.Models
{
    public class Fighter : Character
    {
        bool HasActionSurge = true;
        bool HasExtraAttack = true;

        public Fighter(string name)
            : base(name) { }

        public bool CanUseExtraAttack()
        {
            if (HasExtraAttack)
            {
                HasExtraAttack = false;
                return true;
            }
            return false;
        }

        public void ExtraAttack(Character target)
        {
            int temp = AttackPowerMin;
            if (AttackPowerMin + 10 > AttackPowerMax)
            {
                AttackPowerMin = AttackPowerMax - 1;
                BasicAttack(target);
                AttackPowerMin = temp;

                return;
            }
            AttackPowerMin += 10;
            BasicAttack(target);
            AttackPowerMin -= 10;
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
            HasExtraAttack = true;
            HasActionSurge = true;
        }

        public void EscolherAcoes(Character target)
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
                    if (CanUseExtraAttack())
                    {
                        Console.WriteLine("Usando Extra Attack!");
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
