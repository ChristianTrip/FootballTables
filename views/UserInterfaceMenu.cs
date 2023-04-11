using FootballTables.services;

namespace FootballTables.views;

public static class UserInterfaceMenu
{

    private static void PrintHeader()
    {
        Console.WriteLine("==============================================================================");
        Console.WriteLine("==| Football Tables Program                                                |==");
        Console.WriteLine("==|                                              Created by Christian Trip |==");
        Console.WriteLine("==|                                 Written in the C# programming language |==");
        Console.WriteLine("==============================================================================");
        Console.WriteLine("==| IMPORTANT ANNOUNCEMENT:                                                |==");
        Console.WriteLine("==| Due to lack of funds,                                                  |==");
        Console.WriteLine("==| there will only be 8 teams                                             |==");
        Console.WriteLine("==| instead of the usually 12                                              |==");
        Console.WriteLine("==| teams per league.                                                      |==");
        Console.WriteLine("==============================================================================");
        Console.WriteLine("==============================================================================");
        Console.WriteLine();
    }

    private static void PrintOptions()
    {
        Console.WriteLine("Main menu. Chose an option to preform:");
        Console.WriteLine();
        Console.WriteLine("1. Print out tables for randomly generated Superliga games");
        Console.WriteLine("2. Print out tables for randomly generated 1. division games");
        Console.WriteLine("3. Exit");
    }
    public static void StartMenu()
    {
        PrintHeader();

        var run = true;
        
        while (run)
        {
            PrintOptions();
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Superliga tables");
                    MatchService.PrintMatchesForLeague(0);
                    break;
                case "2":
                    Console.WriteLine("1. division tables");
                    MatchService.PrintMatchesForLeague(1);
                    break;
                case "3":
                    Console.WriteLine("Exit");
                    run = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Choose a number on the list of options\n\n");
                    break;
            }
        }
    }

}