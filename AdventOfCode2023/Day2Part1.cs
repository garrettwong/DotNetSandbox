internal class Day2Part1
{
    public static void Run(string[] args)
    {
        var text = System.IO.File.ReadAllText("day2.txt");
        var lines = text.Split('\n');

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine(text);
        
        var allCubes = 0;
        int sum = 0;
        var numbers = new List<int>();
        for(var i = 0; i < lines.Length; i++) {
            var line = lines[i]; // i+1
            // Console.WriteLine($"Line: {line}");
            // split each line by colon than semi
            var first = line.Split(':')[0];
            var second = line.Split(':')[1];
            var segments = second.Split(';');

            var bMax = 14;
            var gMax = 13;
            var rMax = 12;
            

            var bGameMax = 0;
            var gGameMax = 0;
            var rGameMax = 0;
            
            var valid = true;
            foreach(var s in segments) { // each full game
                Console.WriteLine(s);

                foreach(var pair in s.Split(',')) { // each subgame
                    var num = pair.Trim().Split(' ')[0];
                    var color = pair.Trim().Split(' ')[1];
                    
                    Console.WriteLine(num);
                    Console.WriteLine(color);
                    
                    switch(color) {
                        case "blue":
                            if (bMax < int.Parse(num)) valid = false;
                            bGameMax = bGameMax < int.Parse(num) ? int.Parse(num) : bGameMax;
                            break;
                        case "red":
                            if (rMax < int.Parse(num)) valid = false;
                            rGameMax = rGameMax < int.Parse(num) ? int.Parse(num) : rGameMax;
                            break;
                        case "green":
                            if (gMax < int.Parse(num)) valid = false;
                            gGameMax = gGameMax < int.Parse(num) ? int.Parse(num) : gGameMax;
                            break;
                    }
                }
            }

            if (valid) {
                // Console.WriteLine("VALID: " + s);
                sum+=(i+1);
            }
            var cube = bGameMax * rGameMax * gGameMax;
            Console.WriteLine(bGameMax + " " + rGameMax + " " + gGameMax);
            Console.WriteLine("CUBE" + cube);
            allCubes += cube;
        }
        Console.WriteLine("AllCubes" + allCubes);
        Console.WriteLine("SUM" + sum);

        var total = 0;
        foreach(var n in numbers) {
            Console.WriteLine(n);
            total += n;
        }

        Console.WriteLine(total);
    }
}