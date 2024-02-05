// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static string upath = @".\\upath\\count.cfg";
        private static DateTime dt1 = DateTime.Now;
        static void Main(string[] args)
        {
            String s1 = "";
            Console.WriteLine("Hello DateTime TestApp!");
            dt1 = DateTime.Now;
            s1 = dt1.ToString("yyyy-MM-dd hh:mm:ss");

            Console.WriteLine("datetime: "+s1);

            if(Directory.Exists(upath)==false)
            {
                Directory.CreateDirectory(upath);
            }

            Console.WriteLine("path: "+ $"{Path.GetFileName(upath)}");
            Console.WriteLine("full path: " + $"{Path.GetFullPath(upath)}");

        }
    }
}