using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseBetRace.Data.AllPunters
{
    public static class Factory
    {
        // Decides which class to instantiate
        public static Punter GetAPunter(int id)
        {
            switch (id)
            {
                case 0: return new Joe();
                case 1: return new Bob();
                case 2: return new Al();
                default: return null;
            }
        }
    }
}
