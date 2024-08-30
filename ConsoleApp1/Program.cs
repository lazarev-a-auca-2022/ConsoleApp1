// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        PrintFileTree(currentDirectory, "");
        
    }

    static void PrintFileTree(string directory, string indent)
    {
        foreach (var file in Directory.GetFiles(directory))
        {
            Console.WriteLine($"{indent}- {Path.GetFileName(file)}");
        }
        
        foreach (var dir in Directory.GetDirectories(directory))
        {
            Console.WriteLine($"{indent}+ {Path.GetFileName(dir)}");
            PrintFileTree(dir, indent + "  ");
        }
    }
}