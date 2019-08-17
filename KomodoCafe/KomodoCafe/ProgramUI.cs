using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Cafe_Classes;

namespace KomodoCafe
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            _menuRepo.SeedMenu();

            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu
                Console.WriteLine("Select a menu option:\n" +
                    "1. View Menu \n" +
                    "2. View Ingredients for a Menu Item\n" +
                    "3. Create Menu Item \n" +
                    "4. Delete Menu Item \n" +
                    "5. Exit \n");

                //Get User's input
                string input = Console.ReadLine();

                //SwitchCase to evaluate input

                switch (input)
                {
                    case "1":
                        //Get Menu List
                        DisplayMenuWithNumber_Name_Price();
                        break;
                    case "2":
                        //View Ingredients for an ItemNumber
                        ViewIngredientsForAnItem();
                        break;
                    case "3":
                        CreateNewMenuItem();
                        //Create Menu Item
                        break;
                    case "4":
                        //Delete Menu Item
                        RemoveMenuItem();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        private void DisplayMenuWithNumber_Name_Price()
        {
            Console.Clear();
            List<MenuItem> listOfItems = _menuRepo.GetMenu();
            foreach (MenuItem item in listOfItems)
            {
                Console.WriteLine($" Number:{item.ItemNumber} - {item.Name}: {item.Price}");
                Console.WriteLine();
            }

        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            // ItemNumber
            Console.WriteLine("Enter a Number for the Menu Item:");
            newItem.ItemNumber = Console.ReadLine();


            //Name
            Console.WriteLine("Enter a Name for the Menu Item:");
            newItem.Name = Console.ReadLine();


            //Description
            Console.WriteLine("Enter a Description for the Menu Item:");
            newItem.Description = Console.ReadLine();
            Console.WriteLine();
            _menuRepo.CreateNewMenuItem(newItem);

            Console.WriteLine();
            //Ingredients
            Console.WriteLine("Enter a List of Ingredients for the Menu Item:\n" +
                "(Separate ingredients with a comma)");
            string ingredients = Console.ReadLine();

            newItem.Ingredients = _menuRepo.AddIngredientToMenuItem(newItem, ingredients);


            //Price
            Console.WriteLine("Enter the Selling Price for the Menu Item:");
            newItem.Price = Console.ReadLine();



        }

        private void RemoveMenuItem()
        {
            DisplayMenuWithNumber_Name_Price();
            Console.WriteLine("Enter the Number of the Item you would like to remove");
            string MenuItemNumber = Console.ReadLine();
            _menuRepo.DeleteMenuItem(MenuItemNumber);
                
        }

        private void ViewIngredientsForAnItem()
        {
            DisplayMenuWithNumber_Name_Price();
            Console.WriteLine("Enter the Number of the Item you would like to view)");
            string menuItemNumber = Console.ReadLine();
           MenuItem item = _menuRepo.GetMenuItemByNumber(menuItemNumber);
            Console.Clear();
            Console.WriteLine($"{item.Name} has the following ingredients:");

           foreach(string ingredient in item.Ingredients)
            {
                Console.WriteLine(ingredient);
            }

           // _menuRepo.ViewIngredients(item);
            
            
            
        }


 







    }
}

