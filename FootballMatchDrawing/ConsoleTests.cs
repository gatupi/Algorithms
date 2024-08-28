using FootballMatchDrawing.Classes;

namespace FootballMatchDrawing;

static class ConsoleTests
{
    public static void ShowIndexPairMatrix(bool randomize = false)
    {
        var permutation = new PairListPermutation(20);
        var matrix = permutation.Permutate(randomize);
        Console.WriteLine(matrix.ToMatrixString());
    }

    public static void CheckDuplicatedPair((int, int)[,] matrix)
    {
        try
        {
            var hash = new HashSet<(int, int)>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var (v1, v2) = matrix[i, j];
                    if (!hash.Add((v1, v2)) || !hash.Add((v2, v1)))
                    {
                        throw new Exception("Contém pares repetidos");
                    }
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        Console.WriteLine("Gerado sem repetições");
    }

    public static void GenerateFootballMatchweeks(int totalTeams = 6)
    {
        var teams = Team.CreateTeams(Team.TEAM_NAMES);
        var copy = new Team[totalTeams];
        Array.Copy(teams.ToArray(), copy, copy.Length);
        var randomizer = new MatchRandomizer(copy);
        randomizer.Randomize(true);
        foreach (var round in randomizer.Rounds)
        {
            Console.WriteLine($"Rodada {round.Number}");
            Console.WriteLine(round.Matches.Stringify());
            Console.WriteLine();
        }
    }
}