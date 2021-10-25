namespace SymbolConverter;

using System.Collections.Generic;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Write some text to convert:");
            Console.WriteLine(ProcessInput(Console.ReadLine()));
            Console.WriteLine();
        }
    }

    private static string ProcessInput(string input)
    {
        return Converter.Convert(input);
    }
}
