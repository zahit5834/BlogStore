using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticlesWithCategories();
        public AppUser GetAppUserByArticleId(int id);
        List<Article> GetTop3PopularArticles();
        List<Article> GetArticlesByAppUSer (string id);
        Article GetArticlesById(int categoryId);
        Article GetArticleBySlug(string slug);
        List<Article> GetArticlesByCategoryId(int categoryId);
    }
}
