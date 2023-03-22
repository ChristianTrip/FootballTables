# FootballTables

Football leagues in Denmark is organised in tiers. The first tier (SuperLigaen) use the same tournament style as the second tier (NordicBetLigaen), which mean that handling scores is done in a uniform manner.

 

Each tier is composed of 12 teams, that play internally between themselves in 22 rounds, after which the tier is split into an upper and lower fraction, each consisting of 6 teams. Each fraction then play internally between themselves in 10 additional rounds, after which the table is then finished.

 

Your job is to implement a football processor application, that based on a lot of comma-separated files inside a directory can process and print the necessary information on the console as well as into a result file in the same directory.

 

There could be any number of files available, depending on the current data, so the processor should process any number of files from one end to the other, and after processing each file it must present the current table standings of the league. The files are all csv files (Comma Separated Values), so they can be edited in a spreadsheet easily.

 

Files includes are:

setup.csv
teams.csv
round-1.csv
round-2.csv
…
round-32.cvs
 

The setup file contain a line on the league setup, such as

League name
Number of positions to promote to Champions league 
(usually 1 in Superligaen, 0 in NordicBetLigaen, they have promotions instead)
Number of subsequent positions to promote to Europe league
Number of subsequent positions to promote to Conference League
Number of positions to promote to an upper league 
(when the above is all zero, these ones are show, so 2 in NordicBetLigaen, 0 in Superligaen)
Number of final positions that are to be relegated into a lower league (usually 2)
 

The teams file contains information about the individual clubs, Each club specify, in this order:

Abbreviation
Full club name
Special ranking 
(W-last years champion, C-Last years cup winner, P-Promoted team, R-Relegated team)
 

 

After having loaded the setup and teams file, the current standings must be presented. Each club is represented with a formatted line showing the following information

Position in the table
Special marking in parentheses
Full club name
Games played
Number of games won
Number of games drawn
Number of games lost
Goals for
Goals against
Goal Difference
Points achieved
Current winning streak (up to 5 latest played games represented as W|D|L for win, draw, loss, or just a dash when no such streak is present)
 

The list is sorted such that order is:

By points
By goal difference
By goals for
By goals against
Alphabetically 
 

The position is calculated per team based on the same sorting, except that two clubs with the same points and goal figures must have the same position.

In case multiple teams have the same position, only the first team shows the position number, and the rest inherit this number by showing a dash instead.


The top lines should be individually coloured to show CL, EL, EC qualification or promotion qualification and the last lines should be individually coloured to show the relegation threat. Apart from that, easy colouring would be nice, such as green, amber, red in streaks, if possible, and/or anything to make it pleasing to the user (Strive to make it look the best to a user, always)

 

When processing the individual rounds, the file contains the following items

Home team abbreviated
Away team abbreviated
Score (x-y) where x is home team goals and y is away team goals
Other data may exist after that.
 

When processing each round, the rules should apply


In case of error, processing should stop and no further processing should be done, clearly stating where the processing stopped and what the problem was (With a human explanation, not some creepy algorithmic expression)
Only teams known from teams file should be processed (even though other results may be in there)
During the first 22 rounds, you can only play against the same team in one home and one away match. After 22 rounds, the same applies again, but this time for teams inside each fraction
In Denmark you are not allowed to play against yourself
If games had to be cancelled and postponed, they would reside in a file called round-x-a.csv, where the a represents an incremental additional number.
For the initial rounds, only a league table is shown. After the split, two tables of the upper and lower fraction must be presented separately
Any custom rules you deem necessary, which are then explained
Marking & Deliverables

 

The solution should prove the usage of the following things from C#:

Type system
Null handling
String interpolation
Pattern Matching
Classes, structs and enums
Properties
Named & optional parameters
Tupples, deconstruction
Exception
Attributes and DataValidation
Arrays / Collections
Ranges
Generics
 

Optionally use:

Operator overloads
Ref/in/out
Optional parameters
Indexers
Interfaces
Delegates
 

The solution must be checked into a git repository and exported as a .git file 

git bundle create xxx.git —all

Use your name(s) as the filename, to make it easier for me.

 

You can work in groups of up to 3 people, but each must make a valuable contribution, and be easily identified in each git commit.

 

The solution must contain two markdown documents

one outlining the solution, the usage, and the rule/error help information (README.md)
One document presenting examples of where the above C# constructs are being used (MARKME.md)
 

The solution must contain a directory called test containing test data. By test data I mean a set of directories each containing a scenario, to play out to ensure all rules are being tested. Make sure the directories are named according to test case.

 

 

You are free to find help with each other and resources available to you, including StackOverflow and Chatbots. However, if you do use these two options, you will have to

Add a file (LINKS.md) containing links to questions on StackOverflow you have used, one link per line.
Add a directory chat containing transcript file for each chat conversation you have (Don’t worry about formatting).
It makes no difference whether you use help often or not, so please be honest, allowing me to judge it unbiased.
