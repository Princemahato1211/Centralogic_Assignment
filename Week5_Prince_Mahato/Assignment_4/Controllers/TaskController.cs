using Assignment_4.DTO;
using Assignment_4.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace Assignment_5.Controllers
{
	[Route("api/[controller][action]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		string URI = "https://localhost:8081";
		string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
		string Database = "TaskDatabse";
		string Container = "TaskContainer";

		public readonly Microsoft.Azure.Cosmos.Container _container;

        public TaskController()
        {
			CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);  // To Connect with Azure cosmos DB Emulator
			Database database = cosmosClient.GetDatabase(Database);    // To Connect With Database
			_container = database.GetContainer(Container);          // To Connect With Container
        }

		[HttpPost]
		public async Task<IActionResult> AddTask(TaskDTO task)
		{
			try
			{
				TaskEntity taskEntity = new TaskEntity();

				//important fields
				taskEntity.TaskId = task.TaskId;
				taskEntity.Title = task.Title;
				taskEntity.Description = task.Description;

				//manadatory fields
				taskEntity.Id = Guid.NewGuid().ToString();
				taskEntity.Uid = taskEntity.Id;
				taskEntity.DocumentType = "AllType";
				taskEntity.CreatedBy = "Prince UID";
				taskEntity.CreatedByName = "Prince";
				taskEntity.CreatedOn = DateTime.Now;
				taskEntity.UpdateBy = "Prince UID";
				taskEntity.UpdateByName = "Prince";
				taskEntity.UpdateOn = DateTime.Now;
				taskEntity.Version = 1;
				taskEntity.Active = true;
				taskEntity.Archieved = false;

				TaskEntity output = await _container.CreateItemAsync(taskEntity);

				return Ok(output+"Data Added Succesfully");
			}catch(Exception e)
			{
				return BadRequest("Data Adding Failed" + e);
			}
		}

		[HttpPost]
		public IActionResult GetAllTask()
		{
			try
			{
				var taskList = _container.GetItemLinqQueryable<TaskEntity>(true).Where(p => p.Archieved == false).AsEnumerable().ToList();
				return Ok(taskList);  
			}
			catch (Exception e)
			{
				return BadRequest("Error");
			}
		}

		[HttpPost]
		public IActionResult GetTaskById(string id)
		{
			try
			{
				var task = _container.GetItemLinqQueryable<TaskEntity>(true).Where(p => p.Id == id).AsEnumerable().FirstOrDefault();

				TaskDTO t1 = new TaskDTO();
				t1.TaskId = task.TaskId;
				t1.Title = task.Title;
				t1.Description = task.Description;

				return Ok(t1);
			}
			catch (Exception e)
			{
				return BadRequest("Error");
			}
		}

		[HttpPut]
		public async Task<TaskEntity> UpdateTask(string id,TaskDTO task)
		{
			var item = _container.GetItemLinqQueryable<TaskEntity>(true).Where(p => p.Id == id).AsEnumerable().FirstOrDefault();

			TaskEntity maintTask = new TaskEntity();
			maintTask.TaskId = task.TaskId;
			maintTask.Title = task.Title;
			maintTask.Description = task.Description;

			maintTask.Id = id;
			maintTask.Uid = item.Uid;
			maintTask.DocumentType = item.Uid;
			maintTask.CreatedBy = item.CreatedBy;
			maintTask.CreatedByName = item.CreatedByName;
			maintTask.CreatedOn = item.CreatedOn;
			maintTask.UpdateBy = "New Person UID";
			maintTask.UpdateByName = "New Person";
			maintTask.UpdateOn = DateTime.Now;
			maintTask.Version = 1;
			maintTask.Active = true;
			maintTask.Archieved = false;

			var result = await _container.ReplaceItemAsync(maintTask,id);

			return result;
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTask(string id)
		{
			var item = _container.GetItemLinqQueryable<TaskEntity>(true).Where(p => p.Id == id).AsEnumerable().FirstOrDefault();
			if(item == null)
			{
				return BadRequest("No Document is Available with id  = " + id);
			}

			var result = await _container.DeleteItemStreamAsync(id,new PartitionKey(id));
			return Ok("Deleted Succesfully");
		}
	}
}




