using MonsterKampfSimulator.Monsters;

namespace MonsterKampfSimulator
{
    public class GameManager
    {
        private List<Monster> m_selectedMonsters = [];
        public void Init() 
        {
            InitiateMonsterlist();
        }

        public void Run() // Legt eine logische Reihenfolge der auszuführenden Methoden fest
        {
            Init();
            OutputHelpers.WriteInColorLine("Der Kampf beginnt!", ConsoleColor.DarkRed);
            RoundCounter();
        }


        private void InitiateMonsterlist()  // Erstellt Monsterobjekte und instanziert eine Monsterliste.
        {
            Console.WriteLine("Willkommen im Monsterclashsimulator \n Erstelle dein erstes Monster:");
            CreateMonster();
            DisplaySelectedMonster();
            CreateMonster();
            DisplaySelectedMonster();
        }
        private void CreateMonster()    // Anleitung und Führung zum erstellen eines Monsters mithilfe von Konstruktoren.
        {
            EMonsterType monsterType = ChooseMonsterType();

            while (m_selectedMonsters.Count == 1 && monsterType == GetMonsterTypeFromInstance(m_selectedMonsters[0])) 
            {
                Console.WriteLine("Du darfst keine zwei Monster der gleichen Rasse wählen. Bitte wähle eine andere Rasse.");
                monsterType = ChooseMonsterType();
            }
                
            Console.WriteLine("Gib jetzt den Namen deines Monsters ein");
            string name = Console.ReadLine()!;
            int HP = SetPoint("HP", 1, 100);
            int AP = SetPoint("AP", 20, 80);
            int VP = SetPoint("VP", 20, 80);
            int SP = SetPoint("SP", 1, 100);

            Monster playerMonster = null!;

            if (monsterType == EMonsterType.Goblin)
            {
                playerMonster = new Goblin(name, HP, AP, VP, SP);
            }
            else if (monsterType == EMonsterType.Ork)
            {
                playerMonster = new Ork(name, HP, AP, VP, SP);
            }
            else if (monsterType == EMonsterType.Troll)
            {
                playerMonster = new Troll(name, HP, AP, VP, SP);
            }
            m_selectedMonsters.Add(playerMonster!);
        }

        private static EMonsterType GetMonsterTypeFromInstance(Monster monster)
        {
            if (monster is Goblin) return EMonsterType.Goblin;
            if (monster is Ork) return EMonsterType.Ork;
            if (monster is Troll) return EMonsterType.Troll;
            return EMonsterType.None;
        }
        private static EMonsterType ChooseMonsterType()    // Definiert die Monsterrasse 
        {
            int choice = 0;

            Console.WriteLine("\nWähle die Rasse deines Monsters:");
            Console.WriteLine("1. Goblin");
            Console.WriteLine("2. Ork");
            Console.WriteLine("3. Troll");
            Console.WriteLine("Gib die Zahl für die Auswahl ein:");

            bool correctInput = false;
            while (!correctInput)
            {
                correctInput = InputHelper.CheckUserInputIntRange(Console.ReadLine()!, (int)EMonsterType.None + 1, (int)EMonsterType.Max - 1, out choice);
                if (!correctInput)
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle entweder '1' für Goblin,'2' für Ork oder '3'für Troll.");
            }

            if (choice == 1)
            {
                return EMonsterType.Goblin;
            }
            else if (choice == 2)
            {
                return EMonsterType.Ork;
            }
            else if (choice == 3)
            {
                return EMonsterType.Troll;
            }
            else
                return EMonsterType.None;
        }

        private static int SetPoint(string stat, int min, int max)     //User kann die Statpunkte der Monster hiermit definieren
        {
            bool correctInput = false;
            int point = 0;

            while (!correctInput)
            {
                Console.WriteLine($"Setze jetzt die {stat} zwischen {min} und {max}");
                string consoleInput = Console.ReadLine()!;
                correctInput = InputHelper.CheckUserInputIntRange(consoleInput, min, max, out point);
                if (!correctInput)
                    Console.WriteLine($"Ungültige Eingabe!");
            }
            return point;
        }

        private void DisplaySelectedMonster()   // Schreibt bei Nutzung der Methode das aktuelle Monster mit Namen auf
        {
            Console.WriteLine("Deine ausgewählten Monster:");
            for (int i = 0; i < m_selectedMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_selectedMonsters[i].Name}");
            }
        }

        private void RoundCounter() // Roundcounter definiert den Kampf und die Runden indem er abwechselnd die Fertigkeiten der Monster einsetzt (ruft den AttackLoop auf) und die Runden mitzählt bis ein Monster verliert
        {
            int _round = 1;
            Monster M1 = m_selectedMonsters[0];
            Monster M2 = m_selectedMonsters[1];

            while (M1.IsAlive && M2.IsAlive)
            {
                Console.WriteLine($"\n===== Runde {_round} =====");
                AttackLoop(M1, M2);
                _round++;
                Console.WriteLine("Weiter mit Enter");
                Console.ReadLine();
            }

            if (M1.IsAlive)
            {
                Console.WriteLine($"{M1.Name} hat gewonnen!");
                Console.WriteLine($"Der Kampf hat {_round} Runden gedauert");
            }
            else
            {
                Console.WriteLine($"{M2.Name} hat gewonnen");
                Console.WriteLine($"Der Kampf hat {_round} Runden gedauert");
            }


        }

        private static void AttackLoop(Monster M1, Monster M2)     // Ein Loop der dazu dient zu definieren welches Monster anhand seiner Stats zuerst angreifen darf
        {
            Monster first = M1;
            Monster second = M2;

            // Wählt aus welches Monster zuerst angreifen darf anhand seine "Speedpoints"
            if (M1.SP > M2.SP)
            {
                first = M1;
                second = M2;
            }
            else if (M2.SP > M1.SP)
            {
                first = M2;
                second = M1;
            }
            else
            { // Wenn beide Monster die selben "Speedpoints" wird per Zufall entschieden wer angreifen darf.
                bool m1Starts = Random.Shared.Next(2) == 0;
                first = m1Starts ? M1 : M2;
                second = m1Starts ? M2 : M1;
            }
            first.Attack(second);
            if (!second.IsAlive) return; 
            second.Attack(first);
        }
    }
}
