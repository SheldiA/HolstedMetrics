using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Holsted
{
    class Mayers : IMetric
    {
        Regex patternConditional = new Regex(@"(for|if|while)\s?\(.*\)");
        
        Regex patternReturn = new Regex(@"\breturn\b");
        Regex patternCase = new Regex(@"case");
        Regex patternLogicalStatement = new Regex(@"&&|\|\|");

        public string Calculate(string file)
        {
            string result = "";
            string currLineCode = "";
            int numberCondition = 0;

            Match match = patternConditional.Match(file);
            
            MatchCollection findReturn = patternReturn.Matches(file);
            int numberReturn = findReturn.Count;
            MatchCollection findCase = patternCase.Matches(file);
            int numberCase = findCase.Count;
            int numberPredicat = 0;
            while (match.Success)
            {
                ++numberCondition;
                currLineCode = match.Value;
                MatchCollection findLogicalS = patternLogicalStatement.Matches(currLineCode);
                numberPredicat += findLogicalS.Count;

                match = match.NextMatch();
            }

            int cyclomaticComplexity = numberCondition + numberCase + 2 * numberReturn;
            result = "[ " + cyclomaticComplexity + " , " + (cyclomaticComplexity + numberPredicat) + " ]";
            return result;
        }
    }
}
