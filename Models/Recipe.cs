using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealDesignerPRO.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int FoodItemID { get; set; }
        public int MealID { get; set; }

        public virtual FoodItem FoodItem { get; set; }
        public virtual Meal Meal { get; set; }
    }
}