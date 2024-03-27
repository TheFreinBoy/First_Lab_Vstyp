using System;
using System.Text;

class BinaryAdditionProgram
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введіть перше число у бінарному вигляді:");
        string Number1 = Console.ReadLine();
        Console.WriteLine("Введіть друге число у бінарному вигляді:");
        string Number2 = Console.ReadLine();

        string resultBinary = AddBinary(Number1, Number2);
        resultBinary = resultBinary.PadLeft(8, '0');
        Console.WriteLine($"Сума бінарних: {resultBinary}");
        Console.WriteLine($"Сума десяткових: {TranferIntoDecimal(resultBinary)}");

    }

    static string AddBinary(string Number1, string Number2)
    {
        int maxLength = Math.Max(Number1.Length, Number2.Length);
        int carry = 0;
        StringBuilder result = new StringBuilder();

        for (int i = 1; i <= maxLength; i++)
        {
            int bit1 = 0;
            if (Number1.Length >= i)
            {
                bit1 = Number1[Number1.Length - i] - '0';
            }
            int bit2 = 0;
            if (Number2.Length >= i)
            {
                bit2 = Number2[Number2.Length - i] - '0';
            }
            int sum = bit1 + bit2 + carry;
            result.Insert(0, (char)(sum % 2 + '0'));
            carry = sum / 2;
        }

        while (carry > 0)
        {
            result.Insert(0, (char)(carry % 2 + '0'));
            carry /= 2;
        }
        return result.ToString();
    }

    static double TranferIntoDecimal(string binaryNumber)
    {
        double[] number = new double[binaryNumber.Length];
        int degree = binaryNumber.Length - 1;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (binaryNumber[i] == '1')
            {
                number[i] = Math.Pow(2, degree);
                degree--;
            }
            else if (binaryNumber[i] == '0')
            {
                number[i] = 0;
                degree--;
            }          
        }
        double sum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            sum += number[i];
        }
        return sum;
    }
}
