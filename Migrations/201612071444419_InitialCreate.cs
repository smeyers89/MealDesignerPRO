namespace MealDesignerPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Single(nullable: false),
                        Carbs = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Type = c.String(),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Refrigerator",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        FoodItemID = c.Int(nullable: false),
                        Meal_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FoodItem", t => t.FoodItemID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.Meal_ID)
                .Index(t => t.FoodItemID)
                .Index(t => t.Meal_ID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalCalories = c.Single(nullable: false),
                        TotalCarbs = c.Single(nullable: false),
                        TotalFat = c.Single(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refrigerator", "Meal_ID", "dbo.Meal");
            DropForeignKey("dbo.Refrigerator", "FoodItemID", "dbo.FoodItem");
            DropIndex("dbo.Refrigerator", new[] { "Meal_ID" });
            DropIndex("dbo.Refrigerator", new[] { "FoodItemID" });
            DropTable("dbo.Meal");
            DropTable("dbo.Refrigerator");
            DropTable("dbo.FoodItem");
        }
    }
}
