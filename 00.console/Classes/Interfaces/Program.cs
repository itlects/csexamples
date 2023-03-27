using System;

namespace Classes // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiple interfaces demo! \r\n");

            DemoClass myObj = new DemoClass();
            myObj.myMethod();
            myObj.myOtherMethod();
        }

        interface IFirstInterface
        {
            void myMethod(); // interface method
        }

        interface ISecondInterface
        {
            void myOtherMethod(); // interface method
        }

        // Implement multiple interfaces
        class DemoClass : IFirstInterface, ISecondInterface
        {
            public void myMethod()
            {
                Console.WriteLine("Some text..");
            }
            public void myOtherMethod()
            {
                Console.WriteLine("Some other text...");
            }
        }


    }
}