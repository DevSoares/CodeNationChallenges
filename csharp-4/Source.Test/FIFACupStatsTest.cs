using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class FIFACupStatsTest
    {
        [Fact]
        public void Shoud_Return_20_Itens_When_Get_Top_Players()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.First20Players();
            Assert.NotNull(topPlayers);
            Assert.Equal(20, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Release_Clause()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByReleaseClause();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Age()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByAge();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }


        [Fact]
        public void ShouldNotGetEmptyList()
        {
            var cup = new FIFACupStats();
            Assert.NotEmpty(cup.ReadData());
        }        

        [Fact]
        public void Should20FirstPlayersNames()
        {
            var cup = new FIFACupStats();
            var names = new List<string>()
            {
                "C. Ronaldo dos Santos Aveiro",
                "Lionel Messi",
                "Neymar da Silva Santos Jr.",
                "Luis Suárez",
                "Manuel Neuer",
                "Robert Lewandowski",
                "David De Gea Quintana",
                "Eden Hazard",
                "Toni Kroos",
                "Gonzalo Higuaín",
                "Sergio Ramos García",
                "Kevin De Bruyne",
                "Thibaut Courtois",
                "Alexis Sánchez",
                "Luka Modrić",
                "Gareth Bale",
                "Sergio Agüero",
                "Giorgio Chiellini",
                "Gianluigi Buffon",
                "Paulo Dybala"
            };

            Assert.Equal(names, cup.First20Players());
        }
    }
}
