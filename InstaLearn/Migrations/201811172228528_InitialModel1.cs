namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                        CoursesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CoursesId, cascadeDelete: true)
                .Index(t => t.CoursesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CoursesId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CoursesId" });
            DropTable("dbo.Students");
        }
    }
}
