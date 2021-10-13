using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnit.Api.Interfaces.Repository;
using XUnit.Api.Models;
using XUnit.Api.Services;
using XUnit.Test.Attributes;

namespace XUnit.Test.Tests.Services
{
    public class GameServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void GameService_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(GameService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task CreateGame_WhenGameAlreadyExists_ReturnFail(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            Games games
            )
        {
            gameRepository.FindById(games.Id)
                .Returns(games);

            var result = await sut.CreateGame(games);

            result.Should().Be("Game with the same Id already exists in our database!");
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task CreateGame_WhenGameDontExists_ReturnOk(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            Games games
            )
        {
            Games game = null;

            gameRepository.FindById(games.Id)
                .Returns(game);

            var result = await sut.CreateGame(games);

            result.Should().Be("Game created with success!");
            await gameRepository.Received(1).Create(games);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task DeleteGame_WhenGameDontExists_ReturnFail(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            int id
            )
        {
            Games game = null;

            gameRepository.FindById(id)
                .Returns(game);

            var result = await sut.DeleteGame(id);

            result.Should().Be("Game with the same Id don't exists in our database!");
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task DeleteGame_WhenGameAlreadyExists_ReturnOk(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            int id,
            Games game
            )
        {
            gameRepository.FindById(id)
                .Returns(game);

            var result = await sut.DeleteGame(id);

            result.Should().Be("Game deleted with success!");
            await gameRepository.Received(1).Delete(id);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task ListGames_WhenEverythingWorks_ReturnOk(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            List<Games> game
            )
        {
            gameRepository.ListAll()
                .Returns(game);

            var result = await sut.ListGames();

            result.Should().BeEquivalentTo(game);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task UpdateGames_WhenGameDontExists_ReturnFail(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            Games gamesFull
            )
        {
            Games game = null;


            gameRepository.FindById(gamesFull.Id)
                .Returns(game);

            var result = await sut.UpdateGame(gamesFull);

            result.Should().Be("Game with the same Id don't exists in our database!");
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task UpdateGames_WhenGameAlreadyExists_ReturnOk(
            [Frozen] IGameRepository gameRepository,
            [Greedy] GameService sut,
            int id,
            Games games
            )
        {
            gameRepository.FindById(id)
                .Returns(games);

            var result = await sut.UpdateGame(games);

            result.Should().Be("Game updated with success!");
            await gameRepository.Received(1).Update(games);
        }
    }
}
