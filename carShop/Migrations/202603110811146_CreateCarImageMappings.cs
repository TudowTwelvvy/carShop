namespace carShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCarImageMappings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarImageMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                        CarImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.CarImage", t => t.CarImageID, cascadeDelete: true)
                .Index(t => t.CarID)
                .Index(t => t.CarImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarImageMapping", "CarImageID", "dbo.CarImage");
            DropForeignKey("dbo.CarImageMapping", "CarID", "dbo.Car");
            DropIndex("dbo.CarImageMapping", new[] { "CarImageID" });
            DropIndex("dbo.CarImageMapping", new[] { "CarID" });
            DropTable("dbo.CarImageMapping");
        }
    }
}
