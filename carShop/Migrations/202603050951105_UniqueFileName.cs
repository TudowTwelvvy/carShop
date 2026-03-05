namespace carShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueFileName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarImage", "FileName", c => c.String(maxLength: 100));
            CreateIndex("dbo.CarImage", "FileName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CarImage", new[] { "FileName" });
            AlterColumn("dbo.CarImage", "FileName", c => c.String());
        }
    }
}
