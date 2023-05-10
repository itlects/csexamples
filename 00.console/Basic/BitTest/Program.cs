using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private bool GetBit(ushort status, int bitOffset) => ((int)status >> bitOffset & 1) > 0;

        // (uint) this._rawData[28] << 16 | (uint)this._rawData[29];

        static void Main(string[] args)
        {
            Console.WriteLine("Hello~ Bit Test!");

            //printDecimal2BitFormat(10);
            //myGetBitTest();
            //myRegisterTest();
            //myRegisterTest2();
            myRegisterTest3();
        }

        private static void myRegisterTest3()
        {
            ushort[] _rawData = new ushort[0x1f];
            _rawData[7] = 0b00000000_10000000;
            _rawData[8] = 0b00000000_01000000;
            printDecimal2BinaryFormat(_rawData[7] << 0x10, 32);//-- 0x10(16bit) left shift,  bin:00000000_10000000_00000000_00000000
            uint reg = (uint) (_rawData[7] << 0x10) | _rawData[8];
            printDecimal2BinaryFormat(reg, 32);
        }

        private static void myRegisterTest2()
        {
            int data = 0b_00001010_00000010_00000010_00001101;
            printDecimal2BinaryFormat((int)data, 32);
        }

        public static byte[] mergeByteArray(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            Array.Copy(a, 0, c, 0, a.Length);
            Array.Copy(b, 0, c, a.Length, b.Length);

            return c;
        }

        private static void myRegisterTest()
        {
            int data = 0b_00001010_00000010_00000010_00001101;
            ushort[] _rawData = new ushort[0x1f];// 0x1f = 31
            _rawData[0] = 0x0001;
            _rawData[1] = 0x0011;
            _rawData[28] = 0x0100;//0b_00000000_00000001_00000000_00000000


            printDecimal2BitFormat((int)data);
            
            printDecimal2BitFormat((int)_rawData[28]);

            for(int i = 0;i< 0x1f; i++) {
                printDecimal2BitFormat((int)_rawData[i]);
            }
        }

        private static void myGetBitTest()
        {
            ushort status = 0b_00000010_00001101;//-- 2B = 16bit

            int result = (int)status >> 3&1;// 오른쪽 하위 3bit를 버리고 4번째 bit를 사용해서 1(0b1)과 비교

            printDecimal2BitFormat((int)result);

            Console.WriteLine("{0}",result > 0);

        }


        private static void printDecimal2BinaryFormat(int value, int bitSize)
        {
            int number = value;
            string strBin = Convert.ToString(number, 2);
            strBin = strBin.PadLeft(bitSize, '0');
            Console.WriteLine($"bin:{strBin}");
        }
        private static void printDecimal2BinaryFormat(uint value, int bitSize)
        {
            uint number = value;
            string strBin = Convert.ToString(number, 2);
            strBin = strBin.PadLeft(bitSize, '0');
            Console.WriteLine($"bin:{strBin}");
        }
        /// <summary>
        /// deciaml입력->2진,8진,10진,16진 출력
        /// </summary>
        /// <param name="value">입력: integer value </param>
        private static void printDecimal2BitFormat(int value)
        {
            int number = value;
            string strBin;
            string strOct;
            string strDec;
            string strHex;

            strBin = Convert.ToString(number, 2);
            strOct = Convert.ToString(number, 8);
            strDec = Convert.ToString(number, 10);
            strHex = Convert.ToString(number, 16);

            Console.WriteLine($"bin:{strBin}");
            Console.WriteLine($"ocx:{strOct}");
            Console.WriteLine($"dec:{strDec}");
            Console.WriteLine($"hex:{strHex}");
        }
    }
}