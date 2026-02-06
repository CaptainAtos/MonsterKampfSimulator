using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator.Monsters
{
    public class Troll : Monster
    {
        public float FokusP;

        public Troll(string _name, float _currentHP, float _AP, float _DP, float _SP, float _FP = 15) : base(_name, _currentHP, _AP, _DP, _SP) // Konstruktor
        {
            FokusP = _FP;
        }

        public override void Attack(Monster _defender) //Definiert den Damage und überschreibt Klassenabhängig die Sonderfertigkeiten und DMG.
        {
            float _dmg;
            Random rand = new Random();
            float fokusroll = rand.Next(100);

            if (fokusroll > FokusP)
            {
                _dmg = AP / _defender.DP * 2;
                _defender.TakeDamage(_dmg);
            }
            else if (fokusroll <= FokusP)
            {
                _dmg = 0;
                Console.WriteLine("Ork ist abgelenkt und schaut einem Schmetterling hinterher");
                TakeDamage(_dmg);
            }

        }
        public override void MakeNoise(float _dmg) // Übergibt den Damage des Angriffs und ruft Random unterschiedliche Kommentare der Monster hervor.
        {
            Random rand = new Random();
            float Speaktxt = rand.Next(100);

            if (Speaktxt <= 25)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("HäääH ? Ork da hat was gestochen", ConsoleColor.Yellow);
            }
            else if (Speaktxt > 25 && Speaktxt <= 50)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("EEEHH, Ork du machst wütend! Ork sauer!", ConsoleColor.Yellow);
            }
            else if (Speaktxt > 50 && Speaktxt <= 75)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("AUA ! Ork aus dir macht Ohrstäbchen für Kerzenwachs sammeln!", ConsoleColor.Yellow);
            }
            else if (Speaktxt > 75 && Speaktxt <= 100)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Hmmm was war das ?!", ConsoleColor.Yellow);
            }
            else
                base.MakeNoise(_dmg);


        }
    }
}
