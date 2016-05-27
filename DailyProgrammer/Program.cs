namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            e260_Garage_Door.Actions[] commands = new e260_Garage_Door.Actions[]
            {
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Wait,
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Click,
                e260_Garage_Door.Actions.Wait,
            };

            IChallenge<int[]> challenge = new e260_Garage_Door();
            challenge.GetResult(commands);
        }
    }
}

