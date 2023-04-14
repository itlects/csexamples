using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Basic // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-- test: ascii to char
            //asciiToCharTest();
            //asciiToCharTest2();

            //-- test: datetime 객체의 사용
            //DateTimeTest();
            //consolewritelineTest();

            //-- protocol format test
            // BCD표시: 2022년도 -> 0b0010 0b0000 0b0010 0b0010, 0x02 0x00 0x02 0x02
            // => string, dec: 2022 hex: 02000202
            //DateToBCDTest();//날자 YYYYMMDD hhmmss 변환

            //--test: 문자열->byte[]배열, byte[]배열->문자열
            //byte[] bytes = stringToByte("ABC123abc");
            //string s1 = byteToString(bytes);
            //Console.WriteLine(s1);


        }

        private static void asciiToCharTest2()
        {
            string s1 = "abc123ABC";
            byte[] ascii = stringToAscii(s1);
            string s2 = null;
            s2 = asciiToString(ascii);
            Console.WriteLine(s2);
        }

        private static void asciiToCharTest()
        {
            byte[] ascii = Encoding.ASCII.GetBytes("abc123ABC");
            foreach (byte b in ascii)
            {
                Console.Write(string.Format("0x{0:x} ", b));    // Ascii 
                Console.WriteLine(((Char)b).ToString());            // Ascii To Char
            }
        }

        private static void consolewritelineTest()
        {
            Console.WriteLine("Hello World!");

            //-- 출력방식
            int n1 = 3;
            ConsoleWriteline(n1);

            byte[] bytes = { 1, 2, 3 };
            foreach (byte b in bytes)
            {
                ConsoleWriteline(b);
            }


            byte[] bytes2 = { 93, 94, 95 };
            foreach (byte b in bytes2)
            {
                ConsoleWriteline(b);

            }
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
                ConsoleWriteline(v);
            }

            Console.WriteLine("------ DatetimeStringToBCD");

            byte[] bcdByte = StringToBCD(dateTime);
            foreach (int v in StringToBCD(dateTime))
            {
                ConsoleWriteline(v);
            }
            foreach (ushort v in StringToBCD(dateTime))
            {
                ConsoleWriteline(v);
            }
            Console.WriteLine("------ BCDToString");
            Console.WriteLine(BCDToString(bcdByte));


        }

        private static void ConsoleWriteline(int value)
        {
            Console.WriteLine("{0}", Convert.ToString(value, 16).PadLeft(4, '0'));

            string binaryStr = Convert.ToString(value, 2);
            int zeroCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(binaryStr.Length) / 8)) * 8;
            Console.WriteLine(Regex.Replace(binaryStr.PadLeft(zeroCount, '0'), ".{4}", "$0 ", RegexOptions.RightToLeft));
        }

        private static int[] UseGetNumericValue(string value)
        {
            int[] bcd = new int[4];// DEC: 1234 -> BCD: 0001 0010 0011 0100

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

        //--------------------------------------------------------------

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


        public static string ByteToHex(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }

        // string to byte
        public static byte[] stringToByte(string s)
        {
            //byte[] bytes;
            //bytes = Encoding.Default.GetBytes(s);

            // Convert a C# string to a byte array
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            foreach (byte b in bytes)
            {
                Console.WriteLine("{0:X2} ", b);
            }

            return bytes;
        }

        public static string byteToString(byte[] bytes)
        {
            string s1 = Encoding.ASCII.GetString(bytes);
            return s1;
        }


        public static byte[] stringToAscii(string s)
        {
            byte[] ascii = Encoding.ASCII.GetBytes(s);
            return ascii;
        }

        public static string asciiToString(byte[] ascii)
        {
            string s1 = null;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ascii)
            {
                sb.Append(((Char)b).ToString());
            }
            s1 = sb.ToString();
            return s1;
        }
    }
}