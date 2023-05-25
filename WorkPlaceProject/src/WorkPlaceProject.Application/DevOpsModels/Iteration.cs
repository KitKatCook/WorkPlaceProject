namespace WorkPlaceProject.Application.DevOpsModels
{
    public class Iteration
    {
		public Guid Id { get; set; }	

		public string Name { get; set; }	

		public string Path { get; set; }

		public Attribute Attribute { get; set; }

		public string Url { get; set; }
    }
}


public class Attributes
{
	public DateTime StartDate { get; set; }

	public DateTime EndDate { get; set; }

	public string TimeFrame { get; set; }
} 

// TODO add link to go to the iteration in devops