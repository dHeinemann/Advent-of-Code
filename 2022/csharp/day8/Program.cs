string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

int[,] trees = ParseInput(File.ReadAllText(filePath));

Console.WriteLine($"Part 1: {CalculatePart1()}");
Console.WriteLine($"Part 2: {CalculatePart2()}");

int CalculatePart1()
{
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

    return visible.Count;
}

int CalculatePart2()
{
    int topScore = 0;
    for (int col = 0; col < trees.GetLength(0); col++)
    {
        for (int row = 0; row < trees.GetLength(1); row++)
        {
            int score = CalculateScore(col, row);
            if (score > topScore)
                topScore = score;
        }
    }

    return topScore;
}

int CalculateScore(int x, int y)
{
    int[] distances = new int[4];
    for (int col = x+1; col < trees.GetLength(0); col++)
    {
        if (trees[col, y] >= trees[x, y] || col == trees.GetLength(0) - 1)
        {
            distances[0] = col - x;
            break;
        }
    }
    
    for (int col = x-1; col >= 0; col--)
    {
        if (trees[col, y] >= trees[x, y] || col == 0)
        {
            distances[1] = x - col;
            break;
        }
    }
    
    for (int row = y+1; row < trees.GetLength(1); row++)
    {
        if (trees[x, row] >= trees[x, y] || row == trees.GetLength(1) - 1)
        {
            distances[2] = row - y;
            break;
        }
    }
    
    for (int row = y-1; row >= 0; row--)
    {
        if (trees[x, row] >= trees[x, y] || row == 0)
        {
            distances[3] = y - row;
            break;
        }
    }

    return distances.Aggregate(1, (a, b) => a * b);
}

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
