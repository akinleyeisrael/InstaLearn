namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "InstructorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "InstructorId", c => c.Int(nullable: false));
        }
    }
}
