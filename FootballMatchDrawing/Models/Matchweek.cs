using FootballMatchDrawing.Models.Interfaces;

namespace FootballMatchDrawing.Classes;

class Matchweek : IFootballMatchweek
{

    public Matchweek(int number, IEnumerable<IFootballMatch> matches)
    {
        Number = number;
        Matches = matches.ToList();
    }
    public int Number { get; }

    public IReadOnlyList<IFootballMatch> Matches { get; }
}