namespace FootballLeague.Migrations
{
    using FootballLeague.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;
    using static FootballLeague.Services.ServiceLeague;

    internal sealed class Configuration : DbMigrationsConfiguration<FootballLeague.Data.FootballLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FootballLeague.Data.FootballLeagueContext";
        }

        protected override void Seed(FootballLeague.Data.FootballLeagueContext context)
        {
            // Remove todos os jogadores primeiro (para evitar erro de FK com Teams)
            context.Players.RemoveRange(context.Players);

            // Depois remove todos os tecnicos
            context.Commissions.RemoveRange(context.Commissions);

            // Depois remove todos os times
            context.Teams.RemoveRange(context.Teams);

            // Depois remove os rounds
            context.Rounds.RemoveRange(context.Rounds);

            // Depois remove as partidas
            context.Matchs.RemoveRange(context.Matchs);

            // Depois remove a tabela da liga
            context.LeagueStandings.RemoveRange(context.LeagueStandings);

            // Depois remove a liga
            context.Leagues.RemoveRange(context.Leagues);

            context.SaveChanges();

            var liga = new List<League>
            {
                new League
                {
                    Id = 1,
                    Name = "CopaTópicos"
                }
            };
            var times = new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "Goiás",
                    City =  "Goiânia",
                    State =  "Goiás",
                    FoundationYear = 1943,
                    Stadium = "Serrinha",
                    CapacityStadium = 14525,
                    MainColors = "Verde e Branco",
                    SecondaryColors = "Branco e Verde",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "América Mineiro",
                    City =  "Belo Horizonte",
                    State =  "Minas Gerais",
                    FoundationYear = 1912,
                    Stadium = "Independência",
                    CapacityStadium = 23018,
                    MainColors = "Preto e Verde",
                    SecondaryColors = "Branco com Verde e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 3,
                    Name = "Atlético Mineiro",
                    City =  "Belo Horizonte",
                    State =  "Minas Gerais",
                    FoundationYear = 1908,
                    Stadium = "Arena MRV",
                    CapacityStadium = 46000,
                    MainColors = "Preto e Branco",
                    SecondaryColors = "Branco",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 4,
                    Name = "Cruzeiro",
                    City =  "Belo Horizonte",
                    State =  "Minas Gerais",
                    FoundationYear = 1921,
                    Stadium = "Mineirão",
                    CapacityStadium = 62000,
                    MainColors = "Azul e Branco",
                    SecondaryColors = "Branco e Azul",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 5,
                    Name = "Athletico Paranaense",
                    City =  "Curitiba",
                    State =  "Paraná",
                    FoundationYear = 1924,
                    Stadium = "Ligga Arena",
                    CapacityStadium = 42372,
                    MainColors = "Vermelho e Preto",
                    SecondaryColors = "Dourado e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 6,
                    Name = "Coritiba",
                    City =  "Curitiba",
                    State =  "Paraná",
                    FoundationYear = 1909,
                    Stadium = "Major Antônio Couto Pereira",
                    CapacityStadium = 40502,
                    MainColors = "Branco com Verde e Preto",
                    SecondaryColors = "Verde e Branco",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 7,
                    Name = "Sport",
                    City =  "Recife",
                    State =  "Pernambuco",
                    FoundationYear = 1905,
                    Stadium = "Ilha do Retiro",
                    CapacityStadium = 26418,
                    MainColors = "Vermelho e Preto",
                    SecondaryColors = "Amarelo e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 8,
                    Name = "Botafogo",
                    City =  "Rio de Janeiro",
                    State =  "Rio de Janeiro",
                    FoundationYear = 1894,
                    Stadium = "Nilton Santos",
                    CapacityStadium = 46831,
                    MainColors = "Preto e Branco",
                    SecondaryColors = "Preto com Dourado",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 9,
                    Name = "Flamengo",
                    City =  "Rio de Janeiro",
                    State =  "Rio de Janeiro",
                    FoundationYear = 1895,
                    Stadium = "Maracanã",
                    CapacityStadium = 78838,
                    MainColors = "Preto e Vermelho com Branco",
                    SecondaryColors = "Branco e Vermelho com Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 10,
                    Name = "Fluminense",
                    City =  "Rio de Janeiro",
                    State =  "Rio de Janeiro",
                    FoundationYear = 1902,
                    Stadium = "Manoel Schwartz",
                    CapacityStadium = 8000,
                    MainColors = "Verde e Vermelho com Branco",
                    SecondaryColors = "Branco e Verde com Vermelho",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 11,
                    Name = "Vasco da Gama",
                    City =  "Rio de Janeiro",
                    State =  "Rio de Janeiro",
                    FoundationYear = 1898,
                    Stadium = "São Januário",
                    CapacityStadium = 20419,
                    MainColors = "Preto e Branco",
                    SecondaryColors = "Branco e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 12,
                    Name = "Internacional",
                    City =  "Porto Alegre",
                    State =  "Rio Grande do Sul",
                    FoundationYear = 1909,
                    Stadium = "Beira-Rio",
                    CapacityStadium = 50128,
                    MainColors = "Vermelho e Branco",
                    SecondaryColors = "Branco e Vermelho",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 13,
                    Name = "Grêmio",
                    City =  "Porto Alegre",
                    State =  "Rio Grande do Sul",
                    FoundationYear = 1903,
                    Stadium = "Arena do Grêmio",
                    CapacityStadium = 60540,
                    MainColors = "Azul e Preto com Branco",
                    SecondaryColors = "Branco com Azul e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 14,
                    Name = "Chapecoense",
                    City =  "Chapecó",
                    State =  "Santa Catarina",
                    FoundationYear = 1973,
                    Stadium = "Arena Condá",
                    CapacityStadium = 22600,
                    MainColors = "Verde com Branco",
                    SecondaryColors = "Branco com Verde",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 15,
                    Name = "Figueirense",
                    City =  "Florianópolis",
                    State =  "Santa Catarina",
                    FoundationYear = 1921,
                    Stadium = "Orlando Scarpelli",
                    CapacityStadium = 19584,
                    MainColors = "Preto e Branco",
                    SecondaryColors = "Branco e Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 16,
                    Name = "Corinthians",
                    City =  "São Paulo",
                    State =  "São Paulo",
                    FoundationYear = 1910,
                    Stadium = "Neo Química Arena",
                    CapacityStadium = 48905,
                    MainColors = "Preto e Branco",
                    SecondaryColors = "Preto",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 17,
                    Name = "Palmeiras",
                    City =  "São Paulo",
                    State =  "São Paulo",
                    FoundationYear = 1914,
                    Stadium = "Allianz Parque",
                    CapacityStadium = 43713,
                    MainColors = "Verde e Branco",
                    SecondaryColors = "Branco e Verde",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 18,
                    Name = "Santos",
                    City =  "Santos",
                    State =  "São Paulos",
                    FoundationYear = 1912,
                    Stadium = "Vila Belmiro",
                    CapacityStadium = 17923,
                    MainColors = "Branco",
                    SecondaryColors = "Preto e Branco",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 19,
                    Name = "Red Bull Bragantino",
                    City =  "Bragança Paulista",
                    State =  "São Paulo",
                    FoundationYear = 1928,
                    Stadium = "Nabi Abi Chedid",
                    CapacityStadium = 17022,
                    MainColors = "Vermelho e Branco",
                    SecondaryColors = "Azul e Vermelho",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 20,
                    Name = "São Paulo",
                    City =  "São Paulo",
                    State =  "São Paulo",
                    FoundationYear = 1930,
                    Stadium = "MorumBIS",
                    CapacityStadium = 66795,
                    MainColors = "Branco com Vermelho e Preto",
                    SecondaryColors = "Vermelho e Preto com Branco",
                    LeagueId = 1
                },
            };
            var jogadores = new List<Player>
            {
                //Jogadores Id1 
#region
                new Player
                {
                    Id = 600,
                    Name = "Jogador Deletavel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 08, 28),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 17,
                    Height = 1.61m,
                    Weight = 69.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 1,
                    Name = "José Souza Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 08, 28),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 17,
                    Height = 1.61m,
                    Weight = 69.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 2,
                    Name = "Murilo Silva Cardoso",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 08, 20),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 7,
                    Height = 1.62m,
                    Weight = 68.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 3,
                    Name = "Davi Melo Silva",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 11, 24),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 82,
                    Height = 1.72m,
                    Weight = 80.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 1
                },
                new Player
                {
                    Id = 4,
                    Name = "Rodrigo Pinto Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 02, 12),
                    Position = Position.LateralDireito,
                    ShirtNumber = 30,
                    Height = 1.66m,
                    Weight = 98.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 5,
                    Name = "Murilo Goncalves Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 01, 05),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 71,
                    Height = 1.66m,
                    Weight = 73.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 6,
                    Name = "Vinicius Rocha Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 03, 18),
                    Position = Position.Ponta,
                    ShirtNumber = 86,
                    Height = 1.8m,
                    Weight = 66.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 7,
                    Name = "Thiago Dias Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 09, 09),
                    Position = Position.Goleiro,
                    ShirtNumber = 58,
                    Height = 1.86m,
                    Weight = 85.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 1
                },
                new Player
                {
                    Id = 8,
                    Name = "Arthur Santos Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 04, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 81,
                    Height = 1.65m,
                    Weight = 88.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 9,
                    Name = "Felipe Azevedo Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 01, 22),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 73,
                    Height = 1.94m,
                    Weight = 65.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 10,
                    Name = "André Goncalves Barros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 02, 04),
                    Position = Position.AlaDireito,
                    ShirtNumber = 28,
                    Height = 1.97m,
                    Weight = 74.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 11,
                    Name = "Julian Cavalcanti Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 02, 16),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 46,
                    Height = 1.81m,
                    Weight = 95.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 12,
                    Name = "Tomás Cunha Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 12, 28),
                    Position = Position.AlaDireito,
                    ShirtNumber = 20,
                    Height = 1.6m,
                    Weight = 62.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 13,
                    Name = "Murilo Costa Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 05, 22),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 96,
                    Height = 1.71m,
                    Weight = 91.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 14,
                    Name = "Rodrigo Pereira Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 08, 23),
                    Position = Position.AlaDireito,
                    ShirtNumber = 20,
                    Height = 1.86m,
                    Weight = 77.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 15,
                    Name = "Douglas Araujo Cavalcanti",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 04, 06),
                    Position = Position.Goleiro,
                    ShirtNumber = 77,
                    Height = 1.69m,
                    Weight = 74.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 16,
                    Name = "Felipe Rocha Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 01, 06),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 61,
                    Height = 1.63m,
                    Weight = 99.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 17,
                    Name = "Vinicius Goncalves Cavalcanti",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 12, 01),
                    Position = Position.LateralDireito,
                    ShirtNumber = 71,
                    Height = 1.97m,
                    Weight = 68.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 18,
                    Name = "Enzo Cunha Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 08, 17),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 59,
                    Height = 1.71m,
                    Weight = 74.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 19,
                    Name = "Rodrigo Barros Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 04, 15),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 43,
                    Height = 1.85m,
                    Weight = 93.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 20,
                    Name = "Cauã Correia Dias",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 09, 15),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 74,
                    Height = 1.64m,
                    Weight = 71.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 21,
                    Name = "Thiago Santos Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 04, 01),
                    Position = Position.AlaDireito,
                    ShirtNumber = 2,
                    Height = 1.79m,
                    Weight = 93.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 22,
                    Name = "João Correia Barros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 06, 16),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 97,
                    Height = 1.61m,
                    Weight = 62.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 23,
                    Name = "Tiago Santos Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 12, 09),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 26,
                    Height = 1.74m,
                    Weight = 75.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 24,
                    Name = "Antônio Souza Silva",
                    Nacionality = "Argentino",
                    BirthDate = new DateTime(1984, 11, 26),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 61,
                    Height = 1.72m,
                    Weight = 80.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                new Player
                {
                    Id = 25,
                    Name = "Mateus Costa Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 05, 24),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 28,
                    Height = 1.89m,
                    Weight = 91.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 26,
                    Name = "Nicolash Alves Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 11, 14),
                    Position = Position.AlaDireito,
                    ShirtNumber = 26,
                    Height = 1.74m,
                    Weight = 71.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 27,
                    Name = "Kaua Souza Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 12, 07),
                    Position = Position.LateralDireito,
                    ShirtNumber = 65,
                    Height = 1.84m,
                    Weight = 89.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 28,
                    Name = "Bruno Melo Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 07, 06),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 47,
                    Height = 1.73m,
                    Weight = 88.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 1
                },
                new Player
                {
                    Id = 29,
                    Name = "Tiago Sousa Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 12, 18),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 73,
                    Height = 1.95m,
                    Weight = 91.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 1
                },
                #endregion
                //Jogadores Id2
#region
                new Player
                {
                    Id = 30,
                    Name = "Enzo Costa Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 11, 29),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 55,
                    Height = 1.63m,
                    Weight = 75.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 31,
                    Name = "Bruno Rodrigues Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 04, 11),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 78,
                    Height = 1.79m,
                    Weight = 93.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 32,
                    Name = "Daniel Ribeiro Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 04, 05),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 9,
                    Height = 1.98m,
                    Weight = 80.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 33,
                    Name = "Diogo Melo Dias",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 09, 13),
                    Position = Position.Zagueiro,
                    ShirtNumber = 50,
                    Height = 1.76m,
                    Weight = 61.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 34,
                    Name = "Cauã Carvalho Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 10, 24),
                    Position = Position.Zagueiro,
                    ShirtNumber = 3,
                    Height = 1.72m,
                    Weight = 94.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 35,
                    Name = "Joao Cunha Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 02, 09),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 85,
                    Height = 1.62m,
                    Weight = 93.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 36,
                    Name = "Luis Gomes Silva",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 09, 25),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 68,
                    Height = 1.61m,
                    Weight = 90.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 37,
                    Name = "Joao Oliveira Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 12, 15),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 30,
                    Height = 1.65m,
                    Weight = 67.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 38,
                    Name = "Tomás Martins Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 05, 21),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 65,
                    Height = 1.74m,
                    Weight = 60.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 39,
                    Name = "Danilo Correia Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 12, 13),
                    Position = Position.Goleiro,
                    ShirtNumber = 22,
                    Height = 1.85m,
                    Weight = 87.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 40,
                    Name = "João Santos Costa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 04, 18),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 30,
                    Height = 1.91m,
                    Weight = 61.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 41,
                    Name = "Vinícius Fernandes Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 08, 30),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 60,
                    Height = 1.66m,
                    Weight = 63.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 42,
                    Name = "Enzo Azevedo Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 07, 11),
                    Position = Position.Goleiro,
                    ShirtNumber = 9,
                    Height = 1.84m,
                    Weight = 83.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 43,
                    Name = "Ryan Goncalves Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 11, 26),
                    Position = Position.AlaDireito,
                    ShirtNumber = 91,
                    Height = 2.0m,
                    Weight = 73.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 44,
                    Name = "Kauã Pinto Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 12, 28),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 94,
                    Height = 1.9m,
                    Weight = 99.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 45,
                    Name = "Diogo Lima Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 10, 03),
                    Position = Position.Volante,
                    ShirtNumber = 72,
                    Height = 1.99m,
                    Weight = 70.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 46,
                    Name = "Mateus Costa Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 07, 01),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 58,
                    Height = 1.76m,
                    Weight = 80.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 47,
                    Name = "Joao Goncalves Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 05, 01),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 97,
                    Height = 1.75m,
                    Weight = 88.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 48,
                    Name = "Thiago Rocha Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 01, 25),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 7,
                    Height = 1.9m,
                    Weight = 65.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 49,
                    Name = "Nicolash Rocha Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 04, 25),
                    Position = Position.Volante,
                    ShirtNumber = 63,
                    Height = 1.73m,
                    Weight = 71.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 50,
                    Name = "Antônio Gomes Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 12, 16),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 72,
                    Height = 1.78m,
                    Weight = 96.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 51,
                    Name = "Diogo Alves Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 11, 05),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 9,
                    Height = 1.9m,
                    Weight = 70.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 52,
                    Name = "Enzo Barbosa Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 11, 07),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 9,
                    Height = 1.98m,
                    Weight = 69.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 53,
                    Name = "Leonardo Santos Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 01, 06),
                    Position = Position.Ponta,
                    ShirtNumber = 5,
                    Height = 1.71m,
                    Weight = 81.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 54,
                    Name = "Murilo Correia Cardoso",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 17),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 93,
                    Height = 1.69m,
                    Weight = 91.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 55,
                    Name = "Daniel Ribeiro Ferreira",
                    Nacionality = "Uruguaio",
                    BirthDate = new DateTime(1992, 05, 04),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 73,
                    Height = 1.83m,
                    Weight = 68.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 56,
                    Name = "Diogo Oliveira Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 12, 31),
                    Position = Position.Zagueiro,
                    ShirtNumber = 16,
                    Height = 1.74m,
                    Weight = 80.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 2
                },
                new Player
                {
                    Id = 57,
                    Name = "Gabriel Goncalves Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 02, 02),
                    Position = Position.Ponta,
                    ShirtNumber = 92,
                    Height = 1.82m,
                    Weight = 71.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 2
                },
                new Player
                {
                    Id = 58,
                    Name = "Kaua Martins Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 06, 04),
                    Position = Position.Ponta,
                    ShirtNumber = 45,
                    Height = 1.87m,
                    Weight = 91.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                new Player
                {
                    Id = 59,
                    Name = "Tiago Melo Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 05, 21),
                    Position = Position.LateralDireito,
                    ShirtNumber = 40,
                    Height = 1.71m,
                    Weight = 74.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 2
                },
                #endregion
                //Jogadores Id3
#region
                new Player
                {
                    Id = 60,
                    Name = "Douglas Fernandes Dias",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 12, 29),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 89,
                    Height = 1.76m,
                    Weight = 68.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 61,
                    Name = "Felipe Goncalves Sousa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 05, 02),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 57,
                    Height = 1.71m,
                    Weight = 73.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 62,
                    Name = "Gabriel Martins Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 02, 01),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 75,
                    Height = 1.95m,
                    Weight = 83.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 63,
                    Name = "Thiago Fernandes Sousa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 07, 03),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 23,
                    Height = 1.99m,
                    Weight = 68.1m,
                    MainFeet = MainFeet.Esquerdo
,
                    TeamId = 3
                },
                new Player
                {
                    Id = 64,
                    Name = "Enzo Gomes Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 12, 19),
                    Position = Position.Volante,
                    ShirtNumber = 20,
                    Height = 1.63m,
                    Weight = 83.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 65,
                    Name = "Gabriel Rodrigues Cunha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 02, 20),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 48,
                    Height = 1.94m,
                    Weight = 63.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 66,
                    Name = "Carlos Oliveira Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 03, 06),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 9,
                    Height = 1.66m,
                    Weight = 75.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 67,
                    Name = "Arthur Barbosa Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 12, 09),
                    Position = Position.Ponta,
                    ShirtNumber = 41,
                    Height = 1.93m,
                    Weight = 99.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 68,
                    Name = "Ryan Souza Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 01, 30),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 57,
                    Height = 1.92m,
                    Weight = 74.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 69,
                    Name = "Eduardo Barbosa Cunha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 23),
                    Position = Position.Zagueiro,
                    ShirtNumber = 49,
                    Height = 1.66m,
                    Weight = 64.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 70,
                    Name = "Júlio Rodrigues Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 03, 07),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 1,
                    Height = 1.62m,
                    Weight = 77.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 71,
                    Name = "Caio Azevedo Araujo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 05, 23),
                    Position = Position.Ponta,
                    ShirtNumber = 72,
                    Height = 1.98m,
                    Weight = 64.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 72,
                    Name = "José Araujo Cunha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 01, 03),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 23,
                    Height = 1.73m,
                    Weight = 97.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 73,
                    Name = "Lucas Barbosa Sousa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 04, 27),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 37,
                    Height = 1.7m,
                    Weight = 90.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 74,
                    Name = "Murilo Castro Cavalcanti",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 09, 26),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 84,
                    Height = 1.83m,
                    Weight = 61.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 75,
                    Name = "Martim Azevedo Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 11, 03),
                    Position = Position.Ponta,
                    ShirtNumber = 91,
                    Height = 1.66m,
                    Weight = 61.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 76,
                    Name = "Benício Vasconcelos Quintana",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 03, 05),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 30,
                    Height = 1.63m,
                    Weight = 66.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 77,
                    Name = "Gabriel Antunes Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 05, 28),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 26,
                    Height = 1.83m,
                    Weight = 89.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 78,
                    Name = "Davi Vasconcelos Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 11, 10),
                    Position = Position.Ponta,
                    ShirtNumber = 65,
                    Height = 1.85m,
                    Weight = 72.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 79,
                    Name = "Gabriel Freitas Cardoso",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 07, 09),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 98,
                    Height = 1.91m,
                    Weight = 72.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 80,
                    Name = "João Miguel Sales Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 01, 14),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 17,
                    Height = 1.62m,
                    Weight = 84.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 81,
                    Name = "Noah Macedo Faria",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 02, 26),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 75,
                    Height = 1.73m,
                    Weight = 99.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 82,
                    Name = "Joaquim Pimentel Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 01, 04),
                    Position = Position.Zagueiro,
                    ShirtNumber = 88,
                    Height = 1.65m,
                    Weight = 80.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 83,
                    Name = "Gael Prado Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 01, 15),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 90,
                    Height = 1.83m,
                    Weight = 89.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 84,
                    Name = "Miguel Barbosa Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 07, 29),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 25,
                    Height = 1.81m,
                    Weight = 66.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 85,
                    Name = "Davi Vargas Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 05, 08),
                    Position = Position.Zagueiro,
                    ShirtNumber = 43,
                    Height = 1.67m,
                    Weight = 62.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                new Player
                {
                    Id = 86,
                    Name = "Théo Cunha Vasconcelos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 05, 27),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 96,
                    Height = 1.61m,
                    Weight = 80.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 87,
                    Name = "Henry Neves Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 07, 16),
                    Position = Position.Ponta,
                    ShirtNumber = 50,
                    Height = 1.83m,
                    Weight = 70.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 3
                },
                new Player
                {
                    Id = 88,
                    Name = "Gabriel Bernardes​ Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 03, 16),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 54,
                    Height = 1.87m,
                    Weight = 62.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 3
                },
                new Player
                {
                    Id = 89,
                    Name = "Isaac Cardoso Bernardes​",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 05, 03),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 66,
                    Height = 1.73m,
                    Weight = 91.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 3
                },
                #endregion
                //Jogadores Id4
#region
                new Player
                {
                    Id = 90,
                    Name = "Pedro Macedo Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 03, 29),
                    Position = Position.Zagueiro,
                    ShirtNumber = 72,
                    Height = 1.65m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 91,
                    Name = "Arthur Fonseca Cabral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 03, 30),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 12,
                    Height = 1.72m,
                    Weight = 73.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 92,
                    Name = "Gael Marques Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 04, 25),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 79,
                    Height = 1.67m,
                    Weight = 79.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 93,
                    Name = "Anthony Cabral Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 07, 20),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.63m,
                    Weight = 65.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 94,
                    Name = "Miguel Barbosa Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 16),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 33,
                    Height = 1.72m,
                    Weight = 80.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 95,
                    Name = "Henry Correia Godinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 04, 28),
                    Position = Position.AlaDireito,
                    ShirtNumber = 18,
                    Height = 1.97m,
                    Weight = 80.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 96,
                    Name = "Lorenzo Batista Botelho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 03, 09),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 26,
                    Height = 1.91m,
                    Weight = 66.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 97,
                    Name = "Lucas Bernardes​ Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 05, 18),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 70,
                    Height = 1.99m,
                    Weight = 84.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4

                },
                new Player
                {
                    Id = 98,
                    Name = "Anthony Bernardes​ Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 05, 23),
                    Position = Position.AlaDireito,
                    ShirtNumber = 65,
                    Height = 1.9m,
                    Weight = 90.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 99,
                    Name = "Gael Domingues Macedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 08, 18),
                    Position = Position.Goleiro,
                    ShirtNumber = 80,
                    Height = 1.61m,
                    Weight = 93.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 100,
                    Name = "Gabriel Gouveia Medeiros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 07, 10),
                    Position = Position.Goleiro,
                    ShirtNumber = 92,
                    Height = 1.82m,
                    Weight = 97.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 101,
                    Name = "Benjamin Quaresma Martins",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1995, 06, 25),
                    Position = Position.AlaDireito,
                    ShirtNumber = 86,
                    Height = 1.86m,
                    Weight = 87.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 102,
                    Name = "Rafael Neves Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 11),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 32,
                    Height = 1.78m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 103,
                    Name = "Gabriel Quintana Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 06, 13),
                    Position = Position.Ponta,
                    ShirtNumber = 26,
                    Height = 1.93m,
                    Weight = 68.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 104,
                    Name = "Ravi Mendonça Castro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 08, 26),
                    Position = Position.AlaDireito,
                    ShirtNumber = 43,
                    Height = 1.66m,
                    Weight = 81.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 105,
                    Name = "Ravi Figueiredo Gouveia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 25),
                    Position = Position.Volante,
                    ShirtNumber = 46,
                    Height = 1.94m,
                    Weight = 69.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 106,
                    Name = "Pedro Aguiar Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 10, 07),
                    Position = Position.LateralDireito,
                    ShirtNumber = 41,
                    Height = 1.96m,
                    Weight = 85.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 107,
                    Name = "Bernardo Correia Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 09, 12),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 20,
                    Height = 1.83m,
                    Weight = 63.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 108,
                    Name = "Matheus Furtado Macedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 05, 24),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 32,
                    Height = 1.65m,
                    Weight = 73.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 109,
                    Name = "Théo Pinheiro Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 04, 26),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 79,
                    Height = 1.92m,
                    Weight = 61.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 110,
                    Name = "Lucca Peixoto Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 10),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 88,
                    Height = 1.89m,
                    Weight = 83.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 111,
                    Name = "Murilo Teles Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 05, 22),
                    Position = Position.Goleiro,
                    ShirtNumber = 94,
                    Height = 1.71m,
                    Weight = 81.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 112,
                    Name = "Henrique Fonseca Camacho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 09, 06),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 3,
                    Height = 1.82m,
                    Weight = 80.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 113,
                    Name = "Rafael Neves Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 04, 11),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 87,
                    Height = 1.66m,
                    Weight = 69.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 114,
                    Name = "Nicolas Neves Reis",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 09, 17),
                    Position = Position.Ponta,
                    ShirtNumber = 44,
                    Height = 1.94m,
                    Weight = 75.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 115,
                    Name = "Benício Pinto Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 05, 23),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 89,
                    Height = 1.91m,
                    Weight = 70.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 116,
                    Name = "Joaquim Godinho Chaves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 10, 25),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 54,
                    Height = 1.64m,
                    Weight = 68.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 4
                },
                new Player
                {
                    Id = 117,
                    Name = "Lorenzo Rego Duarte",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 01, 20),
                    Position = Position.AlaDireito,
                    ShirtNumber = 70,
                    Height = 1.97m,
                    Weight = 89.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                new Player
                {
                    Id = 118,
                    Name = "Miguel Marques Álvares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 06, 20),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 39,
                    Height = 1.9m,
                    Weight = 92.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 4
                },
                new Player
                {
                    Id = 119,
                    Name = "Matheus Pinto Vargas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 10, 16),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 82,
                    Height = 1.63m,
                    Weight = 76.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 4
                },
                #endregion
                //Jogadores Id5
#region
                new Player
                {
                    Id = 120,
                    Name = "Lorenzo Fernandes Martins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 02, 24),
                    Position = Position.LateralDireito,
                    ShirtNumber = 58,
                    Height = 1.72m,
                    Weight = 94.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 121,
                    Name = "Gabriel Miranda Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 11, 16),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 60,
                    Height = 1.89m,
                    Weight = 81.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 122,
                    Name = "Lucca Quintana Gouveia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 07, 17),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 8,
                    Height = 1.79m,
                    Weight = 69.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 123,
                    Name = "Lorenzo Duarte Domingues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 09, 02),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 65,
                    Height = 1.8m,
                    Weight = 75.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 124,
                    Name = "Nicolas Quaresma Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 11, 06),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 42,
                    Height = 1.61m,
                    Weight = 98.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 125,
                    Name = "Bernardo Sales Henriques",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2004, 05, 14),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 46,
                    Height = 1.9m,
                    Weight = 85.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 126,
                    Name = "Bernardo Sales Henriques",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2004, 05, 14),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 46,
                    Height = 1.9m,
                    Weight = 85.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 127,
                    Name = "Lucca Azevedo Cabral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 04, 23),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 28,
                    Height = 1.87m,
                    Weight = 99.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 128,
                    Name = "Rafael Pacheco Peixoto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 01, 13),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 94,
                    Height = 1.64m,
                    Weight = 93.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 129,
                    Name = "Théo Saldanha Medeiros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 07, 17),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 33,
                    Height = 1.76m,
                    Weight = 92.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 130,
                    Name = "Gui Araújo Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 01, 29),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 31,
                    Height = 1.73m,
                    Weight = 95.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 131,
                    Name = "Gael Tavares Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 01, 26),
                    Position = Position.AlaDireito,
                    ShirtNumber = 65,
                    Height = 1.68m,
                    Weight = 60.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 132,
                    Name = "Henrique Batista Vasconcelos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 03, 09),
                    Position = Position.LateralDireito,
                    ShirtNumber = 28,
                    Height = 1.83m,
                    Weight = 77.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 133,
                    Name = "Lucas Ramos Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 06, 03),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 13,
                    Height = 1.65m,
                    Weight = 65.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 134,
                    Name = "Lucca Furtado Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 11, 19),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 11,
                    Height = 1.7m,
                    Weight = 81.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 135,
                    Name = "Murilo Vieira Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 04, 16),
                    Position = Position.Goleiro,
                    ShirtNumber = 11,
                    Height = 1.68m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 136,
                    Name = "Benício Torres Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 05, 19),
                    Position = Position.LateralDireito,
                    ShirtNumber = 28,
                    Height = 1.73m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 137,
                    Name = "Levi Loureiro Figueiredo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 04, 16),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 55,
                    Height = 1.89m,
                    Weight = 85.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 138,
                    Name = "Bernardo Antunes Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 06, 08),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 56,
                    Height = 1.9m,
                    Weight = 92.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 139,
                    Name = "Joaquim Amaral Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 02, 20),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 22,
                    Height = 1.72m,
                    Weight = 62.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 140,
                    Name = "Miguel Rios Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 09, 06),
                    Position = Position.AlaDireito,
                    ShirtNumber = 41,
                    Height = 1.92m,
                    Weight = 98.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 141,
                    Name = "Henry Macedo Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 08, 24),
                    Position = Position.LateralDireito,
                    ShirtNumber = 64,
                    Height = 1.61m,
                    Weight = 93.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                new Player
                {
                    Id = 142,
                    Name = "Henrique Gouveia Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 04, 03),
                    Position = Position.Ponta,
                    ShirtNumber = 69,
                    Height = 1.66m,
                    Weight = 94.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 143,
                    Name = "Bernardo Amaral Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 08, 16),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 38,
                    Height = 1.75m,
                    Weight = 94.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 144,
                    Name = "Bernardo Cabral Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 03, 23),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 67,
                    Height = 1.99m,
                    Weight = 61.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 145,
                    Name = "Ravi Vaz Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 05, 28),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 18,
                    Height = 1.82m,
                    Weight = 76.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 146,
                    Name = "Henry Vasconcelos Ferreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 06, 08),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 61,
                    Height = 1.6m,
                    Weight = 78.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 5
                },
                new Player
                {
                    Id = 147,
                    Name = "Benício Rocha Gonçalves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 01, 13),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 11,
                    Height = 1.71m,
                    Weight = 94.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 148,
                    Name = "Gui Carvalho Santos",
                    Nacionality = "Argentino",
                    BirthDate = new DateTime(1993, 12, 31),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 47,
                    Height = 1.77m,
                    Weight = 81.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 5
                },
                new Player
                {
                    Id = 149,
                    Name = "Joaquim Botelho Moreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 11, 05),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 82,
                    Height = 1.96m,
                    Weight = 71.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 5
                },
                #endregion
                //Jogadores Id6
#region
                new Player
                {
                    Id = 150,
                    Name = "Henrique Camacho Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 09, 05),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 75,
                    Height = 1.8m,
                    Weight = 62.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 151,
                    Name = "Murilo Pinheiro Batista",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 06, 15),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 25,
                    Height = 1.62m,
                    Weight = 66.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 152,
                    Name = "Nicolas Cabral Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 02, 17),
                    Position = Position.Volante,
                    ShirtNumber = 58,
                    Height = 1.64m,
                    Weight = 82.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 153,
                    Name = "Gui Alves Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 12, 29),
                    Position = Position.Zagueiro,
                    ShirtNumber = 78,
                    Height = 1.69m,
                    Weight = 74.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 154,
                    Name = "Théo Fonseca Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 08, 31),
                    Position = Position.AlaDireito,
                    ShirtNumber = 39,
                    Height = 1.97m,
                    Weight = 81.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 155,
                    Name = "Lucca Pinheiro Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 06, 30),
                    Position = Position.Ponta,
                    ShirtNumber = 4,
                    Height = 1.69m,
                    Weight = 65.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 156,
                    Name = "Joaquim Figueiredo Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 04, 11),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 2,
                    Height = 1.97m,
                    Weight = 75.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 157,
                    Name = "Noah Costa Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 12, 06),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 77,
                    Height = 1.93m,
                    Weight = 90.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 158,
                    Name = "Matheus Moreira Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 01, 04),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 70,
                    Height = 1.84m,
                    Weight = 93.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 159,
                    Name = "Lucca Moreira Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 09, 26),
                    Position = Position.Volante,
                    ShirtNumber = 46,
                    Height = 1.68m,
                    Weight = 72.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 160,
                    Name = "Levi Leite Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 07, 01),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 45,
                    Height = 1.69m,
                    Weight = 67.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 161,
                    Name = "Bernardo Andrade Bernardes​",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 02, 19),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 30,
                    Height = 1.86m,
                    Weight = 99.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 162,
                    Name = "Matheus Furtado Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 05, 01),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 68,
                    Height = 1.7m,
                    Weight = 63.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 163,
                    Name = "Matheus Figueiredo Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 10, 02),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 30,
                    Height = 1.73m,
                    Weight = 84.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 164,
                    Name = "Benício Gomes Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 06, 13),
                    Position = Position.AlaDireito,
                    ShirtNumber = 35,
                    Height = 1.79m,
                    Weight = 67.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 165,
                    Name = "Noah Domingues Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 07, 27),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 31,
                    Height = 1.6m,
                    Weight = 81.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 166,
                    Name = "Bernardo Sales Bernardes​",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 01, 26),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 57,
                    Height = 1.78m,
                    Weight = 61.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 167,
                    Name = "Ravi Loureiro Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 03, 05),
                    Position = Position.Ponta,
                    ShirtNumber = 91,
                    Height = 1.63m,
                    Weight = 88.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 168,
                    Name = "Henrique Pires Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 02, 14),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 78,
                    Height = 1.71m,
                    Weight = 66.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 169,
                    Name = "Davi Tavares Vaz",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 12, 22),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 81,
                    Height = 1.86m,
                    Weight = 68.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 170,
                    Name = "Samuel Cabral Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 09, 21),
                    Position = Position.AlaDireito,
                    ShirtNumber = 85,
                    Height = 1.63m,
                    Weight = 75.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 171,
                    Name = "Gael Rocha Rego",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 06, 03),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 97,
                    Height = 1.99m,
                    Weight = 75.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 172,
                    Name = "Nicolas Araújo Castro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 03, 13),
                    Position = Position.Goleiro,
                    ShirtNumber = 35,
                    Height = 1.92m,
                    Weight = 85.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 173,
                    Name = "Arthur Lins Vasconcelos",
                    Nacionality = "Argentino",
                    BirthDate = new DateTime(1993, 09, 02),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 41,
                    Height = 1.93m,
                    Weight = 68.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 174,
                    Name = "Henrique Oliveira Martins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 08, 23),
                    Position = Position.Zagueiro,
                    ShirtNumber = 33,
                    Height = 1.75m,
                    Weight = 65.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 175,
                    Name = "Pedro Pires Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 08, 27),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 64,
                    Height = 1.85m,
                    Weight = 61.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 176,
                    Name = "Gui Botelho Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 08, 12),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 54,
                    Height = 1.66m,
                    Weight = 76.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 6
                },
                new Player
                {
                    Id = 177,
                    Name = "Joaquim Gonçalves Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 07, 16),
                    Position = Position.AlaDireito,
                    ShirtNumber = 37,
                    Height = 1.8m,
                    Weight = 72.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 6
                },
                new Player
                {
                    Id = 178,
                    Name = "Murilo Andrade Quintana",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 07, 16),
                    Position = Position.Volante,
                    ShirtNumber = 9,
                    Height = 1.81m,
                    Weight = 83.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },
                new Player
                {
                    Id = 179,
                    Name = "Samuel Ferreira Vasconcelos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 02, 17),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 98,
                    Height = 1.88m,
                    Weight = 68.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 6
                },

#endregion
                //Jogadores Id7
#region
                new Player
                {
                    Id = 180,
                    Name = "Matheus Quaresma Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 10, 11),
                    Position = Position.Volante,
                    ShirtNumber = 36,
                    Height = 1.66m,
                    Weight = 95.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 181,
                    Name = "Pedro Sales Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 09, 27),
                    Position = Position.LateralDireito,
                    ShirtNumber = 75,
                    Height = 1.91m,
                    Weight = 97.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 182,
                    Name = "Benjamin Figueiredo Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 01, 14),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 97,
                    Height = 1.75m,
                    Weight = 80.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 183,
                    Name = "Matheus Aguiar Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 09, 22),
                    Position = Position.Ponta,
                    ShirtNumber = 1,
                    Height = 1.89m,
                    Weight = 63.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 184,
                    Name = "Lucca Vargas Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 03, 28),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 60,
                    Height = 1.92m,
                    Weight = 78.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 185,
                    Name = "Pedro Andrade Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 02, 27),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 89,
                    Height = 1.94m,
                    Weight = 75.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 186,
                    Name = "Rafael Loureiro Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 09, 11),
                    Position = Position.LateralDireito,
                    ShirtNumber = 55,
                    Height = 1.7m,
                    Weight = 87.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 187,
                    Name = "Gui Vieira Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 07, 19),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 96,
                    Height = 1.7m,
                    Weight = 85.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 188,
                    Name = "Ravi Sales Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 02, 10),
                    Position = Position.Goleiro,
                    ShirtNumber = 74,
                    Height = 1.93m,
                    Weight = 93.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 189,
                    Name = "Gabriel Franco Vasconcelos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 04, 11),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 15,
                    Height = 1.79m,
                    Weight = 85.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 190,
                    Name = "Miguel Araújo Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 10, 21),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 16,
                    Height = 1.69m,
                    Weight = 86.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 191,
                    Name = "Ravi Neves Antunes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 05, 13),
                    Position = Position.LateralDireito,
                    ShirtNumber = 54,
                    Height = 1.93m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 192,
                    Name = "João Miguel Reis Melgaço",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 03, 10),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 8,
                    Height = 1.67m,
                    Weight = 76.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 193,
                    Name = "Noah Barreto Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 07, 30),
                    Position = Position.AlaDireito,
                    ShirtNumber = 65,
                    Height = 1.9m,
                    Weight = 90.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 194,
                    Name = "Rafael Fernandes Rios",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 05, 14),
                    Position = Position.AlaDireito,
                    ShirtNumber = 11,
                    Height = 1.78m,
                    Weight = 96.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 195,
                    Name = "Arthur Rodrigues Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 07, 10),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 89,
                    Height = 1.77m,
                    Weight = 82.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 196,
                    Name = "Davi Barbosa Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 08, 01),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 25,
                    Height = 1.62m,
                    Weight = 65.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 197,
                    Name = "Matheus Chaves Rocha",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2003, 10, 09),
                    Position = Position.Zagueiro,
                    ShirtNumber = 53,
                    Height = 1.8m,
                    Weight = 60.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 198,
                    Name = "Miguel Teles Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 10, 02),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 51,
                    Height = 1.67m,
                    Weight = 71.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 199,
                    Name = "Heitor Duarte Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 04, 13),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 71,
                    Height = 1.88m,
                    Weight = 79.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 200,
                    Name = "Théo Lima Veiga",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 07, 05),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 38,
                    Height = 1.64m,
                    Weight = 80.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 201,
                    Name = "Pedro Oliveira Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 05, 08),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 35,
                    Height = 1.93m,
                    Weight = 62.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 7
                },
                new Player
                {
                    Id = 202,
                    Name = "Bernardo Prado Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 07, 25),
                    Position = Position.Goleiro,
                    ShirtNumber = 39,
                    Height = 1.61m,
                    Weight = 79.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 203,
                    Name = "Davi Henriques Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 03, 16),
                    Position = Position.Volante,
                    ShirtNumber = 62,
                    Height = 1.74m,
                    Weight = 71.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 204,
                    Name = "Bernardo Pedrosa Barreto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 10, 28),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 35,
                    Height = 1.82m,
                    Weight = 79.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 205,
                    Name = "João Miguel Vasconcelos Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 12, 26),
                    Position = Position.Zagueiro,
                    ShirtNumber = 59,
                    Height = 1.71m,
                    Weight = 87.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 206,
                    Name = "Ravi Silva Pimentel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 09, 15),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 57,
                    Height = 1.72m,
                    Weight = 97.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },
                new Player
                {
                    Id = 207,
                    Name = "Lorenzo Rodrigues Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 11, 13),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 28,
                    Height = 1.97m,
                    Weight = 78.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 208,
                    Name = "Lucas Saldanha Franco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 11, 18),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 3,
                    Height = 1.77m,
                    Weight = 75.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 7
                },
                new Player
                {
                    Id = 209,
                    Name = "Levi Rego Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 03, 18),
                    Position = Position.LateralDireito,
                    ShirtNumber = 22,
                    Height = 1.92m,
                    Weight = 76.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 7
                },

#endregion
                //Jogadores Id8
#region
                new Player
                {
                    Id = 210,
                    Name = "Lucas Andrade Vargas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 09, 02),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 75,
                    Height = 1.6m,
                    Weight = 67.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 211,
                    Name = "Théo Alves Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 09, 23),
                    Position = Position.Zagueiro,
                    ShirtNumber = 5,
                    Height = 1.62m,
                    Weight = 95.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 212,
                    Name = "Isaac Caldeira Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 10, 21),
                    Position = Position.Ponta,
                    ShirtNumber = 29,
                    Height = 1.73m,
                    Weight = 68.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 213,
                    Name = "Benício Marques Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 02, 04),
                    Position = Position.Goleiro,
                    ShirtNumber = 59,
                    Height = 1.85m,
                    Weight = 75.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 214,
                    Name = "Davi Ribeiro Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 07, 08),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 38,
                    Height = 1.64m,
                    Weight = 67.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 215,
                    Name = "Pedro Faria Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 01, 02),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 25,
                    Height = 1.67m,
                    Weight = 96.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 216,
                    Name = "Joaquim Furtado Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 10, 23),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 40,
                    Height = 1.99m,
                    Weight = 85.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 217,
                    Name = "Lorenzo Silva Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 06, 23),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 19,
                    Height = 1.9m,
                    Weight = 81.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 218,
                    Name = "Henrique Batista Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 03, 05),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 9,
                    Height = 1.9m,
                    Weight = 67.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 219,
                    Name = "Joaquim Teles Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 12, 20),
                    Position = Position.LateralDireito,
                    ShirtNumber = 99,
                    Height = 1.92m,
                    Weight = 79.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 220,
                    Name = "Arthur Peixoto Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 04, 19),
                    Position = Position.Volante,
                    ShirtNumber = 3,
                    Height = 1.99m,
                    Weight = 68.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 221,
                    Name = "Noah Menezes Pimentel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 11, 25),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 30,
                    Height = 1.6m,
                    Weight = 92.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 222,
                    Name = "Miguel Franco Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 10, 09),
                    Position = Position.Ponta,
                    ShirtNumber = 96,
                    Height = 1.67m,
                    Weight = 65.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 223,
                    Name = "Joaquim Furtado Reis",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 01, 07),
                    Position = Position.LateralDireito,
                    ShirtNumber = 81,
                    Height = 1.7m,
                    Weight = 71.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 224,
                    Name = "Heitor Pires Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 31),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 41,
                    Height = 1.96m,
                    Weight = 71.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 225,
                    Name = "Arthur Machado Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 05, 08),
                    Position = Position.LateralDireito,
                    ShirtNumber = 75,
                    Height = 1.96m,
                    Weight = 83.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 226,
                    Name = "Samuel Menezes Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 08, 20),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 29,
                    Height = 1.91m,
                    Weight = 81.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 227,
                    Name = "Lucas Costa Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 08, 25),
                    Position = Position.Volante,
                    ShirtNumber = 13,
                    Height = 1.61m,
                    Weight = 75.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 228,
                    Name = "Murilo Melo Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 02, 14),
                    Position = Position.LateralDireito,
                    ShirtNumber = 77,
                    Height = 1.79m,
                    Weight = 72.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 229,
                    Name = "Benício Ribeiro Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 03, 13),
                    Position = Position.Zagueiro,
                    ShirtNumber = 90,
                    Height = 1.97m,
                    Weight = 70.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 230,
                    Name = "Heitor Sales Fonseca",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 07, 30),
                    Position = Position.Goleiro,
                    ShirtNumber = 78,
                    Height = 1.94m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 231,
                    Name = "Murilo Rocha Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 07, 24),
                    Position = Position.Ponta,
                    ShirtNumber = 25,
                    Height = 1.7m,
                    Weight = 73.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 232,
                    Name = "Ravi Pedrosa Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 04, 14),
                    Position = Position.Zagueiro,
                    ShirtNumber = 96,
                    Height = 1.89m,
                    Weight = 95.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 233,
                    Name = "Levi Chaves Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 10, 27),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 12,
                    Height = 1.88m,
                    Weight = 89.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 8
                },
                new Player
                {
                    Id = 234,
                    Name = "Lucas Freitas Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 11, 16),
                    Position = Position.Volante,
                    ShirtNumber = 61,
                    Height = 1.86m,
                    Weight = 77.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 8
                },
                new Player
                {
                    Id = 235,
                    Name = "Arthur Teles Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 07, 05),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 61,
                    Height = 1.6m,
                    Weight = 66.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 236,
                    Name = "Davi Reis Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 07, 30),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 65,
                    Height = 1.81m,
                    Weight = 72.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 237,
                    Name = "Gui Batista Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 10, 23),
                    Position = Position.Ponta,
                    ShirtNumber = 90,
                    Height = 1.75m,
                    Weight = 94.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 238,
                    Name = "Gui Silva Marinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 10, 08),
                    Position = Position.Volante,
                    ShirtNumber = 89,
                    Height = 1.89m,
                    Weight = 62.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },
                new Player
                {
                    Id = 239,
                    Name = "Bernardo Vasconcelos Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 07, 12),
                    Position = Position.Zagueiro,
                    ShirtNumber = 16,
                    Height = 1.75m,
                    Weight = 68.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 8
                },

#endregion
                //Jogadores Id9
#region
                new Player
                {
                    Id = 240,
                    Name = "Henry Rios Botelho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 05, 29),
                    Position = Position.Volante,
                    ShirtNumber = 20,
                    Height = 1.99m,
                    Weight = 80.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 241,
                    Name = "Levi Rocha Vaz",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 09, 09),
                    Position = Position.Goleiro,
                    ShirtNumber = 5,
                    Height = 1.76m,
                    Weight = 81.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 242,
                    Name = "Levi Brito Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 02, 05),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 95,
                    Height = 1.89m,
                    Weight = 88.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 243,
                    Name = "Henrique Cunha Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 08, 02),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 22,
                    Height = 1.98m,
                    Weight = 84.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 244,
                    Name = "Rafael Fonseca Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 03, 30),
                    Position = Position.Goleiro,
                    ShirtNumber = 51,
                    Height = 1.87m,
                    Weight = 90.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 245,
                    Name = "Rafael Vasconcelos Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 02, 17),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 81,
                    Height = 1.9m,
                    Weight = 63.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 246,
                    Name = "Noah Teles Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 11, 04),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 61,
                    Height = 1.93m,
                    Weight = 89.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 247,
                    Name = "Gabriel Pires Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 05, 15),
                    Position = Position.Volante,
                    ShirtNumber = 92,
                    Height = 1.87m,
                    Weight = 83.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 248,
                    Name = "Murilo Pinheiro Ferreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 07, 26),
                    Position = Position.AlaDireito,
                    ShirtNumber = 2,
                    Height = 1.91m,
                    Weight = 91.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 249,
                    Name = "Noah Rodrigues Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 09, 25),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 23,
                    Height = 1.93m,
                    Weight = 80.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 250,
                    Name = "Joaquim Rios Faria",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 04, 15),
                    Position = Position.Ponta,
                    ShirtNumber = 55,
                    Height = 1.88m,
                    Weight = 68.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 251,
                    Name = "Rafael Carvalho Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 08, 19),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 30,
                    Height = 1.95m,
                    Weight = 88.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 252,
                    Name = "Lucas Machado Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 11, 23),
                    Position = Position.Volante,
                    ShirtNumber = 9,
                    Height = 1.71m,
                    Weight = 65.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 253,
                    Name = "Lucca Pereira Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 09, 15),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 22,
                    Height = 1.89m,
                    Weight = 95.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 254,
                    Name = "Arthur Loureiro Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 02, 17),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 71,
                    Height = 1.83m,
                    Weight = 71.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 255,
                    Name = "Bernardo Miranda Freitas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 12, 08),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 28,
                    Height = 1.68m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 256,
                    Name = "Pedro Pinto Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 01),
                    Position = Position.Zagueiro,
                    ShirtNumber = 76,
                    Height = 1.8m,
                    Weight = 80.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 257,
                    Name = "Noah Barreto Martins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 09, 30),
                    Position = Position.Ponta,
                    ShirtNumber = 79,
                    Height = 1.86m,
                    Weight = 83.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 258,
                    Name = "Anthony Oliveira Faria",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1998, 05, 09),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 10,
                    Height = 1.66m,
                    Weight = 72.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 259,
                    Name = "Rafael Cardoso Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 07, 08),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 78,
                    Height = 1.65m,
                    Weight = 62.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 260,
                    Name = "Matheus Pacheco Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 29),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 98,
                    Height = 1.87m,
                    Weight = 83.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 261,
                    Name = "Isaac Neves Macedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 09, 07),
                    Position = Position.Ponta,
                    ShirtNumber = 74,
                    Height = 1.66m,
                    Weight = 83.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 262,
                    Name = "Matheus Rocha Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 05, 30),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 79,
                    Height = 1.83m,
                    Weight = 75.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 9
                },
                new Player
                {
                    Id = 263,
                    Name = "Anthony Duarte Leite",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 03, 17),
                    Position = Position.Goleiro,
                    ShirtNumber = 77,
                    Height = 1.81m,
                    Weight = 95.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 264,
                    Name = "Théo Rego Franco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 04, 26),
                    Position = Position.AlaDireito,
                    ShirtNumber = 65,
                    Height = 1.61m,
                    Weight = 78.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 265,
                    Name = "João Miguel Saldanha Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 12, 09),
                    Position = Position.Zagueiro,
                    ShirtNumber = 87,
                    Height = 1.89m,
                    Weight = 64.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 266,
                    Name = "Isaac Gouveia Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 09, 30),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 60,
                    Height = 1.61m,
                    Weight = 65.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 267,
                    Name = "Heitor Barreto Chaves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 03, 20),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 66,
                    Height = 1.64m,
                    Weight = 90.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 9
                },
                new Player
                {
                    Id = 268,
                    Name = "Miguel Brito Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 04),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 96,
                    Height = 2.0m,
                    Weight = 89.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },
                new Player
                {
                    Id = 269,
                    Name = "Nicolas Ferreira Godinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 03, 01),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 5,
                    Height = 1.97m,
                    Weight = 89.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 9
                },

#endregion
                //Jogadores Id10
#region
                new Player
                {
                    Id = 270,
                    Name = "Lucca Teles Castro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 01, 25),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 49,
                    Height = 1.95m,
                    Weight = 87.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 271,
                    Name = "Levi Vaz Vargas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 10, 05),
                    Position = Position.Zagueiro,
                    ShirtNumber = 63,
                    Height = 1.62m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 272,
                    Name = "Benjamin Vieira Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 06, 13),
                    Position = Position.AlaDireito,
                    ShirtNumber = 84,
                    Height = 1.78m,
                    Weight = 92.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 273,
                    Name = "Noah Pedrosa Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 08, 19),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 55,
                    Height = 1.81m,
                    Weight = 98.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 274,
                    Name = "Benjamin Furtado Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 02, 05),
                    Position = Position.Zagueiro,
                    ShirtNumber = 51,
                    Height = 1.71m,
                    Weight = 99.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 275,
                    Name = "Lorenzo Aguiar Duarte",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 09, 24),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 99,
                    Height = 1.85m,
                    Weight = 66.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 276,
                    Name = "Joaquim Cunha Fonseca",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 01, 15),
                    Position = Position.Volante,
                    ShirtNumber = 46,
                    Height = 1.97m,
                    Weight = 87.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 277,
                    Name = "Bernardo Quaresma Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 01, 22),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 11,
                    Height = 1.8m,
                    Weight = 88.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 278,
                    Name = "Miguel Pacheco Rios",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 11, 11),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 17,
                    Height = 1.8m,
                    Weight = 69.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 279,
                    Name = "Noah Rocha Barreto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 03, 10),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 58,
                    Height = 1.98m,
                    Weight = 63.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 280,
                    Name = "Nicolas Reis Pimentel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 05, 04),
                    Position = Position.Goleiro,
                    ShirtNumber = 81,
                    Height = 1.99m,
                    Weight = 72.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 281,
                    Name = "Nicolas Reis Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 12, 17),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 56,
                    Height = 1.7m,
                    Weight = 97.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 282,
                    Name = "Gui Ribeiro Pinheiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 11, 08),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 79,
                    Height = 1.89m,
                    Weight = 95.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 283,
                    Name = "Lucas Amaral Quintana",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2004, 10, 07),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 44,
                    Height = 1.83m,
                    Weight = 88.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 284,
                    Name = "Heitor Rodrigues Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 06, 30),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 88,
                    Height = 1.66m,
                    Weight = 74.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 285,
                    Name = "Nicolas Caldeira Pinto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 03, 22),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 47,
                    Height = 1.65m,
                    Weight = 73.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 286,
                    Name = "Bernardo Pacheco Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 11, 02),
                    Position = Position.Goleiro,
                    ShirtNumber = 50,
                    Height = 1.84m,
                    Weight = 92.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 287,
                    Name = "Nicolas Pires Lima",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 12),
                    Position = Position.AlaDireito,
                    ShirtNumber = 79,
                    Height = 1.72m,
                    Weight = 66.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 288,
                    Name = "Arthur Souza Barreto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 03, 30),
                    Position = Position.Volante,
                    ShirtNumber = 49,
                    Height = 1.72m,
                    Weight = 84.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 289,
                    Name = "Benjamin Bernardes​ Melgaço",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 08, 15),
                    Position = Position.AlaDireito,
                    ShirtNumber = 50,
                    Height = 1.73m,
                    Weight = 85.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 290,
                    Name = "Arthur Gomes Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 12, 08),
                    Position = Position.Goleiro,
                    ShirtNumber = 25,
                    Height = 1.86m,
                    Weight = 61.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 10
                },
                new Player
                {
                    Id = 291,
                    Name = "Samuel Barros Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 12, 18),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 35,
                    Height = 1.78m,
                    Weight = 79.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 292,
                    Name = "Levi Veiga Medeiros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 09, 18),
                    Position = Position.LateralDireito,
                    ShirtNumber = 41,
                    Height = 1.82m,
                    Weight = 66.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 293,
                    Name = "Isaac Batista Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 08, 23),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 24,
                    Height = 1.89m,
                    Weight = 66.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 294,
                    Name = "Samuel Gonçalves Brito",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 05, 30),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 71,
                    Height = 1.7m,
                    Weight = 66.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 295,
                    Name = "Heitor Sales Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 10, 25),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 80,
                    Height = 1.72m,
                    Weight = 74.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 296,
                    Name = "Isaac Rodrigues Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 10, 14),
                    Position = Position.Zagueiro,
                    ShirtNumber = 59,
                    Height = 1.82m,
                    Weight = 82.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 10
                },
                new Player
                {
                    Id = 297,
                    Name = "Murilo Lima Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 05, 22),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 77,
                    Height = 1.9m,
                    Weight = 87.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 298,
                    Name = "Henrique Souza Mendonça",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 06, 21),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 97,
                    Height = 1.98m,
                    Weight = 93.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },
                new Player
                {
                    Id = 299,
                    Name = "Lucas Pedrosa Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 02, 03),
                    Position = Position.Zagueiro,
                    ShirtNumber = 83,
                    Height = 1.88m,
                    Weight = 96.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 10
                },

#endregion
                //Jogadores Id11
#region
                new Player
                {
                    Id = 300,
                    Name = "Arthur Camacho Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 12, 02),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 96,
                    Height = 1.69m,
                    Weight = 77.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 301,
                    Name = "Samuel Torres Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 10, 09),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 40,
                    Height = 1.82m,
                    Weight = 81.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 302,
                    Name = "Benjamin Sá Souza",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 04, 04),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 14,
                    Height = 1.83m,
                    Weight = 75.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 303,
                    Name = "Ravi Lins Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 09, 13),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 79,
                    Height = 1.86m,
                    Weight = 86.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 304,
                    Name = "Henry Silva Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 09),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 67,
                    Height = 1.85m,
                    Weight = 95.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 305,
                    Name = "Théo Guedes Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 03, 31),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 83,
                    Height = 1.66m,
                    Weight = 75.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 306,
                    Name = "Ravi Faria Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 08, 09),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 64,
                    Height = 1.86m,
                    Weight = 84.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 307,
                    Name = "Henrique Domingues Oliveira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 02, 05),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 17,
                    Height = 1.9m,
                    Weight = 69.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 308,
                    Name = "Joaquim Rodrigues Tavares",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2005, 06, 18),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 33,
                    Height = 1.75m,
                    Weight = 66.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 309,
                    Name = "Lucca Teixeira Gonçalves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 12, 08),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 34,
                    Height = 1.96m,
                    Weight = 87.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 310,
                    Name = "Lorenzo Ramos Figueiredo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 02, 28),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 15,
                    Height = 1.86m,
                    Weight = 60.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 311,
                    Name = "Arthur Ribeiro Veiga",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 06, 03),
                    Position = Position.Ponta,
                    ShirtNumber = 64,
                    Height = 1.78m,
                    Weight = 98.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 312,
                    Name = "Arthur Gomes Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 02, 06),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 79,
                    Height = 1.8m,
                    Weight = 79.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 313,
                    Name = "Théo Franco Caldeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 04, 22),
                    Position = Position.Zagueiro,
                    ShirtNumber = 4,
                    Height = 1.68m,
                    Weight = 98.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 314,
                    Name = "Levi Veiga Melgaço",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 06, 01),
                    Position = Position.Ponta,
                    ShirtNumber = 56,
                    Height = 1.61m,
                    Weight = 60.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 315,
                    Name = "Isaac Lopes Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 01, 16),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 52,
                    Height = 1.77m,
                    Weight = 70.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 316,
                    Name = "Anthony Loureiro Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 01, 06),
                    Position = Position.LateralDireito,
                    ShirtNumber = 60,
                    Height = 1.66m,
                    Weight = 99.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 317,
                    Name = "Levi Gouveia Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 07, 20),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 14,
                    Height = 1.67m,
                    Weight = 72.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 318,
                    Name = "Gael Melgaço Bernardes​",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 12, 11),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 59,
                    Height = 1.63m,
                    Weight = 60.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 319,
                    Name = "Lucca Vaz Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 07, 25),
                    Position = Position.AlaDireito,
                    ShirtNumber = 45,
                    Height = 1.92m,
                    Weight = 81.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 320,
                    Name = "Anthony Brito Rios",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 11, 18),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 54,
                    Height = 1.76m,
                    Weight = 69.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 321,
                    Name = "Anthony Antunes Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 09, 28),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 96,
                    Height = 1.66m,
                    Weight = 68.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 322,
                    Name = "Pedro Coimbra Quintana",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 11, 30),
                    Position = Position.AlaDireito,
                    ShirtNumber = 41,
                    Height = 1.88m,
                    Weight = 81.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 323,
                    Name = "João Miguel Faria Leite",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 23),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 3,
                    Height = 1.94m,
                    Weight = 66.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 324,
                    Name = "Murilo Domingues Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 11, 03),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 93,
                    Height = 1.96m,
                    Weight = 82.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 325,
                    Name = "Benjamin Reis Brito",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 12, 31),
                    Position = Position.Volante,
                    ShirtNumber = 50,
                    Height = 1.84m,
                    Weight = 62.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 326,
                    Name = "Noah Caldeira Teles",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 01, 16),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 93,
                    Height = 1.94m,
                    Weight = 82.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 11
                },
                new Player
                {
                    Id = 327,
                    Name = "Nicolas Saldanha Botelho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 08, 14),
                    Position = Position.Goleiro,
                    ShirtNumber = 14,
                    Height = 1.94m,
                    Weight = 84.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 11
                },
                new Player
                {
                    Id = 328,
                    Name = "João Miguel Cunha Gonçalves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 02, 19),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 93,
                    Height = 1.9m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },
                new Player
                {
                    Id = 329,
                    Name = "Arthur Batista Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 06, 04),
                    Position = Position.Volante,
                    ShirtNumber = 34,
                    Height = 1.82m,
                    Weight = 68.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 11
                },

#endregion
                //Jogadores Id12
#region
                new Player
                {
                    Id = 330,
                    Name = "Benício Pedrosa Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 04, 11),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 99,
                    Height = 1.8m,
                    Weight = 67.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 331,
                    Name = "Ravi Lins Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 07, 23),
                    Position = Position.LateralDireito,
                    ShirtNumber = 62,
                    Height = 1.7m,
                    Weight = 77.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 332,
                    Name = "Murilo Martins Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 08, 05),
                    Position = Position.AlaDireito,
                    ShirtNumber = 8,
                    Height = 1.6m,
                    Weight = 71.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 333,
                    Name = "Ravi Marques Franco",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1990, 04, 30),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 82,
                    Height = 1.8m,
                    Weight = 78.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 334,
                    Name = "Joaquim Antunes Batista",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 11, 09),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 93,
                    Height = 1.81m,
                    Weight = 61.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 335,
                    Name = "Matheus Andrade Mendes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 05, 05),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 23,
                    Height = 1.76m,
                    Weight = 97.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 336,
                    Name = "Samuel Barreto Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 09, 09),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 84,
                    Height = 1.74m,
                    Weight = 89.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 337,
                    Name = "Isaac Brito Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 31),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 5,
                    Height = 1.64m,
                    Weight = 76.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 338,
                    Name = "Noah Pires Caldeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 11, 06),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 13,
                    Height = 1.87m,
                    Weight = 72.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 339,
                    Name = "Miguel Camacho Cabral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 07, 22),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 82,
                    Height = 1.98m,
                    Weight = 83.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 340,
                    Name = "Anthony Fonseca Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 08, 11),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 50,
                    Height = 1.68m,
                    Weight = 92.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 341,
                    Name = "Joaquim Santos Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 10, 03),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 28,
                    Height = 1.65m,
                    Weight = 98.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 342,
                    Name = "Lucca Tavares Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 04, 06),
                    Position = Position.Volante,
                    ShirtNumber = 59,
                    Height = 1.7m,
                    Weight = 65.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 343,
                    Name = "Lucca Gouveia Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 09, 09),
                    Position = Position.Ponta,
                    ShirtNumber = 92,
                    Height = 1.87m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 344,
                    Name = "Noah Menezes Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 04, 25),
                    Position = Position.Zagueiro,
                    ShirtNumber = 69,
                    Height = 1.92m,
                    Weight = 99.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 345,
                    Name = "Noah Menezes Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 04, 25),
                    Position = Position.Zagueiro,
                    ShirtNumber = 69,
                    Height = 1.92m,
                    Weight = 99.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 346,
                    Name = "Ravi Pedrosa Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 01, 05),
                    Position = Position.LateralDireito,
                    ShirtNumber = 82,
                    Height = 1.8m,
                    Weight = 61.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 347,
                    Name = "Samuel Rego Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 12, 17),
                    Position = Position.Volante,
                    ShirtNumber = 83,
                    Height = 1.78m,
                    Weight = 63.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 348,
                    Name = "Lucas Prado Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 10, 14),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 27,
                    Height = 1.98m,
                    Weight = 70.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 349,
                    Name = "Noah Marinho Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 01, 29),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 6,
                    Height = 1.84m,
                    Weight = 73.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 350,
                    Name = "Matheus Quaresma Barreto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 11, 13),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 48,
                    Height = 1.98m,
                    Weight = 82.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 351,
                    Name = "Isaac Mendes Teles",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 12, 20),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 69,
                    Height = 1.79m,
                    Weight = 82.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 352,
                    Name = "Bernardo Figueiredo Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 09, 29),
                    Position = Position.Zagueiro,
                    ShirtNumber = 60,
                    Height = 1.95m,
                    Weight = 94.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 353,
                    Name = "Isaac Furtado Reis",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 06, 20),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 12,
                    Height = 1.64m,
                    Weight = 87.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },
                new Player
                {
                    Id = 354,
                    Name = "Noah Rios Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 06, 24),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 49,
                    Height = 1.8m,
                    Weight = 94.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 355,
                    Name = "Davi Melo Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 09, 23),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 8,
                    Height = 1.61m,
                    Weight = 85.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 12
                },
                new Player
                {
                    Id = 356,
                    Name = "Heitor Pedrosa Rego",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 01, 08),
                    Position = Position.LateralDireito,
                    ShirtNumber = 53,
                    Height = 1.87m,
                    Weight = 77.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 357,
                    Name = "Joaquim Duarte Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 11, 22),
                    Position = Position.Zagueiro,
                    ShirtNumber = 67,
                    Height = 1.68m,
                    Weight = 67.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 358,
                    Name = "Davi Costa Marques",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1995, 03, 13),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 64,
                    Height = 1.62m,
                    Weight = 81.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 12
                },
                new Player
                {
                    Id = 359,
                    Name = "Noah Guedes Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 10, 28),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 63,
                    Height = 1.91m,
                    Weight = 82.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 12
                },

#endregion
                //Jogadores Id13
#region
                new Player
                {
                    Id = 360,
                    Name = "Rafael Martins Rios",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 04, 01),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 41,
                    Height = 1.79m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 361,
                    Name = "Henrique Gonçalves Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 11, 17),
                    Position = Position.LateralDireito,
                    ShirtNumber = 79,
                    Height = 1.68m,
                    Weight = 77.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 362,
                    Name = "Lorenzo Pires Duarte",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 05, 11),
                    Position = Position.Ponta,
                    ShirtNumber = 28,
                    Height = 1.83m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 363,
                    Name = "João Miguel Vargas Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 18),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 16,
                    Height = 1.62m,
                    Weight = 64.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 364,
                    Name = "Nicolas Vieira Caldeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 04, 30),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 91,
                    Height = 1.75m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 365,
                    Name = "Henry Marques Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 10, 06),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 36,
                    Height = 1.88m,
                    Weight = 65.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 366,
                    Name = "Joaquim Godinho Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 12, 24),
                    Position = Position.LateralDireito,
                    ShirtNumber = 79,
                    Height = 1.64m,
                    Weight = 79.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 367,
                    Name = "Isaac Godinho Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 11, 12),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 59,
                    Height = 1.84m,
                    Weight = 99.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 368,
                    Name = "Matheus Quaresma Marinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 11, 22),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.66m,
                    Weight = 78.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 369,
                    Name = "Matheus Quaresma Marinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 11, 22),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.66m,
                    Weight = 78.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 370,
                    Name = "Davi Lopes Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 06, 16),
                    Position = Position.AlaDireito,
                    ShirtNumber = 26,
                    Height = 1.98m,
                    Weight = 95.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 371,
                    Name = "Pedro Alves Melgaço",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 03, 24),
                    Position = Position.Zagueiro,
                    ShirtNumber = 44,
                    Height = 1.83m,
                    Weight = 74.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 372,
                    Name = "Noah Azevedo Rego",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 02, 03),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 73,
                    Height = 1.77m,
                    Weight = 91.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 373,
                    Name = "Henry Machado Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 06, 14),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 61,
                    Height = 1.97m,
                    Weight = 69.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 374,
                    Name = "Henrique Machado Brito",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 07, 22),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 48,
                    Height = 1.67m,
                    Weight = 70.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 375,
                    Name = "Ravi Azevedo Leite",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 11, 28),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 42,
                    Height = 1.71m,
                    Weight = 69.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 376,
                    Name = "Gael Quaresma Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 07, 29),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 48,
                    Height = 1.86m,
                    Weight = 62.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 377,
                    Name = "Samuel Moreira Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 03, 10),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 77,
                    Height = 1.88m,
                    Weight = 99.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 378,
                    Name = "Gabriel Caldeira Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 12, 13),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 98,
                    Height = 1.79m,
                    Weight = 90.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 379,
                    Name = "Samuel Ferreira Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 07, 26),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 43,
                    Height = 1.67m,
                    Weight = 89.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 380,
                    Name = "Joaquim Azevedo Faria",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 10, 21),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 54,
                    Height = 1.63m,
                    Weight = 69.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 381,
                    Name = "Lucas Correia Martins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 09, 09),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 38,
                    Height = 1.85m,
                    Weight = 92.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 382,
                    Name = "Arthur Amaral Figueiredo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 10, 06),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 90,
                    Height = 1.73m,
                    Weight = 73.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 383,
                    Name = "Murilo Caldeira Pedrosa",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1983, 01, 31),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 2,
                    Height = 1.81m,
                    Weight = 90.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 13
                },
                new Player
                {
                    Id = 384,
                    Name = "Bernardo Amaral Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 09, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 55,
                    Height = 1.72m,
                    Weight = 77.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 385,
                    Name = "Levi Caldeira Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 04, 25),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 33,
                    Height = 1.87m,
                    Weight = 80.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },
                new Player
                {
                    Id = 386,
                    Name = "Samuel Faria Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 10, 12),
                    Position = Position.Ponta,
                    ShirtNumber = 94,
                    Height = 1.78m,
                    Weight = 70.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 387,
                    Name = "Pedro Nogueira Leite",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 12, 30),
                    Position = Position.Goleiro,
                    ShirtNumber = 9,
                    Height = 1.83m,
                    Weight = 72.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 388,
                    Name = "Ravi Sá Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 07, 05),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 98,
                    Height = 1.93m,
                    Weight = 84.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 13
                },
                new Player
                {
                    Id = 389,
                    Name = "Gui Brito Veiga",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 05, 09),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 43,
                    Height = 1.68m,
                    Weight = 99.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 13
                },

#endregion
                //Jogadores Id14
#region
                new Player
                {
                    Id = 390,
                    Name = "Benício Salgado Antunes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 12, 02),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 67,
                    Height = 1.92m,
                    Weight = 78.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 391,
                    Name = "Gabriel Oliveira Teles",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 08, 03),
                    Position = Position.Zagueiro,
                    ShirtNumber = 28,
                    Height = 1.72m,
                    Weight = 62.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 392,
                    Name = "Benjamin Barbosa Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 02, 07),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 77,
                    Height = 1.82m,
                    Weight = 61.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 393,
                    Name = "Rafael Gomes Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 07, 03),
                    Position = Position.AlaDireito,
                    ShirtNumber = 51,
                    Height = 1.61m,
                    Weight = 61.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 394,
                    Name = "João Miguel Pinto Álvares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 10, 23),
                    Position = Position.LateralDireito,
                    ShirtNumber = 19,
                    Height = 1.98m,
                    Weight = 70.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 395,
                    Name = "Murilo Santos Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 06, 16),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 28,
                    Height = 1.77m,
                    Weight = 93.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 396,
                    Name = "Lorenzo Vargas Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 05, 09),
                    Position = Position.Volante,
                    ShirtNumber = 7,
                    Height = 1.85m,
                    Weight = 97.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 397,
                    Name = "Miguel Vieira Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 12, 09),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 59,
                    Height = 1.69m,
                    Weight = 67.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 398,
                    Name = "Gui Fonseca Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 10, 12),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 22,
                    Height = 1.72m,
                    Weight = 64.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 399,
                    Name = "Nicolas Saldanha Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 04, 12),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 94,
                    Height = 1.61m,
                    Weight = 63.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 400,
                    Name = "Lucca Azevedo Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 02, 05),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 25,
                    Height = 1.67m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 401,
                    Name = "Rafael Correia Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 03, 17),
                    Position = Position.Volante,
                    ShirtNumber = 97,
                    Height = 1.72m,
                    Weight = 80.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 402,
                    Name = "Samuel Brito Leite",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 11, 02),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 55,
                    Height = 1.82m,
                    Weight = 72.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 403,
                    Name = "Benjamin Fernandes Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 12, 29),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 3,
                    Height = 1.86m,
                    Weight = 68.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 404,
                    Name = "Matheus Coimbra Mendes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 07, 28),
                    Position = Position.Goleiro,
                    ShirtNumber = 93,
                    Height = 1.69m,
                    Weight = 77.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 405,
                    Name = "Davi Cabral Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 02, 07),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 98,
                    Height = 1.82m,
                    Weight = 91.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 406,
                    Name = "Benjamin Fonseca Camacho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 09, 25),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 88,
                    Height = 1.7m,
                    Weight = 60.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 407,
                    Name = "Gabriel Prado Gomes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 02, 03),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 1,
                    Height = 1.72m,
                    Weight = 74.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 14
                },
                new Player
                {
                    Id = 408,
                    Name = "Pedro Menezes Cabral",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1997, 08, 12),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 54,
                    Height = 1.71m,
                    Weight = 85.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 409,
                    Name = "Heitor Franco Pinheiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 04, 06),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 28,
                    Height = 1.83m,
                    Weight = 89.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 410,
                    Name = "Pedro Pacheco Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 05, 12),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 2,
                    Height = 1.65m,
                    Weight = 92.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 411,
                    Name = "Miguel Torres Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 07, 01),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 40,
                    Height = 1.86m,
                    Weight = 76.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 412,
                    Name = "Samuel Medeiros Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 03, 27),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 41,
                    Height = 1.84m,
                    Weight = 93.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 413,
                    Name = "Joaquim Vargas Alves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 01, 19),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 70,
                    Height = 1.98m,
                    Weight = 84.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 414,
                    Name = "João Miguel Faria Camacho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 13),
                    Position = Position.Goleiro,
                    ShirtNumber = 23,
                    Height = 1.64m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 415,
                    Name = "Noah Fonseca Moreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 02, 04),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 85,
                    Height = 1.83m,
                    Weight = 80.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 416,
                    Name = "Arthur Marques Pedrosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 02, 09),
                    Position = Position.Goleiro,
                    ShirtNumber = 77,
                    Height = 1.84m,
                    Weight = 69.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 417,
                    Name = "Lorenzo Guedes Faria",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 07, 10),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 88,
                    Height = 1.99m,
                    Weight = 90.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },
                new Player
                {
                    Id = 418,
                    Name = "Henry Cunha Pimentel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 04, 06),
                    Position = Position.Volante,
                    ShirtNumber = 27,
                    Height = 1.95m,
                    Weight = 65.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 14
                },
                new Player
                {
                    Id = 419,
                    Name = "Henry Almeida Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 02, 28),
                    Position = Position.LateralDireito,
                    ShirtNumber = 8,
                    Height = 1.94m,
                    Weight = 66.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 14
                },

#endregion
                //Jogadores Id15
#region
                new Player
                {
                    Id = 420,
                    Name = "João Miguel Ramos Peixoto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 09, 12),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 66,
                    Height = 1.98m,
                    Weight = 79.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 421,
                    Name = "Théo Batista Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 07, 23),
                    Position = Position.Volante,
                    ShirtNumber = 33,
                    Height = 1.62m,
                    Weight = 88.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 422,
                    Name = "Benício Pereira Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 12, 31),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 5,
                    Height = 1.7m,
                    Weight = 72.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 423,
                    Name = "Benício Pereira Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 12, 31),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 5,
                    Height = 1.7m,
                    Weight = 72.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 424,
                    Name = "Davi Martins Fonseca",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 06, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 77,
                    Height = 1.76m,
                    Weight = 62.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 425,
                    Name = "Arthur Cardoso Nogueira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 07, 17),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 43,
                    Height = 1.89m,
                    Weight = 67.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 426,
                    Name = "Samuel Menezes Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 05, 31),
                    Position = Position.Zagueiro,
                    ShirtNumber = 29,
                    Height = 1.99m,
                    Weight = 76.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 427,
                    Name = "Pedro Coimbra Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 11, 03),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 7,
                    Height = 1.87m,
                    Weight = 95.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 428,
                    Name = "Heitor Pinheiro Coimbra",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 05),
                    Position = Position.Zagueiro,
                    ShirtNumber = 89,
                    Height = 1.73m,
                    Weight = 83.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 429,
                    Name = "Théo Torres Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 02),
                    Position = Position.Goleiro,
                    ShirtNumber = 81,
                    Height = 1.62m,
                    Weight = 88.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 430,
                    Name = "Henry Loureiro Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 10, 13),
                    Position = Position.Zagueiro,
                    ShirtNumber = 38,
                    Height = 1.64m,
                    Weight = 86.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 431,
                    Name = "Rafael Mendes Marinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 12, 15),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 34,
                    Height = 1.62m,
                    Weight = 85.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 432,
                    Name = "Davi Gonçalves Pinheiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 02, 12),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 9,
                    Height = 1.85m,
                    Weight = 72.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 433,
                    Name = "Lorenzo Ramos Medeiros",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1995, 08, 27),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 55,
                    Height = 1.9m,
                    Weight = 72.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 434,
                    Name = "Ravi Figueiredo Torres",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 02, 05),
                    Position = Position.Volante,
                    ShirtNumber = 30,
                    Height = 1.77m,
                    Weight = 97.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 435,
                    Name = "Nicolas Gouveia Teles",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 03, 15),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 87,
                    Height = 1.82m,
                    Weight = 93.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 436,
                    Name = "Lorenzo Rios Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 06, 30),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 69,
                    Height = 1.6m,
                    Weight = 91.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 437,
                    Name = "Henrique Almeida Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 07, 17),
                    Position = Position.AlaDireito,
                    ShirtNumber = 31,
                    Height = 1.68m,
                    Weight = 79.3m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 438,
                    Name = "Levi Fernandes Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 02, 12),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 56,
                    Height = 1.6m,
                    Weight = 86.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 439,
                    Name = "Lorenzo Botelho Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 01, 07),
                    Position = Position.Zagueiro,
                    ShirtNumber = 23,
                    Height = 1.94m,
                    Weight = 88.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 440,
                    Name = "Gabriel Amaral Ferreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 07, 11),
                    Position = Position.Volante,
                    ShirtNumber = 32,
                    Height = 1.8m,
                    Weight = 82.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 441,
                    Name = "Heitor Henriques Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 04, 20),
                    Position = Position.AlaDireito,
                    ShirtNumber = 15,
                    Height = 1.7m,
                    Weight = 63.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 442,
                    Name = "Bernardo Tavares Rego",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 03, 18),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 21,
                    Height = 1.9m,
                    Weight = 60.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 443,
                    Name = "Levi Brito Álvares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 10, 03),
                    Position = Position.Goleiro,
                    ShirtNumber = 79,
                    Height = 1.83m,
                    Weight = 69.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 444,
                    Name = "Gui Melo Mendes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 02, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 72,
                    Height = 1.66m,
                    Weight = 86.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },
                new Player
                {
                    Id = 445,
                    Name = "Gabriel Batista Silva",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 30),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 85,
                    Height = 1.92m,
                    Weight = 83.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 446,
                    Name = "Gui Vieira Godinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 04, 02),
                    Position = Position.Ponta,
                    ShirtNumber = 52,
                    Height = 1.85m,
                    Weight = 98.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 447,
                    Name = "Henrique Costa Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 01, 17),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 81,
                    Height = 1.7m,
                    Weight = 61.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 15
                },
                new Player
                {
                    Id = 448,
                    Name = "João Miguel Saldanha Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 07, 21),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 76,
                    Height = 1.72m,
                    Weight = 80.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 15
                },
                new Player
                {
                    Id = 449,
                    Name = "Ravi Moreira Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 02, 11),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 30,
                    Height = 1.66m,
                    Weight = 90.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 15
                },

#endregion
                //Jogadores Id16
#region
                new Player
                {
                    Id = 450,
                    Name = "Rafael Rodrigues Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 05, 02),
                    Position = Position.AlaDireito,
                    ShirtNumber = 53,
                    Height = 1.67m,
                    Weight = 77.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 451,
                    Name = "Arthur Vargas Camacho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 09, 10),
                    Position = Position.Volante,
                    ShirtNumber = 33,
                    Height = 1.91m,
                    Weight = 70.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 452,
                    Name = "Gui Gouveia Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 04, 18),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 81,
                    Height = 1.81m,
                    Weight = 80.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 453,
                    Name = "Gui Domingues Camacho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 05, 12),
                    Position = Position.Ponta,
                    ShirtNumber = 74,
                    Height = 1.96m,
                    Weight = 84.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 454,
                    Name = "Matheus Saldanha Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 03, 04),
                    Position = Position.LateralDireito,
                    ShirtNumber = 8,
                    Height = 1.99m,
                    Weight = 98.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 455,
                    Name = "Gui Oliveira Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 06, 20),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 27,
                    Height = 1.62m,
                    Weight = 60.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 456,
                    Name = "Gael Sales Medeiros",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1988, 09, 08),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 34,
                    Height = 1.6m,
                    Weight = 61.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 457,
                    Name = "Benjamin Pedrosa Machado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 01),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 35,
                    Height = 1.77m,
                    Weight = 72.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 458,
                    Name = "Samuel Teles Brito",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 11, 03),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 76,
                    Height = 1.87m,
                    Weight = 72.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 459,
                    Name = "Henry Oliveira Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 27),
                    Position = Position.AlaDireito,
                    ShirtNumber = 95,
                    Height = 1.77m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 460,
                    Name = "Lorenzo Loureiro Araújo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 11),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 91,
                    Height = 1.64m,
                    Weight = 84.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 461,
                    Name = "Nicolas Marinho Cunha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 12, 25),
                    Position = Position.Volante,
                    ShirtNumber = 94,
                    Height = 1.67m,
                    Weight = 78.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Name = "Benício Rocha Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 03, 02),
                    Position = Position.Ponta,
                    ShirtNumber = 10,
                    Height = 1.74m,
                    Weight = 82.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 463,
                    Name = "Nicolas Melgaço Medeiros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 11, 26),
                    Position = Position.Zagueiro,
                    ShirtNumber = 13,
                    Height = 1.83m,
                    Weight = 93.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 464,
                    Name = "Davi Azevedo Domingues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 05, 19),
                    Position = Position.LateralDireito,
                    ShirtNumber = 41,
                    Height = 1.79m,
                    Weight = 94.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 465,
                    Name = "Benjamin Santos Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 08, 31),
                    Position = Position.LateralDireito,
                    ShirtNumber = 72,
                    Height = 1.99m,
                    Weight = 99.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 466,
                    Name = "Isaac Leite Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 02, 18),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 62,
                    Height = 1.72m,
                    Weight = 64.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 467,
                    Name = "Henry Camacho Nogueira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 05, 03),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 99,
                    Height = 1.73m,
                    Weight = 81.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 468,
                    Name = "Miguel Fernandes Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 08, 26),
                    Position = Position.Ponta,
                    ShirtNumber = 83,
                    Height = 1.73m,
                    Weight = 75.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 469,
                    Name = "Arthur Cabral Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 03, 10),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 40,
                    Height = 1.7m,
                    Weight = 74.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 470,
                    Name = "Joaquim Brito Ramos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 03, 22),
                    Position = Position.Ponta,
                    ShirtNumber = 66,
                    Height = 1.6m,
                    Weight = 92.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 471,
                    Name = "Benjamin Melo Cabral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 10, 27),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 11,
                    Height = 1.66m,
                    Weight = 75.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 472,
                    Name = "Miguel Vaz Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 19),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 31,
                    Height = 1.82m,
                    Weight = 70.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Name = "Nicolas Cunha Pires",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 11, 17),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 73,
                    Height = 1.79m,
                    Weight = 77.9m,
                    MainFeet = MainFeet.Direito,

                    TeamId = 16
                },
                new Player
                {
                    Id = 474,
                    Name = "Samuel Quaresma Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 07, 22),
                    Position = Position.LateralDireito,
                    ShirtNumber = 69,
                    Height = 1.85m,
                    Weight = 96.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 16
                },
                new Player
                {
                    Id = 475,
                    Name = "Ravi Rego Almeida",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 12, 04),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 74,
                    Height = 1.99m,
                    Weight = 69.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 16
                },
                new Player
                {
                    Id = 476,
                    Name = "Arthur Fernandes Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 01, 13),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 82,
                    Height = 1.89m,
                    Weight = 75.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 477,
                    Name = "Jogador2",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2021, 02, 02),
                    Position = Position.Goleiro,
                    ShirtNumber = 12,
                    Height = 1.30m,
                    Weight = 30.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 478,
                    Name = "Arthur Fernandes Rocha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 01, 13),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 82,
                    Height = 1.89m,
                    Weight = 75.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },
                new Player
                {
                    Id = 479,
                    Name = "Joaquim Peixoto Álvares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 02, 12),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 88,
                    Height = 1.64m,
                    Weight = 77.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 16
                },

#endregion
                //Jogadores Id17
#region
                new Player
                {
                    Id = 480,
                    Name = "Nicolas Costa Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 01, 09),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 45,
                    Height = 1.9m,
                    Weight = 69.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 481,
                    Name = "Anthony Pedrosa Torres",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2001, 05, 24),
                    Position = Position.Zagueiro,
                    ShirtNumber = 55,
                    Height = 1.83m,
                    Weight = 60.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 482,
                    Name = "João Miguel Melo Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 12, 23),
                    Position = Position.Volante,
                    ShirtNumber = 81,
                    Height = 1.79m,
                    Weight = 76.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 483,
                    Name = "Bernardo Marinho Álvares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 01, 16),
                    Position = Position.Goleiro,
                    ShirtNumber = 59,
                    Height = 1.97m,
                    Weight = 62.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 484,
                    Name = "Benício Rodrigues Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 03, 21),
                    Position = Position.Zagueiro,
                    ShirtNumber = 65,
                    Height = 1.62m,
                    Weight = 77.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 485,
                    Name = "Henrique Leite Quintana",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 01, 22),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 3,
                    Height = 1.92m,
                    Weight = 66.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 486,
                    Name = "Gabriel Cardoso Peixoto",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 12, 30),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 20,
                    Height = 1.79m,
                    Weight = 79.4m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 487,
                    Name = "João Miguel Lima Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 08, 27),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 94,
                    Height = 1.98m,
                    Weight = 94.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 488,
                    Name = "Lucas Cunha Saldanha",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 07, 08),
                    Position = Position.Goleiro,
                    ShirtNumber = 30,
                    Height = 1.93m,
                    Weight = 70.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 489,
                    Name = "Lucas Lima Vargas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 03, 16),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 92,
                    Height = 1.83m,
                    Weight = 87.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 490,
                    Name = "Samuel Marques Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 11),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 17,
                    Height = 1.7m,
                    Weight = 66.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 491,
                    Name = "Henrique Freitas Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 05, 03),
                    Position = Position.LateralDireito,
                    ShirtNumber = 7,
                    Height = 1.61m,
                    Weight = 67.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 492,
                    Name = "Lucas Menezes Miranda",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 02, 13),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 56,
                    Height = 1.97m,
                    Weight = 98.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 493,
                    Name = "Murilo Ferreira Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 02, 20),
                    Position = Position.Volante,
                    ShirtNumber = 90,
                    Height = 1.79m,
                    Weight = 76.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 494,
                    Name = "Théo Vieira Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 15),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 19,
                    Height = 1.73m,
                    Weight = 62.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 495,
                    Name = "Théo Vieira Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 01, 15),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 19,
                    Height = 1.73m,
                    Weight = 62.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 496,
                    Name = "Benjamin Pacheco Pinheiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 03, 03),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 49,
                    Height = 1.63m,
                    Weight = 99.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 497,
                    Name = "Gael Loureiro Costa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 03, 06),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 53,
                    Height = 1.82m,
                    Weight = 62.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 498,
                    Name = "Henry Oliveira Barros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 10, 11),
                    Position = Position.Zagueiro,
                    ShirtNumber = 83,
                    Height = 1.92m,
                    Weight = 63.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 499,
                    Name = "Matheus Rios Costa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 05),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 43,
                    Height = 1.99m,
                    Weight = 71.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 500,
                    Name = "Gui Rodrigues Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 03, 19),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 38,
                    Height = 1.79m,
                    Weight = 92.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 501,
                    Name = "Ravi Teixeira Veiga",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 11, 18),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 86,
                    Height = 1.72m,
                    Weight = 66.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 502,
                    Name = "Arthur Aguiar Castro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 01, 30),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 42,
                    Height = 1.69m,
                    Weight = 64.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 503,
                    Name = "João Miguel Camacho Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 04, 26),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 32,
                    Height = 1.78m,
                    Weight = 69.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 504,
                    Name = "Levi Furtado Rodrigues",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1984, 12, 14),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 72,
                    Height = 1.69m,
                    Weight = 63.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 505,
                    Name = "Lorenzo Melgaço Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 03, 02),
                    Position = Position.Volante,
                    ShirtNumber = 52,
                    Height = 1.9m,
                    Weight = 73.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 506,
                    Name = "Noah Antunes Mendonça",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 08, 18),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 42,
                    Height = 1.94m,
                    Weight = 69.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },
                new Player
                {
                    Id = 507,
                    Name = "Benjamin Tavares Vargas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 04, 28),
                    Position = Position.Zagueiro,
                    ShirtNumber = 59,
                    Height = 1.62m,
                    Weight = 63.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 17
                },
                new Player
                {
                    Id = 508,
                    Name = "Nicolas Melo Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2002, 05, 16),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 15,
                    Height = 1.86m,
                    Weight = 66.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 17
                },
                new Player
                {
                    Id = 509,
                    Name = "Isaac Botelho Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2001, 03, 23),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.72m,
                    Weight = 68.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 17
                },

#endregion
                //Jogadores Id18
#region
                new Player
                {
                    Id = 510,
                    Name = "Heitor Batista Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 07, 02),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.62m,
                    Weight = 98.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 511,
                    Name = "Miguel Barreto Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1998, 01, 06),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 79,
                    Height = 1.64m,
                    Weight = 64.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 512,
                    Name = "Pedro Souza Quintana",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 01, 24),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 94,
                    Height = 1.74m,
                    Weight = 79.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 513,
                    Name = "Gael Pires Mota",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 23),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 63,
                    Height = 1.6m,
                    Weight = 98.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 514,
                    Name = "Théo Torres Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 10, 28),
                    Position = Position.Goleiro,
                    ShirtNumber = 24,
                    Height = 1.61m,
                    Weight = 66.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 515,
                    Name = "Lucas Teixeira Azevedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 06, 05),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 3,
                    Height = 1.99m,
                    Weight = 83.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 516,
                    Name = "Bernardo Azevedo Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 04, 16),
                    Position = Position.Ponta,
                    ShirtNumber = 64,
                    Height = 1.67m,
                    Weight = 82.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 517,
                    Name = "Noah Domingues Rios",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 12, 16),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 17,
                    Height = 1.61m,
                    Weight = 66.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 518,
                    Name = "Levi Cardoso Moreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 08, 06),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 96,
                    Height = 1.99m,
                    Weight = 66.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 519,
                    Name = "Lucas Vieira Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 02, 07),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 76,
                    Height = 1.66m,
                    Weight = 78.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 520,
                    Name = "Matheus Souza Franco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 08, 02),
                    Position = Position.AlaDireito,
                    ShirtNumber = 45,
                    Height = 1.68m,
                    Weight = 83.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 521,
                    Name = "Nicolas Brito Melo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 01, 09),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 66,
                    Height = 1.62m,
                    Weight = 68.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 522,
                    Name = "Benjamin Teles Neves",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 10, 17),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 62,
                    Height = 1.92m,
                    Weight = 76.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 523,
                    Name = "Gabriel Vaz Franco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 08, 07),
                    Position = Position.AlaDireito,
                    ShirtNumber = 58,
                    Height = 1.62m,
                    Weight = 65.5m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 524,
                    Name = "Gui Prado Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 05, 18),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 85,
                    Height = 1.74m,
                    Weight = 82.8m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 525,
                    Name = "Davi Rocha Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 04, 11),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 15,
                    Height = 1.94m,
                    Weight = 71.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 526,
                    Name = "Levi Melo Freitas",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 12, 25),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 63,
                    Height = 1.98m,
                    Weight = 95.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 527,
                    Name = "Théo Teixeira Costa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 08, 10),
                    Position = Position.LateralDireito,
                    ShirtNumber = 40,
                    Height = 1.81m,
                    Weight = 91.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 528,
                    Name = "Benjamin Rocha Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 11, 16),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 17,
                    Height = 1.8m,
                    Weight = 63.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 529,
                    Name = "Lucca Lopes Mota",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1990, 11, 18),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 25,
                    Height = 1.94m,
                    Weight = 80.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 530,
                    Name = "Noah Menezes Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 10, 02),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 83,
                    Height = 1.88m,
                    Weight = 91.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 531,
                    Name = "Gael Freitas Antunes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 06, 06),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 14,
                    Height = 1.74m,
                    Weight = 74.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 532,
                    Name = "Lorenzo Freitas Cardoso",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 08, 20),
                    Position = Position.Volante,
                    ShirtNumber = 83,
                    Height = 1.95m,
                    Weight = 89.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 533,
                    Name = "Lucas Peixoto Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 12, 31),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 51,
                    Height = 1.82m,
                    Weight = 79.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 534,
                    Name = "Murilo Almeida Mendes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 01, 13),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 79,
                    Height = 1.72m,
                    Weight = 93.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 535,
                    Name = "Nicolas Barros Sales",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 10, 29),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 5,
                    Height = 1.79m,
                    Weight = 82.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 536,
                    Name = "Samuel Gouveia Henriques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 03, 23),
                    Position = Position.Goleiro,
                    ShirtNumber = 7,
                    Height = 1.93m,
                    Weight = 75.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 18
                },
                new Player
                {
                    Id = 537,
                    Name = "Samuel Veiga Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 09, 26),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 22,
                    Height = 1.78m,
                    Weight = 91.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },
                new Player
                {
                    Id = 538,
                    Name = "Lucca Costa Castro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 04, 15),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 59,
                    Height = 1.81m,
                    Weight = 70.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 18
                },
                new Player
                {
                    Id = 539,
                    Name = "Gabriel Antunes Santos",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 09, 19),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 27,
                    Height = 1.62m,
                    Weight = 79.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 18
                },

#endregion
                //Jogadores Id19
#region
                new Player
                {
                    Id = 540,
                    Name = "Arthur Tavares Caldeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 03, 03),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 2,
                    Height = 1.84m,
                    Weight = 82.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 19
                },
                new Player
                {
                    Id = 541,
                    Name = "Joaquim Peixoto Ferreira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 08, 20),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 29,
                    Height = 1.62m,
                    Weight = 77.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 542,
                    Name = "Henry Machado Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 01, 16),
                    Position = Position.LateralDireito,
                    ShirtNumber = 83,
                    Height = 1.6m,
                    Weight = 95.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 543,
                    Name = "Isaac Marinho Gouveia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 01, 09),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 89,
                    Height = 1.96m,
                    Weight = 71.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 544,
                    Name = "Davi Melgaço Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 03, 01),
                    Position = Position.Volante,
                    ShirtNumber = 83,
                    Height = 1.79m,
                    Weight = 89.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 545,
                    Name = "Heitor Melgaço Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 04, 08),
                    Position = Position.Goleiro,
                    ShirtNumber = 95,
                    Height = 1.78m,
                    Weight = 80.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 546,
                    Name = "Noah Vieira Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1999, 12, 08),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 18,
                    Height = 1.77m,
                    Weight = 92.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 19
                },
                new Player
                {
                    Id = 547,
                    Name = "Rafael Quaresma Correia",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 06, 16),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 51,
                    Height = 1.63m,
                    Weight = 86.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 548,
                    Name = "Henrique Gonçalves Pimentel",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 05, 27),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 37,
                    Height = 1.61m,
                    Weight = 90.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 549,
                    Name = "Benjamin Bernardes​ Medeiros",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1994, 07, 19),
                    Position = Position.Ponta,
                    ShirtNumber = 73,
                    Height = 1.72m,
                    Weight = 63.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 550,
                    Name = "Gabriel Araújo Caldeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 01, 13),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 47,
                    Height = 1.7m,
                    Weight = 99.0m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 551,
                    Name = "Gael Duarte Prado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 08, 21),
                    Position = Position.Goleiro,
                    ShirtNumber = 17,
                    Height = 1.66m,
                    Weight = 72.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 552,
                    Name = "Levi Camacho Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 07, 17),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 49,
                    Height = 1.71m,
                    Weight = 85.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 553,
                    Name = "Matheus Azevedo Fernandes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 11, 24),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 70,
                    Height = 1.75m,
                    Weight = 62.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 19
                },
                new Player
                {
                    Id = 554,
                    Name = "Pedro Cardoso Barros",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(1999, 05, 22),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 29,
                    Height = 1.85m,
                    Weight = 81.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 555,
                    Name = "Rafael Duarte Menezes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 05, 08),
                    Position = Position.LateralDireito,
                    ShirtNumber = 27,
                    Height = 1.69m,
                    Weight = 84.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 556,
                    Name = "Bernardo Vaz Ribeiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1987, 01, 16),
                    Position = Position.Zagueiro,
                    ShirtNumber = 92,
                    Height = 1.68m,
                    Weight = 79.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 557,
                    Name = "Noah Prado Cabral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 09, 17),
                    Position = Position.Goleiro,
                    ShirtNumber = 55,
                    Height = 1.94m,
                    Weight = 70.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 558,
                    Name = "Miguel Rego Macedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 03, 16),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 85,
                    Height = 1.7m,
                    Weight = 86.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 559,
                    Name = "Ravi Azevedo Bernardes​",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 11, 27),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 12,
                    Height = 1.62m,
                    Weight = 74.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 560,
                    Name = "Benício Bernardes​ Tavares",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 12, 06),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 68,
                    Height = 1.63m,
                    Weight = 77.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 561,
                    Name = "Pedro Melgaço Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1990, 11, 30),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 2,
                    Height = 1.97m,
                    Weight = 72.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 562,
                    Name = "Gui Martins Marinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 12, 15),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 4,
                    Height = 1.71m,
                    Weight = 63.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 563,
                    Name = "Matheus Camacho Figueiredo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 10, 07),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 27,
                    Height = 1.79m,
                    Weight = 97.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 564,
                    Name = "Noah Vieira Fonseca",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1980, 02, 26),
                    Position = Position.Volante,
                    ShirtNumber = 69,
                    Height = 1.75m,
                    Weight = 82.6m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 565,
                    Name = "Lucca Fernandes Furtado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 05, 25),
                    Position = Position.Ponta,
                    ShirtNumber = 78,
                    Height = 1.76m,
                    Weight = 60.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 566,
                    Name = "João Miguel Fonseca Pacheco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 04, 22),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 92,
                    Height = 1.88m,
                    Weight = 70.4m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 19
                },
                new Player
                {
                    Id = 567,
                    Name = "Matheus Barreto Franco",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 12, 10),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 2,
                    Height = 1.65m,
                    Weight = 80.2m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 19
                },
                new Player
                {
                    Id = 568,
                    Name = "Heitor Medeiros Amaral",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 06, 04),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 51,
                    Height = 1.84m,
                    Weight = 97.6m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },
                new Player
                {
                    Id = 569,
                    Name = "Gui Machado Mendonça",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 05, 31),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 9,
                    Height = 1.88m,
                    Weight = 73.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 19
                },

#endregion
                //Jogadores Id20
#region
                new Player
                {
                    Id = 570,
                    Name = "Théo Barros Brito",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 06, 10),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 29,
                    Height = 1.72m,
                    Weight = 70.7m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 571,
                    Name = "Levi Melgaço Guedes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1981, 10, 06),
                    Position = Position.AlaEsquerdo,
                    ShirtNumber = 19,
                    Height = 1.91m,
                    Weight = 88.3m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 572,
                    Name = "Miguel Botelho Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1985, 03, 14),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 61,
                    Height = 1.99m,
                    Weight = 86.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 573,
                    Name = "João Miguel Barros Figueiredo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 04, 13),
                    Position = Position.MeiaAtacanteDireito,
                    ShirtNumber = 5,
                    Height = 1.64m,
                    Weight = 88.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 574,
                    Name = "Benjamin Coimbra Godinho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2004, 11, 19),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 49,
                    Height = 1.65m,
                    Weight = 67.0m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 575,
                    Name = "Murilo Pinto Macedo",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 01, 19),
                    Position = Position.MeioCampoEsquerdo,
                    ShirtNumber = 8,
                    Height = 1.75m,
                    Weight = 76.1m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 576,
                    Name = "Anthony Pires Andrade",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2005, 03, 14),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 78,
                    Height = 1.69m,
                    Weight = 96.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 577,
                    Name = "Gael Silva Barbosa",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 12, 29),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 45,
                    Height = 1.82m,
                    Weight = 71.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 578,
                    Name = "Arthur Almeida Reis",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 07, 03),
                    Position = Position.Goleiro,
                    ShirtNumber = 94,
                    Height = 1.84m,
                    Weight = 64.2m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 579,
                    Name = "Miguel Bernardes​ Menezes",
                    Nacionality = "Latino",
                    BirthDate = new DateTime(2002, 09, 16),
                    Position = Position.MeiaCentral,
                    ShirtNumber = 83,
                    Height = 1.76m,
                    Weight = 65.8m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 580,
                    Name = "Ravi Teles Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 02, 13),
                    Position = Position.AlaDireito,
                    ShirtNumber = 40,
                    Height = 1.88m,
                    Weight = 78.1m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 581,
                    Name = "Pedro Oliveira Vieira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 03, 30),
                    Position = Position.Volante,
                    ShirtNumber = 68,
                    Height = 1.88m,
                    Weight = 99.8m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 582,
                    Name = "Gui Pacheco Carvalho",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1993, 01, 30),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 69,
                    Height = 1.98m,
                    Weight = 81.7m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 583,
                    Name = "Murilo Ribeiro Aguiar",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1983, 07, 13),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 96,
                    Height = 1.91m,
                    Weight = 71.2m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 584,
                    Name = "Davi Barbosa Marques",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1995, 12, 08),
                    Position = Position.LateralEsquerdo,
                    ShirtNumber = 28,
                    Height = 1.82m,
                    Weight = 68.6m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 585,
                    Name = "Ravi Álvares Salgado",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1988, 07, 28),
                    Position = Position.AtacanteDireito,
                    ShirtNumber = 73,
                    Height = 1.93m,
                    Weight = 97.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 586,
                    Name = "Rafael Duarte Loureiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 05, 10),
                    Position = Position.AtacanteEsquerdo,
                    ShirtNumber = 14,
                    Height = 1.68m,
                    Weight = 81.1m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 587,
                    Name = "Lucca Ramos Pinheiro",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 04, 01),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 82,
                    Height = 1.92m,
                    Weight = 61.0m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 588,
                    Name = "Miguel Barreto Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 01, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 13,
                    Height = 1.62m,
                    Weight = 91.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 589,
                    Name = "Miguel Barreto Quaresma",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1992, 01, 01),
                    Position = Position.Goleiro,
                    ShirtNumber = 13,
                    Height = 1.62m,
                    Weight = 91.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 590,
                    Name = "Benjamin Martins Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 09, 01),
                    Position = Position.Volante,
                    ShirtNumber = 54,
                    Height = 1.99m,
                    Weight = 92.4m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 591,
                    Name = "Pedro Gomes Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2000, 11, 22),
                    Position = Position.MeiaLateral,
                    ShirtNumber = 34,
                    Height = 1.68m,
                    Weight = 88.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 592,
                    Name = "Gabriel Freitas Antunes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1991, 11, 14),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 40,
                    Height = 1.88m,
                    Weight = 84.9m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 593,
                    Name = "João Miguel Macedo Sá",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1989, 03, 05),
                    Position = Position.LateralDireito,
                    ShirtNumber = 18,
                    Height = 1.73m,
                    Weight = 93.9m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 594,
                    Name = "Isaac Cardoso Mendes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(2003, 12, 09),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 22,
                    Height = 1.8m,
                    Weight = 95.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 595,
                    Name = "Levi Gonçalves Lins",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1986, 03, 21),
                    Position = Position.MeioCampoDireito,
                    ShirtNumber = 99,
                    Height = 1.65m,
                    Weight = 85.5m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 596,
                    Name = "Levi Aguiar Rodrigues",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1996, 10, 02),
                    Position = Position.MeiaAtacanteEsquerdo,
                    ShirtNumber = 54,
                    Height = 1.76m,
                    Weight = 92.7m,
                    MainFeet = MainFeet.Ambidestro,
                    TeamId = 20
                },
                new Player
                {
                    Id = 597,
                    Name = "Lucca Franco Pereira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1984, 08, 19),
                    Position = Position.LateralDireito,
                    ShirtNumber = 8,
                    Height = 1.89m,
                    Weight = 85.3m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },
                new Player
                {
                    Id = 598,
                    Name = "Gael Macedo Teixeira",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1997, 01, 20),
                    Position = Position.Zagueiro,
                    ShirtNumber = 24,
                    Height = 1.78m,
                    Weight = 92.9m,
                    MainFeet = MainFeet.Direito,
                    TeamId = 20
                },
                new Player
                {
                    Id = 599,
                    Name = "Isaac Carvalho Lopes",
                    Nacionality = "Brasileiro",
                    BirthDate = new DateTime(1982, 11, 16),
                    Position = Position.LateralDireito,
                    ShirtNumber = 39,
                    Height = 1.92m,
                    Weight = 83.5m,
                    MainFeet = MainFeet.Esquerdo,
                    TeamId = 20
                },

#endregion

            };
            var treinadores = new List<Commission>
            {
                //Commission Id1
#region
                new Commission
                {
                    Id = 1,
                    Name = "Daniel Carvalho Cavalcanti",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1980, 03, 10),
                    TeamId = 1
                },
                new Commission
                {
                    Id = 2,
                    Name = "Tiago Pereira Goncalves",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1989, 06, 08),
                    TeamId = 1
                },
                new Commission
                {
                    Id = 3,
                    Name = "Felipe Rocha Barros",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1990, 04, 05),
                    TeamId = 1
                },
                new Commission
                {
                    Id = 4,
                    Name = "Douglas Silva Ribeiro",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1994, 08, 24),
                    TeamId = 1
                },
                new Commission
                {
                    Id = 5,
                    Name = "Thiago Costa Santos",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1991, 06, 24),
                    TeamId = 1
                },
                new Commission
                {
                    Id = 500,
                    Name = "Treinador Deletavel",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1965, 04, 05),
                    TeamId = 1
                },
#endregion
                // Commission Id2
#region
                new Commission
                {
                    Id = 6,
                    Name = "Erick Ribeiro Correia",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1965, 05, 22),
                    TeamId = 2
                },
                new Commission
                {
                    Id = 7,
                    Name = "Davi Barbosa Rocha",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1972, 09, 24),
                    TeamId = 2
                },
                new Commission
                {
                    Id = 8,
                    Name = "Joao Goncalves Almeida",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1962, 08, 26),
                    TeamId = 2
                },
                new Commission
                {
                    Id = 9,
                    Name = "Leonardo Gomes Lima",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1975, 03, 09),
                    TeamId = 2
                },
                new Commission
                {
                    Id = 10,
                    Name = "Danilo Martins Santos",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1978, 12, 23),
                    TeamId = 2
                },
                new Commission
                {
                    Id = 11,
                    Name = "Gabriel Cavalcanti Carvalho",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1962, 10, 24),
                    TeamId = 2
                },
#endregion
                // Commission Id3
#region
                new Commission
                {
                    Id = 12,
                    Name = "Bruno Pereira Souza",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1979, 12, 20),
                    TeamId = 3
                },
                new Commission
                {
                    Id = 13,
                    Name = "Alex Cardoso Almeida",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1978, 04, 28),
                    TeamId = 3
                },
                new Commission
                {
                    Id = 14,
                    Name = "Lucas Martins Barros",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(2021, 02, 02),
                    TeamId = 3
                },
                new Commission
                {
                    Id = 15,
                    Name = "Mateus Rocha Gomes",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1975, 03, 01),
                    TeamId = 3
                },
                new Commission
                {
                    Id = 16,
                    Name = "Enzo Azevedo Carvalho",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1976, 10, 21),
                    TeamId = 3
                },
                new Commission
                {
                    Id = 17,
                    Name = "Igor Gomes Silva",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1968, 06, 27),
                    TeamId = 3
                },
#endregion
                // Commission Id4
#region
                new Commission
                {
                    Id = 18,
                    Name = "Miguel Barbosa Santos",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1969, 04, 29),
                    TeamId = 4
                },
                new Commission
                {
                    Id = 19,
                    Name = "Vitór Dias Castro",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1964, 01, 12),
                    TeamId = 4
                },
                new Commission
                {
                    Id = 20,
                    Name = "Vitór Alves Castro",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1975, 04, 07),
                    TeamId = 4
                },
                new Commission
                {
                    Id = 21,
                    Name = "Miguel Correia Cardoso",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1978, 11, 08),
                    TeamId = 4
                },
                new Commission
                {
                    Id = 22,
                    Name = "Tomás Goncalves Oliveira",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1973, 12, 25),
                    TeamId = 4
                },
                new Commission
                {
                    Id = 23,
                    Name = "Bruno Barbosa Silva",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1972, 12, 11),
                    TeamId = 4
                },
#endregion
                // Commission Id5
#region
                new Commission
                {
                    Id = 25,
                    Name = "Douglas Castro Cavalcanti",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1979, 05, 11),
                    TeamId = 5
                },
                new Commission
                {
                    Id = 25,
                    Name = "Davi Cavalcanti Rodrigues",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1961, 11, 08),
                    TeamId = 5
                },
                new Commission
                {
                    Id = 26,
                    Name = "Mateus Alves Azevedo",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1974, 02, 03),
                    TeamId = 5
                },
                new Commission
                {
                    Id = 27,
                    Name = "João Almeida Lima",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1977, 03, 08),
                    TeamId = 5
                },
                new Commission
                {
                    Id = 28,
                    Name = "Alex Gomes Oliveira",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1976, 02, 21),
                    TeamId = 5
                },
                new Commission
                {
                    Id = 29,
                    Name = "Julian Almeida Sousa",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1970, 07, 23),
                    TeamId = 5
                },
#endregion
                // Commission Id6
#region
                new Commission
                {
                    Id = 30,
                    Name = "Matheus Barbosa Almeida",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1962, 12, 27),
                    TeamId = 6
                },
                new Commission
                {
                    Id = 31,
                    Name = "Tiago Rocha Almeida",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1980, 11, 13),
                    TeamId = 6
                },
                new Commission
                {
                    Id = 32,
                    Name = "Matheus Goncalves Cardoso",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1963, 04, 15),
                    TeamId = 6
                },
                new Commission
                {
                    Id = 33,
                    Name = "Vitor Dias Barros",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1972, 01, 19),
                    TeamId = 6
                },
                new Commission
                {
                    Id = 34,
                    Name = "Kaua Melo Correia",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1975, 06, 03),
                    TeamId = 6
                },
                new Commission
                {
                    Id = 35,
                    Name = "Gabriel Cardoso Sousa",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1971, 06, 16),
                    TeamId = 6
                },
#endregion
                // Commission Id7
#region
                new Commission
                {
                    Id = 36,
                    Name = "Paulo Carvalho Cunha",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1965, 03, 13),
                    TeamId = 7
                },
                new Commission
                {
                    Id = 37,
                    Name = "Miguel Gomes Souza",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1968, 03, 04),
                    TeamId = 7
                },
                new Commission
                {
                    Id = 38,
                    Name = "Fábio Fernandes Santos",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1978, 10, 16),
                    TeamId = 7
                },
                new Commission
                {
                    Id = 39,
                    Name = "Douglas Gomes Cavalcanti",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1971, 10, 12),
                    TeamId = 7
                },
                new Commission
                {
                    Id = 40,
                    Name = "Guilherme Pinto Rocha",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1973, 10, 11),
                    TeamId = 7
                },
                new Commission
                {
                    Id = 41,
                    Name = "Antônio Ferreira Costa",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1968, 08, 03),
                    TeamId = 7
                },
#endregion
                // Commission Id8
#region
                new Commission
                {
                    Id = 42,
                    Name = "Rafael Lima Almeida",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1971, 02, 24),
                    TeamId = 8
                },
                new Commission
                {
                    Id = 43,
                    Name = "Enzo Oliveira Pinto",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1968, 05, 12),
                    TeamId = 8
                },
                new Commission
                {
                    Id = 44,
                    Name = "Luiz Pereira Silva",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1962, 10, 27),
                    TeamId = 8
                },
                new Commission
                {
                    Id = 45,
                    Name = "Matheus Gomes Martins",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1966, 07, 25),
                    TeamId = 8
                },
                new Commission
                {
                    Id = 46,
                    Name = "Victor Almeida Carvalho",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1974, 05, 04),
                    TeamId = 8
                },
                new Commission
                {
                    Id = 47,
                    Name = "Douglas Cavalcanti Fernandes",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1963, 01, 28),
                    TeamId = 8
                },
#endregion
                // Commission Id9
#region
                new Commission
                {
                    Id = 48,
                    Name = "Tiago Souza Rocha",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1961, 01, 11),
                    TeamId = 9
                },
                new Commission
                {
                    Id = 49,
                    Name = "Vinicius Sousa Dias",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1960, 08, 30),
                    TeamId = 9
                },
                new Commission
                {
                    Id = 50,
                    Name = "Fábio Carvalho Martins",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1960, 08, 30),
                    TeamId = 9
                },
                new Commission
                {
                    Id = 51,
                    Name = "Tomás Pinto Lima",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1971, 10, 10),
                    TeamId = 9
                },
                new Commission
                {
                    Id = 52,
                    Name = "Luís Goncalves Lima",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1961, 04, 07),
                    TeamId = 9
                },
                new Commission
                {
                    Id = 53,
                    Name = "Rafael Fernandes Ferreira",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1972, 11, 10),
                    TeamId = 9
                },
#endregion
                // Commission Id10
#region
                new Commission
                {
                    Id = 54,
                    Name = "Rodrigo Almeida Martins",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1967, 03, 20),
                    TeamId = 10
                },
                new Commission
                {
                    Id = 55,
                    Name = "Carlos Fernandes Gomes",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1965, 10, 19),
                    TeamId = 10
                },
                new Commission
                {
                    Id = 56,
                    Name = "Lucas Dias Goncalves",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1972, 05, 04),
                    TeamId = 10
                },
                new Commission
                {
                    Id = 57,
                    Name = "Estevan Pinto Correia",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1962, 09, 23),
                    TeamId = 10
                },
                new Commission
                {
                    Id = 58,
                    Name = "Felipe Lima Barros",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1978, 09, 10),
                    TeamId = 10
                },
                new Commission
                {
                    Id = 59,
                    Name = "Kauan Rodrigues Fernandes",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1964, 10, 09),
                    TeamId = 10
                },
#endregion
                // Commission Id11
#region
                new Commission
                {
                    Id = 60,
                    Name = "Kai Martins Fernandes",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1971, 05, 15),
                    TeamId = 11
                },
                new Commission
                {
                    Id = 61,
                    Name = "Vinicius Souza Azevedo",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1969, 11, 21),
                    TeamId = 11
                },
                new Commission
                {
                    Id = 62,
                    Name = "Fábio Castro Araujo",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1971, 08, 30),
                    TeamId = 11
                },
                new Commission
                {
                    Id = 63,
                    Name = "Vitor Carvalho Rocha",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1970, 09, 27),
                    TeamId = 11
                },
                new Commission
                {
                    Id = 64,
                    Name = "Igor Araujo Pinto",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1961, 11, 21),
                    TeamId = 11
                },
                new Commission
                {
                    Id = 65,
                    Name = "Kaua Sousa Gomes",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1975, 05, 26),
                    TeamId = 11
                },
#endregion
                // Commission Id12
#region
                new Commission
                {
                    Id = 66,
                    Name = "Kaua Barros Gomes",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1978, 11, 14),
                    TeamId = 12
                },
                new Commission
                {
                    Id = 67,
                    Name = "Kauê Ribeiro Fernandes",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1968, 11, 21),
                    TeamId = 12
                },
                new Commission
                {
                    Id = 68,
                    Name = "Joao Rodrigues Pinto",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1971, 02, 15),
                    TeamId = 12
                },
                new Commission
                {
                    Id = 69,
                    Name = "Arthur Sousa Cavalcanti",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1974, 11, 23),
                    TeamId = 12
                },
                new Commission
                {
                    Id = 70,
                    Name = "Pedro Souza Melo",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1980, 07, 15),
                    TeamId = 12
                },
                new Commission
                {
                    Id = 71,
                    Name = "Samuel Barbosa Rocha",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1975, 12, 18),
                    TeamId = 12
                },
#endregion
                // Commission Id13
#region
                new Commission
                {
                    Id = 72,
                    Name = "Guilherme Fernandes Sousa",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1968, 03, 27),
                    TeamId = 13
                },
                new Commission
                {
                    Id = 73,
                    Name = "Martim Almeida Oliveira",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1980, 04, 04),
                    TeamId = 13
                },
                new Commission
                {
                    Id = 74,
                    Name = "João Lima Araujo",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1969, 01, 13),
                    TeamId = 13
                },
                new Commission
                {
                    Id = 75,
                    Name = "Júlio Martins Costa",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1964, 11, 24),
                    TeamId = 13
                },
                new Commission
                {
                    Id = 76,
                    Name = "Felipe Cavalcanti Fernandes",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1973, 10, 27),
                    TeamId = 13
                },
                new Commission
                {
                    Id = 77,
                    Name = "Murilo Cunha Pereira",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1978, 11, 23),
                    TeamId = 13
                },
#endregion
                // Commission Id14
#region
                new Commission
                {
                    Id = 114,
                    Name = "Kauê Correia Martins",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1966, 02, 27),
                    TeamId = 14
                },
                new Commission
                {
                    Id = 115,
                    Name = "Mateus Gomes Almeida",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1963, 07, 13),
                    TeamId = 14
                },
                new Commission
                {
                    Id = 116,
                    Name = "Rafael Martins Castro",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1968, 10, 26),
                    TeamId = 14
                },
                new Commission
                {
                    Id = 116,
                    Name = "Danilo Ribeiro Pereira",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1970, 05, 01),
                    TeamId = 14
                },
                new Commission
                {
                    Id = 117,
                    Name = "Erick Melo Gomes",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1960, 09, 17),
                    TeamId = 14
                },
                new Commission
                {
                    Id = 118,
                    Name = "Davi Azevedo Rodrigues",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1961, 05, 06),
                    TeamId = 14
                },
#endregion
                // Commission Id15
#region
                new Commission
                {
                    Id = 78,
                    Name = "Alex Silva Costa",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1964, 01, 27),
                    TeamId = 15
                },
                new Commission
                {
                    Id = 79,
                    Name = "Pedro Santos Carvalho",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1974, 06, 24),
                    TeamId = 15
                },
                new Commission
                {
                    Id = 80,
                    Name = "Treinador2",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1970, 10, 08),
                    TeamId = 15
                },
                new Commission
                {
                    Id = 81,
                    Name = "Victor Carvalho Rocha",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1965, 11, 21),
                    TeamId = 15
                },
                new Commission
                {
                    Id = 82,
                    Name = "Vitor Fernandes Oliveira",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1965, 03, 10),
                    TeamId = 15
                },
                new Commission
                {
                    Id = 83,
                    Name = "Vitor Fernandes Oliveira",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1970, 01, 24),
                    TeamId = 15
                },
#endregion
                // Commission Id16
#region
                new Commission
                {
                    Id = 84,
                    Name = "Kauan Souza Gomes",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1975, 03, 21),
                    TeamId = 16
                },
                new Commission
                {
                    Id = 85,
                    Name = "Danilo Goncalves Santos",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1970, 01, 18),
                    TeamId = 16
                },
                new Commission
                {
                    Id = 86,
                    Name = "Gustavo Martins Pinto",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1971, 09, 27),
                    TeamId = 16
                },
                new Commission
                {
                    Id = 87,
                    Name = "Leonardo Cavalcanti Fernandes",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1966, 06, 14),
                    TeamId = 16
                },
                new Commission
                {
                    Id = 88,
                    Name = "Arthur Azevedo Castro",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1965, 08, 23),
                    TeamId = 16
                },
                new Commission
                {
                    Id = 89,
                    Name = "José Oliveira Ribeiro",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1968, 05, 05),
                    TeamId = 16
                },
#endregion
                // Commission Id17
#region
                new Commission
                {
                    Id = 90,
                    Name = "Erick Souza Lima",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1964, 06, 24),
                    TeamId = 17
                },
                new Commission
                {
                    Id = 91,
                    Name = "Luan Rodrigues Cavalcanti",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1970, 09, 27),
                    TeamId = 17
                },
                new Commission
                {
                    Id = 92,
                    Name = "Daniel Cardoso Pereira",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1968, 02, 08),
                    TeamId = 17
                },
                new Commission
                {
                    Id = 93,
                    Name = "Kauê Ferreira Azevedo",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1963, 03, 15),
                    TeamId = 17
                },
                new Commission
                {
                    Id = 94,
                    Name = "Felipe Azevedo Sousa",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1969, 10, 03),
                    TeamId = 17
                },
                new Commission
                {
                    Id = 95,
                    Name = "Luiz Correia Rodrigues",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1965, 07, 08),
                    TeamId = 17
                },
#endregion
                // Commission Id18
#region
                new Commission
                {
                    Id = 96,
                    Name = "Luiz Almeida Sousa",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1966, 12, 06),
                    TeamId = 18
                },
                new Commission
                {
                    Id = 97,
                    Name = "Cauã Pinto Cavalcanti",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1962, 09, 02),
                    TeamId = 18
                },
                new Commission
                {
                    Id = 98,
                    Name = "Cauã Melo Carvalho",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1970, 04, 05),
                    TeamId = 18
                },
                new Commission
                {
                    Id = 99,
                    Name = "Breno Castro Carvalho",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1980, 01, 28),
                    TeamId = 18
                },
                new Commission
                {
                    Id = 100,
                    Name = "João Silva Fernandes",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1960, 06, 14),
                    TeamId = 18
                },
                new Commission
                {
                    Id = 101,
                    Name = "Samuel Araujo Pinto",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1968, 01, 07),
                    TeamId = 18
                },
#endregion
                // Commission Id19
#region
                new Commission
                {
                    Id = 102,
                    Name = "Kaua Lima Castro",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1962, 08, 02),
                    TeamId = 19
                },
                new Commission
                {
                    Id = 103,
                    Name = "Leonardo Barbosa Ferreira",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1977, 09, 06),
                    TeamId = 19
                },
                new Commission
                {
                    Id = 104,
                    Name = "Leonardo Barbosa Ferreira",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1979, 03, 29),
                    TeamId = 19
                },
                new Commission
                {
                    Id = 105,
                    Name = "Estevan Pereira Silva",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1969, 07, 05),
                    TeamId = 19
                },
                new Commission
                {
                    Id = 106,
                    Name = "Felipe Cavalcanti Gomes",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1968, 02, 18),
                    TeamId = 19
                },
                new Commission
                {
                    Id = 107,
                    Name = "Antônio Martins Dias",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1974, 01, 31),
                    TeamId = 19
                },
#endregion
                // Commission Id20
#region
                new Commission
                {
                    Id = 108,
                    Name = "Luis Sousa Gomes",
                    Function = Function.Auxiliar,
                    BirthDate = new DateTime(1995, 09, 03),
                    TeamId = 20
                },
                new Commission
                {
                    Id = 109,
                    Name = "Felipe Fernandes Cavalcanti",
                    Function = Function.TreinadorGoleiros,
                    BirthDate = new DateTime(1971, 03, 03),
                    TeamId = 20
                },
                new Commission
                {
                    Id = 110,
                    Name = "Tomás Melo Sousa",
                    Function = Function.Treinador,
                    BirthDate = new DateTime(1972, 06, 23),
                    TeamId = 20
                },
                new Commission
                {
                    Id = 111,
                    Name = "Carlos Almeida Martins",
                    Function = Function.PreparadorFisico,
                    BirthDate = new DateTime(1974, 11, 17),
                    TeamId = 20
                },
                new Commission
                {
                    Id = 112,
                    Name = "Carlos Almeida Martins",
                    Function = Function.Fisiologista,
                    BirthDate = new DateTime(1974, 07, 13),
                    TeamId = 20
                },
                new Commission
                {
                    Id = 113,
                    Name = "Carlos Ribeiro Sousa",
                    Function = Function.Fisioterapeuta,
                    BirthDate = new DateTime(1980, 07, 25),
                    TeamId = 20
                },
#endregion
               
            };

            liga.ForEach(l => context.Leagues.Add(l));
            times.ForEach(t => context.Teams.Add(t));
            jogadores.ForEach(j => context.Players.Add(j));
            treinadores.ForEach(t => context.Commissions.Add(t));

            context.SaveChanges();

            var service = new LeagueService(context);
            foreach (var ligaCriada in context.Leagues.ToList())
            {
                service.GerarRodadas(ligaCriada.Id);
            }
            service.VerificarLigasCompletasEGerarRodadas();
            foreach (var ligaCriada in context.Leagues.ToList())
            {
                service.InicializarClassificacao(ligaCriada.Id);
            }
        }
    }
}