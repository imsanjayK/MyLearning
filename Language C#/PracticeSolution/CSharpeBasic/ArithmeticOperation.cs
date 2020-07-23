using System;

namespace CSharpeBasic
{
    class ArithmeticOperation: Present
    {
        public static void Example()
        {

            int value1 = 10;
            int value2 = 5;
            int result;
            // Add +
            result = value1 + value2;
            Console.WriteLine($"Result of  {value1} + {value2} = {result}");

            // Subtract -
            result = value1 - value2;
            Console.WriteLine($"Result of  {value1} - {value2} = {result}");

            // Multiply *
            result = value1 * value2;
            Console.WriteLine($"Result of  {value1} * {value2} = {result}");
            
            // Divide /
            result = value1 / value2;
            Console.WriteLine($"Result of  {value1} / {value2} = {result}");
            
            // Module %
            result = value1 % value2;
            Console.WriteLine($"Result of  {value1} % {value2} = {result}");

            //Increment
            ++value1;
            Console.WriteLine($"Result of  {value1}");
            value1++;
            Console.WriteLine($"Result of  {value1}");
            
            //Decrement
            --value1;
            Console.WriteLine($"Result of  {value1}");
            value1--;
            Console.WriteLine($"Result of  {value1}");
        }
    }
}