namespace CBE.Feature.DiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimeissue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Topics", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsComments", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsComments", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsLikes", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsLikes", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsSubscribes", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TopicsSubscribes", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TopicsSubscribes", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopicsSubscribes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopicsLikes", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopicsLikes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopicsComments", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopicsComments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Topics", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Topics", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
