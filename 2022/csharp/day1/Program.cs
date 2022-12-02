string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var dict = new Dictionary<int, int>();

int currentElf = 1;
foreach (string calories in File.ReadAllLines(filePath))
{
    if (!string.IsNullOrEmpty(calories))
    {
        if (!dict.ContainsKey(currentElf))
            dict[currentElf] = 0;

        dict[currentElf] += Convert.ToInt32(calories);
    }
    else
    {
        currentElf++;
    }
}

int topCalories = dict.Values.Max();
int totalTop3Calories = dict.Values.OrderByDescending(v => v).Take(3).Sum();

Console.WriteLine($"Elf with most calories has {topCalories} calories.");
Console.WriteLine($"Top three elves with most calories have {totalTop3Calories} calories.");