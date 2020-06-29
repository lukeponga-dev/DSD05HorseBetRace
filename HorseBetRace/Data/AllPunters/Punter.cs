using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseBetRace.Data.AllPunters
{
   public abstract class Punter
    {
        public string PunterName { get; set; } // The punters name
        public Bet MyBet { get; set; } // An instance of Bet() that has punters bet
        public int Cash { get; set; } // How much money punter has
        public RadioButton MyRadioButton { get; set; } //Radiobutton
        public Label MyLabel { get; set; } //Label

        public void
            UpdateLabels() // Set my label to my bets description and the label on the radio button to show the punters cash
        {
            MyLabel.Text = MyBet.GetDescription();
        }
        public bool PlaceBet(int betAmount, int horseToWin) // Place a new bet and store it in my bet field
        {
            if (Cash >= betAmount)
            {
                MyBet = new Bet()
                {
                    Amount = betAmount,
                    Horse = horseToWin,
                    Bettor = this
                };
                UpdateLabels();
                return true;
            }
            //return false if punter did not have enough cash
            else
            {
                MessageBox.Show(PunterName + @" doesn't have enough to bet");
                return false;
            }

        }
   }

   public class Joe : Punter // Inherit from the Punter class
   {
       public Joe() // Sets up the punter Joe
       {
           PunterName = "Joe";
           Cash = 50;
       }
   }

   public class Bob : Punter // Inherit from the Punter class
   {
       public Bob() // Sets up the punter Bob
       {
           PunterName = "Bob";
           Cash = 50;
       }
   }


   public class Al : Punter // Inherit from the Punter class
   {
       public Al() // Sets up the punter Al
       {
           PunterName = "Al";
           Cash = 50;
       }
   }
}
