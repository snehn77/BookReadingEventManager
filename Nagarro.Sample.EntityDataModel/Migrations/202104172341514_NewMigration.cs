namespace Nagarro.Sample.EntityDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookReadingEvent", newName: "BookReadingEvents");
            RenameTable(name: "dbo.PostedComment", newName: "PostedComments");
            RenameTable(name: "dbo.User", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.PostedComments", newName: "PostedComment");
            RenameTable(name: "dbo.BookReadingEvents", newName: "BookReadingEvent");
        }
    }
}
