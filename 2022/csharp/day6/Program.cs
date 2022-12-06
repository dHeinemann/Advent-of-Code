string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(filePath);

// Standard solution
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

// Bonus LINQ solution
Console.WriteLine($"Part 1: {FindStart(input,  4)} (LINQ)");
Console.WriteLine($"Part 2: {FindStart(input, 14)} (LINQ)");

int FindStart(string s, int length)
{
    return s.Select((_, i) => new
    {
        Index = i,
        Input = i >= length
            ? s[(i - length)..i]
            : string.Empty
    })
    .First(i => i.Input.Distinct().Count() == length)
    .Index;
}