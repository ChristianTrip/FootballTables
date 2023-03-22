namespace FootballTables.services;

public class FileHandler
{
    private string _fileLocation;
    private string _filePath;

    public FileHandler(string fileLocation, string fileName)
    {
        _fileLocation = fileLocation;
        _filePath = fileLocation + fileName;
    }

    public FileHandler(string fileName) : this("/Users/christiantrip/RiderProjects/FootballTables/FootballTables/dataFiles/", fileName)
    {
    }
    
    
    public List<string> ReadFile()
    {
        var lines = new List<string>();
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(_filePath);
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
            reader.Close();
        }
        
        
        return lines;
    }

    public void WriteLineToFile(bool append, string line)
    {
        
        if (File.Exists(_filePath))
        {
            StreamWriter writer = null;

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

    public void WriteLinesToFile(bool append, List<string> lines)
    {
        if (File.Exists(_filePath))
        {
            StreamWriter writer = null;
            if (append)
            {
                writer = File.AppendText(_filePath);
                Console.WriteLine($"{lines.Count} lines got appended to the file");
            }
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
    }

    public void DeleteLineById(string id)
    {
        var lines = ReadFile();
        foreach (var line in lines)
        {
            if (line.Contains(id))
            {
                lines.Remove(line);
                break;
            }
        }
        WriteLinesToFile(false, lines);   
    }
}