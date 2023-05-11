using System;


//-- https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/operators/pointer-related-operators
//-- https://www.tutorialspoint.com/how-to-compile-unsafe-code-in-chash
//-- https://bm4904.tistory.com/21
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //test1();
            //test2PointerMemberAccess();
            //test3PointerArrayMemberAccess();
            test4PointerArrayMemberAccessByAddress();
            //test5PointerArrayMemberAddressCalc();
            //test6PointerArrayMemberAccessByPointerInDecrease();
        }

        private static unsafe void test6PointerArrayMemberAccessByPointerInDecrease()
        {
            int* numbers = stackalloc int[] { 0, 1, 2 };
            int* p1 = &numbers[0];
            int* p2 = p1;
            Console.WriteLine($"Before operation: p1 - {(long)p1}, p2 - {(long)p2}");
            Console.WriteLine($"Postfix increment of p1: {(long)(p1++)}");
            Console.WriteLine($"Prefix increment of p2: {(long)(++p2)}");
            Console.WriteLine($"After operation: p1 - {(long)p1}, p2 - {(long)p2}");

            // Output is similar to
            // Before operation: p1 - 816489946512, p2 - 816489946512
            // Postfix increment of p1: 816489946512
            // Prefix increment of p2: 816489946516
            // After operation: p1 - 816489946516, p2 - 816489946516
        }

        private static unsafe void test5PointerArrayMemberAddressCalc()
        {
            int* numbers = stackalloc int[] { 0, 10, 20, 30, 40, 50 };
            int* p1 = &numbers[1];
            int* p2 = &numbers[5];
            Console.WriteLine(p2 - p1);  // output: 4
        }

        private static unsafe void test4PointerArrayMemberAccessByAddress()
        {
            const int Count = 3;
            int[] numbers = new int[Count] { 10, 20, 30 };
            fixed (int* pointerToFirst = &numbers[0])
            {
                pointerToFirst[0] = (pointerToFirst[1] + 1);

                int* pointerToLast = pointerToFirst + (Count - 1);

                Console.WriteLine($"Value {*pointerToFirst} at address {(long)pointerToFirst}");
                Console.WriteLine($"Value {*pointerToLast} at address {(long)pointerToLast}");
            }
            foreach(int n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            ++numbers[1];
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
            // Output is similar to:
            // Value 10 at address 1818345918136
            // Value 30 at address 1818345918144
        }

        private static unsafe void test3PointerArrayMemberAccess()
        {
            char* pointerToChars = stackalloc char[123];

            for (int i = 65; i < 123; i++)
            {
                pointerToChars[i] = (char)i;
            }

            Console.Write("Uppercase letters: ");
            for (int i = 65; i < 91; i++)
            {
                Console.Write(pointerToChars[i]);
            }

            // Output:
            // Uppercase letters: ABCDEFGHIJKLMNOPQRSTUVWXYZ
        }

        public struct Coords
        {
            public int X;
            public int Y;
            public override string ToString() => $"({X}, {Y})";
        }

        public static unsafe void test2PointerMemberAccess()
        {
            Coords coords;
            Coords* p = &coords;
            p->X = 3;
            p->Y = 4;
            Console.WriteLine(p->ToString());  // output: (3, 4)
        }

        private static void test1()
        {
            unsafe
            {
                char letter = 'A';
                char* pointerToLetter = &letter;
                Console.WriteLine($"Value of the `letter` variable: {letter}");
                Console.WriteLine($"Address of the `letter` variable: {(long)pointerToLetter:X}");

                *pointerToLetter = 'Z';
                Console.WriteLine($"Value of the `letter` variable after update: {letter}");
            }
            // Output is similar to:
            // Value of the `letter` variable: A
            // Address of the `letter` variable: DCB977DDF4
            // Value of the `letter` variable after update: Z
        }
    }
}