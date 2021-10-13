using System.Collections.Generic;
using System.Threading.Tasks;
using XUnit.Api.Interfaces.Repository;
using XUnit.Api.Interfaces.Services;
using XUnit.Api.Models;

namespace XUnit.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new System.ArgumentNullException(nameof(gameRepository));
        }

        public async Task<string> CreateGame(Games request)
        {
            var game = await _gameRepository.FindById(request.Id);

            if (game != null)
                return "Game with the same Id already exists in our database!";

            await _gameRepository.Create(request);

            return "Game created with success!";
        }

        public async Task<string> DeleteGame(int id)
        {
            var game = await _gameRepository.FindById(id);

            if (game == null)
                return "Game with the same Id don't exists in our database!";

            await _gameRepository.Delete(id);

            return "Game deleted with success!";
        }

        public async Task<List<Games>> ListGames()
        {
            var allGames = await _gameRepository.ListAll();

            return allGames;
        }

        public async Task<string> UpdateGame(Games request)
        {
            var game = await _gameRepository.FindById(request.Id);

            if (game == null)
                return "Game with the same Id don't exists in our database!";

            await _gameRepository.Update(request);

            return "Game updated with success!";
        }
    }
}
