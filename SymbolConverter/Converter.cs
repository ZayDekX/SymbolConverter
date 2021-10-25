namespace SymbolConverter;

using System.Collections.Generic;
using System.Text;

public static class Converter
{
    public static string Convert(string input)
    {
        input = input.ToLower();
        var builder = new StringBuilder();
        
        var counts = GetSymbolCounts(input);

        foreach (var symbol in input)
        {
            if (counts[symbol] > 1)
            {
                builder.Append(')');
                continue;
            }

            builder.Append('(');
        }

        return builder.ToString();
    }

    private static Dictionary<char, int> GetSymbolCounts(string input)
    {
        var dict = new Dictionary<char, int>();

        foreach (var symbol in input)
        {
            if (!dict.ContainsKey(symbol))
            {
                dict[symbol] = 0;
            }
            dict[symbol]++;
        }

        return dict;
    }
}
