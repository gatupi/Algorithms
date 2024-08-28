namespace FootballMatchDrawing;

class Match {
    public Match(Team homeTeam, Team awayTeam) {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
    }

    public Team HomeTeam { get; }
    public Team AwayTeam { get; }

    public bool HasTeam(Guid teamId) => HomeTeam.Id == teamId || AwayTeam.Id == teamId;
}