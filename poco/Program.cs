using System;
using System.Threading;

namespace poco
{
    class Program
    {
        //so many public static's jesus christ

        public static bool alt = false;
        public static bool shift = false;
        public static bool control = false;
        /*
        mode: 0 = type
        mode: 1 = normal
        */
        //public static byte mode = 1;
        public static bool toQuit = false;

        public static ushort width;
        public static ushort height;
        public static ushort cursorx = 0;
        public static ushort cursory = 0;
        public static uint globalCursorX = 0;
        public static uint globalCursorY = 0;

        public static char key;
        public static ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static ConsoleKeyInfo keyInfo;

        public static string currentFileData;
        public static string currentPath;

        static void Main(string[] args)
        {
            System.Console.Clear();

            width = (ushort)Console.WindowWidth;
            height = (ushort)Console.WindowHeight;

            try
            {
                Files.loadFile(args[0]);
                currentPath = args[0];
            } catch (Exception e){ }

            //ConsoleFuncs.writeAtColor("hi", 0, 0, ConsoleColor.Red, ConsoleColor.Blue);
            //ConsoleFuncs.writeAtColor("hi2", 0, 1, ConsoleColor.DarkYellow, ConsoleColor.Magenta);

            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(10); // Loop until input is entered.
                cki = Console.ReadKey(true);

                width = (ushort)Console.WindowWidth;
                height = (ushort)Console.WindowHeight;
                keyInfo = cki;
                key = keyInfo.KeyChar;

                HandleInput.main();

            } while (toQuit == false);
        }
    }
}