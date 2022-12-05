string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string[] lines = File.ReadAllLines(filePath);

Stack<char>[]    stacks     = GetStacks(lines.Take(8));
Queue<Procedure> procedures = GetProcedures(lines.Skip(10));

while (procedures.Count > 0)
{
    Procedure proc = procedures.Dequeue();
    for (int i = 0; i < proc.Count; i++)
        stacks[proc.Destination - 1].Push(stacks[proc.Source - 1].Pop());
}

Console.WriteLine($"Part 1: {new string(stacks.Select(s => s.Peek()).ToArray())}");

static Queue<Procedure> GetProcedures(IEnumerable<string> procedureLines)
{
    var procedures = new Queue<Procedure>();
    foreach (string line in procedureLines)
        procedures.Enqueue(
            new Procedure(
                Convert.ToInt32(line[5..7].Trim()),
                Convert.ToInt32(line[12..14].Trim()),
                Convert.ToInt32(line[17..].Trim())
            )
        );

    return procedures;
}

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
