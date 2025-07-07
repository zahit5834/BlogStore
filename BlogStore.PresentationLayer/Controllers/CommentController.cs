using BlogStore.BusinessLayer.Abstract;
using BlogStore.DataAccessLayer.Dtos;
using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogStore.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult CommentList()
        {
            var values = _commentService.TGetAll();
            return View(values);
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateComment([FromBody] CreateCommentViewModel commentModel)
        {

            if(ModelState.IsValid && commentModel != null && !string.IsNullOrEmpty(commentModel.CommentDetail) && commentModel.ArticleId > 0)
            {
                var comment = new Comment
                {
                    CommentDetail = commentModel.CommentDetail,
                    ArticleId = commentModel.ArticleId,
                    IsValid = true,

                };
                Console.WriteLine(User.FindFirst(ClaimTypes.Name)?.Value ?? "Anonim");
                Console.WriteLine(commentModel.CommentDetail);
                Console.WriteLine(commentModel.ArticleId);
                comment.CommentDate = DateTime.Now;

                // Kullanıcı bilgisi ekle (isteğe bağlı)
                comment.AppUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;



                _commentService.TInsert(comment);

                return Json(new { success = true, message = "Yorum eklendi." });
            }
            else
            {
                return Json(new { success = false, message = "Geçersiz yorum verisi." });
            }
           
        }
        
        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction("CommentList");
        }
        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            var value = _commentService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.IsValid = true;
            _commentService.TUpdate(comment);
            return RedirectToAction("CommentList");
        }
    }
}
