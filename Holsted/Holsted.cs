using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Holsted
{
    class Holsted
    {
        
        private string file;
        private ListStatementsAndOperands listStatementsAndOperands;

        private char[] endLineCode = { ';', '{', '}','(',')','[',']'};
        //Regex dataDeclarationRegex = new Regex(@"^\b\w+\b(\s+\b\w+\b){1,}(;|{|})$");
        Regex dataDeclarationRegex = new Regex(@"\b\w+\b(\s+\b\w+\b){1,}");
        Regex digitalConst = new Regex(@"\b\d+\b");

        public Holsted(string file)
        {
            this.file = file;
            listStatementsAndOperands = new ListStatementsAndOperands();
        }
        //return position to end / of comments
        private int SkipComments(int pos)
        {
            ++pos;
            if ((file[pos] != '*') && (file[pos] != '/'))
                return pos - 1;
            ++pos;
            for (; pos < (file.Length - 1); ++pos)
                if (file[pos] == '\n')
                    break;
                else
                    if ((file[pos] == '*') && (file[pos + 1] == '/'))
                    {
                        ++pos;
                        break;
                    }
            return pos;
        }

        private int HandlingStringConst(int pos)
        {
            string stringConst = "";

            ++pos;
            while (file[pos] != '"' && pos < file.Length)
            {
                stringConst += file[pos];
                ++pos;
            }
            listStatementsAndOperands.AddConst(stringConst);

            return pos;
        }

        private void ParseCodeLine(string str)
        {
           Match matchDeclaration = dataDeclarationRegex.Match(str);
           if (matchDeclaration.Success)
           {
               string temp = matchDeclaration.Value;
               string variable = "";
               for (int i = temp.LastIndexOf(' ') + 1; i < temp.Length; ++i)
                   variable += temp[i];
               listStatementsAndOperands.AddOperand(variable, true);
           }

           Match matchDigitalConst = digitalConst.Match(str);
           if (matchDigitalConst.Success)
           {
               //в идеале получить значение между пробелами
               listStatementsAndOperands.AddConst(matchDigitalConst.Value);
           }
        }

        public string Calculate()
        {
            string result = "";
            string codeLine = "";

            for (int i = 0; i < file.Length; ++i)
            {
                switch (file[i])
                {
                    case '/':
                        i = SkipComments(i);
                        break;
                    case '"':
                        i = HandlingStringConst(i);
                        break;
                    default:
                        if (endLineCode.Contains(file[i]))
                        {
                            ParseCodeLine(codeLine);
                            codeLine = "";
                            listStatementsAndOperands.AddStatement(file[i].ToString());
                        }
                        else
                            if ((file[i] != '\n') && (file[i] != '\r'))
                                codeLine += file[i];
                        break;
                }                        
            }

            return result;
        }
    }
}
