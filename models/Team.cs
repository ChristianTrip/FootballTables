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
   public int Points { get; set; }
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
                  case MatchStatus.WON:
                     sb.Append('W');
                     break;
                  case MatchStatus.LOST:
                     sb.Append('L');
                     break;
                  case MatchStatus.DRAW:
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
   public int TimesWon => GetNumberOfTimesMatchStatus(MatchStatus.WON);

   public int TimesLost => GetNumberOfTimesMatchStatus(MatchStatus.LOST);

   public int TimesDraw => GetNumberOfTimesMatchStatus(MatchStatus.DRAW);

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
      if (points >= 0 && points <= 3)
      {
         Points += points;
      }
   }

   public void AddMatchAndSetStatus(Match match)
   {
      var homeGoals = match.HomeTeamGoals;
      var awayGoals = match.AwayTeamGoals;
      var matchStatus = MatchStatus.DRAW;
      
      if (match.Home.Equals(this.Abbreviation))
      {
         this.GoalsFor += homeGoals;
         
         if (homeGoals > awayGoals)
         {
            matchStatus = MatchStatus.WON;
         }
         else if (homeGoals < awayGoals)
         {
            matchStatus = MatchStatus.LOST;
         }
      }
      if (match.Away.Equals(this.Abbreviation))
      {
         this.GoalsFor += awayGoals;
         
         if (homeGoals > awayGoals)
         {
            matchStatus = MatchStatus.LOST;
         }
         else if (homeGoals < awayGoals)
         {
            matchStatus = MatchStatus.WON;
         }
      }
      
      GivePointsBasedOnMatchStatus(matchStatus);
   }

   private void GivePointsBasedOnMatchStatus(MatchStatus matchStatus)
   {
      switch (matchStatus)
      {
         case MatchStatus.WON:
            this.Points += 3;
            break;
         case MatchStatus.LOST:
            this.Points += 0;
            break;
         case MatchStatus.DRAW:
            this.Points += 1;
            break;
         default:
            Console.WriteLine("Game could not be settled");
            break;
      }
   }


   public override string ToString() => $"abbreviation: {Abbreviation}, name: {Name}, ranking: {SpecialRanking}".Trim();
   
}