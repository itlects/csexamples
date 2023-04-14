using System;
using System.Text;

namespace Basic // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //-- byte test
            //ByteTest1();
            //ByteTest2();//한글ASCII -> byte 변환 출력 
            //ByteTest3(); //한글->hex 변환

            //--date format test    
            //DateTimeTest();
            //DateTimeTest("2023/03/23 13:50:21");//날자 데이터 처리 
            
            //-- protocol format test
            DateToBCDTest();//날자 YYYYMMDD hhmmss 변환
        }

        private static void DateTimeTest()
        {
            DateTime dt1;
            if (DateTime.TryParse("2021/8/24", out dt1))
                Console.WriteLine(dt1);

            DateTime dt2;
            if (DateTime.TryParse("2021/8/24 10:24:20", out dt2))
                Console.WriteLine(dt2);
        }

        private static void DateTimeTest(string date)
        {
            string s1 = "1999/9/9";//20230327160751
            if (date != null) {
                s1 = date;
            }

            // String을 DateTime으로 변환
            DateTime dt = DateTime.Parse(s1);

            // DateTime을 String으로 변환
            string sDate = dt.ToString("yyyy/MM/dd HH:mm:ss");

            Console.WriteLine("{0}", sDate);
        }

        private static void DateToBCDTest()
        {

            // 20230327160751(0x20, 0x23, 0x03, 0x27, 0x16, 0x07, 0x51, )
            string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            Console.WriteLine("DateTime.Now : {0}", dateTime);

            Console.WriteLine("------ UseGetNumericValue");
            foreach (int v in UseGetNumericValue(dateTime))
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("------ StringToBCD");

            byte[] bcdByte = StringToBCD(dateTime);
            foreach (int v in StringToBCD(dateTime))
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("------ BCDToString");
            Console.WriteLine(BCDToString(bcdByte));


        }

        private static int[] UseGetNumericValue(string value)
        {
            int[] bcd = new int[4];

            bcd[0] = ((int)Char.GetNumericValue(value, 0)) << 12 | ((int)Char.GetNumericValue(value, 1)) << 8 |
                ((int)Char.GetNumericValue(value, 2)) << 4 | ((int)Char.GetNumericValue(value, 3));
            bcd[1] = ((int)Char.GetNumericValue(value, 4)) << 12 | ((int)Char.GetNumericValue(value, 5)) << 8 |
                ((int)Char.GetNumericValue(value, 6)) << 4 | ((int)Char.GetNumericValue(value, 7));
            bcd[2] = ((int)Char.GetNumericValue(value, 8)) << 12 | ((int)Char.GetNumericValue(value, 9)) << 8 |
                ((int)Char.GetNumericValue(value, 10)) << 4 | ((int)Char.GetNumericValue(value, 11));
            bcd[3] = ((int)Char.GetNumericValue(value, 12)) << 4 | ((int)Char.GetNumericValue(value, 13));

            return bcd;
        }

        private static byte[] StringToBCD(string value)
        {
            int valueLength = value.Length;
            byte[] bcd = new byte[valueLength / 2];

            for (int i = 0; i < valueLength; i += 2)
            {
                bcd[i / 2] = Convert.ToByte(value[i].ToString(), 16);
                bcd[i / 2] <<= 4;
                bcd[i / 2] |= Convert.ToByte(value[i + 1].ToString(), 16);
            }

            return bcd;
        }

        private static string BCDToString(byte[] bcd)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bcd.Length; i++)
            {
                sb.Append(bcd[i] >> 4);
                sb.Append(bcd[i] & 0x0F);
            }

            return sb.ToString();
        }



        private static void ByteTest3()
        {

        }

        private static void ByteTest2()
        {
            //string s1 = "가나다";
            string s1 = "abc가123";

            char[] cs  = s1.ToCharArray();
            Console.WriteLine("=> char: ");
            foreach (char c in cs)
            {
                Console.WriteLine("{0}", (int)c);

            }

            Console.WriteLine();
            byte[] bs = System.Text.ASCIIEncoding.Default.GetBytes(s1);
            Console.WriteLine("=> byte: ");
            foreach(char b in bs)
            {
                Console.WriteLine("{0}", (int)b);
            }

        }

        private static void ByteTest1()
        {
            string s1 = "abc";
            byte[] b1 = Encoding.Default.GetBytes(s1);
            
            Console.WriteLine("string s1: " + s1 );

            string msg = string.Format("hex: {0:X2}\r\n", b1[0]);

            Console.WriteLine("byte b1: " + b1);
            Console.WriteLine("hex s1: " + msg);


        }


        //1byte 길이의 바이트 -> 16진수 문자열
        public string ByteToString(byte srcByte)
        {
            return srcByte.ToString("X2");
        }

        //바이트배열-> 16진수 문자열 
        public string byteArrayToHexString(byte[] convBytes)
        {
            return BitConverter.ToString(convBytes).Replace("-", "");
        }

        //16진수 문자열 바이트배열 -> 문자열
        public string byteArrayToString(byte[] srcBytes)
        {
            return Encoding.Default.GetString(srcBytes);
        }

        //문자열-> 바이트배열
        public byte[] getByteArrayFromString(string sSrc)
        {
            byte[] retBytes;

            retBytes = Encoding.Default.GetBytes(sSrc);

            return retBytes;
        }

        //문자열 2자리->16진수 HEX
        // sting 78 -> 0x78
        public byte getHex(string srcValue)
        {
            //srcValue = "78";

            return Convert.ToByte(srcValue, 16);

            //리턴되는 값은 0x78
        }

        public string getByte(byte srcValue)
        {
            //srcValue = 0x78

            return Convert.ToString(srcValue, 16);

            //리턴값은 "78";
        }


    }
}