using System.Collections.Generic;
using System.Linq;

namespace DailyProgrammer
{
    public class e269_BASIC_Formatting : IChallenge<string[]>
    {
        private string[] blockStarters = new string[] { "FOR", "IF" };
        private string[] blockEnders = new string[] { "NEXT", "ENDIF" };
        private string indentation = "    ";
        private int lvlIndentation = 0;


        public string[] GetResult(object input)
        {
            string[] lines = (string[])input;
            return GetFormattedCode(lines);
        }


        private string[] GetFormattedCode(string[] lines)
        {
            int nbLines = lines.Length;

            List<string> output = new List<string>();
            for (int i = 0; i < nbLines; i++)
            {
                string newLine = GetFormattedLine(lines[i].TrimStart());
                if (!string.IsNullOrEmpty(newLine))
                    output.Add(newLine);
            }

            return output.ToArray();
        }

        private string GetFormattedLine(string line)
        {
            var firstWord = line.Split(null)[0];

            if (blockEnders.Any(x => firstWord.StartsWith(x)))
                lvlIndentation--;

            string newLine = string.Concat(Enumerable.Repeat(indentation, lvlIndentation)) + line;

            if (blockStarters.Any(x => firstWord.StartsWith(x)))
                lvlIndentation++;

            return newLine;
        }


        public string[] CheckForErrors(string[] lines)
        {
            return new string[0];
        }

    }
}
