using System;
using System.Collections.Generic;

namespace poco
{
    class HandleInput
    {
        public static void main()
        {
            checkModifiers();
            if (specialKeys() == true) return;
            if (arrowKeys() == true) return;

            if (Program.control != true && Program.alt != true)
            {
                if (Program.cursorx >= Program.width)
                {
                    ConsoleFuncs.writeAt(Program.key.ToString(), 0, Program.cursory+1);
                    Program.cursorx = 1;
                    Program.cursory++;
                    Program.globalCursorX++;
                } else
                {
                    ConsoleFuncs.writeAt(Program.key.ToString(), Program.cursorx, Program.cursory);
                    Program.cursorx++;
                    Program.globalCursorX++;
                }

                Program.currentFileData += Program.key.ToString();

            } else if (Program.control == true)
            {
                if(Program.cki.Key == ConsoleKey.S)
                {
                    //Console.WriteLine("save");

                    Files.saveFile(Program.currentPath);

                }
            }
            
        }
        /*
        only spaghetti below here


        and above here
         */
        private static void checkModifiers()
        {
            if ((Program.cki.Modifiers & ConsoleModifiers.Alt) != 0)
            {
                Program.alt = true;
            }
            else
            {
                Program.alt = false;
            }
            if ((Program.cki.Modifiers & ConsoleModifiers.Shift) != 0)
            {
                Program.shift = true;
            }
            else
            {
                Program.shift = false;
            }
            if ((Program.cki.Modifiers & ConsoleModifiers.Control) != 0)
            {
                Program.control = true;
            }
            else
            {
                Program.control = false;
            }
        }
        private static bool specialKeys()
        {
            if (Program.keyInfo.Key == ConsoleKey.Backspace && Program.cursorx != 0)
            {
                try
                {
                    ConsoleFuncs.writeAt(" ", Program.cursorx - 1, Program.cursory);
                    Program.cursorx -= 1;
                    Program.globalCursorX -= 1;
                    Console.SetCursorPosition(Program.cursorx, Program.cursory);

                    string[] lines = Program.currentFileData.Split("~\n");
                    char[] chars = lines[Program.globalCursorY].ToCharArray();

                    var foos = new List<char>(chars);
                    foos.RemoveAt((int)(Program.globalCursorX));
                    chars = foos.ToArray();

                    var concatChars = string.Join("", chars);

                    lines[Program.globalCursorY] = concatChars;

                    Program.currentFileData = string.Join("~\n", lines);
                    return true;
                } catch {
                    Program.cursorx -= 1;
                    Program.globalCursorX -= 1;
                    return true;
                }
            }
            else if (Program.keyInfo.Key == ConsoleKey.Backspace && Program.globalCursorX == 0 && Program.globalCursorY != 0)
            {
                /*try
                {
                    ConsoleFuncs.writeAt(" ", Program.cursorx, Program.cursory + 1);
                    Program.cursory -= 1;
                    Program.globalCursorY -= 1;
                    return true;
                } catch { return true; }*/
                return true;

            } else if (Program.keyInfo.Key == ConsoleKey.Backspace && Program.globalCursorX == 0 && Program.globalCursorY == 0)
            {
                return true;
            }
            else if (Program.keyInfo.Key == ConsoleKey.Enter)
            {
                ConsoleFuncs.writeAt("\n", Program.cursorx, Program.cursory);
                Program.cursorx = 0;
                Program.globalCursorX = 0;
                Program.cursory += 1;
                Program.globalCursorY += 1;
                Program.currentFileData += "~\n";
                return true;
            }
            return false;
        }
        private static bool arrowKeys()
        {
            if (Program.keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (Program.cursorx == 0) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx - 1, Program.cursory);
                    Program.cursorx--;
                    Program.globalCursorX--;
                }
                return true;
            }
            else if (Program.keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (Program.globalCursorY + 1 >= Program.height - 3) return true;

                if (Program.globalCursorY == Program.height - 1) { }
                else
                {
                    string[] lines = Program.currentFileData.Split("~\n");

                    Console.SetCursorPosition(Program.cursorx, Program.cursory + 1);
                    Program.cursory++;
                    Program.globalCursorY++;
                    
                    var len = lines[Program.globalCursorY].Length;
                    if (len >= Program.globalCursorX) return true;

                    Program.cursorx = (ushort)len;
                    Program.globalCursorX = (ushort)len;
                    Console.SetCursorPosition(Program.cursorx, Program.cursory);
                }
                return true;
            }
            else if (Program.keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (Program.globalCursorY == 0) { }
                else
                {
                    string[] lines = Program.currentFileData.Split("~\n");

                    Console.SetCursorPosition(Program.cursorx, Program.cursory - 1);
                    Program.cursory--;
                    Program.globalCursorY--;

                    var len = lines[Program.globalCursorY].Length;
                    if (len >= Program.globalCursorX) return true;

                    Program.cursorx = (ushort)len;
                    Program.globalCursorX = (ushort)len;
                    Console.SetCursorPosition(Program.cursorx, Program.cursory);
                }
                return true;
            }
            else if (Program.keyInfo.Key == ConsoleKey.RightArrow)
            {
                string[] lines = Program.currentFileData.Split("~\n");
                if (Program.globalCursorX >= lines[Program.globalCursorY].Length) return true;
                
                if (Program.cursorx == Program.width - 1) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx + 1, Program.cursory);
                    Program.cursorx++;
                    Program.globalCursorX++;
                }
                return true;
            }
            return false;
        }
    }
}
