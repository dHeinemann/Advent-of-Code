string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
DirectoryFso root = ParseInput(File.ReadAllLines(filePath));

List<DirectoryFso> allDirectories = Flatten(root);
Console.WriteLine($"Part 1: {allDirectories.Select(d => d.Size).Where(s => s <= 100000).Sum()}");

const int diskSize      = 70000000;
const int requiredSpace = 30000000;

int currentSpace = diskSize - root.Size;

foreach (DirectoryFso dir in allDirectories.OrderBy(d => d.Size))
{
    if (currentSpace + dir.Size >= requiredSpace)
    {
        Console.WriteLine($"Part 2: {dir.Size}");
        break;
    }
}

List<DirectoryFso> Flatten(DirectoryFso dir)
{
    var directories = new List<DirectoryFso>();
    foreach (DirectoryFso child in dir.Children.OfType<DirectoryFso>())
    {
        directories.Add(child);
        directories.AddRange(Flatten(child));
    }

    return directories;
}

DirectoryFso ParseInput(string[] input)
{
    var currentDirectory = new DirectoryFso("/");
    foreach (string line in input)
    {
        if (line.StartsWith("$ cd "))
        {
            string dirName = line[5..];
            if (dirName == "/")
                continue;

            if (dirName == "..")
            {
                currentDirectory = (DirectoryFso)currentDirectory.Parent!;
            }
            else
            {
                if (!currentDirectory.Contains(dirName))
                    currentDirectory.AddDirectory(dirName);

                currentDirectory = (DirectoryFso)currentDirectory[dirName];
            }
        }
        else if (line.StartsWith("dir "))
        {
            string dirName = line[4..];
            if (!currentDirectory.Contains(dirName))
                currentDirectory.AddDirectory(dirName);
        }
        else
        {
            if (line == "$ ls")
                continue;
            
            string[] fileParts = line.Split(" ");
            currentDirectory.AddFile(fileParts[1], Convert.ToInt32(fileParts[0]));
        }
    }

    while (currentDirectory.Parent != null)
        currentDirectory = (DirectoryFso)currentDirectory.Parent!;

    return currentDirectory;
}

public enum FsoType
{
    File,
    Directory
}

public interface IFso
{
    IFso? Parent { get; }
    
    string Name { get; }
    
    int Size { get; }
    
    FsoType FsoType { get; }
}

public class FileFso : IFso
{
    public IFso? Parent { get; init; }
    
    public string Name { get; }
    public int Size { get; }

    public FsoType FsoType => FsoType.File;

    public FileFso(string name, int size)
    {
        Name = name;
        Size = size;
    }
}

public class DirectoryFso : IFso
{
    private readonly Dictionary<string, IFso> _children = new();
    
    public IFso? Parent { get; private init; }
    
    public string Name { get; }

    public int Size => _children.Values.Sum(c => c.Size);


    public FsoType FsoType => FsoType.Directory;

    public List<IFso> Children => _children.Values.ToList();

    public DirectoryFso(string name) => Name = name;

    public IFso this[string name] => _children[name];

    public bool Contains(string name) => _children.ContainsKey(name);

    public void AddFile(string name, int size)
    {
        var f = new FileFso(name, size)
        {
            Parent = this
        };
        _children[name] = f;
    }

    public void AddDirectory(string name)
    {
        var d = new DirectoryFso(name)
        {
            Parent = this
        };
        _children[name] = d;
    }
}