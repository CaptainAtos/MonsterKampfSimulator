using MonsterKampfSimulator.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator
{
    internal enum EMonsterType // Nummeriert die Monstertypen für die vereinfachte Implementation in Gamemanager. None und Max sind da um Out of Bounds Fails zu vermeiden.
    {
        None,
        Goblin, 
        Ork,
        Troll,
        Max
    }
}
