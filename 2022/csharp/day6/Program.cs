string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(filePath);

int? part1Answer = null;
int? part2Answer = null;
for (int i = 4; i < input.Length; i++)
{
    if (part1Answer == null)
    {
        var characters = new HashSet<char>(input[(i - 4)..i]);
        if (characters.Count == 4)
            part1Answer = i;
    }

    if (part2Answer == null && i >= 14)
    {
        var characters = new HashSet<char>(input[(i - 14)..i]);
        if (characters.Count == 14)
            part2Answer = i;
    }

    if (part1Answer != null && part2Answer != null)
        break;
}

Console.WriteLine($"Part 1: {part1Answer}");
Console.WriteLine($"Part 2: {part2Answer}");
