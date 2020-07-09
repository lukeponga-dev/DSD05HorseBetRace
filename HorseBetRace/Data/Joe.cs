using HorseBetRace.Data.AllPunters;
using System.Windows.Forms;

namespace HorseBetRace.Data
{
    public class Joe : Punter // Inherit from the Punter class
    {
        public override string PunterName { get; set; }
        public override Bet MyBet { get; set; }
        public override int Cash { get; set; } 
        public override RadioButton MyRadioButton { get; set; }
        public override Label MyLabel { get; set; }
        
        // Sets up the punter Joe
        public Joe()
        {
            PunterName = "Joe";
            Cash = 50;
        }
    }
}