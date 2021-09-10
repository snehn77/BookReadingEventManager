namespace Nagarro.Sample.EntityDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookReadingEvent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Duration = c.Int(),
                        Description = c.String(),
                        OtherDetails = c.String(),
                        InvitedEmails = c.String(),
                        UserID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PostedComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookReadingEventID = c.Int(),
                        Comments = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookReadingEvent", t => t.BookReadingEventID)
                .Index(t => t.BookReadingEventID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User");
            DropForeignKey("dbo.PostedComment", "BookReadingEventID", "dbo.BookReadingEvent");
            DropIndex("dbo.PostedComment", new[] { "BookReadingEventID" });
            DropIndex("dbo.BookReadingEvent", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.PostedComment");
            DropTable("dbo.BookReadingEvent");
        }
    }
}
