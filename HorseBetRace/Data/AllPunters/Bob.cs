using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseBetRace.Data.AllPunters
{
    public class Bob : Punter 
    {
        public Bob() // Sets up the punter Bob
        {
            PunterName = "Bob";
            Cash = 50;
        }
    }
}
