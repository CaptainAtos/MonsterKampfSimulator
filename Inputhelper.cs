using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator
{
    public static class InputHelper     // Wandelt die Usereingabe vom String in ein Integer um solange es auch Zahlen waren.
    {
        public static bool CheckUserInputIntRange(string _input, int _min, int _max, out int _result)
        {
            bool correctInput = int.TryParse(_input, out _result);

            if (correctInput)
                if (_result >= _min && _result <= _max)
                    return true;

            return false;
        }
    }
}
