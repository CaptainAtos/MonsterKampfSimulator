using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator.Monsters

{
    public abstract class Monster
    {
        public string Name;
        public float CurrentHP; // Aktuelle HP
        public float AP; // Angriffspunkte
        public float DP; // Verteildigungspunkte
        public float SP; // Geschwindigkeitspunkte
        public const int DamageMultiplier = 2;

        public bool IsAlive => CurrentHP > 0;

        public Monster(string _name, float _currentHP, float _AP, float _DP, float _SP)
        {
            Name = _name;
            CurrentHP = _currentHP;
            AP = _AP;
            DP = _DP;
            SP = _SP;
        }

        public virtual void Attack(Monster _defender)
        {
            float _dmg = AP / _defender.DP * 2;
            _defender.TakeDamage(_dmg);
        }

        public virtual void TakeDamage(float _dmg)
        {
            CurrentHP -= _dmg;
            MakeNoise(_dmg);
        }

        public virtual void MakeNoise(float _dmg) 
        {
            Console.Write($"Dem Monster {Name} wurde ");
            OutputHelpers.WriteInColor($"{_dmg}", ConsoleColor.DarkRed);
            Console.Write(" Schaden gemacht und es hat noch ");
            OutputHelpers.WriteInColor($" {CurrentHP} ",ConsoleColor.Green);
            Console.WriteLine("HP.");
        }
    }
}
