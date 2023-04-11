using System.Text;

namespace FootballTables.models;

public class Team
{
   public string Name { get; }
   public string Abbreviation { get; }
   public string SpecialRanking { get; }

   public string NameWithRanking
   {
      get
      {
         if (SpecialRanking.Equals("-") || SpecialRanking.Equals(" ") || SpecialRanking.Equals(""))
         {
            return Name;
         }
         else
         {
            return Name + " (" + SpecialRanking + ")";
         }
      }
   }
   public int Points { get; private set; }
   public int GoalsFor { get; set; }
   public int GoalsAgainst { get; set; }
   public int GoalsDifference => GoalsFor - GoalsAgainst;


   public string League { get; }
   
   public List<MatchStatus> Matches { get; }

   public string WinningStreak
   {
      get
      {
         var sb = new StringBuilder();
         var count = 1;
         for (var i = Matches.Count - 1; i > 0; i--)
         {

            if (count <= 6)
            {
               switch (Matches[i])
               {
                  case MatchStatus.Won:
                     sb.Append('W');
                     break;
                  case MatchStatus.Lost:
                     sb.Append('L');
                     break;
                  case MatchStatus.Draw:
                     sb.Append('D');
                     break;
                  default:
                     Console.WriteLine("Error");
                     break;
               }
               sb.Append(' ');
               count++;
            }
            else
            {
               break;
            }
         }
         return sb.ToString();
      }
   }

   public int NumberOfGamesPlayed => Matches.Count;
   public int TimesWon => GetNumberOfTimesMatchStatus(MatchStatus.Won);

   public int TimesLost => GetNumberOfTimesMatchStatus(MatchStatus.Lost);

   public int TimesDraw => GetNumberOfTimesMatchStatus(MatchStatus.Draw);

   public Team(string abbreviation, string name, string specialRanking, string league)
   {
      Abbreviation = abbreviation.ToUpper();
      Name = name;
      SpecialRanking = specialRanking.ToUpper();
      League = league;
      Matches = new List<MatchStatus>();
      Points = 0;
   }

   private int GetNumberOfTimesMatchStatus(MatchStatus status)
   {
      var count = 0;
      foreach (var match in Matches)
      {
         if (match.Equals(status))
         {
            count++;
         }
      }
      return count;
   }
   
   public void AddPoints(int points)
   {
      if (points is >= 0 and <= 3)
      {
         Points += points;
      }
   }

   public void AddMatchAndSetStatus(Match match)
   {
      var homeGoals = match.HomeTeamGoals;
      var awayGoals = match.AwayTeamGoals;
      var matchStatus = MatchStatus.Draw;
      
      if (match.Home.Equals(this.Abbreviation))
      {
         this.GoalsFor += homeGoals;
         
         if (homeGoals > awayGoals)
         {
            matchStatus = MatchStatus.Won;
         }
         else if (homeGoals < awayGoals)
         {
            matchStatus = MatchStatus.Lost;
         }
      }
      if (match.Away.Equals(this.Abbreviation))
      {
         this.GoalsFor += awayGoals;
         
         if (homeGoals > awayGoals)
         {
            matchStatus = MatchStatus.Lost;
         }
         else if (homeGoals < awayGoals)
         {
            matchStatus = MatchStatus.Won;
         }
      }
      
      GivePointsBasedOnMatchStatus(matchStatus);
   }

   private void GivePointsBasedOnMatchStatus(MatchStatus matchStatus)
   {
      switch (matchStatus)
      {
         case MatchStatus.Won:
            this.Points += 3;
            break;
         case MatchStatus.Lost:
            this.Points += 0;
            break;
         case MatchStatus.Draw:
            this.Points += 1;
            break;
         default:
            Console.WriteLine("Game could not be settled");
            break;
      }
   }


   public override string ToString() => $"abbreviation: {Abbreviation}, name: {Name}, ranking: {SpecialRanking}".Trim();
   
}