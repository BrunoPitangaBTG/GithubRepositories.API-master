using GithubRepositories.Integration;
using GithubRepositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepositories.Respository
{
    public class GithubRepository : IGithubRepository
    {
        private readonly IGithubIntegration _githubIntegration;

        public GithubRepository(IGithubIntegration githubIntegration)
        {
            _githubIntegration = githubIntegration;
        }

        public async Task<List<Item>> GetRepositories(string[] lenguages) =>
            (await _githubIntegration.GetRespositoriesByFilter(string.Join("+", lenguages.Select(x => $"language:{x}"))))?.items;

        public async Task<Item> GetRepository(string owner, string repo) =>
           await _githubIntegration.GetRepository(owner, repo);
    }
}
