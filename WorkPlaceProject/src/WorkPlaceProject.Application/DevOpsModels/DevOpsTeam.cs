using Newtonsoft.Json;

namespace WorkPlaceProject.Application.DevOpsModels
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DevOpsTeam
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "ProjectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "IdentityUrl")]
        public string IdentityUrl { get; set; }

        [JsonProperty(PropertyName = "ProjectName")]
        public string ProjectName { get; set; }

    }
}

// TODO add link to go to the team in devops