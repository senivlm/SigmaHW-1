namespace Task12_3
{
    internal static class ExampleCalculator
    {

        public static double CalculatePolandPostfix(string expresion, ProceduresRepository procedures)
        {
            Stack<double> operation = new Stack<double>();
            double tempDouble = default;

            string[] examples = expresion.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < examples.Length; i++)
            {
                if (double.TryParse(examples[i], out tempDouble))
                {
                    operation.Push(tempDouble);
                }
                else
                {
                    if (operation.Count == 1)
                    {
                        //operation.Push(procedures.GetFunction(examples[i]).Invoke(operation.Pop(), default));
                        operation.Push(procedures.GetFunktion(examples[i], operation.Pop(), default));
                    }
                    else
                    {
                        //operation.Push(procedures.GetFunction(examples[i]).Invoke(operation.Pop(), operation.Pop()));
                        operation.Push(procedures.GetFunktion(examples[i], operation.Pop(), operation.Pop()));
                    }

                }
            }

            return operation.Pop();
        }

        public static string CalculatePolandPostfixTotal(string expresion, ProceduresRepository procedures)
        {
            Stack<double> operation = new();
            double tempDouble = default;
            string result = "";

            string[] examples = (ExpressionParser.ToPalandPostfix(expresion, procedures))
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < examples.Length; i++)
            {
                if (double.TryParse(examples[i], out tempDouble))
                {
                    operation.Push(tempDouble);
                }
                else
                {
                    if (operation.Count == 1)
                    {
                        //operation.Push(procedures.GetFunction(examples[i]).Invoke(operation.Pop(), default));
                        operation.Push(procedures.GetFunktion(examples[i], operation.Pop(), default));
                    }
                    else
                    {
                        //operation.Push(procedures.GetFunction(examples[i]).Invoke(operation.Pop(), operation.Pop()));
                        operation.Push(procedures.GetFunktion(examples[i], operation.Pop(), operation.Pop()));
                    }

                }
            }
            foreach (var item in examples)
            {
                result += item + " ";
            }

            return $"{result}= {Math.Round(operation.Pop(), 4)}";
        }

    }
}
