namespace poco
{
    class Files
    {
        public static string[] readFile(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            int counter = 0;
            string line;
            string[] fileLines = {};

            while ((line = file.ReadLine()) != null)
            {
                fileLines = Functions.stringArrayPush(fileLines, line);
                counter++;
            }

            file.Close();
            Program.currentFileData = fileLines;
            return fileLines;
        }
        public static void loadFile(string path)
        {
            System.Console.Clear();
            string[] fileLines = readFile(path);
            ushort currentY = 0;

            foreach(string line in fileLines)
            {
                ConsoleFuncs.writeLine(line, currentY);
                currentY++;
            }
        }
    }
}
