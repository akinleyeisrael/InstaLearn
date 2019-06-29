namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourseCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CourseCategories (Name) VALUES('Mobile Development')");
            Sql("INSERT INTO CourseCategories (Name) VALUES('Game Development')");
            Sql("INSERT INTO CourseCategories (Name) VALUES('Desktop Development')");
            Sql("INSERT INTO CourseCategories (Name) VALUES('Machine Learning')");
            Sql("INSERT INTO CourseCategories (Name) VALUES('Data Science')");         
        }
        
        public override void Down()
        {
        }
    }
}
