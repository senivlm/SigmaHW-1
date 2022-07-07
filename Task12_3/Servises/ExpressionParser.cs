using System.Text;

namespace Task12_3
{
    internal static class ExpressionParser
    {
        public static string ToPalandPostfix(string expresion, ProceduresRepository procedures)
        {
            string[] example = expresion.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> operation = new Stack<string>();
            double temp = 0;
            string result = "";
            string startFunk = procedures.GetStartBracket();
            string endFunk = procedures.GetEndtBracket();

            for (int i = 0; i < example.Length; i++)
            {
                if (double.TryParse(example[i], out temp))
                {
                    result += " " + temp;
                }
                else
                {
                    if (example[i] == endFunk)
                    {
                        while (operation.Count > 0
                            && procedures.GetPriority(operation.Peek()) != 0)
                        {
                            result += " " + operation.Pop();
                        }

                        if (operation.Count > 0) operation.Pop();
                        continue;
                    }
                    if (example[i] == startFunk)
                    {
                        operation.Push(example[i]);
                    }
                    else
                    {
                        if (operation.Count == 0 ||
                            procedures.GetPriority(operation.Peek()) < procedures.GetPriority(example[i]))
                        {
                            operation.Push(example[i]);
                        }
                        else
                        {
                            while (operation.Count > 0 &&
                                procedures.GetPriority(operation.Peek()) >= procedures.GetPriority(example[i]))
                            {
                                result += " " + operation.Pop();
                            }
                            operation.Push(example[i]);
                        }
                    }
                }
            }

            while (operation.Count > 0)
            {
                result += " " + operation.Pop();
            }

            return result.Trim();
        }

        public static string ToNormal(string expresion, ProceduresRepository procedures)
        {
            string[] example = expresion.Split();
            StringBuilder sb = new();
            Stack<string> operation = new Stack<string>();
            string result = "";
            string startFunk = procedures.GetStartBracket();
            string endFunk = procedures.GetEndtBracket();

            for (int i = 0; i < example.Length; i++)
            {
                for (int j = 0; j < example[i].Length; j++) 
                {
                    if (char.IsDigit(example[i][j]))
                    {
                        result = ParseStartDigitSymbol(example, result, i, j);
                    }
                    else
                    {
                        if (result != "")
                        {
                            result = ParseEndDigitSymbol(example, sb, result, i, j);
                        }
                        else
                        {
                            ParseOperations(example, sb, i, j);
                        }
                    }
                }
            }
            return sb.ToString().Trim(); ;
        }

        #region SubOperations

        private static string ParseEndDigitSymbol(string[] example, StringBuilder sb, string result, int i, int j)
        {
            if (example[i][j].Equals(','))
            {
                sb.Append(result + example[i][j]);
                result = "";
            }
            if (example[i][j].Equals('.'))
            {
                sb.Append(result + example[i][j].ToString().Replace(example[i][j], ','));
                result = "";
            }
            else
            {
                if (result != "")
                {
                    sb.Append(" " + result + " " + example[i][j] + " ");
                    result = "";
                }
            }

            return result;
        }

        private static void ParseOperations(string[] example, StringBuilder sb, int i, int j)
        {
            if (example[i][j].Equals('('))
            {
                sb.Append(" " + example[i][j] + " ");
            }
            if (example[i][j].Equals(')'))
            {
                sb.Append(" " + example[i][j] + " ");
            }
            if (!example[i][j].Equals(')') & !example[i][j].Equals('('))
            {
                sb.Append(example[i][j].ToString());
            }
        }

        private static string ParseStartDigitSymbol(string[] example, string result, int i, int j)
        {
            if (result == " ")
            {
                result += " " + example[i][j];
            }
            else
            {
                result += example[i][j];
            }

            return result;
        }

        #endregion
    }
}
