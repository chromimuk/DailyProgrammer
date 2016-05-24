namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4cb7eh/20160328_challenge_260_easy_garage_door_opener/
    /// </summary>
    public class e260_Garage_Door : IChallenge<int[]>
    {
        public enum Commands { Click=0, Wait=1 };

        public const int STATE_OPEN = 0;
        public const int STATE_OPENING = 1;
        public const int STATE_STOPPEDWHILEOPENING = 2;
        public const int STATE_CLOSING = 3;
        public const int STATE_STOPPEDWHILECLOSING = 4;
        public const int STATE_CLOSED = 5;


        public int[] GetResult(object input)
        {
            int[] commands = (int[]) input;

            int[] result = new int[commands.Length + 1];
            result[0] = STATE_CLOSED;

            for (int i = 0; i < commands.Length; i++)
            {
                result[i + 1] = GetState(result[i], commands[i]);
            }

            return result;
        }


        private int GetState(int currentState, int command)
        {
            int newState = -1;
            bool buttonClicked = (command == (int)Commands.Click);

            switch (currentState)
            {
                case STATE_OPEN:
                    newState = buttonClicked ? STATE_CLOSING : STATE_OPEN;
                    break;
                case STATE_OPENING:
                    newState = buttonClicked ? STATE_STOPPEDWHILEOPENING : STATE_OPEN;
                    break;
                case STATE_STOPPEDWHILEOPENING:
                    newState = buttonClicked ? STATE_CLOSING : STATE_STOPPEDWHILEOPENING;
                    break;
                case STATE_CLOSING:
                    newState = buttonClicked ? STATE_STOPPEDWHILECLOSING : STATE_CLOSED;
                    break;
                case STATE_STOPPEDWHILECLOSING:
                    newState = buttonClicked ? STATE_OPENING : STATE_STOPPEDWHILECLOSING;
                    break;
                case STATE_CLOSED:
                    newState = buttonClicked ? STATE_OPENING : STATE_CLOSED;
                    break;
            }
            
            return newState;
        }
    }
}
