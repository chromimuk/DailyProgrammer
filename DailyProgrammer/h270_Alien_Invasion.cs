using DailyProgrammer;
using System.Linq;


namespace Dailyprogrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4nga90/20160610_challenge_270_hard_alien_invasion/
    /// </summary>
    public class h270_Alien_Invasion : IChallenge<int>
    {
        string[] crop;

        public int GetResult(object input)
        {
            string[] lines = (string[])input;
            crop = lines.Skip(1).ToArray();

            int size = int.Parse(lines[0]);
            bool isSquare = false;
            int best = 0;

            for (int n = 1; n < size; n++)
            {
                for (int i = 0; i < size - (n - 1); i++)
                {
                    for (int j = 0; j < size - (n - 1); j++)
                    {
                        isSquare = CheckNSquare(i, j, n);
                        if (isSquare) break;
                    }
                    if (isSquare) break;
                }

                if (isSquare)
                {
                    best = n;
                    isSquare = false;
                }
            }

            best = (best * best);
            System.Diagnostics.Debug.WriteLine(best + " spaces available");
            
            return best;
        }


        private bool CheckNSquare(int posX, int posY, int n)
        {
            bool isSquare = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (crop[posX + i][posY + j] == 'X')
                    {
                        isSquare = false;
                        break;
                    }
                    if (!isSquare) break;
                }
                if (!isSquare) break;
            }

            if (isSquare)
                System.Diagnostics.Debug.WriteLine("Space N^" + n + " available (" + posY + ";" + posX + ")");

            return isSquare;
        }

    }
}
