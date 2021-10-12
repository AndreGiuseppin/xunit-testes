using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit.Api.Interfaces.Repository;
using XUnit.Api.Models;

namespace XUnit.Api.Repository
{
    public class GameRepository : IGameRepository
    {
        public async Task Create(Games request)
        {
            var bdo = new List<Games>();

            bdo.Add(request);
        }

        public async Task Delete(int id)
        {
            var bdo = new List<Games>();

            bdo.Add(new Games { Id = 1, Name = "Battlefield 2042", Description = "First-Person-Shooter", Price = 300, PermitedAge = 18 });

            var existedGames = bdo.Where(x => x.Id == id).FirstOrDefault();

            bdo.Remove(existedGames);
        }

        public async Task<Games> FindById(int id)
        {
            var bdo = new List<Games>();

            bdo.Add(new Games { Id = 1, Name = "Battlefield 2042", Description = "First-Person-Shooter", Price = 300, PermitedAge = 18 });

            var existedGames = bdo.Where(x => x.Id == id).FirstOrDefault();

            return existedGames;
        }

        public async Task<List<Games>> ListAll()
        {
            var bdo = new List<Games>();

            bdo.Add(new Games { Id = 1, Name = "Battlefield 2042", Description = "First-Person-Shooter", Price = 300, PermitedAge = 18 });
            bdo.Add(new Games { Id = 2, Name = "Battlefield 5", Description = "First-Person-Shooter", Price = 250, PermitedAge = 16 });
            bdo.Add(new Games { Id = 3, Name = "Battlefield 1", Description = "First-Person-Shooter", Price = 200, PermitedAge = 14 });
            bdo.Add(new Games { Id = 4, Name = "Battlefield 4", Description = "First-Person-Shooter", Price = 150, PermitedAge = 12 });
            bdo.Add(new Games { Id = 5, Name = "Battlefield 3", Description = "First-Person-Shooter", Price = 100, PermitedAge = 10 });

            var allGames = bdo.ToList();

            return allGames;
        }

        public async Task Update(Games request)
        {
            var bdo = new List<Games>();

            bdo.Add(new Games { Id = 1, Name = "Battlefield 2042", Description = "First-Person-Shooter", Price = 300, PermitedAge = 18 });

            var existedGames = bdo.Where(x => x.Id == request.Id).FirstOrDefault();

            existedGames.Name = request.Name;
            existedGames.Description = request.Description;
            existedGames.Price = request.Price;
            existedGames.PermitedAge = request.PermitedAge;
        }
    }
}
