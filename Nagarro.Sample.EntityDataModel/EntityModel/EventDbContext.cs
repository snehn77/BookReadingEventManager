using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nagarro.Sample.EntityDataModel
{
    public class EventDbContext : DbContext
    {
        public EventDbContext():base("BookReadingEventDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BookReadingEvent> BookReadingEvents { get; set; }
        public DbSet<PostedComment> PostedComments { get; set; }

    }
}
