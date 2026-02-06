namespace MonsterKampfSimulator
{
    internal static class OutputHelpers
    {
        public static void WriteInColor(string _text, ConsoleColor _color = ConsoleColor.Gray)  //Ändert variabel die Farbe des Textes in die in der Methode bestimmte Farbe.
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.Write(_text);
            Console.ForegroundColor = oldColor;
            return;
        }
        public static void WriteInColorLine(string _text, ConsoleColor _color = ConsoleColor.Gray)  //Ändert variabel die Farbe des Textes in die in der Methode bestimmte Farbe und macht danach einen Zeilenumbruch.
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.WriteLine(_text);
            Console.ForegroundColor = oldColor;
            return;
        }
    }
}