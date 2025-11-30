using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator.Monster

{
    public abstract class _Monster
    {
        public string Name;
        public bool IsGoblin;
        public bool IsOrk;
        public float CurrentHP; // Aktuelle HP
        public float AP; // Angriffspunkte
        public float DP; // Verteildigungspunkte
        public float SP; // Geschwindigkeitspunkte
        
        public bool IsAlive => CurrentHP > 0;

        public List<_Monster> m_availableMonsters = new List<_Monster>();
        public List<_Monster> m_selectedMonsters = new List<_Monster>();

        public _Monster(string _name, float _currentHP, float _AP, float _DP, float _SP)
        {
            Name = _name;
            CurrentHP = _currentHP;
            AP = _AP;
            DP = _DP;
            SP = _SP;
        }

        public virtual void Attack(_Monster _defender)
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
            Console.Write($"Aua! Ich bin {Name} und mir wurden ");
            OutputHelpers.WriteInColor($"{_dmg}", ConsoleColor.DarkRed);
            Console.Write(" HP von");
            OutputHelpers.WriteInColor($" {CurrentHP} ",ConsoleColor.Green);
            Console.WriteLine("HP abgezogen");
        }
    }
}
