namespace DailyProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = Tools.ReadFile("res\\e266_input.txt");

            string[] lines = new string[]
            {
                "    ",
                "VAR I",
                " FOR I=1 TO 31",
                "               IF !(I MOD 3) THEN",
                "  PRINT \"FIZZ\"",
                "       ENDIF",
                "                   IF !(I MOD 5) THEN",
                "                 PRINT \"BUZZ\"",
                "                   ENDIF",
                "               IF(I MOD 3) && (I MOD 5) THEN",
                "      PRINT \"FIZZBUZZ\"",
                "       ENDIF",
                "                NEXT",
            };

            e269_BASIC_Formatting challenge = new e269_BASIC_Formatting();
            challenge.CheckForErrors(lines);
        }
    }
}

