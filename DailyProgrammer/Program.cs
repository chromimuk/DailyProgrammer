namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            e260_Garage_Door.Commands[] commands = new e260_Garage_Door.Commands[]
            {
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Wait,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Wait,
            };

            IChallenge<int[]> challenge = new e260_Garage_Door();
            challenge.GetResult(commands);
        }
    }
}

