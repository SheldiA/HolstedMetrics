using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Holsted
{
    class ListStatementsAndOperands
    {
        struct Item
        {
            string name;
            int count;
            public Item(string str)
            {
                name = str;
                count = 0;
            }
        };

        private List<string> statementsName;
        private List<int> statementsCount;
        private List<string> operandsName;
        private List<int> operandsCount;
        private List<string> constsName;
        private List<int> constsCount;

        private int numberUniqueOperands;

        public ListStatementsAndOperands()
        {
            statementsName = new List<string>();
            operandsName = new List<string>();
            statementsCount = new List<int>();
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
    }
}
