using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedCombatGame.Models
{
    public class Character
    {
        private static Random random = new Random();
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int AttackPowerMax { get; set; }
        public int AttackPowerMin { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public Character(string name)
        {
            Name = name;
            AttackPowerMin = random.Next(10, 21);
            AttackPowerMax = random.Next(AttackPowerMin, AttackPowerMin + 31);
            Defense = random.Next(5, 16);
            Speed = random.Next(1, 21);
            MaxHitPoints = 100;
            HitPoints = MaxHitPoints;
        }

        public bool IsAlive()
        {
            return HitPoints > 0;
        }

        public bool IsCriticalHit()
        {
            return random.Next(1, 21) == 20 ? true : false;
        }

        public void BasicAttack(Character target)
        {
            bool isCritical = IsCriticalHit();

            int AttackPower = isCritical
                ? random.Next(AttackPowerMin, AttackPowerMax + 1) * 2
                : random.Next(AttackPowerMin, AttackPowerMax + 1);

            int damage = AttackPower - target.Defense;

            Console.WriteLine(isCritical ? "CRITICAL HIT!" : "");
            Console.WriteLine(
                $"{Name} (ATK: {AttackPower}) vs {target.Name} (DEF: {target.Defense})"
            );

            if (damage < 0)
                damage = 1;
            target.HitPoints -= damage;

            if (target.HitPoints < 0)
                target.HitPoints = 0;
        }

        public void Apresentar()
        {
            Console.WriteLine(
                $"{Name.ToUpper()}\nHP: {HitPoints}/{MaxHitPoints}\nAtaque Max: {AttackPowerMax}\nAtaque Min: {AttackPowerMin}\nDefesa: {Defense}\nVelocidade: {Speed}"
            );
        }

        public void ApresentarSimplificado()
        {
            Console.WriteLine($"Nome: {Name.ToUpper()} ({HitPoints}/{MaxHitPoints})");
        }

        public virtual void ListaDeAcoes() { }

        public virtual void EscolherAcoes(Character target) { }

        public virtual void PassouTurno() { }
    }
}
