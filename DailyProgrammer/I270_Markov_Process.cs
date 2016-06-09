using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DailyProgrammer
{
    
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4n6hc2/20160608_challenge_270_intermediate_generating/
    /// http://www.rose-hulman.edu/Users/faculty/young/CS-Classes/csse220/200820/web/Programs/Markov/markov.html
    /// n=2
    /// </summary>
    class i270_Markov_Process : IChallenge<string>
    {
        Dictionary<string, Dictionary<string, int>> table = new Dictionary<string, Dictionary<string, int>>();
        string NONWORD = "***";

        public string GetResult(object input)
        {
            string text = (string)input;
            string[] words = GetSeperatedWords(text);

            BuildDataStructure(words);
            PrintDictionary();
            return GetGeneratedText();
        }


        private string[] GetSeperatedWords(string text)
        {
            text = Regex.Replace(text, @"[^a-zA-Z0-9.,]+", " ");
            text = NONWORD + " " + NONWORD + text + NONWORD;
            return text.Split(' ');
        }


        // IF the table already contains the prefix, we need to add the suffix
        //  (if the suffix already exist, ++ its occurence)
        // ELSE add the prefix to the table
        private void BuildDataStructure(string[] words)
        {
            for (int i = 2; i < words.Length; i++)
            {
                string prefix = words[i - 2] + " " + words[i - 1];
                string suffix = words[i];

                if (table.ContainsKey(prefix))
                {
                    Dictionary<string, int> prefixRow = table[prefix];

                    if (prefixRow.ContainsKey(suffix))
                        prefixRow[suffix]++;
                    else
                        prefixRow.Add((suffix == "") ? NONWORD : suffix, 1);
                }
                else
                {
                    table[prefix] = new Dictionary<string, int>()
                    {
                        { (suffix == "") ? NONWORD : suffix, 1 }
                    };
                }
            }
        }


        private string GetGeneratedText()
        {
            StringBuilder text = new StringBuilder();

            Dictionary<string, int> tableRow = table[NONWORD + " " + NONWORD];
            string previousWord = NONWORD;
            string currentWord = "";

            while (currentWord != NONWORD)
            {
                currentWord = GetRandomWord(tableRow);
                string key = previousWord + " " + currentWord;

                if (table.ContainsKey(key))
                {
                    text.Append(Regex.IsMatch(currentWord, ".*[.,]$") ? currentWord + "\n" : currentWord + " ");
                    tableRow = table[key];
                    previousWord = currentWord;
                }
            }

            System.Diagnostics.Debug.WriteLine(text.ToString());

            return text.ToString();
        }


        private string GetRandomWord(Dictionary<string, int> dictionary)
        {
            if (dictionary.Keys.Count == 1)
                return dictionary.Keys.First();

            else
            {
                List<string> words = new List<string>();
                foreach (var d in dictionary)
                {
                    for (var i = 0; i < d.Value; i++)
                        words.Add(d.Key);
                }

                Random rand = new Random();
                int toSkip = rand.Next(0, words.Count);

                string chosenWord = words.Skip(toSkip).Take(1).First();
                dictionary[chosenWord]--;

                return chosenWord;
            }
        }


        private void PrintDictionary()
        {
            foreach (var d in table)
            {
                System.Diagnostics.Debug.WriteLine(d.Key + " | " + string.Join(" ", d.Value));
            }
        }


    }
}
