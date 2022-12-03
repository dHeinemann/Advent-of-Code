var part1Items = new List<char>();
var part2Items = new List<char>();

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string[] rucksacks = File.ReadAllLines(filePath);
for (int groupNo = 1; groupNo <= rucksacks.Length / 3; groupNo++)
{
    int groupStartIndex = (groupNo * 3) - 3;
    
    string rucksack1 = rucksacks[groupStartIndex];
    string rucksack2 = rucksacks[groupStartIndex + 1];
    string rucksack3 = rucksacks[groupStartIndex + 2];

    // Part 1
    foreach (string rucksack in new[] { rucksack1, rucksack2, rucksack3 })
    {
        var compartment1 = new HashSet<char>(rucksack[..(rucksack.Length / 2)]);
        var compartment2 = new HashSet<char>(rucksack[(rucksack.Length / 2)..]);
        
        compartment1.IntersectWith(compartment2);
        part1Items.Add(compartment1.First());
    }

    // Part 2
    var itemsInCommon = new HashSet<char>(rucksack1);
    itemsInCommon.IntersectWith(new HashSet<char>(rucksack2));
    itemsInCommon.IntersectWith(new HashSet<char>(rucksack3));
    part2Items.Add(itemsInCommon.First());
}

Console.WriteLine($"Part 1: {part1Items.Sum(GetPriority)}");
Console.WriteLine($"Part 2: {part2Items.Sum(GetPriority)}");

int GetPriority(char c)
{
    return c >= 'a'
        ? c - 96
        : c - 38;
}