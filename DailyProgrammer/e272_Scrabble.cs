using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4oylbo/20160620_challenge_272_easy_whats_in_the_bag/
    /// </summary>
    public class e272_Scrabble : IChallenge<Dictionary<char, int>>
    {
        public Dictionary<char, int> GetResult(object input)
        {
            string currentTiles = (string) input;

            foreach (char c in currentTiles)
            {
                tiles[c]--;
                if (tiles[c] < 0)
                    throw new ArgumentException("Invalid input. More " + c + "'s have been taken from the bag than possible.");
            }

            return tiles.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }
        
        public Dictionary<char, int> tiles = new Dictionary<char, int>()
        {
            {'E', 12},
            {'A', 9},
            {'I', 9},
            {'O', 8},
            {'N', 6},
            {'R', 6},
            {'T', 6},
            {'L', 4},
            {'S', 4},
            {'U', 4},
            {'D', 4},
            {'G', 3},
            {'_', 2},
            {'B', 2},
            {'C', 2},
            {'M', 2},
            {'P', 2},
            {'F', 2},
            {'H', 2},
            {'V', 2},
            {'W', 2},
            {'Y', 2},
            {'K', 1},
            {'J', 1},
            {'X', 1},
            {'Q', 1},
            {'Z', 1}
        };

    }
}
