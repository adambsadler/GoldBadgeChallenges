using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        public Ingredient() { }
        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
