using Newtonsoft.Json;

namespace Assignment_4.Entity
{
	public class TaskEntity
	{
		//Mandatory Fields
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
		public string Uid { get; set; }

		[JsonProperty(PropertyName = "dType", NullValueHandling = NullValueHandling.Ignore)]
		public string DocumentType { get; set; }

		[JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
		public string CreatedBy { get; set; }

		[JsonProperty(PropertyName = "createdByName", NullValueHandling = NullValueHandling.Ignore)]
		public string CreatedByName { get; set; }

		[JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime CreatedOn { get; set; }

		[JsonProperty(PropertyName = "updateBy", NullValueHandling = NullValueHandling.Ignore)]
		public string UpdateBy { get; set; }

		[JsonProperty(PropertyName = "updateByName", NullValueHandling = NullValueHandling.Ignore)]
		public string UpdateByName { get; set; }

		[JsonProperty(PropertyName = "updateOn", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime UpdateOn { get; set; }

		[JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
		public int Version { get; set; }

		[JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
		public Boolean Active { get; set; }

		[JsonProperty(PropertyName = "archieved", NullValueHandling = NullValueHandling.Ignore)]
		public Boolean Archieved { get; set; }


		//Important fields
		[JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
		public int TaskId { get; set; }

		[JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

	}
}
