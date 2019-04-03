using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        private const int NUM_OF_DIGITS = 4;
        private const int MIN_DIGIT = 1;
        private const int MAX_DIGIT = 6;
        private const char RED_PEG_SYMBOL = '+';
        private const char WHITE_PEG_SYMBOL = '-';
        private const int NUM_OF_ATTEMPTS_ALLOWED = 10;
        
        static void Main(string[] args)
        {
            SecretCodeGenerator generator = new SecretCodeGenerator(NUM_OF_DIGITS, MIN_DIGIT, MAX_DIGIT);
            MasterMindEvaluator evaluator = new MasterMindEvaluator();

            List<int> secretCode = generator.GenerateCode();
            Console.WriteLine("Secret Code Generated!");
            //StaticLibrary.printList("Secret", secretCode);

            int numOfAttemptsUsed = 0;
            Boolean isWin = false;
            while(!isWin && numOfAttemptsUsed < NUM_OF_ATTEMPTS_ALLOWED)
            {
                List<int> secretCodeCopy = new List<int>(secretCode);

                Console.WriteLine();
                StaticLibrary.PrintHorizontalLine();
                Console.WriteLine("ATTEMPT #" + (numOfAttemptsUsed + 1));
                StaticLibrary.PrintHorizontalLine();

                List<int> attemptCode = GetAttemptCode();

                StaticLibrary.PrintList("ATTEMPT CODE", attemptCode);

                AttemptResult result = evaluator.Evaluate(secretCodeCopy, attemptCode);
                string plusMinusStr = ConstructPlusMinusString(result.redPegs, result.whitePegs);
                Console.WriteLine("RESULT = " + plusMinusStr);

                if(result.redPegs == NUM_OF_DIGITS)
                {
                    isWin = true;
                }
                numOfAttemptsUsed++;
            }

            Console.WriteLine();
            StaticLibrary.PrintHorizontalLine();
            if (isWin)
            {
                Console.WriteLine("YOU WON IN " + numOfAttemptsUsed + " ATTEMPT(S)!");
                StaticLibrary.PrintList("SECRET CODE = ", secretCode);
            }
            else
            {
                Console.WriteLine("YOU LOSE!");
                StaticLibrary.PrintList("SECRET CODE = ", secretCode);
            }
            StaticLibrary.PrintHorizontalLine();

            Console.ReadKey();
        }

        private static List<int> GetAttemptCode() {
            List<int> attemptCode = new List<int>();

            for(int i = 0; i < NUM_OF_DIGITS; i++)
            {
                Console.WriteLine("Enter digit #" + (i + 1) + ":");
                int digit = GetDigit();
                attemptCode.Add(digit);
            }
            return attemptCode;
        }

        private static int GetDigit()
        {
            Boolean isDigit = false;
            int digit = 0;
            while (!isDigit)
            {
                string line = Console.ReadLine();

                try
                {
                    digit = Convert.ToInt32(line);

                    if(digit >= MIN_DIGIT && digit <= MAX_DIGIT)
                    {
                        isDigit = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer between " + MIN_DIGIT + " and " + MAX_DIGIT);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter an integer between " + MIN_DIGIT + " and " + MAX_DIGIT);
                }
            }

            return digit;
        }

        private static string ConstructPlusMinusString(int reds, int whites)
        {
            string constructedString = "";

            for (int r = 0; r < reds; r++)
            {
                constructedString = constructedString + RED_PEG_SYMBOL;
            }
            for (int w = 0; w < whites; w++)
            {
                constructedString = constructedString + WHITE_PEG_SYMBOL;
            }
            return constructedString;
        }
    }
}
