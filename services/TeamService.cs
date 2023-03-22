using FootballTables.models;

namespace FootballTables.services;

public class TeamService: ICrud<Team, string>
{
    private const string FileName = "teams.csv";
    private readonly FileHandler _fileHandler = new FileHandler(FileName);
    
    
    public void Create(Team model)
    {
        var teamAsString = $"{model.Abbreviation}, {model.Name}, {model.SpecialRanking}";
        _fileHandler.WriteLineToFile(true, teamAsString);
    }

    public Team GetById(string abbreviation)
    {
        Team team = null;

        foreach (var element in _fileHandler.ReadFile())
        {
            var line = element.Split(", ");
            
            if (line[0].Equals(abbreviation.ToUpper()) && line.Length == 4)
            {
                var name = line[1];
                var specialRanking = line[2];
                var league = line[3];
                team = new Team(abbreviation, name, specialRanking, league);
            }
        }
        return team;
    }

    public List<Team> GetAll()
    {
        var teams = new List<Team>();

        foreach (var element in _fileHandler.ReadFile())
        {
            var line = element.Split(", ");
            if (line.Length == 4)
            {
                var abbreviation = line[0];
                var name = line[1];
                var specialRanking = line[2];var league = line[3];
                teams.Add(new Team(abbreviation, name, specialRanking, league));
            }
            else
            {
                Console.WriteLine("Could not retrieve teams from csv-file, because file contains invalid data lines");
                teams.Clear();
                break;
            }
        }
        return teams;
    }

    public void Update(Team model)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }
}