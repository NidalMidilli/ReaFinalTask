using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReaFinalTaskAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        [HttpGet]
        public List<EntTask> Get()
        {
            return taskService.GetTaskWithComments();

        }
        [HttpPost]

        public int Post([FromBody] EntTask task)
        {
            return taskService.AddTask(task);
        }
        [HttpPut]
        public int Put([FromBody] EntTask task)
        {
            return taskService.UpdateTask(task);
        }
        [HttpDelete]
        public int Delete(int id)
        {
            var result = taskService.GetTaskById(id);
            return taskService.DeleteTask(result);

        }
        [HttpGet("{id}")]
        public EntTask Get(int id)
        {
            return taskService.GetTaskById(id);
        }
    }
}