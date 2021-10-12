using System.Collections.Generic;
using System.Threading.Tasks;
using XUnit.Api.Models;

namespace XUnit.Api.Interfaces.Services
{
    public interface IGameService
    {
        public Task<string> CreateGame(Games request);
        public Task<string> UpdateGame(Games request);
        public Task<List<Games>> ListGames();
        public Task<string> DeleteGame(int id);
    }
}
