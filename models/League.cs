namespace FootballTables.models;

public class League
{
    public string Name { get; }
    public string Year { get; }
    private List<Team> teams;
    public List<Team> TeamsSortedByPoints => GetTeamsSortedByPoints();

    private List<Match> matches = new List<Match>();

    public List<Match> Matches
    {
        get { return matches;}
        set { matches = value; }
    }

    public League(string name, string year)
    {
        Name = name;
        Year = year;
        teams = new List<Team>();
    }
    
    public League(string name, string year, int promoteToChampionsLeague, int promoteToEuropeLeague, int promoteToConferenceLeague, int PromoteToUpperLeague, int PromoteToLowerLeague)
    {
        Name = name;
        Year = year;
        teams = new List<Team>();
        Matches = new List<Match>();
    }

    private List<Team> GetTeamsSortedByPoints()
    {
        
        teams.Sort((x, y) => y.Points.CompareTo(x.Points));

        return teams;
    }
    
    public void AddTeam(Team team)
    {
        if (!teams.Contains(team))
        {
            teams.Add(team);
        }
        else
        {
            Console.WriteLine($"Team {team.Abbreviation} is already in {Name}");
        }
    }

    public void AddMatch(Match match)
    {
        match.League = this;
        match.AwayTeam = GetTeamByAbbreviation(match.Away);
        match.HomeTeam = GetTeamByAbbreviation(match.Home);

        if (match.AwayTeam != null && match.HomeTeam != null)
        {
            match.SettleMatch();
            Matches.Add(match);
        }
        
    }

    private Team GetTeamByAbbreviation(string abbreviation)
    {
        foreach (var team in teams)
        {
            if (team.Abbreviation.Equals(abbreviation))
            {
                return team;
            }
        }
        return null;
    }
   
}