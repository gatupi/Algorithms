namespace FootballMatchDrawing;

class Round {

    public Round(int number, IEnumerable<Match> matches) {
        Number = number;
        Matches = matches.ToList();
    }
    public int Number { get; }
    public IReadOnlyList<Match> Matches { get; }
}