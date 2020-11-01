using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class KomodoBadgesRepo
    {
        private Dictionary<int, List<string>> _doors = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> GetDictionary() 
        {
            return _doors;
        }


        public void AddBadge(Badges badge)
        {
            _doors.Add(badge.BadgeID, badge.Doors);
        }

       
    }
}