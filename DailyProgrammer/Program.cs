namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            string input = "PQAREIOURSTHGWIOAE_";
            
            e272_Scrabble challenge = new e272_Scrabble();
            challenge.GetResult(input);
        }
    }
}

