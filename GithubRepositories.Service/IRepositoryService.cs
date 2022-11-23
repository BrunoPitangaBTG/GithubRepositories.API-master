using GithubRepositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepositories.Service
{
    public interface IRepositoryService
    {
        Task<List<Item>> ListRepositoriesWithLenguages();
        Task<Item> RepositoryDetail(string owner, string repoName);
    }
}
