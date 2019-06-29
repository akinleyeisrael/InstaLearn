namespace InstaLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMakeDatetimedatetim2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
