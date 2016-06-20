using Dailyprogrammer;

namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = Tools.ReadFile("res\\input.txt");
            
            h270_Alien_Invasion challenge = new h270_Alien_Invasion();
            challenge.GetResult(lines);
        }
    }
}

