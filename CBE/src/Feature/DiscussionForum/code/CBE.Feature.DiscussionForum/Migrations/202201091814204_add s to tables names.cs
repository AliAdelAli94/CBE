namespace CBE.Feature.DiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstotablesnames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TopicComments", newName: "TopicsComments");
            RenameTable(name: "dbo.TopicLikes", newName: "TopicsLikes");
            RenameTable(name: "dbo.TopicSubscribes", newName: "TopicsSubscribes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TopicsSubscribes", newName: "TopicSubscribes");
            RenameTable(name: "dbo.TopicsLikes", newName: "TopicLikes");
            RenameTable(name: "dbo.TopicsComments", newName: "TopicComments");
        }
    }
}
