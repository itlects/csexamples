using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //substringTest1();

            //substringTest2();

            //substringTest3();
            
            //substringTest4();
            
            mySubstringTest1();

        }

        private static void substringTest4()
        {
            string str = "IndexOf Method LastIndexOf Method";

            // str.Length = 33
            // 13번째 인덱스부터 역순으로 "IndexOf"의 위치를 찾습니다.
            Console.WriteLine(str.LastIndexOf("IndexOf", str.Length - 20));
            Console.WriteLine("{0}", str.Substring(0, str.Length - 20));
        }

        private static void substringTest3()
        {
            string str = "IndexOf Method LastIndexOf Method";

            // 대소문자를 무시하는 검색 유형을 설정합니다.
            Console.WriteLine(str.IndexOf("indexof", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(str.LastIndexOf("indexof", StringComparison.OrdinalIgnoreCase));
        }

        private static void mySubstringTest1()
        {
            string s1 = "023D01000820552220007219129A03023E01000800721912BF0C1100C003";

            int position = s1.IndexOf("9A03");
            Console.WriteLine("pos:{0}, read: [{1}]{2}", position, (s1.Substring(position + 4)).Length, s1.Substring(position + 4));

            Console.WriteLine("token: {0}",s1.Substring(position, 4));
        }

        private static void substringTest2()
        {
            String[] pairs = { "Color1=red", "Color2=green", "Color3=blue",
                 "Title=Code Repository" };
            foreach (var pair in pairs)
            {
                int position = pair.IndexOf("=");
                if (position < 0)
                    continue;
                Console.WriteLine("Key: {0}, Value: '{1}'",
                               pair.Substring(0, position),
                               pair.Substring(position + 1));
            }
        }
        // The example displays the following output:
        //     Key: Color1, Value: 'red'
        //     Key: Color2, Value: 'green'
        //     Key: Color3, Value: 'blue'
        //     Key: Title, Value: 'Code Repository'


        /***
        * https://learn.microsoft.com/ko-kr/dotnet/api/system.string.substring?view=net-7.0
        * 
        */
        private static void substringTest1()
        {
            Console.WriteLine("substring test1");

            string[] info = { "Name: Felica Walker", "Title: Mz.",
                   "Age: 47", "Location: Paris", "Gender: F"};
            int found = 0;

            Console.WriteLine("The initial values in the array are:");
            foreach (string s in info)
                Console.WriteLine(s);


            Console.WriteLine("\nWe want to retrieve only the key information. That is:");
            foreach (string s in info)
            {
                found = s.IndexOf(": ");
                Console.WriteLine("   {0}", s.Substring(found + 2));
            }
        }
        // The example displays the following output:
        //       The initial values in the array are:
        //       Name: Felica Walker
        //       Title: Mz.
        //       Age: 47
        //       Location: Paris
        //       Gender: F
        //       
        //       We want to retrieve only the key information. That is:
        //          Felica Walker
        //          Mz.
        //          47
        //          Paris
        //          F
    }
}

