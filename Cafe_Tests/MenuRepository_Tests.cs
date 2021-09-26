using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_Tests
{
    [TestClass]
    public class MenuRepository_Tests
    {
        private MenuRepository _repo;
        private Menu _item;
        private List<Ingredient> _ingredient;

        [TestInitialize]
        public void Arrange()
        {
            _ingredient = new List<Ingredient>();
            Ingredient beefPatty = new Ingredient("Beef Patty");
            Ingredient bun = new Ingredient("Bun");
            Ingredient cheese = new Ingredient("Cheese");
            _ingredient.Add(beefPatty);
            _ingredient.Add(bun);
            _ingredient.Add(cheese);
            _repo = new MenuRepository();
            _item = new Menu(1, "Cheeseburger", "A juicy all beef patty.", _ingredient, 4.99m);

            _repo.CreateMenuItem(_item);
        }

        [TestMethod]
        public void CreateMenuItem_ShouldGetNotNull()
        {
            // Arrange
            Menu menuItem = new Menu();
            menuItem.MealNumber = 2;

            // Act
            _repo.CreateMenuItem(menuItem);
            Menu menuItemFromList = _repo.FindItemByNumber(2);

            // Assert
            Assert.IsNotNull(menuItemFromList);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {

            bool deleteItem = _repo.DeleteMenuItem(1);

            Assert.IsTrue(deleteItem);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnFalse()
        {
            bool deleteItem = _repo.DeleteMenuItem(3);

            Assert.IsFalse(deleteItem);
        }
    }
}
