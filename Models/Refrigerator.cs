using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MealDesignerPRO.Models
{
    public class Refrigerator
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int FoodItemID { get; set; }

        public virtual FoodItem FoodItem { get; set; }
    }
}