namespace MealDesignerPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ingredient", newName: "Recipe");
            DropForeignKey("dbo.Refrigerator", "Meal_ID", "dbo.Meal");
            DropIndex("dbo.Refrigerator", new[] { "Meal_ID" });
            DropColumn("dbo.Refrigerator", "Meal_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refrigerator", "Meal_ID", c => c.Int());
            CreateIndex("dbo.Refrigerator", "Meal_ID");
            AddForeignKey("dbo.Refrigerator", "Meal_ID", "dbo.Meal", "ID");
            RenameTable(name: "dbo.Recipe", newName: "Ingredient");
        }
    }
}
