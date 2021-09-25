using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfItems = new List<Menu>();
        private List<Ingredient> _listOfIngredients = new List<Ingredient>();
        private int _countId;

        // Create
        public void CreateMenuItem(Menu menuItem)
        {
            _listOfItems.Add(menuItem);
        }

        public void CreateIngredient(Ingredient newIngredient)
        {
            newIngredient.IngredientId = ++_countId;
            _listOfIngredients.Add(newIngredient);
        }

        // Read
        public List<Menu> GetMenuItems()
        {
            return _listOfItems;
        }

        public List<Ingredient> GetItemIngredients(Menu item)
        {
            return item.Ingredients;
        }

        // Delete
        public bool DeleteMenuItem(int mealNumber)
        {
            Menu item = FindItemByNumber(mealNumber);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item);

            if(initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public Menu FindItemByNumber(int mealNumber)
        {
            foreach(Menu item in _listOfItems)
            {
                if(item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
