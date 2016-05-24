using System;
using System.Collections.Generic;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4fc896/20160418_challenge_263_easy_calculating_shannon/
    /// </summary>
    public class e263_Shannon_Entropy : IChallenge<double>
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();

        public double GetResult(object input)
        {
            string message = (string)input;
            double messageLength = message.Length;

            FillDictionary(message);

            double res = 0;
            foreach (var e in chars)
            {
                res += (e.Value / messageLength) * Math.Log(messageLength / e.Value, 2);
            }
            return res;
        }


        private void FillDictionary(string message)
        {
            foreach (char c in message)
            {
                if (chars.ContainsKey(c))
                    chars[c]++;
                else
                    chars.Add(c, 1);
            }
        }
    }
}
