namespace FootballTables.database;

public class FileHandler
{
    private static readonly string FolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    private string _filePath;
    
    
    public string FileName
    {
        set => _filePath = Path.Combine(FolderPath, "dataFiles", value);
    }
   
    public FileHandler(string fileName)
    {
        _filePath = Path.Combine(FolderPath, "dataFiles", fileName);
    }
    
    public List<string> ReadFile()
    {
        var lines = new List<string>();
        try
        {
            var reader = new StreamReader(_filePath);
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //reader.Close();
        }
        
        
        return lines;
    }

    public void WriteLineToFile(bool append, string line, string header)
    {
        
        if (!File.Exists(_filePath))
        {
            // Create a file to write to.
            using var writer = File.CreateText(_filePath);
            writer.WriteLine(header);
            writer.WriteLine(line);
        }
        else if (File.Exists(_filePath))
        {
            StreamWriter? writer;

            if (append)
            {
                writer = File.AppendText(_filePath);
                Console.WriteLine("Line got appended to the file");
            }
            else
            {
                writer = File.CreateText(_filePath);
                Console.WriteLine("File got overriden with line");
            }
            writer.WriteLine(line);
            writer.Close();
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
    }

    public void WriteLinesToFile(bool append, List<string> lines, string header)
    {
        if (!File.Exists(_filePath))
        {
            using var writer = File.CreateText(_filePath);
            writer.WriteLine(header);
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }
        else if (File.Exists(_filePath))
        {
            if (!append)
            {
                using var writer = File.CreateText(_filePath);
                writer.WriteLine(header);
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            else
            {
                using var writer = File.AppendText(_filePath);
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
                Console.WriteLine($"{lines.Count} lines got appended to the file");
            }
        }
    }

}