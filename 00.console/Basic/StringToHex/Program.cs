﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// see https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types
stringToHex();

void stringToHex()
{
    string input = "Hello World!";
    char[] values = input.ToCharArray();
    foreach (char letter in values)
    {
        // Get the integral value of the character.
        int value = Convert.ToInt32(letter);
        // Convert the integer value to a hexadecimal value in string form.
        Console.WriteLine($"Hexadecimal value of {letter} is {value:X}");
    }
    /* Output:
        Hexadecimal value of H is 48
        Hexadecimal value of e is 65
        Hexadecimal value of l is 6C
        Hexadecimal value of l is 6C
        Hexadecimal value of o is 6F
        Hexadecimal value of   is 20
        Hexadecimal value of W is 57
        Hexadecimal value of o is 6F
        Hexadecimal value of r is 72
        Hexadecimal value of l is 6C
        Hexadecimal value of d is 64
        Hexadecimal value of ! is 21
     */
}

