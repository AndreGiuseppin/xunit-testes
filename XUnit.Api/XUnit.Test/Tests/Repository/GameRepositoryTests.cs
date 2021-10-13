using AutoFixture.Idioms;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;
using XUnit.Api.Models;
using XUnit.Api.Repository;
using XUnit.Test.Attributes;

namespace XUnit.Test.Tests.Repository
{
    public class GameRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void GameRepository_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(GameRepository).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task Create_WhenEverythingWorks_ReturnOkAsync(
            Games games
            )
        {
            var sut = Substitute.For<GameRepository>();
            await sut.Create(games);
            await sut.Received(1).Create(games);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task Delete_WhenEverythingWorks_ReturnOkAsync(
            int id
            )
        {
            var sut = Substitute.For<GameRepository>();
            await sut.Delete(id);
            await sut.Received(1).Delete(id);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task FindById_WhenEverythingWorks_ReturnOkAsync(
            int id
            )
        {
            var sut = Substitute.For<GameRepository>();
            await sut.FindById(id);
            await sut.Received(1).FindById(id);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task ListAll_WhenEverythingWorks_ReturnOkAsync(
            )
        {
            var sut = Substitute.For<GameRepository>();
            await sut.ListAll();
            await sut.Received(1).ListAll();
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task Update_WhenEverythingWorks_ReturnOkAsync(
            )
        {
            var games = new Games
            {
                Id = 1,
                Name = "Battlefield 2042",
                Description = "First-Person-Shooter",
                Price = 300,
                PermitedAge = 18
            };

            var sut = Substitute.For<GameRepository>();
            await sut.Update(games);
            await sut.Received(1).Update(games);
        }
    }
}
