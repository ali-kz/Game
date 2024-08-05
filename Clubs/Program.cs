using Clubs;
using Games;
using Users;
using static Utils.Util;
using static System.Console;

var numFinder = new FindNumber("Find the Number", "the player must guess the number!", 7);
var hackPassword = new HackPassword("Hack the Password", "the player must hack FBI!", 30);

var club1 = new PlayerClub();
club1.AddGame(numFinder);
club1.AddGame(hackPassword);

var club2 = new PlayerClub([numFinder, hackPassword]);

club1.Open();