using System.Text.RegularExpressions;

namespace DailyProgrammer
{
    public class e232_Palindromes : IChallenge<bool>
    {
        public bool GetResult(object input)
        {
            string message = (string)input;
            message = Regex.Replace(message, @"[^a-zA-Z0-9]+", string.Empty).ToUpper();

            int end = message.Length - 1;
            for (int start = 0; start < message.Length / 2; start++)
            {
                if (message[start] != message[end])
                {
                    return false;
                }
                end--;
            }

            return true;
        }
    }
}
