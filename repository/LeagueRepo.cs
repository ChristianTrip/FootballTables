using FootballTables.models;
using FootballTables.database;

namespace FootballTables.repository;

public class LeagueRepo: ICrud<League, string>
{
    
    private const string FileName = "setup.csv";
    private readonly FileHandler _fileHandler = new FileHandler(FileName);


    public void Create(League model)
    {
        throw new NotImplementedException();
    }

    public League GetById(string id)
    {
        throw new NotImplementedException();
    }

    public List<League> GetAll()
    {
        var leagues = new List<League>();
        
        foreach (var element in _fileHandler.ReadFile())
        {
            var line = element.Split(", ");
            if (line.Length == 7)
            {
                var league = new League(
                    line[0],
                    line[1],
                    Convert.ToInt16(line[2]),
                    Convert.ToInt16(line[3]),
                    Convert.ToInt16(line[4]),
                    Convert.ToInt16(line[5]),
                    Convert.ToInt16(line[6]));
                
                leagues.Add(league);
            }
            else
            {
                Console.WriteLine("Could not retrieve league from csv-file, because file contains invalid data lines");
                leagues.Clear();
                break;
            }
        }
        return leagues;
    }
    
}