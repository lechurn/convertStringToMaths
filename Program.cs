using System;
using System.Collections.Generic;

namespace calculateStringMath
{
    class Program
    {
        public static string Operator = "";
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // 1 + 1
            // 2 * 2
            // 1 + 2 + 3
            // 6 / 2
            // 11 + 23 
            // 11.1 + 23
            // 1 + 1 * 3 

            string[] statements = new string[]{
                "1 + 1 ",
                "2 * 2 ",
                "1 + 2 + 3 ",
                "6 / 2 ",
                "11 + 23 ",
                "11.1 + 23 ",
                "1 + 1 * 3 ",
                "1 + 1 * 3 / 2"
            };

            for (int index = 0; index < statements.Length; index++)
            {
                Console.WriteLine("");
                Console.WriteLine(String.Format("statement : {0} ", statements[index]));
                Calculate(statements[index]);
            }

            //Console.ReadLine();
        }

        public static bool IsNumeric(string input)
        {
            double test;
            return double.TryParse(input, out test);
        }

        public static double Calculate(string statement)
        {
            double ret = 0;

            if (IsNumeric(statement.Replace(" ","")))
            {
                ret = Convert.ToDouble(statement);
            }
            else
            {
                CalculateByStatement(statement);
            }

            return ret;
        }

        public static void CalculateByStatement(string statement)
        {
            var lines = statement.Split(" ");

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains('*'))
                {
                    CalculateWithOperators(lines, index);
                    return;
                }
            }

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains('/'))
                {
                    CalculateWithOperators(lines, index);
                    return;
                }
            }

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains('+'))
                {
                    CalculateWithOperators(lines, index);
                    return;
                }
            }

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains('-'))
                {
                    CalculateWithOperators(lines, index);
                    return;
                }
            }
        }

        public static void CalculateWithOperators(string[] lines, int currIndex)
        {
            var calculatedValue = 0d;
            var ret = "";

            calculatedValue = CalculateWithPrecedence(lines[currIndex - 1], lines[currIndex + 1], lines[currIndex]);

            for (int index = 0; index < lines.Length; index++)
            {
                if (index == currIndex)
                {
                    ret += calculatedValue + " ";
                }
                else
                {
                    if (!((index == currIndex - 1) || (index == currIndex + 1)))
                    {
                        ret += lines[index] + " ";
                    }
                }
            }

            Console.WriteLine(ret);
            Calculate(ret);
        }

        public static double CalculateWithPrecedence(string Value1, string Value2, string Operator)
        {
            double newValue = 0;
            switch (Operator)
            {
                case "*":
                    newValue = Convert.ToDouble(Value1) * Convert.ToDouble(Value2);
                    break;
                case "/":
                    newValue = Convert.ToDouble(Value1) / Convert.ToDouble(Value2);
                    break;
                case "+":
                    newValue = Convert.ToDouble(Value1) + Convert.ToDouble(Value2);
                    break;
                case "-":
                    newValue = Convert.ToDouble(Value1) - Convert.ToDouble(Value2);
                    break;
            }
            return newValue;
        }
    }
}
