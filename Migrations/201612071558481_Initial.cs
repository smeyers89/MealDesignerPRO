namespace MealDesignerPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        FoodItemID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FoodItem", t => t.FoodItemID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.FoodItemID)
                .Index(t => t.MealID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredient", "MealID", "dbo.Meal");
            DropForeignKey("dbo.Ingredient", "FoodItemID", "dbo.FoodItem");
            DropIndex("dbo.Ingredient", new[] { "MealID" });
            DropIndex("dbo.Ingredient", new[] { "FoodItemID" });
            DropTable("dbo.Ingredient");
        }
    }
}
