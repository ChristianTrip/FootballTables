using FootballTables.models;
using FootballTables.database;

namespace FootballTables.repository;

public class MatchRepo: ICrud<Match, int>
{
    private const string FileName = "round1.csv";
    private readonly FileHandler _fileHandler = new(FileName);
    

    public List<Match> GetMatchesByRoundNumber(int round)
    {
        _fileHandler.FileName = "round" + round + ".csv";
        return GetAll();
    }

    public void AddMatchToRound(int roundNumber, string match)
    {
        var header = "hometeam, awayteam, score/result";
        _fileHandler.FileName = "round" + roundNumber + ".csv";
        _fileHandler.WriteLineToFile(true, match, header);
    }
    
    public void CreateRound(int roundNumber, List<String> matchesAsStrings)
    {
        var header = "hometeam, awayteam, score/result";
        
        _fileHandler.FileName = "round" + roundNumber + ".csv";
        _fileHandler.WriteLinesToFile(false, matchesAsStrings, header);
    }
    
    public void Create(Match model)
    {
        
    }

    public Match GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, List<Match>> GetAllRounds()
    {
        return null;
    }

    public List<Match> GetAll()
    {
        
        var matches = new List<Match>();

        foreach (var element in _fileHandler.ReadFile())
        {
            var line = element.Split(", ");
            if (line.Length == 3)
            {
                var homeTeam = line[0];
                var awayTeam = line[1];
                var homeTeamGoals = Convert.ToInt16(line[2].Substring(0,1));
                var awayTeamGoals = Convert.ToInt16(line[2].Substring(2));
                matches.Add(new Match(homeTeam, awayTeam, homeTeamGoals, awayTeamGoals));
            }
            else
            {
                Console.WriteLine("Could not retrieve matches from csv-file, because file contains invalid data lines");
                matches.Clear();
                break;
            }
        }
        return matches;
        
    }

    public void Update(Match model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}