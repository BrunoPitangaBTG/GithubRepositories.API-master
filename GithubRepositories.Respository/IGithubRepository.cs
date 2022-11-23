using GithubRepositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepositories.Respository
{
    public interface IGithubRepository
    {
        Task<List<Item>> GetRepositories(string[] lenguages);
        Task<Item> GetRepository(string owner, string repo);
    }
}
