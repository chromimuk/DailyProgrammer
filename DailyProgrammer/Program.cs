namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            string input = @"
                Blessed are the poor in spirit,
                for theirs is the kingdom of heaven.
                Blessed are those who mourn,
                for they will be comforted.
                Blessed are the meek,
                for they will inherit the earth.
                Blessed are those who hunger and thirst for righteousness,
                for they will be filled.
                Blessed are the merciful,
                for they will be shown mercy.
                Blessed are the pure in heart,
                for they will see God.
                Blessed are the peacemakers,
                for they will be called sons of God.
            ";


            i270_Markov_Process challenge = new i270_Markov_Process();
            challenge.GetResult(input);
        }
    }
}

