using System;

using System.Linq;
using System.Text;

//-- https://www.delftstack.com/ko/howto/csharp/list-to-string-in-csharp/
//-- https://developer-talk.tistory.com/736
//-- https://zetcode.com/csharp/list-to-string/
//-- https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.list-1.count?view=net-7.0
//-- https://developer-talk.tistory.com/222
namespace ListTest // Note: actual namespace depends on the project name.
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }


    internal class Program
    {
        //public delegate TOutput Converter<in TInput, out TOutput>(TInput input);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //test1JoinToArray();
            //test2Aggregate();
            //test3ConvertAll();
            //test4ConvertAll2();
            //test5Lamda();
            //test6UserDefinedClass();
            //test7Linq ();
            //test8UserDefinedClass();

            //test9Join();
            //test10StringBuilder();
            //test11Aggregate();
            //test12String();

            //test13ListMethod();
            //test14ListMethod();

        }

        /// <summary>
        /// 다음 예제에서는 목록의 Count 수명에서 다양 한 지점에서 속성의 값을 보여 입니다. 
        /// 목록이 만들어지고 채워지고 해당 요소가 표시되면 Capacity 및 Count 속성이 표시됩니다. 
        /// 이러한 속성은 메서드가 TrimExcess 호출된 후 목록 내용이 지워진 후 다시 표시됩니다.
        /// </summary>
        private static void test14ListMethod()
        {
            List<string> dinosaurs = new List<string>();

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
                dinosaurs.Contains("Deinonychus"));

            Console.WriteLine("\nInsert(2, \"Compsognathus\")");
            dinosaurs.Insert(2, "Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            // Shows accessing the list using the Item property.
            Console.WriteLine("\ndinosaurs[3]: {0}", dinosaurs[3]);

            Console.WriteLine("\nRemove(\"Compsognathus\")");
            dinosaurs.Remove("Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            dinosaurs.TrimExcess();
            Console.WriteLine("\nTrimExcess()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            dinosaurs.Clear();
            Console.WriteLine("\nClear()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            /* This code example produces the following output:

            Capacity: 0

            Tyrannosaurus
            Amargasaurus
            Mamenchisaurus
            Deinonychus
            Compsognathus

            Capacity: 8
            Count: 5

            Contains("Deinonychus"): True

            Insert(2, "Compsognathus")

            Tyrannosaurus
            Amargasaurus
            Compsognathus
            Mamenchisaurus
            Deinonychus
            Compsognathus

            dinosaurs[3]: Mamenchisaurus

            Remove("Compsognathus")

            Tyrannosaurus
            Amargasaurus
            Mamenchisaurus
            Deinonychus
            Compsognathus

            TrimExcess()
            Capacity: 5
            Count: 5

            Clear()
            Capacity: 5
            Count: 0
             */
        }

        /// <summary>
        /// 다음 예제에서는 간단한 비즈니스 개체를 포함하는 의 List<T> 용량과 개수를 확인하는 방법을 보여 줍니다. 
        /// 메서드를 사용하여 TrimExcess 추가 용량을 제거하는 방법을 보여 줍니다.
        /// </summary>
        private static void test13ListMethod()
        {
            List<Part> parts = new List<Part>();

            Console.WriteLine("\nCapacity: {0}", parts.Capacity);

            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            Console.WriteLine("\nCapacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.TrimExcess();
            Console.WriteLine("\nTrimExcess()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.Clear();
            Console.WriteLine("\nClear()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);
            /*
         This code example produces the following output.
                Capacity: 0

                ID: 1234   Name: crank arm
                ID: 1334   Name: chain ring
                ID: 1434   Name: seat
                ID: 1534   Name: cassette
                ID: 1634   Name: shift lever

                Capacity: 8
                Count: 5

                TrimExcess()
                Capacity: 5
                Count: 5

                Clear()
                Capacity: 5
                Count: 0
         */
        }



        private static void test12String()
        {
            var words = new List<string> {"There", "are", "three", "chairs", "and", "two", "lamps", "in",  "the", "room"};

            string res = string.Empty;

            words.ForEach(word => {

                res += $"{word} ";
            });

            Console.WriteLine(res);
        }

        private static void test11Aggregate()
        {
            var words = new List<string> {"There", "are", "three", "chairs", "and", "two", "lamps", "in",  "the", "room"};

            var res = words.Aggregate((total, part) => $"{total} {part}");
            Console.WriteLine(res);
            //-- There are three chairs and two lamps in the room
        }

        //-- using System.Text;
        private static void test10StringBuilder()
        {
            var words = new List<string> {"There", "are", "three", "chairs", "and", "two", "lamps", "in",  "the", "room"};

            var builder = new StringBuilder();

            foreach (var word in words)
            {
                builder.Append(word).Append(" ");
            }

            Console.WriteLine(builder.ToString());

            //-- There are three chairs and two lamps in the room
        }

        private static void test9Join()
        {
            var words = new List<string> { "a", "visit", "to", "London" };
            
            var res = string.Join("-", words);
            Console.WriteLine(res);

            res = string.Join("", words);
            Console.WriteLine(res);
        }

        private static void test8UserDefinedClass()
        {
            List<Person> personList = new List<Person>()
            {
              new Person { Name = "둘리", Age = 20 },
              new Person { Name = "또치", Age = 30 },
              new Person { Name = "생선", Age = 40 }
            };

            List<User> userList = personList.Select(person => PersonToUser(person)).ToList();
            Console.WriteLine("personList의 요소");
            foreach (Person person in personList)
            {
                Console.WriteLine("Name: " + person.Name + ", Age: " + person.Age);
            }

            Console.WriteLine("\nuserList의 요소");
            foreach (User user in userList)
            {
                Console.WriteLine("Name: " + user.Name + ", Age: " + user.Age);
            }
        }

        private static void test7Linq()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            List<string> strList = intList.Select(num => num.ToString() + "번").ToList();

            Console.WriteLine("[strList의 요소]");
            Console.WriteLine(string.Join(", ", strList));
        }

        public static User PersonToUser(Person person)
        {
            return new User() { Name = person.Name, Age = (person.Age * 2).ToString() };
        }
        private static void test6UserDefinedClass()
        {
            List<Person> personList = new List<Person>()
            {
              new Person { Name = "둘리", Age = 20 },
              new Person { Name = "또치", Age = 30 },
              new Person { Name = "생선", Age = 40 }
            };

            List<User> userList = personList.ConvertAll(new Converter<Person, User>(PersonToUser));
            // 람다 표현식을 사용하는 경우
            /*
            List<User> userList = personList.ConvertAll(person => { 
              return new User() { Name = person.Name, Age = (person.Age * 2).ToString() };
            });
            */

            Console.WriteLine("personList의 요소");
            foreach (Person person in personList)
            {
                Console.WriteLine("Name: " + person.Name + ", Age: " + person.Age);
            }

            Console.WriteLine("\nuserList의 요소");
            foreach (User user in userList)
            {
                Console.WriteLine("Name: " + user.Name + ", Age: " + user.Age);
            }
        }

        private static void test5Lamda()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            List<string> strList = intList.ConvertAll(num => num.ToString() + "번");

            Console.WriteLine("[strList의 요소]");
            Console.WriteLine(string.Join(", ", strList));
        }

        public static string intToString2(int num)
        {
            return num.ToString() + "번";
        }
        private static void test4ConvertAll2()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            List<string> strList = intList.ConvertAll(new Converter<int, string>(intToString2));

            Console.WriteLine("[strList의 요소]");
            Console.WriteLine(string.Join(", ", strList));
        }

        public static string intToString(int num)
        {
            return num.ToString();
        }
        private static void test3ConvertAll()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            List<string> strList = intList.ConvertAll(new Converter<int, string>(intToString));

            Console.WriteLine("[strList의 요소]");
            Console.WriteLine(string.Join(", ", strList));
        }

        private static void test2Aggregate()
        {
            List<string> names = new List<string>() { "Ross", "Joey", "Chandler" };
            string joinedNames = names.Aggregate((x, y) => x + ", " + y);
            Console.WriteLine(joinedNames);

        }

        private static void test1JoinToArray()
        {
            List<string> names = new List<string>() { "Ross", "Joey", "Chandler" };
            string joinedNames = String.Join(", ", names.ToArray());
            Console.WriteLine(joinedNames);
        }
    }
}