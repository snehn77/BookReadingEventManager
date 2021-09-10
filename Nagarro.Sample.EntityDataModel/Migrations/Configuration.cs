namespace Nagarro.Sample.EntityDataModel.Migrations
{
    using Nagarro.Sample.Shared;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventDbContext context)
        {
            var users = new List<User>
            {
            new User{Email="def.abc@gmail.com",FirstName="abc",LastName="def",Password="mypass",ModifiedOn=DateTime.Now,CreatedOn=DateTime.Now}
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var events = new List<BookReadingEvent>
            {
                new BookReadingEvent{ModifiedOn = DateTime.Now, CreatedOn = DateTime.Now,BookTitle = "SnehBook",Date=DateTime.Now,Location="Best PG",StartTime="1",Type=EventType.Public,UserID=1}
            };
            events.ForEach(s => context.BookReadingEvents.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
