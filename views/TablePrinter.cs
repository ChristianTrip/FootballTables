using System.Text;
using FootballTables.models;

namespace FootballTables.views;

public class TablePrinter
{

    private static string _tableFormat = "| {0,-4}| {1,-20}| {2,-4}| {3,-3}| {4,-3}| {5,-3}| {6,-3}| {7,-3}| {8,-3}| {9,-4}| {10,-13}|";
    

    public static void PrintTable(List<Team> teams, int roundNumber)
    {
        var teamNameSpace = GetLongestTeamName(teams);
        
        _tableFormat = "| {0,-4}| {1,-" + teamNameSpace + "}| {2,-4}| {3,-3}| {4,-3}| {5,-3}| {6,-3}| {7,-3}| {8,-4}| {9,-4}| {10,-12}|";

        var position = 1; // only works with a list sorted by number of points beforehand
        Console.WriteLine("ROUND " + roundNumber + ":");
        PrintHeader();
        foreach (var team in teams)
        {
            var line = String.Format(_tableFormat, 
                position,
                team.NameWithRanking, 
                team.NumberOfGamesPlayed, 
                team.TimesWon, 
                team.TimesDraw, 
                team.TimesLost, 
                team.GoalsFor , 
                team.GoalsAgainst, 
                team.GoalsDifference, 
                team.Points, 
                team.WinningStreak);
            Console.WriteLine(line);
            position++;
        }
        
        var builder = new StringBuilder();
        
        Console.WriteLine("--------------------------------------------------------------------------------------");
        builder.Append("");
    }
    
    private static int GetLongestTeamName(List<Team> teams)
    {
        var longestTeamName = 20;
        
        foreach (var team in teams)
        {
            if (team.NameWithRanking.Length > longestTeamName)
            {
                longestTeamName = team.NameWithRanking.Length;
            }
        }

        return longestTeamName + 1;
    }

    private static void PrintHeader()
    {
        var header = String.Format(_tableFormat, "Pos", "Team", "Pld", "W", "D", "L", "GF", "GA", "GD", "Pts", "WS");
                Console.WriteLine(header);
    }
    
    private static void PrintRow()
    {

        
    }
}