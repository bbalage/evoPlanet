using System.IO;
using System.Reflection;

namespace EvoPlanet.Server.Models
{
    public static class DataBase
    {
        private static string _defaultPath;

        static DataBase()
        {
            _defaultPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        }

        public static string ReadData(string filename)
        {
            return File.ReadAllText(Path.Combine(_defaultPath, filename));
        }

        public static void SaveData(string filename, string data)
        {
            File.WriteAllText(Path.Combine(_defaultPath, filename), data);
        }
    }
}
