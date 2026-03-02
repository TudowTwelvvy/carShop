namespace carShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Car", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Car", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Car", "Description", c => c.String());
            AlterColumn("dbo.Car", "Name", c => c.String());
        }
    }
}
