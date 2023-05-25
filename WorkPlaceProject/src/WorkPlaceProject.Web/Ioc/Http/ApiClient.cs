
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WorkPlaceProject.Application.DevOpsModels;

namespace WorkPlaceProject.Web.Ioc.Http
{
    public class ApiClient
    {
        private string projectId = "75d25206-8e06-44d8-a4d4-1c0d3cfe761b";
        private string organisationName = "kitcookdev12";
        private string projectName = "Work Place Project";
        public ApiClient()
        {
        }



        public async Task<IEnumerable<Team>> GetTeams()
        {
            TeamResponse result = await Get<TeamResponse>($"https://dev.azure.com/{organisationName}/_apis/projects/{projectId}/teams?api-version=2.0");

            return result.Value ?? new List<Team>();
        }

        public async Task<IEnumerable<Iteration>> GetIterations(Guid teamId)
        {
            IterationResponse result = await Get<IterationResponse>($"https://dev.azure.com/{organisationName}/{projectId}/{teamId}/_apis/work/teamsettings/iterations");

            return result.Value ?? new List<Iteration>();
        }

        public async Task<IEnumerable<T>> GetStories<T>()
        {
            return new List<T>();
        }

        private async Task<T?> Get<T>(string requestUri)
        {
            try
            {
                var personalaccesstoken = "idgdnu72rlgav6t5bq3nkasgetbgpmwwlvxotfi73j7qqaopi6xq";

                using HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", personalaccesstoken))));

                using HttpResponseMessage response = client.GetAsync(requestUri).Result;

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                responseBody.Replace("\"value\":", "");

                var rr = JsonConvert.DeserializeObject(responseBody);

                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }
        }

        public async Task GetProjects()
        {
            try
            {
                var personalaccesstoken = "idgdnu72rlgav6t5bq3nkasgetbgpmwwlvxotfi73j7qqaopi6xq";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = client.GetAsync(
                                "https://dev.azure.com/kitcookdev12/_apis/projects").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}

public class TeamResponse
{
    public List<Team> Value { get; set; }
}

public class IterationResponse
{
    public List<Iteration> Value { get; set; }
}