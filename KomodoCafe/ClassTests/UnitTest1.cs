using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komodo_Cafe_Classes;
using System.Collections.Generic;

namespace ClassTests
{
    [TestClass]
    public class MenuRepositoryTests
    {

        //[TestInitialize]
        //public void Arrange()
        //{


        //}
        [TestMethod]
        public void CreateNewMenuItem()
        {

            //Arrange
            MenuItem _menuItem = new MenuItem("1", "Cheeseburger", "Burger with Cheese", new List<string> { "patty", "bun", "cheese" }, "5.99");

            MenuRepository _menuRepo = new MenuRepository();

            List<MenuItem> menu = _menuRepo.GetMenu();

            //Act
            _menuRepo.CreateNewMenuItem(_menuItem);

            bool listContainsItem = menu.Contains(_menuItem);

            //Assert

            Assert.IsTrue(listContainsItem);
        }

        [TestMethod]
        public void TestForDeleteMenuItem()
        {
            //Arrange
            MenuItem _menuItem = new MenuItem("1", "Cheeseburger", "Burger with Cheese", new List<string> { "patty", "bun", "cheese" }, "5.99");

            MenuRepository _menuRepo = new MenuRepository();

            List<MenuItem> menu = _menuRepo.GetMenu();

            menu.Add(_menuItem);

            //Act

            _menuRepo.DeleteMenuItem(_menuItem.ItemNumber);

            bool listContainsItem = menu.Contains(_menuItem);

            //Assert

            Assert.IsFalse(listContainsItem);

        }

        [TestMethod]
        public void TestGetMenuItemByNumber()
        {
        //Arrange
            MenuItem _menuItem = new MenuItem("1", "Cheeseburger", "Burger with Cheese", new List<string> { "patty", "bun", "cheese" }, "5.99");

        MenuRepository _menuRepo = new MenuRepository();

        List<MenuItem> menu = _menuRepo.GetMenu();

        menu.Add(_menuItem);


            //Act
            MenuItem itemByNumber =_menuRepo.GetMenuItemByNumber(_menuItem.ItemNumber);

            //Assert
            Assert.AreEqual(itemByNumber, _menuItem);
            }

        [TestMethod]
        public void TestViewMenuItemsIngredients()
        {
            //Arrange
            MenuItem _menuItem = new MenuItem("1", "Cheeseburger", "Burger with Cheese", new List<string> { "patty", "bun", "cheese" }, "5.99");

            MenuRepository _menuRepo = new MenuRepository();

            List<MenuItem> menu = _menuRepo.GetMenu();

            //Act
           List<string> retrievedIngredients = _menuRepo.ViewIngredients(_menuItem);

            //Assert
            Assert.AreEqual(retrievedIngredients, _menuItem.Ingredients);

        }

        [TestMethod]
        public void TestAddIngredientsToItem()
        {
            //Arrange
            MenuItem _menuItem = new MenuItem("1", "Cheeseburger", "Burger with Cheese", new List<string> { "patty", "bun", "cheese" }, "5.99");

            MenuRepository _menuRepo = new MenuRepository();

            // List<MenuItem> menu = _menuRepo.GetMenu();

           List<string> addedIngredients = _menuRepo.AddIngredientToMenuItem(_menuItem, "lettuce, tomato, pickle");

            Assert.AreEqual(6, addedIngredients.Count);

        }

        [TestMethod]
        public void TestSeedMenu()
        {
            //Arrange
            MenuRepository _menuRepo = new MenuRepository();

           List<MenuItem> menu = _menuRepo.GetMenu();
            int initialCount = menu.Count;

            //Act
            _menuRepo.SeedMenu();
            int postTestCount = menu.Count;
            bool initialIsLess = initialCount < postTestCount;

            Assert.IsTrue(initialIsLess);


        }

            

            










    }
}
