string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(filePath);

for (int i = 4; i < input.Length; i++)
    if (input[(i - 4)..i].Distinct().Count() == 4)
    {
        Console.WriteLine($"Part 1: {i}");
        break;
    }

for (int i = 14; i < input.Length; i++)
    if (input[(i - 14)..i].Distinct().Count() == 14)
    {
        Console.WriteLine($"Part 2: {i}");
        break;
    }
