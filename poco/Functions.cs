namespace poco
{
    class Functions
    {
        public static string[] stringArrayPush(string[] array, string data)
        {
            System.Array.Resize(ref array, array.Length + 1);
            array[array.GetUpperBound(0)] = data;

            return array;
        }
    }
}
