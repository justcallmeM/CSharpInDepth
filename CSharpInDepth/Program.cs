using System;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace CSharpInDepth
{
    //class Program
    //{
    //    private int _number;
    //    public int Number
    //    {
    //        get => _number * 2;
    //        set => _number = value;
    //    }

    //    static void Main(string[] args)
    //    {
    //        Program program = new Program();

    //        program.Number = 2;

    //        Console.WriteLine(program.Number);

    //        var book = (title: "Lost in the Snow", author: "Holly Webb");
    //        Console.WriteLine(book.title);

    //        Console.ReadKey(true);
    //    }
    //}

    class Foo
    {
        private int bar;

        public string Name { get; set; }
        public int Age
        {
            get => bar;
            set
            {
                bar = value * 2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type foo = typeof(Foo);

            WriteLine("Methods =>\n" +
                        "__________\n\n");

            foreach (MethodInfo method in foo.GetMethods())
            {
                WriteLine(
                    $"{(method.IsPrivate ? "private" : "public")} " +
                    $"{method.Name}" +
                    $"({String.Join(',', method.GetParameters().Select(p => p.ParameterType))}) -> " +
                    $"{method.ReturnType}\n\n");
            }

            WriteLine("Fields =>\n" +
                        "__________\n\n");

            foreach (FieldInfo field in foo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                WriteLine(
                    $"{(field.IsPrivate ? "private" : "public")} {field.FieldType} {field.Name}");
            }

            ReadKey();
        }
    }
}
