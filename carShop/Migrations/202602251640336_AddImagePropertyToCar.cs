namespace carShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePropertyToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "ImagePath");
        }
    }
}
