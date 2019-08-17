using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Badge_Classes;

namespace Komodo_Badge
{
    class ProgramUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedDictionary();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Create a Badge\n" +
                    "2. Edit a Badge's Access\n" +
                    "3. View all Badges and their Access\n" +
                    "4. Exit\n" +
                    "");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Create a Badge
                        CreateABadgeWithValue();
                        break;
                    case "2":
                        //Edit a Badge
                        //Find a Badge
                        //Add
                        //Remove
                        //Remove All
                        EditBadge();

                        break;
                    case "3":
                        //View all Badges & Access
                        ViewAllBadges();
                        break;
                    case "4":
                        //Exit
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }
            private void CreateABadgeWithValue()
            {
            Console.Clear();
            Console.WriteLine("Enter an ID for new Badge: ");
            int badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter rooms, separated by a comma, that badge {badgeID} will have access to. ");
            string roomAccess = Console.ReadLine();
            _badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);

            }

            private void EditBadge()
        {
            //Get User Input & Return a badge
            Console.Clear();
            Console.WriteLine("Enter an ID for the Badge to edit: ");
            int badgeID = int.Parse(Console.ReadLine());
           // List<string> badgeAccess = _badgeRepo.ReturnBadgeAccess(badgeID);
            IDictionary<int, List<string>> badgeAccess = _badgeRepo.ReturnDictionary();

            //Display that badge's access
            DisplaySingleBadgeRoomAccess(badgeID, badgeAccess[badgeID]);

            //Prompt if this is the badge you want to edit after seeing its access
            Console.WriteLine();
            Console.WriteLine("Would you like to edit this Badge?");

            string editBadge = Console.ReadLine();
            if (editBadge == "y")
            {

                // Add or Remove
                Console.WriteLine("Would you like to \"add\" or \"remove\" room access for this badge?");
               string addOrRemove = Console.ReadLine().ToLower();
                if (addOrRemove == "add")
                { 
                        //Add Room Access to captured badge
                Console.WriteLine($"What room(s) would you like to add to Badge {badgeID}?");
                    string roomsToAdd = Console.ReadLine();
                     
                   _badgeRepo.AddBadgeAccess(badgeAccess[badgeID], roomsToAdd);
                    Console.Clear();
                    DisplaySingleBadgeRoomAccess(badgeID, badgeAccess[badgeID]);
                }
                else if (addOrRemove == "remove")
                {
                    Console.WriteLine("Enter rooms you wish to remove: ");
                    Console.WriteLine("Enter \"all\" to remove all rooms from badge");
                    string roomsToRemove = Console.ReadLine();
                    if (roomsToRemove == "all")
                    {
                        _badgeRepo.RemoveAllRoomsFromBadge(badgeID);
                        // prompt user to remove badge or keep badge
                        Console.WriteLine("Would you like to remove this badge from Dictionary?");
                        string removeBadge = Console.ReadLine();
                        if (removeBadge == "y")
                        {
                            _badgeRepo.RemoveBadgeFromDictionary(badgeID);
                        }
                        else if (removeBadge == "n")
                        {
                            Console.WriteLine("You must enter rooms for access if not removing Badge from Dictionary\n" +
                                " \n" +
                                $"Enter rooms you would like to give Badge {badgeID} access to: ");
                        }
                        else if (removeBadge == "exit") { }
                        else
                        {
                            Console.WriteLine("Please enter a \"y\", \"n\", or \"exit\"");
                        }

                    }
                    else
                        _badgeRepo.RemoveBadgeAccess(badgeID, roomsToRemove);
                }
                else if (addOrRemove == "exit")
                { Console.WriteLine("Badge Access not changed"); }
                else
                { Console.WriteLine("Please enter a valid response : \"add\" , \"remove\" , or \"exit\""); }
            }

        }

            private void DisplaySingleBadgeRoomAccess(int badgeID, List<string> badgeAccess)
        {

            Console.WriteLine($"{badgeID} has access to rooms: ");
            foreach (var room in badgeAccess)
            {
                Console.Write(room);

            }
            Console.WriteLine();
        }

        private void ViewAllBadges()
        {
            Console.Clear();
           IDictionary<int,List<string>> badgeAccess = _badgeRepo.ReturnDictionary();

            foreach (var badge in badgeAccess)
            {
                Console.WriteLine("Badge ID: " + badge.Key + " has access to rooms:");
                foreach (string room in badge.Value)
                    Console.WriteLine(room);
            }

        }

        private void SeedDictionary()
        {
            
           
            _badgeRepo.AddBadgeToDictionary(111,"A101, A102, A103");
            _badgeRepo.AddBadgeToDictionary(112, "B101, B102, B103");
            _badgeRepo.AddBadgeToDictionary(113, "C101, C102, C103");


        }















    }
}
