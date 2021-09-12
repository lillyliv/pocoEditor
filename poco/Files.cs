using System.IO;
using System.Threading.Tasks;


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
            Program.currentFileData = string.Join("\n", fileLines);
            return fileLines;
        }
        public static void loadFile(string path)
        {
            System.Console.Clear();
            readFile(path);

            System.Console.Write(Program.currentFileData);
        }
        public static async void saveFile(string path)
        {
            try
            {
                string[] lines = Program.currentFileData.Split("~\n");
                var i = 0;

                foreach(string line in lines)
                {
                    lines[i] = line.Replace("!~", "~");
                    i++;
                }

                System.IO.File.Delete(path);

                await File.WriteAllLinesAsync(path, lines);

            } catch (System.Exception e) { }
        }
    }
}
