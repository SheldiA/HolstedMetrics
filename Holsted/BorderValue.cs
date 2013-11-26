using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Holsted
{
    class BorderValue : IMetric
    {
        public struct conditionalData
        {
            public string name;
            public int beginPosition;
            public int endPosition;
            public conditionalData(string name, int begin, int end)
            {
                this.name = name;
                this.beginPosition = begin;
                this.endPosition = end;
            }
        }

        private Regex cond = new Regex(@"while|if|else|for");
        Regex patternConditional = new Regex(@"(for|if|while|case)\s?\(.*\)");
        private Regex brace = new Regex(@"\}");
        Regex patternSemicolon = new Regex(@";");
        private List<int> positionEndConditional;

        private List<conditionalData> allConditionalStatement;
        private List<conditionalData> nameAndBegin;

        public BorderValue()
        {
            allConditionalStatement = new List<conditionalData>();
            nameAndBegin = new List<conditionalData>();
            positionEndConditional = new List<int>();
        }

        private void AssignEndPosition()
        {
            for (int i = 0; i < positionEndConditional.Count; ++i)
            {
                for (int j = 1; j < nameAndBegin.Count; ++j)
                {
                    if (positionEndConditional[i] > nameAndBegin[nameAndBegin.Count - 1].beginPosition)
                    {
                        allConditionalStatement.Add(new conditionalData(nameAndBegin[nameAndBegin.Count - 1].name,nameAndBegin[nameAndBegin.Count - 1].beginPosition,positionEndConditional[i]));
                        nameAndBegin.RemoveAt(nameAndBegin.Count - 1);
                        break;
                    }
                    else
                        if ((positionEndConditional[i] > nameAndBegin[j - 1].beginPosition) && (positionEndConditional[i] < nameAndBegin[j].beginPosition))
                        {
                            allConditionalStatement.Add(new conditionalData(nameAndBegin[j - 1].name,nameAndBegin[j - 1].beginPosition,positionEndConditional[i]));
                            nameAndBegin.RemoveAt(j - 1);
                            break;
                        }
                }
            }
            allConditionalStatement.Add(new conditionalData(nameAndBegin[0].name,nameAndBegin[0].beginPosition,positionEndConditional[positionEndConditional.Count - 1]));
        }

        public int AddInsertedNode()
        {
            int result = 0;

            for (int i = 0; i < allConditionalStatement.Count; ++i)
            {
                for (int j = i + 1; j < allConditionalStatement.Count; ++j)
                {
                    if (allConditionalStatement[j].beginPosition < allConditionalStatement[i].endPosition)
                        ++result;
                    else
                        break;
                }
            }

            return result;
        }

        public string Calculate(string file)
        {
            string result = "";

            Match matchCond = cond.Match(file);
            while (matchCond.Success)
            {
                nameAndBegin.Add(new conditionalData(matchCond.Value,matchCond.Index,0));
                matchCond = matchCond.NextMatch();
            }

            Match matchBrace = brace.Match(file);
            while (matchBrace.Success)
            {
                positionEndConditional.Add(matchBrace.Index);
                matchBrace = matchBrace.NextMatch();
            }
            AssignEndPosition();

            MatchCollection findSemicolon = patternSemicolon.Matches(file);
            int numberSemicolon = findSemicolon.Count;
            
            int numberGraphNode = numberSemicolon;
            MatchCollection findConditional = patternConditional.Matches(file);
            numberGraphNode += findConditional.Count;
            int absoluteBorderComplexity = numberGraphNode - 1 + AddInsertedNode();
            double relativeBorderComplexity = 1 - (double)(numberGraphNode - 1) / (double)absoluteBorderComplexity;

            result = "Относительная граничная сложность программы = " + Math.Round(relativeBorderComplexity,3);
            return result;
        }
    }
}
