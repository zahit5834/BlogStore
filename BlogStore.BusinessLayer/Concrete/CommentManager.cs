using BlogStore.BusinessLayer.Abstract;
using BlogStore.BusinessLayer.Services;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IConfiguration config;
        private readonly GoogleTranslateService _translateService;
        private readonly ToxicityChecker _toxicityChecker;

        public CommentManager(ICommentDal commentDal, GoogleTranslateService translateService, ToxicityChecker toxicityChecker)
        {
            _commentDal = commentDal;
            _translateService = translateService;
            _toxicityChecker = toxicityChecker;
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id);
        }

        public List<Comment> TGetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentsByArticle(int id)
        {
            return _commentDal.GetCommentsByArticle(id);
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public async Task TInsertAsync(Comment comment)
        {
            string translatedComment = await _translateService.TraslateToEngAsync(comment.CommentDetail);
            
            // 2. İngilizce yorumu toksisite için kontrol et
            bool isToxic = await _toxicityChecker.IsToxicAsync(translatedComment);
            Console.WriteLine(comment.CommentDetail);
            Console.WriteLine(translatedComment);
            Console.WriteLine(isToxic.ToString());
            comment.IsValid = !isToxic;

            await _commentDal.InsertAsync(comment);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
