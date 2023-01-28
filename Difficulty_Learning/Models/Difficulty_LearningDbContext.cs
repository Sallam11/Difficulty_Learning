using Difficulty_Learning.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Difficulty_Learning.Models
{
    public class Difficulty_LearningDbContext : DbContext
    {
        public Difficulty_LearningDbContext(DbContextOptions<Difficulty_LearningDbContext> options) : base(options)
        {

        }


        ////    protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////    {
        ////        base.OnModelCreating(modelBuilder);
        ////        modelBuilder.Entity<Category_Course>().HasNoKey().ToSqlQuery("category_Courses");
        ////    }

        public DbSet<Category_Course> Category_Courses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Type> User_Types { get; set; }
        public DbSet<Watched_History> Watched_Historys { get; set; }



    

}

}
