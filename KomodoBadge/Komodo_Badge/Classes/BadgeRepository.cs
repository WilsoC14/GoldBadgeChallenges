using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge_Classes
{
    public class BadgeRepository
    {

        private readonly IDictionary<int, List<string>> badgeAccess = new Dictionary<int, List<string>>();



        public void AddBadgeToDictionary(int badgeID, string roomAccess)
        {
            //method in UI will need to give a badgeID and a string of rooms to Access
            Badge badgeToAdd = new Badge();
            badgeToAdd.BadgeID = badgeID;

            badgeToAdd.RoomAccess = new List<string>();
            string[] roomsToGiveAccess = roomAccess.Split(',');

            foreach (var room in roomsToGiveAccess)
            {
                badgeToAdd.RoomAccess.Add(room);


            }
            badgeAccess.Add(badgeID, badgeToAdd.RoomAccess);

        }
        //View All Badges
        public IDictionary<int, List<string>> ReturnDictionary()
        {
            return badgeAccess;


        }

        public List<string> ReturnBadgeAccess(int badgeID)
        {
            if (badgeAccess.ContainsKey(badgeID))
                return badgeAccess[badgeID];
            else return null;
        }



        public void AddBadgeAccess(List<string> badgeAccess, string roomsToAdd)
        {   
            string[] roomsToGiveAccess = roomsToAdd.Split(',');

            foreach (var room in roomsToGiveAccess)
            {
                badgeAccess.Add(room);
            }
          
        }



        public void RemoveBadgeAccess(int badgeID, string roomsToRemove)
        {
            //  List<string> accessRooms = badgeAccess[badgeID];
            string[] rooms = roomsToRemove.Split(',');

            foreach (var room in rooms)
            {
                badgeAccess[badgeID].Remove(room);
            }

           
        }
        public void RemoveAllRoomsFromBadge(int badgeID)
        {

            badgeAccess[badgeID] = new List<string>();

        }


        public void RemoveBadgeFromDictionary(int badgeID)
        {
            if (badgeAccess.ContainsKey(badgeID))
            {
                badgeAccess.Remove(badgeID);
            }

        }




    }
}

