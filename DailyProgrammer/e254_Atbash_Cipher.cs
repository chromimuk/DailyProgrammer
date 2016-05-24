using System;
using System.Linq;
using System.Text;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/45w6ad/20160216_challenge_254_easy_atbash_cipher/
    /// </summary>
    public class e254_Atbash_Cipher : IChallenge<string>
    {
        private readonly static int alphabetSize = 26;
        private readonly char[] alphabet = Enumerable.Range('a', alphabetSize).Select(x => (char)x).ToArray();
        private char[] alphabetReverse = new char[alphabetSize];

        public e254_Atbash_Cipher()
        {
            PopulateReversedAlphabet();
        }


        public string GetResult(object input)
        {
            string text = (string) input;
            StringBuilder cipher = new StringBuilder();
            foreach (char c in text)
            {
                int idx = Array.IndexOf(alphabet, c);
                cipher.Append((idx > -1) ? alphabetReverse[idx] : c);
            }
            return cipher.ToString();
        }


        private void PopulateReversedAlphabet()
        {
            for (var i = 0; i < alphabetSize; i++)
            {
                alphabetReverse[i] = alphabet[alphabetSize - i - 1];
            }
        }

    }
}
