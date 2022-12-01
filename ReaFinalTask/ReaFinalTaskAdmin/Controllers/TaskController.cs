using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;

namespace ReaFinalTaskAdmin.Controllers
{
    public class TaskController : Controller
    {
        ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var result = taskService.GetTaskWithComments();
            return View(result);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Add(EntTask task)
        {
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult results = taskValidator.Validate(task);
            if (results.IsValid)
            {
                taskService.AddTask(task);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            var result = taskService.GetTaskById(id);
            return View(result);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Update(EntTask task)
        {
            TaskValidator taskValidator = new TaskValidator();
            ValidationResult results = taskValidator.Validate(task);
            if (results.IsValid)
            {
                taskService.UpdateTask(task);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var result = taskService.GetTaskById(id);
            taskService.DeleteTask(result);
            return RedirectToAction("Index");
        }
    }
}
