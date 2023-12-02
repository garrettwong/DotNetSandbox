internal class Day1Part1
{
    public static void Run(string[] args)
    {
        var text = System.IO.File.ReadAllText("day1.txt");
        var lines = text.Split('\n');

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine(text);

        var numbers = new List<int>();
        for(var i = 0; i < lines.Length; i++) {
            var line = lines[i];
            Console.WriteLine($"Line: {line}");

            // find 2 digit number
            var intArr = new List<int>();
            foreach (var c in line.ToCharArray()) {    
                int result;
                if (int.TryParse(c.ToString(), out result)) {
                    intArr.Add(result);
                }   
            }
            numbers.Add(intArr[0] * 10 + intArr[intArr.Count-1]);
        }

        var total = 0;
        foreach(var n in numbers) {
            Console.WriteLine(n);
            total += n;
        }

        Console.WriteLine(total);
    }
}