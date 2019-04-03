using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class SecretCodeGenerator
    {
        private Random random = new Random();
        private int numOfDigits;
        private int minDigit;
        private int maxDigit;

        public SecretCodeGenerator(int numOfDigitsIn, int minIn, int maxIn)
        {
            numOfDigits = numOfDigitsIn;
            minDigit = minIn;
            maxDigit = maxIn;
        }
        public List<int> GenerateCode()
        {
            List<int> result = new List<int>();

            for(int i = 0; i < numOfDigits; i++)
            {
                int randomNum = GenerateDigit(minDigit, maxDigit);
                result.Add(randomNum);

            }

            return result;
        }

        private int GenerateDigit(int min, int max)
        {
            int num = random.Next(min, max + 1);
            return num;
        }
    }
}
