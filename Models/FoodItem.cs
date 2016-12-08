using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealDesignerPRO.Models
{
    public class FoodItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }

        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}