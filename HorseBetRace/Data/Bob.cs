using System.Windows.Forms;

namespace HorseBetRace.Data.AllPunters
{
    public class Bob : Punter
    {
        public Bob() // Sets up the punter Bob
        {
            PunterName = "Bob";
            Cash = 50;
        }

        public override string PunterName { get; set; }
        public override Bet MyBet { get; set; }
        public override int Cash { get; set; }
        public override RadioButton MyRadioButton { get; set; }
        public override Label MyLabel { get; set; }

    }
}
