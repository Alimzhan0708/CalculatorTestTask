using System;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static Brackets Brackets1 = new Brackets();
        static Divide Divide1 = new Divide();
        static Multiply Multiply1 = new Multiply();
        static Plus Plus1 = new Plus();
        static Minus Minus1 = new Minus();

        public class Operations
        {
            protected string operationSign = "";

            public string GetOperationSign()
            {
                return operationSign;
            }
        }

        public class Plus : Operations
        {
            public Plus()
            {
                operationSign = "+";
            }

            public void CalculatePlusOperations(List<double> TempNumbers, List<string> TempSigns)
            {
                if (TempSigns.Contains(operationSign))
                {
                    while (TempSigns.Contains(operationSign))
                    {
                        int Index = TempSigns.IndexOf(operationSign);
                        TempNumbers[Index] = TempNumbers[Index] + TempNumbers[Index + 1];
                        TempNumbers.Remove(TempNumbers[Index + 1]);
                        TempSigns.Remove(operationSign);
                    }
                }
            }
        }

        public class Minus : Operations
        {
            public Minus()
            {
                operationSign = "-";
            }

            public void CalculateMinusOperations(List<double> TempNumbers, List<string> TempSigns)
            {
                if (TempSigns.Contains(operationSign))
                {
                    while (TempSigns.Contains(operationSign))
                    {
                        int Index = TempSigns.IndexOf(operationSign);
                        TempNumbers[Index] = TempNumbers[Index] - TempNumbers[Index + 1];
                        TempNumbers.Remove(TempNumbers[Index + 1]);
                        TempSigns.Remove(operationSign);
                    }
                }
            }
        }

        public class Multiply : Operations
        {
            public Multiply()
            {
                operationSign = "*";
            }

            public void CalculateMultiplyOperations(List<double> TempNumbers, List<string> TempSigns)
            {
                if (TempSigns.Contains(operationSign))
                {
                    while (TempSigns.Contains(operationSign))
                    {
                        int Index = TempSigns.IndexOf(operationSign);
                        TempNumbers[Index] = TempNumbers[Index] * TempNumbers[Index + 1];
                        TempNumbers.Remove(TempNumbers[Index + 1]);
                        TempSigns.Remove(operationSign);
                    }
                }
            }
        }

        public class Divide : Operations
        {
            public Divide()
            {
                operationSign = "/";
            }

            public void CalculateDivideOperations(List<double> TempNumbers, List<string> TempSigns)
            {
                if (TempSigns.Contains(operationSign))
                {
                    while (TempSigns.Contains(operationSign))
                    {
                        int Index = TempSigns.IndexOf(operationSign);
                        TempNumbers[Index] = TempNumbers[Index] / TempNumbers[Index + 1];
                        TempNumbers.Remove(TempNumbers[Index + 1]);
                        TempSigns.Remove(operationSign);
                    }
                }
            }
        }

        public class Brackets
        {
            double Result = 0;
            string operationSign1 = "(";
            string operationSign2 = ")";

            List<double> TempNumbers = new List<double>();
            List<string> TempSigns = new List<string>();

            public void Calculate(List<double> Numbers, List<string> Signs)
            {
                if (Signs.Contains(operationSign1) && Signs.Contains(operationSign2))
                {
                    while (Signs.Contains(operationSign1) && Signs.Contains(operationSign2))
                    {
                        for (int x = Signs.IndexOf(operationSign1); x < Signs.IndexOf(operationSign2); x++)
                        {
                            TempNumbers.Add(Numbers[x]);
                            Console.WriteLine(Numbers[x]);
                        }

                        for (int x = Signs.IndexOf(operationSign1) + 1; x < Signs.IndexOf(operationSign2); x++)
                        {
                            TempSigns.Add(Signs[x]);
                            Console.WriteLine(Signs[x]);
                        }

                        BaseCalculation(TempNumbers, TempSigns);        
                        
                        Result = TempNumbers[0];
                        for (int y = Signs.IndexOf(operationSign1) + 1; y < Signs.IndexOf(operationSign2); y++)
                        {
                            Numbers.RemoveAt(y);
                        }

                        Numbers[Signs.IndexOf(operationSign1)] = Result;

                        Signs.RemoveRange(Signs.IndexOf(operationSign1), Signs.IndexOf(operationSign2)-1);
                    }
                }
                else
                {
                    return;
                }
            }

            public string GetOperation1()
            {
                return operationSign1;
            }
            public string GetOperation2()
            {
                return operationSign2;
            }
        }

        public class Parser
        {
            string[] TempNumbersInStrings;
            List<string> NumbersInStrings = new List<string>();
            List<double> Numbers = new List<double>();

            public void ParseNumbers(string userInput)
            {
                string[] separator = { Plus1.GetOperationSign(),Minus1.GetOperationSign(), Multiply1.GetOperationSign(),
                                       Divide1.GetOperationSign(), Brackets1.GetOperation1(), Brackets1.GetOperation2()};
                TempNumbersInStrings = userInput.Split(separator, StringSplitOptions.None);
                foreach (string number in TempNumbersInStrings)
                {
                    NumbersInStrings.Add(number);
                }
                for (int x = 0; x < NumbersInStrings.Count; x++)
                {
                    if (NumbersInStrings[x] == "")
                    {
                        NumbersInStrings.Remove(NumbersInStrings[x]);
                    }
                }
                foreach (string number in NumbersInStrings)
                {
                    Numbers.Add(double.Parse(number));
                }
            }

            public List<double> GetNumbers()
            {
                return Numbers;
            }

            //------------------------------------------------------------------------//

            List<string> Signs = new List<string>();

            public void ParseSigns(string userInput)
            {
                List<string> NumbersInStrings = new List<string>();
                foreach (double number in Numbers)
                {
                    NumbersInStrings.Add(number.ToString());
                }
                foreach (string numberInString in NumbersInStrings)
                {
                    userInput.Remove(NumbersInStrings.IndexOf(numberInString));
                }
                for (int x = 0; x < userInput.Length; x++)
                {
                    if (userInput[x] == '+' || userInput[x] == '-' || userInput[x] == '*' || userInput[x] == '/'
                        || userInput[x] == '(' || userInput[x] == ')')
                    {
                        Signs.Add(userInput[x].ToString());
                    }
                }
            }

            public List<string> GetSigns()
            {
                return Signs;
            }
        }       

        public static void BaseCalculation(List<double> TempNumbers, List<string> TempSigns)
        {
            Divide1.CalculateDivideOperations(TempNumbers, TempSigns);            
            Multiply1.CalculateMultiplyOperations(TempNumbers, TempSigns);
            Minus1.CalculateMinusOperations(TempNumbers, TempSigns);
            Plus1.CalculatePlusOperations(TempNumbers, TempSigns);
        }

        public static void Calculate(List<double> Numbers, List<string> Signs, out double Answer)
        {
            List<double> TempNumbers = new List<double>();
            TempNumbers = Numbers;

            Brackets1.Calculate(TempNumbers, Signs);
            BaseCalculation(TempNumbers, Signs);

            Answer = TempNumbers[0];
        }        

        static void Main(string[] args)
        {
            string userInput = "";
            userInput = Console.ReadLine();
            while (userInput.Contains(" "))
            {
                userInput = userInput.Replace(" ", "");
            }

            //------------------------------------------------------------------------//

            Parser Parser1 = new Parser();

            Parser1.ParseNumbers(userInput);
            List<double> Numbers = new List<double>();
            Numbers = Parser1.GetNumbers();

            Parser1.ParseSigns(userInput);
            List<string> Signs = new List<string>();
            Signs = Parser1.GetSigns();

            //------------------------------------------------------------------------//

            double Answer;
            Program.Calculate(Numbers, Signs, out Answer);
            Console.WriteLine(Answer);

            Console.ReadKey();
        }
    }
}

