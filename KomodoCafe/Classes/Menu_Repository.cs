using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Classes
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();
        // Create new menu item
        public void CreateNewMenuItem(MenuItem menuItem)
        {
            int initialCount = _menu.Count;
            _menu.Add(menuItem);
            menuItem.Ingredients = new List<string>();
            if (initialCount < _menu.Count)
            {
                Console.WriteLine($"{menuItem.Name} successfully added to Menu");
            }
            else { Console.WriteLine($"{menuItem.Name} was not added to Menu"); }
                

        }



        // Read Menu
        public List<MenuItem> GetMenu()
        {
            return _menu;
        }


        public void DeleteMenuItem(string menuItem)
        {
            int initialMenuItemCount = _menu.Count;

            MenuItem itemToDelete = GetMenuItemByNumber(menuItem);

            _menu.Remove(itemToDelete);

            if (_menu.Count < initialMenuItemCount)
            {
                Console.WriteLine($"{ itemToDelete.Name} has been removed from the menu." );
            }
            else
            { Console.WriteLine($"{itemToDelete.Name} was not removed, please try again!"); }
            ;

        }
        // VIEW MENU ITEM DETAILS???

        //Make Helper Method to pair user input's Item Number
        // with MenuItem menuItem

        public MenuItem GetMenuItemByNumber(string itemNumber)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.ItemNumber == itemNumber)
                {
                    return menuItem;
                }

            }
            return null;
        }

        public List<string> ViewIngredients (MenuItem menuItem)
        {
            //GetMenuItemByNumber(menuItem.ItemNumber);
            return menuItem.Ingredients;
            

        }


        public List<string> AddIngredientToMenuItem (MenuItem menuItem,string ingredientList)
        {
            string[] ingredientsToAdd = ingredientList.Split(',');

          
            foreach(var ingredient in ingredientsToAdd)
            {
                menuItem.Ingredients.Add(ingredient);
            }
            return menuItem.Ingredients;
        }

        public void SeedMenu ()
        {
            //string ingredientList = "patty, bun, cheese";
            //string[] ingredientsToAdd = ingredientList.Split(',');
            //List<string> 
            MenuItem cheeseburger = new MenuItem("1", "Cheeseburger", "Burger with Cheese",new List<string> {"patty", "bun", "cheese" } , "5.99");
            _menu.Add(cheeseburger);

        }
    }
}
