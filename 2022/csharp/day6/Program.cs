string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(filePath);

for (int i = 4; i < input.Length; i++)
{
    var characters = new HashSet<char>(input[(i-4)..i]);
    if (characters.Count == 4)
    {
        Console.WriteLine($"Part 1: {i}");
        break;
    }
}
