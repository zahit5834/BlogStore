using BlogStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Context
{
    public class BlogContext:DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9D6BOD8;initial catalog=BlogStoreNightDb;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
