using System.Text.RegularExpressions;

namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInputInstructions();

            string input = GetInput();

            input = RemoveNonNumericalCharacters(input);

            var (xString, yString, nString) = ExtractIntegerString(input);

            try
            {
                var (X, Y, N) = StringToInt(xString, yString, nString);
                if (CheckInputConditions(X, Y, N)) PrintFizzBuzz(X, Y, N);
                else Console.WriteLine("Input conditions was not met.");
            }
            catch (Exception)
            {
                Console.WriteLine("The input must contain three integers.");
            }
        }

        private static void PrintInputInstructions()
        {
            Console.WriteLine("Input three integers in ascending order between 1 and 100.");
            Console.WriteLine();
        }

        private static string GetInput()
        {
            string input;
            int counter = 0;
            do
            {
                if (counter > 0)
                {
                    Console.WriteLine("Enter a correct input.");
                    Console.WriteLine();
                }
                input = Console.ReadLine();
                counter++;
            } while (input.Length < 5);

            return input;
        }

        private static string RemoveNonNumericalCharacters(string input)
        {
            string newInput = Regex.Replace(input, "[^0-9 ]", " ");

            newInput = TrimWhitespace(newInput);

            return newInput;
        }

        private static string TrimWhitespace(string input)
        {
            string newInput = input.Trim(new char[] { ' ' });

            return newInput;
        }

        private static (string, string, string) ExtractIntegerString(string input) 
        {
            string[] integers = new string[3];
            for (int i = 0; i < integers.Length; i++)
            {
                integers[i] = Regex.Match(input, @"\d+").Value;
                input = RemoveExtractedInteger(input, integers[i]);
            }

            return (integers[0], integers[1], integers[2]);
        }

        private static string RemoveExtractedInteger(string input, string integer)
        {
            char[] integerChar = integer.ToCharArray();
            string newInput = input.TrimStart(integerChar);

            newInput = TrimWhitespace(newInput);

            return newInput;
        }

        private static (int, int, int) StringToInt(string string1, string string2, string string3)
        {
            int int1 = int.Parse(string1);
            int int2 = int.Parse(string2);
            int int3 = int.Parse(string3);

            return (int1, int2, int3);
        }

        private static bool CheckInputConditions(int X, int Y, int N)
        {
            // 1 <= X < Y <= N <= 100

            if (X < 1) return false;
            if (X >= Y) return false;
            if (Y > N) return false;
            if (N > 100) return false;

            return true;
        }

        private static void PrintFizzBuzz(int X, int Y, int N)
        {
            Console.WriteLine();
            for (int i = 1; i <= N; i++)
            {
                if (i % X == 0 && i % Y == 0) Console.WriteLine("FizzBuzz");
                else if (i % X == 0) Console.WriteLine("Fizz");
                else if (i % Y == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }
        }
    }
}