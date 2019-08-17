using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge_Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }
       public List<string> RoomAccess { get; set; }

        public Badge() { }
        public Badge(int badgeID, List<string> roomAccess)
        {
            BadgeID = badgeID;
            RoomAccess = roomAccess;
        }

    }
}
