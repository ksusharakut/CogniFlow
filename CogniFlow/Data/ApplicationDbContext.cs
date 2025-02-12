using Microsoft.EntityFrameworkCore;
using CogniFlow.Models.Entities;
using CogniFlow.Configurations;

namespace CogniFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PasswordResetToken> PasswordResetToken { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<AnswerOption> AnswerOption { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordResetTokenConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerOptionConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
