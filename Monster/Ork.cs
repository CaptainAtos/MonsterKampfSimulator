namespace MonsterKampfSimulator.Monsters
{
    public class Ork : Monster
    {
        public float DumbnessP;

        public Ork(string _name, float _currentHP, float _AP, float _DP, float _SP, float _DumbnessP = 10) : base(_name, _currentHP, _AP, _DP, _SP) // Konstruktor
        {
            DumbnessP = _DumbnessP;
        }

        public override void Attack(Monster _defender) //Definiert den Damage und überschreibt Klassenabhängig die Sonderfertigkeiten und DMG.
        {
            float _dmg;
            Random rand = new Random();
            float dumbnessRoll = rand.Next(100);

            if (dumbnessRoll > DumbnessP)
            {
                _dmg = AP / _defender.DP * DamageMultiplier;
                _defender.TakeDamage(_dmg);
            }
            else if (dumbnessRoll <= DumbnessP)
            {
                _dmg = AP;
                Console.WriteLine("Ork ist blind vor Wut und haut sich die Axt selber ins Gesicht.");
                TakeDamage(_dmg);
            }

        }
        public override void MakeNoise(float _dmg) // Übergibt den Damage des Angriffs und ruft Random unterschiedliche Kommentare der Monster hervor.
        {
            Random rand = new Random();
            float Speaktxt = rand.Next(100);

            if (Speaktxt <= 25)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Grraaaah ! Du hast meine Ehre als Krieger beschmutzt !", ConsoleColor.Blue);
            }
            else if (Speaktxt > 25 && Speaktxt <= 50)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("HAHA ! Glaubst du das hat ORK WEHGETAN ?!", ConsoleColor.Blue);
            }
            else if (Speaktxt > 50 && Speaktxt <= 75)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("GAAAAAARRRRRHHHHHH", ConsoleColor.Blue);
            }
            else if (Speaktxt > 75 && Speaktxt <= 100)
            {   base.MakeNoise(_dmg);
                OutputHelpers.WriteInColorLine("Aaaaa. RUUUUAAAR", ConsoleColor.Blue);
            }
            else
                base.MakeNoise(_dmg);
        }
    }
}
