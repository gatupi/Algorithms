using FootballMatchDrawing.Models.Interfaces;

namespace FootballMatchDrawing.Classes;

class Match : IFootballMatch
{
    public Match(ITeam homeTeam, ITeam awayTeam)
    {
        Id = Guid.NewGuid();
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
    }

    public Guid Id { get; }
    public ITeam HomeTeam { get; }
    public ITeam AwayTeam { get; }

    public bool HasTeam(Guid teamId) => HomeTeam.Id == teamId || AwayTeam.Id == teamId;
}