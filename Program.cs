// See https://aka.ms/new-console-template for more information

using FootballTables.models;
using FootballTables.services;

var teamService = new TeamService();
var fck = new Team("FCK", "Fodboldklub København", "W", "Superligaen");

//teamService.Create(fck);

/*
 * __run dir__
 * read setup
 * read teams
 * print tabel
 * iterate (x=1)
 *  - read round x
 *  - print table
 * write final table to file
 * __the end__
 */


foreach (var team in teamService.GetAll())
{
    Console.WriteLine(team);
}
{
    
}





