using System;

namespace CSharpeBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================[ START ]=========================");
            DeclareVariable.Example();
            ArithmeticOperation.Example();
            DataType.Example();
            Console.WriteLine("=======================[ END ]==========================");
           
        }
    }
    interface Present
    {
        static void Example() 
        {
            Console.WriteLine("Default inteterface method");
        }
    }
}
