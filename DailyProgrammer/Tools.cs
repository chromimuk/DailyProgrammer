using System;
using System.IO;
using System.Text;

namespace DailyProgrammer
{
    static class Tools
    {
        public static string[] ReadFile(string file)
        {
            string rootPath = GetRootPath();
            return File.ReadAllLines((Path.Combine(rootPath, file)), Encoding.UTF8);
        }

        public static string GetRootPath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        }
    }
}
