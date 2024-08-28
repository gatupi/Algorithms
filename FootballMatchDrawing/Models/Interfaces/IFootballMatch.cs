namespace FootballMatchDrawing.Models.Interfaces;

interface IFootballMatch
{
    public Guid Id { get; }
    public ITeam HomeTeam { get; }
    public ITeam AwayTeam { get; }
}