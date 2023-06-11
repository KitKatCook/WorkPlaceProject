using Newtonsoft.Json;

namespace WorkPlaceProject.Application.DevOpsModels
{
	public class WorkItem
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "rev")]
		public int Revision { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public Fields Fields { get; set; }
    }

	public class Fields
	{
		[JsonProperty(PropertyName = "System.AreaPath")]
		public string AreaPath { get; set; }

        [JsonProperty(PropertyName = "System.TeamProject")]
		 public string TeamProject { get; set; }

        [JsonProperty(PropertyName = "System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty(PropertyName = "System.State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "System.Reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "System.CommentCount")]
        public int CommentCount { get; set; }

        [JsonProperty(PropertyName = "System.Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "System.BoardColumn")]
        public string BoardColumn { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.StoryPoints")]
        public string StoryPoints { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.Effort")]
        public string Effort { get; set; }

        [JsonProperty(PropertyName = "System.Description")]
        public string Description { get; set; } 
        
        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.AcceptanceCriteria")]
        public string AcceptanceCriteria { get; set; }
	}

}