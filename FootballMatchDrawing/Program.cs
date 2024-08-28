// See https://aka.ms/new-console-template for more information
using FootballMatchDrawing;
using System.Runtime.Intrinsics;

Console.WriteLine("Hello, World!");
var teams = Team.CreateTeams(Team.TEAM_NAMES);
var copy = new Team[4];
Array.Copy(teams.ToArray(), copy, copy.Length);
var randomizer = new MatchRandomizer(copy);

//var matchList = randomizer.Matches.ToList();
//matchList.Shuffle();
//Console.WriteLine(matchList.Stringify());
//foreach(var team in randomizer.Teams) {
//    var matches = randomizer.GetMatchesByTeam(team.Id);
//    var homeMatches = matches.Where(match => match.HomeTeam.Id == team.Id).Count();
//    var awayMatches = matches.Where(match => match.AwayTeam.Id == team.Id).Count();
//    Console.WriteLine($"{team.Name.PadRight(32)} Home {homeMatches} Away {awayMatches} Total {matches.Count()}");
//}

//Console.WriteLine();
//randomizer.Randomize();
//Console.WriteLine(randomizer.Rounds.Count());

//foreach(var round in randomizer.Rounds) {
//    Console.WriteLine($"Rodada {round.Number}");
//    Console.WriteLine(round.Matches.Stringify());
//    Console.WriteLine();
//}


//Console.WriteLine(Utils.FillArray(20).ToArrayString());
//Console.WriteLine(Utils.FillArray(10, 0, -3).ToArrayString());
//Console.WriteLine(Utils.FillArray(6, 12, 7).ToArrayString());

var permutation = new PairListPermutation(20);
Console.WriteLine();
var matrix = permutation.Permutate(true);
Console.WriteLine(matrix.ToMatrixString());
var hash = new HashSet<(int, int)>();
for (int i = 0; i < matrix.GetLength(0); i++) {
    for (int j = 0; j < matrix.GetLength(1); j++) {
        var (v1, v2) = matrix[i, j];
        if (!hash.Add((v1, v2)) || !hash.Add((v2, v1))) {
            throw new Exception("Contém pares repetidos");
        }
    }
}
Console.WriteLine("Gerado sem repetições");

randomizer.Randomize(true);
foreach (var round in randomizer.Rounds) {
    Console.WriteLine($"Rodada {round.Number}");
    Console.WriteLine(round.Matches.Stringify());
    Console.WriteLine();
}


