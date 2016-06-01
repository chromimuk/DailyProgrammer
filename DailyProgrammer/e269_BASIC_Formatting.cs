using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4lpygb/20160530_challenge_269_easy_basic_formatting/
    /// bonus done but look awful
    /// </summary>
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



        /// Bonus

        class Block
        {
            public Block(Block p, Block c) { parent = p; child = c; }
            public Block child { get; set; }
            public Block parent { get; set; }
        }

        class BlockFor : Block
        {
            public BlockFor(Block p, Block c) : base(p, c) { }
        }
        class BlockIf : Block
        {
            public BlockIf(Block p, Block c) : base(p, c) { }
        }


        Block mainBlock;
        Block currentBlock;
        List<string> errors;
        enum StatementTypes { LOOP=1, CONDITION=2 };
        string ERROR_MISSING_NEXT = "MISSING NEXT";
        string ERROR_EXTRA_NEXT = "EXTRA NEXT";
        string ERROR_MISSING_ENDIF = "MISSING ENDIF";
        string ERROR_EXTRA_ENDIF = "EXTRA ENDIF";


        public string[] CheckForErrors(string[] lines)
        {
            errors = new List<string>();
            mainBlock = new Block(null, null);
            currentBlock = mainBlock;

            for (int i = 0; i < lines.Length; i++)
            {
                string firstWord = lines[i].TrimStart().Split(null)[0];

                if (firstWord.StartsWith("FOR"))
                {
                    OpenBlock(StatementTypes.LOOP);
                }
                else if (firstWord.StartsWith("NEXT"))
                {
                    CloseBlock(StatementTypes.LOOP);
                }
                else if (firstWord.StartsWith("IF"))
                {
                    OpenBlock(StatementTypes.CONDITION);
                }
                else if (firstWord.StartsWith("ENDIF"))
                {
                    CloseBlock(StatementTypes.CONDITION);
                }
            }

            CheckIfBlocksAreStillOpened();

            return errors.ToArray();
        }

        private void CheckIfBlocksAreStillOpened()
        {
            while (currentBlock.parent != null)
            {
                errors.Add(currentBlock is BlockFor ? ERROR_MISSING_NEXT : ERROR_MISSING_ENDIF);
                CloseCurrentBlock();
            }
        }

        private void OpenBlock(StatementTypes type)
        {
            if (type == StatementTypes.LOOP)
                currentBlock.child = new BlockFor(currentBlock, null);
            else
                currentBlock.child = new BlockIf(currentBlock, null);

            currentBlock = currentBlock.child;
        }


        private void CloseBlock(StatementTypes type)
        {
            bool hasNoChild = (currentBlock.child == null);
            bool isExpectedBlock = (type == StatementTypes.LOOP) ? (currentBlock is BlockFor) : (currentBlock is BlockIf);

            if (hasNoChild && isExpectedBlock)
                CloseCurrentBlock();
            else
                CantCloseBlock(type);
        }

        private void CantCloseBlock(StatementTypes type)
        {
            string error;

            if (type == StatementTypes.LOOP)
            {
                if (currentBlock.parent is BlockFor)
                {
                    error = ERROR_MISSING_ENDIF;
                    CloseParentBlock();
                }
                else
                    error = ERROR_EXTRA_NEXT;
            }
            else
            {
                if (currentBlock.parent is BlockIf)
                {
                    error = ERROR_MISSING_NEXT;
                    CloseParentBlock();
                }
                else
                    error = ERROR_EXTRA_ENDIF;
            }

            errors.Add(error);
        }

        private void CloseCurrentBlock()
        {
            currentBlock = currentBlock.parent;
            currentBlock.child = null;
        }

        private void CloseParentBlock()
        {
            currentBlock = currentBlock.parent.parent;
            currentBlock.child = null;
        }


    }
}
