using System.IO;

namespace EvoPlanet.Server.Models
{
    public static class DataBase
    {
        //Planet object return value maybe????
        public static string ReadData(string filename)
        {
            return File.ReadAllText(filename);
        }

        public static void SaveData(string filename, string data)
        {
            File.WriteAllText(filename, data);
        }
    }
}
