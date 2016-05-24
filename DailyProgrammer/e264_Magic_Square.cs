using System.Linq;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4dccix/20160404_challenge_261_easy_verifying_3x3_magic/
    /// </summary>
    public class e264_Magic_Square : IChallenge<bool>
    {
        private int[] square;

        public bool GetResult(object input)
        {
            square = (int[]) input;

            // init with diags
            bool res = AreMagics(square[0], square[4], square[8]) && AreMagics(square[2], square[4], square[6]);

            if (res)
            {
                int startHorizontal = 0;
                for (int i = 0; i < 3; i++)
                {
                    res &= AreMagics(square[i], square[i + 3], square[i + 6]);  // vertical
                    res &= AreMagics(square[startHorizontal], square[startHorizontal + 1], square[startHorizontal + 2]); // horizontal
                    startHorizontal += 3;
                }
            }

            return res;
        }

        private bool AreMagics(params int[] numbers)
        {
            int score = 15;
            return numbers.Sum() == score;
        }
    }
}
