namespace FootballTables.models;

public class Match
{
    public DateTime Date { get; set; }
    public int RoundNumber { get; set; }

    public Team HomeTeam { get; set; } = null!;
    public Team AwayTeam { get; set; } = null!;

    public string Home { get; }
    public string Away { get; }
    public int HomeTeamGoals { get; }
    public int AwayTeamGoals { get; }

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
            HomeTeam.Matches.Add(MatchStatus.Won);
            AwayTeam.Matches.Add(MatchStatus.Lost);
        }
        else if (HomeTeamGoals < AwayTeamGoals)
        {
            AwayTeam.AddPoints(3);
            HomeTeam.Matches.Add(MatchStatus.Lost);
            AwayTeam.Matches.Add(MatchStatus.Won);
        }
        else
        {
            HomeTeam.AddPoints(1);
            AwayTeam.AddPoints(1);
            HomeTeam.Matches.Add(MatchStatus.Draw);
            AwayTeam.Matches.Add(MatchStatus.Draw);
        }
    }
    
    

    public override string ToString()
    {
        return $"{Home}, {Away}, {HomeTeamGoals}-{AwayTeamGoals}";
    }
}