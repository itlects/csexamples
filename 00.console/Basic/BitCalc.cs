using System;

public class BitCalc
{
	public BitCalc()
	{
	}

    public static byte[] mergeByteArray(byte[] a, byte[] b)
    {
        byte[] c = new byte[a.Length + b.Length];
        Array.Copy(a, 0, c, 0, a.Length);
        Array.Copy(b, 0, c, a.Length, b.Length);

        return c;
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

    //1byte 길이의 바이트 -> 16진수 문자열
    public string ByteToString(byte srcByte)
    {
        return srcByte.ToString("X2");
    }

    //바이트배열-> 16진수 문자열 
    public static string byteArrayToHexString(byte[] convBytes)
    {
        return BitConverter.ToString(convBytes).Replace("-", "");
    }

    //16진수 문자열 바이트배열 -> 문자열
    public static string byteArrayToString(byte[] srcBytes)
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


    public static byte[] intToBytes(int i)
    {
        byte[] array = new byte[4];

        array[3] = (byte)(i & 0xFF);
        array[2] = (byte)((i >> 8) & 0xFF);
        array[1] = (byte)((i >> 16) & 0xFF);
        array[0] = (byte)((i >> 24) & 0xFF);

        return array;
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
}
