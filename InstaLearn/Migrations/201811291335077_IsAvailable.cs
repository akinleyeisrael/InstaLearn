namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsAvailable");
        }
    }
}
