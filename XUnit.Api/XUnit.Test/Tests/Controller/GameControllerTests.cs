using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnit.Api.Controllers;
using XUnit.Api.Interfaces.Services;
using XUnit.Api.Models;
using XUnit.Test.Attributes;

namespace XUnit.Test.Tests.Controller
{
    public class GameControllerTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void GameController_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(GameController).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteDataAttribute]
        public async Task Create_WhenEverythingWorks_ReturnOk(
            [Frozen] IGameService gameService,
            [Greedy] GameController sut,
            Games games,
            string response
            )
        {
            gameService.CreateGame(games)
                .Returns(response);

            var result = await sut.Create(games);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoNSubstituteDataAttribute]
        public async Task Update_WhenEverythingWorks_ReturnOk(
            [Frozen] IGameService gameService,
            [Greedy] GameController sut,
            Games games,
            string response
            )
        {
            gameService.UpdateGame(games)
                .Returns(response);

            var result = await sut.Update(games);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoNSubstituteDataAttribute]
        public async Task List_WhenEverythingWorks_ReturnOk(
            [Frozen] IGameService gameService,
            [Greedy] GameController sut,
            List<Games> games
            )
        {
            gameService.ListGames()
                .Returns(games);

            var result = await sut.List();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoNSubstituteDataAttribute]
        public async Task Delete_WhenEverythingWorks_ReturnOk(
            [Frozen] IGameService gameService,
            [Greedy] GameController sut,
            int id,
            string response
            )
        {
            gameService.DeleteGame(id)
                .Returns(response);

            var result = await sut.Delete(id);

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
