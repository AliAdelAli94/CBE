namespace CBE.Feature.DiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TopicComments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TopicID = c.Guid(),
                        Content = c.String(),
                        TopicCommentID = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TopicComments", t => t.TopicCommentID)
                .ForeignKey("dbo.Topics", t => t.TopicID)
                .Index(t => t.TopicID)
                .Index(t => t.TopicCommentID);
            
            CreateTable(
                "dbo.TopicLikes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TopicID = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.TopicSubscribes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TopicID = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID)
                .Index(t => t.TopicID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicSubscribes", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.TopicLikes", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.TopicComments", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.TopicComments", "TopicCommentID", "dbo.TopicComments");
            DropIndex("dbo.TopicSubscribes", new[] { "TopicID" });
            DropIndex("dbo.TopicLikes", new[] { "TopicID" });
            DropIndex("dbo.TopicComments", new[] { "TopicCommentID" });
            DropIndex("dbo.TopicComments", new[] { "TopicID" });
            DropTable("dbo.TopicSubscribes");
            DropTable("dbo.TopicLikes");
            DropTable("dbo.TopicComments");
            DropTable("dbo.Topics");
        }
    }
}
