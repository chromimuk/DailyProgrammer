namespace DailyProgrammer
{
    class Program
    {
        /// Done: e254, e263, e264, e266
        
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            IChallenge<bool> challenge = new e264_Magic_Square();
            challenge.GetResult(new object[] { new int[9] { 8, 1, 6, 3, 5, 7, 4, 9, 2 } });
        }
    }
}

