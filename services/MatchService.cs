
using FootballTables.models;
using FootballTables.repository;
using FootballTables.setup;
using FootballTables.views;

namespace FootballTables.services;

public static class MatchService
{

    private static readonly MatchRepo MatchRepo = new();

    public static void PrintMatchesForLeague(int leagueIndex)
    {
        var league = SetupData.Leagues[leagueIndex];
        
        var round = 1;
        while (MatchRepo.GetMatchesByRoundNumber(round).Count != 0)
        {
            foreach (var match in MatchRepo.GetMatchesByRoundNumber(round))
            {
                league.AddMatch(match);
            }
            TablePrinter.PrintTable(league.TeamsSortedByPoints, round);
            round++;
        }
    }

    public static void SetupRounds(List<League> leagues)
    {
        var matches = new List<Match>();
        foreach (var league in leagues)
        {
            matches.AddRange(GetAllPossibleMatches(league.TeamsSortedByPoints));
        }
        var round = new List<string>();

        var roundNumber = 1;

        while (matches.Count > 0 && roundNumber < 50)
        {
            for (var index = 0; index < matches.Count; index++)
            {
                var match = matches[index];

                if (round.Count == 0)
                {
                    round.Add(match.ToString());
                    matches.Remove(match);
                    index--;
                    continue;
                }
                
                var homePlays = false;
                var awayPlays = false;
                foreach (var roundMatch in round)
                {
                    if (roundMatch.Contains(match.Home))
                    {
                        homePlays = true;
                        break;
                    }
                    if (roundMatch.Contains(match.Away))
                    {
                        awayPlays = true;
                        break;
                    }
                }
                if (!homePlays && !awayPlays)
                {
                    round.Add(match.ToString());
                    matches.Remove(match);
                    index--;
                }

            }
            
            CreateRound(roundNumber, round);
            round.Clear();
            roundNumber++;
        }
    }
    
    private static List<Match> GetAllPossibleMatches(List<Team> teams)
    {
        var matches = new List<Match>();
        for (var i = 0; i < teams.Count; i++)
        {
            var home = teams[i].Abbreviation;
            for (var j = 0; j < teams.Count; j++)
            {
                if (j == i)
                {
                    continue;
                }
                var away = teams[j].Abbreviation;
                var homeGoals = new Random().Next(0, 5);
                var awayGoals = new Random().Next(0, 5);
                var match = new Match(home, away, homeGoals, awayGoals);
                matches.Add(match);
            }
        }
        return matches;
    }
    
    private static void CreateRound(int round, List<string> roundMatches)
    {
        MatchRepo.CreateRound(round, roundMatches);
    }
}