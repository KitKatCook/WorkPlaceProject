using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WorkPlaceProject.Application.DevOpsModels;

namespace WorkPlaceProject.Web.Ioc.Http
{
    public class ApiClient
    {
        private readonly string ProjectId = "75d25206-8e06-44d8-a4d4-1c0d3cfe761b";
        private readonly string OrganisationName = "kitcookdev12";

        private string PAT = "";
        public ApiClient()
        {
        }


        public async Task<IEnumerable<DevOpsTeam>> GetTeams()
        {
            TeamResponse result = await Get<TeamResponse>($"https://dev.azure.com/{OrganisationName}/_apis/projects/{ProjectId}/teams?api-version=2.0");

            return result.Value ?? new List<DevOpsTeam>();
        }

        public async Task<IEnumerable<Iteration>> GetIterations(Guid teamId)
        {
            IterationResponse result = await Get<IterationResponse>($"https://dev.azure.com/{OrganisationName}/{ProjectId}/{teamId}/_apis/work/teamsettings/iterations");

            return result.Value ?? new List<Iteration>();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItems(Guid teamId, Guid iterationId)
        {
            WorkItemRelationsResponse workItemRelationsResponse = await Get<WorkItemRelationsResponse>($"https://dev.azure.com/{OrganisationName}/{ProjectId}/{teamId}/_apis/work/teamsettings/iterations/{iterationId}/workitems?api-version=7.1-preview.1");

            List<WorkItem> workItems = new List<WorkItem>();

            if(workItemRelationsResponse is not null 
                && workItemRelationsResponse.WorkItemRelations is not null)
            {
                foreach (WorkItemRelation workItemResponse in workItemRelationsResponse.WorkItemRelations)
                {
                    WorkItem? workItem = await GetWorkItem(workItemResponse.Target.Id);

                    if (workItem is not null)
                    {
                        workItems.Add(workItem);
                    }
                }
            }

            return workItems;
        }

        public async Task<WorkItem?> GetWorkItem(int workItemId)
        {
            WorkItem? workItem = await Get<WorkItem>($"https://dev.azure.com/{OrganisationName}/_apis/wit/workItems/{workItemId}");

            return workItem;
        }

        public async Task<WorkItem?> PatchWorkItemStoryPoints(int storyPoints, int workItemId)
        {
            PatchWorkItem patchWorkItem = new PatchWorkItem
            {
                WorkItemField = new List<WorkItemField>()
                {
                    new WorkItemField
                    {
                        Operation = "replace",
                        Path = "/fields/Microsoft.VSTS.Scheduling.StoryPoints",
                        Value = storyPoints
                    }
                }
            };

            var serialisedObject = JsonConvert.SerializeObject(patchWorkItem.WorkItemField);

            StringContent content = new StringContent(serialisedObject, Encoding.UTF8, "application/json-patch+json");

            WorkItem? workItem = await Patch<WorkItem>($"https://dev.azure.com/{OrganisationName}/_apis/wit/workItems/{workItemId}?api-version=2.0", content);

            return workItem;
        }

        private async Task<T?> Get<T>(string requestUri)
        {
            try
            {
                using HttpClient client = new();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", PAT))));

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

        private async Task<T?> Patch<T>(string requestUri, HttpContent? content)
        {
            try
            {
                using HttpClient client = new();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json-patch+json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", PAT))));

                using HttpResponseMessage response = client.PatchAsync(requestUri, content).Result;

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }
        }
    }
}

public class TeamResponse
{
    public List<DevOpsTeam> Value { get; set; }
}

public class IterationResponse
{
    public List<Iteration> Value { get; set; }
}
public class WorkItemRelationsResponse
{
    [JsonProperty(PropertyName = "workItemRelations")]
    public List<WorkItemRelation> WorkItemRelations { get; set; }
}

public class WorkItemRelation
{
    [JsonProperty(PropertyName = "rel")]
    public string Relationship { get; set; }

    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

    [JsonProperty(PropertyName = "target")]
    public WorkItemRelationsTarget Target { get; set; }		
}

public class WorkItemRelationsTarget
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }
}


public class PatchWorkItem
{
    public List<WorkItemField> WorkItemField { get; set; }
}

public class WorkItemField
{
    [JsonProperty(PropertyName = "op")]
    public string Operation { get; set; }

    [JsonProperty(PropertyName = "value")]
    public int Value { get; set; }

    [JsonProperty(PropertyName = "path")]
    public string Path { get; set; }
}