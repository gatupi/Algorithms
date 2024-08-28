namespace FootballMatchDrawing.Classes;

class MatchRandomizer
{

    private readonly List<Matchweek> _rounds = [];

    public MatchRandomizer(IEnumerable<Team> teams)
    {
        //if (teams.Count() % 2 != 0) {
        //    throw new Exception("Number of teams must be even");
        //}
        Teams = teams.ToList();
    }

    public IReadOnlyList<Team> Teams { get; }
    public IReadOnlyList<Matchweek> Rounds => _rounds;

    public void Randomize(bool shuffle = false)
    {
        int totalTeams = Teams.Count;
        var matrix = new PairListPermutation(totalTeams).Permutate(shuffle);
        int count = 0;
        List<Match> matches = [];
        foreach (var pair in matrix)
        {
            int roundNumber = count / (totalTeams / 2) + 1;
            var (i, j) = pair;
            if (i < 0 || j < 0) continue;
            var teamA = Teams[i];
            var teamB = Teams[j];
            if (roundNumber % 2 == 1)
            {
                matches.Add(new Match(teamA, teamB));
            }
            else
            {
                matches.Add(new Match(teamB, teamA));
            }
            if (++count % (totalTeams / 2) == 0)
            {
                _rounds.Add(new Matchweek(roundNumber, matches));
                matches = [];
            }
        }
    }
}
