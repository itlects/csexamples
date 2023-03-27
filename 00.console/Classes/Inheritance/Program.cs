using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("inheritance demo!");
            Console.WriteLine();
            
            Console.WriteLine("1) inheritanceCarDemo()!");
            inheritanceCarDemo();
            Console.WriteLine();

            Console.WriteLine("2) inheritanceAnimalSoundDemo()!");
            inheritanceAnimalSoundDemo();
            Console.WriteLine();
        }

        //------------------------------------
        // inheritanceCarDemo()
        private static void inheritanceAnimalSoundDemo()
        {
            Animal myAnimal = new Animal();  // Create a Animal object
            Animal myPig = new Pig();  // Create a Pig object
            Animal myDog = new Dog();  // Create a Dog object

            myAnimal.animalSound();
            myPig.animalSound();
            myDog.animalSound();
        }

        private static void inheritanceCarDemo()
        {
            // Create a myCar object
            Car myCar = new Car();

            // Call the honk() method (From the Vehicle class) on the myCar object
            myCar.honk();

            // Display the value of the brand field (from the Vehicle class) and the value of the modelName from the Car class
            Console.WriteLine(myCar.brand + " " + myCar.modelName);
        }

        class Vehicle  // base class (parent) 
        {
            public string brand = "Ford";  // Vehicle field
            public void honk()             // Vehicle method 
            {
                Console.WriteLine("Tuut, tuut!");
            }
        }

        //------------------------------------
        // anaimalSoundDemo()
        class Car : Vehicle  // derived class (child)
        {
            public string modelName = "Mustang";  // Car field
        }


        class Animal  // Base class (parent) 
        {
            public void animalSound()
            {
                Console.WriteLine("The animal makes a sound");
            }
        }

        class Pig : Animal  // Derived class (child) 
        {
            public void animalSound()
            {
                Console.WriteLine("The pig says: wee wee");
            }
        }

        class Dog : Animal  // Derived class (child) 
        {
            public void animalSound()
            {
                Console.WriteLine("The dog says: bow wow");
            }
        }
    }
}