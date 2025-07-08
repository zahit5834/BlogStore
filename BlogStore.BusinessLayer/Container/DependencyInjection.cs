using BlogStore.BusinessLayer.Abstract;
using BlogStore.BusinessLayer.Concrete;
using BlogStore.BusinessLayer.Services;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Container
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<GoogleTranslateService, GoogleTranslateService>();
            services.AddScoped<ToxicityChecker, ToxicityChecker>();

            

            return services;
        }
    }
}
