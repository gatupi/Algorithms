namespace FootballMatchDrawing {
    class Team {

        public static readonly string[] TEAM_NAMES = [
            "Flamengo",
            "Palmeiras",
            "São Paulo",
            "Corinthians",
            "Grêmio",
            "Internacional",
            "Cruzeiro",
            "Atlético Mineiro",
            "Fluminense",
            "Botafogo",
            "Vasco da Gama",
            "Santos",
            "Athletico Paranaense",
            "Bahia",
            "Ceará",
            "Fortaleza",
            "Sport Recife",
            "Chapecoense",
            "América Mineiro",
            "Atlético Goianiense"
        ];

        public Team(string name) {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public static IEnumerable<Team> CreateTeams(IEnumerable<string> names) {
            return names.Select(name =>  new Team(name));
        }
    }
}
