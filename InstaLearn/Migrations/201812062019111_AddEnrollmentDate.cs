namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "EnrollmentDate");
        }
    }
}
