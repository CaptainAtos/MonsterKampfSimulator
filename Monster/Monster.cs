using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator.Monster
{
    public abstract class Monster
    {
        public string Name;
        public bool IsGoblin;
        public bool IsOrk;
        public float CurrentHP; // Aktuelle HP
        public float AP; // Angriffspunkte
        public float DP; // Verteildigungspunkte
        public float SP; // Geschwindigkeitspunkte
        
        public bool IsAlive => CurrentHP > 0;

        public Monster(string _name, float _currentHP, float _AP, float _DP, float _SP)
        {
            Name = _name;
            CurrentHP = _currentHP;
            AP = _AP;
            DP = _DP;
            SP = _SP;
        }

        public virtual void Attack(float _dmg, Monster _defender)
        {
            _dmg = AP / _defender.DP * 2;
            _defender.TakeDamage(_dmg);
        }

        public virtual void TakeDamage(float _dmg)
        {
            CurrentHP -= _dmg;
            Console.WriteLine($"Aua! Ich bin {Name} und mir wurden {_dmg} abgezogen");
        }
    }
}
