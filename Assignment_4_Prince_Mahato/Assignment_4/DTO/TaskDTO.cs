using Newtonsoft.Json;

namespace Assignment_4.DTO
{
	public class TaskDTO
	{
		//Important fields
		[JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
		public int TaskId { get; set; }

		[JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }
	}
}
