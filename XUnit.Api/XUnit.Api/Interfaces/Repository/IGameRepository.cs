using System.Collections.Generic;
using System.Threading.Tasks;
using XUnit.Api.Models;

namespace XUnit.Api.Interfaces.Repository
{
    public interface IGameRepository
    {
        public Task<Games> FindById(int id);
        public Task<List<Games>> ListAll();
        public Task Create(Games request);
        public Task Delete(int id);
        public Task Update(Games request);
    }
}
