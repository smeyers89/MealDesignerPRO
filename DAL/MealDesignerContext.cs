using MealDesignerPRO.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MealDesignerPRO.DAL
{
    public class MealDesignerContext : DbContext
    {
        public MealDesignerContext() : base("MealDesignerContext")
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Refrigerator> Refrigerators { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}