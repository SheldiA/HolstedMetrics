using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Holsted
{
    class Holsted : IMetric
    {
        
        private string file;
        private ListStatementsAndOperands listStatementsAndOperands;

        private char[] endLineCode = { ';', '{', '}','(',')','[',']'};
        private string[] signStatement = { ">=", ">>>=", "<=", "<>", "!", "==", "=", "!=", "<<=", ">>=", "<<", ">>", ">", "<", "++", "--", "+=", "-=", "*=", "/=", "%=", "+", "-", "*", "/", "%", "&&", "||", "&=", "|=", "^=", "&", "|", "^"};
        private string[] keyWords = { "if","else","while","do","for","new","break","continue","goto","return","switch","case"};//case return отдельно??
        //Regex dataDeclarationRegex = new Regex(@"^\b\w+\b(\s+\b\w+\b){1,}(;|{|})$");
        Regex dataDeclarationRegex = new Regex(@"\s*\b\w+\b(\s+\b\w+\b){1,}");
        Regex digitalConstRegex = new Regex(@"\b\d+\b");
        Regex variableRegex = new Regex(@"\b\w+\b");
        

        public Holsted()
        {            
            listStatementsAndOperands = new ListStatementsAndOperands();
        }
        //return position to end / of comments
        private int SkipComments(int pos)
        {
            ++pos;
            if ((file[pos] != '*') && (file[pos] != '/'))
            {
                listStatementsAndOperands.AddStatement("/");
                return pos - 1;
            }
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

        private string RemoveConst(string str,string constant)
        {
            int pos = str.IndexOf(constant);
            int i = pos;
            while (str[i] != ',')
                --i;
            str = str.Remove(i,constant.Length + (pos - i));

            return str;
        }

        private void ParseCodeLine(string str)
        {
            bool isNotConstAndVar = false;
            if (!CheckKeyWords(str))
            {
                Match matchDigitalConst = digitalConstRegex.Match(str);
                while (matchDigitalConst.Success)
                {
                    listStatementsAndOperands.AddConst(matchDigitalConst.Value);
                    if (str.IndexOf(',') > -1)
                    {
                        str = RemoveConst(str, matchDigitalConst.Value);
                        isNotConstAndVar = false;
                    }
                    else
                        isNotConstAndVar = true;
                    matchDigitalConst = matchDigitalConst.NextMatch();
                }

                if (!isNotConstAndVar)
                {
                    Match matchDeclaration = dataDeclarationRegex.Match(str);
                    if (matchDeclaration.Success)
                    {
                        int position = 0;
                        if ((position = str.IndexOf(',')) > -1)
                        {
                            int i = position;
                            while ((i >= 0) && !((str[i] == ' ') && ((position - i) > 1)))
                                --i;
                            position = i;
                        }
                        else
                            position = matchDeclaration.Value.LastIndexOf(' ');
                        str = str.Substring(position);
                        Match matchVariable = variableRegex.Match(str);
                        while (matchVariable.Success)
                        {
                            listStatementsAndOperands.AddOperand(matchVariable.Value, true);
                            matchVariable = matchVariable.NextMatch();
                        }
                    }
                    else
                    {
                        Match matchVariable = variableRegex.Match(str);
                        while (matchVariable.Success)
                        {
                            if (listStatementsAndOperands.operandsName.Contains(matchVariable.Value))
                                listStatementsAndOperands.AddOperand(matchVariable.Value, false);
                            matchVariable = matchVariable.NextMatch();
                        }
                    }
                }
            }
        }

        private int CheckIsSign(int pos)
        {
            int result = -1;
            bool isEqual;
            for (int i = 0; i < signStatement.Length; ++i)
            {
                if ((pos + signStatement[i].Length - 1) < file.Length)
                {
                    isEqual = true;
                    for (int j = 0; j < signStatement[i].Length; ++j)
                    {
                        if (file[pos + j] != signStatement[i][j])
                            isEqual = false;
                    }
                    if (isEqual)
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result;
        }

        private bool CheckKeyWords(string str)
        {
            bool result = false;
            string keyWordsPattern = "";
            Regex keyWordRegex;
            for (int i = 0; i < keyWords.Length; ++i)
            {
                keyWordsPattern = @"\b" + keyWords[i] +"\\b";
                keyWordRegex = new Regex(keyWordsPattern);
                if (keyWordRegex.IsMatch(str))
                {
                    result = true;
                    listStatementsAndOperands.AddStatement(keyWords[i]);
                    break;
                }
            }

            return result;
        }

        public string Calculate(string file)
        {
            string result = "";
            string codeLine = "";
            int temp;

            this.file = file;

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
                    case '.':
                        codeLine = "";
                        listStatementsAndOperands.AddStatement(".");
                        break;
                    default:
                        if (endLineCode.Contains(file[i]) )
                        {
                            if(codeLine != "")
                                ParseCodeLine(codeLine);
                            codeLine = "";
                            listStatementsAndOperands.AddStatement(file[i].ToString());
                        }
                        else
                            if ((temp = CheckIsSign(i)) > -1)
                            {
                                if (codeLine != "")
                                    ParseCodeLine(codeLine);
                                codeLine = "";
                                listStatementsAndOperands.AddStatement(signStatement[temp]);
                                i += (signStatement[temp].Length - 1);
                            }
                            else
                                if ((file[i] != '\n') && (file[i] != '\r'))
                                    codeLine += file[i];
                        break;
                }                        
            }

            double uniqueStat = listStatementsAndOperands.GetUniqueStatementCount();
            double uniqueOper = listStatementsAndOperands.GetUniqueOperandsCount();
            double allStat = listStatementsAndOperands.GetStatesmentCount();
            double allOper = listStatementsAndOperands.GetOperandsCount();
            double n = uniqueStat + uniqueOper;
            double N = allOper + allStat;
            double V = N * Math.Log10(n) / Math.Log10(2);
            double Nn = uniqueStat * Math.Log10(uniqueStat) / Math.Log10(2) + uniqueOper * Math.Log10(uniqueOper) / Math.Log10(2);
            double Ll = 2 * uniqueOper / (uniqueStat * allOper) ;
            result += "Число уникальных операторов проограммы = " +  Math.Round(uniqueStat,3) + " \n";
            result += "Число уникальных операндов проограммы = " + Math.Round(uniqueOper,3) + " \n";
            result += "Словарь программы n = " + Math.Round(n,3) + "\n";
            result += "Общее число операторов в программе = " + Math.Round(allStat,3) + "\n";
            result += "Общее число операндов в программе = " + Math.Round(allOper,3) + "\n";
            result += "Длина программы N = " + Math.Round(N,3) + "\n";
            result += "Теоретическая длина программы N' = " + Math.Round(Nn,3) + "\n";
            result += "Объём программы V = " + Math.Round(V,3) + "\n";
            result += "Уровень качества программирования L' = " + Math.Round(Ll,3) + "\n";
            return result;
        }

    }
}
