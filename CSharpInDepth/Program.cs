using System;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace CSharpInDepth
{
    class Program
    {
        private int _number;
        public int Number
        {
            get => _number * 2;
            set => _number = value;
        }
        
        static void Main(string[] args)
        {
            GetSetPractice();
            AnonymousTypesPractice();

            Console.ReadKey(true);
        }

        static void GetSetPractice()
        {
            Program program = new Program();

            program.Number = 2;
            Console.WriteLine(program.Number);
        }
        static void AnonymousTypesPractice()
        {
            var book = (title: "Lost in the Snow", author: "Holly Webb");
            Console.WriteLine(book.title);
        }
        static void GenericsPractice1()
        {
            //restrictions
        }
        static void GenericsPractice2()
        {
            GenericCounter<string>.Increment();
            GenericCounter<string>.Increment();
            GenericCounter<string>.Display();

            GenericCounter<int>.Display();
            GenericCounter<int>.Increment();
            GenericCounter<int>.Display();
        }
        static void NullableTypes()
        {
            Nullable.PrintValueAsInt32(5); //prints 5
            Nullable.PrintValueAsInt32("some string"); // prints null
        }
    }

    class GenericCounter<T>
    {
        //typeof practice
        private static int value;
        static GenericCounter()
        {
            Console.WriteLine($"Initializing counter for {typeof(T)}: {value}");
        }
        public static void Increment()
        {
            value++;
        }
        public static void Display()
        {
            Console.WriteLine($"Counter for {typeof(T)}: {value}");
        }
    }


    static class Nullable
    {
        public static void PrintValueAsInt32(object o)
        {
            int? nullable = o as int?;
            Console.WriteLine(nullable.HasValue ?
                              nullable.Value.ToString() : "null");
        }

        public static void EvaluateToNull()
        {
            // ?? - null coalescing operator
            // int w = x ?? y ?? z; 
            int? a = 5;
            int b = 10;
            int c = a ?? b;
        }
    }

    static class Delegates
    {
        //encapsulate apiece of code so that it can be passed around and executed 
        //as necessary in a type-safe fashion in terms of the return type and parameters.

        //anonymous methods.
    }

    //class Foo
    //{
    //    private int bar;

    //    public string Name { get; set; }
    //    public int Age
    //    {
    //        get => bar;
    //        set
    //        {
    //            bar = value * 2;
    //        }
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Type foo = typeof(Foo);

    //        WriteLine("Methods =>\n" +
    //                    "__________\n\n");

    //        foreach (MethodInfo method in foo.GetMethods())
    //        {
    //            WriteLine(
    //                $"{(method.IsPrivate ? "private" : "public")} " +
    //                $"{method.Name}" +
    //                $"({String.Join(',', method.GetParameters().Select(p => p.ParameterType))}) -> " +
    //                $"{method.ReturnType}\n\n");
    //        }

    //        WriteLine("Fields =>\n" +
    //                    "__________\n\n");

    //        foreach (FieldInfo field in foo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    //        {
    //            WriteLine(
    //                $"{(field.IsPrivate ? "private" : "public")} {field.FieldType} {field.Name}");
    //        }

    //        ReadKey();
    //    }
    //}
}
