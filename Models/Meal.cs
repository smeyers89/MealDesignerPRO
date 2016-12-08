using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MealDesignerPRO.Models
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Total Calories")]
        public float TotalCalories { get; set; }

        [Display(Name = "Total Carbs")]
        public float TotalCarbs { get; set; }

        [Display(Name = "Total Fat")]
        public float TotalFat { get; set; }
        public string Time { get; set; }
        
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}