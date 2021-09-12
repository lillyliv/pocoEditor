using System;

namespace poco
{
    class ConsoleFuncs
    {
        public static void writeAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void writeAtColor(string s, int x, int y, ConsoleColor fore, ConsoleColor back)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = fore;
                Console.BackgroundColor = back;
                Console.Write(s);
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void writeLine(string line, ushort y)
        {
            ushort currentX = 0;
            char[] charArr = line.ToCharArray();
            foreach (char ch in charArr)
            {
                if(currentX < Program.width)
                {
                    ConsoleFuncs.writeAt(ch.ToString(), currentX, y);
                    currentX++;
                } else if(y < Program.height)
                {
                    currentX = 0;
                    y++;
                    ConsoleFuncs.writeAt(ch.ToString(), currentX, y);
                    currentX++;
                }
            }
        }
    }
}