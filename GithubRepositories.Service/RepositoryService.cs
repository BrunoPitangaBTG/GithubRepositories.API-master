using GithubRepositories.Model;
using GithubRepositories.Respository;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepositories.Service
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IGithubRepository  _githubRepository;

        public RepositoryService(IGithubRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }

        public async Task<List<Item>> ListRepositoriesWithLenguages()
        {
            string[] lenguages = new[] { "typescript", "c#", "java", "css", "python" };

            return await _githubRepository.GetRepositories(lenguages);
        }

        public async Task<Item> RepositoryDetail(string owner, string repoName)
        {
            if (string.IsNullOrEmpty(owner))
                throw new ArgumentNullException("Owner não foi informado");

            if (string.IsNullOrEmpty(repoName))
                throw new ArgumentNullException("O Nome de repositorio não foi informado");

            return await _githubRepository.GetRepository(owner, repoName);
        }
    }
}
