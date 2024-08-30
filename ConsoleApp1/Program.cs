
class Program
{
    private const int MaxFiles = 3;
    private static int fileCount = 0;

    static void Main(string[] args)
    {
        try
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            PrintFileTree(currentDirectory, "");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(1); // Force exit
        }
    }

    static void PrintFileTree(string directory, string indent)
    {
        foreach (var file in Directory.GetFiles(directory))
        {
            if (fileCount >= MaxFiles)
            {
                throw new Exception("File limit exceeded. Please try again.");
            }
            Console.WriteLine($"{indent}- {Path.GetFileName(file)}");
            fileCount++;
        }

        foreach (var dir in Directory.GetDirectories(directory))
        {
            if (fileCount >= MaxFiles)
            {
                throw new Exception("File limit exceeded. Please try again.");
            }
            Console.WriteLine($"{indent}+ {Path.GetFileName(dir)}");
            fileCount++;
            PrintFileTree(dir, indent + "  ");
        }
    }
}