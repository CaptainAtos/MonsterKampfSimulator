namespace MonsterKampfSimulator.Monsters
{
    public class Goblin : Monster
    {
        private const int CritdamageMultiplier = 5;
        public float CritP;
        public Goblin(string _name, float _currentHP, float _AP, float _DP, float _SP, float _CritP = 25) : base(_name, _currentHP, _AP, _DP, _SP) // Konstruktor
        {
            CritP = _CritP;
        }

        public override void Attack( Monster _defender) //Definiert den Damage und überschreibt Klassenabhängig die Sonderfertigkeiten und DMG.
        {
            float _dmg;
            Random rand = new Random();
            float critRoll = rand.Next(100);

            if (critRoll > CritP)
            {
                _dmg = AP / _defender.DP * DamageMultiplier;
                _defender.TakeDamage(_dmg);
            }
            else if (critRoll <= CritP)
            {
                _dmg = AP / _defender.DP * CritdamageMultiplier;
                _defender.TakeDamage(_dmg);
            }
        }

        public override void MakeNoise(float _dmg) // Übergibt den Damage des Angriffs und ruft Random unterschiedliche Kommentare der Monster hervor.
        {
            Random rand = new Random();
            float Speaktxt = rand.Next(100);

            if (Speaktxt <= 25)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Aua ! Nein nein tue Goblin bitte nicht weh ! Ich gebe auf", ConsoleColor.Magenta);
            }
            else if (Speaktxt > 25 && Speaktxt <= 50)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Auuuuuuuu schnell weg hier!", ConsoleColor.Magenta);
            }
            else if (Speaktxt > 50 && Speaktxt <= 75)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Dafür schlitz ich dir ein drittes Auge mit meinem Dolch!", ConsoleColor.Magenta);
            }
            else if (Speaktxt > 75 && Speaktxt <= 100)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Gobaga gobgogoga Goba Gaba!", ConsoleColor.Magenta);
            }
            else
                base.MakeNoise(_dmg);
        }
    }
}
