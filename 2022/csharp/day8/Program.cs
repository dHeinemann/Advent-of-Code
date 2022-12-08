string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

int[,] trees = ParseInput(File.ReadAllText(filePath));
var visible = new HashSet<(int, int)>();

for (int col = 0; col < trees.GetLength(0); col++)
{
    int last = -1;
    for (int row = 0; row < trees.GetLength(1); row++)
    {
        if (trees[col, row] > last)
        {
            visible.Add((col, row));
            last = trees[col, row];
        }
    }
    
    last = -1;
    for (int row = trees.GetLength(1) - 1; row >= 0; row--)
    {
        if (trees[col, row] > last)
        {
            visible.Add((col, row));
            last = trees[col, row];
        }
    }
}

for (int row = 0; row < trees.GetLength(1); row++)
{
    int last = -1;
    for (int col = 0; col < trees.GetLength(0); col++)
    {
        if (trees[col, row] > last)
        {
            visible.Add((col, row));
            last = trees[col, row];
        }
    }
    
    last = -1;
    for (int col = trees.GetLength(0) - 1; col >= 0; col--)
    {
        if (trees[col, row] > last)
        {
            visible.Add((col, row));
            last = trees[col, row];
        }
    }
}

Console.WriteLine($"Part 1: {visible.Count}");

int[,] ParseInput(string input)
{
    int cols = input.IndexOf("\n");
    int rows = input.Split('\n').Length;

    int col = 0;
    int row = 0;

    int[,] trees = new int[cols, rows];
    foreach (char c in input)
    {
        if (c == '\n')
        {
            col = 0;
            row++;
        }
        else
        {
            trees[col++, row] = Convert.ToInt32(c.ToString());
        }
    }

    return trees;
}
