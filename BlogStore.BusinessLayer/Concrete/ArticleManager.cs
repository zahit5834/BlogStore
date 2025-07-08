using BlogStore.BusinessLayer.Abstract;
using BlogStore.BusinessLayer.Services;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly ToxicityChecker _toxicityChecker;
        private readonly GoogleTranslateService _translateService;

        public ArticleManager(IArticleDal articleDal, GoogleTranslateService translateService, ToxicityChecker toxicityChecker)
        {
            _articleDal = articleDal;
            var googleApiKey = "AIzaSyDBeRNB4qRGBXuy4JZxpUpu9WqR9Hz8WGA";
            _translateService = translateService;
            _toxicityChecker = toxicityChecker;
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public AppUser TGetAppUserByArticleId(int id)
        {
            return _articleDal.GetAppUserByArticleId(id);
        }

        public List<Article> TGetArticlesByAppUSer(string id)
        {
            return _articleDal.GetArticlesByAppUSer(id);
        }

        public List<Article> TGetArticlesWithCategories()
        {
            return _articleDal.GetArticlesWithCategories();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetTop3PopularArticles()
        {
            return _articleDal.GetTop3PopularArticles();
        }

        public void TInsert(Article entity)
        {
            if (entity.Title.Length >= 10 && entity.Title.Length <= 100 && entity.Description != "" && entity.ImageUrl.Contains("a"))
            {
                _articleDal.Insert(entity);
            }
            else
            {
                // hata mesajı
            }
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
        public Article TGetArticlesById(int id)
        {
            return _articleDal.GetArticlesById(id);
        }

        public Article TGetArticleBySlug(string slug)
        {
            var s = _articleDal.GetArticleBySlug(slug);
            return s;
        }

        public List<Article> TGetArticlesByCategoryId(int categoryId)
        {
            return _articleDal.GetArticlesByCategoryId(categoryId);
        }
    }
}
