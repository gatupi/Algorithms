namespace FootballMatchDrawing.Models.Interfaces;

interface IFootballMatchweek
{
    public int Number { get; }
    public IReadOnlyList<IFootballMatch> Matches { get; }
}