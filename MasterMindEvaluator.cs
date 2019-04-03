using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class MasterMindEvaluator
    {
        private List<int> secretCode;
        private List<int> attemptCode;

        public AttemptResult Evaluate(List<int> secretCodeIn, List<int> attemptCodeIn)
        {
            secretCode = secretCodeIn;
            attemptCode = attemptCodeIn;

            AttemptResult result = new AttemptResult();

            //result.secretCode = new List<int>(secretCodeIn);
            result.redPegs = 0;
            result.whitePegs = 0;

            result.redPegs = GetRedPegs();

            if (result.redPegs != secretCode.Count)
            {
                result.whitePegs = GetWhitePegs();
            }

            return result;
        }

        private int GetRedPegs()
        {
            int numberOfRedPegs = 0;
            for(int i = 0; i < secretCode.Count; i++)
            {
                if(attemptCode[i] == secretCode[i])
                {
                    attemptCode[i] = 0;
                    secretCode[i] = 0;
                    numberOfRedPegs++;
                }
            }
            return numberOfRedPegs;
        }

        private int GetWhitePegs()
        {
            int numberOfWhitePegs = 0;
            for (int i = 0; i < secretCode.Count; i++)
            {
                int attemptNum = attemptCode[i];
                if (attemptNum != 0)
                {
                    int indexOfNum = secretCode.IndexOf(attemptNum);
                    if(indexOfNum >= 0)
                    {
                        numberOfWhitePegs++;
                        secretCode[indexOfNum] = 0;
                    }
                }
            }
            return numberOfWhitePegs;
        }
    }
}
