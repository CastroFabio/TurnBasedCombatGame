using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedCombatGame.Models
{
    public class Paladin : Character
    {
        public bool HasDivineSmite = true;

        public Paladin(string name)
            : base(name) { }

        public override void ListaDeAcoes()
        {
            Console.WriteLine("1 - Basic Attack");
            Console.WriteLine("2 - Divine Smite");
        }

        public bool CanUseDivineSmite()
        {
            if (HasDivineSmite)
            {
                HasDivineSmite = false;
                return true;
            }
            return false;
        }

        public void DivineSmite(Character target)
        {
            AttackPowerMax += 10;
            BasicAttack(target);
            AttackPowerMax -= 10;
        }

        public override void PassouTurno()
        {
            HasDivineSmite = true;
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
                    if (CanUseDivineSmite())
                    {
                        Console.WriteLine("DIVINE SMITE!");
                        DivineSmite(target);
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
