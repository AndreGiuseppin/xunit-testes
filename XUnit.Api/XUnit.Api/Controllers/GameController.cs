using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XUnit.Api.Interfaces.Services;
using XUnit.Api.Models;

namespace XUnit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("create-game")]
        public async Task<IActionResult> Create(Games request)
        {
            var result = await _gameService.CreateGame(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("update-game")]
        public async Task<IActionResult> Update(Games request)
        {
            var result = await _gameService.UpdateGame(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("list-games")]
        public async Task<IActionResult> List()
        {
            var result = await _gameService.ListGames();

            return Ok(result);
        }

        [HttpPost]
        [Route("delete-game")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gameService.DeleteGame(id);

            return Ok(result);
        }
    }
}
