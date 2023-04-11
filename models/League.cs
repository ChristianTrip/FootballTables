namespace FootballTables.models;

public class League
{
    public string Name { get; }
    private string Year { get; }
    private int PromoteToChampionsLeague { get; }
    private int PromoteToEuropeLeague { get; }
    private int PromoteToConferenceLeague { get; }
    private int PromoteToUpperLeague { get; }
    private int PromoteToLowerLeague { get; }
    private readonly List<Team> _teams;
    public List<Team> TeamsSortedByPoints => GetTeamsSortedByPoints();

    private List<Match> Matches { get; init; } = new();
    
    
    public League(string name, string year, int promoteToChampionsLeague, int promoteToEuropeLeague, int promoteToConferenceLeague, int promoteToUpperLeague, int promoteToLowerLeague)
    {
        Name = name;
        Year = year;
        PromoteToChampionsLeague = promoteToChampionsLeague;
        PromoteToEuropeLeague = promoteToEuropeLeague;
        PromoteToConferenceLeague = promoteToConferenceLeague;
        this.PromoteToUpperLeague = promoteToUpperLeague;
        this.PromoteToLowerLeague = promoteToLowerLeague;
        _teams = new List<Team>();
    }

    private List<Team> GetTeamsSortedByPoints()
    {
        
        _teams.Sort((x, y) => y.Points.CompareTo(x.Points));

        return _teams;
    }
    
    public void AddTeam(Team team)
    {
        if (!_teams.Contains(team))
        {
            _teams.Add(team);
        }
        else
        {
            Console.WriteLine($"Team {team.Abbreviation} is already in {Name}");
        }
    }

    public void AddMatch(Match match)
    {
        match.AwayTeam = GetTeamByAbbreviation(match.Away);
        match.HomeTeam = GetTeamByAbbreviation(match.Home);

        if (match is not { AwayTeam: { }, HomeTeam: { } }) return;
        match.SettleMatch();
        Matches.Add(match);
    }

    private Team GetTeamByAbbreviation(string abbreviation)
    {
        foreach (var team in _teams)
        {
            if (team.Abbreviation.Equals(abbreviation))
            {
                return team;
            }
        }
        return null!;
    }
   
}