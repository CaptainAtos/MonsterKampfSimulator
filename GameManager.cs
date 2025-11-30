using MonsterKampfSimulator.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator
{
    public class GameManager
    {
        public List<_Monster> m_selectedMonsters = new List<_Monster>();
        public void Init()
        {
            InitiateMonsterlist();
        }

        public void Run()
        {
            Init();
            RoundCounter();
            OutputHelpers.WriteInColorLine("Der Kampf beginnt!", ConsoleColor.DarkRed);
        }

        // public void End()

        private void InitiateMonsterlist()
        {
            Console.WriteLine("Willkommen im Monsterclashsimulator \n Erstelle dein erstes Monster:");
            CreateMonster();
            DisplaySelectedMonster();
            CreateMonster();
            DisplaySelectedMonster();

        }

        private void CreateMonster()
        {
            EMonsterType monsterType = ChooseMonsterType();
            Console.WriteLine("Gib jetzt den Namen deines Monsters ein");
            string name = Console.ReadLine()!;
            int HP = SetPoint("HP", 1, 100);
            int AP = SetPoint("AP", 20, 80);
            int VP = SetPoint("VP", 20, 80);
            int SP = SetPoint("SP", 1, 100);

            _Monster playerMonster = null!;

            if (monsterType == EMonsterType.Goblin)
            {
                playerMonster = new Goblin(name, HP, AP, VP, SP);
            }
            else if (monsterType == EMonsterType.Ork)
            {
                playerMonster = new Ork(name, HP, AP, VP, SP);
            }

            m_selectedMonsters.Add(playerMonster!);

        }
        private static EMonsterType ChooseMonsterType()
        {
            int choice = 0;

            Console.WriteLine("\nWähle die Rasse deines Monsters:");
            Console.WriteLine("1. Goblin");
            Console.WriteLine("2. Ork");
            Console.WriteLine("Gib die Zahl für die Auswahl ein:");

            bool correctInput = false;
            while (!correctInput)
            {
                correctInput = Inputhelper.CheckUserInputIntRange(Console.ReadLine()!, (int)EMonsterType.None + 1, (int)EMonsterType.Max - 1, out choice);
                if (!correctInput)
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle entweder '1' für Goblin oder '2' für Ork.");
            }

            if (choice == 1)
            {
                return EMonsterType.Goblin;
            }
            else
            {
                return EMonsterType.Ork;
            }
        }
        // TODO : Maximale Points einführen. Spieler hat begrenzte Anzahl an Punkten die er auf alle Stats verteilen kann. 
        private static int SetPoint(string stat, int min, int max)
        {
            bool correctInput = false;
            int point = 0;

            while (!correctInput)
            {
                OutputHelpers.WriteInColorLine($"Setze jetzt die {stat} zwischen {min} und {max}",ConsoleColor.Green);
                string consoleInput = Console.ReadLine()!;
                correctInput = Inputhelper.CheckUserInputIntRange(consoleInput, min, max, out point);
                if (!correctInput)
                    Console.WriteLine($"Ungültige Eingabe!");
            }
            return point;
        }

        private void DisplaySelectedMonster()
        {
            Console.WriteLine("Deine ausgewählten Monster:");
            for (int i = 0; i < m_selectedMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_selectedMonsters[i].Name}");
            }
        }

        public void RoundCounter()
        {
            int _round = 0;
            _Monster M1 = m_selectedMonsters[0];
            _Monster M2 = m_selectedMonsters[1];

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
            }
            else
            {
                Console.WriteLine($"{M2.Name} hat gewonnen");
            }


        }

        private void AttackLoop(_Monster M1, _Monster M2)
        {
            _Monster first = M1;
            _Monster second = M2;

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
            { // Wenn beide Monster die selben "Speedpoints" darf der mit den höheren "Attackpoints" angreifen
                if (M1.AP > M2.AP)
                {
                    first = M1;
                    second = M2;
                }
                else if (M1.AP < M2.AP)
                {
                    first = M2;
                    second = M1;
                }
            }
            first.Attack(second);
            if (!second.IsAlive) return;
            second.Attack(first);
        }
    }
}
