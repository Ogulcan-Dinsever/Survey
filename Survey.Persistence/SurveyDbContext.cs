using Microsoft.EntityFrameworkCore;
using Survey.Domain.SurveyAggregate;

namespace Survey.Persistence
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Surveys> Survey { get; set; }
        public DbSet<Answers> Answer { get; set; }
    }
}
