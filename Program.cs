using System;
using System.Linq;
using System.Text;
namespace Name
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Введіть бінарні числа, які хочете додати: ");
            string input = Console.ReadLine();
            string input2 = Console.ReadLine();
            (char[], char[]) symbols = EnteringBinaryNumbers(input, input2);
            TransferIntoNumber(input, input2, symbols);
        }
        static (char[], char[]) EnteringBinaryNumbers(string input, string input2)
        {
            char[] symbol = input.ToCharArray();
            char[] symbol2 = input2.ToCharArray();
            (char[], char[]) symbols = (symbol, symbol2);
            return symbols;
        }
        static void TransferIntoNumber(string input, string input2, (char[], char[]) symbols)
        {
            double[] numbers = new double[input.Length];
            int degree = input.Length - 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (symbols.Item1[i] == '1')
                {
                    numbers[i] = Math.Pow(2, degree);
                    degree--;
                }
                else if (symbols.Item1[i] == '0')
                {
                    numbers[i] = 0;
                    degree--;
                }
            }
            int[] intNumbers = numbers.Select(d => (int)d).ToArray();
            int sumMassive1 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sumMassive1 += intNumbers[i];
            }

            double[] numbers2 = new double[input2.Length];
            int degree2 = input2.Length - 1;
            for (int i = 0; i < input2.Length; i++)
            {
                if (symbols.Item2[i] == '1')
                {
                    numbers2[i] = Math.Pow(2, degree2);
                    degree2--;
                }
                else if (symbols.Item2[i] == '0')
                {
                    numbers2[i] = 0;
                    degree2--;
                }
            }
            int[] intNumbers2 = numbers2.Select(d => (int)d).ToArray();
            int sumMassive2 = 0;
            for (int j = 0; j < input2.Length; j++)
            {
                sumMassive2 += intNumbers2[j];
            }
            SumOfNumbers(sumMassive1, sumMassive2);
        }
        static void SumOfNumbers(int sumMassive1, int sumMassive2)
        {
            int sum = sumMassive1 + sumMassive2;
            Console.WriteLine($"Сума чисел у десятковій формі: {sum}");
            TransferIntoBinary(sum);
        }
        static void TransferIntoBinary(int sum)
        {
            string binary = Convert.ToString(sum, 2);
            binary = binary.PadLeft(8, '0');
            Console.WriteLine($"Сума чисел у бінарному вигляді: {binary}");
        }
    }
}