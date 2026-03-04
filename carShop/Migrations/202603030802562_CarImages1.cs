namespace carShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarImages1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductImage", newName: "CarImage");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CarImage", newName: "ProductImage");
        }
    }
}
