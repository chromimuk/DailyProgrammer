using System;
using System.Collections.Generic;

namespace DailyProgrammer
{
    
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4ijtrt/20160509_challenge_266_easy_basic_graph/
    /// </summary>
    public class e266_Node_Degrees : IChallenge<int[]>
    {
        private int nbNodes = 0;
        private List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

        public int[] GetResult(object input)
        {
            string[] lines = (string[]) input;
            ReadLines(lines);

            int[] results = new int[nbNodes];
            foreach (var pair in pairs)
            {
                results[pair.Item1 - 1]++;
                results[pair.Item2 - 1]++;
            }

            return results;
        }

        private void ReadLines(string[] lines)
        {
            nbNodes = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                int[] tmp = Array.ConvertAll(lines[i].Split(' '), int.Parse);
                pairs.Add(new Tuple<int, int>(tmp[0], tmp[1]));
            }
        }

    }
}
