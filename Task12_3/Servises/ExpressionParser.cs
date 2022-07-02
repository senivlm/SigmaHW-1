namespace Task12_3
{
    internal static class ExpressionParser
    {
        public static string ToPalandPostfix(string expresion, ProceduresRepository procedures)
        {
            string[] example = expresion.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> operation = new Stack<string>();
            int temp = 0;
            string result = "";
            string startFunk = procedures.GetStartBracket();
            string endFunk = procedures.GetEndtBracket();

            for (int i = 0; i < example.Length; i++)
            {
                if (int.TryParse(example[i], out temp))
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



    }
}
