using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public decimal MealPrice { get; set; }

        public Menu() { }

        public Menu(int mealNumber, string mealName, string mealDescription, List<Ingredient> ingredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            MealPrice = mealPrice;
        }
    }
}
