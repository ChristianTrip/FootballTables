namespace FootballTables.models;

public class Match
{
    public DateTime Date { get; set; }
    public int RoundNumber { get; set; }

    public League League { get; set; }
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    
    public string Home { get; }
    public string Away { get; }
    public int HomeTeamGoals { get; }
    public int AwayTeamGoals { get; }

    public Match(Team homeTeam, Team awayTeam, int homeTeamGoals, int awayTeamGoals)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeTeamGoals = homeTeamGoals;
        AwayTeamGoals = awayTeamGoals;
    }
    
    public Match(string home, string away, int homeTeamGoals, int awayTeamGoals)
    {
        Home = home;
        Away = away;
        HomeTeamGoals = homeTeamGoals;
        AwayTeamGoals = awayTeamGoals;
    }

    public void SettleMatch()
    {
        
        GivePoints();
        GiveGoals();
    }

    private void GiveGoals()
    {
        HomeTeam.GoalsFor += HomeTeamGoals;
        HomeTeam.GoalsAgainst += AwayTeamGoals;
        AwayTeam.GoalsFor += AwayTeamGoals;
        AwayTeam.GoalsAgainst += HomeTeamGoals;
    }
    
    private void GivePoints() // setScore / updateScore
    {
        if (HomeTeamGoals > AwayTeamGoals)
        {
            HomeTeam.AddPoints(3);
            HomeTeam.Matches.Add(MatchStatus.WON);
            AwayTeam.Matches.Add(MatchStatus.LOST);
        }
        else if (HomeTeamGoals < AwayTeamGoals)
        {
            AwayTeam.AddPoints(3);
            HomeTeam.Matches.Add(MatchStatus.LOST);
            AwayTeam.Matches.Add(MatchStatus.WON);
        }
        else
        {
            HomeTeam.AddPoints(1);
            AwayTeam.AddPoints(1);
            HomeTeam.Matches.Add(MatchStatus.DRAW);
            AwayTeam.Matches.Add(MatchStatus.DRAW);
        }
    }
    
    

    public override string ToString()
    {
        return $"{Home}, {Away}, {HomeTeamGoals}-{AwayTeamGoals}";
    }
}