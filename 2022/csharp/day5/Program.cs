string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string[] lines = File.ReadAllLines(filePath);

Stack<char>[] part1Stacks = GetStacks(lines.Take(8));
Stack<char>[] part2Stacks = GetStacks(lines.Take(8));

foreach (Procedure proc in GetProcedures(lines.Skip(10)))
{
    var toMove = new Stack<char>();
    for (int i = 0; i < proc.Count; i++)
    {
        // Part 1
        part1Stacks[proc.Destination - 1].Push(part1Stacks[proc.Source - 1].Pop());
        
        // Part 2
        toMove.Push(part2Stacks[proc.Source - 1].Pop());
    }
    
    // Part 2 (continued)
    while (toMove.Count > 0)
        part2Stacks[proc.Destination - 1].Push(toMove.Pop());
}

// Results
Console.WriteLine($"Part 1: {new string(part1Stacks.Select(s => s.Peek()).ToArray())}");
Console.WriteLine($"Part 2: {new string(part2Stacks.Select(s => s.Peek()).ToArray())}");

static List<Procedure> GetProcedures(IEnumerable<string> procedureLines) =>
    procedureLines.Select(line => new Procedure(
        Convert.ToInt32(line[ 5.. 7].Trim()),
        Convert.ToInt32(line[12..14].Trim()),
        Convert.ToInt32(line[17..  ].Trim())
    )).ToList();

static Stack<char>[] GetStacks(IEnumerable<string> stackLines)
{
    var stacks = new Stack<char>[9];
    for (int i = 0; i < 9; i++)
        stacks[i] = new Stack<char>();
    
    foreach (string stackLevel in stackLines.Reverse())
    {
        for (int i = 0; i < 9; i++)
        {
            char crate = stackLevel[i*4 + 1];
            if (crate != ' ')
                stacks[i].Push(crate);
        }
    }

    return stacks;
}

internal record Procedure(int Count, int Source, int Destination);
