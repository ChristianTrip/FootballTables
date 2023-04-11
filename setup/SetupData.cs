using FootballTables.models;
using FootballTables.repository;
using FootballTables.services;

namespace FootballTables.setup;

public static class SetupData
{
    private static readonly LeagueRepo LeagueRepo = new();
    private static readonly TeamRepo TeamRepo = new();
    public static List<League> Leagues { get; } = new();

    public static void Start()
    {
        SetupTeamsAndLeagues();
        SetupRoundsForLeagues();
    }
    
    private static void SetupTeamsAndLeagues()
    {
        foreach (var league in LeagueRepo.GetAll())
        {
            foreach (var team in TeamRepo.GetAll())
            {
                if (league.Name.Equals(team.League))
                {
                    league.AddTeam(team);
                }
            }
            Leagues.Add(league);
        }
    }

    private static void SetupRoundsForLeagues()
    {
        MatchService.SetupRounds(Leagues);
    }
    
    
}