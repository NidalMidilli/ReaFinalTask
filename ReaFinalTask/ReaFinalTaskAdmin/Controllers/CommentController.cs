using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ReaFinalTaskAdmin.Controllers
{
    public class CommentController : Controller
    {
        ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var result = commentService.ListAllComments();
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
        public IActionResult Add(Comment comment)
        {
            CommentValidator commentValidator = new CommentValidator();
            ValidationResult results = commentValidator.Validate(comment);
            if (results.IsValid)
            {
                commentService.AddComment(comment);
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
            var result = commentService.GetCommentById(id);
            return View(result);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Update(Comment comment)
        {
            CommentValidator commentValidator = new CommentValidator();
            ValidationResult results = commentValidator.Validate(comment);
            if (results.IsValid)
            {
                commentService.UpdateComment(comment);
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
            var result = commentService.GetCommentById(id);
            commentService.DeleteComment(result);
            return RedirectToAction("Index");
        }
    }
}
