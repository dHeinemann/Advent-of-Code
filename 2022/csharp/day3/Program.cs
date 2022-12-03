string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var items = new List<char>();
foreach (string rucksack in File.ReadAllLines(filePath))
{
    string compartment1 = rucksack[..(rucksack.Length / 2)];
    string compartment2 = rucksack[(rucksack.Length / 2)..];

    var rucksackItems = new HashSet<char>();
    foreach (char item in compartment1)
        rucksackItems.Add(item);

    foreach (char item in compartment2)
    {
        if (rucksackItems.Contains(item))
        {
            items.Add(item);
            break;
        }
    }
}

int sum = items.Sum(GetPriority);

Console.WriteLine($"The sum of priorities of items appearing in both compartments is {sum}.");

int GetPriority(char c)
{
    return c >= 'a'
        ? c - 96
        : c - 38;
}