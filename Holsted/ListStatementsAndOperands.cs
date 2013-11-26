using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Holsted
{
    class ListStatementsAndOperands
    {
        private List<string> statementsName;
        private List<int> statementsCount;
        public List<string> operandsName;
        private List<int> operandsCount;
        private List<string> constsName;
        private List<int> constsCount;

        private int numberUniqueOperands;

        public ListStatementsAndOperands()
        {
            statementsName = new List<string>();
            operandsName = new List<string>();
            statementsCount = new List<int>();//while -= do else не выводить
            operandsCount = new List<int>();
            constsName = new List<string>();
            constsCount = new List<int>();
            numberUniqueOperands = 0;
        }

        public void AddElement(List<string> elementsName, List<int> elementsCount,string element)
        {
            int position = elementsName.IndexOf(element);
            if (position > -1)
                ++elementsCount[position];
            else
            {
                elementsName.Add(element);
                elementsCount.Add(1);
            }
        }

        public void AddOperand(string operand,bool isUnique)
        {
            AddElement(operandsName, operandsCount, operand);
            if (isUnique)
                ++numberUniqueOperands;
        }

        public void AddStatement(string statement)
        {
            AddElement(statementsName, statementsCount, statement);
        }

        public void AddConst(string constant)
        {
            AddElement(constsName, constsCount, constant);
        }

        public int GetUniqueStatementCount()
        {
            int result = 0;
            for (int i = 0; i < statementsName.Count; ++i)
                if (statementsName[i] != "}" && statementsName[i] != ")" && statementsName[i] != "]")
                    ++result;
            return result;
        }

        public int GetUniqueOperandsCount()
        {
            return (numberUniqueOperands + constsName.Count);
        }

        public int StatCount(string stat)
        {
            int i = statementsName.IndexOf(stat);
            if (i > -1)
                return statementsCount[i];
            else
                return 0;
        }

        public int GetStatesmentCount()
        {
            int result = 0;

            result = statementsCount.Sum();
            result -= StatCount("do");
            result -= StatCount("}");
            result -= StatCount(")");
            result -= StatCount("]");
            result -= StatCount("else");
            return result;
        }

        public int GetOperandsCount()
        {
            return (operandsCount.Sum() + constsCount.Sum());
            
        }
    }
}
