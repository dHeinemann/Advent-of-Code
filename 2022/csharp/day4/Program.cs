string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

int subsetCount  = 0;
int overlapCount = 0;
foreach (string pair in File.ReadAllLines(filePath))
{
    string[] elves = pair.Split(',');

    int[] elf1Sections = elves[0].Split('-').Select(s => Convert.ToInt32(s)).ToArray();
    int[] elf2Sections = elves[1].Split('-').Select(s => Convert.ToInt32(s)).ToArray();

    bool elf1IsSubsetOf2 = elf1Sections[0] >= elf2Sections[0] && elf1Sections[1] <= elf2Sections[1];
    bool elf2IsSubsetOf1 = elf2Sections[0] >= elf1Sections[0] && elf2Sections[1] <= elf1Sections[1];

    if (elf1IsSubsetOf2 || elf2IsSubsetOf1)
        subsetCount++;

    bool overlap = elf1Sections[0] >= elf2Sections[0] && elf1Sections[0] <= elf2Sections[1]
        || elf1Sections[1] >= elf2Sections[0] && elf1Sections[1] <= elf2Sections[1]
        || elf1IsSubsetOf2
        || elf2IsSubsetOf1;
    if (overlap)
        overlapCount++;
}

Console.WriteLine($"Part 1: {subsetCount}");
Console.WriteLine($"Part 2: {overlapCount}");
