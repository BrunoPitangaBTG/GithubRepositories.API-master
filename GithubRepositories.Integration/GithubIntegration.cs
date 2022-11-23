using GithubRepositories.Model;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GithubRepositories.Integration
{
    public class GithubIntegration : IGithubIntegration
    {
        private readonly HttpClient _httpClient;

        public GithubIntegration(HttpClient httpClient)
        {
            _httpClient = httpClient;

            //TODO: LER DO APPSETTINGS
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
          
            // The GitHub API requires two headers.
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/vnd.github.v3+json");
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");
        }

        public async Task<Item> GetRepository(string owner, string repoName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"repos/{owner}/{repoName}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Item>(content);
            }
            catch (System.Net.Http.HttpRequestException ex) when (ex.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new Exception($"Repositorio: {repoName} e owner: {owner} não encontrados");
            }
            catch (Exception)
            {

                throw new Exception($"Não foi possivel consultar a repositorio: ${repoName}");
            }
        }

        public async Task<GithubResponse> GetRespositoriesByFilter(string filter)
        {
            try
            {
                var response = await _httpClient.GetAsync($"search/repositories?q={filter}&sort=stars&order=desc&per_page=5");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<GithubResponse>(content);
            }
            catch (Exception)
            {

                throw new Exception("Não foi possivel consultar a Lista de repositorios");
            }
          
        }
    }
}
