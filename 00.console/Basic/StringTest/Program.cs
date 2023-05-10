using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //StringArrayTest();
            //IntArrayTest();
            ByteArrayTest1();
            ByteArrayTest2();

        }

        private static void ByteArrayTest2()
        {
            Byte[] bs1 = new Byte[] { 0x01, 0x11, 0x02 };
            byte[] bs2 = new Byte[] { 0x10 }; 
            byte[] bs = mergeByteArray(bs1, bs2);
            foreach (byte b in bs)
            {
                Console.WriteLine("0x{0:X2}", b);
            }
        }

        private static void ByteArrayTest1()
        {
            Byte[] bs1 = new Byte[] { 1, 2, 3 };
            byte[] bs2 = new Byte[] { 10 };
            byte[] bs = mergeByteArray(bs1, bs2);
            foreach (byte b in bs)
            {
                Console.WriteLine(b);
            }
        }

        private static byte[] mergeByteArray(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            Array.Copy(a, 0, c, 0, a.Length);
            Array.Copy(b, 0, c, a.Length, b.Length);

            return c;
        }
        private static void IntArrayTest()
        {
            int[] ns = new int[] { 1, 2, 3 };
            ns = ns.Append(10).ToArray();

            foreach(int n in ns)
            {
                Console.WriteLine(n);
            }
        }

        private static void StringArrayTest()
        {
            // New String Array with a few default values
            string[] colorsArray = new string[] { "Red", "Blue" };

            // Using the .Append() method and converting it back to a string array
            colorsArray = colorsArray.Append("Yellow").ToArray();

            // Display values
            foreach (var item in colorsArray)
            {
                Console.WriteLine(item);
            }

        }
    }
}