// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Person
    {
        private string name; // field
        public string Name   // property
        {
            get { return name; }
            set { name = value; }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            Person myObj = new Person();
            myObj.Name = "Liam";
            Console.WriteLine(myObj.Name);
        }
    }
}