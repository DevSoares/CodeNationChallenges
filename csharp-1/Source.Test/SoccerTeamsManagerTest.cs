using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManagerTest
    {
        [Fact]
        public void Should_Get_Null_Best_Players_List()
        {
            var manager = new SoccerTeamsManager();
            var teams = manager.GetTopPlayers(2);
            Assert.Empty(teams);
        }


        [Fact]
        public void Should_Get_Best_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(2, "Time 2", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() { 15, 2, 33, 4, 13 };
            var skill = new List<int>() { 30, 50, 50, 30, 10 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Now, skill[i], 0);

            playersIds = new List<long>() { 16, 3, 34, 5, 14 };
            skill = new List<int>() { 35, 52, 50, 10, 10 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 2, $"Boleiro {i}", DateTime.Now, skill[i], 0);

            var bestPlayers = manager.GetTopPlayers(5);
            Assert.Equal(3, bestPlayers[0]);
            Assert.Equal(2, bestPlayers[1]);
            Assert.Equal(33, bestPlayers[2]);
            Assert.Equal(34, bestPlayers[3]);
            Assert.Equal(16, bestPlayers[4]);
        }


        [Fact]
        public void Should_Get_Player_Salary_By_Id()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Joao", DateTime.Now, 30, 1000);
            Assert.Equal(1000, manager.GetPlayerSalary(1));
        }


        [Fact]
        public void Should_Get_Higher_Salary_Player_Id()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() { 15, 2, 33, 4, 13 };
            var salary = new List<long>() { 1500, 1800, 300, 1800, 750 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Now, 0, salary[i]);

            Assert.Equal(2, manager.GetHigherSalaryPlayer(1));
        }


        [Fact]
        public void Should_Get_Null_Teams_List()
        {
            var manager = new SoccerTeamsManager();
            var teams = manager.GetTeams();
            Assert.Empty(teams);
        }

        [Fact]
        public void Should_Return_Oldest_Player()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() { 15, 2, 33, 4, 13 };
            var playerAges = new List<long>() { 10, 10, 15, 18, 13 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", new DateTime().AddYears((int)playerAges[i]), 0, 0);

            Assert.Equal(2, manager.GetOlderTeamPlayer(1));
        }

        [Fact]
        public void Should_Get_Team_Name_By_Id()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            Assert.Equal("Time 1", manager.GetTeamName(1));
        }

        [Fact]
        public void Should_Get_Player_Name_By_Id()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Joao", DateTime.Now, 30, 30);
            Assert.Equal("Joao", manager.GetPlayerName(1));
        }


        [Fact]
        public void Should_Be_Unique_Ids_For_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Joao", DateTime.Now, 30, 30);
            Assert.Throws<UniqueIdentifierException>(() =>
                manager.AddPlayer(1, 1, "Joao", DateTime.Now, 30, 30));
        }


        [Fact]
        public void Should_Be_Unique_Ids_For_Teams()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            Assert.Throws<UniqueIdentifierException>(() =>
                manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2"));
        }

        [Fact]
        public void Should_Be_Valid_Player_When_Set_Captain()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.SetCaptain(1);
            Assert.Equal(1, manager.GetTeamCaptain(1));
            Assert.Throws<PlayerNotFoundException>(() =>
                manager.SetCaptain(2));
        }

        [Fact]
        public void Should_Ensure_Sort_Order_When_Get_Team_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() { 15, 2, 33, 4, 13 };
            for (int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Today, 0, 0);

            playersIds.Sort();
            Assert.Equal(playersIds, manager.GetTeamPlayers(1));
        }

        [Theory]
        [InlineData("10,20,300,40,50", 2)]
        [InlineData("50,240,3,1,50", 1)]
        [InlineData("10,22,24,3,24", 2)]
        public void Should_Choose_Best_Team_Player(string skills, int bestPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var skillsLevelList = skills.Split(',').Select(x => int.Parse(x)).ToList();
            for (int i = 0; i < skillsLevelList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, skillsLevelList[i], 0);

            Assert.Equal(bestPlayerId, manager.GetBestTeamPlayer(1));
        }

        [Theory]
        [InlineData("Azul;Vermelho", "Azul;Amarelo", "Amarelo")]
        [InlineData("Azul;Vermelho", "Amarelo;Laranja", "Amarelo")]
        [InlineData("Azul;Vermelho", "Azul;Vermelho", "Vermelho")]
        public void Should_Choose_Right_Color_When_Get_Visitor_Shirt_Color(string teamColors, string visitorColors, string visitorMatchColor)
        {
            long teamId = 1;
            long visitorTeamId = 2;
            var teamColorList = teamColors.Split(";");
            var visitorColorList = visitorColors.Split(";");

            var manager = new SoccerTeamsManager();
            manager.AddTeam(teamId, $"Time {teamId}", DateTime.Now, teamColorList[0], teamColorList[1]);
            manager.AddTeam(visitorTeamId, $"Time {visitorTeamId}", DateTime.Now, visitorColorList[0], visitorColorList[1]);

            Assert.Equal(visitorMatchColor, manager.GetVisitorShirtColor(teamId, visitorTeamId));
        }
    }
}
