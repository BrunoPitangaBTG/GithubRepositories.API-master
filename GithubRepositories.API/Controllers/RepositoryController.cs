using GithubRepositories.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GithubRepositories.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public RepositoryController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet("repos")]
        public async Task<IActionResult> GetAllRepositoresLenguages()
        {
            try
            {
                return Ok(await _repositoryService.ListRepositoriesWithLenguages());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("repo-detail")]
        public async Task<IActionResult> GetAllRepositoresLenguages([Required][FromQuery(Name = "owner")] string owner, [Required][FromQuery(Name = "repo")] string repo)
        {
            try
            {
                return Ok(await _repositoryService.RepositoryDetail(owner, repo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
