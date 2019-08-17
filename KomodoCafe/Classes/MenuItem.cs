using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Classes

{

    public class MenuItem
    {
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } // string.split
        public string Price { get; set; }

        public MenuItem() { }
        public MenuItem(string itemNumber, string name, string description, List<string> ingredients, string price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }

}
