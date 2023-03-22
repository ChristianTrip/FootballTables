namespace FootballTables.models;

public class Team
{
   public string Name { get; }
   public string Abbreviation { get; }
   public string SpecialRanking { get; }
   
   public string League { get; }
   
   public Team(string abbreviation, string name, string specialRanking, string league)
   {
      Abbreviation = abbreviation.ToUpper();
      Name = name;
      SpecialRanking = specialRanking.ToUpper();
      League = league;
   }

   public override string ToString() => $"abbreviation: {Abbreviation}, name: {Name}, ranking: {SpecialRanking}".Trim();
   
}