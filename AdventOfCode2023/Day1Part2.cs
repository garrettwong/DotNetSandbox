using System.Dynamic;
using System.Security.Cryptography;

internal class Day1Part2
{
    public static string ReplaceTextNumbers(string line)
    {
        line = line.Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");
        return line;
    }

    public static void Run(string[] args)
    {
        var text = System.IO.File.ReadAllText("day1part2.txt");
        var lines = text.Split('\n');

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine(text);

        var numbers = new List<int>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            // line replace...
            line = ReplaceTextNumbers(line);
            Console.WriteLine(line);

            Console.WriteLine($"Line: {line}");

            // find 2 digit number
            var intArr = new List<int>();
            foreach (var c in line.ToCharArray())
            {
                int result;
                if (int.TryParse(c.ToString(), out result))
                {
                    intArr.Add(result);
                }
            }
            numbers.Add(intArr[0] * 10 + intArr[intArr.Count - 1]);
        }

        var total = 0;
        foreach (var n in numbers)
        {
            Console.WriteLine(n);
            total += n;
        }

        Console.WriteLine(total);
    }
}