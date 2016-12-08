using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MealDesignerPRO.Models;

namespace MealDesignerPRO.DAL
{
    public class MealDesignerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MealDesignerContext>
    {
        protected override void Seed(MealDesignerContext context)
        {
            var foodItems = new List<FoodItem>
            {
                new FoodItem {Name="Egg",Calories=200,Carbs=15,Fat=3,Type="Main",Time="Breakfast"}
            };

            foodItems.ForEach(f => context.FoodItems.Add(f));
            context.SaveChanges();

            var meal = new List<Meal>
            {
                new Meal {Name="Eggs",TotalCalories=200,TotalCarbs=15,TotalFat=3,Time="Breakfast"}
            };

            meal.ForEach(f => context.Meals.Add(f));
            context.SaveChanges();

            var refrigerators = new List<Refrigerator>
            {
                new Refrigerator {Quantity=1 , FoodItemID=1}
            };

            refrigerators.ForEach(f => context.Refrigerators.Add(f));
            context.SaveChanges();

            var recipes = new List<Recipe>
            {
                new Recipe {Quantity=2,FoodItemID=1,MealID=1}
            };

            recipes.ForEach(f => context.Recipes.Add(f));
            context.SaveChanges();
        }
    }
}