using GithubRepositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepositories.Integration
{
    public interface IGithubIntegration
    {
        Task<GithubResponse> GetRespositoriesByFilter(string filter);
        Task<Item> GetRepository(string owner, string repoName);
    }
}
